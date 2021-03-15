Imports System.Data.SqlClient

Partial Class SalarySent
    Inherits System.Web.UI.Page
    Public cmd As New SqlCommand
    Public obj As New HelpDeskClass
    Public qry As String
    Dim ofn As New Functions
    Public dr As SqlDataReader
    Dim i As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'If Not IsPostBack Then
        '    Response.Redirect("~/Login.aspx")
        'End If
        If IsPostBack = False Then

            obj.opencn()
            qry = "select distinct max(monthyear),left(max(monthyear),4),right(max(monthyear),2) from empmast"

            Dim dt As DateTime = DateTime.Now.Date
            ddlMonthYear.Items.Clear()
            For i As Integer = -2 To 2 ' to pick one month prior to current month and two forthcoming months
                Dim monthyear_value As String = dt.AddMonths(i).ToString("yyyyMM")
                Dim monthyear_text As String = dt.AddMonths(i).ToString("MMM yyyy")
                ddlMonthYear.Items.Add(New ListItem(monthyear_text, monthyear_value))
            Next

            ddlMonthYear.SelectedIndex = ddlMonthYear.Items.IndexOf(ddlMonthYear.Items.FindByValue(ofn.FetchValue(qry)))
            ddlSal.SelectedIndex = ddlMonthYear.Items.IndexOf(ddlMonthYear.Items.FindByText("Salary"))

        End If

    End Sub

    Protected Sub SendSalarySMS(ByVal desg As String)

        Dim sm As New SendMail
        Dim ofn As New Functions
        Dim sql As String
        Dim receiver As String = ""

        Dim msg As String = ""

        If ddlSal.SelectedItem.Text = "Salary" Or ddlSal.SelectedItem.Text = "Scooter Allowance" Or ddlSal.SelectedItem.Text = "Car Allowance" Then
            msg = "Your " & ddlSal.SelectedItem.Text & " for the Month of " & Me.ddlMonthYear.SelectedItem.Text & " has been transferred to your bank account."
            'ElseIf ddlSal.SelectedItem.Text = "Scooter Allowance" Or ddlSal.SelectedItem.Text = "Car Allowance" Then
            '    msg = "Your " & ddlSal.SelectedItem.Text & " for the Month of " & Me.ddlMonthYear.SelectedItem.Text & " has been transferred to your bank account."
        End If

        sql = "select a.empcode, a.cardno, a.empname, a.desg, b.catg, c.mobile from jct_empmast_base a INNER JOIN JCT_Emp_Catg_Desg_Mapping b ON a.catg = b.catg " & _
                "INNER JOIN mistel c ON a.empcode = c.empcode and a.company_code = c.company_code " & _
                "where b.designation in (" & desg & ") and a.active = 'Y' and a.company_code = '" & Session("CompanyCode") & "' " & _
                "and c.mobile is not null and Len(c.mobile) = 10"

        Dim dr As SqlDataReader
        Try

            dr = ofn.FetchReader(sql)

            If dr.HasRows Then
                While dr.Read
                    receiver += dr("mobile") + ","
                End While

                receiver = receiver.Remove(receiver.LastIndexOf(","c), 1)
                sm.SendSMS(Session("CompanyCode"), Session("EmpCode"), receiver, msg, ddlSal.SelectedItem.Text & " Sent")
            End If

            dr.Close()

        Catch ex As Exception

        Finally

        End Try

    End Sub

    Protected Sub cmdapply_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdapply.Click

            Dim designations As String = ""
            Dim msgdesignations As String = ""

            For Each li As ListItem In cblPending.Items
                If li.Selected Then
                    designations += "'" & li.Value + "',"
                End If
            Next

            If designations <> "" Then
                designations = designations.Remove(designations.LastIndexOf(","), 1)
            End If

        qry = "insert into jct_emp_Salary_Update select '" & Session("CompanyCode") & "','" & Session("Empcode") & "','" & ddlMonthYear.SelectedValue & "',a.catg,'" & dtTransfer.SelectedDate & "', a.empcode,null,null,'" & ddlSal.SelectedValue & "' from jct_empmast_base a, JCT_Emp_Catg_Desg_Mapping b " & _
                    "where a.catg=b.catg and a.active = 'y' and b.status='' and a.company_code = '" & Session("CompanyCode") & "' and designation in (" & designations & ")"

            If ofn.InsertRecord(qry) Then
            If ddlSal.SelectedIndex = 0 Then
                cblDone.DataBind()
                cblPending.DataBind()
            Else
                ddlSal_SelectedIndexChanged(sender, e)
            End If

                msgdesignations = Trim(designations.Replace("'"c, " "c))
                If ddlSal.SelectedItem.Text <> "Medical" Then
                SendSalarySMS(designations)
                End If
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "scr", "<script>alert('" & ddlSal.SelectedItem.Text & " for the month of " & ddlMonthYear.SelectedItem.Text & " for " & msgdesignations & " Updated Successfully!!')</script>")

            Else
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "scr", "<script>alert('Error Occurred!!')</script>")
            End If

    End Sub

    Protected Sub ddlSal_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlSal.SelectedIndexChanged
        If ddlSal.SelectedItem.Text = "Salary" Then
            cblDone.DataSourceID = "SqlDataSource1"
            cblDone.DataBind()
            cblPending.DataSourceID = "SqlDataSource2"
            cblPending.DataBind()
        ElseIf ddlSal.SelectedItem.Text = "Scooter Allowance" Then
            Dim sql As String
            SqlDataSource1 = Nothing
            cblDone.DataSource = SqlDataSource1
            cblDone.DataBind()
            SqlDataSource2 = Nothing
            cblPending.DataSource = SqlDataSource2
            cblPending.DataBind()
            cblDone.Items.Clear()
            cblPending.Items.Clear()
            sql = "SELECT DISTINCT b.Designation,b.Designation FROM    jct_emp_Salary_Update a RIGHT OUTER JOIN dbo.JCT_Emp_Catg_Desg_Mapping b ON   	a.Catg=b.Catg AND a.type=b.Allowance_Type AND a.monthyear = " & ddlMonthYear.SelectedItem.Value & " WHERE   b.Allowance_Type = '" & ddlSal.SelectedItem.Value & "' AND a.catg not IN ( SELECT catg FROM jct_emp_Salary_Update c WHERE catg IN ( 'JM1', 'JM2', 'MM3' )   AND monthyear =" & ddlMonthYear.SelectedItem.Value & "  AND c.type=a.type)"
            If ofn.CheckRecordExistInTransaction(sql) = True Then
                ofn.FillList(cblPending, sql)
            End If
            sql = "SELECT DISTINCT b.Designation,b.Designation FROM jct_emp_Salary_Update a , dbo.JCT_Emp_Catg_Desg_Mapping b WHERE   b.Allowance_Type = 'SCR' AND a.Catg=b.Catg AND a.monthyear =  " & ddlMonthYear.SelectedItem.Value & " AND a.type='" & ddlSal.SelectedItem.Value & "'"
            If ofn.CheckRecordExistInTransaction(sql) = True Then
                ofn.FillList(cblDone, sql)
            End If
        ElseIf ddlSal.SelectedItem.Text = "Car Allowance" Then
            SqlDataSource1 = Nothing
            cblDone.DataSource = SqlDataSource1
            cblDone.DataBind()
            SqlDataSource2 = Nothing
            cblPending.DataSource = SqlDataSource2
            cblPending.DataBind()
            Dim sql As String
            cblDone.Items.Clear()
            cblPending.Items.Clear()
            sql = "SELECT DISTINCT b.Designation,b.Designation FROM    jct_emp_Salary_Update a RIGHT OUTER JOIN dbo.JCT_Emp_Catg_Desg_Mapping b ON   	a.Catg=b.Catg AND a.type=b.Allowance_Type AND a.monthyear = " & ddlMonthYear.SelectedItem.Value & " WHERE   b.Allowance_Type = '" & ddlSal.SelectedItem.Value & "' AND a.catg not IN ( SELECT catg FROM jct_emp_Salary_Update c WHERE catg IN ( 'MM1', 'MM2', 'SM3','SM2')  AND monthyear = " & ddlMonthYear.SelectedItem.Value & "  AND c.type=a.type)"
            If ofn.CheckRecordExistInTransaction(sql) = True Then
                ofn.FillList(cblPending, sql)
            End If
            sql = "SELECT DISTINCT b.Designation,b.Designation FROM jct_emp_Salary_Update a , dbo.JCT_Emp_Catg_Desg_Mapping b WHERE   b.Allowance_Type = 'CAR' AND a.Catg=b.Catg AND a.monthyear =  " & ddlMonthYear.SelectedItem.Value & " AND a.type='" & ddlSal.SelectedItem.Value & "'"
            If ofn.CheckRecordExistInTransaction(sql) = True Then
                ofn.FillList(cblDone, sql)
            End If
        End If

    End Sub
    Protected Sub ddlMonthYear_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlMonthYear.SelectedIndexChanged
        ddlSal_SelectedIndexChanged(sender, e)
    End Sub
End Class
