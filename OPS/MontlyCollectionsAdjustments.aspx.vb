
Partial Class OPS_MontlyCollectionsAdjustments
    Inherits System.Web.UI.Page

    Protected Sub cmdView_Click(sender As Object, e As System.EventArgs) Handles cmdView.Click

        grdCollection.DataSource = SqlDataSource1
        grdCollection.DataBind()

        grdDailyCollection.DataSource = SqlDataSource2
        grdDailyCollection.DataBind()

        grdDailyInvoicing.DataSource = SqlDataSource3
        grdDailyInvoicing.DataBind()

        grdAdjustmentDetail.DataSource = SqlDataSource4
        grdAdjustmentDetail.DataBind()

        grdInvoiceAgeing.DataSource = SqlDataSource5
        grdInvoiceAgeing.DataBind()

       

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

    Protected Sub SqlDataSource4_Selecting(sender As Object, e As System.Web.UI.WebControls.SqlDataSourceSelectingEventArgs) Handles SqlDataSource4.Selecting
        e.Command.CommandTimeout = 10000

    End Sub

    Protected Sub SqlDataSource5_Selecting(sender As Object, e As System.Web.UI.WebControls.SqlDataSourceSelectingEventArgs) Handles SqlDataSource5.Selecting
        e.Command.CommandTimeout = 10000

    End Sub

    Protected Sub SqlDataSource6_Selecting(sender As Object, e As System.Web.UI.WebControls.SqlDataSourceSelectingEventArgs) Handles SqlDataSource6.Selecting
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

            For i As Integer = 0 To 12
                Dim dt As DateTime = DateTime.Now.AddMonths(-i)
                Dim month As String = dt.ToString("MMM")
                Dim list_text = month.ToString
                Dim list_value = i
                Dim li As ListItem = New ListItem(list_text, list_value)
                ddlMonth.Items.Add(li)
            Next

            ddlYear.Items.Add(DateTime.Now.Year)
            ddlYear.Items.Add(DateTime.Now.Year - 1)

        End If

    End Sub

    Protected Sub cmdViewOutstanding_Click(sender As Object, e As System.EventArgs) Handles cmdViewOutstanding.Click
        grdOutstandingsCustomer.DataSource = SqlDataSource6
        grdOutstandingsCustomer.DataBind()

    End Sub

    Protected Sub grdOutstandingsCustomer_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles grdOutstandingsCustomer.SelectedIndexChanged
        grdOutstandingsSP.DataSource = SqlDataSource7
        grdOutstandingsSP.DataBind()

    End Sub

    Protected Sub grdInvoiceAgeing_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdInvoiceAgeing.RowDataBound

        e.Row.Cells(0).Visible = False
        e.Row.Cells(1).Visible = False
        If e.Row.RowType = DataControlRowType.DataRow Then

            For i As Integer = 3 To 20 'grdInvoiceAgeing.Columns.Count - 1
                'e.Row.Cells(i).Text = Math.Round(Val(e.Row.Cells(i).Text) / 10000000, 3)
                Try
                    If IsNumeric(e.Row.Cells(i).Text) Then
                        If Not (e.Row.Cells(2).Text.Contains("%")) Then
                            'e.Row.Cells(i).Text = Format(Convert.ToDecimal(e.Row.Cells(i).Text), "#,##0.00")
                            e.Row.Cells(i).Text = Val(e.Row.Cells(i).Text) / 100000
                            e.Row.Cells(i).Text = Format(Convert.ToDecimal(e.Row.Cells(i).Text), "#,##0.00")
                        End If
                    End If
                Catch ex As Exception

                End Try
            Next

        End If

    End Sub

End Class
