Imports System.Data
Imports System.Data.SqlClient

Partial Class OPS_Quotation_Preview
    Inherits System.Web.UI.Page
    Dim ofn As New Functions

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim quot_no As String = Request.QueryString("quot")
        Dim sqlstr As String = "jct_ops_get_quotation_print '" & quot_no & "'"
        Dim dr As SqlDataReader
        Try
            dr = ofn.FetchReader(sqlstr)
            If dr.HasRows() Then
                dr.Read()
                lblQuotationNo.Text = dr("quotation_no")
                lblCurrentDate.Text = dr("dated")
                lblCustomerName.Text = dr("Customer")
                lblCustomerName1.Text = dr("Customer")
                lblCustomerCode.Text = dr("customer_code")
                lblSalesPerson.Text = dr("sales_person_name")
                lblBrand.Text = dr("brand")
                'lblProduct.Text = dr("Item_Code")
                'lblProductName.Text = dr("item_desc")
                'lblEpi.Text = dr("epi")
                'lblPpi.Text = dr("ppi")
                'lblGsm.Text = dr("gsm")
                'lblWidth.Text = dr("width")
                'lblWeave.Text = dr("weave")
                'lblUnitPrice.Text = dr("sale_price")
                'lblDiscount.Text = dr("discount")
                'lblDiscountPc.Text = dr("discount_perc")
                'lblCurrency.Text = dr("currency")
                'lblNetUnitPrice.Text = Val(lblUnitPrice.Text) - Val(lblDiscount.Text)
            End If

        Catch ex As Exception

        End Try

    End Sub

    Protected Sub lblBack_Click(sender As Object, e As System.EventArgs) Handles lblBack.Click

    End Sub

    Protected Sub GridView1_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound

        Static avg_unit_price, tot_amt, tot_qty, no_of_items As Double

        If e.Row.RowType = DataControlRowType.DataRow Then
            tot_qty = tot_qty + Val(e.Row.Cells(7).Text)
            tot_amt = tot_amt + Val(e.Row.Cells(6).Text) * Val(e.Row.Cells(7).Text)

            no_of_items += 1

        ElseIf e.Row.RowType = DataControlRowType.Footer Then
            If no_of_items > 0 Then
                avg_unit_price = Math.Round(tot_amt / tot_qty, 2)
                e.Row.Cells(6).Text = "Wt. Avg: " + avg_unit_price.ToString '+ "<br/> Avg Unit Price: " + Math.Round(tot_amt / no_of_items, 2).ToString
                e.Row.Cells(7).Text = Math.Round(tot_qty, 2)

            End If
        End If

    End Sub

End Class
