Imports System.Data
Imports System.Net
Imports System.Data.SqlClient
Partial Class OPS_QuotationReport
    Inherits System.Web.UI.Page

    Protected Sub ibtViewQuotation_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles ibtViewQuotation.Click
        Dim cn As New Connection
        Dim ds As New DataSet()
        Dim temp As String = Trim(txtQuotationNo.Text)
        '[jct_ops_quotations_summary]jct_ops_QuotationStatusReport
        Dim sqlstr As String = "jct_ops_quotations_summary"
        Dim cmd As SqlCommand = New SqlCommand(sqlstr, cn.Connection)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@Quotation_No", SqlDbType.VarChar, 16)
        cmd.Parameters("@Quotation_No").Value = temp
        Dim da As New SqlDataAdapter(cmd)
        da.Fill(ds)
        GridViewSummary.DataSource = ds
        GridViewSummary.DataBind()
        Bindgrid(temp)
     

    End Sub

    Private Sub Bindgrid(temp As String)
        Dim cn As New Connection
        Dim ds As New DataSet()
        '[jct_ops_quotations_summary]jct_ops_QuotationStatusReport
        Dim sqlstr As String = " Select a.quotation_no  as QuotationNo,a.order_no as OrderNo,a.item_no as ItemCode,b.created_dt  as OrderCreated From   miserp.som.dbo.jct_quotations_order a Inner join  miserp.som.dbo.t_order_hdr b  ON a.order_no=b.order_no   where   a.quotation_no= '" & temp & "'"
        Dim cmd As SqlCommand = New SqlCommand(sqlstr, cn.Connection)
        cmd.CommandType = CommandType.Text
        cmd.Parameters.Add("@Quotation_No", SqlDbType.VarChar, 16)
        cmd.Parameters("@Quotation_No").Value = temp
        Dim da As New SqlDataAdapter(cmd)
        da.Fill(ds)
        GridViewOrder.DataSource = ds
        GridViewOrder.DataBind()
    End Sub

End Class
