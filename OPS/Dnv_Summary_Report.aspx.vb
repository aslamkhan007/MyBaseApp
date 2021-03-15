Imports System.Data.SqlClient
Imports System.Data
Imports System.IO.StreamWriter

Partial Class SalesAnalysisSystem_Dnv_Summary_Report
    Inherits System.Web.UI.Page
    Dim obj1 As Functions = New Functions
    Dim ConStr As String = System.Web.Configuration.WebConfigurationManager.ConnectionStrings("ShpConnectionString").ConnectionString
    Dim conn As SqlConnection = New SqlConnection(ConStr)

    Protected Sub cmdDownload_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdDownload.Click

        If (conn.State = Data.ConnectionState.Closed) Then
            conn.Open()
        End If

        Dim sql As String
        Dim datasource_procedure As String = ""
        If DropDownList1.SelectedItem.Text = "DnV Detail" Then
            datasource_procedure = "jct_sas_sales_dnv_summary"
        ElseIf DropDownList1.SelectedItem.Text = "Invoice Wise Contribution" Then
            datasource_procedure = "jct_sas_invoice_wise_contribution"
        End If

        sql = datasource_procedure & " '" & txtSdate.Text & "', '" & txtEdate.Text & "', '" & ddlSegment.SelectedValue.ToString & "', '" & txtItemGroup.Text & "','','', '' "
        Dim cmd As SqlCommand = New SqlCommand(sql, conn)
        'cmd.CommandType = CommandType.StoredProcedure
        Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
        Dim ds As DataSet = New DataSet
        da.Fill(ds)
        Dim dt As DataTable = ds.Tables(0)
        CreateExcelFile(dt)
        'lnkReport.Visible = True
        'lnkReport.Text = "Click here to download the Dispatch detail for Period '" & txtSDate.Text & "' - '" & txtEDate.Text & "'"
        'Response.ClearContent()
        Response.ContentType = "application/octet-stream"
        Response.AddHeader("Content-Disposition", String.Format("attachment; filename = {0}", System.IO.Path.GetFileName("DnV_Detail.xls")))
        Response.AppendHeader("Content-Disposition", "attachment; filename=DnV_Detail.xls")
        Response.TransmitFile(Server.MapPath("DnV_Detail.xls"))
        Response.End()
        conn.Close()

    End Sub

    Function CreateExcelFile(ByVal dt As DataTable) As Boolean

        Dim bFileCreated As Boolean = False
        Dim sTableStart As String = "<HTML><BODY><TABLE Border=1><TR><TH>Dispatch Details Between '" & txtSDate.Text & "' AND '" & txtEDate.Text & "' </TH></TR>"
        Dim sTableEnd As String = "</TABLE></BODY></HTML>"
        Dim sTableData As String = ""
        Dim nRow As Long
        sTableData &= "<TR>"
        For nCol = 0 To dt.Columns.Count - 1
            sTableData &= "<TD><B>" & dt.Columns(nCol).ColumnName & "</B></TD>"
        Next
        sTableData &= "</TR>"
        For nRow = 0 To dt.Rows.Count - 1
            sTableData &= "<TR>"
            For nCol = 0 To dt.Columns.Count - 1
                sTableData &= "<TD>" & dt.Rows(nRow).Item(nCol).ToString & "</TD>"
            Next
            sTableData &= "</TR>"
        Next
        Dim sTable As String = sTableStart & sTableData & sTableEnd
        '  Dim oExcelFile As System.IO.File
        Dim oExcelWrite As System.IO.StreamWriter
        Dim sExcelFile As String = Server.MapPath("DnV_Detail.xls")
        oExcelWrite = IO.File.CreateText(sExcelFile)
        oExcelWrite.WriteLine(sTable)
        oExcelWrite.Close()
        bFileCreated = True
        Return bFileCreated

    End Function

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        GridView1.DataSourceID = DropDownList1.SelectedValue  '"SqlDataSource5"
        GridView1.DataBind()

    End Sub

End Class
