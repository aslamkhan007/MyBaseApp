Imports System.Data.SqlClient
Imports System.Data
Imports System.Web.HttpResponse
Imports vb = Microsoft.VisualBasic
Imports System.String
Imports System.Math
Partial Class material_required
    Inherits System.Web.UI.Page
    Dim sql As String
    Dim dr As SqlDataReader
    Dim cmd As SqlCommand
    Dim sqlpass, sno2 As String
    Public obj As New HelpDeskClass
    Dim Ash, sno1 As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Session("Companycode") = "JCT00LTD"
        'Session("Empcode") = "C-00509"

        If Not IsPostBack Then

            ''txt_tranno.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)) {document.getElementById('" + btn_enter.UniqueID + "').click();return false;}} else {return true}; ")
            'txt_tranno.Attributes.Add("onkeypress", "return clickButton(event,'" + btn_enter.ClientID + "')")


            ''-----Fill Year Month Combo Box
            sqlpass = "select distinct ltrim(rtrim(a.year_month_name))+' - '+convert(char(6),a.year_month), a.year_month " & _
                    "from jct_pp_year_month a " & _
                    "where upper(ltrim(rtrim(a.status))) in ('A') " & _
                    "and upper(ltrim(rtrim(a.company_code)))='" & Session("Companycode") & "' " & _
                    "order by a.year_month desc "

            obj.opencn()
            cmd = New SqlCommand(sqlpass, obj.cn)
            dr = cmd.ExecuteReader

            If dr.HasRows = True Then
                While dr.Read
                    Me.ddl_yearmonth.Items.Add(dr.Item(0))
                End While
                Me.ddl_yearmonth.SelectedIndex = 0
            Else
                FMsg.Message = "Year Month not defined"
                FMsg.CssClass = "errormsg"
                FMsg.Display()
                Me.ddl_yearmonth.Focus()
                dr.Close()
                Exit Sub
            End If
            dr.Close()
            obj.closecn()


            ''-----Fill Rev.No. Combo Box
            sqlpass = "select distinct a.pln_rev_no " & _
                    "from jct_pp_mth_planned_sorts a " & _
                    "where upper(ltrim(rtrim(a.monthyr))) = '" & Right(RTrim(Me.ddl_yearmonth.Text), 6) & "' " & _
                    "and location='" & LTrim(RTrim(Me.ddl_plant.Text)) & "' " & _
                    "/*and upper(ltrim(rtrim(a.company_code)))='" & Session("Companycode") & "'*/ " & _
                    "order by a.pln_rev_no "

            obj.opencn()
            cmd = New SqlCommand(sqlpass, obj.cn)
            dr = cmd.ExecuteReader

            If dr.HasRows = True Then
                While dr.Read
                    Me.ddl_revno.Items.Add(dr.Item(0))
                End While
                Me.ddl_revno.SelectedIndex = 0
            Else
                FMsg.Message = "Rev.No. not defined"
                FMsg.CssClass = "errormsg"
                FMsg.Display()
                Me.ddl_revno.Focus()
                dr.Close()
                Exit Sub
            End If
            dr.Close()
            obj.closecn()


            ''-----Fill Remarks Text Box
            sqlpass = "select distinct top 1 isnull(a.revision_remarks,'') " & _
                    "from jct_pp_mth_planned_sorts a " & _
                    "where upper(ltrim(rtrim(a.monthyr))) = '" & Right(RTrim(Me.ddl_yearmonth.Text), 6) & "' " & _
                    "and a.pln_rev_no=" & Val(Me.ddl_revno.Text) & _
                    " /*and upper(ltrim(rtrim(a.company_code)))='" & Session("Companycode") & "'*/ "

            obj.opencn()
            cmd = New SqlCommand(sqlpass, obj.cn)
            dr = cmd.ExecuteReader

            If dr.HasRows = True Then
                dr.Read()
                Me.txt_remarks.Text = dr.Item(0)
            Else
                FMsg.Message = "Rev.No. not defined"
                FMsg.CssClass = "errormsg"
                FMsg.Display()
                Me.ddl_revno.Focus()
                dr.Close()
                Exit Sub
            End If
            dr.Close()
            obj.closecn()


        End If

    End Sub

    Protected Sub lnk_fetch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnk_fetch.Click

        If LTrim(RTrim(Me.ddl_yearmonth.Text)) = "" Or LTrim(RTrim(Me.ddl_revno.Text)) = "" Then
            FMsg.Message = "Invalid Year Month"
            FMsg.CssClass = "errormsg"
            FMsg.Display()
            Exit Sub
        End If

        Dim rtype As String = ""

        If Me.ddl_reporttype.Text = "Sort wise looms requirement advice" Then
            rtype = "Q"  ''Quality/Sort wise
        End If

        If Me.ddl_reporttype.Text = "Sort wise yarn requirement advice" Then
            rtype = "S"  ''Sort wise
        End If

        If Me.ddl_reporttype.Text = "Count wise yarn requirement advice" Then
            rtype = "C"  ''Count wise
        End If

        If Me.ddl_reporttype.Text = "Raw material value advice" Then
            rtype = "R"  ''Count wise raw material valuation
        End If

        obj.opencn()

        ''Dim Sqlpass = "exec jct_pp_required_material_fetch '" & Me.ddl_yearmonth.Text & "','" & Me.ddl_revno.Text & "','" & UCase(LTrim(RTrim(Session("empcode")))) & "','" & UCase(LTrim(RTrim(Session("companycode")))) & "'"

        If Me.ddl_reporttype.Text = "Planned Vs Actual Prdn." Then
            sqlpass = "exec jct_pp_fetch_planned_vs_actual " & Right(RTrim(Me.ddl_yearmonth.Text), 6) & "," & _
                    Me.ddl_revno.Text & ",'" & _
                    Left(ddl_cotsyn.Text, 1) & "','" & _
                    Left(ddl_plant.Text, 1) & "','" & _
                    rtype & "','" & _
                    UCase(LTrim(RTrim(Session("empcode")))) & "','" & _
                    UCase(LTrim(RTrim(Session("companycode")))) & "'"
        Else
            sqlpass = "exec jct_pp_monthly_req " & Right(RTrim(Me.ddl_yearmonth.Text), 6) & "," & _
                    Me.ddl_revno.Text & ",'" & _
                    Left(ddl_cotsyn.Text, 1) & "','" & _
                    Left(ddl_plant.Text, 1) & "','" & _
                    rtype & "','" & _
                    UCase(LTrim(RTrim(Session("empcode")))) & "','" & _
                    UCase(LTrim(RTrim(Session("companycode")))) & "'"
        End If

        Dim Da As SqlDataAdapter = New SqlDataAdapter(sqlpass, obj.cn)

        Try

            Dim ds As DataSet = New DataSet()
            Da.Fill(ds)
            GridView1.DataSource = ds
            GridView1.DataBind()
        Catch ex As Exception
            obj.closecn()
            FMsg.Message = (ex.Message)
            FMsg.CssClass = "addmsg"
            FMsg.Display()
        Finally
            obj.closecn()
        End Try

    End Sub

    Protected Sub ddl_yearmonth_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl_yearmonth.SelectedIndexChanged

        ''-----ReFill Rev.No. Combo Box

        Me.ddl_revno.Items.Clear()

        sqlpass = "select distinct a.pln_rev_no " & _
                "from jct_pp_mth_planned_sorts a " & _
                "where upper(ltrim(rtrim(a.monthyr))) = '" & Right(RTrim(Me.ddl_yearmonth.Text), 6) & "' " & _
                "and location='" & LTrim(RTrim(Me.ddl_plant.Text)) & "' " & _
                "/*and upper(ltrim(rtrim(a.company_code)))='" & Session("Companycode") & "'*/ " & _
                "order by a.pln_rev_no "

        obj.opencn()
        cmd = New SqlCommand(sqlpass, obj.cn)
        dr = cmd.ExecuteReader

        If dr.HasRows = True Then
            While dr.Read
                Me.ddl_revno.Items.Add(dr.Item(0))
            End While
            Me.ddl_revno.SelectedIndex = 0
        Else
            FMsg.Message = "Rev.No. not defined"
            FMsg.CssClass = "errormsg"
            FMsg.Display()
            Me.ddl_revno.Focus()
            dr.Close()
            Exit Sub
        End If
        dr.Close()
        obj.closecn()


        ''-----ReFill Remarks Text Box
        sqlpass = "select distinct top 1 isnull(a.revision_remarks,'') " & _
                "from jct_pp_mth_planned_sorts a " & _
                "where upper(ltrim(rtrim(a.monthyr))) = '" & Right(RTrim(Me.ddl_yearmonth.Text), 6) & "' " & _
                "and a.pln_rev_no=" & Val(Me.ddl_revno.Text) & _
                " /*and upper(ltrim(rtrim(a.company_code)))='" & Session("Companycode") & "'*/ "

        obj.opencn()
        cmd = New SqlCommand(sqlpass, obj.cn)
        dr = cmd.ExecuteReader

        If dr.HasRows = True Then
            dr.Read()
            Me.txt_remarks.Text = dr.Item(0)
        Else
            FMsg.Message = "Rev.No. not defined"
            FMsg.CssClass = "errormsg"
            FMsg.Display()
            Me.ddl_revno.Focus()
            dr.Close()
            Exit Sub
        End If
        dr.Close()
        obj.closecn()

    End Sub

    Protected Sub lnk_exit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnk_exit.Click

        Me.Dispose()
        Response.Redirect("default.aspx")

    End Sub

    Protected Sub lnk_excel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnk_excel.Click

        'GridViewExportUtil.Export("planning.xls", Me.GridView1)
        Dim filename As String = LTrim(RTrim(Me.ddl_reporttype.Text)) + "_" + Right(RTrim(Me.ddl_yearmonth.Text), 6) + "-" + LTrim(RTrim(Me.ddl_revno.Text)) + ".xls"
        GridViewExportUtil.Export(filename, Me.GridView1)

    End Sub

    Protected Sub ddl_revno_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl_revno.SelectedIndexChanged

        ''-----ReFill Remarks Text Box
        sqlpass = "select distinct top 1 isnull(a.revision_remarks,'') " & _
                "from jct_pp_mth_planned_sorts a " & _
                "where upper(ltrim(rtrim(a.monthyr))) = '" & Right(RTrim(Me.ddl_yearmonth.Text), 6) & "' " & _
                "and a.pln_rev_no=" & Val(Me.ddl_revno.Text) & _
                " /*and upper(ltrim(rtrim(a.company_code)))='" & Session("Companycode") & "'*/ "

        obj.opencn()
        cmd = New SqlCommand(sqlpass, obj.cn)
        dr = cmd.ExecuteReader

        If dr.HasRows = True Then
            dr.Read()
            Me.txt_remarks.Text = dr.Item(0)
        Else
            FMsg.Message = "Rev.No. not defined"
            FMsg.CssClass = "errormsg"
            FMsg.Display()
            Me.ddl_revno.Focus()
            dr.Close()
            Exit Sub
        End If
        dr.Close()
        obj.closecn()

    End Sub

    Protected Sub ddl_plant_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl_plant.SelectedIndexChanged

        If Me.ddl_plant.Text = "Taffeta" Then
            Me.ddl_cotsyn.Text = "Synthetic"
        End If

        ''-----ReFill Rev.No. Combo Box

        Me.ddl_revno.Items.Clear()

        sqlpass = "select distinct a.pln_rev_no " & _
                "from jct_pp_mth_planned_sorts a " & _
                "where upper(ltrim(rtrim(a.monthyr))) = '" & Right(RTrim(Me.ddl_yearmonth.Text), 6) & "' " & _
                "and location='" & LTrim(RTrim(Me.ddl_plant.Text)) & "' " & _
                "/*and upper(ltrim(rtrim(a.company_code)))='" & Session("Companycode") & "'*/ " & _
                "order by a.pln_rev_no "

        obj.opencn()
        cmd = New SqlCommand(sqlpass, obj.cn)
        dr = cmd.ExecuteReader

        If dr.HasRows = True Then
            While dr.Read
                Me.ddl_revno.Items.Add(dr.Item(0))
            End While
            Me.ddl_revno.SelectedIndex = 0
        Else
            FMsg.Message = "Rev.No. not defined"
            FMsg.CssClass = "errormsg"
            FMsg.Display()
            Me.ddl_revno.Focus()
            dr.Close()
            Exit Sub
        End If
        dr.Close()
        obj.closecn()


        ''-----ReFill Remarks Text Box
        sqlpass = "select distinct top 1 isnull(a.revision_remarks,'') " & _
                "from jct_pp_mth_planned_sorts a " & _
                "where upper(ltrim(rtrim(a.monthyr))) = '" & Right(RTrim(Me.ddl_yearmonth.Text), 6) & "' " & _
                "and a.pln_rev_no=" & Val(Me.ddl_revno.Text) & _
                " /*and upper(ltrim(rtrim(a.company_code)))='" & Session("Companycode") & "'*/ "

        obj.opencn()
        cmd = New SqlCommand(sqlpass, obj.cn)
        dr = cmd.ExecuteReader

        If dr.HasRows = True Then
            dr.Read()
            Me.txt_remarks.Text = dr.Item(0)
        Else
            FMsg.Message = "Rev.No. not defined"
            FMsg.CssClass = "errormsg"
            FMsg.Display()
            Me.ddl_revno.Focus()
            dr.Close()
            Exit Sub
        End If
        dr.Close()
        obj.closecn()

    End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound

        If e.Row.Cells(0).Text = "999999" Then
            e.Row.Cells(0).Text = "Total"
            ''e.Row.Cells(0).BackColor = Drawing.Color.LightGreen
            e.Row.BackColor = Drawing.Color.LightGreen
        End If

    End Sub

End Class
