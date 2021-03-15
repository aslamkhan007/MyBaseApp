Imports System.Data.SqlClient
Imports System.Data
Imports System.IO
Partial Class medicalinsurance
    Inherits System.Web.UI.Page
    Dim Obj As New Connection
    Dim cmd As New SqlCommand
    Dim qry, qry1, qry2, qry3, qry4, qry5, qry6, qry7, qry8, qry9, qry10, qry11, qry12, qry13 As String
    Dim dt As New Data.DataTable
    Dim dr As SqlDataReader

    Dim Salutation, name, dob, age, flag, exist, children As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Session("Empcode") <> "") Then
        Else
            Response.Redirect("~/login.aspx")
        End If
        'Session("empcode") = "demo"

        If IsPostBack = False Then
            Dim cl(7) As String
            Dim k As Integer
            cl(0) = "salutation"
            cl(1) = "name"
            cl(2) = "dob"
            cl(3) = "age"
            cl(4) = "flag"
            cl(5) = "exist"
            For k = 0 To 5
                Dim dc As New Data.DataColumn
                dc.ColumnName = cl(k)
                dt.Columns.Add(dc)
            Next
            ViewState("dt") = dt

            Obj.ConOpen()
            qry = "select empname from jct_empmast_base where empcode ='" & Me.Session("Empcode") & "'"
            cmd = New SqlCommand(qry, Obj.Connection)
            Me.Txtempname.Text = IIf(cmd.ExecuteScalar Is Nothing, "", cmd.ExecuteScalar)

           
            qry1 = "select relativename as [Spouse Name],dob,case when flag ='y' then 'Y' else 'N' end as flag from jct_epor_employee_family_dtl where emp_code ='" & Me.Session("Empcode") & "' and relation = 'spouse'"
            cmd = New SqlCommand(qry1, Obj.Connection)
            'Me.Txtspousename.Text = IIf(cmd.ExecuteScalar Is Nothing, "", cmd.ExecuteScalar)
            'If Me.Txtspousename.Text = "" Then
            '    qry8 = "insert into jct_epor_employee_family_dtl(emp_code,relation,relativename)values('" & Session("empcode") & "','spouse','" & Me.Txtspousename.Text & "')"
            '    cmd = New SqlCommand(qry8, Obj.Connection)
            '    cmd.ExecuteNonQuery()
            'End If
            dr = cmd.ExecuteReader
            If dr.HasRows Then
                While dr.Read
                    Txtspousename.Text = dr(0)
                    txtspdob.SelectedDate = dr(1)
                    ddlspflag.SelectedItem.Text = dr(2)
                End While
            End If
            dr.Close()
            qry10 = "select relativename as [Father Name],dob,case when flag ='y' then 'Y' else 'N' end as flag from jct_epor_employee_family_dtl where emp_code ='" & Me.Session("Empcode") & "' and relation='father'"
            cmd = New SqlCommand(qry10, Obj.Connection)
            dr = cmd.ExecuteReader
            If dr.HasRows = True Then
                While dr.Read
                    Me.Txtfather.Text = dr(0)
                    Me.txtfatherdob.SelectedDate = dr(1)
                    Me.ddlfatherflag.SelectedItem.Text = dr(2)
                End While
            End If
            dr.Close()
            qry11 = "select relativename as [Mother Name],dob,case when flag ='y' then 'Y' else 'N' end as flag from jct_epor_employee_family_dtl where emp_code ='" & Me.Session("Empcode") & "' and relation='mother'"
            cmd = New SqlCommand(qry11, Obj.Connection)
            dr = cmd.ExecuteReader
            If dr.HasRows = True Then
                While dr.Read
                    Me.txtmother.Text = dr(0)
                    Me.txtmotherdob.SelectedDate = dr(1)
                    Me.ddlmotherflag.SelectedItem.Text = dr(2)
                End While
            End If
            dr.Close()
            grdbnd()
        End If
    End Sub
    Sub grdbnd()
        qry2 = " select shortdesc as [salutation],relativename as [Name],convert(varchar(10),dob,101) as [dob] ,convert(varchar(10),age) as [age],case when flag ='y' then 'Y' else 'N' end as flag,'Y' as exist  from jct_epor_employee_family_dtl e left outer join jct_epor_master_saluation m on e.salutation=m.shortdesc where m.status ='a'and e.emp_code= '" & Me.Session("Empcode") & "'and e.relation = 'children' "
        Dim ds As New DataSet
        Dim adp As New SqlDataAdapter(qry2, Obj.Connection)
        adp.Fill(ds)
        Me.Grdchild.DataSource = ds
        Me.Grdchild.DataBind()
        ViewState("dt") = ds.Tables(0)

    End Sub

    Protected Sub Grdchild_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles Grdchild.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim ddl As New DropDownList
            ddl = CType(e.Row.FindControl("ddlsal"), DropDownList)
            Obj.ConOpen()
            qry8 = "select salt_code, shortdesc  from jct_epor_master_saluation where status='a'"
            cmd = New SqlCommand(qry8, Obj.Connection)
            dr = cmd.ExecuteReader
            If dr.HasRows = True Then
                While dr.Read()
                    Dim lst As New ListItem
                    lst.Text = dr(1)
                    lst.Value = dr(0)
                    ddl.Items.Add(lst)
                End While
            End If
            dr.Close()


        End If

    End Sub
    

    Protected Sub btnadd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnadd.Click
        dt = ViewState("dt")
        dt.Rows.Clear()
        Dim rw As Data.DataRow
        For i As Integer = 0 To Me.Grdchild.Rows.Count - 1
            rw = dt.NewRow
            rw("Salutation") = CType(Grdchild.Rows(i).FindControl("ddlsal"), DropDownList).SelectedItem.Text
            rw("Name") = CType(Grdchild.Rows(i).FindControl("textname"), TextBox).Text
            rw("DOB") = CType(Grdchild.Rows(i).FindControl("textdob"), TextBox).Text
            rw("Age") = CType(Grdchild.Rows(i).FindControl("textage"), TextBox).Text
            rw("flag") = CType(Grdchild.Rows(i).FindControl("ddlflag"), DropDownList).SelectedItem.Text
            rw("exist") = CType(Grdchild.Rows(i).FindControl("textexist"), TextBox).Text
            dt.Rows.Add(rw)
        Next
        Dim rw1 As Data.DataRow
        rw1 = dt.NewRow
        rw1("Salutation") = "MR"
        rw1("Name") = ""
        rw1("DOB") = ""
        rw1("Age") = ""
        rw1("flag") = "N"
        rw1("exist") = "N"
        dt.Rows.Add(rw1)
        Me.Grdchild.DataSource = dt
        Me.Grdchild.DataBind()
    End Sub
    Protected Sub btnsub_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsub.Click
        Obj.ConOpen()
        qry1 = "select relativename as [Spouse Name],dob,case when flag ='y' then 'Y' else 'N' end as flag from jct_epor_employee_family_dtl where emp_code ='" & Me.Session("Empcode") & "' and relation = 'spouse'"
        cmd = New SqlCommand(qry1, Obj.Connection)
        dr = cmd.ExecuteReader
        Dim sp As Boolean = False
        If dr.HasRows = True Then
            MsgBox("Data Exist")
            'sp = True
        Else
            dr.Close()
            qry8 = "insert into jct_epor_employee_family_dtl values('" & Session("Companycode") & "','" & Session("Empcode") & "','" & Session("Empcode") & "','spouse','" & Me.Txtspousename.Text & "','','" & Me.txtspdob.SelectedDate & "',datediff(yy,'" & Me.txtspdob.SelectedDate & "',getdate()),'','" & Me.ddlspflag.SelectedItem.Text & "','','','','','','')"
            cmd = New SqlCommand(qry8, Obj.Connection)
            cmd.ExecuteNonQuery()
        End If
        dr.Close()
        qry10 = "select relativename as [Father Name],dob,case when flag ='y' then 'Y' else 'N' end as flag from jct_epor_employee_family_dtl where emp_code ='" & Me.Session("Empcode") & "' and relation='father'"
        cmd = New SqlCommand(qry10, Obj.Connection)
        dr = cmd.ExecuteReader
        If dr.HasRows = True Then

            MsgBox("Data Exist")
        Else
            dr.Close()
            qry12 = "insert into jct_epor_employee_family_dtl values('" & Session("Companycode") & "','" & Session("Empcode") & "','" & Session("Empcode") & "','father','" & Me.Txtfather.Text & "','','" & Me.txtfatherdob.SelectedDate & "',datediff(yy,'" & Me.txtfatherdob.SelectedDate & "',getdate()),'','" & Me.ddlfatherflag.SelectedItem.Text & "','','','','','','')"
            cmd = New SqlCommand(qry12, Obj.Connection)
            cmd.ExecuteNonQuery()
        End If
        dr.Close()
        qry11 = "select relativename as [Mother Name],dob,case when flag ='y' then 'Y' else 'N' end as flag from jct_epor_employee_family_dtl where emp_code ='" & Me.Session("Empcode") & "' and relation='mother'"
        cmd = New SqlCommand(qry11, Obj.Connection)
        dr = cmd.ExecuteReader
        If dr.HasRows = True Then
            MsgBox("Data Exist")
        Else
            dr.Close()
            qry13 = "insert into jct_epor_employee_family_dtl values('" & Session("Companycode") & "','" & Session("Empcode") & "','" & Session("Empcode") & "','mother','" & Me.txtmother.Text & "','','" & Me.txtmotherdob.SelectedDate & "',datediff(yy,'" & Me.txtmotherdob.SelectedDate & "',getdate()),'','" & Me.ddlmotherflag.SelectedItem.Text & "','','','','','','')"
            cmd = New SqlCommand(qry13, Obj.Connection)
            cmd.ExecuteNonQuery()
        End If
        dr.Close()
        'qry1 = "select relativename as [Spouse Name] from jct_epor_employee_family_dtl where emp_code ='" & Me.Session("empcode") & "' and relation = 'spouse'"
        'cmd = New SqlCommand(qry1, Obj.Connection)
        'dr = cmd.ExecuteReader
        'If dr.HasRows Then
        '    While dr.Read()
        '        Me.Txtspousename.Text = dr(0)
        '    End While

        'Else

        '    qry8 = "insert into jct_epor_employee_family_dtl(emp_code,relation,relativename)values('" & Session("empcode") & "','spouse','" & Me.Txtspousename.Text & "')"
        '    cmd = New SqlCommand(qry8, Obj.Connection)

        '    dr.Close()
        '    cmd.ExecuteNonQuery()

        For i As Integer = 0 To Me.Grdchild.Rows.Count - 1

            Salutation = CType(Me.Grdchild.Rows(i).FindControl("ddlsal"), DropDownList).SelectedItem.Text
            name = CType(Me.Grdchild.Rows(i).FindControl("textname"), TextBox).Text
            dob = CType(Grdchild.Rows(i).FindControl("textdob"), TextBox).Text
            age = CType(Grdchild.Rows(i).FindControl("textage"), TextBox).Text
            flag = CType(Grdchild.Rows(i).FindControl("ddlflag"), DropDownList).SelectedValue
            exist = CType(Grdchild.Rows(i).FindControl("textexist"), TextBox).Text
            Obj.ConOpen()
            'qry3 = "select * from jct_epor_employee_family_dtl"
            'cmd = New SqlCommand(qry3, Obj.Connection)
            'dr = cmd.ExecuteReader
            'If dr.HasRows = True Then
            '    While dr.Read()
            '    End While
            'End If

            qry7 = "select * from jct_emp_upload_medical where transactionno = (select  max(transactionno) from jct_emp_demand_medical)"
            cmd = New SqlCommand(qry7, Obj.Connection)
            dr = cmd.ExecuteReader
            If dr.HasRows = True Then
                While dr.Read()
                    MsgBox("Data Exist")
                    Exit Sub
                End While
            End If
            dr.Close()
            Obj.ConOpen()

            If UCase(exist) = "Y" Then
                qry3 = " update jct_epor_employee_family_dtl set flag='y' where emp_code='" & Me.Session("Empcode") & "'"
                cmd = New SqlCommand(qry3, Obj.Connection)
                cmd.ExecuteNonQuery()
                'ElseIf exist = "n" Then
                '    qry4 = " update jct_epor_employee_family_dtl set flag='n'where emp_code='" & Me.Session("empcode") & "'"
                '    cmd = New SqlCommand(qry4, Obj.Connection)
                '    cmd.ExecuteNonQuery()
            Else

                qry5 = "insert into jct_epor_employee_family_dtl values('" & Session("Companycode") & "','" & Session("Empcode") & "','" & Session("Empcode") & "','children','" & name & "','" & Salutation & "','" & dob & "'  ,'" & age & "','','" & flag & "','','','','','','')"
                cmd = New SqlCommand(qry5, Obj.Connection)
                cmd.ExecuteNonQuery()


                'qry6 = "update jct_emp_upload_medical set submitdate = getdate() where empcode='" & Session("empcode") & "' and transactionno=(select max(transactionno) from  jct_emp_upload_medical where empcode='" & Session("empcode") & "')"
                qry6 = "insert into jct_emp_upload_medical select '" & Session("Empcode") & "',max(transactionno),getdate() from jct_emp_demand_medical "
                cmd = New SqlCommand(qry6, Obj.Connection)
                cmd.ExecuteNonQuery()

            End If


        Next


    End Sub

  
End Class
