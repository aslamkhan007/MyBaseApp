Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.UI.DataVisualization.Charting

Partial Class frm_new_sale_tpm
    Inherits System.Web.UI.Page
    Dim sql As String
    Dim dr As SqlDataReader
    Dim cmd As SqlCommand
    Dim obj As New MiserpCon
    Dim obj2 As New Functions
    Dim sqlpass, sno2 As String
    Dim scrpt_str As String
    Dim Ash, sno1 As Integer
    Public CstModule As New CostModule
    Dim order_no, order_qty, location As String
    Dim suma1 As Decimal = 0, suma2 As Decimal = 0, suma3 As Decimal = 0, suma4 As Decimal = 0, suma5 As Decimal = 0, suma6 As Decimal = 0
    Dim sumb1 As Decimal = 0, sumb2 As Decimal = 0, sumb3 As Decimal = 0, sumb4 As Decimal = 0, sumb5 As Decimal = 0, sumb6 As Decimal = 0
    Dim sumc1 As Decimal = 0, sumc2 As Decimal = 0, sumc3 As Decimal = 0, sumc4 As Decimal = 0, sumc5 As Decimal = 0, sumc6 As Decimal = 0
    Dim sumd1 As Decimal = 0, sumd2 As Decimal = 0, sumd3 As Decimal = 0, sumd4 As Decimal = 0, sumd5 As Decimal = 0, sumd6 As Decimal = 0
    Dim sume1 As Decimal = 0, sume2 As Decimal = 0, sume3 As Decimal = 0, sume4 As Decimal = 0, sume5 As Decimal = 0, sume6 As Decimal = 0
    Dim sumf1 As Decimal = 0, sumf2 As Decimal = 0, sumf3 As Decimal = 0, sumf4 As Decimal = 0, sumf5 As Decimal = 0, sumf6 As Decimal = 0
    Dim sumg1 As Decimal = 0, sumg2 As Decimal = 0, sumg3 As Decimal = 0, sumg4 As Decimal = 0, sumg5 As Decimal = 0, sumg6 As Decimal = 0
    Dim sumh1 As Decimal = 0, sumh2 As Decimal = 0, sumh3 As Decimal = 0, sumh4 As Decimal = 0, sumh5 As Decimal = 0, sumh6 As Decimal = 0
    Dim sumi1 As Decimal = 0, sumi2 As Decimal = 0, sumi3 As Decimal = 0, sumi4 As Decimal = 0, sumi5 As Decimal = 0, sumi6 As Decimal = 0
    Dim constr As String = System.Web.Configuration.WebConfigurationManager.ConnectionStrings("shpConnectionString").ConnectionString



    Protected Sub cmdFetch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdFetch.Click
        'Dim constr As String = System.Web.Configuration.WebConfigurationManager.ConnectionStrings("misjctdev").ConnectionString
        Dim cn As SqlConnection = New SqlConnection(constr)

        sqlpass = "exec jct_ops_tpm_new_test1 'JCT00LTD','PHG',1 ,'" & txtEffecFrom.Text & "','" & txtEffecTo.Text & "','" & ddlgroup.SelectedItem.Text & "' "
        Dim cmd As SqlCommand = New SqlCommand(sqlpass, cn)
        cmd.CommandTimeout = 0
        cn.Open()
        cmd.ExecuteNonQuery()
        sqlpass = ""

        If ddloutput.SelectedItem.Value = "Report" And ddlgroup.SelectedItem.Value = "" Then
            grdGrid1.Visible = True

            BindData1()

            grdGrid2.Visible = False
            grdGrid3.Visible = False
            grdGrid4.Visible = False
            grdGrid5.Visible = False
            grdGrid6.Visible = False
            grdGrid7.Visible = False
            grdGrid8.Visible = False
            grdGrid9.Visible = False

        ElseIf ddloutput.SelectedItem.Value = "Report" And ddlgroup.SelectedItem.Value = "Cotton" Then
            grdGrid1.Visible = True
            grdGrid2.Visible = True
            grdGrid3.Visible = True
            grdGrid4.Visible = True
            grdGrid5.Visible = True
            grdGrid6.Visible = True
            grdGrid7.Visible = True
            grdGrid8.Visible = True
            grdGrid9.Visible = True

            BindData1()
            BindData2()
            BindData3()
            BindData4()
            BindData5()
            BindData6()
            BindData7()
            BindData8()
            BindData9()
        ElseIf ddloutput.SelectedItem.Value = "Report" And ddlgroup.SelectedItem.Value = "Taffeta" Then

            grdGrid1.Visible = True
            grdGrid2.Visible = True
            grdGrid3.Visible = True
            grdGrid4.Visible = True
            grdGrid5.Visible = True

            BindData1()
            BindData2()
            BindData3()
            BindData4()
            BindData5()

            grdGrid6.Visible = False
            grdGrid7.Visible = False
            grdGrid7.Visible = False
            grdGrid8.Visible = False
            grdGrid9.Visible = False
        ElseIf ddloutput.SelectedItem.Value = "Report" And ddlgroup.SelectedItem.Value = "Others" Then

            grdGrid1.Visible = True
            grdGrid2.Visible = True
            grdGrid3.Visible = True
            grdGrid4.Visible = True

            BindData1()
            BindData2()
            BindData3()
            BindData4()

            grdGrid5.Visible = False
            grdGrid6.Visible = False
            grdGrid7.Visible = False
            grdGrid8.Visible = False
            grdGrid9.Visible = False
        ElseIf ddloutput.SelectedItem.Value = "Graph" And ddlgroup.SelectedItem.Value = "Cotton" Or ddlgroup.SelectedItem.Value = "Taffeta" Or ddlgroup.SelectedItem.Value = "Others" Then

            grdGrid1.Visible = False
            grdGrid2.Visible = False
            grdGrid3.Visible = False
            grdGrid4.Visible = False
            grdGrid5.Visible = False
            grdGrid6.Visible = False
            grdGrid7.Visible = False
            grdGrid8.Visible = False
            grdGrid9.Visible = False
        End If

    End Sub

    Protected Sub cmdclose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdclose.Click
        Response.Redirect("default.aspx")
        Me.Visible = False
    End Sub

    Protected Sub grdGrid1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdGrid1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            suma1 = suma1 + Decimal.Parse(e.Row.Cells(2).Text)
            suma2 = suma2 + Decimal.Parse(e.Row.Cells(3).Text)
            suma3 = suma3 + Decimal.Parse(e.Row.Cells(4).Text)
            suma4 = suma4 + Decimal.Parse(e.Row.Cells(5).Text)
            suma5 = suma5 + Decimal.Parse(e.Row.Cells(6).Text)
            suma6 = suma6 + Decimal.Parse(e.Row.Cells(7).Text)

        ElseIf e.Row.RowType = DataControlRowType.Footer Then
            e.Row.Cells(1).Text = "Total"
            e.Row.Cells(2).Text = suma1
            e.Row.Cells(3).Text = suma2
            e.Row.Cells(4).Text = suma3
            e.Row.Cells(5).Text = suma4
            e.Row.Cells(6).Text = suma5
            e.Row.Cells(7).Text = suma6
        End If
    End Sub

    'Protected Sub grdGrid1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdGrid1.PageIndexChanging
    '    grdGrid1.PageIndex = e.NewPageIndex
    '    BindData1()
    'End Sub

    Public Sub BindData1()
        Dim Sqlpass As String
        If ddloutput.SelectedItem.Value = "Report" And ddlgroup.SelectedItem.Value = "" Then
            Sqlpass = "select group_no_new 'Type', group_desc 'Description',  convert(numeric(6,2),today_packing)  'ToDPck', convert(numeric(6,2),todate_packing ) 'UDtPck',  convert(numeric(6,2),today_sale_qty) 'ToDspQty', convert(numeric(6,2),today_sale_amount) 'ToDspVal',  convert(numeric(6,2),todate_sale_qty) 'UDtDspQty', convert(numeric(6,2),todate_sale_amount) 'UDtdspval',  convert(numeric(6,2),avg_rate)  'AvgRate' FROM jct_ops_tpm order by sr_no2,sr_no1"
            Dim conn = New SqlConnection(constr)
            conn.Open()
            Dim cmd As SqlCommand = New SqlCommand(Sqlpass, conn)
            'cmd.ExecuteNonQuery()
            Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim ds As DataSet = New DataSet()
            da.Fill(ds)
            grdGrid1.DataSource = ds
            grdGrid1.DataBind()
            conn.Close()
        ElseIf ddloutput.SelectedItem.Value = "Report" And ddlgroup.SelectedItem.Value = "Cotton" Then
            Sqlpass = "select  group_no_new 'Type',  group_desc  'Description' , convert(numeric(6,2),today_packing)  'ToDPck', convert(numeric(6,2),todate_packing ) 'UDtPck',  convert(numeric(6,2),today_sale_qty) 'ToDspQty', convert(numeric(6,2),today_sale_amount) 'ToDspVal',  convert(numeric(6,2),todate_sale_qty) 'UDtDspQty', convert(numeric(6,2),todate_sale_amount) 'UDtdspval',  convert(numeric(6,2),avg_rate)  'AvgRate' FROM jct_ops_tpm where sr_no2  = 1 "
            Dim conn = New SqlConnection(constr)
            Dim cmd As SqlCommand = New SqlCommand(Sqlpass, conn)
            Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim ds As DataSet = New DataSet()
            da.Fill(ds)
            grdGrid1.DataSource = ds
            grdGrid1.DataBind()
        ElseIf ddloutput.SelectedItem.Value = "Report" And ddlgroup.SelectedItem.Value = "Taffeta" Then
            Sqlpass = "select group_no_new 'Type', group_desc 'Description',  convert(numeric(6,2),today_packing)  'ToDPck', convert(numeric(6,2),todate_packing ) 'UDtPck',  convert(numeric(6,2),today_sale_qty) 'ToDspQty', convert(numeric(6,2),today_sale_amount) 'ToDspVal',  convert(numeric(6,2),todate_sale_qty) 'UDtDspQty', convert(numeric(6,2),todate_sale_amount) 'UDtdspval',  convert(numeric(6,2),avg_rate)  'AvgRate' FROM jct_ops_tpm where sr_no2  = 11 "
            Dim conn = New SqlConnection(constr)
            Dim cmd As SqlCommand = New SqlCommand(Sqlpass, conn)
            Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim ds As DataSet = New DataSet()
            da.Fill(ds)
            grdGrid1.DataSource = ds
            grdGrid1.DataBind()
        ElseIf ddloutput.SelectedItem.Value = "Report" And ddlgroup.SelectedItem.Value = "Others" Then
            Sqlpass = "select group_no_new 'Type', group_desc 'Description',  convert(numeric(6,2),today_packing)  'ToDPck', convert(numeric(6,2),todate_packing ) 'UDtPck',  convert(numeric(6,2),today_sale_qty) 'ToDspQty', convert(numeric(6,2),today_sale_amount) 'ToDspVal',  convert(numeric(6,2),todate_sale_qty) 'UDtDspQty', convert(numeric(6,2),todate_sale_amount) 'UDtdspval',  convert(numeric(6,2),avg_rate)  'AvgRate' FROM jct_ops_tpm where sr_no2  = 9 "
            Dim conn = New SqlConnection(constr)
            Dim cmd As SqlCommand = New SqlCommand(Sqlpass, conn)
            Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim ds As DataSet = New DataSet()
            da.Fill(ds)
            grdGrid1.DataSource = ds
            grdGrid1.DataBind()
        End If
    End Sub
    Public Sub BindData2()
        Dim Sqlpass As String
        If ddloutput.SelectedItem.Value = "Report" And ddlgroup.SelectedItem.Value = "Cotton" Then
            Sqlpass = "select  group_no_new 'Type', group_desc 'Description',  convert(numeric(6,2),today_packing)  'ToDPck', convert(numeric(6,2),todate_packing ) 'UDtPck',  convert(numeric(6,2),today_sale_qty) 'ToDspQty', convert(numeric(6,2),today_sale_amount) 'ToDspVal',  convert(numeric(6,2),todate_sale_qty) 'UDtDspQty', convert(numeric(6,2),todate_sale_amount) 'UDtdspval',  convert(numeric(6,2),avg_rate)  'AvgRate' FROM jct_ops_tpm where sr_no2  = 2 "
            ' Sqlpass = "select group_no_new , group_desc, convert(numeric(6,2),today_packing/1000),convert(numeric(6,2),todate_packing/1000), convert(numeric(6,2),today_sale_qty/1000), convert(numeric(6,2),today_sale_amount/100000) , convert(numeric(6,2),todate_sale_qty/1000),convert(numeric(6,2),todate_sale_amount/100000) , convert(numeric(6,2),avg_rate) FROM jct_ops_tpm where sr_no2  = 2 "
            Dim conn = New SqlConnection(constr)
            conn.Open()
            Dim cmd As SqlCommand = New SqlCommand(Sqlpass, conn)
            'cmd.ExecuteNonQuery()
            Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim ds As DataSet = New DataSet()
            da.Fill(ds)
            grdGrid2.DataSource = ds
            grdGrid2.DataBind()
            conn.Close()
        ElseIf ddloutput.SelectedItem.Value = "Report" And ddlgroup.SelectedItem.Value = "Taffeta" Then
            Sqlpass = "select group_no_new 'Type', group_desc 'Description',  convert(numeric(6,2),today_packing)  'ToDPck', convert(numeric(6,2),todate_packing ) 'UDtPck',  convert(numeric(6,2),today_sale_qty) 'ToDspQty', convert(numeric(6,2),today_sale_amount) 'ToDspVal',  convert(numeric(6,2),todate_sale_qty) 'UDtDspQty', convert(numeric(6,2),todate_sale_amount) 'UDtdspval',  convert(numeric(6,2),avg_rate)  'AvgRate' FROM jct_ops_tpm where sr_no2  = 12 "
            Dim conn = New SqlConnection(constr)
            Dim cmd As SqlCommand = New SqlCommand(Sqlpass, conn)
            Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim ds As DataSet = New DataSet()
            da.Fill(ds)
            grdGrid2.DataSource = ds
            grdGrid2.DataBind()

        ElseIf ddloutput.SelectedItem.Value = "Report" And ddlgroup.SelectedItem.Value = "Others" Then
            Sqlpass = "select group_no_new 'Type', group_desc 'Description',  convert(numeric(6,2),today_packing)  'ToDPck', convert(numeric(6,2),todate_packing ) 'UDtPck',  convert(numeric(6,2),today_sale_qty) 'ToDspQty', convert(numeric(6,2),today_sale_amount) 'ToDspVal',  convert(numeric(6,2),todate_sale_qty) 'UDtDspQty', convert(numeric(6,2),todate_sale_amount) 'UDtdspval',  convert(numeric(6,2),avg_rate)  'AvgRate' FROM jct_ops_tpm where sr_no2  = 21 "
            Dim conn = New SqlConnection(constr)
            Dim cmd As SqlCommand = New SqlCommand(Sqlpass, conn)
            Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim ds As DataSet = New DataSet()
            da.Fill(ds)
            grdGrid2.DataSource = ds
            grdGrid2.DataBind()
        End If
    End Sub
    Public Sub BindData3()
        Dim Sqlpass As String
        If ddloutput.SelectedItem.Value = "Report" And ddlgroup.SelectedItem.Value = "Cotton" Then
            Sqlpass = "select group_no_new 'Type', group_desc 'Description',  convert(numeric(6,2),today_packing)  'ToDPck', convert(numeric(6,2),todate_packing ) 'UDtPck',  convert(numeric(6,2),today_sale_qty) 'ToDspQty', convert(numeric(6,2),today_sale_amount) 'ToDspVal',  convert(numeric(6,2),todate_sale_qty) 'UDtDspQty', convert(numeric(6,2),todate_sale_amount) 'UDtdspval',  convert(numeric(6,2),avg_rate)  'AvgRate' FROM jct_ops_tpm where sr_no2  = 3 "
            Dim conn = New SqlConnection(constr)
            conn.Open()
            Dim cmd As SqlCommand = New SqlCommand(Sqlpass, conn)
            'cmd.ExecuteNonQuery()
            Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim ds As DataSet = New DataSet()
            da.Fill(ds)
            grdGrid3.DataSource = ds
            grdGrid3.DataBind()
            conn.Close()
        ElseIf ddloutput.SelectedItem.Value = "Report" And ddlgroup.SelectedItem.Value = "Taffeta" Then
            Sqlpass = "select group_no_new 'Type', group_desc 'Description',  convert(numeric(6,2),today_packing)  'ToDPck', convert(numeric(6,2),todate_packing ) 'UDtPck',  convert(numeric(6,2),today_sale_qty) 'ToDspQty', convert(numeric(6,2),today_sale_amount) 'ToDspVal',  convert(numeric(6,2),todate_sale_qty) 'UDtDspQty', convert(numeric(6,2),todate_sale_amount) 'UDtdspval',  convert(numeric(6,2),avg_rate)  'AvgRate' FROM jct_ops_tpm where sr_no2  = 13 "
            Dim conn = New SqlConnection(constr)
            Dim cmd As SqlCommand = New SqlCommand(Sqlpass, conn)
            Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim ds As DataSet = New DataSet()
            da.Fill(ds)
            grdGrid3.DataSource = ds
            grdGrid3.DataBind()
        ElseIf ddloutput.SelectedItem.Value = "Report" And ddlgroup.SelectedItem.Value = "Others" Then
            Sqlpass = "select group_no_new 'Type', group_desc 'Description',  convert(numeric(6,2),today_packing)  'ToDPck', convert(numeric(6,2),todate_packing ) 'UDtPck',  convert(numeric(6,2),today_sale_qty) 'ToDspQty', convert(numeric(6,2),today_sale_amount) 'ToDspVal',  convert(numeric(6,2),todate_sale_qty) 'UDtDspQty', convert(numeric(6,2),todate_sale_amount) 'UDtdspval',  convert(numeric(6,2),avg_rate)  'AvgRate' FROM jct_ops_tpm where sr_no2  = 22 "
            Dim conn = New SqlConnection(constr)
            Dim cmd As SqlCommand = New SqlCommand(Sqlpass, conn)
            Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim ds As DataSet = New DataSet()
            da.Fill(ds)
            grdGrid3.DataSource = ds
            grdGrid3.DataBind()
        End If
    End Sub

    Public Sub BindData4()
        Dim Sqlpass As String
        If ddloutput.SelectedItem.Value = "Report" And ddlgroup.SelectedItem.Value = "Cotton" Then
            Sqlpass = "select group_no_new 'Type', group_desc 'Description',  convert(numeric(6,2),today_packing)  'ToDPck', convert(numeric(6,2),todate_packing ) 'UDtPck',  convert(numeric(6,2),today_sale_qty) 'ToDspQty', convert(numeric(6,2),today_sale_amount) 'ToDspVal',  convert(numeric(6,2),todate_sale_qty) 'UDtDspQty', convert(numeric(6,2),todate_sale_amount) 'UDtdspval',  convert(numeric(6,2),avg_rate)  'AvgRate' FROM jct_ops_tpm where sr_no2  = 4 "
            Dim conn = New SqlConnection(constr)
            conn.Open()
            Dim cmd As SqlCommand = New SqlCommand(Sqlpass, conn)
            'cmd.ExecuteNonQuery()
            Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim ds As DataSet = New DataSet()
            da.Fill(ds)
            grdGrid4.DataSource = ds
            grdGrid4.DataBind()
            conn.Close()
        ElseIf ddloutput.SelectedItem.Value = "Report" And ddlgroup.SelectedItem.Value = "Taffeta" Then
            Sqlpass = "select group_no_new 'Type', group_desc 'Description',  convert(numeric(6,2),today_packing)  'ToDPck', convert(numeric(6,2),todate_packing ) 'UDtPck',  convert(numeric(6,2),today_sale_qty) 'ToDspQty', convert(numeric(6,2),today_sale_amount) 'ToDspVal',  convert(numeric(6,2),todate_sale_qty) 'UDtDspQty', convert(numeric(6,2),todate_sale_amount) 'UDtdspval',  convert(numeric(6,2),avg_rate)  'AvgRate' FROM jct_ops_tpm where sr_no2  = 14 "
            Dim conn = New SqlConnection(constr)
            Dim cmd As SqlCommand = New SqlCommand(Sqlpass, conn)
            Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim ds As DataSet = New DataSet()
            da.Fill(ds)
            grdGrid4.DataSource = ds
            grdGrid4.DataBind()
        ElseIf ddloutput.SelectedItem.Value = "Report" And ddlgroup.SelectedItem.Value = "Others" Then
            Sqlpass = "select group_no_new 'Type', group_desc 'Description',  convert(numeric(6,2),today_packing)  'ToDPck', convert(numeric(6,2),todate_packing ) 'UDtPck',  convert(numeric(6,2),today_sale_qty) 'ToDspQty', convert(numeric(6,2),today_sale_amount) 'ToDspVal',  convert(numeric(6,2),todate_sale_qty) 'UDtDspQty', convert(numeric(6,2),todate_sale_amount) 'UDtdspval',  convert(numeric(6,2),avg_rate)  'AvgRate' FROM jct_ops_tpm where sr_no2  = 23 "
            Dim conn = New SqlConnection(constr)
            Dim cmd As SqlCommand = New SqlCommand(Sqlpass, conn)
            Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim ds As DataSet = New DataSet()
            da.Fill(ds)
            grdGrid4.DataSource = ds
            grdGrid4.DataBind()
        End If
    End Sub
    Public Sub BindData5()
        Dim Sqlpass As String
        If ddloutput.SelectedItem.Value = "Report" And ddlgroup.SelectedItem.Value = "Cotton" Then
            Sqlpass = "select group_no_new 'Type', group_desc 'Description',  convert(numeric(6,2),today_packing)  'ToDPck', convert(numeric(6,2),todate_packing ) 'UDtPck',  convert(numeric(6,2),today_sale_qty) 'ToDspQty', convert(numeric(6,2),today_sale_amount) 'ToDspVal',  convert(numeric(6,2),todate_sale_qty) 'UDtDspQty', convert(numeric(6,2),todate_sale_amount) 'UDtdspval',  convert(numeric(6,2),avg_rate)  'AvgRate' FROM jct_ops_tpm where sr_no2  = 5 "
            Dim conn = New SqlConnection(constr)
            conn.Open()
            Dim cmd As SqlCommand = New SqlCommand(Sqlpass, conn)
            'cmd.ExecuteNonQuery()
            Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim ds As DataSet = New DataSet()
            da.Fill(ds)
            grdGrid5.DataSource = ds
            grdGrid5.DataBind()
            conn.Close()
        ElseIf ddloutput.SelectedItem.Value = "Report" And ddlgroup.SelectedItem.Value = "Taffeta" Then
            Sqlpass = "select group_no_new 'Type', group_desc 'Description',  convert(numeric(6,2),today_packing)  'ToDPck', convert(numeric(6,2),todate_packing ) 'UDtPck',  convert(numeric(6,2),today_sale_qty) 'ToDspQty', convert(numeric(6,2),today_sale_amount) 'ToDspVal',  convert(numeric(6,2),todate_sale_qty) 'UDtDspQty', convert(numeric(6,2),todate_sale_amount) 'UDtdspval',  convert(numeric(6,2),avg_rate)  'AvgRate' FROM jct_ops_tpm where sr_no2  = 15 "
            Dim conn = New SqlConnection(constr)
            Dim cmd As SqlCommand = New SqlCommand(Sqlpass, conn)
            Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim ds As DataSet = New DataSet()
            da.Fill(ds)
            grdGrid5.DataSource = ds
            grdGrid5.DataBind()
        End If

    End Sub

    Public Sub BindData6()
        Dim Sqlpass As String
        If ddloutput.SelectedItem.Value = "Report" And ddlgroup.SelectedItem.Value = "Cotton" Then
            Sqlpass = "select group_no_new 'Type', group_desc 'Description',  convert(numeric(6,2),today_packing)  'ToDPck', convert(numeric(6,2),todate_packing ) 'UDtPck',  convert(numeric(6,2),today_sale_qty) 'ToDspQty', convert(numeric(6,2),today_sale_amount) 'ToDspVal',  convert(numeric(6,2),todate_sale_qty) 'UDtDspQty', convert(numeric(6,2),todate_sale_amount) 'UDtdspval',  convert(numeric(6,2),avg_rate)  'AvgRate' FROM jct_ops_tpm where sr_no2  = 6 "
            Dim conn = New SqlConnection(constr)
            conn.Open()
            Dim cmd As SqlCommand = New SqlCommand(Sqlpass, conn)
            'cmd.ExecuteNonQuery()
            Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim ds As DataSet = New DataSet()
            da.Fill(ds)
            grdGrid6.DataSource = ds
            grdGrid6.DataBind()
            conn.Close()
        End If
    End Sub
    Public Sub BindData7()
        Dim Sqlpass As String
        If ddloutput.SelectedItem.Value = "Report" And ddlgroup.SelectedItem.Value = "Cotton" Then
            Sqlpass = "select group_no_new 'Type', group_desc 'Description',  convert(numeric(6,2),today_packing)  'ToDPck', convert(numeric(6,2),todate_packing ) 'UDtPck',  convert(numeric(6,2),today_sale_qty) 'ToDspQty', convert(numeric(6,2),today_sale_amount) 'ToDspVal',  convert(numeric(6,2),todate_sale_qty) 'UDtDspQty', convert(numeric(6,2),todate_sale_amount) 'UDtdspval',  convert(numeric(6,2),avg_rate)  'AvgRate' FROM jct_ops_tpm where sr_no2  = 7 "
            Dim conn = New SqlConnection(constr)
            conn.Open()
            Dim cmd As SqlCommand = New SqlCommand(Sqlpass, conn)
            'cmd.ExecuteNonQuery()
            Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim ds As DataSet = New DataSet()
            da.Fill(ds)
            grdGrid7.DataSource = ds
            grdGrid7.DataBind()
            conn.Close()
        End If
    End Sub
    Public Sub BindData8()
        Dim Sqlpass As String
        If ddloutput.SelectedItem.Value = "Report" And ddlgroup.SelectedItem.Value = "Cotton" Then
            Sqlpass = "select group_no_new 'Type', group_desc 'Description',  convert(numeric(6,2),today_packing)  'ToDPck', convert(numeric(6,2),todate_packing ) 'UDtPck',  convert(numeric(6,2),today_sale_qty) 'ToDspQty', convert(numeric(6,2),today_sale_amount) 'ToDspVal',  convert(numeric(6,2),todate_sale_qty) 'UDtDspQty', convert(numeric(6,2),todate_sale_amount) 'UDtdspval',  convert(numeric(6,2),avg_rate)  'AvgRate' FROM jct_ops_tpm where sr_no2  = 8 "
            Dim conn = New SqlConnection(constr)
            conn.Open()
            Dim cmd As SqlCommand = New SqlCommand(Sqlpass, conn)
            'cmd.ExecuteNonQuery()
            Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim ds As DataSet = New DataSet()
            da.Fill(ds)
            grdGrid8.DataSource = ds
            grdGrid8.DataBind()
            conn.Close()
        End If
    End Sub
    Public Sub BindData9()
        Dim Sqlpass As String
        If ddloutput.SelectedItem.Value = "Report" And ddlgroup.SelectedItem.Value = "Cotton" Then
            Sqlpass = "select group_no_new 'Type', group_desc 'Description',  convert(numeric(6,2),today_packing)  'ToDPck', convert(numeric(6,2),todate_packing ) 'UDtPck',  convert(numeric(6,2),today_sale_qty) 'ToDspQty', convert(numeric(6,2),today_sale_amount) 'ToDspVal',  convert(numeric(6,2),todate_sale_qty) 'UDtDspQty', convert(numeric(6,2),todate_sale_amount) 'UDtdspval',  convert(numeric(6,2),avg_rate)  'AvgRate' FROM jct_ops_tpm where sr_no2  = 20 "
            Dim conn = New SqlConnection(constr)
            conn.Open()
            Dim cmd As SqlCommand = New SqlCommand(Sqlpass, conn)
            'cmd.ExecuteNonQuery()
            Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim ds As DataSet = New DataSet()
            da.Fill(ds)
            grdGrid9.DataSource = ds
            grdGrid9.DataBind()
            conn.Close()
        End If
    End Sub
    Protected Sub cmdexcel1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdexcel1.Click
        GridViewExportUtil.Export("tpm.xls", Me.grdGrid1)
    End Sub
    Public Sub group()
        Dim SqlPass As String = " select report_group from jct_ops_tpm_report_group"
        Dim Dr As SqlDataReader = obj.FetchReader(SqlPass)
        Try
            If Dr.HasRows = True Then
                Me.ddlgroup.Items.Clear()
                'ddlgroup.Items.Add(" ")
                While Dr.Read()
                    If Not (Dr.Item(0) Is System.DBNull.Value) Then
                        Me.ddlgroup.Items.Add(Trim(Dr.Item(0)))
                    End If
                End While
            Else
            End If
        Catch ex As Exception
        Finally
            obj.ConClose()
        End Try
    End Sub

    Public Sub output()
        Dim SqlPass As String = "select output_view  from jct_ops_tpm_report_view "
        Dim Dr As SqlDataReader = obj.FetchReader(SqlPass)
        Try
            If Dr.HasRows = True Then
                Me.ddloutput.Items.Clear()
                While Dr.Read()
                    If Not (Dr.Item(0) Is System.DBNull.Value) Then
                        Me.ddloutput.Items.Add(Trim(Dr.Item(0)))
                    End If
                End While
            Else
            End If
        Catch ex As Exception
        Finally
            obj.ConClose()
        End Try
    End Sub

    'Public Sub employeename()
    '    'Dim SqlPass As String = "select distinct empname from jct_ops_ta_bills where date between '" & txtEffecFrom.Text & "' AND '" & txtEffecTo.Text & "' and (ccdescrp =  '" & ddlcostcenter.Text & "' or '" & ddlcostcenter.Text & "' = ' ') order by empname"
    '    If ddllocation.SelectedItem.Value = " " And ddlcostcenter.SelectedItem.Value = " " Then
    '        sqlpass = "select distinct empname from jct_ops_ta_bills order by empname "
    '    Else
    '        If ddllocation.SelectedItem.Value <> " " And ddlcostcenter.SelectedItem.Value <> " " Then
    '            sqlpass = "select distinct empname from jct_ops_ta_bills where location =  '" & ddllocation.SelectedItem.Text & "'  and ccdescrp =  '" & ddlcostcenter.Text & "'  order by empname "
    '        Else
    '            If ddllocation.SelectedItem.Value <> " " And ddlcostcenter.SelectedItem.Value = " " Then
    '                sqlpass = "select distinct empname from jct_ops_ta_bills where location =  '" & ddllocation.SelectedItem.Text & "' order by empname "
    '            End If
    '        End If
    '    End If


    '    Dim Dr As SqlDataReader = obj.FetchReader(sqlpass)
    '    Try
    '        If Dr.HasRows = True Then
    '            Me.ddlemployee.Items.Clear()
    '            ddlemployee.Items.Add(" ")
    '            While Dr.Read()
    '                If Not (Dr.Item(0) Is System.DBNull.Value) Then
    '                    Me.ddlemployee.Items.Add(Trim(Dr.Item(0)))
    '                End If
    '            End While
    '        Else
    '        End If
    '    Catch ex As Exception
    '    Finally
    '        obj.ConClose()
    '    End Try

    'End Sub
    
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
        'pnlChart.Visible = True
        ''sql = " SELECT  sum(tot_exp) as total,empname FROM jct_ops_ta_bills where date between '" & txtEffecFrom.Text & "' AND '" & txtEffecTo.Text & "' and (location =  '" & ddllocation.Text & "' or '" & ddllocation.Text & "' = ' ') and (ccdescrp =  '" & ddlcostcenter.Text & "' or '" & ddlcostcenter.Text & "' = ' ') and (empname =  '" & ddlemployee.Text & "' or '" & ddlemployee.Text & "' = ' ') group by empname"
        'PopulateBarChart(sql, Chart1)
        'pnlChart.Visible = True
        'Dim SqlChartParm As String = "select convert(numeric(6,2),today_packing/1000) 'TodayPacking',convert(numeric(6,2),todate_packing/1000) 'UptodatePacking', convert(numeric(6,2),today_sale_qty/1000)  'TodayDespatchQty', convert(numeric(6,2),today_sale_amount/100000) 'TodayDespatchVal', convert(numeric(6,2),todate_sale_qty/1000)'UptodateDespatchQty',convert(numeric(6,2),todate_sale_amount/100000) 'UptodateDespatchval' FROM jct_ops_tpm where sr_no2  = 1 "
        'Dim conn As SqlConnection = New SqlConnection(constr)
        'conn.Open()
        'Dim cmd As SqlCommand = New SqlCommand(SqlChartParm, conn)
        'Dim da As New SqlDataAdapter
        'da.SelectCommand = cmd
        'Dim ds As New DataSet
        'da.Fill(ds, SqlChartParm)
        'Dim row As DataRow
        'For Each row In ds.Tables(SqlChartParm).Rows

        '    Dim series As String = row(ds.Tables(SqlChartParm).Rows)
        '    Chart1.Series.Add(series)
        '    Chart1.Series(series).ChartType = SeriesChartType.Column
        '    Chart1.Series(series).BorderWidth = 2
        '    Chart1.Series(series)("PointWidth") = "0.8"
        '    Chart1.Series(series)("DrawingStyle") = "Cylinder"

        '    Dim colIndex As Integer
        '    For colIndex = 1 To (ds.Tables(SqlChartParm).Columns.Count) - 1
        '        Dim columnName As String = ds.Tables(SqlChartParm).Columns(colIndex).ColumnName
        '        Dim YVal As Integer = CInt(row(columnName))
        '        Chart1.Series(series).ToolTip = YVal

        '        Chart1.Series(series).Points.AddXY(columnName, YVal)
        '    Next colIndex

        'Next row
        'conn.Close()


    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            output()
            group()
        End If
    End Sub

    Protected Sub grdGrid2_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdGrid2.RowDataBound

        If e.Row.RowType = DataControlRowType.DataRow Then
            sumb1 = sumb1 + Decimal.Parse(e.Row.Cells(2).Text)
            sumb2 = sumb2 + Decimal.Parse(e.Row.Cells(3).Text)
            sumb3 = sumb3 + Decimal.Parse(e.Row.Cells(4).Text)
            sumb4 = sumb4 + Decimal.Parse(e.Row.Cells(5).Text)
            sumb5 = sumb5 + Decimal.Parse(e.Row.Cells(6).Text)
            sumb6 = sumb6 + Decimal.Parse(e.Row.Cells(7).Text)

        ElseIf e.Row.RowType = DataControlRowType.Footer Then
            e.Row.Cells(1).Text = "Total"
            e.Row.Cells(2).Text = sumb1
            e.Row.Cells(3).Text = sumb2
            e.Row.Cells(4).Text = sumb3
            e.Row.Cells(5).Text = sumb4
            e.Row.Cells(6).Text = sumb5
            e.Row.Cells(7).Text = sumb6
        End If
    End Sub

    Protected Sub grdGrid3_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdGrid3.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            sumc1 = sumc1 + Decimal.Parse(e.Row.Cells(2).Text)
            sumc2 = sumc2 + Decimal.Parse(e.Row.Cells(3).Text)
            sumc3 = sumc3 + Decimal.Parse(e.Row.Cells(4).Text)
            sumc4 = sumc4 + Decimal.Parse(e.Row.Cells(5).Text)
            sumc5 = sumc5 + Decimal.Parse(e.Row.Cells(6).Text)
            sumc6 = sumc6 + Decimal.Parse(e.Row.Cells(7).Text)

        ElseIf e.Row.RowType = DataControlRowType.Footer Then
            e.Row.Cells(1).Text = "Total"
            e.Row.Cells(2).Text = sumc1
            e.Row.Cells(3).Text = sumc2
            e.Row.Cells(4).Text = sumc3
            e.Row.Cells(5).Text = sumc4
            e.Row.Cells(6).Text = sumc5
            e.Row.Cells(7).Text = sumc6
        End If
    End Sub

    Protected Sub grdGrid4_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdGrid4.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            sumd1 = sumd1 + Decimal.Parse(e.Row.Cells(2).Text)
            sumd2 = sumd2 + Decimal.Parse(e.Row.Cells(3).Text)
            sumd3 = sumd3 + Decimal.Parse(e.Row.Cells(4).Text)
            sumd4 = sumd4 + Decimal.Parse(e.Row.Cells(5).Text)
            sumd5 = sumd5 + Decimal.Parse(e.Row.Cells(6).Text)
            sumd6 = sumd6 + Decimal.Parse(e.Row.Cells(7).Text)

        ElseIf e.Row.RowType = DataControlRowType.Footer Then
            e.Row.Cells(1).Text = "Total"
            e.Row.Cells(2).Text = sumd1
            e.Row.Cells(3).Text = sumd2
            e.Row.Cells(4).Text = sumd3
            e.Row.Cells(5).Text = sumd4
            e.Row.Cells(6).Text = sumd5
            e.Row.Cells(7).Text = sumd6
        End If
    End Sub

    Protected Sub grdGrid5_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdGrid5.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            sume1 = sume1 + Decimal.Parse(e.Row.Cells(2).Text)
            sume2 = sume2 + Decimal.Parse(e.Row.Cells(3).Text)
            sume3 = sume3 + Decimal.Parse(e.Row.Cells(4).Text)
            sume4 = sume4 + Decimal.Parse(e.Row.Cells(5).Text)
            sume5 = sume5 + Decimal.Parse(e.Row.Cells(6).Text)
            sume6 = sume6 + Decimal.Parse(e.Row.Cells(7).Text)

        ElseIf e.Row.RowType = DataControlRowType.Footer Then
            e.Row.Cells(1).Text = "Total"
            e.Row.Cells(2).Text = sume1
            e.Row.Cells(3).Text = sume2
            e.Row.Cells(4).Text = sume3
            e.Row.Cells(5).Text = sume4
            e.Row.Cells(6).Text = sume5
            e.Row.Cells(7).Text = sume6
        End If
    End Sub

    Protected Sub grdGrid6_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdGrid6.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            sumf1 = sumf1 + Decimal.Parse(e.Row.Cells(2).Text)
            sumf2 = sumf2 + Decimal.Parse(e.Row.Cells(3).Text)
            sumf3 = sumf3 + Decimal.Parse(e.Row.Cells(4).Text)
            sumf4 = sumf4 + Decimal.Parse(e.Row.Cells(5).Text)
            sumf5 = sumf5 + Decimal.Parse(e.Row.Cells(6).Text)
            sumf6 = sumf6 + Decimal.Parse(e.Row.Cells(7).Text)

        ElseIf e.Row.RowType = DataControlRowType.Footer Then
            e.Row.Cells(1).Text = "Total"
            e.Row.Cells(2).Text = sumf1
            e.Row.Cells(3).Text = sumf2
            e.Row.Cells(4).Text = sumf3
            e.Row.Cells(5).Text = sumf4
            e.Row.Cells(6).Text = sumf5
            e.Row.Cells(7).Text = sumf6
        End If
    End Sub

    Protected Sub grdGrid7_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdGrid7.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            sumg1 = sumg1 + Decimal.Parse(e.Row.Cells(2).Text)
            sumg2 = sumg2 + Decimal.Parse(e.Row.Cells(3).Text)
            sumg3 = sumg3 + Decimal.Parse(e.Row.Cells(4).Text)
            sumg4 = sumg4 + Decimal.Parse(e.Row.Cells(5).Text)
            sumg5 = sumg5 + Decimal.Parse(e.Row.Cells(6).Text)
            sumg6 = sumg6 + Decimal.Parse(e.Row.Cells(7).Text)

        ElseIf e.Row.RowType = DataControlRowType.Footer Then
            e.Row.Cells(1).Text = "Total"
            e.Row.Cells(2).Text = sumg1
            e.Row.Cells(3).Text = sumg2
            e.Row.Cells(4).Text = sumg3
            e.Row.Cells(5).Text = sumg4
            e.Row.Cells(6).Text = sumg5
            e.Row.Cells(7).Text = sumg6
        End If
    End Sub

    Protected Sub grdGrid8_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdGrid8.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            sumh1 = sumh1 + Decimal.Parse(e.Row.Cells(2).Text)
            sumh2 = sumh2 + Decimal.Parse(e.Row.Cells(3).Text)
            sumh3 = sumh3 + Decimal.Parse(e.Row.Cells(4).Text)
            sumh4 = sumh4 + Decimal.Parse(e.Row.Cells(5).Text)
            sumh5 = sumh5 + Decimal.Parse(e.Row.Cells(6).Text)
            sumh6 = sumh6 + Decimal.Parse(e.Row.Cells(7).Text)

        ElseIf e.Row.RowType = DataControlRowType.Footer Then
            e.Row.Cells(1).Text = "Total"
            e.Row.Cells(2).Text = sumh1
            e.Row.Cells(3).Text = sumh2
            e.Row.Cells(4).Text = sumh3
            e.Row.Cells(5).Text = sumh4
            e.Row.Cells(6).Text = sumh5
            e.Row.Cells(7).Text = sumh6
        End If
    End Sub

    Protected Sub grdGrid9_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdGrid9.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            sumi1 = sumi1 + Decimal.Parse(e.Row.Cells(2).Text)
            sumi2 = sumi2 + Decimal.Parse(e.Row.Cells(3).Text)
            sumi3 = sumi3 + Decimal.Parse(e.Row.Cells(4).Text)
            sumi4 = sumi4 + Decimal.Parse(e.Row.Cells(5).Text)
            sumi5 = sumi5 + Decimal.Parse(e.Row.Cells(6).Text)
            sumi6 = sumi6 + Decimal.Parse(e.Row.Cells(7).Text)

        ElseIf e.Row.RowType = DataControlRowType.Footer Then
            e.Row.Cells(1).Text = "Total"
            e.Row.Cells(2).Text = sumi1
            e.Row.Cells(3).Text = sumi2
            e.Row.Cells(4).Text = sumi3
            e.Row.Cells(5).Text = sumi4
            e.Row.Cells(6).Text = sumi5
            e.Row.Cells(7).Text = sumi6
        End If
    End Sub

    Protected Sub grdGrid1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdGrid1.SelectedIndexChanged

    End Sub
End Class

