Imports System.Data.SqlClient
Imports System.Data
Imports System.Net
Partial Class OPS_QuotationProd_Detail_Report
    Inherits System.Web.UI.Page

    Protected Sub lnkFetch_Click(sender As Object, e As System.EventArgs) Handles lnkFetch.Click
        bindgridAuth()
    End Sub
    Private Sub bindgridAuth()
        GridView1.DataSource = Nothing
        GridView1.DataBind()
        Dim cn As New Connection
        Dim sql As String = "jct_ops_Get_planning_internal_process_report"
        Dim cmd As New SqlCommand(sql, cn.Connection)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("Quotation_no", SqlDbType.VarChar, 16).Value = txtQuotation.Text
        cmd.Parameters.Add("Fromdate ", SqlDbType.VarChar, 510).Value = txtDateFrom.Text
        cmd.Parameters.Add("Todate", SqlDbType.VarChar, 510).Value = txtDateTo.Text
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet()
        da.Fill(ds)
        If ds.Tables.Count > 0 Then
            If ds.Tables(0).Rows.Count > 0 Then

                GridView1.DataSource = ds
                GridView1.DataBind()

            End If

        Else
            GridView1.DataSource = Nothing
            GridView1.DataBind()
        End If
    End Sub
End Class
