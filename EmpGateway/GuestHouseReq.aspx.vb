Imports System.Data.SqlClient
Imports System.Data
Partial Class GuestHouseReq
    Inherits System.Web.UI.Page
    Dim sqlpass, sqlpass1 As String
    Dim obj As New HelpDeskClass
    Dim obj2 As New Connection
    Dim dr As SqlDataReader
    Dim cmd As SqlCommand
    Dim jctian As String
    Dim sql As String
    Dim Obj1 As New Connection
    Dim EmailTO As String
    Dim empname, emp_desg, emp_dept As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack = False Then
            Me.RadioButtonList1.Items(0).Selected = True
            Me.RLCharge.Items(0).Selected = True
            Me.RLDrink1.Items(0).Selected = True
            Me.RLFood.Items(0).Selected = True
            RadioButtonList1_SelectedIndexChanged(sender, e)
            'Session("Loc")
            RLCharge.Items(0).Selected = True
            Me.PnlYes.Visible = False
            Me.PnlNo.Visible = False
            GetCompany()
            GetDept()
            GetEmp()
            GetGuestHouse()
            If Request.QueryString("Trans") <> "" Then
                Show(Convert.ToInt16(Request.QueryString("Trans")))
            End If
            'If Session("Empcode") <> "" Then
            '    obj.opencn()
            '    sqlpass = "select EmpCode,EmpName,DeptCode from JCT_Empmast_Base where empcode='" & Session("Empcode") & "'"
            '    cmd = New SqlCommand(sqlpass, obj.cn)
            '    dr = cmd.ExecuteReader
            '    dr.Read()
            '    Me.DdlDept.SelectedValue = dr(2)
            '    Me.DdlName.SelectedItem.Text = dr(1)
            '    obj.closecn()
            'End If
            '----------------------------
            If (Request.QueryString.Get("reply")) = 1 Then
                disable()
                Me.PnlAuth.Visible = True
                Me.LnkSub.Text = "Authorize"
                TctAccname.Visible = True
                Me.DdlName.Visible = False
                Me.LnkClear.Enabled = False
                Me.CLMeal.Visible = False
                LnkCancel.Visible = True
                '---------------

                obj.opencn()
                sql = "select name,address,personno,tocharge,stayrequired,meals,servedrinks,personaccdept,personaccname,convert(varchar(12),stdurationfrom,101) as datefrom,convert(varchar(12),stdurationto,101) as dateto,accommodation,food,authflag,jctian,jctian_empcode,guest_phone,accon_type,convert(varchar(12),Meal_Date,101) as Meal_Date from JCT_EMP_GUESTHOUSE where transactionno=" & Request.QueryString.Get("Guest") & " "
                cmd = New SqlCommand(sql, obj.cn)
                dr = cmd.ExecuteReader
                If dr.HasRows = True Then
                    dr.Read()
                    If dr.Item(0) Is System.DBNull.Value Then
                        Response.Write("<script>alert('No Survey For Authorization')</script>")
                    Else
                        If dr("jctian") = "Y" Then
                            Me.RadioButtonList1.Items(1).Selected = True
                            Me.RadioButtonList1.Items(0).Selected = False
                            Me.RadioButtonList1_SelectedIndexChanged(sender, e)
                            Me.txtempcode.Text = dr("jctian_empcode")
                        Else
                            Me.RadioButtonList1.Items(0).Selected = True
                            Me.RadioButtonList1.Items(1).Selected = False
                            Me.txtempcode.Text = ""
                        End If
                        Me.TxtName.Text = dr("name")
                        Me.TxtPerson.Text = dr("personno")
                        Me.TxtAdd.Text = dr("address")
                        Me.TxtGuestPhone.Text = dr("guest_phone")
                        Me.RLCharge.SelectedValue = dr("tocharge")
                        Me.RLDrink1.SelectedValue = dr("servedrinks")
                        Me.RLFood.SelectedValue = dr("food")
                        Me.RLStay.SelectedValue = dr("stayrequired")
                        Me.Datefrom.Text = dr("datefrom")
                        Me.Dateto.Text = dr("dateto")
                        If RLStay.Items(0).Selected = True Then
                            Me.RLStay_SelectedIndexChanged(sender, e)
                            Me.DdlAccomm.SelectedValue = dr("accon_type")
                            TxtAccomm.Text = dr("Accommodation")

                        Else
                            Me.RLStay_SelectedIndexChanged(sender, e)
                            Me.DdlDept.SelectedValue = dr("personaccdept")
                            'GetEmp()
                            Me.TctAccname.Text = dr("personaccname")
                            Me.txtmeal.Text = dr("Meals")
                        End If
                    End If
                    obj.closecn()
                End If
            ElseIf (Request.QueryString.Get("reply")) = 2 Then
                Me.LnkCancel.Enabled = False
                Me.LnkSub.text = "Authorize"
                Me.LnkSub.Enabled = False
                Me.LnkClear.Enabled = False
            Else
                Me.PnlAuth.Visible = False
                Me.LnkSub.Text = "Submit"
                TctAccname.Visible = False
                Me.txtmeal.Visible = False
                LnkCancel.Visible = False
            End If
        End If
    End Sub
    Protected Sub RLStay_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RLStay.SelectedIndexChanged
        StayReq()
        DdlAccomm_SelectedIndexChanged(sender, e)
    End Sub
    Private Sub GetCompany()
        obj.opencn()
        sqlpass = "select CompanyCode,Companyname,Location from jctgen..JCT_Company_Master"
        cmd = New SqlCommand(sqlpass, obj.cn)
        dr = cmd.ExecuteReader
        While dr.Read
            Me.DdlComp.Items.Add(dr(1) + " ~ " + dr(2))
            Me.DdlComp.Items(DdlComp.Items.Count - 1).Value = dr(0)
        End While
        dr.Close()
        obj.closecn()
    End Sub
    Private Sub StayReq()
        If Me.RLStay.SelectedValue = "Y" Then
            Me.PnlYes.Visible = True
            Me.PnlNo.Visible = False
        ElseIf Me.RLStay.SelectedValue = "N" Then
            Me.PnlYes.Visible = False
            Me.PnlNo.Visible = True
        End If
    End Sub
    Private Sub GetGuestHouse()
        obj.opencn()
        sqlpass = "select guesthouse from Jct_Emp_Guest_Accom where Companycode='" & Me.DdlComp.SelectedValue & "' and status='A'"
        cmd = New SqlCommand(sqlpass, obj.cn)
        dr = cmd.ExecuteReader
        Me.DdlAccomm.Items.Clear()

        If dr.HasRows Then
            While dr.Read
                Me.DdlAccomm.Items.Add(dr(0))
            End While
        End If
        Me.DdlAccomm.Items.Add("Other")
        dr.Close()
        obj.closecn()
    End Sub
    Private Sub GetGuestHouse_aDDRESS()
        If (Request.QueryString.Get("reply")) = 1 Then

        Else
            Dim dr2 As SqlDataReader
            Dim cmd1 As New SqlCommand
            obj.opencn()
            sql = "select DESCRIPTION from Jct_Emp_Guest_Accom where Companycode='" & Me.DdlComp.SelectedValue & "' and status='A' AND GUESTHOUSE='" & Trim(Me.DdlAccomm.SelectedValue) & "'"
            cmd1 = New SqlCommand(sql, obj.cn)
            dr2 = cmd1.ExecuteReader
            If dr2.HasRows Then
                While dr2.Read
                    Me.TxtAccomm.Text = dr2(0)
                    
                End While
            Else
                Me.TxtAccomm.Text = ""
            End If
            dr2.Close()
            obj.closecn()
        End If
       
    End Sub
    Private Sub GetDept()
        Dim dr1 As SqlDataReader
        obj.opencn()
        Me.DdlDept.Items.Clear()
        sqlpass = "select deptcode,deptname from deptmast where company_code='" & Me.DdlComp.SelectedValue & "' order by deptname"
        cmd = New SqlCommand(sqlpass, obj.cn)
        dr1 = cmd.ExecuteReader
        Me.DdlDept.Items.Add("")
        Me.DdlDept.Items.Add("All")
        While dr1.Read
            Me.DdlDept.Items.Add(dr1(1))
            Me.DdlDept.Items(DdlDept.Items.Count - 1).Value = dr1(0)
        End While
        dr1.Close()
        obj.closecn()
    End Sub
    Private Sub GetEmp()
        obj.opencn()
        Me.DdlName.Items.Clear()
        If Me.DdlDept.SelectedValue = "All" Then
            sqlpass = "select distinct empname from JCT_Empmast_Base order by empname"
        Else
            sqlpass = "select distinct empname from JCT_Empmast_Base where deptcode='" & Me.DdlDept.SelectedValue & "' order by empname"
        End If
        'Dim ds As New DataSet
        'Dim adp As New SqlDataAdapter(sqlpass, obj.cn)
        'adp.Fill(ds, "JCT_Empmast_Base")
        'Dim dv As DataView = ds.Tables(0).DefaultView
        'dv.Sort = "empname"
        'Me.DdlName.DataSource = dv
        'Me.DdlName.DataTextField = "empname"
        'Me.DdlName.DataValueField = "empname"
        'Me.DdlName.DataBind()
        '----------------------------
        Dim dr1 As SqlDataReader
        cmd = New SqlCommand(sqlpass, obj.cn)
        dr1 = cmd.ExecuteReader
        While dr1.Read
            Me.DdlName.Items.Add(dr1(0))
            Me.DdlName.Items(DdlName.Items.Count - 1).Value = dr1(0)
        End While
        dr1.Close()
        obj.closecn()
        'cmd = New SqlCommand(sqlpass, obj.cn)
        'dr = cmd.ExecuteReader
        'While dr.Read
        '    Me.DdlName.Items.Add(dr(0))
        '    Me.DdlName.Items(DdlName.Items.Count - 1).Value = dr(0)
        'End While
        'dr.Close()
        obj.closecn()
    End Sub

    Protected Sub DdlDept_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DdlDept.SelectedIndexChanged
        GetEmp()
    End Sub

    Protected Sub DdlComp_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DdlComp.SelectedIndexChanged
        GetDept()
        GetGuestHouse()
    End Sub
    Private Sub Show(ByVal trans As Integer)
        obj.opencn()
        sqlpass = "select * from JCT_EMP_GUESTHOUSE where transactionNo=" & trans & " and (status<>'D' or status is null)"
        cmd = New SqlCommand(sqlpass, obj.cn)
        dr = cmd.ExecuteReader
        dr.Read()

        Me.DdlComp.SelectedValue = dr(0)
        Me.TxtName.Text = dr("Name")
        Me.TxtAdd.Text = dr("Address")
        Me.TxtPerson.Text = dr("PersonNo")
        Me.RLCharge.SelectedValue = dr("ToCharge")
        Me.RLStay.SelectedValue = dr("StayRequired")
        If dr("StayRequired") = "Y" Then
            Me.PnlYes.Visible = True
            Me.PnlNo.Visible = False
            Me.Datefrom.Text = dr("StDurationFrom")
            Me.Dateto.Text = dr("StDurationTo")
            Me.DdlAccomm.SelectedValue = StrReverse(Mid(StrReverse(dr("Accommodation").ToString), InStr(StrReverse(dr("Accommodation").ToString), "-") + 1, StrReverse(dr("Accommodation").ToString).Length))
            Me.TxtAccomm.Text = StrReverse(Mid(StrReverse(dr("Accommodation").ToString), InStr(StrReverse(dr("Accommodation").ToString), "-") + 1, StrReverse(dr("Accommodation").ToString).Length))
            Me.RLDrink1.SelectedValue = dr("ServeDrinks")
            Me.RLFood.SelectedValue = dr("Food")
        Else
            Me.PnlYes.Visible = False
            Me.PnlNo.Visible = True
            Me.RLDrink1.SelectedValue = dr("ServeDrinks")
            Me.DdlDept.SelectedValue = dr("PersonAccDept")
            Me.DdlName.SelectedValue = dr("PersonAccName")
            For i As Integer = 0 To 3
                If InStr(dr("Meals").ToString, Me.CLMeal.Items(i).Value.ToString) <> 0 Then
                    Me.CLMeal.Items(i).Selected = True
                Else
                    CLMeal.Items(i).Selected = False
                End If
            Next
        End If

        obj.closecn()
    End Sub
    Protected Sub LnkSub_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LnkSub.Click
        Dim lunch As String
        Dim dinner As String
        Dim Breakfast As String
        Dim Snacks As String
        If CLMeal.Items(0).Selected = True Then
            Breakfast = Me.CLMeal.Items(0).Text
        Else
            Breakfast = "Null"
        End If
        If CLMeal.Items(1).Selected = True Then
            lunch = Me.CLMeal.Items(1).Text
        Else
            lunch = "Null"
        End If
        If CLMeal.Items(2).Selected = True Then
            Snacks = Me.CLMeal.Items(2).Text
        Else
            Snacks = "Null"
        End If

        If CLMeal.Items(3).Selected = True Then
            dinner = Me.CLMeal.Items(3).Text
        Else
            dinner = "Null"
        End If

        '----------------------------------------
        If Me.RadioButtonList1.Items(1).Selected = True And Me.txtempcode.Text = "" Then
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "scr", "<script language = javascript>alert('Please fill Employee Code')</script>")
            Exit Sub
        End If
        get_employee_name()
        obj.opencn()
        Dim accom As String, meal As String = ""
        If Me.DdlAccomm.SelectedValue = "Other" Then
            accom = Me.TxtAccomm.Text + "-" + Me.DdlComp.SelectedItem.Text
        Else
            accom = Me.DdlAccomm.SelectedValue + "-" + Me.DdlComp.SelectedItem.Text
        End If
        For i As Integer = 0 To Me.CLMeal.Items.Count - 1
            If Me.CLMeal.Items(i).Selected = True Then
                meal = meal + "|" + CLMeal.Items(i).Text
            End If
        Next
        Try
            If Me.LnkSub.Text = "Submit" Then
                If Me.RadioButtonList1.Items(1).Selected = True Then
                    jctian = "Y"
                Else
                    jctian = "N"
                End If

                '------------------------Submit Request------------------------------
                If Me.RLStay.SelectedValue = "Y" Then
                    If Me.TxtAccomm.Text = "" Then
                        Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "scr", "<script language = javascript>alert('Please fill Accom. Desc.')</script>")
                        Exit Sub
                    End If
                    sqlpass = "insert into JCT_EMP_GUESTHOUSE(CompanyCode,EmpCode,[Name],Address,PersonNo,ToCharge,StayRequired,ServeDrinks,StDurationFrom,StDurationTo,Accommodation,Food,AuthFlag,jctian,jctian_empcode,Guest_Phone,Accon_type,flaghc,createddt,employeeE_name,Breakfast,Lunch,Snacks,Dinner,emp_desg,emp_dept)" & _
                              "values('" & Session("CompanyCode") & "','" & Session("Empcode") & "','" & Me.TxtName.Text & "','" & Me.TxtAdd.Text & "'," & _
                              "'" & Me.TxtPerson.Text & "','" & Me.RLCharge.SelectedValue & "','" & Me.RLStay.SelectedValue & "','" & Me.RLDrink1.SelectedValue & "'," & _
                              "'" & Me.Datefrom.Text & "','" & Me.Dateto.Text & "','" & accom & "','" & Me.RLFood.SelectedValue & "','P','" & Trim(jctian) & "','" & Trim(Me.txtempcode.Text) & "','" & Trim(Me.TxtGuestPhone.Text) & "','" & Trim(Me.DdlAccomm.SelectedValue) & "','1H',GETDATE(),'" & Trim(empname) & "','" & Breakfast & "','" & lunch & "','" & Snacks & "','" & dinner & "','" & Trim(emp_desg) & "','" & Trim(emp_dept) & "')"

                ElseIf Me.RLStay.SelectedValue = "N" Then
                    sqlpass = "insert into JCT_EMP_GUESTHOUSE(CompanyCode,EmpCode,[Name],Address,PersonNo,ToCharge,StayRequired,Meals,ServeDrinks,PersonAccDept,PersonAccName,AuthFlag,jctian,jctian_empcode,food,Guest_Phone,flaghc,createddt,employeee_name,Breakfast,Lunch,Snacks,Dinner,StDurationFrom,StDurationTo,emp_desg,emp_dept)" & _
                              "values('" & Session("CompanyCode") & "','" & Session("Empcode") & "','" & Me.TxtName.Text & "','" & Me.TxtAdd.Text & "'," & _
                              "'" & Me.TxtPerson.Text & "','" & Me.RLCharge.SelectedValue & "','" & Me.RLStay.SelectedValue & "','" & meal & "','" & Me.RLDrink1.SelectedValue & "','" & Me.DdlDept.SelectedValue & "','" & Me.DdlName.SelectedValue & "','P','" & Trim(jctian) & "','" & Trim(Me.txtempcode.Text) & "','" & Me.RLFood.SelectedValue & "','" & Trim(Me.TxtGuestPhone.Text) & "','1H',GETDATE(),'" & Trim(empname) & "','" & Breakfast & "','" & lunch & "','" & Snacks & "','" & dinner & "','" & Me.Datefrom.Text & "','" & Me.Dateto.Text & "','" & Trim(emp_desg) & "','" & Trim(emp_dept) & "')"
                End If
                cmd = New SqlCommand(sqlpass, obj.cn)
                cmd.ExecuteNonQuery()
                ' Me.ClientScript.RegisterClientScriptBlock(Me.GetType, "msg", "<script language = javascript>alert('Request Added')</script>")
                Me.Label25.Visible = True
                'Dim empcode As String = cmd.ExecuteScalar
                sqlpass = "select e_mailid from mistel where empcode='" & Session("Empcode") & "'"
                cmd = New SqlCommand(sqlpass, obj.cn)
                Dim empemail As String = cmd.ExecuteScalar
                '-------------e mail to------------------------------------------------------
                email_to()
                '-----------------------
                sendmail(empemail, EmailTO, "submit")
		'sendmail(empemail, GetEmailID("N-02632"), "submit")
                '-----------------------------------------------------------------

            ElseIf Me.LnkSub.Text = "Authorize" Then

                '-------------------------Authorize Request----------------------
                sql = "update JCT_EMP_GUESTHOUSE set authFlag='A',AuthBy='" & Session("Empcode") & "',AuthDate=getdate(),AuthRemarks='" & Me.TxtauthRemarks.Text & "',flaghc='' where transactionno=" & Request.QueryString.Get("Guest") & " and AuthFlag<>'A' and status is null"
                cmd = New SqlCommand(sql, obj.cn)
                cmd.ExecuteNonQuery()
                Me.ClientScript.RegisterClientScriptBlock(Me.GetType, "msg", "<script language = javascript>alert('Request Authorized')</script>")
                sqlpass = "select empCode from JCT_EMP_GUESTHOUSE where transactionno=" & Request.QueryString.Get("Guest") & " and AuthFlag='A'"
                cmd = New SqlCommand(sqlpass, obj.cn)
                Dim empcode As String = cmd.ExecuteScalar
                sqlpass = "select e_mailid from mistel where empcode='" & empcode & "'"
                cmd = New SqlCommand(sqlpass, obj.cn)
                Dim empemail As String = cmd.ExecuteScalar
                '------------------------------------------
                sqlpass = "select e_mailid from mistel where empcode='" & Session("Empcode") & "'"
                cmd = New SqlCommand(sqlpass, obj.cn)
                Dim empcodefrom As String = cmd.ExecuteScalar
                sendmail(empcodefrom, empemail, "Auth")
                '---------------------------------------------------------------
                Response.Redirect("MyWorkArae.aspx")
            End If

        Catch ex As Exception
            Me.ClientScript.RegisterClientScriptBlock(Me.GetType, "msg", "<script language = javascript>alert('Improper Data!!')</script>")
        End Try
        obj.closecn()
    End Sub
    Public Sub email_to()
        Dim SqlPass = "SELECT e_mailid from JCTDEV..JCT_EMP_HOD a,JCTDEV..MISTEL b WHERE b.EmpCode=a.Resp_Emp and  emp_code='" & Session("Empcode") & "' and flag in('1H') and status is null AND Auth_Req='Y'and Days=0 and a.Company_Code='" & Session("Companycode") & "'"
        Dim Dr As SqlDataReader = Obj1.FetchReader(SqlPass)
        Try
            If Dr.HasRows = True Then
                While Dr.Read()
                    If Not (Dr.Item(0) Is System.DBNull.Value) Then
                        empname = Dr.Item(0)
                    End If
                End While
                Dr.Close()
            End If

        Catch ex As Exception
        Finally
            obj.closecn()
        End Try
    End Sub
    Public Sub get_employee_name()
        Dim SqlPass = "select empname,desg,deptname from jct_empmast_base a, deptmast b WHERE a.deptcode=b.deptcode and  empcode='" & Session("Empcode") & "' and a.company_code='" & Session("Companycode") & "'"
        Dim Dr As SqlDataReader = Obj1.FetchReader(SqlPass)
        Try
            If Dr.HasRows = True Then
                While Dr.Read()
                    If Not (Dr.Item(0) Is System.DBNull.Value) Then
                        empname = Dr.Item(0)
                        emp_desg = Dr(1)
                        emp_dept = Dr(2)
                    End If
                End While
                Dr.Close()
            End If

        Catch ex As Exception
        Finally
            obj.closecn()
        End Try
    End Sub
    Private Sub sendmail(ByVal From1 As String, ByVal Too As String, ByVal type As String)
        Dim mailclient As New Net.Mail.SmtpClient

        'Dim mail As System.Net.Mail.SmtpClient

        'Dim frm As New Net.Mail.MailAddress(From1)

        Dim from As String
        'With message
        obj2.ConOpen()

        '---------------Get Name,Dept and Email ID Of Sender----------------- 
        sqlpass = "select e_mailid from mistel where empcode='" & Session("empcode") & "'"
        Dim dr As SqlDataReader = obj2.FetchReader(sqlpass)
        If dr.HasRows = True Then
            dr.Read()
            If dr.Item(0) Is System.DBNull.Value Then
                from = From1 '"dummy@jctltd.com"
            Else
                ' Dim frm2 As New Net.Mail.MailAddress(dr.Item(0))
                from = dr.Item(0)
            End If
        Else
            from = From1 '"dummy@jctltd.com"
        End If
        dr.Close()
        sqlpass = "select empname from jct_empmast_base where empcode='" & Session("empcode") & "'"
        Dim cmd As New SqlCommand(sqlpass, obj2.Connection)
        Dim name As String = cmd.ExecuteScalar
        sqlpass = "select b.deptname from jct_empmast_base a,deptmast b where empcode='" & Session("empcode") & "' and a.deptcode=b.deptcode"
        cmd = New SqlCommand(sqlpass, obj2.Connection)
        Dim dept As String = cmd.ExecuteScalar
        '----------------------------------------------------------------
        obj2.ConClose()

        'Too = Too
        Too = "ramandeep@jctltd.com"
        'message.To.Add(Too)
        Dim message As New System.Net.Mail.MailMessage(From1, Too)
        message.IsBodyHtml = True
        If type = "Auth" Then
            message.Body = name & " has authorized your Guest House Request" & "<br/><br/><br/><br/><br/><br/><br/> DISCLAIMER: This email has been generated through Employee Gateway Package. <br/>Kindly do not reply as you will not receive a response."
            message.Subject = "Guest House Request"
        ElseIf type = "Cancel" Then
            message.Body = name & " has Cancelled your Guest House Request" & "<br/><br/><br/><br/><br/><br/><br/> DISCLAIMER: This email has been generated through Employee Gateway Package. <br/>Kindly do not reply as you will not receive a response."
            message.Subject = "Guest House Request"
        Else
            message.Body = name & " of department : " & dept & " has submitted a new Guest House Request, Needs Your Authorization !!!!" & "<br/><br/><br/><br/><br/><br/><br/> DISCLAIMER: This email has been generated through Employee Gateway Package. <br/>Kindly do not reply as you will not receive a response."
            message.Subject = "Guest House Request"
        End If
        mailclient.Host = "EXCHANGE2007"
        If Too <> "" Or Not Too Is Nothing Then
            mailclient.Send(message)
            mailclient = Nothing
        End If
        'End With
    End Sub
    Protected Sub LnkClear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LnkClear.Click
        reset()
    End Sub
    Private Sub reset()
        Me.label25.visible = False
        Me.DdlComp.SelectedIndex = 0
        Me.TxtName.Text = ""
        Me.TxtAdd.Text = ""
        Me.TxtPerson.Text = ""
        Me.Datefrom.Text = Date.Today
        Me.Dateto.Text = Date.Today
        Me.DdlAccomm.SelectedIndex = 0
        Me.TxtAccomm.Text = ""
        Me.TxtauthRemarks.Text = ""
        Me.txtempcode.Text = ""
        Me.TxtGuestPhone.Text = ""
        For Each chk As ListItem In Me.RLStay.Items
            chk.Selected = False
        Next
        For Each chk As ListItem In Me.RLStay.Items
            chk.Selected = False
        Next
        'For Each chk As ListItem In Me.RLCharge.Items
        '    chk.Selected = False
        'Next
        'For Each chk As ListItem In Me.RLDrink1.Items
        '    chk.Selected = False
        'Next
        'For Each chk As ListItem In Me.RLDrink1.Items
        '    chk.Selected = False
        'Next
        'For Each chk As ListItem In Me.RLFood.Items
        '    chk.Selected = False
        'Next
        For Each chk As ListItem In Me.CLMeal.Items
            chk.Selected = False
        Next
        GetDept()
        GetEmp()
        Me.PnlYes.Visible = False
        Me.PnlNo.Visible = False
        Me.txtmeal.Text = ""
        Me.TctAccname.Text = ""
    End Sub
    Private Sub disable()
        Me.DdlComp.Enabled = False
        Me.TxtName.Enabled = False
        Me.TxtAdd.Enabled = False
        Me.TxtPerson.Enabled = False
        Me.Datefrom.Enabled = False
        Me.Dateto.Enabled = False
        Me.DdlAccomm.Enabled = False
        Me.TxtAccomm.Enabled = False
        Me.txtempcode.Enabled = False
        Me.TxtGuestPhone.Enabled = False
        Me.RadioButtonList1.Enabled = False
        Me.txtmeal.Enabled = False
        Me.DdlDept.Enabled = False
        Me.TctAccname.Enabled = False
        For Each chk As ListItem In Me.RLStay.Items
            chk.Enabled = False
        Next
        For Each chk As ListItem In Me.RLStay.Items
            chk.Enabled = False
        Next
        For Each chk As ListItem In Me.RLCharge.Items
            chk.Enabled = False
        Next
        For Each chk As ListItem In Me.RLDrink1.Items
            chk.Enabled = False
        Next
        For Each chk As ListItem In Me.RLDrink1.Items
            chk.Enabled = False
        Next
        For Each chk As ListItem In Me.RLFood.Items
            chk.Enabled = False
        Next
        For Each chk As ListItem In Me.CLMeal.Items
            chk.Enabled = False
        Next
        GetDept()
        GetEmp()
        Me.PnlYes.Visible = False
        Me.PnlNo.Visible = False
    End Sub
    Protected Sub RadioButtonList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonList1.SelectedIndexChanged
        If Me.RadioButtonList1.Items(0).Selected = True Then
            Me.Label24.Visible = False
            Me.txtempcode.Visible = False

        Else
            Me.txtempcode.Visible = True
            Me.Label24.Visible = True

        End If
    End Sub
    Protected Sub DdlAccomm_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DdlAccomm.SelectedIndexChanged
        GetGuestHouse_aDDRESS()
    End Sub
    Protected Sub LnkCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LnkCancel.Click
        '-------------------------Authorize Request----------------------
        obj.opencn()
        sql = "update JCT_EMP_GUESTHOUSE set authFlag='C',AuthBy='" & Session("Empcode") & "',AuthDate=getdate(),AuthRemarks='" & Me.TxtauthRemarks.Text & "',flaghc='' where transactionno=" & Request.QueryString.Get("Guest") & " and AuthFlag<>'A' and status is null"
        cmd = New SqlCommand(sql, obj.cn)
        cmd.ExecuteNonQuery()
        Me.ClientScript.RegisterClientScriptBlock(Me.GetType, "msg", "<script language = javascript>alert('Request Authorized')</script>")
        sqlpass = "select empCode from JCT_EMP_GUESTHOUSE where transactionno=" & Request.QueryString.Get("Guest") & " and AuthFlag='C'"
        cmd = New SqlCommand(sqlpass, obj.cn)
        Dim empcode As String = cmd.ExecuteScalar
        sqlpass = "select e_mailid from mistel where empcode='" & empcode & "'"
        cmd = New SqlCommand(sqlpass, obj.cn)
        Dim empemail As String = cmd.ExecuteScalar
        '------------------------------------------
        sqlpass = "select e_mailid from mistel where empcode='" & Session("Empcode") & "'"
        cmd = New SqlCommand(sqlpass, obj.cn)
        Dim empcodefrom As String = cmd.ExecuteScalar
        obj.closecn()
        sendmail(empcodefrom, empemail, "Cancel")
        Response.Redirect("MyWorkArae.aspx")
        '---------------------------------------------------------------
    End Sub
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Response.Redirect("Default.aspx")
    End Sub
End Class

   

