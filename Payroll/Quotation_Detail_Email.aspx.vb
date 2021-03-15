Imports System.Data
Imports System.Data.SqlClient
Partial Class OPS_Quotation_Detail_Email
    Inherits System.Web.UI.Page
    Dim ofn As New Functions
    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        'Dim lID As String = Request.QueryString("id")
        Dim lID As String = "1000000"
        Dim sqlstr As String = "Jct_Payroll_Leave_Auth_Report '" & Convert.ToInt32(lID) & "'"
        Dim dr As SqlDataReader
        Try
            dr = ofn.FetchReader(sqlstr)
            If dr.HasRows() Then
                dr.Read()
                lblLeaveId.Text = dr("LeaveID")
                lblStatus.Text = dr("STATUS")

                'lblnature.Text = dr("dated")
                'lblRequesterName.Text = dr("RequesterName")
                'lblRequesterCode.Text = dr("customer_code")
                ''lblBrand.Text = dr("brand").ToString
                ''lblSalesPerson.Text = dr("sales_person_name")
                ''txtSaleNotes.Text = dr("sale_notes").ToString
                'lblLeaveStatus.Text = dr("Status").ToString
                ''lblDispatchApproval.Text = dr("Approval_Status").ToString
                'lblAuthorisedUser.Text = dr("Approval_User").ToString
                'lblAuthorisationDt.Text = dr("Authorisation_Dt").ToString

                'lblSOReqStatus.Text = IIf(dr("Req_SO").ToString() = "", "-Not Available-", dr("Req_SO").ToString())
                'lblApprovalDt.Text = dr("Approval_Dt").ToString

                'lblQuotationType.Text = dr("quotation_type").ToString
                'lblPPCRemarks.Text = dr("PPC_Remarks").ToString
                'lblRemarks.Text = dr("Remark").ToString
                'ViewState("MaxShades") = dr("Max_Shades").ToString

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

    'Protected Sub lblBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblBack.Click

    'End Sub

    'Protected Sub GridView1_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
    '    Static avg_unit_price, tot_amt, tot_qty, no_of_items As Double
    '    If e.Row.RowType = DataControlRowType.DataRow Then
    '        tot_qty = tot_qty + Val(e.Row.Cells(8).Text)
    '        tot_amt = tot_amt + Val(e.Row.Cells(7).Text) * Val(e.Row.Cells(8).Text)
    '        no_of_items += 1
    '    ElseIf e.Row.RowType = DataControlRowType.Footer Then
    '        If no_of_items > 0 Then
    '            avg_unit_price = Math.Round(tot_amt / tot_qty, 2)
    '            e.Row.Cells(5).Text = "Max: " & ViewState("MaxShades").ToString
    '            e.Row.Cells(7).Text = "Wt. Avg: " + avg_unit_price.ToString '+ "<br/> Avg Unit Price: " + Math.Round(tot_amt / no_of_items, 2).ToString
    '            e.Row.Cells(8).Text = Math.Round(tot_qty, 2)
    '        End If
    '    End If
    'End Sub

    'Protected Sub GridView3_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles GridView3.SelectedIndexChanged

    'End Sub
End Class
