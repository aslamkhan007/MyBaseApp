Imports System.Data
Imports System.Data.SqlClient

Partial Class OPS_MontlyCollections
    Inherits System.Web.UI.Page

    Protected Sub cmdView_Click(sender As Object, e As System.EventArgs) Handles cmdView.Click

        grdCollection.DataSource = SqlDataSource1
        grdCollection.DataBind()

        grdDailyCollection.DataSource = SqlDataSource2
        grdDailyCollection.DataBind()

        grdCustomerWiseCollection.DataSource = SqlDataSource3
        grdCustomerWiseCollection.DataBind()

    End Sub

    Protected Sub SqlDataSource1_Selecting(sender As Object, e As System.Web.UI.WebControls.SqlDataSourceSelectingEventArgs) Handles SqlDataSource1.Selecting
        e.Command.CommandTimeout = 10000

    End Sub

    Protected Sub SqlDataSource2_Selecting(sender As Object, e As System.Web.UI.WebControls.SqlDataSourceSelectingEventArgs) Handles SqlDataSource2.Selecting
        e.Command.CommandTimeout = 10000

    End Sub

    Protected Sub SqlDataSource3_Selecting(sender As Object, e As System.Web.UI.WebControls.SqlDataSourceSelectingEventArgs) Handles SqlDataSource3.Selecting
        e.Command.CommandTimeout = 10000

    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            ddlDateFrom.Items.Clear()
            For i As Integer = 0 To 24
                Dim dt As DateTime = DateTime.Now.AddMonths(-i)
                Dim month As String = dt.ToString("MMM")
                Dim year As String = dt.ToString("yyyy")
                Dim list_text = month.ToString + " " + year.ToString
                Dim list_value = dt.Year.ToString + "-" + dt.ToString("MM") + "-" + "01"
                Dim li As ListItem = New ListItem(list_text, list_value)
                ddlDateFrom.Items.Add(li)

            Next

            ddlDateTo.Items.Clear()
            For i As Integer = 0 To 24
                Dim dt As DateTime = DateTime.Now.AddMonths(-i)
                Dim month As String = dt.ToString("MMM")
                Dim year As String = dt.ToString("yyyy")
                Dim list_text = month.ToString + " " + year.ToString
                Dim list_value = dt.Year.ToString + "-" + dt.ToString("MM") + "-" + Date.DaysInMonth(dt.Year, dt.Month).ToString
                Dim li As ListItem = New ListItem(list_text, list_value)
                ddlDateTo.Items.Add(li)

            Next

            'For i As Integer = 0 To 12
            '    Dim dt As DateTime = DateTime.Now.AddMonths(-i)
            '    Dim month As String = dt.ToString("MMM")
            '    Dim list_text = month.ToString
            '    Dim list_value = i
            '    Dim li As ListItem = New ListItem(list_text, list_value)
            '    ddlMonth.Items.Add(li)
            'Next

            'ddlYear.Items.Add(DateTime.Now.Year)
            'ddlYear.Items.Add(DateTime.Now.Year - 1)

        End If

    End Sub

    Protected Sub grdCustomerWiseCollection_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdCustomerWiseCollection.RowDataBound
        e.Row.Cells(0).Visible = False
        e.Row.Cells(4).Width = WebControls.Unit.Pixel(400)

    End Sub

    Protected Sub cmdExportExcel_Click(sender As Object, e As System.EventArgs) Handles cmdExportExcel.Click

        'Dim obj As New Connection

        'Dim sql As String = "JCT_OPS_PLANNING_FREEZED_PLAN_DETAILS"
        'Dim cmd As New SqlCommand(sql, obj.Connection())
        'cmd.CommandType = CommandType.StoredProcedure
        'cmd.CommandTimeout = 0
        'cmd.Parameters.Add("@OrderNo", SqlDbType.VarChar, 20).Value = ""
        'cmd.Parameters.Add("@WeavingSort", SqlDbType.VarChar, 20).Value = ""
        'cmd.Parameters.Add("@PlanID", SqlDbType.Int).Value = ddlPlanID.SelectedItem.Value
        'cmd.Parameters.Add("@Shed", SqlDbType.VarChar, 20).Value = ""
        'cmd.Parameters.Add("@Customer", SqlDbType.VarChar, 20).Value = ""
        'cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 20).Value = ddlPlant.SelectedItem.Text
        'Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet()
        'da.Fill(ds)

        'ds = SqlDataSource3.Select(

        SqlDataSource3.SelectParameters("Plant").DefaultValue = ddlPlant.SelectedItem.Value
        SqlDataSource3.SelectParameters("FromDt").DefaultValue = ddlDateFrom.SelectedItem.Value
        SqlDataSource3.SelectParameters("ToDt").DefaultValue = ddlPlant.SelectedItem.Value

        Dim dv As DataView = SqlDataSource3.Select(DataSourceSelectArguments.Empty)

        Dim dt As DataTable = dv.ToTable

        'Dim dt As DataTable = SqlDataSource3.Select(DataSourceSelectArguments.Empty)

        Dim attachment As String = "attachment; filename=Customer_Collections.xls"
        Response.ClearContent()
        Response.AddHeader("content-disposition", attachment)
        Response.ContentType = "application/vnd.ms-excel"
        Dim tab As String = ""
        For Each dc As DataColumn In dt.Columns
            Response.Write(tab + dc.ColumnName)
            tab = vbTab
        Next
        Response.Write(vbLf)
        Dim i As Integer
        For Each dr As DataRow In dt.Rows
            tab = ""
            For i = 0 To dt.Columns.Count - 1
                Response.Write(tab + dr(i).ToString())
                tab = vbTab
            Next
            Response.Write(vbLf)
        Next
        Response.[End]()

        'obj.ConClose()

    End Sub

End Class
