Imports System.Data
Imports System.Data.SqlClient
Imports System
Imports System.Configuration
Imports System.Collections
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.Threading
Imports System.Web.UI.DataVisualization.Charting
Partial Class OPS_DashboardView
    Inherits System.Web.UI.Page
    Dim ObjFun As Functions = New Functions
    Dim Qry As String
    Dim sql As String
    Dim obj1 As Connection = New Connection
    Dim obj As Functions = New Functions
    Dim DeptCode, DeptCode1 As String
    Dim Cmd As SqlCommand
    Dim OrdNo As String, CustCode As String, SaleTeam As String, SalePerson As String
    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            Qry = " Select '' as [team_code],'' as [team_description] Union  SELECT rtrim(team_code),rtrim(team_description) FROM MISERP.SOM.DBO.jct_team_mASter  ORDER BY team_code   "
            ObjFun.FillList(ddlSalesTeam, Qry)
            If ddlSalesTeam.SelectedItem.Text = "" Then

                Qry = "SELECT  '' as group_desc, '' as group_no Union Select rtrim(group_no),rtrim(group_desc) FROM miserp.som.dbo.m_cust_group WHERE group_TYPE='SALESP' AND status ='o'"
                ObjFun.FillList(ddlSalesPerson, Qry)

            Else

                ddlSalesPerson.Items.Clear()
                Qry = "Select '' as [sale_person_code] ,'' as [group_desc] union SELECT DISTINCT rtrim(a.sale_person_code),rtrim(b.group_desc) FROM MISERP.SOM.DBO.jct_team_saleperson_mapping a  INNER JOIN MISERP.SOM.dbo.miserp.som.dbo.m_cust_group b ON b.group_no = a.sale_person_code WHERE  a.status='O' and group_type='SalesP' and    team_code = '" + ddlSalesTeam.SelectedItem.Text + "'"
                ObjFun.FillList(ddlSalesPerson, Qry)
            End If
            Chart1.Visible = False
            Chart2.Visible = False
            RblOPtions_SelectedIndexChanged(sender, e)
        End If

    End Sub
    Protected Sub ddlSalesTeam_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlSalesTeam.SelectedIndexChanged
        If ddlSalesTeam.SelectedItem.Text = "" Then
            ddlSalesPerson.Items.Clear()
            Qry = "Select '' as group_no, '' as group_desc Union SELECT RTRIM(group_no),RTRIM(group_desc) FROM miserp.som.dbo.m_cust_group WHERE group_TYPE='SALESP' AND status ='o'"
            ObjFun.FillList(ddlSalesPerson, Qry)
        Else
            ddlSalesPerson.Items.Clear()
            Qry = "Select '' as [sale_person_code] ,'' as [group_desc] union SELECT DISTINCT RTRIM(a.sale_person_code),RTRIM(b.group_desc) FROM MISERP.SOM.DBO.jct_team_saleperson_mapping a  INNER JOIN MISERP.SOM.dbo.m_cust_group b ON b.group_no = a.sale_person_code WHERE  a.status='O' and group_type='SalesP' and    team_code = '" + ddlSalesTeam.SelectedItem.Text + "'"
            ObjFun.FillList(ddlSalesPerson, Qry)
        End If
    End Sub

    Protected Sub CmdFetch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmdFetch.Click
        PopulatePieChart()
    End Sub
    Protected Sub PopulatePieChart()
        If Chart1.Visible = True Then
            Chart2.Visible = True
        Else
            Chart2.Visible = False
        End If
        Dim OrdNo As String, CustCode As String, SaleTeam As String, SalePerson As String
        OrdNo = "0"
        CustCode = ""
        SaleTeam = ""
        SalePerson = ""

        If txtOrderNo.Text = "" Then
            OrdNo = "-All-"
        Else
            OrdNo = txtOrderNo.Text
        End If

        If txtCustomer.Text = "" Then
            CustCode = "-All-"
        Else
            CustCode = Right(txtCustomer.Text, Len(txtCustomer.Text) - InStr(txtCustomer.Text, "~")) 'txtCustomer.Text
        End If

        If ddlSalesPerson.SelectedItem.Text = "" Then
            SalePerson = "-All-"
        Else
            SalePerson = Trim(ddlSalesPerson.SelectedItem.Value)
        End If


        If ddlSalesTeam.SelectedItem.Text = "" Then
            SaleTeam = "-All-"
        Else
            SaleTeam = Trim(ddlSalesTeam.SelectedItem.Value)
        End If
        Chart1.Visible = True
        Qry = "Exec " & ViewState("Proc").ToString & " '" & OrdNo & "','" & CustCode & "','" & SalePerson & "',0,'" & Session("Empcode") & "','" & SaleTeam & "',1"
        ' Qry = "EXEC JCT_OPs_OverDue_Dashboard '-All-','-All-','-All-',50,'-All-','-All-',1 "
        ' PopulatePieChart(Qry, Chart1)
        If RblOPtions.SelectedIndex = 0 Then
            GrdDetail.Columns(2).HeaderText = "OrderOverDue"
        Else
            GrdDetail.Columns(2).HeaderText = "OrdersReturned"
        End If
        ObjFun.FillGrid(Qry, GrdDetail)

        Try
            Cmd = New SqlCommand(Qry, obj1.Connection)
            Dim SqlReader As SqlDataReader = Cmd.ExecuteReader()
            Dim ds1 As DataSet = New DataSet
            ds1.Tables.Add()
            ds1.Load(SqlReader, LoadOption.OverwriteChanges, ds1.Tables(0))
            Chart1.RenderType = RenderType.ImageTag
            Chart1.ImageType = ChartImageType.Png
            Chart1.DataSource = ds1
            Chart1.Titles(0).Text = "Sale Person's " & RblOPtions.SelectedItem.Text
            '   Chart1.Serializer.Content = SerializationContents.Appearance
            '   Chart1.Serializer.Reset()
            Chart1.Series("Series1").ChartType = SeriesChartType.Pie
            Chart1.Series("Series1")("PointWidth") = "0.5"
            Chart1.Series("Series1").XValueMember = ds1.Tables(0).Columns(0).Caption
            Chart1.Series("Series1").YValueMembers = ds1.Tables(0).Columns(1).Caption
            Chart1.Series("Series1").PostBackValue = "#VALX"
            Chart1.Series("Series1").LabelPostBackValue = "#VALY"
            Chart1.BorderSkin.SkinStyle = BorderSkinStyle.Emboss
            Chart1.Series("Series1").LabelToolTip = "Unique Orders =#VALY"
            Chart1.Series("Series1").ToolTip = "Total Unique Orders of #VALX"
            Chart1.Series("Series1").Label = "#VALY"
            Chart1.Series("Series1").LegendPostBackValue = "#VALX"
            'ViewState.Add("Index", chart.Series("Series1").LegendPostBackValue)
            Chart1.Series("Series1").LegendText = "#VALX"
            Chart1.Series("Series1").LegendToolTip = "Sale Person=#VALX"
            '= "#INDEX";

            Chart1.Series("Series1").BackImageTransparentColor = Drawing.Color.Empty
            Chart1.Series("Series1").MarkerImageTransparentColor = Drawing.Color.Empty
            'chart.Series("Series1").CustomProperties = "LabelStyle=Outside"
            'chart.DataBind()=

        Catch ex As Exception
            MsgBox("Exception")
        End Try

    End Sub

    Protected Sub PopulateChart1(ByVal sql As String, ByRef Chart2 As Chart)


        ' Chart2.Visible = True
        Cmd = New SqlCommand(Qry, obj1.Connection)
        Dim SqlReader As SqlDataReader = Cmd.ExecuteReader()
        Dim ds1 As DataSet = New DataSet
        ds1.Tables.Add()
        ds1.Load(SqlReader, LoadOption.OverwriteChanges, ds1.Tables(0))
        'If RblOPtions.SelectedIndex = 0 Then
        '    'GrdDetail.Columns(2).HeaderText = "OrderOverDue"
        'Else
        '    GrdDetail.Columns(2).HeaderText = "Order Wise Returned Meters"
        'End If
        Chart2.DataSource = ds1
        'Chart2.Serializer.Content = SerializationContents.Appearance
        'Chart2.Serializer.Reset()
        Chart2.Series("Series1").ChartType = SeriesChartType.Pie
        Chart2.Series("Series1")("PointWidth") = "0.5"
        Chart2.Titles(0).Text = "Sale Person's " & RblOPtions.SelectedItem.Text

        Chart2.Series("Series1").XValueMember = ds1.Tables(0).Columns(0).Caption
        Chart2.Series("Series1").YValueMembers = ds1.Tables(0).Columns(1).Caption
        Chart2.Series("Series1").PostBackValue = "#VALX,#VALY"
        Chart2.Series("Series1").LabelPostBackValue = "#VALY"
        Chart2.Series("Series1").LabelToolTip = "Unique Orders =#VALY"
        Chart2.Series("Series1").ToolTip = "Total Unique Orders of #VALX=#VALY"
        Chart2.Series("Series1").Label = "#VALY"
        Chart2.BorderSkin.SkinStyle = BorderSkinStyle.Emboss
        Chart2.Series("Series1").LegendPostBackValue = "#VALX"
        Chart2.Series("Series1").LegendText = "#VALX"
        Chart2.Series("Series1").LegendToolTip = "Rated Department=#VALX"

        Chart2.Series("Series1").BackImageTransparentColor = Drawing.Color.Empty
        Chart2.Series("Series1").MarkerImageTransparentColor = Drawing.Color.Empty
        'Dim pointIndex As Int32 = Val(ViewState("Index").ToString)  'Int32.Parse(e.PostBackValue)

        'If (pointIndex >= 0 And pointIndex < Chart1.Series("Series1").Points.Count) Then
        '    Chart1.Series("Series1").Points(pointIndex).CustomProperties += "Exploded=true"
        'End If


    End Sub

    Protected Sub GrdDetail_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles GrdDetail.SelectedIndexChanged

        CustCode = ""
        CustCode = GrdDetail.SelectedRow.Cells(1).Text
        CustCode = Trim(Right(CustCode, Len(CustCode) - InStr(CustCode, "~")))
        Qry = "EXEC " & ViewState("Proc").ToString & "  '-All-','-All-','" & CustCode & "',0,'-All-','-All-',2 "
        ObjFun.FillGrid(Qry, GrdDetail1)
    End Sub

    Protected Sub Chart1_Click(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ImageMapEventArgs) Handles Chart1.Click
        pnlChart2.Visible = True
        CustCode = ""
        CustCode = e.PostBackValue
        CustCode = Trim(Right(CustCode, Len(CustCode) - InStr(CustCode, "~")))
        LblDetail.Text = Trim(e.PostBackValue) & " | "
        If RblOPtions.SelectedIndex = 0 Then
            Qry = "EXEC JCT_OPs_OverDue_Dashboard '-All-','-All-','" & CustCode & "',0,'-All-','-All-',3 "
        Else
            Qry = "EXEC " & ViewState("Proc").ToString & " '-All-','-All-','" & CustCode & "',0,'-All-','-All-',3 "


        End If
        Try
            PopulateChart1(Qry, Chart2)
            CmdFetch_Click(sender, e)

        Catch ex As Exception
            MsgBox("Exception")
        End Try
    End Sub

    Protected Sub Chart2_Click(sender As Object, e As System.Web.UI.WebControls.ImageMapEventArgs) Handles Chart2.Click
        pnlChart3.Visible = True

        pnlChart2.Visible = True
        ' Chart1_Click(sender, e)
        OrdNo = ""
        CustCode = ""
        SaleTeam = ""
        SalePerson = LblDetail.Text
        If txtOrderNo.Text = "" Then
            OrdNo = "-All-"
        Else
            OrdNo = txtOrderNo.Text
        End If

        CustCode = e.PostBackValue.Split("~")(1).ToString()
        Dim CustomerName As String = e.PostBackValue.Split("~")(0).ToString()
        CustCode = CustCode.Split(",")(0).ToString()
        PopulatePieChart()

        If ddlSalesTeam.SelectedItem.Text = "" Then
            SaleTeam = "-All-"
        Else
            SaleTeam = Trim(ddlSalesTeam.SelectedItem.Value)
        End If



        SalePerson = Trim(LblDetail.Text)

        SalePerson = Left(SalePerson, Len(SalePerson) - 1)
        SalePerson = Trim(Right(SalePerson, Len(SalePerson) - InStr(SalePerson, "~")))
        Qry = "EXEC JCT_OPs_OverDue_Dashboard '-All-','-All-','" & SalePerson & "',0,'-All-','-All-',3 "
        PopulateChart1(sql, Chart2)


        Qry = "Exec JCT_OPs_OverDue_Dashboard  '" & OrdNo & "','" & CustCode & "','" & SalePerson & "',0,'" & Session("Empcode") & "','" & SaleTeam & "',7"
        ' PopulateColumnChart(Qry, Chart5)
        PopulateBarChart(Qry, Chart3, CustomerName)
        '  LblDetail.Text = LblDetail.Text & e.PostBackValue
    End Sub

    Protected Sub PopulateColumnChart(ByVal sql As String, ByRef chart As Chart)
        Cmd = New SqlCommand(sql, obj1.Connection)
        Dim SqlReader As SqlDataReader = Cmd.ExecuteReader()
        Dim ds1 As DataSet = New DataSet
        ds1.Tables.Add()
        ds1.Load(SqlReader, LoadOption.OverwriteChanges, ds1.Tables(0))
        chart.DataSource = ds1
        Dim legend(10) As String
        Dim I As Int32 = 0
        chart.Series.Clear()
        While I < ds1.Tables(0).Columns.Count
            chart.Series.Add("Series1" & I.ToString)
            chart.Series("Series1" & I.ToString).ChartType = SeriesChartType.Column
            chart.Series("Series1" & I.ToString)("PointWidth") = "0.5"
            'chart.Series("Series1" & I.ToString).XValueMember = ds1.Tables(0).Columns(I).AutoIncrementSeed
            chart.Series("Series1" & I.ToString).XValueMember = ds1.Tables(0).Columns(I).Caption
            chart.Series("Series1" & I.ToString).YValuesPerPoint = 1
            chart.Series("Series1" & I.ToString).LegendText = ds1.Tables(0).Columns(I).ColumnName
            chart.Series("Series1" & I.ToString).YValueMembers = ds1.Tables(0).Columns(I).Caption
            chart.Series("Series1" & I.ToString).ToolTip = ds1.Tables(0).Columns(I).ColumnName + ds1.Tables(0).Columns(I).DefaultValue
            ' chart.ChartAreas("ChartArea1").AxisY.MajorTickMark.Enabled = True
            I = I + 1
        End While

        ' chart.Series("Series1").Legend = ds1.Tables(0).Columns.ToString

        'chart.Series("Series1").LegendText = ds1.Tables(0).Columns(0).ColumnName
        chart.DataBind()
    End Sub

    Protected Sub PopulateBarChart(ByVal sql As String, ByRef chart As Chart, ByVal Cust As String)
        Try
            chart.Series("Series1").ChartType = SeriesChartType.Column
            chart.Titles(0).Text = "Order Wise Overdue Amount of " + Cust + ""

            ' Set point width of the series
            chart.Series("Series1")("PointWidth") = "0.2"

            ' Set drawing style
            chart.Series("Series1")("DrawingStyle") = "Cylinder"

            chart.Series("Series1")("ShowMarkerLines") = "True"
            chart.Series("Series1").BorderWidth = 1
            chart.Series("Series1").MarkerStyle = MarkerStyle.None

            Cmd = New SqlCommand(sql, obj1.Connection)
            Dim SqlReader As SqlDataReader = Cmd.ExecuteReader()
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
            obj1.ConClose()
        End Try

    End Sub

    Protected Sub RblOPtions_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles RblOPtions.SelectedIndexChanged
        If RblOPtions.SelectedIndex = 0 Then
            ViewState.Add("Proc", "JCT_OPs_OverDue_Dashboard")
        ElseIf RblOPtions.SelectedIndex = 1 Then
            ViewState.Add("Proc", "JCT_OPS_ReturenedStock_Dashboard")
        Else
            ViewState.Add("Proc", "Jct_Ops_Dashboard_Outstanding")
        End If
    End Sub
End Class
