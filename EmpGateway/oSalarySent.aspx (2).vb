Imports System.Data.SqlClient
Partial Class SalarySent
    Inherits System.Web.UI.Page
    Public cmd As New SqlCommand
    Public obj As New HelpDeskClass
    Public qry As String
    Public dr As SqlDataReader
    Dim i As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            obj.opencn()
            qry = "select distinct max(monthyear),left(max(monthyear),4),right(max(monthyear),2) from empmast "
            cmd = New SqlCommand(qry, obj.cn)
            dr = cmd.ExecuteReader
   
            If dr.HasRows = True Then

                While dr.Read()

                    Me.DrpMonth.Items(dr.Item(2) - 1).Enabled = True
                    Me.DrpMonth.SelectedIndex = dr.Item(2) - 1
                    Session("yr") = dr.Item(1)
                    Me.LblYear.Text = dr.Item(1)

                End While

            End If

            dr.Close()

            obj.closecn()

            DrpMonth_SelectedIndexChanged(DrpMonth, Nothing)

        End If
    End Sub
    Protected Sub cmdapply_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdapply.Click
        If Me.ChkClerks.Checked = True Then
            obj.opencn()
            qry = "insert into jct_emp_Salary_Update select 'JCT00LTD','" & Session("Empcode") & "','" & Trim(Me.LblYear.Text) & Right("0" & Me.DrpMonth.SelectedIndex + 1, 2) & "',a.catg,'" & Trim(Me.DtClerk.SelectedDate) & "', a.empcode,null,null,'Sal' from jct_empmast_base a, JCT_Emp_Catg_Desg_Mapping b where a.catg=b.catg and a.active='y' and b.status='' and designation='Clerks'"
            cmd = New SqlCommand(qry, obj.cn)
            cmd.ExecuteNonQuery()
            obj.closecn()
            SendSalarySMS("Clerks")
            Me.ChkClerks.Enabled = False
            Response.Write("<script>alert('Record(s) Updated Successfully!!')</script>")
        End If
        If Me.chkAGM.Checked = True Then
            obj.opencn()
            qry = "insert into jct_emp_Salary_Update select 'JCT00LTD','" & Session("Empcode") & "','" & Trim(Me.LblYear.Text) & Right("0" & Me.DrpMonth.SelectedIndex + 1, 2) & "',a.catg,'" & Trim(Me.DtClerk.SelectedDate) & "', a.empcode,null,null,'Sal' from jct_empmast_base a, JCT_Emp_Catg_Desg_Mapping b where a.catg=b.catg and a.active='y' and b.status='' and designation='Asst. General Manager'"
            cmd = New SqlCommand(qry, obj.cn)
            cmd.ExecuteNonQuery()
            obj.closecn()
            SendSalarySMS("Asst. General Manager")
            Me.chkAGM.Enabled = False
            'Response.Write("<script>alert('Record(s) Updated Successfully!!')</script>")
        End If
        If Me.chkAMgr.Checked = True Then
            obj.opencn()
            qry = "insert into jct_emp_Salary_Update select 'JCT00LTD','" & Session("Empcode") & "','" & Trim(Me.LblYear.Text) & Right("0" & Me.DrpMonth.SelectedIndex + 1, 2) & "',a.catg,'" & Trim(Me.DtClerk.SelectedDate) & "', a.empcode,null,null,'Sal' from jct_empmast_base a, JCT_Emp_Catg_Desg_Mapping b where a.catg=b.catg and a.active='y' and b.status='' and designation='Asst. Manager'"
            cmd = New SqlCommand(qry, obj.cn)
            cmd.ExecuteNonQuery()
            obj.closecn()
            SendSalarySMS("Asst. Manager")
            Me.chkAMgr.Enabled = False
            Response.Write("<script>alert('Record(s) Updated Successfully!!')</script>")
        End If
        If Me.chkAssOff.Checked = True Then
            obj.opencn()
            qry = "insert into jct_emp_Salary_Update select 'JCT00LTD','" & Session("Empcode") & "','" & Trim(Me.LblYear.Text) & Right("0" & Me.DrpMonth.SelectedIndex + 1, 2) & "',a.catg,'" & Trim(Me.DtClerk.SelectedDate) & "', a.empcode,null,null,'Sal' from jct_empmast_base a, JCT_Emp_Catg_Desg_Mapping b where a.catg=b.catg and a.active='y' and b.status='' and designation='Asst. Officer'"
            cmd = New SqlCommand(qry, obj.cn)
            cmd.ExecuteNonQuery()
            obj.closecn()
            SendSalarySMS("Asst. Officer")
            Me.chkAssOff.Enabled = False
            Response.Write("<script>alert('Record(s) Updated Successfully!!')</script>")
        End If
        If Me.chkDGM.Checked = True Then
            obj.opencn()
            qry = "insert into jct_emp_Salary_Update select 'JCT00LTD','" & Session("Empcode") & "','" & Trim(Me.LblYear.Text) & Right("0" & Me.DrpMonth.SelectedIndex + 1, 2) & "',a.catg,'" & Trim(Me.DtClerk.SelectedDate) & "', a.empcode,null,null,'Sal' from jct_empmast_base a, JCT_Emp_Catg_Desg_Mapping b where a.catg=b.catg and a.active='y' and b.status='' and designation='Deputy General Manager'"
            cmd = New SqlCommand(qry, obj.cn)
            cmd.ExecuteNonQuery()
            obj.closecn()
            SendSalarySMS("Deputy General Manager")
            Me.chkDGM.Enabled = False
            Response.Write("<script>alert('Record(s) Updated Successfully!!')</script>")
        End If
        If Me.chkDptMgr.Checked = True Then
            obj.opencn()
            qry = "insert into jct_emp_Salary_Update select 'JCT00LTD','" & Session("Empcode") & "','" & Trim(Me.LblYear.Text) & Right("0" & Me.DrpMonth.SelectedIndex + 1, 2) & "',a.catg,'" & Trim(Me.DtClerk.SelectedDate) & "', a.empcode,null,null,'Sal' from jct_empmast_base a, JCT_Emp_Catg_Desg_Mapping b where a.catg=b.catg and a.active='y' and b.status='' and designation='Deputy Manager'"
            cmd = New SqlCommand(qry, obj.cn)
            cmd.ExecuteNonQuery()
            obj.closecn()
            SendSalarySMS("Deputy Manager")
            Me.chkDptMgr.Enabled = False
            Response.Write("<script>alert('Record(s) Updated Successfully!!')</script>")
        End If
        If Me.chkHOD.Checked = True Then
            obj.opencn()
            qry = "insert into jct_emp_Salary_Update select 'JCT00LTD','" & Session("Empcode") & "','" & Trim(Me.LblYear.Text) & Right("0" & Me.DrpMonth.SelectedIndex + 1, 2) & "',a.catg,'" & Trim(Me.DtClerk.SelectedDate) & "', a.empcode,null,null,'Sal' from jct_empmast_base a, JCT_Emp_Catg_Desg_Mapping b where a.catg=b.catg and a.active='y' and b.status='' and designation='HOD'"
            cmd = New SqlCommand(qry, obj.cn)
            cmd.ExecuteNonQuery()
            obj.closecn()
            SendSalarySMS("HOD")
            Me.chkHOD.Enabled = False
            Response.Write("<script>alert('Record(s) Updated Successfully!!')</script>")
        End If
        If Me.chkMgr.Checked = True Then
            obj.opencn()
            qry = "insert into jct_emp_Salary_Update select 'JCT00LTD','" & Session("Empcode") & "','" & Trim(Me.LblYear.Text) & Right("0" & Me.DrpMonth.SelectedIndex + 1, 2) & "',a.catg,'" & Trim(Me.DtClerk.SelectedDate) & "', a.empcode,null,null,'Sal' from jct_empmast_base a, JCT_Emp_Catg_Desg_Mapping b where a.catg=b.catg and a.active='y' and b.status='' and designation='Manager'"
            cmd = New SqlCommand(qry, obj.cn)
            cmd.ExecuteNonQuery()
            obj.closecn()
            SendSalarySMS("Manager")
            Me.chkMgr.Enabled = False
            Response.Write("<script>alert('Record(s) Updated Successfully!!')</script>")
        End If
        If Me.chkOfficer.Checked = True Then
            obj.opencn()
            qry = "insert into jct_emp_Salary_Update select 'JCT00LTD','" & Session("Empcode") & "','" & Trim(Me.LblYear.Text) & Right("0" & Me.DrpMonth.SelectedIndex + 1, 2) & "',a.catg,'" & Trim(Me.DtClerk.SelectedDate) & "', a.empcode,null,null,'Sal' from jct_empmast_base a, JCT_Emp_Catg_Desg_Mapping b where a.catg=b.catg and a.active='y' and b.status='' and designation='Officer'"
            cmd = New SqlCommand(qry, obj.cn)
            cmd.ExecuteNonQuery()
            obj.closecn()
            SendSalarySMS("Officer")
            Me.chkOfficer.Enabled = False
            Response.Write("<script>alert('Record(s) Updated Successfully!!')</script>")
        End If
    End Sub

    Protected Sub DrpMonth_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DrpMonth.SelectedIndexChanged
        obj.opencn()
        qry = "select distinct designation from jct_emp_Salary_Update a, JCT_Emp_Catg_Desg_Mapping b where a.catg=b.catg and b.status='' and monthyear='" & Trim(Me.LblYear.Text) & Right("0" & Me.DrpMonth.SelectedValue, 2) & "' and type='sal'"
        cmd = New SqlCommand(qry, obj.cn)
        dr = cmd.ExecuteReader
        If dr.HasRows = True Then
            While dr.Read()
                If dr.Item(0) = "Clerks" Then
                    Me.ChkClerks.Enabled = False
                End If
                If dr.Item(0) = "Officer" Then
                    Me.chkOfficer.Enabled = False
                End If
                If dr.Item(0) = "Asst. Officer" Then
                    Me.chkAssOff.Enabled = False
                End If
                If dr.Item(0) = "Manager" Then
                    Me.chkMgr.Enabled = False
                End If
                If dr.Item(0) = "Deputy Manager" Then
                    Me.chkDptMgr.Enabled = False
                End If
                If dr.Item(0) = "Asst. Manager" Then
                    Me.chkAMgr.Enabled = False
                End If
                If dr.Item(0) = "HOD" Then
                    Me.chkHOD.Enabled = False
                End If
                If dr.Item(0) = "Asst. General Manager" Then
                    Me.chkAGM.Enabled = False
                End If
                If dr.Item(0) = "Deputy General Manager" Then
                    Me.chkDGM.Enabled = False
                End If
            End While
        Else

            Me.ChkClerks.Enabled = True
            Me.chkOfficer.Enabled = True
            Me.chkAssOff.Enabled = True
            Me.chkMgr.Enabled = True
            Me.chkDptMgr.Enabled = True
            Me.chkAMgr.Enabled = True
            Me.chkHOD.Enabled = True
            Me.chkAGM.Enabled = True
            Me.chkDGM.Enabled = True

        End If
        dr.Close()
        obj.closecn()

    End Sub

    Protected Sub cmdclear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdclear.Click

        Me.chkAGM.Checked = False
        Me.chkAMgr.Checked = False
        Me.chkAssOff.Checked = False
        Me.ChkClerks.Checked = False
        Me.chkDGM.Checked = False
        Me.chkDptMgr.Checked = False
        Me.chkHOD.Checked = False
        Me.chkMgr.Checked = False
        Me.chkOfficer.Checked = False

    End Sub

    'Protected Sub SendSalarySMS(ByVal desg As String)

    '    Dim sm As New SendMail
    '    Dim ofn As New Functions
    '    Dim sql As String
    '    Dim receiver As String = ""

    '    Dim msg As String = "Your Salary for the Month of " & DrpMonth.SelectedItem.Text & ", " & LblYear.Text & " has been transferred to your bank account."

    '    sql = "select a.empcode, a.cardno, a.empname, a.desg, b.catg, c.mobile from jct_empmast_base a INNER JOIN JCT_Emp_Catg_Desg_Mapping b ON a.catg = b.catg " & _
    '            "INNER JOIN mistel c ON a.empcode = c.empcode and a.company_code = c.company_code " & _
    '            "where b.designation = '" & desg & "' and a.active = 'Y' and a.company_code = '" & Session("CompanyCode") & "' " & _
    '            "and c.mobile is not null and Len(c.mobile) = 10"
    '    Try
    '        Dim dr As SqlDataReader = ofn.FetchReader(sql)

    '        If dr.HasRows Then
    '            While dr.Read
    '                sm.SendSMS(Session("CompanyCode"), Session("EmpCode"), dr("mobile"), msg)
    '            End While

    '        End If
    '    Catch ex As Exception

    '    End Try
    'End Sub

    Protected Sub SendSalarySMS(ByVal desg As String)

        Dim sm As New SendMail
        Dim ofn As New Functions
        Dim sql As String
        Dim receiver As String = ""

        Dim msg As String = "Your Salary for the Month of '" & Me.DrpMonth.SelectedItem.Text & "', " & Me.LblYear.Text & " has been transferred to your bank account."

        sql = "select a.empcode, a.cardno, a.empname, a.desg, b.catg, c.mobile from jct_empmast_base a INNER JOIN JCT_Emp_Catg_Desg_Mapping b ON a.catg = b.catg " & _
                "INNER JOIN mistel c ON a.empcode = c.empcode and a.company_code = c.company_code " & _
                "where b.designation = '" & desg & "' and a.active = 'Y' and a.company_code = '" & Session("CompanyCode") & "' " & _
                "and c.mobile is not null and Len(c.mobile) = 10"

        Try

            Dim dr As SqlDataReader = ofn.FetchReader(sql)

            If dr.HasRows Then
                While dr.Read
                    receiver += dr("mobile") + ","
                End While

                receiver = receiver.Remove(receiver.LastIndexOf(","c), 1)
            End If
            sm.SendSMS(Session("CompanyCode"), Session("EmpCode"), receiver, msg, "Salary Sent")

        Catch ex As Exception

        End Try

    End Sub


End Class
