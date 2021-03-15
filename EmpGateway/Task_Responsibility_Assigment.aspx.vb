Imports System.Data.SqlClient
Imports system.Data
Imports vb = Microsoft.VisualBasic
Partial Class Default4
    Inherits System.Web.UI.Page
    Dim db As Connection = New Connection
    Dim sql As String
    Dim da As SqlDataAdapter
    Dim dr As SqlDataReader
    Dim cmd As SqlCommand
    Public obj As New HelpDeskClass
    Public qry As String
    Dim i As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        If (Session("Empcode").ToString <> "") Then
            'empcode = Session("Empcode")
        Else
            Response.Redirect("~/login.aspx")
        End If

        If Not IsPostBack Then
            Try
                sql = "select area from jct_emp_area_master where company_code='" & session("Companycode") & "' order by area"
                dr = db.FetchReader(sql)
                If dr.HasRows Then
                    While dr.Read()
                        If (Not dr.Item(0) Is DBNull.Value) Then
                            ddlArea.Items.Add(dr.Item(0).ToString())
                        End If
                    End While
                    ddlArea.Items.Add("")
                    ddlArea.Text = ""
                End If
            Catch ex As Exception
                lblError.Text = ex.Message
            Finally
                dr.Close()
            End Try
        End If
    End Sub

    Protected Sub ddlArea_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlArea.SelectedIndexChanged

        Try
            sql = "select subarea from jct_emp_sub_area_master where company_code='" & session("Companycode") & "' and area = '" & ddlArea.Text & "' order by subarea"
            Dim cn As SqlConnection
            cn = db.Connection
            da = New SqlDataAdapter(sql, cn)
            Dim dt As DataTable = New DataTable
            da.Fill(dt)

            ddlSubArea.DataSource = dt
            ddlSubArea.DataTextField = "subarea"
            ddlSubArea.DataValueField = "subarea"
            ddlSubArea.DataBind()
            'cmd = New SqlCommand(sql, cn)
            'dr = db.FetchReader(sql)
            'If dr.HasRows Then
            '    While dr.Read()
            '        If (Not dr.Item(0) Is DBNull.Value) Then
            '            ddlSubArea.Items.Add(dr.Item(0).ToString())
            '        End If
            '    End While
            ddlSubArea.Items.Add("")
            ddlSubArea.Text = ""

            'End If
            'dr.Close()

            'sql = "select empname, deptno from jct_empmast_base where active = 'y'"
            'dr = db.FetchReader(sql)
            'If dr.HasRows Then
            '    While dr.Read()
            '        If (Not dr.Item(0) Is DBNull.Value) Then
            '            'ddlSubArea.Items.Add(dr.Item(0).ToString())
            '            cblEmailAddress.Items.Add(dr.Item(0).ToString() & " | " & dr.Item(1).ToString())

            '        End If
            '    End While
            'Else
            '    RegisterClientScriptBlock("scr1", "alert('No data')")
            'End If

        Catch ex As Exception
            lblError.Text = ex.Message
            'Finally
            '    dr.Close()
        End Try
    End Sub

    Protected Sub ddlSubArea_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlSubArea.SelectedIndexChanged

        Try
            'select emp_code from jct_emp_hod where resp_emp in (select distinct resp_emp from jct_emp_hod a, jct_empmast_base b where 
            'a.emp_code = b.empcode and b.deptcode='mis' and a.flag='h'
            'and status is null) and flag='h' and status is null

            'sql = "select b.empcode, b.empname from jct_emp_hod a, jct_empmast_base b " & _
            '"where resp_emp in (select distinct resp_emp from jct_emp_hod a, jct_empmast_base b, jct_emp_area_master c " & _
            '"where(a.emp_code = b.empcode And b.deptcode = c.Area_code) " & _
            '"and c.area = '" & ddlArea.Text & "' and a.flag='h'and a.status is null)" & _
            '"and a.emp_code = b.empcode and a.flag='h' and a.status is null and b.active='y' union select a.empcode,a.empname from jct_empmast_base a, jct_emp_area_master b where b.area_code=a.deptcode and b.area='" & Trim(Me.ddlArea.Text) & "' and a.active='y' order by empcode"

            'sql = "select a.name, a.e_mailid from savior..mistel a, reportdb..jct_emp_sub_area_master b where a.empcode = b.emp_code and area = '" & Trim(ddlArea.Text) & "'"



            ' sql = "select b.empcode, b.empname from jct_emp_hod a, jct_empmast_base b " & _
            '"where resp_emp in (select distinct resp_emp from jct_emp_hod a, jct_empmast_base b, jct_emp_area_master c " & _
            '"where a.emp_code = b.empcode And b.deptcode = c.Area_code " & _
            '"and c.area = '" & ddlArea.Text & "' and c.company_code='" & session("Companycode") & "' and a.flag='1h' and a.status is null)" & _
            '"and a.emp_code = b.empcode and a.flag = '1h' and a.status is null and b.active = 'y' and assosc_flag <> 'D'" & _
            '" union " & _
            '"select a.empcode, a.empname from jct_empmast_base a, jct_emp_area_master b where b.area_code=a.deptcode and b.area='" & Trim(Me.ddlArea.Text) & "' and a.active='y' and assosc_flag <> 'D'" & _
            '" union " & _
            '"select a.resp_emp, b.empname from jct_emp_hod a, jct_empmast_base b " & _
            '"where emp_code in (select distinct a.emp_code from jct_emp_hod a, jct_empmast_base b, jct_emp_area_master c " & _
            '"where a.emp_code = b.empcode And b.deptcode = c.Area_code " & _
            '"and c.area = '" & ddlArea.Text & "' and c.company_code='" & session("Companycode") & "' and a.flag='1h' and a.status is null)" & _
            '"and a.resp_emp = b.empcode and a.flag='1h' and a.status is null and b.active = 'y' and assosc_flag <> 'D'" & _
            '" union " & _
            '"select b.empcode, b.empname from jct_emp_hod a, jct_empmast_base b " & _
            '"where resp_emp in (select a.resp_emp from jct_emp_hod a, jct_empmast_base b " & _
            '"where a.emp_code in (select distinct a.emp_code from jct_emp_hod a, jct_empmast_base b, jct_emp_area_master c " & _
            '"where a.emp_code = b.empcode And b.deptcode = c.Area_code and c.area = '" & ddlArea.Text & "' and c.company_code='" & session("Companycode") & "' and a.flag='1h' and a.status is null) " & _
            '"and b.empcode = a.resp_emp and a.flag='1h' and a.status is null and b.active = 'y') and a.emp_code = b.empcode and a.flag='1h' " & _
            '"and a.status is null and b.active='y' "

            'Modified by Neha to include employees who are not in defined Area but their HODs are
            sql = "exec JCT_EMP_Task_Emp '" & ddlArea.Text & "','" & session("Companycode") & "'"
            dr = db.FetchReader(sql)
            cblEmpResp.Items.Clear()
            If dr.HasRows Then
                While dr.Read()
                    If (Not dr.Item(0) Is DBNull.Value) Then
                        cblEmpResp.Items.Add(New ListItem(dr.Item(1).ToString() & " | " & dr.Item(0).ToString(), dr.Item(0).ToString()))
                    End If
                End While
            End If
        Catch ex As Exception
            lblError.Text = ex.Message
        Finally
            dr.Close()
        End Try
    End Sub

    Protected Sub cmdTo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdTo.Click
        ' Dim i As Integer
        'Dim c As Integer
        For i = 0 To cblEmpResp.Items.Count - 1
            If i <= cblEmpResp.Items.Count - 1 Then
                If cblEmpResp.Items(i).Selected Then
                    cblTo.Items.Add(cblEmpResp.Items(i))
                    cblEmpResp.Items.RemoveAt(i)
                    i -= 1
                End If
            End If
        Next
    End Sub

    Protected Sub cmdCC_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCC.Click

        'Dim i As Integer
        'Dim c As Integer
        For i = 0 To cblEmpResp.Items.Count - 1
            If i <= cblEmpResp.Items.Count - 1 Then
                If cblEmpResp.Items(i).Selected Then
                    cblCC.Items.Add(cblEmpResp.Items(i))
                    cblEmpResp.Items.RemoveAt(i)
                    i -= 1
                End If
            End If
        Next

    End Sub

    Protected Sub cmdSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        Try
            For i = 0 To Me.cblTo.Items.Count - 1
                obj.opencn()
                qry = "insert into JCT_Emp_Sub_Area_Responsibility values ('" & Session("Companycode") & "','" & Session("Empcode") & "','" & Replace(Trim(Me.ddlArea.Text), "'", "''") & "','" & Replace(Trim(Me.ddlSubArea.Text), "'", "''") & "',ltrim('" & cblTo.Items(i).Value.ToString() & "'), 'R', '', getdate(),'12/31/3000')"
                cmd = New SqlCommand(qry, obj.cn)
                cmd.ExecuteNonQuery()
                obj.closecn()
            Next

            For i = 0 To Me.cblCC.Items.Count - 1
                obj.opencn()
                qry = "insert into JCT_Emp_Sub_Area_Responsibility values ('" & Session("Companycode") & "','" & Session("Empcode") & "','" & Replace(Trim(Me.ddlArea.Text), "'", "''") & "','" & Replace(Trim(Me.ddlSubArea.Text), "'", "''") & "',ltrim('" & cblCC.Items(i).Value.ToString() & "'), 'O', '', getdate(),'12/31/3000')"
                cmd = New SqlCommand(qry, obj.cn)
                cmd.ExecuteNonQuery()
                obj.closecn()
            Next
            cblEmpResp.Items.Clear()
            cblTo.Items.Clear()
            cblCC.Items.Clear()
            ClientScript.RegisterClientScriptBlock(Me.GetType, "scr", "alert('Task Responsibility Mapping Saved Successfully')", True)
        Catch
            ClientScript.RegisterClientScriptBlock(Me.GetType, "scr", "alert('Error Occured! Mapping Not Saved')", True)
        Finally
            obj.closecn()
        End Try

    End Sub
    
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Dim i As Integer
        For i = 0 To cblEmpResp.Items.Count - 1
            cblEmpResp.Items(i).Selected = True
        Next
    End Sub

    Protected Sub cmdDeselectEmp_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdDeselectEmp.Click
        ' Dim i As Integer
        For i = 0 To cblEmpResp.Items.Count - 1
            cblEmpResp.Items(i).Selected = False
        Next
    End Sub

    Protected Sub cmdRemove_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdRemove.Click
        For i = 0 To Me.cblTo.Items.Count - 1
            If i <= Me.cblTo.Items.Count - 1 Then
                If Me.cblTo.Items(i).Selected = True Then
                    Me.cblEmpResp.Items.Add(Me.cblTo.Items(i).Text)
                    Me.cblTo.Items.RemoveAt(i)
                    i = i - 1
                End If
            End If
        Next

        For i = 0 To Me.cblCC.Items.Count - 1
            If i <= Me.cblCC.Items.Count - 1 Then
                If Me.cblCC.Items(i).Selected = True Then
                    Me.cblEmpResp.Items.Add(Me.cblCC.Items(i).Text)
                    Me.cblCC.Items.RemoveAt(i)
                    i = i - 1
                End If
            End If
        Next
    End Sub
End Class
