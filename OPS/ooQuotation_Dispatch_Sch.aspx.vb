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
                cmd.ExecuteNonQuery()
                cf = "0"
            Next
            tr.Commit()
            lblMessage.Text = "Dispatch Schedule for Quotation No " & lblQuotationNo.Text & " Saved Successfully!"
        Catch ex As Exception
            tr.Rollback()
            'ofn.Alert(ex.Message)
            lblMessage.Text = ex.Message
        End Try

    End Sub

    Protected Sub ibtAddDispatchItem_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles ibtAddDispatchItem.Click

        If CDate(txtDispatchDate.Text) < DateTime.Now.AddDays(45) Then

        End If

        If Not ViewState("data") Is Nothing Then
            dt = ViewState("data")

        Else
            dt.Columns.Add("ShadeCode")
            dt.Columns.Add("Quantity")
            'dt.Columns.Add("UOM")
            dt.Columns.Add("DispatchDate")

        End If

        Dim drow As DataRow = dt.NewRow
        drow("ShadeCode") = ddlDispatchShade.SelectedItem.Value
        drow("Quantity") = txtDispatchQuantity.Text
        'drow("UOM") = ddlUom.SelectedItem.Value
        drow("DispatchDate") = txtDispatchDate.Text

        dt.Rows.Add(drow)

        ViewState.Add("data", dt)
        grdDispatchDetail.DataSource = dt
        grdDispatchDetail.DataBind()

        'CalculateAllocatedQty()
        CalculateUnAllocatedQty()

    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        lblQuotationNo.Text = Request.QueryString("quot")
        'txtDispatchDate.Text = DateTime.Now.AddDays(45).ToString

        If Not ViewState("data") Is Nothing Then
            dt = ViewState("data")

        Else
            dt.Columns.Add("ShadeCode")
            dt.Columns.Add("Quantity")
            'dt.Columns.Add("UOM")
            dt.Columns.Add("DispatchDate")

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
                    'dtrow("UOM") = dr("Uom")
                    dtrow("DispatchDate") = dr("Dispatch_Date").ToString
                    dt.Rows.Add(dtrow)
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

    Protected Sub lnkDispatchSch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkDispatchSch.Click
        If (pnlCharts.Visible = False) Then

            pnlCharts.Visible = True

            Dim sql As String

            sql = "Exec JCT_OPS_SHEDWISE_ITEM_DISPATCH_DATE   'QT/000011/2013'  "
            PopulateBarChart1(sql, Chart2)

            Panel4.Visible = True

            sql = "Exec JCT_OPS_SHEDWISE_ITEM_TOTAL_UNPLANNED_DAYS 201211"
            Dim title As String = "Plant Capacity Vs UnPlanned Items"
            Dim chartType As String = "UnPlanned"
            PopulateBarChart(sql, Chart4, title, chartType)
            Panel3.Visible = True

            sql = "Exec JCT_OPS_SHEDWISE_ITEM_TOTAL_PLANNED_DAYS 201211"
            chartType = "Planned"
            Dim title1 As String = "Plant Capacity Vs Planned Items"
            PopulateBarChart(sql, Chart3, title1, chartType)
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

    Protected Sub lnkDispatchSch0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkDispatchSch0.Click
        'Panel3.Visible = True
        'Dim sql As String

        '' sql = "Exec JCT_OPS_SHEDWISE_ITEM_DISPATCH_DATE '" + lblQuotationNo.Text + "'"
        'sql = "Exec JCT_OPS_SHEDWISE_ITEM_TOTAL_PLANNED_DAYS"
        '' sql = "jct_ops_check_dispatch_schedule 'V-04328'"

        'PopulateBarChart(sql, Chart3)
    End Sub

    Protected Sub lnkDispatchSch1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkDispatchSch1.Click
        'Panel4.Visible = True
        'Dim sql As String

        '' sql = "Exec JCT_OPS_SHEDWISE_ITEM_DISPATCH_DATE '" + lblQuotationNo.Text + "'"
        'sql = "Exec JCT_OPS_SHEDWISE_ITEM_TOTAL_UNPLANNED_DAYS"
        '' sql = "jct_ops_check_dispatch_schedule 'V-04328'"

        'PopulateBarChart(sql, Chart4)
    End Sub
End Class
