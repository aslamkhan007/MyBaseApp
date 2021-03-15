Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.UI.DataVisualization.Charting

Partial Class frm_act_trav_bills
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
        Dim constr As String = System.Web.Configuration.WebConfigurationManager.ConnectionStrings("misjctdev").ConnectionString
        Dim cn As SqlConnection = New SqlConnection(constr)
        sqlpass = "exec jct_ops_act_tabill '" & txtEffecFrom.Text & "','" & txtEffecTo.Text & "' "
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

    Protected Sub grdGrid1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdGrid1.RowDataBound

        If e.Row.RowType = DataControlRowType.DataRow Then
            sum = sum + Decimal.Parse(e.Row.Cells(11).Text)

        ElseIf e.Row.RowType = DataControlRowType.Footer Then
            e.Row.Cells(10).Text = "Total"
            e.Row.Cells(11).Text = sum / 2

        End If

    End Sub
  
    Protected Sub grdGrid1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdGrid1.PageIndexChanging
        grdGrid1.PageIndex = e.NewPageIndex
        BindData1()
    End Sub

    Public Sub BindData1()
        Dim Sqlpass As String
        Sqlpass = "SELECT distinct empname 'Name',desg 'Designation',ccdescrp 'CostCenter', convert(varchar(10),date,103) 'Date', travel_days 'TravlDays',visit 'VisitStation', trav_exp 'TravlExp', trav_fare 'TravlFare',hotl_chg 'HotalExp',oth_exp 'OtherExp',locl_conv 'LocalExp',tot_exp 'TotalExp' FROM jct_ops_ta_bills where date between '" & txtEffecFrom.Text & "' AND '" & txtEffecTo.Text & "' and (location =  '" & ddllocation.Text & "' or '" & ddllocation.Text & "' = ' ') and (ccdescrp =  '" & ddlcostcenter.Text & "' or '" & ddlcostcenter.Text & "' = ' ') and  (empname =  '" & ddlemployee.Text & "' or '" & ddlemployee.Text & "' = ' ') "
        obj2.FillGrid(Sqlpass, grdGrid1)
    End Sub
    Protected Sub cmdexcel1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdexcel1.Click
        GridViewExportUtil.Export("travel_exp.xls", Me.grdGrid1)
    End Sub
    Public Sub plantlocation()
        Dim SqlPass As String = "select distinct location from jct_ops_ta_bills where date between '" & txtEffecFrom.Text & "' AND '" & txtEffecTo.Text & "' order by location "
        Dim Dr As SqlDataReader = obj.FetchReader(SqlPass)
        Try
            If Dr.HasRows = True Then
                Me.ddllocation.Items.Clear()
                ddllocation.Items.Add(" ")
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
        End Try

    End Sub
    Public Sub costcenter()
        'Dim SqlPass As String = "select distinct ccdescrp from jct_ops_ta_bills where date between '" & txtEffecFrom.Text & "' AND '" & txtEffecTo.Text & "' order by ccdescrp "
        If ddllocation.SelectedItem.Text = "" Then
            sqlpass = "select distinct ccdescrp from jct_ops_ta_bills where date between '" & txtEffecFrom.Text & "' AND '" & txtEffecTo.Text & "' order by ccdescrp "
        Else
            sqlpass = "select distinct ccdescrp from jct_ops_ta_bills where date between '" & txtEffecFrom.Text & "' AND '" & txtEffecTo.Text & "' and location = '" & ddllocation.SelectedItem.Text & "' order by ccdescrp "
        End If

        Dim Dr As SqlDataReader = obj.FetchReader(sqlpass)
        Try
            If Dr.HasRows = True Then
                Me.ddlcostcenter.Items.Clear()
                ddlcostcenter.Items.Add(" ")
                While Dr.Read()
                    If Not (Dr.Item(0) Is System.DBNull.Value) Then
                        Me.ddlcostcenter.Items.Add(Trim(Dr.Item(0)))
                    End If
                End While
            Else
            End If
        Catch ex As Exception
        Finally
            obj.ConClose()
        End Try


    End Sub

    Public Sub employeename()
        'Dim SqlPass As String = "select distinct empname from jct_ops_ta_bills where date between '" & txtEffecFrom.Text & "' AND '" & txtEffecTo.Text & "' and (ccdescrp =  '" & ddlcostcenter.Text & "' or '" & ddlcostcenter.Text & "' = ' ') order by empname"
        If ddllocation.SelectedItem.Value = " " And ddlcostcenter.SelectedItem.Value = " " Then
            sqlpass = "select distinct empname from jct_ops_ta_bills order by empname "
        Else
            If ddllocation.SelectedItem.Value <> " " And ddlcostcenter.SelectedItem.Value <> " " Then
                sqlpass = "select distinct empname from jct_ops_ta_bills where location =  '" & ddllocation.SelectedItem.Text & "'  and ccdescrp =  '" & ddlcostcenter.Text & "'  order by empname "
            Else
                If ddllocation.SelectedItem.Value <> " " And ddlcostcenter.SelectedItem.Value = " " Then
                    sqlpass = "select distinct empname from jct_ops_ta_bills where location =  '" & ddllocation.SelectedItem.Text & "' order by empname "
                End If
            End If
        End If


        Dim Dr As SqlDataReader = obj.FetchReader(sqlpass)
        Try
            If Dr.HasRows = True Then
                Me.ddlemployee.Items.Clear()
                ddlemployee.Items.Add(" ")
                While Dr.Read()
                    If Not (Dr.Item(0) Is System.DBNull.Value) Then
                        Me.ddlemployee.Items.Add(Trim(Dr.Item(0)))
                    End If
                End While
            Else
            End If
        Catch ex As Exception
        Finally
            obj.ConClose()
        End Try

    End Sub

    Protected Sub ddlcostcenter_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlcostcenter.SelectedIndexChanged
        employeename()
    End Sub

    Protected Sub txtEffecTo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEffecTo.TextChanged
        plantlocation()
    End Sub
    Protected Sub PopulateBarChart(ByVal sql As String, ByRef chart As Chart)
        Try
            chart.Series("Series1").ChartType = SeriesChartType.Column

            chart.Titles(0).Text = "Total Expenses"

            ' Set point width of the series
            chart.Series("Series1")("PointWidth") = "0.2"
         
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

            chart.Series("Series1").XValueMember = ds1.Tables(0).Columns(1).Caption
            chart.Series("Series1").YValueMembers = ds1.Tables(0).Columns(0).Caption
            chart.DataBind()
        Catch ex As Exception
            MsgBox("Exception")
        Finally
            obj.ConClose()
        End Try

    End Sub

    Protected Sub lnkchart_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkchart.Click
        pnlChart.Visible = True
        sql = " SELECT distinct  sum(tot_exp) as total,empname FROM jct_ops_ta_bills where date between '" & txtEffecFrom.Text & "' AND '" & txtEffecTo.Text & "' and (location =  '" & ddllocation.Text & "' or '" & ddllocation.Text & "' = ' ') and (ccdescrp =  '" & ddlcostcenter.Text & "' or '" & ddlcostcenter.Text & "' = ' ') and (empname =  '" & ddlemployee.Text & "' or '" & ddlemployee.Text & "' = ' ') group by empname"
        PopulateBarChart(sql, Chart1)
    End Sub

    Protected Sub ddllocation_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddllocation.SelectedIndexChanged
        costcenter()
    End Sub

    'Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    '    If Not IsPostBack Then





    '    End If
    'End Sub
End Class

