Imports System.Data
Imports System.Data.SqlClient

Partial Class OPS_Quotation_Pay_Terms
    Inherits System.Web.UI.Page

    Dim ofn As New Functions
    Dim dt As DataTable = New DataTable
    Dim dt2 As DataTable = New DataTable

    Protected Sub ibtSave_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles ibtSave.Click

        Dim tr As SqlTransaction
        Dim cn As New Connection
        Dim sqlstr As String = "jct_ops_create_quote_pay_terms"
        tr = cn.Connection.BeginTransaction
        Dim cmd As SqlCommand = New SqlCommand(sqlstr, cn.Connection, tr)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@Quotation_no", SqlDbType.VarChar, 16)
        cmd.Parameters.Add("@Currency", SqlDbType.Char, 3)
        cmd.Parameters.Add("@Exchange_Rate", SqlDbType.Float)
        cmd.Parameters.Add("@Pay_Mode", SqlDbType.VarChar, 20)
        cmd.Parameters.Add("@Pay_Type", SqlDbType.VarChar, 20)
        cmd.Parameters.Add("@Discount", SqlDbType.VarChar, 30)
        cmd.Parameters.Add("@Discount_Perc", SqlDbType.Float)
        cmd.Parameters.Add("@Agent", SqlDbType.VarChar, 20)
        cmd.Parameters.Add("@AgentCommissionPerc", SqlDbType.Float)
        cmd.Parameters.Add("@Exp_Pay_Time", SqlDbType.Int)
        cmd.Parameters.Add("@Margin_Perc", SqlDbType.Float)
        cmd.Parameters.Add("@Margin_Unit", SqlDbType.Float)
        cmd.Parameters.Add("@Net_Margin_Unit", SqlDbType.Float)
        cmd.Parameters.Add("@Sale_Price", SqlDbType.Float)
        cmd.Parameters.Add("@Theoretical_Margin", SqlDbType.Float)
        cmd.Parameters.Add("@User_Code", SqlDbType.VarChar, 10)

        Try
            cmd.Parameters("@Quotation_no").Value = lblQuotationNo.Text
            cmd.Parameters("@Currency").Value = ddlCurrency.SelectedItem.Text
            cmd.Parameters("@Exchange_Rate").Value = Val(lblExchangeRate.Text)
            cmd.Parameters("@Pay_Mode").Value = ddlPayMode.SelectedItem.Text
            cmd.Parameters("@Pay_Type").Value = ddlPayType.SelectedItem.Text
            cmd.Parameters("@Discount").Value = ddlDiscount.SelectedItem.Text
            cmd.Parameters("@Discount_Perc").Value = Val(lblTotalDiscountPerc.Text)
            cmd.Parameters("@Agent").Value = txtAgent.Text
            cmd.Parameters("@AgentCommissionPerc").Value = Val(txtAgentCommission.Text)
            cmd.Parameters("@Exp_Pay_Time").Value = Val(txtPayTime.Text)
            cmd.Parameters("@Margin_Perc").Value = Val(txtMarginPerc.Text)
            cmd.Parameters("@Margin_Unit").Value = Val(lblMargin.Text)
            cmd.Parameters("@Net_Margin_Unit").Value = Val(lblNetMargin.Text)
            cmd.Parameters("@Sale_Price").Value = Val(txtSalePrice.Text)
            cmd.Parameters("@Theoretical_Margin").Value = Val(lblThMargin.Text)
            cmd.Parameters("@User_Code").Value = Session("EmpCode").ToString()
            cmd.ExecuteNonQuery()
            SaveTCDDetail(cn, tr, lblQuotationNo.Text)
            SaveTermsCondDetails(cn, tr, lblQuotationNo.Text)
            tr.Commit()
            lblMessage.Text = "Payment Terms for Quotation No " & lblQuotationNo.Text & " Saved Successfully!"

            If Val(lblPrefMargin.Text) < Val(lblThMargin.Text) Then
                Dim emailstr As String = "Quotation # " & lblQuotationNo.Text & " saved with Theoretical Margin below Preferred Margin'"
                '  sm.SendMail("rbaksshi@jctltd.com", "dummy@jctltd.com", emailstr, emailstr)
            End If

        Catch ex As Exception

            tr.Rollback()
            'ofn.Alert(ex.Message)
            lblMessage.Text = ex.Message

        End Try

    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        lblQuotationNo.Text = Request.QueryString("quot")



        'Dim sqlstr1 As String = "select DNV_Cost from jct_ops_quotation_hdr a where quotation_no = '" & lblQuotationNo.Text & "' and rev_no = (Select max(rev_no) from jct_ops_quotation_hdr where quotation_no = a.quotation_no)"
        Dim sqlstr1 As String = "jct_ops_calculate_quote_length_upcharge '" & lblQuotationNo.Text & "'"
        Dim dr1 As SqlDataReader
        If Not IsPostBack Then


            ddlCurrency.DataSourceID = "SqlDataSource1"
            ddlCurrency.DataBind()

            Try
                dr1 = ofn.FetchReader(sqlstr1)
                If dr1.HasRows Then
                    dr1.Read()
                    lblDnvCost.Text = dr1("dnv_cost")
                    lblLengthUpcharge.Text = dr1("Len_charge")
                    lblPrefSellingPrice.Text = dr1("selling_price")
                    lblPrefMargin.Text = dr1("Margin_Perc")
                    ViewState.Add("Cost", dr1("dnv_cost"))
                    ViewState.Add("Len_charge", dr1("Len_charge"))
                    ViewState.Add("selling_price", dr1("selling_price"))
                    'ViewState.Add("Margin_Perc", dr1("Margin_Perc"))
                End If
                dr1.Close()

            Catch ex As Exception
                dr1 = Nothing

            End Try

            Dim cn As New Connection
            Dim sqlstr As String = "jct_ops_get_quote_pay_terms '" & lblQuotationNo.Text & "'"

            Dim cmd As SqlCommand = New SqlCommand(sqlstr, cn.Connection)
            'Dim da As New SqlDataAdapter(cmd)
            Try
                lblExchangeRate.Text = ddlCurrency.SelectedItem.Value
                Dim dr As SqlDataReader = cmd.ExecuteReader
                If dr.HasRows Then
                    While dr.Read
                        'ddlCurrency.Items.FindByText(dr("Currency")).Selected = True
                        ddlCurrency.SelectedIndex = ddlCurrency.Items.IndexOf(ddlCurrency.Items.FindByText(dr("Currency").ToString))

                        'ddlCurrency.Text = dr("Currency")
                        lblExchangeRate.Text = dr("Exchange_Rate")
                        ddlPayMode.Text = dr("Pay_Mode")
                        ddlPayType.Text = dr("Pay_Type")
                        'ddlDiscount.Text = dr("Discount")
                        lblDiscountPerc.Text = dr("Discount_Perc")
                        txtAgent.Text = dr("Agent")
                        txtAgentCommission.Text = dr("Commission")
                        txtPayTime.Text = dr("Exp_Pay_Time")
                        'txtMarginPerc.Text = CStr(dr("Margin_Perc"))
                        lblMargin.Text = dr("Margin_Unit")
                        lblNetMargin.Text = dr("Net_Margin_Unit")
                        txtSalePrice.Text = dr("Sale_Price")
                        ViewState("Sale_Price") = txtSalePrice.Text
                        lblThMargin.Text = dr("Theoretical_Margin")
                        'ddlDiscount.Items.FindByText(dr("Discount")).Selected = True
                        'ddlMarginPerc.Items.FindByText(CStr(dr("Margin_Perc"))).Selected = True
                        txtMarginPerc.Text = dr("Margin_Perc")

                        If Val(lblPrefMargin.Text) > Val(lblThMargin.Text) Then
                            lblThMargin.ForeColor = Drawing.Color.Red
                            lblMessage.Text = "Quotation Margin is less than the preferred margin. This quotation needs to be Authorised by the concerned authority."
                        Else
                            lblThMargin.ForeColor = Drawing.Color.DarkGreen
                            lblMessage.Text = ""
                        End If

                    End While
                End If
                GetQuotationDiscount()
                GetQuotationTermsConditions()

            Catch ex As Exception

            End Try
        End If
    End Sub

    Protected Sub ddlDiscount_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlDiscount.SelectedIndexChanged
        Dim sqlstr As String = "jct_ops_discounts '" & ddlDiscount.SelectedItem.Value & "'"
        Dim dr As SqlDataReader = ofn.FetchReader(sqlstr)

        If ddlDiscount.SelectedItem.Text = "" Then
            lblDiscountPerc.Text = "0"
            lblTotalDiscountPerc.Text = "0"
        Else
            Try
                If dr.HasRows Then
                    dr.Read()
                    lblDiscountPerc.Text = Math.Round(dr(2), 2)
                    If grdDiscounts.Rows.Count = 0 Then
                        lblTotalDiscountPerc.Text = Math.Round(dr(2), 2)
                    End If
                End If

            Catch ex As Exception

            End Try
        End If

        If lblMargin.Text <> "" Or lblSalePrice.Text <> "" Then
            CalculateMargin()
            CalculateSalePrice()
        End If

    End Sub

    Protected Sub ddlCurrency_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlCurrency.SelectedIndexChanged

        If ddlCurrency.SelectedItem.Text = "" Then
            lblExchangeRate.Text = ""
            lblDnvCost.Text = ""
            lblLengthUpcharge.Text = ""
            lblPrefSellingPrice.Text = ""

        ElseIf ddlCurrency.SelectedItem.Text <> "" Then
            lblExchangeRate.Text = ddlCurrency.SelectedItem.Value
            'lblDnvCost.Text = ViewState("Cost")
            'lblLengthUpcharge.Text = ViewState("Len_charge")
            'lblPrefSellingPrice.Text = ViewState("selling_price")

            lblDnvCost.Text = Math.Round(CDbl(ViewState("Cost")) / Val(lblExchangeRate.Text), 2)
            lblLengthUpcharge.Text = Math.Round(CDbl(ViewState("Len_charge")) / Val(lblExchangeRate.Text), 2)
            lblPrefSellingPrice.Text = Math.Round(CDbl(ViewState("selling_price")) / Val(lblExchangeRate.Text), 2)

            If txtSalePrice.Text <> "" Then
                txtSalePrice.Text = Val(txtSalePrice.Text) / Val(lblExchangeRate.Text)
            End If

            If lblMargin.Text <> "" Or lblSalePrice.Text <> "" Then
                CalculateMargin()
                CalculateSalePrice()
            End If

        End If

    End Sub

    Protected Sub CalculateSalePrice()

        Dim cost As Double

        If IsNumeric(lblExchangeRate.Text) Then

            'cost = lblDnvCost.Text  'CDbl(ViewState("Cost")) / Val(lblExchangeRate.Text)
            cost = ViewState("Cost")
        End If

        ' sp is unit price of item after including margin
        If txtMarginPerc.Text <> "" AndAlso IsNumeric(txtMarginPerc.Text) Then
            Dim sp As Double = cost + cost * Val(txtMarginPerc.Text) / 100
            Dim disc As Double = sp * Val(lblTotalDiscountPerc.Text) / 100
            Dim agent_comm As Double = sp * Val(txtAgentCommission.Text) / 100
            lblMargin.Text = Math.Round((sp - cost), 2)
            txtSalePrice.Text = Math.Round(sp, 2)
            lblNetMargin.Text = Math.Round(sp - disc - agent_comm - cost - Val(lblLengthUpcharge.Text), 2)
            lblThMargin.Text = Math.Round((sp - disc - agent_comm - cost - Val(lblLengthUpcharge.Text)) / cost * 100, 2)

            lblMargin.Text = Math.Round(Val(lblMargin.Text) / Val(lblExchangeRate.Text), 2)
            txtSalePrice.Text = Math.Round(Val(txtSalePrice.Text) / Val(lblExchangeRate.Text), 2)
            lblNetMargin.Text = Math.Round(Val(lblNetMargin.Text) / Val(lblExchangeRate.Text), 2)
            lblDnvCost.Text = Math.Round(Val(ViewState("Cost")) / Val(lblExchangeRate.Text), 2)
            lblLengthUpcharge.Text = Math.Round(CDbl(ViewState("Len_charge")) / Val(lblExchangeRate.Text), 2)

            'lblPrefSellingPrice.Text = Math.Round(Val(lblPrefSellingPrice.Text) / Val(lblExchangeRate.Text), 2)
            lblPrefSellingPrice.Text = Math.Round(CDbl(ViewState("selling_price")) / Val(lblExchangeRate.Text), 2)

            If Val(lblPrefMargin.Text) > Val(lblThMargin.Text) Then
                lblThMargin.ForeColor = Drawing.Color.Red
                lblMessage.Text = "Quotation Margin is less than the preferred margin. This quotation needs to be Authorised by the concerned authority."
            Else
                lblThMargin.ForeColor = Drawing.Color.DarkGreen
                lblMessage.Text = ""
            End If

        Else
            txtSalePrice.Text = ""
            lblThMargin.Text = ""
            lblMargin.Text = ""
            lblNetMargin.Text = ""

        End If

    End Sub

    Protected Sub CalculateMargin()

        Dim cost As Double

        If IsNumeric(lblExchangeRate.Text) And lblExchangeRate.Text > 0 Then
            cost = CDbl(ViewState("Cost")) / Val(lblExchangeRate.Text)
            'cost = lblDnvCost.Text  'CDbl(ViewState("Cost")) / Val(lblESxchangeRate.Text)
            'cost = ViewState("Cost")
        Else
            lblMessage.Text = "Please select appropriate currency."
        End If

        If txtSalePrice.Text <> "" AndAlso IsNumeric(txtSalePrice.Text) Then
            Dim sp As Double = Val(txtSalePrice.Text) 'Val(ViewState("Sale_Price"))
            'Dim sp As Double = cost + cost * Val(txtMarginPerc.Text) / 100
            Dim disc As Double = sp * Val(lblTotalDiscountPerc.Text) / 100
            Dim agent_comm As Double = sp * Val(txtAgentCommission.Text) / 100
            lblMargin.Text = Math.Round((sp - cost), 2)
            txtMarginPerc.Text = Math.Round(((sp - cost) * 100 / cost), 2)
            lblNetMargin.Text = Math.Round(sp - disc - agent_comm - cost - Val(lblLengthUpcharge.Text), 2)
            lblThMargin.Text = Math.Round((sp - disc - agent_comm - cost - Val(lblLengthUpcharge.Text)) / cost * 100, 2)

            'lblMargin.Text = Math.Round(Val(lblMargin.Text) / Val(lblExchangeRate.Text), 2)
            'lblThMargin.Text = Math.Round(Val(lblThMargin.Text) / Val(lblExchangeRate.Text), 2)
            'lblNetMargin.Text = Math.Round(Val(lblNetMargin.Text) / Val(lblExchangeRate.Text), 2)

            lblDnvCost.Text = Math.Round(Val(ViewState("Cost")) / Val(lblExchangeRate.Text), 2)
            lblPrefSellingPrice.Text = Math.Round(CDbl(ViewState("selling_price")) / Val(lblExchangeRate.Text), 2)

            If Val(lblPrefMargin.Text) > Val(lblThMargin.Text) Then
                lblThMargin.ForeColor = Drawing.Color.Red
                lblMessage.Text = "Quotation Margin is less than the preferred margin. This quotation needs to be Authorised by the concerned authority."
            Else
                lblThMargin.ForeColor = Drawing.Color.DarkGreen
                lblMessage.Text = ""
            End If

        Else
            txtSalePrice.Text = ""
            lblThMargin.Text = ""
            lblMargin.Text = ""
            lblNetMargin.Text = ""

        End If

    End Sub

    Protected Sub txtAgentCommission_TextChanged(sender As Object, e As System.EventArgs) Handles txtAgentCommission.TextChanged
        If lblMargin.Text <> "" Or lblSalePrice.Text <> "" Then
            CalculateMargin()
            CalculateSalePrice()
        End If

    End Sub

    Protected Sub txtAgent_TextChanged(sender As Object, e As System.EventArgs) Handles txtAgent.TextChanged
        If txtAgent.Text = "" Then
            txtAgent.Text = ""
            lblAgentName.Text = ""
            txtAgentCommission.Text = ""
        Else
            Try
                Dim agent As String = txtAgent.Text
                txtAgent.Text = agent.Split("|c")(1).ToString
                lblAgentName.Text = agent.Split("|c")(0).ToString
                txtAgentCommission.Text = "0"
            Catch ex As Exception
                ofn.Alert("Please Enter Valid Agent")
            End Try
        End If
    End Sub

    Protected Sub txtMarginPerc_TextChanged(sender As Object, e As System.EventArgs) Handles txtMarginPerc.TextChanged
        CalculateSalePrice()

    End Sub

    Protected Sub txtSalePrice_TextChanged(sender As Object, e As System.EventArgs) Handles txtSalePrice.TextChanged
        CalculateMargin()

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

    Protected Sub ibtDispatchDetail_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles ibtDispatchDetail.Click
        Response.Redirect("Quotation_Dispatch_Sch.aspx?quot=" & lblQuotationNo.Text)
    End Sub

    Protected Sub ibtAddDiscount_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles ibtAddDiscount.Click

        If Not ViewState("data") Is Nothing Then
            dt = ViewState("data")

        Else
            dt.Columns.Add("DiscountCode")
            dt.Columns.Add("Discount")
            dt.Columns.Add("Value%")

        End If

        Dim drow As DataRow = dt.NewRow
        drow("DiscountCode") = ddlDiscount.SelectedItem.Value
        drow("Discount") = ddlDiscount.SelectedItem.Text 'ddlShade.SelectedItem.Text
        drow("Value%") = lblDiscountPerc.Text

        dt.Rows.Add(drow)

        ViewState.Add("data", dt)
        grdDiscounts.DataSource = dt
        grdDiscounts.DataBind()

    End Sub

    Protected Sub grdDiscounts_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdDiscounts.RowDataBound
        Dim tot_disc As Double = 0
        'If e.Row.RowType = DataControlRowType.DataRow Then
        For Each row As GridViewRow In grdDiscounts.Rows
            tot_disc += Val(row.Cells(3).Text)
        Next
        If e.Row.RowType = DataControlRowType.Footer Then
            e.Row.Cells(2).Text = tot_disc
            lblTotalDiscountPerc.Text = tot_disc
        End If

    End Sub

    Protected Sub chkLC_CheckedChanged(sender As Object, e As System.EventArgs) Handles chkLC.CheckedChanged
        If chkLC.Checked Then
            lblLCInterest.Text = "12" 'To be picked from Masters
        Else
            lblLCInterest.Text = "0"
        End If

    End Sub

    Protected Sub SaveTCDDetail(cn As Connection, tr As SqlTransaction, quot_no As String)

        Dim sqlstr As String = "jct_ops_create_quot_tcd_detail"
        Dim cmd As SqlCommand = New SqlCommand(sqlstr, cn.Connection, tr)

        cmd.CommandType = CommandType.StoredProcedure

        cmd.Parameters.Add("@Quotation_no", SqlDbType.VarChar, 16)
        cmd.Parameters.Add("@Tcd_Code", SqlDbType.VarChar, 10)
        cmd.Parameters.Add("@Tcd_Desc", SqlDbType.VarChar, 100)
        cmd.Parameters.Add("@Tcd_Value", SqlDbType.Float)
        cmd.Parameters.Add("@UserID", SqlDbType.VarChar, 10)
        cmd.Parameters.Add("@ClearFlag", SqlDbType.Char, 1)

        Dim cf As String = "1"
        For Each drow As GridViewRow In grdDiscounts.Rows
            cmd.Parameters("@ClearFlag").Value = cf
            cmd.Parameters("@Quotation_no").Value = quot_no
            cmd.Parameters("@Tcd_Code").Value = drow.Cells(1).Text
            cmd.Parameters("@Tcd_Desc").Value = drow.Cells(2).Text
            cmd.Parameters("@Tcd_Value").Value = drow.Cells(3).Text
            cmd.Parameters("@UserID").Value = Session("EmpCode").ToString()
            cf = "0"
            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                tr.Rollback()
                ofn.Alert(ex.Message)
            End Try
        Next

    End Sub

    Protected Sub SaveTermsCondDetails(cn As Connection, tr As SqlTransaction, quot_no As String)

        Dim sqlstr As String = "jct_ops_create_quote_terms_conditions_detail"
        Dim cmd As SqlCommand = New SqlCommand(sqlstr, cn.Connection, tr)

        cmd.CommandType = CommandType.StoredProcedure

        cmd.Parameters.Add("@Quotation_no", SqlDbType.VarChar, 16)
        cmd.Parameters.Add("@Tc_Code", SqlDbType.VarChar, 10)
        cmd.Parameters.Add("@Tc_Desc", SqlDbType.VarChar, 100)
        cmd.Parameters.Add("@UserID", SqlDbType.VarChar, 10)
        cmd.Parameters.Add("@ClearFlag", SqlDbType.Char, 1)

        Dim cf As String = "1"
        For Each drow As GridViewRow In grdTermsCond.Rows
            cmd.Parameters("@ClearFlag").Value = cf
            cmd.Parameters("@Quotation_no").Value = quot_no
            cmd.Parameters("@Tc_Code").Value = drow.Cells(1).Text
            cmd.Parameters("@Tc_Desc").Value = drow.Cells(2).Text
            cmd.Parameters("@UserID").Value = Session("EmpCode").ToString()
            cf = "0"
            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                tr.Rollback()
                ofn.Alert(ex.Message)
            End Try
        Next

    End Sub

    Protected Sub grdDiscounts_RowDeleting(sender As Object, e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles grdDiscounts.RowDeleting
        lblMessage.Text = ""
        Dim row As String = e.RowIndex 'grdItems.SelectedRow.RowIndex.ToString

        Dim dt As DataTable = CType(ViewState("data"), DataTable)
        dt.Rows.RemoveAt(row)
        grdDiscounts.DataSource = dt
        grdDiscounts.DataBind()
        ViewState("data") = dt
        If grdDiscounts.Rows.Count = 0 Then
            lblTotalDiscountPerc.Text = Val(lblDiscountPerc.Text)
        End If

    End Sub

    Protected Sub ibtAddTC_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles ibtAddTC.Click
        If Not ViewState("tc") Is Nothing Then
            dt2 = ViewState("tc")

        Else
            dt2.Columns.Add("TC_Code")
            dt2.Columns.Add("TC_Desc")

        End If

        Dim drow As DataRow = dt2.NewRow
        drow("TC_Code") = ddlTermsCond.SelectedItem.Value
        drow("TC_Desc") = ddlTermsCond.SelectedItem.Text 'ddlShade.SelectedItem.Text

        dt2.Rows.Add(drow)

        ViewState.Add("tc", dt2)
        grdTermsCond.DataSource = dt2
        grdTermsCond.DataBind()

    End Sub

    Protected Sub grdTermsCond_RowDeleting(sender As Object, e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles grdTermsCond.RowDeleting
        lblMessage.Text = ""
        Dim row As String = e.RowIndex 'grdItems.SelectedRow.RowIndex.ToString

        Dim dt As DataTable = CType(ViewState("tc"), DataTable)
        dt.Rows.RemoveAt(row)
        grdTermsCond.DataSource = dt
        grdTermsCond.DataBind()
        ViewState("tc") = dt2


    End Sub

    Protected Sub GetQuotationDiscount()
        'lblMessage.Text = ""
        'lblQuotationNo.Text = Request.QueryString("quot")

        If Not ViewState("data") Is Nothing Then
            dt = ViewState("data")
        Else
            dt.Columns.Add("DiscountCode")
            dt.Columns.Add("Discount")
            dt.Columns.Add("Value%")

        End If

        If Not IsPostBack Then

            Dim sqlstr As String = "jct_ops_get_quot_discounts '" & lblQuotationNo.Text & "'"
            Dim cn As New Connection
            Dim cmd As SqlCommand = New SqlCommand(sqlstr, cn.Connection)
            'Dim da As New SqlDataAdapter(cmd)
            Dim dr As SqlDataReader = cmd.ExecuteReader
            If dr.HasRows Then
                While dr.Read
                    Dim drow As DataRow = dt.NewRow
                    drow("DiscountCode") = dr("tcd_code")
                    drow("Discount") = dr("tcd_desc")
                    drow("Value%") = dr("tcd_value")
                    dt.Rows.Add(drow)
                End While
            End If

            ViewState.Add("data", dt)
            grdDiscounts.DataSource = dt
            grdDiscounts.DataBind()

        End If
    End Sub

    Protected Sub GetQuotationTermsConditions()
        'lblMessage.Text = ""
        'lblQuotationNo.Text = Request.QueryString("quot")

        If Not ViewState("tc") Is Nothing Then
            dt2 = ViewState("tc")
        Else
            dt2.Columns.Add("TC_Code")
            dt2.Columns.Add("TC_Desc")

        End If

        If Not IsPostBack Then

            Dim sqlstr As String = "jct_ops_get_quote_terms_conditions_detail '" & lblQuotationNo.Text & "'"
            Dim cn As New Connection
            Dim cmd As SqlCommand = New SqlCommand(sqlstr, cn.Connection)
            'Dim da As New SqlDataAdapter(cmd)
            Dim dr As SqlDataReader = cmd.ExecuteReader
            If dr.HasRows Then
                While dr.Read
                    Dim drow As DataRow = dt2.NewRow
                    drow("TC_Code") = dr("tc_code")
                    drow("TC_Desc") = dr("tc_desc")
                    dt2.Rows.Add(drow)
                End While
                dr.Close()
            End If

            ViewState.Add("tc", dt2)
            grdTermsCond.DataSource = dt2
            grdTermsCond.DataBind()

        End If
    End Sub

    Protected Sub ddlFreight_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlFreight.SelectedIndexChanged
        Dim sqlstr As String = "jct_ops_get_freight '" & ddlFreight.SelectedItem.Value & "'"
        Dim dr As SqlDataReader = ofn.FetchReader(sqlstr)

        If ddlFreight.SelectedItem.Text = "" Then
            txtFreight.Text = "0"
        Else
            Try
                If dr.HasRows Then
                    dr.Read()
                    txtFreight.Text = Math.Round(dr(2), 4)
                    dr.Close()
                End If

            Catch ex As Exception

            End Try
        End If

        If lblMargin.Text <> "" Or lblSalePrice.Text <> "" Then
            CalculateMargin()
            CalculateSalePrice()
        End If
    End Sub

End Class
