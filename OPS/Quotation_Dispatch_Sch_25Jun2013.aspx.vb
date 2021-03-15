Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.UI.DataVisualization.Charting
Imports System.Drawing

Partial Class OPS_Quotation_Dispatch_Sch
    Inherits System.Web.UI.Page

    Dim dt As DataTable = New DataTable
    Dim ofn As New Functions
    Dim obj As Connection = New Connection
    Dim cmd As SqlCommand

    Protected Sub ibtSave_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles ibtSave.Click

        If (ddlCustomerApproval.SelectedIndex = 0) Then
            Dim script As String = "alert('Please select customer approval option..!!');"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ServerControlScript", script, True)
        Else
            Dim tr As SqlTransaction
            Dim cn As New Connection
            Dim sqlstr As String = "jct_ops_create_quote_dispatch_sch"
            tr = cn.Connection.BeginTransaction
            Dim cmd As SqlCommand = New SqlCommand(sqlstr, cn.Connection, tr)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@Quotation_no", SqlDbType.VarChar, 16)
            cmd.Parameters.Add("@Shade", SqlDbType.VarChar, 30)
            cmd.Parameters.Add("@Quantity", SqlDbType.Float, 100)
            cmd.Parameters.Add("@Uom", SqlDbType.VarChar, 10)
            cmd.Parameters.Add("@Dispatch_Date", SqlDbType.VarChar, 20)
            cmd.Parameters.Add("@Country", SqlDbType.VarChar, 50)
            cmd.Parameters.Add("@City", SqlDbType.VarChar, 50)
            cmd.Parameters.Add("@Pack_Rem", SqlDbType.VarChar, 500)
            cmd.Parameters.Add("@Transit_Mode", SqlDbType.VarChar, 20)
            cmd.Parameters.Add("@ClearFlag", SqlDbType.VarChar, 1)
            cmd.Parameters.Add("@CustomerApproval", SqlDbType.VarChar, 1)
            Try
                Dim cf As String = "1"
                For Each row As GridViewRow In grdDispatchDetail.Rows
                    cmd.Parameters("@ClearFlag").Value = cf
                    cmd.Parameters("@Quotation_no").Value = Request.QueryString("quot")
                    cmd.Parameters("@Shade").Value = row.Cells(1).Text
                    cmd.Parameters("@Quantity").Value = row.Cells(2).Text
                    cmd.Parameters("@UOM").Value = ddlUom.SelectedItem.Value
                    cmd.Parameters("@Dispatch_Date").Value = row.Cells(3).Text
                    cmd.Parameters("@Country").Value = txtDestCountry.Text
                    cmd.Parameters("@City").Value = txtDestCity.Text
                    cmd.Parameters("@Pack_Rem").Value = txtPackRemarks.Text
                    cmd.Parameters("@Transit_Mode").Value = ddlTransportMode.SelectedItem.Text
                    cmd.Parameters("@CustomerApproval").Value = ddlCustomerApproval.SelectedItem.Text
                    cmd.ExecuteNonQuery()
                    cf = "0"
                Next
                tr.Commit()
                lblMessage.Text = "Dispatch Schedule for Quotation No " & lblQuotationNo.Text & " Saved Successfully!"
                grdDispatchDetailStatus.DataBind()

            Catch ex As Exception
                tr.Rollback()
                'ofn.Alert(ex.Message)
                lblMessage.Text = ex.Message
            End Try

        End If

    End Sub

    Protected Sub ibtAddDispatchItem_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles ibtAddDispatchItem.Click

        If (ddlCustomerApproval.SelectedIndex = 0) Then

            Dim script As String = "alert('Please select customer approval option..!!');"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ServerControlScript", script, True)

        Else

            If CDate(txtDispatchDate.Text) < DateTime.Now.AddDays(45) Then

            End If

            If Not ViewState("data") Is Nothing Then
                dt = ViewState("data")

            Else
                dt.Columns.Add("ShadeCode")
                dt.Columns.Add("Quantity")
                dt.Columns.Add("DispatchDate")
                dt.Columns.Add("AdvisedDate")
                dt.Columns.Add("CustomerApproval")

            End If

            Dim drow As DataRow = dt.NewRow
            drow("ShadeCode") = ddlDispatchShade.SelectedItem.Value
            drow("Quantity") = txtDispatchQuantity.Text
            drow("DispatchDate") = txtDispatchDate.Text
            drow("AdvisedDate") = ""
            drow("CustomerApproval") = ddlCustomerApproval.SelectedItem.Text

            dt.Rows.Add(drow)

            ViewState.Add("data", dt)
            grdDispatchDetail.DataSource = dt
            grdDispatchDetail.DataBind()

            'CalculateAllocatedQty()
            CalculateUnAllocatedQty()

        End If

    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        lblQuotationNo.Text = Request.QueryString("quot")
        'txtDispatchDate.Text = DateTime.Now.AddDays(45).ToString

        If Not ViewState("data") Is Nothing Then
            dt = ViewState("data")

        Else
            dt.Columns.Add("ShadeCode")
            dt.Columns.Add("Quantity")
            dt.Columns.Add("DispatchDate")
            dt.Columns.Add("AdvisedDate")
            dt.Columns.Add("CustomerApproval")

        End If

        If Not IsPostBack Then

            Dim sqlstr As String = "jct_ops_get_quote_dispatch_sch '" & lblQuotationNo.Text & "'"
            Dim cn As New Connection
            Dim cmd As SqlCommand = New SqlCommand(sqlstr, cn.Connection)
            'Dim da As New SqlDataAdapter(cmd)
            Dim dr As SqlDataReader = cmd.ExecuteReader
            If dr.HasRows Then
                While dr.Read
                    txtDestCity.Text = dr("City").ToString
                    txtDestCountry.Text = dr("Country").ToString
                    txtPackRemarks.Text = dr("Packing_Remarks").ToString
                    ddlTransportMode.SelectedIndex = ddlTransportMode.Items.IndexOf(ddlTransportMode.Items.FindByValue(dr("Transit_Mode").ToString))
                    Dim dtrow As DataRow = dt.NewRow
                    dtrow("ShadeCode") = dr("Shade").ToString
                    dtrow("Quantity") = dr("Quantity").ToString
                    dtrow("DispatchDate") = dr("Dispatch_Date").ToString
                    dtrow("AdvisedDate") = dr("Advised_Date").ToString
                    dtrow("CustomerApproval") = dr("CustomerApproval").ToString
                    dt.Rows.Add(dtrow)
                    If dr("Approval_Status").ToString <> "" Then
                        lblScheduleStatus.Text = dr("Approval_Status").ToString
                    End If

                End While
            End If
        Else

            'CalculateUnAllocatedQty()
            'CalculateAllocatedQty()

        End If

        ViewState.Add("data", dt)
        grdDispatchDetail.DataSource = dt
        grdDispatchDetail.DataBind()

    End Sub

    Protected Sub grdShades_RowDeleting(sender As Object, e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles grdDispatchDetail.RowDeleting

        Dim row As String = e.RowIndex 'grdItems.SelectedRow.RowIndex.ToString

        Dim dt As DataTable = CType(ViewState("data"), DataTable)
        dt.Rows.RemoveAt(row)
        grdDispatchDetail.DataSource = dt
        grdDispatchDetail.DataBind()
        ViewState("data") = dt

        'CalculateAllocatedQty()
        'CalculateUnAllocatedQty()

    End Sub

    Protected Sub ImageButton1_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs)
        Dim img As ImageButton = TryCast(sender, ImageButton)
        Dim grow As GridViewRow = DirectCast(img.NamingContainer, GridViewRow)

        Dim row As String = grow.RowIndex 'grdItems.SelectedRow.RowIndex.ToString

        Dim dt As DataTable = CType(ViewState("data"), DataTable)
        dt.Rows.RemoveAt(row)
        grdDispatchDetail.DataSource = dt
        grdDispatchDetail.DataBind()
        ViewState("data") = dt

        'CalculateAllocatedQty()
        'CalculateUnAllocatedQty()
    End Sub

    Protected Sub CalculateUnAllocatedQty()

        Dim sqlstr As String = "jct_ops_get_quote_qty '" & lblQuotationNo.Text & "', '" & ddlDispatchShade.SelectedItem.Value & "'"
        Dim dr As SqlDataReader = ofn.FetchReader(sqlstr)
        Dim unallocated_qty As Long = 0
        Dim allocated_qty As Long = 0

        For Each drow As GridViewRow In grdDispatchDetail.Rows
            If (drow.Cells(1).Text = ddlDispatchShade.SelectedItem.Text) Then
                allocated_qty = allocated_qty + Val(drow.Cells(2).Text)
            End If
        Next

        If dr.HasRows Then
            While dr.Read
                unallocated_qty = unallocated_qty + dr("quantity")
            End While

        End If

        lblUnallocatedQty.Text = unallocated_qty - allocated_qty
        lblAllocatedQty.Text = allocated_qty

    End Sub

    'Protected Sub CalculateAllocatedQty()

    '    For Each drow As GridViewRow In grdDispatchDetail.Rows
    '        If (drow.Cells(1).Text = ddlDispatchShade.SelectedItem.Text) Then
    '            lblAllocatedQty.Text = Val(lblAllocatedQty.Text) + Val(drow.Cells(2).Text)
    '        End If

    '    Next

    'End Sub

    Protected Sub ddlDispatchShade_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlDispatchShade.SelectedIndexChanged
        lblUnallocatedQty.Text = ""
        lblAllocatedQty.Text = ""
        CalculateUnAllocatedQty()
        'CalculateAllocatedQty()

    End Sub

    Protected Sub ibtBasicInfo_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles ibtBasicInfo.Click
        Response.Redirect("Quotation_Main.aspx?quot=" & lblQuotationNo.Text)

    End Sub

    Protected Sub ibtShadeQty_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles ibtShadeQty.Click
        Response.Redirect("Quotation_Qty.aspx?quot=" & lblQuotationNo.Text)

    End Sub

    Protected Sub ibtPayTerms_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles ibtPayTerms.Click
        Response.Redirect("Quotation_Pay_Terms.aspx?quot=" & lblQuotationNo.Text)

    End Sub

    Protected Sub yearMonth()
        Dim sql As String
        Dim mon As String
        sql = "Select month(getdate())"
        mon = ofn.FetchValue(sql).ToString()
        Dim mon1 As Int16 = Int16.Parse(mon)
        If mon1 < 10 Then

            mon = "0" + mon
        End If
        sql = "Select year(getdate())"
        Dim year As String = ofn.FetchValue(sql).ToString()
        Dim yearmonth As String = year + mon
        ' Dim year_month As Decimal = Decimal.Parse(yearmonth)
        ViewState("Month") = mon
        ViewState("Year") = year
    End Sub

    Protected Sub FillDropDown()

        yearMonth()
        ddlMonth1.SelectedIndex = ddlMonth1.Items.IndexOf(ddlMonth1.Items.FindByValue(ViewState("Month").ToString()))
        ddlMonth2.SelectedIndex = ddlMonth2.Items.IndexOf(ddlMonth2.Items.FindByValue(ViewState("Month").ToString()))
        ddlMonth3.SelectedIndex = ddlMonth3.Items.IndexOf(ddlMonth3.Items.FindByValue(ViewState("Month").ToString()))

        ddlYear1.SelectedIndex = ddlYear1.Items.IndexOf(ddlYear1.Items.FindByText(ViewState("Year").ToString()))
        ddlYear2.SelectedIndex = ddlYear2.Items.IndexOf(ddlYear2.Items.FindByText(ViewState("Year").ToString()))
        ddlYear3.SelectedIndex = ddlYear3.Items.IndexOf(ddlYear3.Items.FindByText(ViewState("Year").ToString()))

    End Sub

    Protected Sub lnkDispatchSch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkDispatchSch.Click
        If (pnlCharts.Visible = False) Then

            pnlCharts.Visible = True

            Dim sql As String

            FillDropDown()

            ViewState("YearMonth") = ViewState("Year") + ViewState("Month")

            sql = "JCT_OPS_SHEDWISE_ITEM_DISPATCH_DATE"

            PopulateBarChart1(sql, Chart2)

            Panel4.Visible = True

            sql = "Exec JCT_OPS_SHEDWISE_ITEM_TOTAL_PLANNED_DAYS " + ViewState("YearMonth")
            Dim chartType As String = "Planned"
            Dim title1 As String = "Plant Capacity Vs Planned Items"
            PopulateBarChart(sql, Chart3, title1, chartType)

            sql = "Exec JCT_OPS_SHEDWISE_ITEM_TOTAL_UNPLANNED_DAYS " + ViewState("YearMonth")
            Dim title As String = "Plant Capacity Vs UnPlanned Items"
            chartType = "UnPlanned"
            PopulateBarChart(sql, Chart4, title, chartType)
            Panel3.Visible = True


        End If

    End Sub

    Public Sub PopulateBarChart(ByVal sql As String, ByRef chart As Chart, ByVal Title As String, ByVal ChartType As String)
        Try
            chart.Series.Clear()

            cmd = New SqlCommand(sql, obj.Connection)
            Dim SqlReader As SqlDataReader = cmd.ExecuteReader()
            Dim ds As DataSet = New DataSet
            ' Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
            'da.Fill(ds, "Bind")
            ds.Tables.Add()
            ds.Load(SqlReader, LoadOption.OverwriteChanges, ds.Tables(0))
            chart.DataSource = ds
            Dim i As Int16 = 0
            Dim row As DataRow
            chart.Titles(0).Text = Title
            chart.Titles(0).Font = New Font("Times New Roman", 12, FontStyle.Bold)
            chart.Titles(0).Alignment = System.Drawing.ContentAlignment.MiddleCenter
            chart.Titles(0).ToolTip = Title
            If (ChartType.ToString() = "Planned") Then

                For Each row In ds.Tables(0).Rows
                    If (row("Parameter").ToString() = "Capacity") Then
                        Dim seriesName As String = row("Parameter").ToString
                        chart.Series.Add(seriesName)

                        chart.Series(seriesName)("PointWidth") = "0.3"

                        chart.Series(seriesName)("DrawingStyle") = "Cylinder"

                        chart.Series(seriesName)("ShowMarkerLines") = "True"

                        chart.Series(seriesName).BorderWidth = 1

                        chart.Series(seriesName).MarkerStyle = MarkerStyle.None

                        Dim colIndex As Integer
                        For colIndex = 1 To (ds.Tables(0).Columns.Count) - 1
                            Dim columnName As String = ds.Tables(0).Columns(colIndex).ColumnName
                            Dim YVal As Integer = CInt(row(columnName))
                            chart.Series(seriesName).ToolTip = " Production per Month : #VALY meters"
                            chart.Series(seriesName).Label = "#VALY"

                            chart.Series(seriesName).Points.AddXY(columnName, YVal)
                        Next colIndex

                    ElseIf (row("Parameter").ToString() = "MtrsLeft") Then
                        Dim seriesName As String = row("Parameter").ToString
                        chart.Series.Add(seriesName)

                        chart.Series(seriesName)("PointWidth") = "0.3"

                        chart.Series(seriesName)("DrawingStyle") = "Cylinder"

                        chart.Series(seriesName)("ShowMarkerLines") = "True"

                        chart.Series(seriesName).BorderWidth = 1

                        chart.Series(seriesName).MarkerStyle = MarkerStyle.None

                        Dim colIndex As Integer
                        For colIndex = 1 To (ds.Tables(0).Columns.Count) - 1
                            ' for each column (column 1 and onward), add the value as a point
                            Dim columnName As String = ds.Tables(0).Columns(colIndex).ColumnName
                            Dim YVal As Integer = CInt(row(columnName))
                            chart.Series(seriesName).ToolTip = "Production in Progress : #VALY meters"
                            chart.Series(seriesName).Label = "#VALY"

                            chart.Series(seriesName).Points.AddXY(columnName, YVal)
                        Next colIndex
                    End If

                Next row

                chart.ChartAreas("ChartArea1").AxisX.Title = "Loom Shed"
                chart.ChartAreas("ChartArea1").AxisX.TitleFont = New Font("Times New Roman", 12, FontStyle.Bold)
                chart.ChartAreas("ChartArea1").AxisY.Title = "Length (in Mtrs)"
                chart.ChartAreas("ChartArea1").AxisX.TitleFont = New Font("Times New Roman", 12, FontStyle.Bold)
                chart.DataBind()

            ElseIf (ChartType.ToString() = "UnPlanned") Then

                For Each row In ds.Tables(0).Rows
                    If (row("Parameter").ToString() = "Capacity") Then
                        Dim seriesName As String = row("Parameter").ToString
                        chart.Series.Add(seriesName)
                        chart.Series(seriesName)("PointWidth") = "0.3"
                        chart.Series(seriesName)("DrawingStyle") = "Cylinder"
                        chart.Series(seriesName)("ShowMarkerLines") = "True"
                        chart.Series(seriesName).BorderWidth = 1
                        chart.Series(seriesName).MarkerStyle = MarkerStyle.None

                        Dim colIndex As Integer
                        For colIndex = 1 To (ds.Tables(0).Columns.Count) - 1
                            ' for each column (column 1 and onward), add the value as a point
                            Dim columnName As String = ds.Tables(0).Columns(colIndex).ColumnName
                            Dim YVal As Integer = CInt(row(columnName))
                            chart.Series(seriesName).ToolTip = " Production per Month : #VALY meters"
                            chart.Series(seriesName).Label = "#VALY"

                            chart.Series(seriesName).Points.AddXY(columnName, YVal)
                        Next colIndex

                    ElseIf (row("Parameter").ToString() = "MtrsLeft") Then
                        Dim seriesName As String = row("Parameter").ToString
                        chart.Series.Add(seriesName)
                        chart.Series(seriesName)("PointWidth") = "0.3"
                        chart.Series(seriesName)("DrawingStyle") = "Cylinder"
                        chart.Series(seriesName)("ShowMarkerLines") = "True"
                        chart.Series(seriesName).BorderWidth = 1
                        chart.Series(seriesName).MarkerStyle = MarkerStyle.None

                        Dim colIndex As Integer
                        For colIndex = 1 To (ds.Tables(0).Columns.Count) - 1
                            ' for each column (column 1 and onward), add the value as a point
                            Dim columnName As String = ds.Tables(0).Columns(colIndex).ColumnName
                            Dim YVal As Integer = CInt(row(columnName))
                            chart.Series(seriesName).ToolTip = "Planned for the next month : #VALY meters"
                            chart.Series(seriesName).Label = "#VALY"

                            chart.Series(seriesName).Points.AddXY(columnName, YVal)
                        Next colIndex
                    End If

                Next row

                chart.ChartAreas("ChartArea1").AxisX.Title = "Loom Shed"
                chart.ChartAreas("ChartArea1").AxisX.TitleFont = New Font("Times New Roman", 12, FontStyle.Bold)
                chart.ChartAreas("ChartArea1").AxisY.Title = "Length (in Mtrs)"
                chart.ChartAreas("ChartArea1").AxisX.TitleFont = New Font("Times New Roman", 12, FontStyle.Bold)
                chart.DataBind()
            End If

        Catch ex As Exception

        Finally
            obj.ConClose()
        End Try

    End Sub

    Public Sub PopulateBarChart1(ByVal sql As String, ByRef chart As Chart)

        Try
            chart.Series.Clear()

            cmd = New SqlCommand(sql, obj.Connection)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 60
            cmd.Parameters.Add("@Quotation", SqlDbType.VarChar, 20).Value = Request.QueryString("quot")
            cmd.Parameters.Add("@YearMonth", SqlDbType.Decimal).Value = Convert.ToDecimal(ViewState("YearMonth").ToString())

            Dim SqlReader As SqlDataReader = cmd.ExecuteReader()
            Dim ds As DataSet = New DataSet
            ' Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
            'da.Fill(ds, "Bind")
            ds.Tables.Add()
            ds.Load(SqlReader, LoadOption.OverwriteChanges, ds.Tables(0))
            chart.DataSource = ds
            Dim i As Int16 = 0
            Dim row As DataRow
            ' Set chart title

            chart.Titles(0).Text = "Loom Shed Status"
            chart.Titles(0).Font = New Font("Times New Roman", 12, FontStyle.Bold)
            chart.Titles(0).Alignment = System.Drawing.ContentAlignment.MiddleCenter
            chart.Titles(0).ToolTip = Title

            For Each row In ds.Tables(0).Rows
                Dim seriesName As String = row("Parameter").ToString
                chart.Series.Add(seriesName)
                chart.Series(seriesName)("PointWidth") = "0.3"
                chart.Series(seriesName)("DrawingStyle") = "Cylinder"
                chart.Series(seriesName)("ShowMarkerLines") = "True"
                chart.Series(seriesName).BorderWidth = 1
                chart.Series(seriesName).MarkerStyle = MarkerStyle.None

                Dim colIndex As Integer
                For colIndex = 1 To (ds.Tables(0).Columns.Count) - 1
                    ' for each column (column 1 and onward), add the value as a point
                    Dim columnName As String = ds.Tables(0).Columns(colIndex).ColumnName
                    Dim YVal As Integer = CInt(row(columnName))
                    chart.Series(seriesName).ToolTip = " #VALX booked for #VALY days."
                    chart.Series(seriesName).Label = "#VALY"
                    chart.Series(seriesName).Points.AddXY(columnName, YVal)
                Next colIndex

            Next row

            chart.ChartAreas("ChartArea1").AxisX.Title = "Loom Shed"
            chart.ChartAreas("ChartArea1").AxisX.TitleFont = New Font("Times New Roman", 12, FontStyle.Bold)
            chart.ChartAreas("ChartArea1").AxisY.Title = "Days Booked"
            chart.ChartAreas("ChartArea1").AxisX.TitleFont = New Font("Times New Roman", 12, FontStyle.Bold)

            chart.DataBind()
        Catch ex As Exception

        Finally
            obj.ConClose()
        End Try
    End Sub

    Protected Sub Chart2_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles Chart2.DataBound

    End Sub

    'Protected Sub lnkDispatchSch0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkDispatchSch0.Click
    '    'Panel3.Visible = True
    '    'Dim sql As String

    '    '' sql = "Exec JCT_OPS_SHEDWISE_ITEM_DISPATCH_DATE '" + lblQuotationNo.Text + "'"
    '    'sql = "Exec JCT_OPS_SHEDWISE_ITEM_TOTAL_PLANNED_DAYS"
    '    '' sql = "jct_ops_check_dispatch_schedule 'V-04328'"

    '    'PopulateBarChart(sql, Chart3)
    'End Sub

    'Protected Sub lnkDispatchSch1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkDispatchSch1.Click
    '    'Panel4.Visible = True
    '    'Dim sql As String

    '    '' sql = "Exec JCT_OPS_SHEDWISE_ITEM_DISPATCH_DATE '" + lblQuotationNo.Text + "'"
    '    'sql = "Exec JCT_OPS_SHEDWISE_ITEM_TOTAL_UNPLANNED_DAYS"
    '    '' sql = "jct_ops_check_dispatch_schedule 'V-04328'"

    '    'PopulateBarChart(sql, Chart4)
    'End Sub



    Protected Sub ddlYear1_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlYear1.SelectedIndexChanged

        If (ddlYear1.SelectedItem.Value <> 0) Then

            ViewState("Year") = ddlYear1.SelectedItem.Value
            ViewState("Month") = ddlMonth1.SelectedItem.Value
            ViewState("YearMonth") = ViewState("Year") + ViewState("Month")
            Dim sql As String
            sql = "JCT_OPS_SHEDWISE_ITEM_DISPATCH_DATE"
            PopulateBarChart1(sql, Chart2)


            ViewState("Year") = ddlYear2.SelectedItem.Value
            ViewState("Month") = ddlMonth2.SelectedItem.Value
            ViewState("YearMonth") = ViewState("Year") + ViewState("Month")
            sql = "Exec JCT_OPS_SHEDWISE_ITEM_TOTAL_PLANNED_DAYS " + ViewState("YearMonth")
            Dim chartType As String = "Planned"
            Dim title1 As String = "Plant Capacity Vs Planned Items"
            PopulateBarChart(sql, Chart3, title1, chartType)


            ViewState("Year") = ddlYear3.SelectedItem.Value
            ViewState("Month") = ddlMonth3.SelectedItem.Value
            ViewState("YearMonth") = ViewState("Year") + ViewState("Month")
            sql = "Exec JCT_OPS_SHEDWISE_ITEM_TOTAL_UNPLANNED_DAYS " + ViewState("YearMonth")
            Dim title As String = "Plant Capacity Vs UnPlanned Items"
            chartType = "UnPlanned"
            PopulateBarChart(sql, Chart4, title, chartType)
            Panel3.Visible = True

        End If

    End Sub

    Protected Sub ddlMonth1_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlMonth1.SelectedIndexChanged

        If (ddlMonth1.SelectedItem.Value <> 0) Then

            ViewState("Year") = ddlYear1.SelectedItem.Value
            ViewState("Month") = ddlMonth1.SelectedItem.Value
            ViewState("YearMonth") = ViewState("Year") + ViewState("Month")
            Dim sql As String
            sql = "JCT_OPS_SHEDWISE_ITEM_DISPATCH_DATE"
            PopulateBarChart1(sql, Chart2)

            ViewState("Year") = ddlYear2.SelectedItem.Value
            ViewState("Month") = ddlMonth2.SelectedItem.Value
            ViewState("YearMonth") = ViewState("Year") + ViewState("Month")
            sql = "Exec JCT_OPS_SHEDWISE_ITEM_TOTAL_PLANNED_DAYS " + ViewState("YearMonth")
            Dim chartType As String = "Planned"
            Dim title1 As String = "Plant Capacity Vs Planned Items"
            PopulateBarChart(sql, Chart3, title1, chartType)

            ViewState("Year") = ddlYear3.SelectedItem.Value
            ViewState("Month") = ddlMonth3.SelectedItem.Value
            ViewState("YearMonth") = ViewState("Year") + ViewState("Month")
            sql = "Exec JCT_OPS_SHEDWISE_ITEM_TOTAL_UNPLANNED_DAYS " + ViewState("YearMonth")
            Dim title As String = "Plant Capacity Vs UnPlanned Items"
            chartType = "UnPlanned"
            PopulateBarChart(sql, Chart4, title, chartType)
            Panel3.Visible = True


        End If

    End Sub

    Protected Sub ddlYear2_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlYear2.SelectedIndexChanged
        If (ddlYear2.SelectedItem.Value <> 0) Then

            ViewState("Year") = ddlYear2.SelectedItem.Value
            ViewState("Month") = ddlMonth2.SelectedItem.Value
            ViewState("YearMonth") = ViewState("Year") + ViewState("Month")
            Dim sql As String
            sql = "Exec JCT_OPS_SHEDWISE_ITEM_TOTAL_PLANNED_DAYS " + ViewState("YearMonth")
            Dim chartType As String = "Planned"
            Dim title1 As String = "Plant Capacity Vs Planned Items"
            PopulateBarChart(sql, Chart3, title1, chartType)


            ViewState("Year") = ddlYear3.SelectedItem.Value
            ViewState("Month") = ddlMonth3.SelectedItem.Value
            ViewState("YearMonth") = ViewState("Year") + ViewState("Month")
            sql = "Exec JCT_OPS_SHEDWISE_ITEM_TOTAL_UNPLANNED_DAYS " + ViewState("YearMonth")
            Title = "Plant Capacity Vs UnPlanned Items"
            chartType = "UnPlanned"
            PopulateBarChart(sql, Chart4, Title, chartType)
            Panel3.Visible = True

            ViewState("Year") = ddlYear1.SelectedItem.Value
            ViewState("Month") = ddlMonth1.SelectedItem.Value
            ViewState("YearMonth") = ViewState("Year") + ViewState("Month")
            sql = "JCT_OPS_SHEDWISE_ITEM_DISPATCH_DATE"
            PopulateBarChart1(sql, Chart2)

        End If
    End Sub

    Protected Sub ddlMonth2_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlMonth2.SelectedIndexChanged

        If (ddlMonth2.SelectedItem.Value <> 0) Then

            ViewState("Year") = ddlYear2.SelectedItem.Value
            ViewState("Month") = ddlMonth2.SelectedItem.Value
            ViewState("YearMonth") = ViewState("Year") + ViewState("Month")
            Dim sql As String
            sql = "Exec JCT_OPS_SHEDWISE_ITEM_TOTAL_PLANNED_DAYS " + ViewState("YearMonth")
            Dim chartType As String = "Planned"
            Dim title1 As String = "Plant Capacity Vs Planned Items"
            PopulateBarChart(sql, Chart3, title1, chartType)



            ViewState("Year") = ddlYear3.SelectedItem.Value
            ViewState("Month") = ddlMonth3.SelectedItem.Value
            ViewState("YearMonth") = ViewState("Year") + ViewState("Month")

            sql = "Exec JCT_OPS_SHEDWISE_ITEM_TOTAL_UNPLANNED_DAYS " + ViewState("YearMonth")
            Dim title As String = "Plant Capacity Vs UnPlanned Items"
            chartType = "UnPlanned"
            PopulateBarChart(sql, Chart4, title, chartType)
            Panel3.Visible = True

            ViewState("Year") = ddlYear1.SelectedItem.Value
            ViewState("Month") = ddlMonth1.SelectedItem.Value
            ViewState("YearMonth") = ViewState("Year") + ViewState("Month")
            sql = "JCT_OPS_SHEDWISE_ITEM_DISPATCH_DATE"
            PopulateBarChart1(sql, Chart2)

        End If
    End Sub

    Protected Sub ddlYear3_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlYear3.SelectedIndexChanged

        If (ddlYear3.SelectedItem.Value <> 0) Then

            ViewState("Year") = ddlYear3.SelectedItem.Value
            ViewState("Month") = ddlMonth3.SelectedItem.Value
            ViewState("YearMonth") = ViewState("Year") + ViewState("Month")
            Dim sql As String
            sql = "Exec JCT_OPS_SHEDWISE_ITEM_TOTAL_UNPLANNED_DAYS " + ViewState("YearMonth")
            Dim title As String = "Plant Capacity Vs UnPlanned Items"
            Dim chartType As String = "UnPlanned"
            PopulateBarChart(sql, Chart4, title, chartType)
            Panel3.Visible = True

            ViewState("Year") = ddlYear2.SelectedItem.Value
            ViewState("Month") = ddlMonth2.SelectedItem.Value
            ViewState("YearMonth") = ViewState("Year") + ViewState("Month")
            sql = "Exec JCT_OPS_SHEDWISE_ITEM_TOTAL_PLANNED_DAYS " + ViewState("YearMonth")
            chartType = "Planned"
            Dim title1 As String = "Plant Capacity Vs Planned Items"
            PopulateBarChart(sql, Chart3, title1, chartType)

            ViewState("Year") = ddlYear1.SelectedItem.Value
            ViewState("Month") = ddlMonth1.SelectedItem.Value
            ViewState("YearMonth") = ViewState("Year") + ViewState("Month")
            sql = "JCT_OPS_SHEDWISE_ITEM_DISPATCH_DATE"
            PopulateBarChart1(sql, Chart2)

        End If

    End Sub

    Protected Sub ddlMonth3_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlMonth3.SelectedIndexChanged

        If (ddlMonth3.SelectedItem.Value <> 0) Then

            ViewState("Year") = ddlYear3.SelectedItem.Value
            ViewState("Month") = ddlMonth3.SelectedItem.Value
            ViewState("YearMonth") = ViewState("Year") + ViewState("Month")
            Dim sql As String
            sql = "Exec JCT_OPS_SHEDWISE_ITEM_TOTAL_UNPLANNED_DAYS " + ViewState("YearMonth")
            Dim title As String = "Plant Capacity Vs UnPlanned Items"
            Dim chartType As String = "UnPlanned"
            PopulateBarChart(sql, Chart4, title, chartType)
            Panel3.Visible = True


            ViewState("Year") = ddlYear2.SelectedItem.Value
            ViewState("Month") = ddlMonth2.SelectedItem.Value
            ViewState("YearMonth") = ViewState("Year") + ViewState("Month")
            sql = "Exec JCT_OPS_SHEDWISE_ITEM_TOTAL_PLANNED_DAYS " + ViewState("YearMonth")
            chartType = "Planned"
            Dim title1 As String = "Plant Capacity Vs Planned Items"
            PopulateBarChart(sql, Chart3, title1, chartType)

            ViewState("Year") = ddlYear1.SelectedItem.Value
            ViewState("Month") = ddlMonth1.SelectedItem.Value
            ViewState("YearMonth") = ViewState("Year") + ViewState("Month")
            sql = "JCT_OPS_SHEDWISE_ITEM_DISPATCH_DATE"
            PopulateBarChart1(sql, Chart2)

        End If

    End Sub

    Protected Sub cmdReset_Click(sender As Object, e As System.EventArgs) Handles cmdReset.Click
        grdDispatchDetail.DataSource = Nothing
        grdDispatchDetail.DataBind()
        lblAllocatedQty.Text = "0"
        lblUnallocatedQty.Text = "0"
        lblMessage.Text = ""

        Dim dt As DataTable = CType(ViewState("data"), DataTable)
        dt.Rows.Clear()
        grdDispatchDetail.DataSource = dt
        grdDispatchDetail.DataBind()
        ViewState("data") = dt

    End Sub

    Protected Sub cmdPickSchedule_Click(sender As Object, e As System.EventArgs) Handles cmdPickSchedule.Click

        For Each row As GridViewRow In grdDispatchDetail.Rows
            row.Cells(3).Text = row.Cells(4).Text
        Next
        
        Dim con As New Connection
        Dim sql As String = "jct_ops_quote_pick_advised_dispatch_sch"
        Dim tran As SqlTransaction
        tran = con.Connection.BeginTransaction()
        Try

            For Each row As GridViewRow In grdDispatchDetail.Rows

                Dim cmd As SqlCommand = New SqlCommand(sql, con.Connection, tran)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.Add("Quotation_No", SqlDbType.VarChar, 20)
                cmd.Parameters.Add("Shade", SqlDbType.VarChar, 100)
                cmd.Parameters.Add("Quantity", SqlDbType.Float, 100)
                cmd.Parameters.Add("Advised_Date", SqlDbType.DateTime)

                cmd.Parameters("Quotation_No").Value = lblQuotationNo.Text
                cmd.Parameters("Shade").Value = row.Cells(1).Text
                cmd.Parameters("Quantity").Value = row.Cells(2).Text
                'Dim adv_date As String = CType(row.FindControl("txtAdvisedDate"), TextBox).Text
                cmd.Parameters("Advised_Date").Value = row.Cells(4).Text
                
                cmd.ExecuteNonQuery()

            Next
            tran.Commit()
            lblMessage.Text = "Advised Schedule for Quotation No. " & lblQuotationNo.Text & " has been picked and saved for this quotation."
        Catch ex As Exception
            tran.Rollback()

        End Try

    End Sub

    Protected Sub cmdRefresh_Click(sender As Object, e As System.EventArgs) Handles cmdRefresh.Click
        grdDispatchDetail.DataBind()

    End Sub

    Protected Sub lnkForwardToPPC_Click(sender As Object, e As System.EventArgs) Handles lnkForwardToPPC.Click

        If grdDispatchDetail.Rows.Count = 0 Then
            lblMessage.Text = "Please save "
        End If

        Dim sql As String = "jct_ops_forward_quot_dispatch_sch"
        Dim con As New Connection
        Dim tran As SqlTransaction
        tran = con.Connection.BeginTransaction()
        Try

            For Each row As GridViewRow In grdDispatchDetail.Rows

                Dim cmd As SqlCommand = New SqlCommand(sql, con.Connection, tran)
                cmd.CommandType = CommandType.StoredProcedure

                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.Add("User_Code", SqlDbType.VarChar, 20)
                cmd.Parameters.Add("Quotation_No", SqlDbType.VarChar, 20)
                cmd.Parameters.Add("Shade", SqlDbType.VarChar, 100)
                cmd.Parameters.Add("Quantity", SqlDbType.Float, 100)
                cmd.Parameters.Add("Dispatch_Date", SqlDbType.DateTime)
                cmd.Parameters.Add("Action_Status", SqlDbType.VarChar, 20)
                cmd.Parameters.Add("Remark", SqlDbType.VarChar, 2000)

                cmd.Parameters("User_Code").Value = Session("EmpCode").ToString
                cmd.Parameters("Quotation_No").Value = lblQuotationNo.Text
                cmd.Parameters("Shade").Value = row.Cells(1).Text
                cmd.Parameters("Quantity").Value = row.Cells(2).Text
                cmd.Parameters("Dispatch_Date").Value = row.Cells(3).Text
                cmd.Parameters("Action_Status").Value = "MktAuth"
                cmd.Parameters("Remark").Value = txtRemarks.Text

                cmd.ExecuteNonQuery()

            Next
            tran.Commit()

            lblMessage.Text = "Quotation No. " & lblQuotationNo.Text & " has been forwarded to PPC for Approval/Advise."
            Try

                Dim sm As New SendMail
                Dim subject As String = "Required Approval/Advise regarding Dispatch Schedule of Quotation No. " + lblQuotationNo.Text + " - " + Session("EmpCode").ToString
                Dim body As String = "Please provide advise or approve the dispatch schedule of Quotation # <a href = 'http://misdev/fusionapps/ops/Quotation_Dispatch_Sch.aspx?quot=" & lblQuotationNo.Text & "'> " & lblQuotationNo.Text & "</a> <br/> Click on Quotation Number to view details."

                sql = "jct_ops_get_quot_mail_recipients"
                Dim cmd As SqlCommand = New SqlCommand(sql, con.Connection)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.Add("Quotation_No", SqlDbType.VarChar, 16)
                cmd.Parameters("Quotation_No").Value = lblQuotationNo.Text
                cmd.Parameters.Add("Action", SqlDbType.VarChar, 20)
                cmd.Parameters("Action").Value = "MktAuth"
                cmd.Parameters.Add("User_Code", SqlDbType.VarChar, 10)
                cmd.Parameters("User_Code").Value = Session("EmpCode").ToString
                Dim dr As SqlDataReader
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                Dim recipients, m_sender As String
                recipients = ""
                m_sender = ""
                If dr.HasRows Then
                    While dr.Read
                        If dr(0).ToString = "To" Then
                            recipients += dr("e_mailid").ToString + ";"
                        ElseIf dr(0).ToString = "From" Then
                            m_sender = dr("e_mailid").ToString
                        End If
                    End While
                End If
                dr.Close()
                Dim bcc As String = "rbaksshi@jctltd.com; jagdeep@jctltd.com; harendra@jctltd.com"
                sm.SendMail2(recipients, "", bcc, "noreply@jctltd.com", subject, body)
                'sm.SendMail("rbaksshi@jctltd.com; jagdeep@jctltd.com; harendra@jctltd.com", "noreply@jctltd.com", subject, body)
                lblMessage.Text += lblMessage.Text + "<br/>E-Mail has also been floated to the concerned person(s)."
                sm.SendMail2(m_sender, "", bcc, "noreply@jctltd.com", subject, body)

                '--------------------------------

                'sql = "jct_fap_mistel_detail"
                'cmd = New SqlCommand(sql, con.Connection)
                'cmd.Parameters.Add("EmpCode", SqlDbType.VarChar, 16)
                'cmd.Parameters("EmpCode").Value = Session("EmpCode").ToString
                'dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)

                'If dr.HasRows Then
                '    While dr.Read
                '        recipients += dr("e_mailid") + ";"

                '    End While
                'End If

                'sm.SendMail(recipients, "", "jagdeep@jctltd.com", "noreply@jctltd.com", subject, body)
                '--------------------------------

            Catch ex As Exception
                lblMessage.Text += lblMessage.Text + "<br/>Error Occurred while sending E-Mail to the concerned person(s)."
            End Try

        Catch ex As Exception
            tran.Rollback()
            lblMessage.Text = "Error occurred while forwarding request to concerned for Dispatch Approval/Advise."
        End Try
    End Sub

End Class
