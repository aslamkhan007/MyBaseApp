Imports System.Data
Imports System.Data.SqlClient
Partial Class EmployeeDetail
    Inherits System.Web.UI.Page
    Dim obj As New Connection
    Dim str, str1, str2 As String
    Shared bankno, bankcode, hno, hdesc, saltype As Boolean
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Session("empcode").ToString <> "") Then
        Else
            Response.Redirect("login.aspx")
        End If
        If Not Page.IsPostBack Then
            lblleave.Visible = False
            dateDOL.Visible = False
            Dim dr As SqlDataReader
            str = "select distinct  deptcode from DEPTMAST"
            obj.ConOpen()
            Dim cmd As SqlCommand = New SqlCommand(str, obj.Connection)
            dr = cmd.ExecuteReader
            While dr.Read()
                ddldeptcode.Items.Add(dr("deptcode"))
            End While
            dr.Close()
            obj.ConClose()
        End If
    End Sub

    Protected Sub btnIns_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnIns.Click
        Dim st1, st2, st3, st4 As String
        obj.ConOpen()
        Dim Ecode As String = txtempcode.Text
        st1 = "select empcode from JCT_EmpMast_Base where empcode='" & Ecode & "' and Active='Y'"
        st2 = "select empcode from jct_login_emp where empcode='" & Ecode & "'"
        st3 = "select uname from production..role_user_mapping where uname='" & Ecode & "'"
        st4 = "select company_code from JCT_EmpMast_Base where cardno='" & txtcard.Text & "' and Active='Y'"
        Dim Ecode2, Ecode3, Ecode4, compcode As String
        Dim cmd2 As New SqlCommand(st1, obj.Connection)
        Dim cmd3 As New SqlCommand(st2, obj.Connection)
        Dim cmd4 As New SqlCommand(st3, obj.Connection)
        Dim cmd5 As New SqlCommand(st4, obj.Connection)
        Ecode2 = cmd2.ExecuteScalar
        Ecode3 = cmd3.ExecuteScalar
        Ecode4 = cmd4.ExecuteScalar
        compcode = cmd5.ExecuteScalar

        If Page.IsValid Then

            Try
                If compcode Is Nothing Then

                    '-----------------------------------------------------------------------------------------------------------
                    If Ecode2 Is Nothing Then
                        Dim sal As String = RLsalary.SelectedValue
                        Dim saltype As String
                        If sal = "O" Then
                            saltype = txtsal.Text
                        Else
                            saltype = RLsalary.SelectedValue
                        End If
                        str = "insert into JCT_EmpMast_Base(Active,Assosc_Flag,empcode,cardno,Mr_Mrs,empname,fathername,address1,address2,Gender,deptcode,deptno,senior_citizen,desg_code,desg,catg,member_id,policy_id,salarytype,bankcode,bankno,PFNo,FPFNo,ESINo,DOB,DOJ,housetype,housedesc,contact_no,house_no,company_code) values('" & RLact.SelectedItem.Text & "','E','" & txtempcode.Text & "','" & txtcard.Text & "','" & RLSal.SelectedValue & "','" & txtempname.Text & "','" & txtfather.Text & "','" & txtadd1.Text & "','" & txtadd2.Text & "','" & RLgen.SelectedItem.Text & "','" & ddldeptcode.SelectedItem.Text & "','" & ddldeptcode.SelectedItem.Text & "','" & RLcit.SelectedItem.Text & "','" & txtdescode.Text & "','" & txtdes.Text & "','" & ddlcat.SelectedItem.Text & "'," & txtmembID.Text & "," & txtPolID.Text & ",'" & saltype & "','" & txtbankcode.Text & "','" & txtbankno.Text & "','" & txtPFno.Text & "','" & txtFPFno.Text & "','" & txtESIno.Text & "', '" & dateDOB.SelectedDate & "','" & dateDOJ.SelectedDate & "','" & txtHtype.Text & "','" & txtHdesc.Text & "','" & txtcontno.Text & "','" & txtHno.Text & "','" & Session("Location") & "')"
                        Dim cmd As SqlCommand = New SqlCommand(str, obj.Connection)
                        cmd.ExecuteNonQuery()
                        cmd.Dispose()
                    End If
                    '----------------------------------------------------------------------------------------------------------------------------


                    '--------------------------------------------------------------------------------------------------------------------------
                    If Ecode3 Is Nothing Then
                        str1 = "insert into jct_login_emp(empcode,empname,active,dateofbirth,company_code) values('" & Ecode & "','" & txtempname.Text & "','Y','" & Format(dateDOB.SelectedDate, "MM/dd/yyyy") & "','" & Session("Location") & "')"
                        Dim cmd As SqlCommand = New SqlCommand(str1, obj.Connection)
                        cmd.ExecuteNonQuery()
                        cmd.Dispose()
                    End If
                    '--------------------------------------------------------------------------------------------------------------------------


                    '--------------------------------------------------------------------------------------------------------------------------
                    If Ecode4 Is Nothing Then
                        If Session("Location") = "JCT00LTD" Then
                            str2 = "insert into production..role_user_mapping values('102','" & Ecode & "')"
                            Dim cmd As SqlCommand = New SqlCommand(str2, obj.Connection)
                            cmd.ExecuteNonQuery()
                            cmd.Dispose()
                        ElseIf Session("Location") = "JCT01LTD" Then
                            str2 = "insert into production..role_user_mapping values('202','" & Ecode & "')"
                            Dim cmd As SqlCommand = New SqlCommand(str2, obj.Connection)
                            cmd.ExecuteNonQuery()
                            cmd.Dispose()
                        End If
                        clear()
                    End If
                    '--------------------------------------------------------------------------------------------------------------------------
                    Response.Write("<script>alert('Employee Details Added!!')</script>")
                End If

            Catch ex As Exception
                Response.Write("<script>alert('Imroper Data!!')</script>")
            Finally
                obj.ConClose()
               
            End Try
        End If


    End Sub

    Protected Sub btnClear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClear.Click
        clear()
    End Sub

    Protected Sub btnfetch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnfetch.Click
        Dim card As String = txtcard.Text
        Dim dr As SqlDataReader
        obj.ConOpen()
        str = "select Active,Assosc_Flag,empcode,cardno,isnull(Mr_Mrs,'mr') as Mr_Mrs,isNull(empname,'') as empname,isNull(fathername,'') as fathername,isNull(address1,'') as address1,isNull(address2,'') as address2,isNull(Gender,'M') as Gender,deptcode,deptno,isNull(senior_citizen,'N') as senior_citizen,isNull(desg_code,'') as desg_code,isNull(desg,'') as desg,isNull(catg,'') as catg,isNull(member_id,'') as member_id,isNull(policy_id,'') as policy_id,isnull(case when salarytype not in ('B','C') then 'O' else salarytype end,'O') as salarytype,isnull(case when salarytype not in ('B','C') then salarytype else '' end,'') as salary,isNull(bankcode,'') as bankcode,isNull(bankno,'') as bankno,isNull(PFNo,'') as PFNo,isNull(FPFNo,'') as FPFNo,isNull(ESINo,'') as ESINo,isnull(convert(varchar(10),DOB,101),'') as DOB,isnull(convert(varchar(10),DOJ,101),'') as DOJ,isnull(case when convert(varchar(10),DOL,101)='01/01/1900' then '' else convert(varchar(10),DOL,101) end,'') as DOL,isNull(housetype,'') as housetype,isNull(housedesc,'') as housedesc,isNull(contact_no,'') as contact_no,isNull(house_no,'') as house_no,company_code from JCT_EmpMast_Base where cardno='" & card & "' and Active='Y'"
        Dim cmd As SqlCommand = New SqlCommand(str, obj.Connection)
        dr = cmd.ExecuteReader

        If dr.HasRows Then
            dr.Read()
            'Active,Assosc_Flag,empcode,cardno,Mr_Mrs,empname,fathername,address1,address2,Gender,deptcode,deptno,senior_citizen,desg_code,desg,catg,
            'member_id,policy_id,salarytype,bankcode,bankno,PFNo,FPFNo,ESINo,DOB,DOJ,DOL,housetype,housedesc,contact_no,house_no,company_code)
            'If dr("Active") = "N" Then
            '    lblleave.Visible = True
            '    dateDOL.Visible = True
            '    dateDOL.SelectedDate = dr("DOL")
            'Else
            '    lblleave.Visible = False
            '    dateDOL.Visible = False
            'End If

            If LCase(dr("Mr_Mrs").ToString) = "mr" Or LCase(dr("Mr_Mrs").ToString) = "mr." Then
                RLSal.SelectedValue = "mr"
            ElseIf LCase(dr("Mr_Mrs").ToString) = "mrs" Or LCase(dr("Mr_Mrs").ToString) = "mrs." Then
                RLSal.SelectedValue = "mrs"
            ElseIf LCase(dr("Mr_Mrs").ToString) = "miss" Or LCase(dr("Mr_Mrs").ToString) = "miss." Then
                RLSal.SelectedValue = "miss"
            Else
                RLSal.SelectedValue = "mr"
            End If
            txtfather.Text = dr("fathername")
            RLact.SelectedValue = dr("Active")
            RLgen.SelectedValue = dr("Gender")
            RLcit.SelectedValue = dr("senior_citizen")
            RLsalary.SelectedValue = dr("salarytype")
            txtsal.Text = dr("salary")
            ddldeptcode.SelectedValue = dr("deptcode")
            ddlcat.SelectedValue = dr("catg")
            txtempcode.Text = dr("empcode")
            txtcard.Text = dr("cardno")
            txtempname.Text = dr("empname")
            txtadd1.Text = dr("address1")
            txtadd2.Text = dr("address2")
            txtdescode.Text = dr("desg_code")
            txtdes.Text = dr("desg")
            txtmembID.Text = dr("member_id")
            txtPolID.Text = dr("policy_id")
            txtbankcode.Text = dr("bankcode")
            txtbankno.Text = dr("bankno")
            txtPFno.Text = dr("PFNo")
            txtFPFno.Text = dr("FPFNo")
            txtESIno.Text = dr("ESINo")
            dateDOB.SelectedDate = dr("DOB")
            dateDOJ.SelectedDate = dr("DOJ")
            'dateDOL.SelectedDate = Convert.ToDateTime(dr("DOL"))
            txtHtype.Text = dr("housetype")
            txtHdesc.Text = dr("housedesc")
            txtcontno.Text = dr("contact_no")
            txtHno.Text = dr("house_no")
            dr.Close()
        Else
            clear()
        End If
        obj.ConClose()
    End Sub
    Private Sub clear()
        lblleave.Visible = False
        dateDOL.Visible = False
        RLact.SelectedValue = "Y"
        RLgen.SelectedValue = "Mr."
        RLgen.SelectedValue = "M"
        RLcit.SelectedValue = "N"
        RLsalary.SelectedValue = "B"
        ddldeptcode.SelectedValue = "ABH1"
        ddlcat.SelectedValue = "001"
        txtsal.Text = ""
        txtempcode.Text = ""
        txtcard.Text = ""
        txtempname.Text = ""
        txtfather.Text = ""
        txtadd1.Text = ""
        txtadd2.Text = ""
        txtdescode.Text = ""
        txtdes.Text = ""
        txtmembID.Text = "0"
        txtPolID.Text = "0"
        txtbankcode.Text = ""
        txtbankno.Text = ""
        txtPFno.Text = ""
        txtFPFno.Text = ""
        txtESIno.Text = ""
        dateDOB.SelectedDate = Date.Today
        dateDOJ.SelectedDate = Date.Today
        dateDOL.SelectedDate = Date.Today
        txtHtype.Text = ""
        txtHdesc.Text = ""
        txtcontno.Text = ""
        txtHno.Text = ""
    End Sub

    Protected Sub CVbankcode_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles CVbankcode.ServerValidate
        If RLsalary.SelectedValue = "B" And txtbankcode.Text = "" Then
            args.IsValid = False
            bankcode = False
        Else
            args.IsValid = True
            bankcode = True
        End If
    End Sub

    Protected Sub CVbankno_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles CVbankno.ServerValidate
        If RLsalary.SelectedValue = "B" And txtbankno.Text = "" Then
            args.IsValid = False
            bankno = False
        Else
            args.IsValid = True
            bankno = True
        End If
    End Sub

    Protected Sub CVhno_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles CVhno.ServerValidate
        If txtHtype.Text <> "HR" And txtHno.Text = "" Then
            args.IsValid = False
            hno = False
        ElseIf txtHtype.Text = "HR" Then
            args.IsValid = True
            hno = True
        End If
    End Sub

    Protected Sub CVhdesc_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles CVhdesc.ServerValidate
        If txtHtype.Text <> "HR" And txtHdesc.Text = "" Then
            args.IsValid = False
            hdesc = False
        ElseIf txtHtype.Text = "HR" Then
            args.IsValid = True
            hdesc = True
        End If
    End Sub
    Public Function IsFromDt(ByVal a As String)
        If Trim(a) = "" Then
            Return "01/01/1900"
        Else
            Return a
        End If
    End Function

    Protected Sub btnUpd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpd.Click
        'Active,Assosc_Flag,empcode,cardno,Mr_Mrs,empname,fathername,address1,address2,Gender,deptcode,deptno,senior_citizen,desg_code,desg,catg,
        'member_id,policy_id,salarytype,bankcode,bankno,PFNo,FPFNo,ESINo,DOB,DOJ,DOL,housetype,housedesc,contact_no,house_no,company_code)
        Dim sal As String = RLsalary.SelectedValue
        Dim saltype, compcode, st As String

        obj.ConOpen()
        st = "select company_code from JCT_EmpMast_Base where cardno='" & txtcard.Text & "' and Active='Y'"
        Dim cmd3 As New SqlCommand(st, obj.Connection)
        compcode = cmd3.ExecuteScalar


        '-----------------------------------------
        If sal = "O" Then
            saltype = txtsal.Text
        Else
            saltype = RLsalary.SelectedValue
        End If
        '------------------------------------------

        If Page.IsValid Then
            Try
                '------------------------------------------
                If compcode = Session("Location") Then
                    If RLact.SelectedValue = "Y" Then
                        str = "update JCT_EmpMast_Base set Active='" & RLact.SelectedValue & "',Mr_Mrs='" & RLSal.SelectedValue & "',empname='" & txtempname.Text & "',fathername='" & txtfather.Text & "',address1='" & txtadd1.Text & "',address2='" & txtadd2.Text & "',gender='" & RLgen.SelectedItem.Text & "',deptcode='" & ddldeptcode.SelectedItem.Text & "',deptno='" & ddldeptcode.SelectedItem.Text & "',senior_citizen='" & RLcit.SelectedItem.Text & "',desg_code='" & txtdescode.Text & "',desg='" & txtdes.Text & "',catg='" & ddlcat.SelectedItem.Text & "',member_id=" & txtmembID.Text & ",policy_id=" & txtPolID.Text & ",salarytype='" & saltype & "',bankcode='" & txtbankcode.Text & "',bankno='" & txtbankno.Text & "',PFno='" & txtPFno.Text & "',FPFNo='" & txtFPFno.Text & "',ESINo='" & txtESIno.Text & "',DOB= '" & dateDOB.SelectedDate & "',DOJ='" & dateDOJ.SelectedDate & "',housetype='" & txtHtype.Text & "',housedesc='" & txtHdesc.Text & "',contact_no='" & txtcontno.Text & "',house_no='" & txtHno.Text & "' where cardno='" & txtcard.Text & "'"
                        Dim cmd As SqlCommand = New SqlCommand(str, obj.Connection)
                        cmd.ExecuteNonQuery()
                        cmd.Dispose()
                    Else
                        str = "update JCT_EmpMast_Base set Active='" & RLact.SelectedValue & "',Mr_Mrs='" & RLSal.SelectedValue & "',empname='" & txtempname.Text & "',fathername='" & txtfather.Text & "',address1='" & txtadd1.Text & "',address2='" & txtadd2.Text & "',gender='" & RLgen.SelectedItem.Text & "',deptcode='" & ddldeptcode.SelectedItem.Text & "',deptno='" & ddldeptcode.SelectedItem.Text & "',senior_citizen='" & RLcit.SelectedItem.Text & "',desg_code='" & txtdescode.Text & "',desg='" & txtdes.Text & "',catg='" & ddlcat.SelectedItem.Text & "',member_id=" & txtmembID.Text & ",policy_id=" & txtPolID.Text & ",salarytype='" & saltype & "',bankcode='" & txtbankcode.Text & "',bankno='" & txtbankno.Text & "',PFno='" & txtPFno.Text & "',FPFNo='" & txtFPFno.Text & "',ESINo='" & txtESIno.Text & "',DOB= '" & dateDOB.SelectedDate & "',DOJ='" & dateDOJ.SelectedDate & "',DOL='" & dateDOL.SelectedDate & "',housetype='" & txtHtype.Text & "',housedesc='" & txtHdesc.Text & "',contact_no='" & txtcontno.Text & "',house_no='" & txtHno.Text & "' where cardno='" & txtcard.Text & "'"
                        Dim cmd As SqlCommand = New SqlCommand(str, obj.Connection)
                        cmd.ExecuteNonQuery()
                        cmd.Dispose()

                        str1 = "update jct_emp_hod set auth_req='N' where resp_emp='" & txtempcode.Text & "'"
                        Dim cmd1 As SqlCommand = New SqlCommand(str1, obj.Connection)
                        cmd1.ExecuteNonQuery()
                        cmd1.Dispose()

                        str2 = "update jct_emp_hod set status='D' where emp_code='" & txtempcode.Text & "'"
                        Dim cmd2 As SqlCommand = New SqlCommand(str2, obj.Connection)
                        cmd2.ExecuteNonQuery()
                        cmd2.Dispose()

                    End If
                    clear()
                    Response.Write("<script>alert('Employee Details Updated!!')</script>")
                End If
                '------------------------------------------
            Catch ex As Exception
                Response.Write("<script>alert('Imroper Data!!')</script>")
            End Try
        End If

        obj.ConClose()
    End Sub

    Protected Sub CVsal_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles CVsal.ServerValidate
        If RLsalary.SelectedValue = "O" And txtsal.Text = "" Then
            args.IsValid = False
            saltype = False
        Else
            args.IsValid = True
            saltype = True
        End If
    End Sub

    Protected Sub RLact_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RLact.SelectedIndexChanged
        If RLact.SelectedValue = "N" Then
            lblleave.Visible = True
            dateDOL.Visible = True
        Else
            lblleave.Visible = False
            dateDOL.Visible = False
        End If
    End Sub

    Protected Sub lnkaddimg_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkaddimg.Click
        If txtcard.Text = "" Then
            Response.Write("<script>alert('Please enter Card Number!!')</script>")
        Else
            Response.Redirect("EmployeeImage.aspx?card=" & txtcard.Text)
        End If

    End Sub
End Class
