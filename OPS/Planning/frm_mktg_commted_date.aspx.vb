Imports System.Data
Imports System.Data.SqlClient
Partial Class frm_mktg_commted_date
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

    Protected Sub cmdFetch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdFetch.Click
        'Dim Sqlpass As String
        Dim constr As String = System.Web.Configuration.WebConfigurationManager.ConnectionStrings("misjctdev").ConnectionString
        Dim cn As SqlConnection = New SqlConnection(constr)

        sqlpass = "exec jct_ops_pp_tentative_commitment_date '" & txtsort.Text & "', " & txtqty.Text & " ,'" & ddllocation.SelectedItem.Text & "','" & ddlshed.SelectedItem.Text & "', " & txtlooms.Text & " , " & txtprocdays.Text & "  "
        Dim cmd As SqlCommand = New SqlCommand(sqlpass, cn)
        'cmd.CommandTimeout = 0
        'cn.Open()
        'cmd.ExecuteNonQuery()
        Dim Dr As SqlDataReader = obj.FetchReader(sqlpass)
        Dr.Read()
        If Dr.HasRows = True Then
            FMsg.CssClass = "errormsg"
            FMsg.Message = ".   "
            FMsg.Display()
        Else
            FMsg.CssClass = "errormsg"
            FMsg.Message = "Perticular not prepared for this Shed"
            FMsg.Display()
        End If
        cn.Close()
        sqlpass = ""
        BindData1()
        'Me.grdGrid1.SelectedIndex = -1

    End Sub

    Protected Sub cmdclose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdclose.Click
        Response.Redirect("default.aspx")
        Me.Visible = False
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'yearmonth()
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
        Sqlpass = "SELECT ordersort 'Sort No',shed 'Shed',convert(numeric(12),orderqty) 'Qty',convert(numeric(12), planqty) 'Plan Freeze',convert(numeric(8,2),days) 'Days',weaving_date 'Weaving Dt',despatch_date 'Commeted Dt',shrinkage 'Sizing%',convert(numeric(12),sizing_length) 'Sizing Length',convert(numeric(8,2),prod_shift) 'Prod/Day',convert(numeric(6,2),looms) 'Looms Alloted',  proc_days 'Process Days',convert(numeric(8),wvgqty) 'Wvg.Prod.' FROM jct_pp_mktg_commt_date  where host_id  = host_id() and ordersort = '" & txtsort.Text & "' and  location = '" & ddllocation.SelectedItem.Text & "'"
        CstModule.FillGrid(Sqlpass, grdGrid1)
    End Sub
    Protected Sub cmdexcel1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdexcel1.Click
        'Try
        GridViewExportUtil.Export("text.xls", Me.grdGrid1)
        'Catch ex As Exception

        'MsgBox(ex.Message)
        ' End Try

    End Sub

    Protected Sub txtsort_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtsort.TextChanged
        SetFocus(txtqty)
    End Sub

    Protected Sub txtqty_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtqty.TextChanged
        SetFocus(txtlooms)
    End Sub

    Protected Sub txtlooms_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtlooms.TextChanged
        SetFocus(txtprocdays)
    End Sub

    Protected Sub ddlshed_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlshed.TextChanged
        SetFocus(txtqty)
    End Sub

    'Public Sub plant()
    '    'Dim SqlPass As String = "SELECT DISTINCT section_code from jct_pp_shed_wise_looms_available where monthyr =  '" & Right(ddlyrmth.Text, 6) & "' order by section_code "
    '    Dim SqlPass As String = "select distinct location from dbo.JCT_OPS_MONTHLY_PLANNING where yearmonth = '" & Right(ddlyrmth.Text, 6) & "' order by location "

    '    Dim Dr As SqlDataReader = obj.FetchReader(SqlPass)
    '    Try
    '        If Dr.HasRows = True Then
    '            Me.ddllocation.Items.Clear()
    '            ' ddlshed.Items.Add("ALL")
    '            While Dr.Read()
    '                If Not (Dr.Item(0) Is System.DBNull.Value) Then
    '                    Me.ddllocation.Items.Add(Trim(Dr.Item(0)))
    '                End If
    '            End While
    '        Else
    '        End If
    '    Catch ex As Exception
    '    Finally
    '        obj.ConClose()
    '    End Try

    'End Sub

    'Public Sub yearmonth()
    '    sqlpass = "select distinct yearmonth from dbo.JCT_OPS_MONTHLY_PLANNING order by yearmonth"
    '    Dim Dr As SqlDataReader = obj.FetchReader(sqlpass)
    '    Try
    '        If Dr.HasRows = True Then
    '            Me.ddlyrmth.Items.Clear()
    '            'ddlrevision.Items.Add("ALL")
    '            While Dr.Read()
    '                If Not (Dr.Item(0) Is System.DBNull.Value) Then
    '                    Me.ddlyrmth.Items.Add(Trim(Dr.Item(0)))
    '                End If
    '            End While
    '        Else
    '        End If
    '    Catch ex As Exception
    '    Finally
    '        obj.ConClose()
    '        Dr.Close()
    '    End Try
    '    'CstModule.FillGrid(sqlpass, grdGrid1)
    'End Sub

    'Protected Sub ddlyrmth_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlyrmth.SelectedIndexChanged
    '    plant()
    'End Sub
End Class

