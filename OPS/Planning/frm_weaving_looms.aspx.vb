﻿Imports System.Data
Imports System.Data.SqlClient

Partial Class frm_weaving_looms
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
    Dim order_no, order_qty, location As String

    Protected Sub cmdFetch_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        'Dim Sqlpass As String
        Dim constr As String = System.Web.Configuration.WebConfigurationManager.ConnectionStrings("misjctdev").ConnectionString
        Dim cn As SqlConnection = New SqlConnection(constr)

        sqlpass = "exec jct_pp_weaving_looms    "
        Dim cmd As SqlCommand = New SqlCommand(sqlpass, cn)
        cmd.CommandTimeout = 0
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()
        'obj2.FillGrid(sqlpass, grdGrid)
        sqlpass = ""
        BindData1()
        'Me.grdGrid1.SelectedIndex = -1

    End Sub

    Protected Sub cmdclose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdclose.Click
        Response.Redirect("default.aspx")
        Me.Visible = False
    End Sub


    'Protected Sub cmdDetailView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdDetailView.Click
    '    BindData()
    'End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Protected Sub grdGrid1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdGrid1.SelectedIndexChanged
        'Session("sql") = ""
        ''Session("sql") = "select fs_stock_no as [Stock No.],fs_stock_variant [Variant],Price,convert(varchar(12),fs_tran_Date) as [Tran Date],current_mkt_price as [Current Mkt Price],convert(varchar(12),purchase_date) as [Current Mkt Price Date],fs_uom as [UOM],vendor_no as [Vendor No.],vendor_name as [Vendor Name],account_no as [Account No.] from  jct_cst_raw_material_price_master where status<>'D' and fs_stock_no='" & grdGrid.SelectedRow.Cells(1).Text & "' and fs_stock_variant='" & grdGrid.SelectedRow.Cells(2).Text & "' and company_code='" & Session("Companycode") & "' order by fs_stock_no "
        'Session("sql") = "select order_no as [order_no],date [Order date],location [Location],sales_person [SalesPerson],sort_no [sort No],order_qty [Order Qty],required_date as [Need Date],planned_qty [Planned Qty],wvg_qty [Wvg Qty],balance [Balance Qty] from jct_pp_fetch_sorts where status not in ('D') order by order_no  "
        'scrpt_str = "<script language='javascript'>window.opener=null;window.open('','_top'); window.open('\popup.aspx','','height=205 width= 360, status=yes, resizable= no, scrollbars= yes, toolbar= no,location= 0, menubar= no'); </script> "

    End Sub

    ' Protected Sub grdGrid_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles grdGrid.Sorting
    'Dim ds As DataSet = New DataSet
    ' obj.opencn()
    'Dim Sqlpass = "select order_no,convert(datetime,convert(varchar(12),Date)),location,sales_person,sort_no ,order_qty,convert(datetime,convert(varchar(12),required_date)),planned_qty, wvg_qty,balance from jct_pp_fetch_sorts where where status<>'D' and monthyr='" & yrmth.Text & "' order by location,order_no "
    'Dim Da As SqlDataAdapter = New SqlDataAdapter(Sqlpass, obj.cn)
    '   Da.Fill(ds)
    '  grdGrid.DataSource = ds
    ' grdGrid.DataBind()
    'Dim dv As DataView = New DataView(ds.Tables(0))
    '   dv.Sort = e.SortExpression & " ASC"
    '  grdGrid.DataSource = dv
    ' grdGrid.DataBind()
    'End Sub

    'Public Sub BindData()
    'If CheckBox1.Checked = True Then
    '  sqlpass = "select monthyr as [Month Year],sort_no as [Sort No],location as [Location],sum(order_qty) as 'Total qty' from jct_pp_fetch_sorts where monthyr = '" & yrmth.Text & "'  and  selected = 'Y' group by  monthyr,sort_no,location order by sort_no "
    'Else
    '   sqlpass = "select monthyr as [Month Year],sort_no as [Sort No],location as [Location],sum(order_qty) as 'Total qty' from jct_pp_fetch_sorts where monthyr = '" & yrmth.Text & "'  and  selected = 'Y' group by  monthyr,sort_no,location and status<>'D' order by location,sort_no"
    'End If
    ' CstModule.FillGrid(sqlpass, grdGrid1)

    ' select monthyr,sort_no,location,sum(order_qty) as 'Total qty'
    'from(jct_pp_fetch_sorts)
    'where monthyr = '201010'
    'and   selected = 'Y'
    'group by  monthyr,sort_no,location
    'order by location,sort_no
    'End Sub

    'for show paging no in grid result 
    Protected Sub grdGrid1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdGrid1.PageIndexChanging
        'Dim Sqlpass As String
        'Sqlpass = "SELECT section_code,loom_no,loom_size,sort_no,day1,day2,day3,day4,day5,day6,day7,day8,day9,day10,day11,day12,day13,day14,day15,day16,day17,day18,day19,day20,day21,day22,day23,day24,day25,day26,day27,day28,day29,day30,day31   FROM jct_pp_shed_wise_looms_available where monthyr = '" & yrmth.Text & "' and  ( (location = '" & ddlshed.Text & "' or '" & ddlshed.Text & "' = 'ALL') order by shed,loom_no "
        'obj2.FillGrid(Sqlpass, grdGrid1)
        grdGrid1.PageIndex = e.NewPageIndex
        BindData1()
        'Me.grdGrid1.SelectedIndex = -1
    End Sub

    ' grdGrid.PageIndex = e.NewPageIndex
    ' BindData1()
    'Me.grdGrid.SelectedIndex = -1
    'End Sub
    'Protected Sub grdGrid1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdGrid1.PageIndexChanging
    '    grdGrid1.PageIndex = e.NewPageIndex
    '    BindData()
    '    Me.grdGrid1.SelectedIndex = -1
    'End Sub

    'Public Sub BindData1()
    '    'If CheckBox1.Checked = True Then
    '    Dim Sqlpass As String
    '    'sqlpass = "exec jct_pp_data_fetch '" & yrmth.Text & "', '" & ddlrfb.Text & "'"
    '    Sqlpass = "SELECT order_no,convert(varchar(11),date,101) as 'date',location,sales_person ,sort_no ,order_qty ,convert(varchar(11),required_date,101)as 'required_date', planned_qty ,wvg_qty ,balance  FROM jct_pp_fetch_sorts  where monthyr = '" & yrmth.Text & "' and  order_location = '" & ddlrfb.Text & "'  and status <> 'D'  order by order_no "
    '    'sqlpass = "select monthyr as [Month Year],sort_no as [Sort No],location as [Location],sum(order_qty) as 'Total qty' from jct_pp_fetch_sorts where monthyr = '" & yrmth.Text & "'  and  selected = 'Y' group by  monthyr,sort_no,location order by sort_no "
    '    'Else
    '    '   sqlpass = "select monthyr as [Month Year],sort_no as [Sort No],location as [Location],sum(order_qty) as 'Total qty' from jct_pp_fetch_sorts where monthyr = '" & yrmth.Text & "'  and  selected = 'Y' group by  monthyr,sort_no,location and status<>'D' order by location,sort_no"
    '    'End If
    '    CstModule.FillGrid(Sqlpass, grdGrid)
    'End Sub

    'Public Sub shed()
    '    Dim SqlPass As String = "SELECT DISTINCT shed from jct_pp_shed_wise_looms_available where monthyr =  '" & yrmth.Text & "' order by shed "

    '    Dim Dr As SqlDataReader = obj.FetchReader(SqlPass)
    '    Try
    '        If Dr.HasRows = True Then
    '            Me.ddlshed.Items.Clear()
    '            ddlshed.Items.Add("ALL")
    '            While Dr.Read()
    '                If Not (Dr.Item(0) Is System.DBNull.Value) Then
    '                    Me.ddlshed.Items.Add(Trim(Dr.Item(0)))
    '                End If
    '            End While
    '        Else
    '        End If
    '    Catch ex As Exception
    '    Finally
    '        obj.ConClose()
    '    End Try

    'End Sub

    'Protected Sub yrmth_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles yrmth.TextChanged
    '    shed()
    'End Sub
    Public Sub BindData1()
        Dim Sqlpass As String
        Sqlpass = "SELECT shed 'Shed',loom_no 'Loom No',loom_size 'Loom Size' FROM jct_pp_weaving_working_looms where (shed = '" & ddlshed.Text & "' or '" & ddlshed.Text & "' = 'ALL') order by shed "
        CstModule.FillGrid(Sqlpass, grdGrid1)
    End Sub
    'Protected Sub cmdexcel1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdexcel1.Click
    '    'Try
    '    GridViewExportUtil.Export("planning.xls", Me.grdGrid1)
    '    'Catch ex As Exception

    '    'MsgBox(ex.Message)
    '    ' End Try

    'End Sub
End Class

