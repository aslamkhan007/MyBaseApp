
Partial Class SalesAnalysisSystem_Customer_Outstandings_Receipts
    Inherits System.Web.UI.Page

    Protected Sub RadioButtonList1_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles RadioButtonList1.SelectedIndexChanged
        SqlDataSource1.SelectParameters.Clear()
        SqlDataSource1.SelectCommand = RadioButtonList1.SelectedItem.Value
        SqlDataSource1.SelectCommandType = SqlDataSourceCommandType.StoredProcedure
        SqlDataSource1.SelectParameters.Add("From_Dt", hdfDateFrom.Value)
        SqlDataSource1.SelectParameters.Add("To_Dt", ddlDateTo.SelectedItem.Value)

        If RadioButtonList1.SelectedIndex = 0 Then
            GridView1.Visible = True
            GridView2.Visible = False
        ElseIf RadioButtonList1.SelectedIndex = 1 Then
            GridView2.Visible = True
            GridView1.Visible = False
        End If


        'LinkButton2.Attributes.Add("onclick", "window.open('popupgrid.aspx?datasource = " & RadioButtonList1.SelectedItem.Value & "','','status=1,toolbar=1,menubar=1,height=800,width=1000');return false")
    End Sub

    Protected Sub LinkButton1_Click(sender As Object, e As System.EventArgs) Handles LinkButton1.Click

        If RadioButtonList1.SelectedIndex = 0 Then
            GridViewExportUtil.Export(RadioButtonList1.SelectedItem.Text & ".xls", GridView1)
        ElseIf RadioButtonList1.SelectedIndex = 1 Then
            GridViewExportUtil.Export(RadioButtonList1.SelectedItem.Text & ".xls", GridView2)

        End If

    End Sub

    Protected Sub LinkButton2_Click(sender As Object, e As System.EventArgs) Handles LinkButton2.Click

    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        'If RadioButtonList1.SelectedIndex >= 0 Then
        '    LinkButton2.Attributes.Add("onclick", "window.open('popupgrid.aspx?datasource = " & RadioButtonList1.SelectedItem.Value & "','','status=0,toolbar=0,menubar=0,height=800,width=1000');return false")
        'End If

        If Not IsPostBack Then

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
        Else
            GetFromDt()
        End If

    End Sub

    Protected Sub ddlDateTo_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlDateTo.SelectedIndexChanged

        GetFromDt()
        RadioButtonList1.SelectedIndex = -1

    End Sub

    Protected Sub GetFromDt()
        Dim dt As DateTime
        dt = CDate(ddlDateTo.SelectedItem.Value)
        hdfDateFrom.Value = dt.Year.ToString + "-" + dt.ToString("MM") + "-" + "1"

    End Sub

End Class

