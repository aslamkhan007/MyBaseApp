Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.UI.DataVisualization.Charting

Partial Class frm_originwise_demage
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
    Dim TotalMtrs As Decimal = 0
    Dim FreshMtrs As Decimal = 0
    Dim DamageMtrs As Decimal = 0
    Dim DamagePer As Decimal = 0
    Dim PrpFlag As Decimal = 0
    Dim SpgFlag As Decimal = 0
    Dim WvgFlag As Decimal = 0
    Dim YrnFlag As Decimal = 0




    Protected Sub cmdFetch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdFetch.Click
        Dim constr As String = System.Web.Configuration.WebConfigurationManager.ConnectionStrings("misjctdev").ConnectionString
        Dim cn As SqlConnection = New SqlConnection(constr)

        sqlpass = "exec jct_ops_originwise_grey_damage '" & txtEffecFrom.Text & "','" & txtEffecTo.Text & "','" & ddllocation.SelectedValue & "' "
        Dim cmd As SqlCommand = New SqlCommand(sqlpass, cn)
        cmd.CommandTimeout = 0
        cn.Open()
        cmd.ExecuteNonQuery()
        sqlpass = ""
        BindData1()

    End Sub

    Protected Sub cmdclose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdclose.Click
        Response.Redirect("default.aspx")
        Me.Visible = False
    End Sub

    Protected Sub grdGrid1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdGrid1.PageIndexChanging
        grdGrid1.PageIndex = e.NewPageIndex
        BindData1()
    End Sub

    Public Sub BindData1()
        Dim Sqlpass As String
        Sqlpass = "select sortno,convert(numeric(8),total_mtrs)'TotalMtrs',convert(numeric(8),fresh_mtrs)'FreshMtrs',convert(numeric(5),damage_mtrs)'DamageMtrs',convert(numeric(6,2),damage_per)'Damage%',convert(varchar(8),location)'Location',convert(numeric(6),prp)'Prp.Flag',convert(numeric(6),spg)'SPG.Flag',convert(numeric(6),wvg)'Wvg.Flag', convert(numeric(6),YRN)'Yrn.Flag'  from jct_ops_grey_damage where location = '" & ddllocation.SelectedValue & "' order by sortno"
        obj2.FillGrid(Sqlpass, grdGrid1)
    End Sub
    Protected Sub cmdexcel1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdexcel1.Click
        GridViewExportUtil.Export("Originwise_Grey_Damage.xls", Me.grdGrid1)
    End Sub

    'Protected Sub PopulateBarChart(ByVal sql As String, ByRef chart As Chart)
    '    Try
    '        chart.Series("Series1").ChartType = SeriesChartType.Column

    '        chart.Titles(0).Text = "Total Expenses"

    '        ' Set point width of the series
    '        chart.Series("Series1")("PointWidth") = "0.2"

    '        ' Set drawing style
    '        chart.Series("Series1")("DrawingStyle") = "Cylinder"


    '        chart.Series("Series1")("ShowMarkerLines") = "True"

    '        chart.Series("Series1").BorderWidth = 1

    '        chart.Series("Series1").MarkerStyle = MarkerStyle.None

    '        cmd = New SqlCommand(sql, obj.Connection)
    '        Dim SqlReader As SqlDataReader = cmd.ExecuteReader()
    '        Dim ds1 As DataSet = New DataSet
    '        ds1.Tables.Add()
    '        ds1.Load(SqlReader, LoadOption.OverwriteChanges, ds1.Tables(0))
    '        chart.DataSource = ds1

    '        chart.Series("Series1").XValueMember = ds1.Tables(0).Columns(1).Caption
    '        chart.Series("Series1").YValueMembers = ds1.Tables(0).Columns(0).Caption
    '        chart.DataBind()
    '    Catch ex As Exception
    '        MsgBox("Exception")
    '    Finally
    '        obj.ConClose()
    '    End Try

    'End Sub

    'Protected Sub lnkchart_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkchart.Click
    '    pnlChart.Visible = True
    '    sql = " SELECT  sum(tot_exp) as total,empname FROM jct_ops_ta_bills where date between '" & txtEffecFrom.Text & "' AND '" & txtEffecTo.Text & "' and (location =  '" & ddllocation.Text & "' or '" & ddllocation.Text & "' = ' ') and (ccdescrp =  '" & ddlcostcenter.Text & "' or '" & ddlcostcenter.Text & "' = ' ') and (empname =  '" & ddlemployee.Text & "' or '" & ddlemployee.Text & "' = ' ') group by empname"
    '    PopulateBarChart(sql, Chart1)
    'End Sub

    Protected Sub grdGrid1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdGrid1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            TotalMtrs = TotalMtrs + Decimal.Parse(e.Row.Cells(1).Text)
            FreshMtrs = FreshMtrs + Decimal.Parse(e.Row.Cells(2).Text)
            DamageMtrs = DamageMtrs + Decimal.Parse(e.Row.Cells(3).Text)
            DamagePer = Math.Round(((DamageMtrs * 100) / TotalMtrs), 2)
            PrpFlag = PrpFlag + Decimal.Parse(e.Row.Cells(6).Text)
            SpgFlag = SpgFlag + Decimal.Parse(e.Row.Cells(7).Text)
            WvgFlag = WvgFlag + Decimal.Parse(e.Row.Cells(8).Text)
            YrnFlag = YrnFlag + Decimal.Parse(e.Row.Cells(9).Text)

        ElseIf e.Row.RowType = DataControlRowType.Footer Then
            e.Row.Cells(0).Text = "Total"
            e.Row.Cells(1).Text = TotalMtrs
            e.Row.Cells(2).Text = FreshMtrs
            e.Row.Cells(3).Text = DamageMtrs
            e.Row.Cells(4).Text = DamagePer
            e.Row.Cells(6).Text = PrpFlag
            e.Row.Cells(7).Text = SpgFlag
            e.Row.Cells(8).Text = WvgFlag
            e.Row.Cells(9).Text = YrnFlag

        End If
    End Sub
End Class

