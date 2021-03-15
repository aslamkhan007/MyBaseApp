Imports System.Data
Imports System.Data.SqlClient
Partial Class frm_shed_wise_loom_available
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
    Dim ObjFun As Functions = New Functions
    Dim Qry As String
    Dim order_no, order_qty, location As String

    Protected Sub cmdFetch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdFetch.Click

        'Dim constr As String = System.Web.Configuration.WebConfigurationManager.ConnectionStrings("misjctdev").ConnectionString
        'Dim cn As SqlConnection = New SqlConnection(constr)

        'sqlpass = "exec jct_ops_pp_shed_wise_loomfree "
        'Dim cmd As SqlCommand = New SqlCommand(sqlpass, cn)
        'cmd.CommandTimeout = 0
        'cn.Open()
        'cmd.ExecuteNonQuery()

        'sqlpass = ""
        'ddlshed.SelectedIndex = 0
        'ddlshed_SelectedIndexChanged(sender, Nothing)
        BindData1()

        'Me.grdGrid1.SelectedIndex = -1

    End Sub

    Protected Sub cmdclose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdclose.Click
        Response.Redirect("default.aspx")
        Me.Visible = False
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            '   Qry = "SELECT  '' as shade Union Select distinct shade FROM jct_ops_pp_shedwise_loomfree"
            '   ObjFun.FillList(ddlshed, Qry)
            Dim constr As String = System.Web.Configuration.WebConfigurationManager.ConnectionStrings("misjctdev").ConnectionString
            Dim cn As SqlConnection = New SqlConnection(constr)

            sqlpass = "exec jct_ops_pp_shed_wise_loomfree "
            Dim cmd As SqlCommand = New SqlCommand(sqlpass, cn)
            cmd.CommandTimeout = 0
            cn.Open()
            cmd.ExecuteNonQuery()
            customer()
            orderno()
            sortno()
        End If
    End Sub
    Protected Sub grdGrid1_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdGrid1.RowCreated
        'e.Row.Cells(2).Width = "1000px"
    End Sub
    Protected Sub grdGrid1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdGrid1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            'Dim status As String = DataBinder.Eval(e.Row.DataItem, "Status")
            'If Trim(status) = "D" Then
            '    ' color the forecolor of the row red
            '    e.Row.ForeColor = Drawing.Color.Red
            'End If
        End If
    End Sub
    Protected Sub grdGrid1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdGrid1.SelectedIndexChanged
        'Session("sql") = ""
        ''Session("sql") = "select fs_stock_no as [Stock No.],fs_stock_variant [Variant],Price,convert(varchar(12),fs_tran_Date) as [Tran Date],current_mkt_price as [Current Mkt Price],convert(varchar(12),purchase_date) as [Current Mkt Price Date],fs_uom as [UOM],vendor_no as [Vendor No.],vendor_name as [Vendor Name],account_no as [Account No.] from  jct_cst_raw_material_price_master where status<>'D' and fs_stock_no='" & grdGrid.SelectedRow.Cells(1).Text & "' and fs_stock_variant='" & grdGrid.SelectedRow.Cells(2).Text & "' and company_code='" & Session("Companycode") & "' order by fs_stock_no "
    End Sub

    'for show paging no in grid result 
    Protected Sub grdGrid1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdGrid1.PageIndexChanging
        'Dim Sqlpass As String
        'Sqlpass = "SELECT section_code,loom_no,loom_size,sort_no,day1,day2,day3,day4,day5,day6,day7,day8,day9,day10,day11,day12,day13,day14,day15,day16,day17,day18,day19,day20,day21,day22,day23,day24,day25,day26,day27,day28,day29,day30,day31   FROM jct_pp_shed_wise_looms_available where monthyr = '" & yrmth.Text & "' and  ( (location = '" & ddlshed.Text & "' or '" & ddlshed.Text & "' = 'ALL') order by shed,loom_no "
        'obj2.FillGrid(Sqlpass, grdGrid1)
        grdGrid1.PageIndex = e.NewPageIndex
        BindData1()
        'Me.grdGrid1.SelectedIndex = -1
    End Sub

    Public Sub BindData1()
        Dim Sqlpass As String
        'Sqlpass = "SELECT section_code 'Shed',Loom_no 'LoomNo', convert(varchar(10),beam_start_dt,103)'Beam_StartDt',Beam_no 'BeamNo', Sort_no 'SortNo',Cut_beam 'CutBeam',Left_right 'L/R',sizing_mtrs 'SizingMtrs',conv_mtrs 'ConvertedMtrs',bal_length 'BalanceMtrs',prod_per_day 'Prod/Day',convert(varchar(10),beam_free_dt,103)'Beam_FreeDt' FROM jct_ops_pp_shedwise_loomfree where host_id = host_id() and section_code = '" & ddlshed.Text & "' order by loom_no "
        Sqlpass = "SELECT distinct shade 'Shed',Loom_no 'LoomNo', order_no 'Orderno', cust_name 'Customer',convert(varchar(10),beam_start_dt,103)'Beam_StartDt',Beam_no 'BeamNo', Sort_no 'SortNo',isnull(Cut_beam,' ') 'CutBeam',isnull(Left_right,' ')'L/R',sizing_mtrs 'SizingMtrs',conv_mtrs 'ConvertedMtrs',bal_length 'BalanceMtrs',prod_per_day 'Prod/Day', isnull(beam_free_dt,' ')'Beam_Free_Dt' FROM jct_ops_pp_shedwise_loomfree where ( shade =  '" & ddlshed.Text & "' or '" & ddlshed.Text & "' = '') and ( cust_name =  '" & ddlcustomer.Text & "' or '" & ddlcustomer.Text & "' = ' ') and ( order_no =  '" & ddlorderno.Text & "' or '" & ddlorderno.Text & "' = ' ') and ( sort_no =  '" & ddlsortno.Text & "' or '" & ddlsortno.Text & "' = ' ') order by shade,loom_no "

        CstModule.FillGrid(Sqlpass, grdGrid1)
    End Sub
    Protected Sub cmdexcel1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdexcel1.Click
        'Try
        GridViewExportUtil.Export("shedwise_loom_free.xls", Me.grdGrid1)
        'Catch ex As Exception
        'MsgBox(ex.Message)
        ' End Try

    End Sub
    Public Sub customer()
        'Dim SqlPass As String = "select distinct cust_name from jct_ops_pp_shedwise_loomfree  where host_id = host_id() and shade =  '" & ddlshed.SelectedItem.Text & "' order by cust_name "
        If ddlshed.SelectedItem.Text = "" Then
            sqlpass = "select distinct cust_name from jct_ops_pp_shedwise_loomfree order by cust_name "
        Else
            sqlpass = "select distinct cust_name from jct_ops_pp_shedwise_loomfree  where  shade  = '" & LTrim(RTrim(ddlshed.SelectedItem.Text)) & "' order by cust_name "
        End If

        Dim Dr As SqlDataReader = obj.FetchReader(sqlpass)
        Try
            If Dr.HasRows = True Then
                Me.ddlcustomer.Items.Clear()
                ddlcustomer.Items.Add(" ")
                While Dr.Read()
                    If Not (Dr.Item(0) Is System.DBNull.Value) Then
                        Me.ddlcustomer.Items.Add(Trim(Dr.Item(0)))
                    End If
                End While
            Else
            End If
        Catch ex As Exception
        Finally
            obj.ConClose()
        End Try

    End Sub

    Public Sub orderno()
        If ddlshed.SelectedItem.Text = "" And ddlcustomer.SelectedItem.Text = " " Then
            sqlpass = "select distinct order_no from jct_ops_pp_shedwise_loomfree order by order_no "
        ElseIf ddlshed.SelectedItem.Text <> "" And ddlcustomer.SelectedItem.Text <> " " Then
            sqlpass = "select distinct order_no from jct_ops_pp_shedwise_loomfree  where  shade =  '" & ddlshed.SelectedItem.Text & "' and  cust_name = '" & ddlcustomer.SelectedItem.Text & "' order by order_no  "
        ElseIf ddlshed.SelectedItem.Text <> "" And ddlcustomer.SelectedItem.Text = " " Then
            sqlpass = "select distinct order_no from jct_ops_pp_shedwise_loomfree  where  shade =  '" & ddlshed.SelectedItem.Text & "' order by order_no  "
        End If

        Dim Dr As SqlDataReader = obj.FetchReader(sqlpass)
        Try
            If Dr.HasRows = True Then
                Me.ddlorderno.Items.Clear()
                ddlorderno.Items.Add(" ")
                While Dr.Read()
                    If Not (Dr.Item(0) Is System.DBNull.Value) Then
                        Me.ddlorderno.Items.Add(Trim(Dr.Item(0)))
                    End If
                End While
            Else
            End If
        Catch ex As Exception
        Finally
            obj.ConClose()
        End Try

    End Sub

    Public Sub sortno()
        If ddlshed.SelectedItem.Text = "" And ddlcustomer.SelectedItem.Text = " " And ddlorderno.SelectedItem.Text = " " Then
            sqlpass = "select distinct sort_no from jct_ops_pp_shedwise_loomfree  order by sort_no "
        ElseIf ddlshed.SelectedItem.Text <> "" And ddlcustomer.SelectedItem.Text <> " " And ddlorderno.SelectedItem.Text <> " " Then
            sqlpass = "select distinct sort_no from jct_ops_pp_shedwise_loomfree  where  shade =  '" & ddlshed.SelectedItem.Text & "' and cust_name =  '" & ddlcustomer.SelectedItem.Text & "' and order_no = '" & ddlorderno.SelectedItem.Text & "' order by sort_no  "
        ElseIf ddlshed.SelectedItem.Text <> "" And ddlcustomer.SelectedItem.Text = " " And ddlorderno.SelectedItem.Text = " " Then
            sqlpass = "select distinct sort_no from jct_ops_pp_shedwise_loomfree  where  shade =  '" & ddlshed.SelectedItem.Text & "' order by sort_no  "
        ElseIf ddlshed.SelectedItem.Text <> "" And ddlcustomer.SelectedItem.Text <> " " And ddlorderno.SelectedItem.Text = " " Then
            sqlpass = "select distinct sort_no from jct_ops_pp_shedwise_loomfree  where  shade =  '" & ddlshed.SelectedItem.Text & "' and cust_name =  '" & ddlcustomer.SelectedItem.Text & "' order by sort_no  "
        End If

        Dim Dr As SqlDataReader = obj.FetchReader(sqlpass)
        Try
            If Dr.HasRows = True Then
                Me.ddlsortno.Items.Clear()
                ddlsortno.Items.Add(" ")
                While Dr.Read()
                    If Not (Dr.Item(0) Is System.DBNull.Value) Then
                        Me.ddlsortno.Items.Add(Trim(Dr.Item(0)))
                    End If
                End While
            Else
            End If
        Catch ex As Exception
        Finally
            obj.ConClose()
        End Try

    End Sub

    Protected Sub ddlcustomer_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlcustomer.SelectedIndexChanged
        orderno()
    End Sub

    Protected Sub ddlorderno_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlorderno.SelectedIndexChanged
        sortno()
    End Sub

    Protected Sub ddlshed_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlshed.SelectedIndexChanged
        customer()
    End Sub
End Class

