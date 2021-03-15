Imports System.Data
Imports System.Data.SqlClient
Partial Class planning_entry
    Inherits System.Web.UI.Page
    Dim sql As String
    Dim dr As SqlDataReader
    Dim cmd As SqlCommand
    Dim obj As New Connection
    Dim obj2 As New Functions
    Dim sqlpass, sno2 As String
    Dim scrpt_str As String
    Dim Ash, sno1 As Integer
    Public CstModule As New CostModule
    Dim order_no, shed, eff, rpm, planned_qty, sizing, workinglooms As String

    Protected Sub cmdFetch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdFetch.Click
        'Dim Sqlpass As String
        'Sqlpass = "exec jct_pp_planned_sorts '" & yrmth.Text & "', '" & days.Text & "'"
        'Sqlpass = "SELECT * FROM jct_pp_mth_planned_sorts where monthyr = '" & yrmth.Text & "' and (location = '" & ddllocation.Text & "' or '" & ddllocation.Text & "' = 'ALL') and ( clth_type = '" & ddlclthtype.Text & "'or '" & ddlclthtype.Text & "' = 'ALL')and status <> 'D' order by sort_no "
        'obj2.FillGrid(Sqlpass, grdGrid)
        ' new code 
        Dim constr As String = System.Web.Configuration.WebConfigurationManager.ConnectionStrings("misjctdev").ConnectionString
        Dim cn As SqlConnection = New SqlConnection(constr)

        sqlpass = "exec jct_pp_planned_sorts  '" & ddlaction.Text & "', '" & ddllocation.Text & "'," & Right(ddlyrmth.Text, 6) & ", " & RTrim(ddlrevno1.Text) & "," & ddldays.Text & ",'" & (LTrim(RTrim(Session("Empcode")))) & "' "
        Dim cmd As SqlCommand = New SqlCommand(sqlpass, cn)
        cmd.CommandTimeout = 0
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()
        sqlpass = ""
        BindData()
    End Sub

    Protected Sub cmdclose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdclose.Click
        Response.Redirect("default.aspx")
        Me.Visible = False
    End Sub

    'Protected Sub cmdDetailView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdDetailView.Click
    '   BindData()
    'End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ddlaction_SelectedIndexChanged(sender, e)
            yearmonth()
            ddllocation_SelectedIndexChanged(sender, e)
            revision()


        End If
        'Me.cmdrevision.Enabled = False
    End Sub

    Protected Sub cmdUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click
        'Dim chkBox1 As Boolean
        If Me.grdGrid.Rows.Count <= 0 Then
            FMsg.CssClass = "errormsg"
            FMsg.Message = "No Data Present To Update..Please Fetch The Data.. "
            FMsg.Display()
            Exit Sub
        End If

        obj.ConOpen()
        'For i = 0 To Me.grdGrid.Rows.Count - 1
        '    chkBox1 = (CType(grdGrid.Rows(i).FindControl("Update"), CheckBox).Checked)


        '    If chkBox1 = True Then
        '        Exit For
        '    ElseIf i = Me.grdGrid.Rows.Count - 1 And chkBox1 = False Then
        '        ' FMsg.CssClass = "errormsg"
        '        'FMsg.Message = "Please Click On Chech Box To Update.."
        '        'FMsg.Display()
        '        Exit Sub
        '    End If
        'Next
        Dim chkBox As Boolean
        Dim a As String
        Dim i As Integer
        For i = 0 To Me.grdGrid.Rows.Count - 1

            chkBox = (CType(grdGrid.Rows(i).FindControl("Update"), CheckBox).Checked)
            If chkBox = True Then
                a = "Y"
            Else
                a = "N"
            End If

            chkBox = (CType(grdGrid.Rows(i).FindControl("Update"), CheckBox).Checked)
            If chkBox = True Then
                shed = CType(grdGrid.Rows(i).FindControl("shed"), TextBox).Text
                eff = CType(grdGrid.Rows(i).FindControl("eff"), TextBox).Text
                rpm = CType(grdGrid.Rows(i).FindControl("rpm"), TextBox).Text
                planned_qty = CType(grdGrid.Rows(i).FindControl("planned_qty"), TextBox).Text
                sizing = CType(grdGrid.Rows(i).FindControl("sizing"), TextBox).Text
                workinglooms = CType(grdGrid.Rows(i).FindControl("workinglooms"), TextBox).Text

                'location = CType(grdGrid.Rows(i).FindControl("location"), TextBox).Text
                'sql = "exec jct_pp_update_planned_sorts '" & Replace(LTrim(RTrim(grdGrid.Rows(i).Cells(0).Text)), "&nbsp;", "") & "', '" & shed & "', " & Replace(LTrim(RTrim(grdGrid.Rows(i).Cells(2).Text)), "&nbsp;", "") & ", " & Replace(LTrim(RTrim(grdGrid.Rows(i).Cells(3).Text)), "&nbsp;", "") & " , " & Replace(LTrim(RTrim(grdGrid.Rows(i).Cells(4).Text)), "&nbsp;", "") & " ," & planned_qty & " ,  " & Replace(LTrim(RTrim(grdGrid.Rows(i).Cells(7).Text)), "&nbsp;", "") & "," & days.Text & ",'" & ddllocation.SelectedValue & "','" & ddlclthtype.SelectedValue & "','" & ddlrevno.SelectedValue & "'," & yrmth.Text & "  "

                'If LTrim(RTrim(ddlaction.SelectedValue)) = "Generate Plan" Then
                'sql = "exec jct_pp_update_planned_sorts '" & Replace(LTrim(RTrim(grdGrid.Rows(i).Cells(0).Text)), "&nbsp;", "") & "', '" & shed & "', " & Replace(LTrim(RTrim(grdGrid.Rows(i).Cells(2).Text)), "&nbsp;", "") & ", " & Replace(LTrim(RTrim(grdGrid.Rows(i).Cells(3).Text)), "&nbsp;", "") & " , " & Replace(LTrim(RTrim(grdGrid.Rows(i).Cells(4).Text)), "&nbsp;", "") & " ," & planned_qty & "," & Replace(LTrim(RTrim(grdGrid.Rows(i).Cells(6).Text)), "&nbsp;", "") & " ," & Replace(LTrim(RTrim(grdGrid.Rows(i).Cells(7).Text)), "&nbsp;", "") & ", " & ddldays.Text & ",'" & ddllocation.SelectedValue & "','" & ddlclthtype.SelectedValue & "'," & Right(ddlyrmth.Text, 6) & " , " & ddlrevno1.SelectedValue & " "
                If LTrim(RTrim(ddlaction.SelectedValue)) = "Plan Modify" Then
                    'sql = "exec jct_pp_update_planned_fetch_sorts  '" & Replace(LTrim(RTrim(grdGrid.Rows(i).Cells(0).Text)), "&nbsp;", "") & "', '" & shed & "'," & eff & " , " & rpm & ", " & Replace(LTrim(RTrim(grdGrid.Rows(i).Cells(4).Text)), "&nbsp;", "") & " ," & planned_qty & "," & Replace(LTrim(RTrim(grdGrid.Rows(i).Cells(6).Text)), "&nbsp;", "") & " , " & ddldays.Text & ",'" & ddllocation.SelectedValue & "','" & ddlclthtype.SelectedValue & "'," & Right(ddlyrmth.Text, 6) & " , " & ddlrevno1.SelectedValue & " "
                    'Else
                    'sql = "exec jct_pp_update_planned_sorts  '" & Replace(LTrim(RTrim(grdGrid.Rows(i).Cells(0).Text)), "&nbsp;", "") & "', '" & shed & "'," & eff & " , " & rpm & ", " & Replace(LTrim(RTrim(grdGrid.Rows(i).Cells(4).Text)), "&nbsp;", "") & " ," & planned_qty & "," & Replace(LTrim(RTrim(grdGrid.Rows(i).Cells(6).Text)), "&nbsp;", "") & " ," & sizing & ", " & workinglooms & "," & ddldays.Text & ",'" & ddllocation.SelectedValue & "','" & ddlclthtype.SelectedValue & "'," & Right(ddlyrmth.Text, 6) & " , " & ddlrevno1.SelectedValue & ",'" & Trim(a) & "' "
                    'sql = "exec jct_pp_update_planned_sorts  '" & Replace(LTrim(RTrim(grdGrid.Rows(i).Cells(0).Text)), "&nbsp;", "") & "', '" & shed & "'," & eff & " , " & rpm & ", " & Replace(LTrim(RTrim(grdGrid.Rows(i).Cells(4).Text)), "&nbsp;", "") & " ," & planned_qty & "," & Replace(LTrim(RTrim(grdGrid.Rows(i).Cells(6).Text)), "&nbsp;", "") & " ,0, " & workinglooms & "," & ddldays.Text & ",'" & ddllocation.SelectedValue & "','" & ddlclthtype.SelectedValue & "'," & Right(ddlyrmth.Text, 6) & " , " & ddlrevno1.SelectedValue & ",'" & Trim(a) & "' "
                    sql = "exec jct_pp_update_planned_sorts  '" & Replace(LTrim(RTrim(grdGrid.Rows(i).Cells(0).Text)), "&nbsp;", "") & "', '" & shed & "'," & eff & " , " & rpm & ", " & Replace(LTrim(RTrim(grdGrid.Rows(i).Cells(4).Text)), "&nbsp;", "") & " ," & planned_qty & "," & Replace(LTrim(RTrim(grdGrid.Rows(i).Cells(6).Text)), "&nbsp;", "") & " ," & sizing & ", " & workinglooms & "," & ddldays.Text & ",'" & ddllocation.SelectedValue & "','" & ddlclthtype.SelectedValue & "'," & Right(ddlyrmth.Text, 6) & " , " & ddlrevno1.SelectedValue & ",'" & Trim(a) & "' "
                    'sql = "exec jct_pp_update_planned_sorts  '" & Replace(LTrim(RTrim(grdGrid.Rows(i).Cells(0).Text)), "&nbsp;", "") & "', '" & shed & "'," & eff & " , " & rpm & ", " & Replace(LTrim(RTrim(grdGrid.Rows(i).Cells(4).Text)), "&nbsp;", "") & " ," & planned_qty & "," & Replace(LTrim(RTrim(grdGrid.Rows(i).Cells(6).Text)), "&nbsp;", "") & " ,0, 0, & ddldays.Text & ",'" & ddllocation.SelectedValue & "','" & ddlclthtype.SelectedValue & "'," & Right(ddlyrmth.Text, 6) & " , " & ddlrevno1.SelectedValue & ",'" & Trim(a) & "' "
                End If

                'CstModule.FillGrid(sql, grdGrid)
                'ElseIf LTrim(RTrim(ddlaction.SelectedValue)) = "Plan Modify" Then
                '   sql = "exec jct_pp_update_planned_sorts '" & Replace(LTrim(RTrim(grdGrid.Rows(i).Cells(0).Text)), "&nbsp;", "") & "', '" & shed & "', " & Replace(LTrim(RTrim(grdGrid.Rows(i).Cells(2).Text)), "&nbsp;", "") & ", " & Replace(LTrim(RTrim(grdGrid.Rows(i).Cells(3).Text)), "&nbsp;", "") & " , " & Replace(LTrim(RTrim(grdGrid.Rows(i).Cells(4).Text)), "&nbsp;", "") & " ," & planned_qty & "," & Replace(LTrim(RTrim(grdGrid.Rows(i).Cells(6).Text)), "&nbsp;", "") & " ," & ddldays.Text & ",'" & ddllocation.SelectedValue & "','" & ddlclthtype.SelectedValue & "'," & Right(ddlyrmth.Text, 6) & " , " & ddlrevno1.SelectedValue & " "
                'End If
                Dim cmd As SqlCommand = New SqlCommand(sql, obj.Connection)
                cmd.ExecuteNonQuery()
            End If
        Next
        fetchmodlstgrd()

    End Sub

    Protected Sub grdGrid_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdGrid.SelectedIndexChanged


    End Sub
    ' for show paging no in grid result 
    Protected Sub grdGrid_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdGrid.PageIndexChanging
        grdGrid.PageIndex = e.NewPageIndex
        Dim Sqlpass As String
        Sqlpass = "SELECT * FROM jct_pp_mth_planned_sorts where monthyr = '" & Right(ddlyrmth.Text, 6) & "' and (location = '" & ddllocation.Text & "' )  and (pln_rev_no =  " & ddlrevno1.Text & " ) and ( clth_type = '" & ddlclthtype.Text & "')  order by sort_no "
        obj2.FillGrid(Sqlpass, grdGrid)
        Me.grdGrid.SelectedIndex = -1
    End Sub


    'Public Sub plant_location()
    '    If LTrim(RTrim(ddlaction.SelectedValue)) = "Generate Plan" Then
    '        sqlpass = "SELECT DISTINCT location from jct_pp_fetch_sorts where monthyr =  '" & Right(ddlyrmth.Text, 6) & "'  and  (revision_no = " & ddlrevno1.Text & " ) order by  location "
    '    Else
    '        sqlpass = "select distinct location from jct_pp_mth_planned_sorts where monthyr = '" & Right(ddlyrmth.Text, 6) & "' and  (pln_rev_no = " & ddlrevno1.Text & " ) "
    '    End If

    '    Dim Dr As SqlDataReader = obj.FetchReader(sqlpass)
    '    Try
    '        If dr.HasRows = True Then
    '            Me.ddllocation.Items.Clear()
    '            'ddllocation.Items.Add("ALL")
    '            While dr.Read()
    '                If Not (dr.Item(0) Is System.DBNull.Value) Then
    '                    Me.ddllocation.Items.Add(Trim(dr.Item(0)))
    '                End If
    '            End While
    '        Else
    '        End If
    '    Catch ex As Exception
    '    Finally
    '        obj.ConClose()
    '    End Try

    'End Sub

    Public Sub cot_syn()
        If LTrim(RTrim(ddlaction.SelectedValue)) = "Generate Plan" Then
            'Dim SqlPass As String = "SELECT DISTINCT  isnull(clth_type,' ') from jct_pp_fetch_sorts  where monthyr =  '" & Right(ddlyrmth.Text, 6) & "' and revision_no = " & ddlrevno1.Text & "  order by isnull(clth_type,' ')"
            sqlpass = "SELECT DISTINCT  isnull(clth_type,' ') from jct_pp_fetch_sorts  where monthyr =  '" & Right(ddlyrmth.Text, 6) & "' and revision_no = " & ddlrevno1.Text & "  and location =  '" & ddllocation.Text & "'  order by isnull(clth_type,' ')"
        Else
            sqlpass = "select distinct isnull(clth_type,' ') from jct_pp_mth_planned_sorts where monthyr = '" & Right(ddlyrmth.Text, 6) & "' and pln_rev_no = " & ddlrevno1.Text & " and location =  '" & ddllocation.Text & "'  "
        End If
        Dim Dr As SqlDataReader = obj.FetchReader(sqlpass)

        Try
            If Dr.HasRows = True Then
                ddlclthtype.Items.Clear()
                'ddlsource.Items.Add("")
                ' ddlclthtype.Items.Add("ALL")
                While Dr.Read()
                    If Not (Dr.Item(0) Is System.DBNull.Value) Then
                        Me.ddlclthtype.Items.Add(Trim(Dr.Item(0)))
                    End If
                End While
            Else
            End If
        Catch ex As Exception
        Finally
            obj.ConClose()
        End Try
    End Sub

    'Public Sub rev_no()
    '    Dim SqlPass As String = "SELECT DISTINCT rev_no from jct_pp_mth_planned_sorts where monthyr =  '" & yrmth.Text & "' order by rev_no"
    '    Dim Dr As SqlDataReader = obj.FetchReader(SqlPass)
    '    Try
    '        If Dr.HasRows = True Then
    '            ddlrevno.Items.Clear()
    '            'ddlsource.Items.Add("")
    '            'ddlrevno.Items.Add("ALL")
    '            While Dr.Read()
    '                If Not (Dr.Item(0) Is System.DBNull.Value) Then
    '                    Me.ddlrevno.Items.Add(Trim(Dr.Item(0)))
    '                End If
    '            End While
    '        Else
    '        End If
    '    Catch ex As Exception
    '    Finally
    '        obj.ConClose()
    '    End Try
    'End Sub

    'Protected Sub yrmth_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    'End Sub
    'Protected Sub ddllocation_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddllocation.SelectedIndexChanged
    '    'cot_syn()
    'End Sub
    'Protected Sub ddlclthtype_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlclthtype.SelectedIndexChanged
    '    'rev_no()
    'End Sub

    ' Protected Sub days_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles days.TextChanged
    'Dim constr As String = System.Web.Configuration.WebConfigurationManager.ConnectionStrings("misjctdev").ConnectionString
    'Dim cn As SqlConnection = New SqlConnection(constr)

    'sqlpass = "jct_pp_planned_sorts '" & yrmth.Text & "' ,  " & days.Text & " "
    'Dim cmd As SqlCommand = New SqlCommand(sqlpass, cn)
    'cn.Open()
    'cmd.ExecuteNonQuery()
    'cn.Close()
    'plant_location()
    'cot_syn()

    'End Sub
    Protected Sub shed_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub
    ' show tick sign on front for selected records 

    '    Sub grdgrid_RowDataBound(ByVal sender As Object, _
    'ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdGrid.RowDataBound

    '        If e.Row.RowType = DataControlRowType.DataRow Then
    '            e.Row.Cells(7).Visible = False
    '        End If
    '        If e.Row.RowType = DataControlRowType.DataRow Then
    '            e.Row.Cells(7).Visible = False
    '            Dim status As String = DataBinder.Eval(e.Row.DataItem, "status")
    '            If Trim(status) = "Y" Then
    '                ' Dim chkBox As Boolean
    '                ' color the forecolor of the row red
    '                e.Row.BackColor = Drawing.Color.DarkGray
    '                'CType(e.Row.FindControl("Update"), CheckBox).Checked = True  ( show the tick sign on gride )

    '            End If
    '        End If
    '        If e.Row.RowType = DataControlRowType.Footer Then
    '            e.Row.Cells(7).Visible = False
    '        End If
    '        ' Click on any where in the grid results & the results will be fetch in columns.
    '    End Sub

    Protected Sub grdgrid_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdGrid.RowDataBound

        If e.Row.RowType = DataControlRowType.DataRow Then
            ' e.Row.Cells(6).Visible = False
        End If
        If e.Row.RowType = DataControlRowType.DataRow Then
            ' e.Row.Cells(6).Visible = False
            Dim status As String = DataBinder.Eval(e.Row.DataItem, "status")
            If Trim(status) = "Y" Then
                ' Dim chkBox As Boolean
                ' color the forecolor of the row red
                e.Row.BackColor = Drawing.Color.DarkGray
                'CType(e.Row.FindControl("Update"), CheckBox).Checked = True  ( show the tick sign on gride )

            End If
        End If
      
        ' Click on any where in the grid results & the results will be fetch in columns.
    End Sub

    Public Sub BindData()
        Dim Sqlpass As String
        'Sqlpass = "SELECT * FROM jct_pp_mth_planned_sorts where monthyr = '" & Right(ddlyrmth.Text, 6) & "' and (location = '" & ddllocation.Text & "' or '" & ddllocation.Text & "' = 'ALL') and ( clth_type = '" & ddlclthtype.Text & "'or '" & ddlclthtype.Text & "' = 'ALL') and status <> 'D' order by shed,sort_no "
        If LTrim(RTrim(ddlaction.SelectedValue)) = "Generate Plan" Then
            Sqlpass = "SELECT * FROM jct_pp_mth_planned_sorts where monthyr = '" & Right(ddlyrmth.Text, 6) & "' and (revision_no =  " & ddlrevno1.Text & " ) and (location = '" & ddllocation.Text & "') and ( clth_type = '" & ddlclthtype.Text & "')   order by sort_no  "
        Else
            Sqlpass = "SELECT * FROM jct_pp_mth_planned_sorts where monthyr = '" & Right(ddlyrmth.Text, 6) & "' and (pln_rev_no =  " & ddlrevno1.Text & " ) and (location = '" & ddllocation.Text & "') and ( clth_type = '" & ddlclthtype.Text & "')   order by sort_no  "
        End If
        CstModule.FillGrid(Sqlpass, grdGrid)
    End Sub
    Public Sub fetchmodlstgrd()
        Dim Sqlpass As String
        'Sqlpass = "SELECT * FROM jct_pp_mth_planned_sorts where monthyr = '" & Right(ddlyrmth.Text, 6) & "' and (location = '" & ddllocation.Text & "' or '" & ddllocation.Text & "' = 'ALL') and ( clth_type = '" & ddlclthtype.Text & "'or '" & ddlclthtype.Text & "' = 'ALL') and status <> 'D' order by shed,sort_no "
        If LTrim(RTrim(ddlaction.SelectedValue)) = "Generate Plan" Then
            Sqlpass = "SELECT * FROM jct_pp_mth_planned_sorts where monthyr = '" & Right(ddlyrmth.Text, 6) & "' and (revision_no =  " & ddlrevno1.Text & " ) and (location = '" & ddllocation.Text & "') and ( clth_type = '" & ddlclthtype.Text & "') order by sort_no  "
        Else
            Sqlpass = "SELECT * FROM jct_pp_mth_planned_sorts where monthyr = '" & Right(ddlyrmth.Text, 6) & "'and (location = '" & ddllocation.Text & "') and (pln_rev_no =  " & ddlrevno1.Text & " ) and ( clth_type = '" & ddlclthtype.Text & "') order by sort_no  "
        End If
        CstModule.FillGrid(Sqlpass, grdGrid)
    End Sub
    Protected Sub Update_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Public Sub yearmonth()
        sqlpass = "select top 1 ltrim(rtrim(year_month_name)) + ' - ' + convert(char(6),year_month) from jct_pp_year_month where status = 'A' order by year_month desc"
        Dim Dr As SqlDataReader = obj.FetchReader(sqlpass)
        Try
            If Dr.HasRows = True Then
                Me.ddlyrmth.Items.Clear()
                'ddlrevision.Items.Add("ALL")
                While Dr.Read()
                    If Not (Dr.Item(0) Is System.DBNull.Value) Then
                        Me.ddlyrmth.Items.Add(Trim(Dr.Item(0)))
                    End If
                End While
            Else
            End If
        Catch ex As Exception
        Finally
            obj.ConClose()
        End Try
        'CstModule.FillGrid(sqlpass, grdGrid1)
    End Sub

    Protected Sub ddldays_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddldays.SelectedIndexChanged
        If LTrim(RTrim(ddlaction.SelectedValue)) = "Generate Plan" Then
            'plant_location()
            cot_syn()
        End If
    End Sub

    Protected Sub ddllocation_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddllocation.SelectedIndexChanged
        If LTrim(RTrim(ddlaction.SelectedValue)) = "Freeze Plan" Then
            sqlpass = "exec jct_pp_check_freeze_status '" & ddllocation.SelectedValue & "','" & Right(ddlyrmth.Text, 6) & "'"
            Dim Dr As SqlDataReader = obj.FetchReader(sqlpass)

            If Dr.HasRows = True Then
                While Dr.Read()
                    FMsg.CssClass = "errormsg"
                    FMsg.Message = "Revision No '" & Dr(0) & "' is already Freezed"
                    FMsg.Display()


                End While
                Me.cmdfreeze.Enabled = False
                Me.cmdfreeze.CssClass = "ButtonDisable"
            Else
                Me.cmdfreeze.Enabled = True
                Me.cmdfreeze.CssClass = "buttonc"

            End If
        End If
        revision()


        ddlrevno1_SelectedIndexChanged(sender, e)
    End Sub

    Public Sub revision()
        If LTrim(RTrim(ddlaction.SelectedValue)) = "Generate Plan" Or LTrim(RTrim(ddlaction.SelectedValue)) = "New Sort" Then
            sqlpass = "select distinct isnull(revision_no,0) revision_no from jct_pp_fetch_sorts where monthyr = '" & Right(ddlyrmth.Text, 6) & "' and location = '" & ddllocation.SelectedValue & "' order by revision_no "
        Else
            sqlpass = "select distinct isnull(pln_rev_no,0) from jct_pp_mth_planned_sorts where location = '" & ddllocation.SelectedValue & "'and monthyr = '" & Right(ddlyrmth.Text, 6) & "' "
        End If

        Dim Dr As SqlDataReader = obj2.FetchReader(sqlpass)

        Try
            If Dr.HasRows = True Then
                Me.ddlrevno1.Items.Clear()
                'ddlrevision.Items.Add("ALL")
                While Dr.Read()
                    If Not (Dr.Item(0) Is System.DBNull.Value) Then
                        Me.ddlrevno1.Items.Add(Trim(Dr.Item(0)))
                    End If
                End While
            Else
            End If
        Catch ex As Exception
        Finally
            obj.ConClose()
            Dr.Close()
        End Try
        'CstModule.FillGrid(sqlpass, grdGrid1)
    End Sub

    Public Sub rev_remarks()
        'sqlpass = "select distinct sales_person from jct_pp_fetch_sorts where monthyr = '" & Right(yrmth.Text, 6) & "'and revision_no =   " & ddlrevision.Text & " "
        sqlpass = "select reason_description from  jct_pp_revision_remarks where status <> 'D' order by reason_description "
        Dim Dr As SqlDataReader = obj.FetchReader(sqlpass)
        Try
            If Dr.HasRows = True Then
                Me.ddlremarks.Items.Clear()
                ' ddlremarks.Items.Add("ALL")
                While Dr.Read()
                    If Not (Dr.Item(0) Is System.DBNull.Value) Then
                        Me.ddlremarks.Items.Add(Trim(Dr.Item(0)))
                    End If
                End While
            Else
                ddlremarks.Items.Add(0)
            End If
        Catch ex As Exception
        Finally
            obj.ConClose()
        End Try
        'CstModule.FillGrid(sqlpass, grdGrid1)
    End Sub
    Public Sub remarks()
        If LTrim(RTrim(ddlaction.SelectedValue)) = "Generate Plan" Then
            sqlpass = "select distinct isnull(revision_remarks,' ') from jct_pp_fetch_sorts where monthyr = '" & Right(ddlyrmth.Text, 6) & "' and location = '" & ddllocation.SelectedValue & "' and revision_no = '" & ddlrevno1.SelectedValue & "'"
        Else
            sqlpass = "select distinct isnull(revision_remarks,' ') from jct_pp_mth_planned_sorts where monthyr = '" & Right(ddlyrmth.Text, 6) & "' and location = '" & ddllocation.SelectedValue & "' and pln_rev_no = '" & ddlrevno1.SelectedValue & "'"
        End If
        Dim Dr As SqlDataReader = obj.FetchReader(sqlpass)

        Try
            If Dr.HasRows = True Then

                'ddlrevision.Items.Add("ALL")
                While Dr.Read()

                    'Me.txtremarks.Text = (Trim(Dr.Item(0)))
                    Me.ddlremarks.Text = (Trim(Dr.Item(0)))
                End While
            Else
            End If
        Catch ex As Exception
        Finally
            obj.ConClose()
        End Try
        'CstModule.FillGrid(sqlpass, grdGrid1)
    End Sub
    Protected Sub ddlyrmth_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlyrmth.SelectedIndexChanged
        Dim I As Integer = 0
        Dim STR As String = ""
        STR = ddlyrmth.SelectedItem.Text

        ddldays.Items.Clear()
        For I = 1 To Date.DaysInMonth(STR.Substring(12, 4), Right(ddlyrmth.SelectedItem.Text, 2))
            ddldays.Items.Add(I)
        Next
        revision()
        ' ddllocation_SelectedIndexChanged(sender, e)
        ' fill value in revision no 
        ddlrevno1_SelectedIndexChanged(sender, e)
        rev_remarks()
        If LTrim(RTrim(ddlaction.SelectedValue)) = "Freeze Plan" Then

            sqlpass = "exec jct_pp_check_freeze_status '" & ddllocation.SelectedValue & "','" & Right(ddlyrmth.Text, 6) & "'"
            Dim Dr As SqlDataReader = obj.FetchReader(sqlpass)

            If Dr.HasRows = True Then
                While Dr.Read()
                    FMsg.CssClass = "errormsg"
                    FMsg.Message = "Revision No '" & Dr(0) & "' is already Freezed"
                    FMsg.Display()
                End While
                Me.cmdfreeze.Enabled = False
                Me.cmdfreeze.CssClass = "ButtonDisable"
            Else
                Me.cmdfreeze.Enabled = True
                Me.cmdfreeze.CssClass = "buttonc"

            End If
        End If
    End Sub

    Protected Sub cmdrevision_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdrevision.Click
        'Dim Sqlpass As String
        'If LTrim(RTrim(ddlaction.SelectedValue)) = "Generate Plan" Then
        Dim constr As String = System.Web.Configuration.WebConfigurationManager.ConnectionStrings("misjctdev").ConnectionString
        Dim cn As SqlConnection = New SqlConnection(constr)

        If LTrim(RTrim(ddlaction.SelectedValue)) = "Generate Plan" Then
            sqlpass = "exec jct_pp_planning_fetch_revno '" & ddllocation.SelectedValue & "','" & Right(ddlyrmth.Text, 6) & "', " & ddlrevno1.Text & ",'" & (LTrim(RTrim(Session("Empcode")))) & "' "
        Else
            ' sqlpass = "exec jct_pp_planning_revno '" & ddllocation.SelectedValue & "','" & Right(ddlyrmth.Text, 6) & "', " & ddlrevno1.Text & " , '" & txtremarks.Text & "'"
            If LTrim(RTrim(ddlaction.SelectedValue)) = "Plan Modify" Then
                sqlpass = "exec jct_pp_planning_revno '" & ddllocation.SelectedValue & "','" & Right(ddlyrmth.Text, 6) & "', " & ddlrevno1.Text & " , '" & ddlremarks.SelectedValue & "', '" & ddlclthtype.SelectedValue & "','" & (LTrim(RTrim(Session("Empcode")))) & "'"

            End If
        End If

        Dim cmd As SqlCommand = New SqlCommand(sqlpass, cn)
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()
        'If Me.grdGrid.Rows.Count <= 0 Then
        FMsg.CssClass = "errormsg"
        FMsg.Message = "Revision No Created"
        FMsg.Display()
        Exit Sub
        'End If
        sqlpass = ""
        'End If

    End Sub

    Protected Sub ddlaction_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlaction.SelectedIndexChanged
        If LTrim(RTrim(ddlaction.SelectedValue)) = "Generate Plan" Then
            Me.ddllocation.Enabled = True
            Me.ddlyrmth.Enabled = True
            Me.ddlrevno1.Enabled = True
            Me.ddldays.Enabled = False
            Me.ddlclthtype.Enabled = False
            Me.ddlremarks.Enabled = False

            Me.cmdFetch.Enabled = False
            Me.cmdFetch.CssClass = "ButtonDisable"
            Me.cmdUpdate.Enabled = False
            Me.cmdUpdate.CssClass = "ButtonDisable"
            Me.cmdrevision.Enabled = True
            Me.cmdrevision.CssClass = "buttonc"

            Me.cmdfreeze.Enabled = False
            Me.cmdfreeze.CssClass = "ButtonDisable"
            Me.cmdunfreeze.Enabled = False
            Me.cmdunfreeze.CssClass = "ButtonDisable"
            Me.cmdnewsort.Enabled = False
            Me.cmdnewsort.CssClass = "ButtonDisable"
            Me.Label24.Text = "Process Rev.No"
        End If

        If LTrim(RTrim(ddlaction.SelectedValue)) = "Plan Modify" Then
            Me.ddllocation.Enabled = True
            Me.ddlyrmth.Enabled = True
            Me.ddlrevno1.Enabled = True
            Me.ddldays.Enabled = True
            Me.ddlclthtype.Enabled = True
            Me.ddlremarks.Enabled = True

            Me.cmdFetch.Enabled = True
            Me.cmdFetch.CssClass = "buttonc"
            Me.cmdUpdate.Enabled = True
            Me.cmdUpdate.CssClass = "buttonc"
            Me.cmdrevision.Enabled = True
            Me.cmdrevision.CssClass = "buttonc"
            Me.cmdfreeze.Enabled = False
            Me.cmdfreeze.CssClass = "ButtonDisable"
            Me.cmdunfreeze.Enabled = False
            Me.cmdunfreeze.CssClass = "ButtonDisable"
            Me.cmdnewsort.Enabled = False
            Me.cmdnewsort.CssClass = "ButtonDisable"
            Me.Label24.Text = "Plan Rev.No"


        End If
        If LTrim(RTrim(ddlaction.SelectedValue)) = "Freeze Plan" Then
            Me.ddllocation.Enabled = True
            Me.ddlyrmth.Enabled = True
            'Me.ddlrevno1.Enabled = True
            Me.ddldays.Enabled = False
            Me.ddlclthtype.Enabled = False
            Me.ddlremarks.Enabled = False

            Me.cmdFetch.Enabled = False
            Me.cmdFetch.CssClass = "ButtonDisable"
            Me.cmdUpdate.Enabled = False
            Me.cmdUpdate.CssClass = "ButtonDisable"
            Me.cmdrevision.Enabled = False
            Me.cmdrevision.CssClass = "ButtonDisable"

            Me.cmdfreeze.Enabled = True
            Me.cmdfreeze.CssClass = "buttonc"
            Me.cmdunfreeze.Enabled = False
            Me.cmdunfreeze.CssClass = "ButtonDisable"

            Me.cmdnewsort.Enabled = False
            Me.cmdnewsort.CssClass = "ButtonDisable"

            Dim constr As String = System.Web.Configuration.WebConfigurationManager.ConnectionStrings("misjctdev").ConnectionString
            Dim cn As SqlConnection = New SqlConnection(constr)

            sqlpass = "exec jct_pp_check_freeze_status '" & ddllocation.SelectedValue & "','" & Right(ddlyrmth.Text, 6) & "'"
            Dim Dr As SqlDataReader = obj.FetchReader(sqlpass)

            If Dr.HasRows = True Then
                While Dr.Read()
                    FMsg.CssClass = "errormsg"
                    FMsg.Message = "Revision No '" & Dr(0) & "' is already Freezed"
                    FMsg.Display()


                End While
                Me.cmdfreeze.Enabled = False
                Me.cmdfreeze.CssClass = "ButtonDisable"
                Me.ddlrevno1.Enabled = False
            Else
                Me.cmdfreeze.Enabled = True
                Me.cmdfreeze.CssClass = "buttonc"
                Me.ddlrevno1.Enabled = True
            End If
            Me.Label24.Text = "Plan Rev.No"
        End If

        If LTrim(RTrim(ddlaction.SelectedValue)) = "UnFreeze Plan" Then
            Me.ddllocation.Enabled = True
            Me.ddlyrmth.Enabled = True
            Me.ddlrevno1.Enabled = True
            Me.ddldays.Enabled = False
            Me.ddlclthtype.Enabled = False
            Me.ddlremarks.Enabled = False

            Me.cmdFetch.Enabled = False
            Me.cmdFetch.CssClass = "ButtonDisable"
            Me.cmdUpdate.Enabled = False
            Me.cmdUpdate.CssClass = "ButtonDisable"
            Me.cmdrevision.Enabled = False
            Me.cmdrevision.CssClass = "ButtonDisable"

            Me.cmdfreeze.Enabled = False
            Me.cmdfreeze.CssClass = "ButtonDisable"
            Me.cmdunfreeze.Enabled = True
            Me.cmdunfreeze.CssClass = "buttonc"

            Me.cmdunfreeze.CssClass = "buttonc"
            Me.cmdnewsort.Enabled = False
            Me.cmdnewsort.CssClass = "ButtonDisable"
            Me.Label24.Text = "Plan Rev.No"


        End If
        If LTrim(RTrim(ddlaction.SelectedValue)) = "New Sort" Then
            Me.ddllocation.Enabled = True
            Me.ddlyrmth.Enabled = True
            Me.ddlrevno1.Enabled = True
            Me.ddldays.Enabled = False
            Me.ddlclthtype.Enabled = False
            Me.ddlremarks.Enabled = False


            Me.cmdFetch.Enabled = False
            Me.cmdFetch.CssClass = "ButtonDisable"
            Me.cmdUpdate.Enabled = False
            Me.cmdUpdate.CssClass = "ButtonDisable"
            Me.cmdrevision.Enabled = False
            Me.cmdrevision.CssClass = "ButtonDisable"

            Me.cmdfreeze.Enabled = False
            Me.cmdfreeze.CssClass = "ButtonDisable"
            Me.cmdunfreeze.Enabled = False
            Me.cmdunfreeze.CssClass = "ButtonDisable"
            Me.cmdnewsort.Enabled = True
            Me.cmdnewsort.CssClass = "buttonc"
            Me.Label24.Text = "Process Rev.No"
        End If
    End Sub

    Protected Sub ddlrevno1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlrevno1.SelectedIndexChanged
        'If LTrim(RTrim(ddlaction.SelectedValue)) = "Plan Modify" Then
        'plant_location()
        remarks()
        cot_syn()
        'End If
    End Sub

    ' code for select all records for updation
    Protected Sub Update_CheckedChanged1(ByVal sender As Object, ByVal e As System.EventArgs)


    End Sub
    ' code for select all records for selection
    Protected Sub Update_CheckedChanged2(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim cbHeader As CheckBox = CType(grdGrid.HeaderRow.FindControl("Update"), CheckBox)
        If cbHeader.Checked = True Then
            For k = 0 To grdGrid.Rows.Count - 1
                Dim myCheckBox As CheckBox = _
                    CType(grdGrid.Rows(k).FindControl("Update"), CheckBox)
                myCheckBox.Checked = True
            Next
        ElseIf cbHeader.Checked = False Then
            For k = 0 To grdGrid.Rows.Count - 1
                Dim myCheckBox As CheckBox = _
                         CType(grdGrid.Rows(k).FindControl("Update"), CheckBox)
                myCheckBox.Checked = False
            Next
        End If
    End Sub

    Protected Sub ddlclthtype_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlclthtype.SelectedIndexChanged

    End Sub


    Protected Sub cmdfreeze_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdfreeze.Click
        Dim constr As String = System.Web.Configuration.WebConfigurationManager.ConnectionStrings("misjctdev").ConnectionString
        Dim cn As SqlConnection = New SqlConnection(constr)

        sqlpass = "exec jct_pp_freeze_plan '" & ddllocation.SelectedValue & "','" & Right(ddlyrmth.Text, 6) & "'," & ddlrevno1.Text & ""
        '" & (LTrim(RTrim(Session("Empcode")))) & "'"
        Dim Dr As SqlDataReader = obj.FetchReader(sqlpass)

        If Dr.HasRows = True Then
            While Dr.Read()
                FMsg.CssClass = "errormsg"
                FMsg.Message = "Revision No '" & Dr(0) & "' is Freezed"
                FMsg.Display()

            End While
        Else
        End If

    End Sub

    Protected Sub cmdunfreeze_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdunfreeze.Click
        Dim constr As String = System.Web.Configuration.WebConfigurationManager.ConnectionStrings("misjctdev").ConnectionString
        Dim cn As SqlConnection = New SqlConnection(constr)

        sqlpass = "exec jct_pp_unfreeze_plan '" & ddllocation.SelectedValue & "','" & Right(ddlyrmth.Text, 6) & "'," & ddlrevno1.Text & " "
        Dim Dr As SqlDataReader = obj.FetchReader(sqlpass)

        If Dr.HasRows = True Then
            While Dr.Read()
                FMsg.CssClass = "errormsg"
                FMsg.Message = "Plan No '" & Dr(0) & "' is Unfreezed"
                FMsg.Display()

            End While
        Else
        End If
    End Sub

    Protected Sub cmdnewsort_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdnewsort.Click
        Dim constr As String = System.Web.Configuration.WebConfigurationManager.ConnectionStrings("misjctdev").ConnectionString
        Dim cn As SqlConnection = New SqlConnection(constr)

        sqlpass = "exec jct_pp_sort_add_final_plan  '" & ddllocation.SelectedValue & "','" & Right(ddlyrmth.Text, 6) & "'," & ddlrevno1.Text & ",'" & (LTrim(RTrim(Session("Empcode")))) & "' "
        Dim Dr As SqlDataReader = obj.FetchReader(sqlpass)
        Dr.Read()
        If Dr.HasRows = True Then
            FMsg.CssClass = "errormsg"
            FMsg.Message = "New Sorts added Sucessfully "
            FMsg.Display()
        Else
            FMsg.CssClass = "errormsg"
            FMsg.Message = "Sorts added Already"
            FMsg.Display()
        End If
    End Sub

    
End Class

