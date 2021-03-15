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
    Dim CustCode As String
    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Chart1.Visible = False
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
        End If





        ' Enable or disable the view state
        Chart1.EnableViewState = True

        ' Determine what content should be serialized in the browser.
        Chart1.ViewStateContent = SerializationContents.Default

        ' If this is not a postback or if state management is not selected, then
        ' add the source chart data to the chart.  Also, if there was no state
        ' management in the previous page view and there is now, reload the data


        '   Chart2.Visible = False

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

    Protected Sub CmdFetch_Click(sender As Object, e As System.EventArgs) Handles CmdFetch.Click
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
        Qry = "Exec JCT_OPs_OverDue_Dashboard    '" & OrdNo & "','" & CustCode & "','" & SalePerson & "',0,'" & Session("Empcode") & "','" & SaleTeam & "',1"
        ' Qry = "EXEC JCT_OPs_OverDue_Dashboard '-All-','-All-','-All-',50,'-All-','-All-',1 "
        PopulatePieChart(Qry, Chart1)
        ObjFun.FillGrid(Qry, GrdDetail)
        'Chart2.Series("Series1").RemoveAt(0)
        ' Chart2.Visible = False

    End Sub
    Protected Sub PopulatePieChart(ByVal sql As String, ByRef chart As Chart)

        Try
            Cmd = New SqlCommand(sql, obj1.Connection)
            Dim SqlReader As SqlDataReader = Cmd.ExecuteReader()
            Dim ds1 As DataSet = New DataSet
            ds1.Tables.Add()
            ds1.Load(SqlReader, LoadOption.OverwriteChanges, ds1.Tables(0))
            chart.RenderType = RenderType.ImageTag
            chart.ImageType = ChartImageType.Png
            chart.DataSource = ds1

            chart.Serializer.Content = SerializationContents.Appearance
            chart.Serializer.Reset()
            chart.Series("Series1").ChartType = SeriesChartType.Pie
            chart.Series("Series1")("PointWidth") = "0.5"
            chart.Series("Series1").XValueMember = ds1.Tables(0).Columns(0).Caption
            chart.Series("Series1").YValueMembers = ds1.Tables(0).Columns(1).Caption
            chart.Series("Series1").PostBackValue = "#VALX"
            chart.Series("Series1").LabelPostBackValue = "#VALY"

            chart.Series("Series1").LabelToolTip = "Unique Orders =#VALY"
            chart.Series("Series1").ToolTip = "Total Unique Orders of #VALX"
            chart.Series("Series1").Label = "#VALY"
            chart.Series("Series1").LegendPostBackValue = "#VALX"
            'ViewState.Add("Index", chart.Series("Series1").LegendPostBackValue)
            chart.Series("Series1").LegendText = "#VALX"
            chart.Series("Series1").LegendToolTip = "Sale Person=#VALX"
            '= "#INDEX";

            chart.Series("Series1").BackImageTransparentColor = Drawing.Color.Empty
            chart.Series("Series1").MarkerImageTransparentColor = Drawing.Color.Empty
            'chart.Series("Series1").CustomProperties = "LabelStyle=Outside"
            'chart.DataBind()=

        Catch ex As Exception
            MsgBox("Exception")
        End Try

    End Sub

    'Protected Sub PopulatePieChart(ByVal sql As String, ByRef chart As Chart)
    '    Try
    '        Cmd = New SqlCommand(sql, obj1.Connection)
    '        Dim SqlReader As SqlDataReader = Cmd.ExecuteReader()
    '        Dim ds1 As DataSet = New DataSet
    '        ds1.Tables.Add()
    '        ds1.Load(SqlReader, LoadOption.OverwriteChanges, ds1.Tables(0))
    '        chart.DataSource = ds1
    '        chart.Series("Series1").ChartType = SeriesChartType.Pie
    '        chart.Series("Series1")("PointWidth") = "0.5"
    '        chart.Series("Series1").XValueMember = ds1.Tables(0).Columns(0).Caption
    '        chart.Series("Series1").YValueMembers = ds1.Tables(0).Columns(1).Caption
    '        chart.DataBind()
    '    Catch ex As Exception
    '        MsgBox("Exception")
    '    End Try

    'End Sub

    Protected Sub GrdDetail_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles GrdDetail.SelectedIndexChanged

        CustCode = ""
        CustCode = GrdDetail.SelectedRow.Cells(1).Text
        CustCode = Trim(Right(CustCode, Len(CustCode) - InStr(CustCode, "~")))
        Qry = "EXEC JCT_OPs_OverDue_Dashboard '-All-','-All-','" & CustCode & "',50,'-All-','-All-',2 "
        ObjFun.FillGrid(Qry, GrdDetail1)
    End Sub

    Protected Sub Chart1_Click(sender As Object, e As System.Web.UI.WebControls.ImageMapEventArgs) Handles Chart1.Click
        CustCode = "" '
        CustCode = e.PostBackValue
        CustCode = Trim(Right(CustCode, Len(CustCode) - InStr(CustCode, "~")))
        Qry = "EXEC JCT_OPs_OverDue_Dashboard '-All-','-All-','" & CustCode & "',50,'-All-','-All-',3 "
        Try
            ' Chart2.Visible = True
            Cmd = New SqlCommand(Qry, obj1.Connection)
            Dim SqlReader As SqlDataReader = Cmd.ExecuteReader()
            Dim ds1 As DataSet = New DataSet
            ds1.Tables.Add()
            ds1.Load(SqlReader, LoadOption.OverwriteChanges, ds1.Tables(0))
            Chart2.DataSource = ds1
            Chart2.Serializer.Content = SerializationContents.Appearance
            Chart2.Serializer.Reset()
            Chart2.Series("Series1").ChartType = SeriesChartType.Pie
            Chart2.Series("Series1")("PointWidth") = "0.5"
            Chart2.Series("Series1").XValueMember = ds1.Tables(0).Columns(0).Caption
            Chart2.Series("Series1").YValueMembers = ds1.Tables(0).Columns(1).Caption
            Chart2.Series("Series1").PostBackValue = "#VALX,#VALY"
            Chart2.Series("Series1").LabelPostBackValue = "#VALY"
            Chart2.Series("Series1").LabelToolTip = "Unique Orders =#VALY"
            Chart2.Series("Series1").ToolTip = "Total Unique Orders of #VALX=#VALY"
            Chart2.Series("Series1").Label = "#VALY"
            Chart2.Series("Series1").LegendPostBackValue = "#VALX"
            Chart2.Series("Series1").LegendText = "#VALX"
            Chart2.Series("Series1").LegendToolTip = "Rated Department=#VALX"

            Chart2.Series("Series1").BackImageTransparentColor = Drawing.Color.Empty
            Chart2.Series("Series1").MarkerImageTransparentColor = Drawing.Color.Empty
            'Dim pointIndex As Int32 = Val(ViewState("Index").ToString)  'Int32.Parse(e.PostBackValue)

            'If (pointIndex >= 0 And pointIndex < Chart1.Series("Series1").Points.Count) Then
            '    Chart1.Series("Series1").Points(pointIndex).CustomProperties += "Exploded=true"
            'End If

            CmdFetch_Click(sender, e)

        Catch ex As Exception
            MsgBox("Exception")
        End Try
    End Sub
End Class
