Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.UI.DataVisualization.Charting
Imports System.Drawing
Partial Class frm_raw_material_cost
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
    Dim sum As Decimal = 0

    Protected Sub cmdFetch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdFetch.Click
        'Dim Sqlpass As String
        Dim constr As String = System.Web.Configuration.WebConfigurationManager.ConnectionStrings("misjctdev").ConnectionString
        Dim cn As SqlConnection = New SqlConnection(constr)

        sqlpass = "exec jct_ops_pp_raw_material_valuation  '" & Right(ddlyrmth.Text, 6) & "','" & ddllocation.SelectedItem.Text & "'"
        Dim cmd As SqlCommand = New SqlCommand(sqlpass, cn)
        cmd.CommandTimeout = 0
        cn.Open()
        cmd.ExecuteNonQuery()
        'cn.Close()
        'obj2.FillGrid(sqlpass, grdGrid)
        sqlpass = ""
        BindData1()
    End Sub

    Protected Sub cmdclose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdclose.Click
        Response.Redirect("default.aspx")
        Me.Visible = False
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            yearmonth()
            plant()
            sale_team()
        End If
    End Sub

    Protected Sub grdGrid1_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdGrid1.RowCreated
        'e.Row.Cells(2).Width = "1000px"
    End Sub
    Protected Sub grdGrid1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdGrid1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            sum = sum + Decimal.Parse(e.Row.Cells(5).Text)
        ElseIf e.Row.RowType = DataControlRowType.Footer Then
            e.Row.Cells(4).Text = "Total"
            e.Row.Cells(5).Text = sum / 2
        End If
    End Sub
    Protected Sub grdGrid1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdGrid1.SelectedIndexChanged
        'Session("sql") = ""
        ''Session("sql") = "select fs_stock_no as [Stock No.],fs_stock_variant [Variant],Price,convert(varchar(12),fs_tran_Date) as [Tran Date],current_mkt_price as [Current Mkt Price],convert(varchar(12),purchase_date) as [Current Mkt Price Date],fs_uom as [UOM],vendor_no as [Vendor No.],vendor_name as [Vendor Name],account_no as [Account No.] from  jct_cst_raw_material_price_master where status<>'D' and fs_stock_no='" & grdGrid.SelectedRow.Cells(1).Text & "' and fs_stock_variant='" & grdGrid.SelectedRow.Cells(2).Text & "' and company_code='" & Session("Companycode") & "' order by fs_stock_no "
    End Sub

    'for show paging no in grid result 
    Protected Sub grdGrid1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdGrid1.PageIndexChanging
        grdGrid1.PageIndex = e.NewPageIndex
        BindData1()
        'Me.grdGrid1.SelectedIndex = -1
    End Sub

    Public Sub BindData1()
        Dim Sqlpass As String
        'Sqlpass = "SELECT team_code 'TeamName',order_no 'orderNo',item_no 'ItemNo', convert(char(10),req_dt,103) 'NeedDt',plan_qty 'Qty',raw_amount 'RawMatrialCost' FROM  jct_ops_pp_raw_mat_cost  where host_id  = host_id() and (location = '" & ddllocation.SelectedItem.Text & "' or '" & ddllocation.SelectedItem.Text & "' = ' ') and  ( team_code = '" & ddlsaleteam.SelectedItem.Text & "' or '" & ddlsaleteam.SelectedItem.Text & "' = ' ') "
        Sqlpass = "SELECT team_code 'TeamName',order_no 'orderNo',item_no 'ItemNo', convert(char(10),req_dt,103) 'NeedDt',plan_qty 'Qty(mtrs)',raw_amount 'RawMatrialCost' FROM  jct_ops_pp_raw_mat_cost  where yearmonth =  '" & Right(ddlyrmth.Text, 6) & "' and  (location = '" & ddllocation.SelectedItem.Text & "' or '" & ddllocation.SelectedItem.Text & "' = ' ') and  ( team_code = '" & ddlsaleteam.SelectedItem.Text & "' or '" & ddlsaleteam.SelectedItem.Text & "' = ' ') order by team_code"
        CstModule.FillGrid(Sqlpass, grdGrid1)
    End Sub
    Protected Sub cmdexcel1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdexcel1.Click
        'Try
        GridViewExportUtil.Export("raw_material_cost.xls", Me.grdGrid1)
        'Catch ex As Exception

        'MsgBox(ex.Message)
        ' End Try

    End Sub
    Public Sub sale_team()
        If ddllocation.SelectedItem.Text <> "" Then
            '    sqlpass = "select distinct team_code from dbo.JCT_OPS_MONTHLY_PLANNING  where yearmonth =  '" & Right(ddlyrmth.Text, 6) & "' and status  is null AND mode = 'Freezed' order by team_code "
            'Else
            sqlpass = "select distinct team_code from dbo.JCT_OPS_MONTHLY_PLANNING  where yearmonth =  '" & Right(ddlyrmth.Text, 6) & "' and (location = '" & ddllocation.SelectedItem.Text & "') and status is null and mode = 'Freezed' order by team_code "
        End If

        Dim Dr As SqlDataReader = obj.FetchReader(sqlpass)
        Try
            If Dr.HasRows = True Then
                Me.ddlsaleteam.Items.Clear()
                ddlsaleteam.Items.Add(" ")
                While Dr.Read()
                    If Not (Dr.Item(0) Is System.DBNull.Value) Then
                        Me.ddlsaleteam.Items.Add(Trim(Dr.Item(0)))
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
    Public Sub plant()
        sqlpass = "select distinct location from dbo.JCT_OPS_MONTHLY_PLANNING  where yearmonth =  '" & Right(ddlyrmth.Text, 6) & "' AND mode = 'Freezed'  order by location "
        Dim Dr As SqlDataReader = obj.FetchReader(sqlpass)
        Try
            If Dr.HasRows = True Then
                Me.ddllocation.Items.Clear()
                'ddllocation.Items.Add("")
                While Dr.Read()
                    If Not (Dr.Item(0) Is System.DBNull.Value) Then
                        Me.ddllocation.Items.Add(Trim(Dr.Item(0)))
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

    Public Sub yearmonth()
        sqlpass = "select distinct yearmonth from dbo.JCT_OPS_MONTHLY_PLANNING where mode = 'Freezed'  order by yearmonth"
        Dim Dr As SqlDataReader = obj.FetchReader(sqlpass)
        Try
            If Dr.HasRows = True Then
                Me.ddlyrmth.Items.Clear()
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
            Dr.Close()
        End Try
        'CstModule.FillGrid(sqlpass, grdGrid1)
    End Sub

    Protected Sub ddllocation_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddllocation.SelectedIndexChanged
        sale_team()
    End Sub
    'graph query 
    'SELECT team_code 'TeamName', raw_amount 'RawMatrialCost' FROM  jct_ops_pp_raw_mat_cost where ( team_code = '" & ddlsaleteam.SelectedItem.Text & "' or '" & ddlsaleteam.SelectedItem.Text & "' = ' ')

    Protected Sub PopulateBarChart(ByVal sql As String, ByRef chart As Chart)
        Try
            chart.Series("Series1").ChartType = SeriesChartType.Column

            chart.Titles(0).Text = "Check your Dispatch Date"

            ' Set point width of the series
            chart.Series("Series1")("PointWidth") = "0.3"

            ' Set drawing style
            chart.Series("Series1")("DrawingStyle") = "Cylinder"



            chart.Series("Series1")("ShowMarkerLines") = "True"

            chart.Series("Series1").BorderWidth = 1

            chart.Series("Series1").MarkerStyle = MarkerStyle.None


            cmd = New SqlCommand(sql, obj.Connection)
            Dim SqlReader As SqlDataReader = cmd.ExecuteReader()
            Dim ds1 As DataSet = New DataSet
            ds1.Tables.Add()
            ds1.Load(SqlReader, LoadOption.OverwriteChanges, ds1.Tables(0))
            chart.DataSource = ds1

            chart.Series("Series1").XValueMember = ds1.Tables(0).Columns(0).Caption
            chart.Series("Series1").YValueMembers = ds1.Tables(0).Columns(1).Caption
            chart.ChartAreas("ChartArea1").AxisX.Title = "Sale Team "

            chart.ChartAreas("ChartArea1").AxisX.TitleFont = New Font("Times New Roman", 12, FontStyle.Bold)
            ' chart.ChartAreas("Area1").AxisX.ForeColor = System.ConsoleColor.Black


            chart.ChartAreas("ChartArea1").AxisY.Title = "Raw Material Cost"
            chart.ChartAreas("ChartArea1").AxisX.TitleFont = New Font("Times New Roman", 12, FontStyle.Bold)
            chart.DataBind()
        Catch ex As Exception
            MsgBox("Exception")
        Finally
            obj.ConClose()
        End Try

    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        sql = "SELECT team_code 'TeamName', Sum(raw_amount) 'RawMatrialCost' FROM  jct_ops_pp_raw_mat_cost where ( team_code = '" & ddlsaleteam.SelectedItem.Text & "' or '" & ddlsaleteam.SelectedItem.Text & "' = '') group by team_code"
        ' sql = "jct_ops_check_dispatch_schedule 'V-04328'"

        PopulateBarChart(sql, Chart1)
    End Sub

    Protected Sub ddlyrmth_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlyrmth.SelectedIndexChanged
        plant()
        sale_team()
    End Sub
End Class

