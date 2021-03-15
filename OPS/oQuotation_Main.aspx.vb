Imports System.Data
Imports System.Data.SqlClient

Partial Class OPS_Quotation_Main
    Inherits System.Web.UI.Page
    Dim ofn As New Functions

    Protected Sub txtItemCode_TextChanged(sender As Object, e As System.EventArgs) Handles txtItemCode.TextChanged
        'hfdItem.Value = txtItemCode.Text

        Try
            grdWarpWeft.DataSource = SqlDataSource2
            grdWarpWeft.DataBind()
            'grdCosting.DataSource = SqlDataSource1
            'grdCosting.DataBind()
        Catch ex As Exception
            ofn.Alert("Please enter valid Item Code")
        End Try

        Get_Fabric_Particulars(txtItemCode.Text)
        ResetCostDetail()

    End Sub

    Protected Sub ResetCostDetail()
        txtRawMaterial.Text = ""
        txtSpinning.Text = ""
        txtWeaving.Text = ""
        txtSizing.Text = ""
        txtShrinkage.Text = ""
        txtProcessing.Text = ""
        txtFinishing.Text = ""
        txtPacking.Text = ""
        txtValueLoss.Text = ""
        txtShrinkage.Text = ""
        txtSellingExp.Text = ""
        lblDnVCost.Text = ""
        lblPrefMarginPerc.Text = ""
        lblSellPrice.Text = ""

    End Sub

    Protected Sub txtCustomer_TextChanged(sender As Object, e As System.EventArgs) Handles txtSearchCustomer.TextChanged
        'Try
        '    lblCustomerName.Text = txtCustomer.Text.Substring(0, txtCustomer.Text.IndexOf("~"))
        '    Dim startc As Integer = txtCustomer.Text.IndexOf("~")
        '    Dim str As String = ""
        '    str = txtCustomer.Text.Substring(startc, txtCustomer.Text.Length - txtCustomer.Text.IndexOf("~"))
        '    txtCustomer.Text = str.Substring(1, str.Length - 1)
        'Catch ex As Exception
        '    ofn.Alert("Please Enter Valid Customer")
        'End Try

        Try
            lblCustomerName.Text = txtSearchCustomer.Text.Split("~c")(0).ToString
            txtCustomerCode.Text = txtSearchCustomer.Text.Split("~c")(1).ToString
            txtSearchItem.Focus()
        Catch ex As Exception
            ofn.Alert("Please Type/Select Valid Customer")
        End Try

    End Sub

    Protected Sub Get_Fabric_Particulars(sort As String)

        Dim sqlstr As String = "jct_ops_get_fabric_param " & sort
        Dim dr As SqlDataReader = ofn.FetchReader(sqlstr)
        If dr.HasRows Then
            dr.Read()
            txtBlend.Text = dr("blend")
            txtEPI.Text = dr("epi_fin")
            txtPPI.Text = dr("picks")
            txtWeave.Text = dr("weave")
            txtWidth.Text = dr("fin_width")
            txtWeightGSM.Text = dr("gsm")
            lblItemDescription.Text = dr("fabric_desc")
        End If

    End Sub

    Protected Sub Get_Cost_Details(sort As String, memo_no As String, finish As String, printing As String) ', loom As String, customer As String)

        Dim sqlstr As String = "jct_ops_get_cost_detail '" & sort & "','" & memo_no & "'" ','" & finish & "','" & printing & "'"
        Dim dr As SqlDataReader = ofn.FetchReader(sqlstr)
        If dr.HasRows Then
            dr.Read()
            txtRawMaterial.Text = IIf(IsDBNull(dr("Raw Material")), "0", dr("Raw Material"))
            txtSpinning.Text = IIf(IsDBNull(dr("Spinning")), "0", dr("Spinning"))
            txtSizing.Text = IIf(IsDBNull(dr("Sizing")), "0", dr("Sizing"))
            txtWeaving.Text = IIf(IsDBNull(dr("Weaving")), "0", dr("Weaving"))
            txtProcessing.Text = IIf(IsDBNull(dr("Processing")), "0", dr("Processing"))
            txtShrinkage.Text = IIf(IsDBNull(dr("Shrinkage")), "0", dr("Shrinkage"))
            txtPacking.Text = IIf(IsDBNull(dr("Packing")), "0", dr("Packing"))
            txtValueLoss.Text = IIf(IsDBNull(dr("Value_Loss")), "0", dr("Value_Loss"))
            txtSellingExp.Text = IIf(IsDBNull(dr("Selling_Exp")), "0", dr("Selling_Exp"))
            lblSellPrice.Text = IIf(IsDBNull(dr("Selling_Price")), "0", dr("Selling_Price"))
            lblDnVCost.Text = IIf(IsDBNull(dr("Dnv_Cost")), "0", dr("Dnv_Cost"))

            lblPrefMarginPerc.Text = Math.Round((Val(lblSellPrice.Text) - Val(lblDnVCost.Text)) * 100 / Val(lblDnVCost.Text), 2)

        End If

    End Sub

    Protected Sub grdCosting_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles grdCosting.SelectedIndexChanged

        Dim sort As String = txtItemCode.Text
        Dim sortno As String = grdCosting.SelectedRow.Cells(5).Text
        Dim memo_no As String = grdCosting.SelectedRow.Cells(2).Text
        Dim loom As String = grdCosting.SelectedRow.Cells(7).Text
        Dim finish As String = ddlFinish.SelectedItem.Value
        Dim printing As String = ddlPrintingType.SelectedItem.Value
        lblMemoNo.Text = memo_no
        Get_Cost_Details(sortno, memo_no, finish, printing) ', sortno, loom, txtCustomer.Text)

    End Sub

    Protected Sub ibtSave_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles ibtSave.Click

        Dim cn As New Connection
        Dim tr As SqlTransaction
        tr = cn.Connection.BeginTransaction
        Dim sqlstr As String = "jct_ops_create_quote"
        Dim cmd As SqlCommand = New SqlCommand(sqlstr, cn.Connection, tr)

        cmd.CommandType = CommandType.StoredProcedure

        cmd.Parameters.Add("@Quotation_No", SqlDbType.VarChar, 16)
        cmd.Parameters("@Quotation_No").Value = lblQuotationNo.Text

        cmd.Parameters.Add("@Customer_Code", SqlDbType.VarChar, 10)
        cmd.Parameters("@Customer_Code").Value = txtCustomerCode.Text

        cmd.Parameters.Add("@Customer_Name", SqlDbType.VarChar, 100)
        cmd.Parameters("@Customer_Name").Value = lblCustomerName.Text

        cmd.Parameters.Add("@Sales_Person_Code", SqlDbType.VarChar, 7)
        cmd.Parameters("@Sales_Person_Code").Value = Session("EmpCode")

        cmd.Parameters.Add("@Sales_Person_Name", SqlDbType.VarChar, 40)
        cmd.Parameters("@Sales_Person_Name").Value = Session("EmpName")

        cmd.Parameters.Add("@Product_Catg", SqlDbType.VarChar, 20)
        cmd.Parameters("@Product_Catg").Value = ddlProductCatg.SelectedItem.Text

        cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 10)
        cmd.Parameters("@Plant").Value = ddlPlant.SelectedItem.Text

        cmd.Parameters.Add("@Item_Type", SqlDbType.VarChar, 20)
        cmd.Parameters("@Item_Type").Value = txtItemType.Text  'ddlItemType.SelectedItem.Text

        cmd.Parameters.Add("@Item_Code", SqlDbType.VarChar, 10)
        cmd.Parameters("@Item_Code").Value = txtItemCode.Text

        cmd.Parameters.Add("@Item_Desc", SqlDbType.VarChar, 80)
        cmd.Parameters("@Item_Desc").Value = lblItemDescription.Text

        cmd.Parameters.Add("@Blend", SqlDbType.VarChar, 50)
        cmd.Parameters("@Blend").Value = txtBlend.Text

        cmd.Parameters.Add("@Epi", SqlDbType.Int)
        cmd.Parameters("@Epi").Value = Val(txtEPI.Text)

        cmd.Parameters.Add("@Ppi", SqlDbType.Int)
        cmd.Parameters("@Ppi").Value = Val(txtPPI.Text)

        cmd.Parameters.Add("@Gsm", SqlDbType.Int)
        cmd.Parameters("@Gsm").Value = Val(txtWeightGSM.Text)

        cmd.Parameters.Add("@Weave", SqlDbType.VarChar, 30)
        cmd.Parameters("@Weave").Value = txtWeave.Text

        cmd.Parameters.Add("@Width", SqlDbType.Int)
        cmd.Parameters("@Width").Value = Val(txtWidth.Text)

        cmd.Parameters.Add("@Memo_No", SqlDbType.VarChar, 10)
        cmd.Parameters("@Memo_No").Value = lblMemoNo.Text

        cmd.Parameters.Add("@Raw_Material", SqlDbType.Float)
        cmd.Parameters("@Raw_Material").Value = Val(txtRawMaterial.Text)

        cmd.Parameters.Add("@Spinning", SqlDbType.Float)
        cmd.Parameters("@Spinning").Value = Val(txtSpinning.Text)

        cmd.Parameters.Add("@Weaving", SqlDbType.Float)
        cmd.Parameters("@Weaving").Value = Val(txtWeaving.Text)

        cmd.Parameters.Add("@Sizing", SqlDbType.Float)
        cmd.Parameters("@Sizing").Value = Val(txtSizing.Text)

        cmd.Parameters.Add("@Processing", SqlDbType.Float)
        cmd.Parameters("@Processing").Value = Val(txtProcessing.Text)

        cmd.Parameters.Add("@Shrinkage", SqlDbType.Float)
        cmd.Parameters("@Shrinkage").Value = Val(txtShrinkage.Text)

        cmd.Parameters.Add("@Finishing", SqlDbType.Float)
        cmd.Parameters("@Finishing").Value = Val(txtFinishing.Text)

        cmd.Parameters.Add("@Value_Loss", SqlDbType.Float)
        cmd.Parameters("@Value_Loss").Value = Val(txtValueLoss.Text)

        cmd.Parameters.Add("@Selling_Exp", SqlDbType.Float)
        cmd.Parameters("@Selling_Exp").Value = Val(txtSellingExp.Text)

        cmd.Parameters.Add("@DNV_Cost", SqlDbType.Int)
        cmd.Parameters("@DNV_Cost").Value = Val(lblDnVCost.Text)

        cmd.Parameters.Add("@Selling_Price", SqlDbType.Int)
        cmd.Parameters("@Selling_Price").Value = Val(lblSellPrice.Text)

        cmd.Parameters.Add("@Pref_Margin_Perc", SqlDbType.Float)
        cmd.Parameters("@Pref_Margin_Perc").Value = Val(lblPrefMarginPerc.Text)

        cmd.Parameters.Add("@Sample_Reqd", SqlDbType.Char, 1)
        cmd.Parameters("@Sample_Reqd").Value = IIf(chkSample.Checked, "1", "0")

        cmd.Parameters.Add("@Sample_Ref", SqlDbType.VarChar, 20)
        cmd.Parameters("@Sample_Ref").Value = txtSampleRef.Text

        cmd.Parameters.Add("@Labdip_Reqd", SqlDbType.Char, 1)
        cmd.Parameters("@Labdip_Reqd").Value = IIf(chkLabDip.Checked, "1", "0")

        cmd.Parameters.Add("@Labdip_Ref", SqlDbType.VarChar, 20)
        cmd.Parameters("@Labdip_Ref").Value = txtLabdipRef.Text

        'cmd.Parameters.Add("@Margin_Perc", SqlDbType.Int)
        'cmd.Parameters("@Margin_Perc").Value = Val(ddlMarginPerc.SelectedItem.Text)

        cmd.Parameters.Add("@User_Code", SqlDbType.VarChar, 10)
        cmd.Parameters("@User_Code").Value = Session("EmpCode")

        cmd.Parameters.Add("@Host_Ip", SqlDbType.VarChar, 20)
        cmd.Parameters("@Host_Ip").Value = Request.UserHostAddress

        cmd.Parameters.Add("@Revision_Remark", SqlDbType.VarChar, 30)
        cmd.Parameters("@Revision_Remark").Value = txtRemark.Text

        cmd.Parameters.Add("@Remark", SqlDbType.VarChar, 100)
        cmd.Parameters("@Remark").Value = txtRemark.Text

        'Output Quotation Number
        cmd.Parameters.Add("@Quot_No", SqlDbType.VarChar, 20)
        cmd.Parameters("@Quot_No").Direction = ParameterDirection.Output

        cn.ConOpen()
        Dim sm As New SendMail
        Try

            cmd.ExecuteNonQuery()
            SaveWarpWeftCountDetail(cn, tr, cmd.Parameters("@Quot_No").Value)
            lblQuotationNo.Text = cmd.Parameters("@Quot_No").Value
            txtQuotationNo.Text = cmd.Parameters("@Quot_No").Value
            tr.Commit()
            ofn.Alert("Quotation # " & lblQuotationNo.Text + " saved successfully!")

            sm.SendMail("jagdeep@jctltd.com", "dummy@jctltd.com", "Quotation # " & lblQuotationNo.Text + " created successfully!", "Quotation # " & lblQuotationNo.Text + " created successfully!")
            'sm.SendMail("jagdeep@jctltd.com", "dummy@jctltd.com", "Quotation # " & lblQuotationNo.Text + " created successfully!", "Quotation # " & lblQuotationNo.Text + " created successfully!")

            lblMessage.Text = "Quotation # " & lblQuotationNo.Text + " saved successfully!"

        Catch ex As Exception
            tr.Rollback()
            ofn.Alert(ex.Message)
            lblMessage.Text = "Error Occurred : " + ex.Message
            sm.SendMail("jagdeep@jctltd.com", "dummy@jctltd.com", "Error Occurred while creating quotation", ex.Message)

        End Try

    End Sub

    Protected Sub SaveWarpWeftCountDetail(cn As Connection, tr As SqlTransaction, quot_no As String)

        Dim sqlstr As String = "jct_ops_create_quote_fab_count"
        Dim cmd As SqlCommand = New SqlCommand(sqlstr, cn.Connection, tr)

        cmd.CommandType = CommandType.StoredProcedure

        cmd.Parameters.Add("@Quotation_no", SqlDbType.VarChar, 16)
        'cmd.Parameters.Add("@Rev_No", SqlDbType.Int)
        cmd.Parameters.Add("@code", SqlDbType.Char, 1)
        cmd.Parameters.Add("@count_no", SqlDbType.VarChar, 20)
        cmd.Parameters.Add("@act_count", SqlDbType.Float)
        cmd.Parameters.Add("@count_name", SqlDbType.VarChar, 100)
        cmd.Parameters.Add("@blend", SqlDbType.VarChar, 30)
        cmd.Parameters.Add("@blend_perc", SqlDbType.VarChar, 20)
        cmd.Parameters.Add("@ClearFlag", SqlDbType.Char, 1)
        Dim cf As String = "1"
        For Each drow As GridViewRow In grdWarpWeft.Rows
            cmd.Parameters("@ClearFlag").Value = cf
            cmd.Parameters("@Quotation_no").Value = quot_no
            'cmd.Parameters("@Rev_No").Value = 0
            cmd.Parameters("@code").Value = drow.Cells(0).Text
            cmd.Parameters("@count_no").Value = drow.Cells(1).Text
            cmd.Parameters("@act_count").Value = drow.Cells(2).Text
            cmd.Parameters("@count_name").Value = drow.Cells(3).Text
            cmd.Parameters("@blend").Value = drow.Cells(4).Text
            cmd.Parameters("@blend_perc").Value = drow.Cells(5).Text
            cf = "0"
            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                tr.Rollback()
                ofn.Alert(ex.Message)
            End Try
        Next

    End Sub

    Protected Sub txtQuotationNo_TextChanged(sender As Object, e As System.EventArgs) Handles txtQuotationNo.TextChanged
        ibtViewQuotation_Click(sender, Nothing)

    End Sub

    Protected Sub ibtViewQuotation_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles ibtViewQuotation.Click

        Dim sqlstr As String = "jct_ops_get_quotes '" & txtQuotationNo.Text & "'"
        Dim cn As New Connection
        Dim cmd As SqlCommand = New SqlCommand(sqlstr, cn.Connection)
        Dim dr As SqlDataReader
        dr = cmd.ExecuteReader()
        Try

        If dr.HasRows Then

            dr.Read()
                lblQuotationNo.Text = dr("Quotation_No")
                lblStatus.Text = dr("status")
                lblQuoteDate.Text = dr("Quot_Date")
                lblExpiryDate.Text = Convert.ToDateTime(lblQuoteDate.Text).AddDays(30).ToString()
                If DateTime.Now >= Convert.ToDateTime(lblExpiryDate.Text) Then
                    lblValidity.Text = "Expired"
                Else
                    lblValidity.Text = "Valid"
                End If
                txtCustomerCode.Text = dr("Customer_Code")
                lblCustomerName.Text = dr("Customer_Name")
                ddlPlant.Text = dr("Plant")
                'ddlItemType.Text = dr("Item_Type")
                txtItemType.Text = dr("Item_Type")
                txtItemCode.Text = dr("Item_Code")
                lblItemDescription.Text = dr("Item_Desc")
                txtBlend.Text = dr("Blend")
                txtEPI.Text = dr("Epi")
                txtPPI.Text = dr("Ppi")
                txtWeightGSM.Text = dr("Gsm")
                txtWeave.Text = dr("Weave")
                txtWidth.Text = dr("Width")
                'ddlFinish.Items.FindByText(dr("Finish")).Selected = True
                chkSample.Checked = IIf(dr("Sample_Reqd") = 1, True, False)
                txtSampleRef.Text = dr("Sample_Ref")
                chkLabDip.Checked = IIf(dr("Labdip_Reqd") = 1, True, False)
                txtLabdipRef.Text = dr("Labdip_Ref")
                txtRemark.Text = dr("Remark")
                lblRevision.Text = dr("Rev_No").ToString
            Else
                ScriptManager.RegisterClientScriptBlock(Me, Me.GetType, "scr", "<script type = 'javascript'>Alert('Please specify valid Quotation No. in Quotation No Field.'</script>", False)
                Exit Sub
            End If
        Catch ex As Exception
            ofn.Alert(ex.Message)

        End Try

        dr.Close()
        grdWarpWeft.DataSource = sdsQuoteFabCount
        grdWarpWeft.DataBind()

        sqlstr = "jct_ops_get_quote_cost_detail '" & txtQuotationNo.Text & "'"
        cmd = New SqlCommand(sqlstr, cn.Connection)
        dr = cmd.ExecuteReader()
        If dr.HasRows Then

            dr.Read()
            txtRawMaterial.Text = dr("Raw_Material")
            txtSpinning.Text = dr("Spinning")
            txtWeaving.Text = dr("Weaving")
            txtSizing.Text = dr("Sizing")
            txtProcessing.Text = dr("Processing")
            txtShrinkage.Text = dr("Shrinkage")
            txtFinishing.Text = dr("Finishing")
            txtValueLoss.Text = dr("Value_Loss")
            txtSellingExp.Text = dr("Selling_Exp")
            lblSellPrice.Text = IIf(dr("Selling_Price") Is Nothing, "0", dr("Selling_Price"))
            lblDnVCost.Text = dr("DNV_Cost")
            lblPrefMarginPerc.Text = dr("Margin_Perc")
        Else

        End If
        dr.Close()

        'hfdItem.Value = txtItemCode.Text
        grdCosting.DataSource = SqlDataSource1
        grdCosting.DataBind()

    End Sub

    Protected Sub cmdAuthorise_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles cmdAuthorise.Click

        Dim sqlstr As String = "jct_ops_authorise_quote"
        Dim cn As New Connection
        Dim cmd As SqlCommand = New SqlCommand(sqlstr, cn.Connection)

        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@Quotation_No", SqlDbType.VarChar, 16)
        cmd.Parameters("@Quotation_No").Value = lblQuotationNo.Text

        cmd.Parameters.Add("@User_Code", SqlDbType.VarChar, 10)
        cmd.Parameters("@User_Code").Value = Session("EmpCode")

        cmd.Parameters.Add("@User_Type", SqlDbType.VarChar, 10)
        cmd.Parameters("@User_Type").Value = "SP"

        'cmd.Parameters.Add("@Rev_No", SqlDbType.Int)
        'cmd.Parameters("@Rev_No").Value = 0

        Try
            cn.ConOpen()
            cmd.ExecuteNonQuery()
            cn.ConClose()

        Catch ex As Exception
            ofn.Alert(ex.Message)

        End Try

        ibtViewQuotation_Click(sender, Nothing)

    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim quot_no As String = Request.QueryString("quot")

        If quot_no <> "" And txtQuotationNo.Text = "" Then
            txtQuotationNo.Text = quot_no
            ibtViewQuotation_Click(sender, Nothing)
        ElseIf quot_no <> "" And txtQuotationNo.Text <> "" Then
            ibtViewQuotation_Click(sender, Nothing)

        End If

    End Sub

    'Protected Sub ddlMarginPerc_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlMarginPerc.SelectedIndexChanged
    '    lblMargin.Text = Val(lblDnVCost.Text) * ddlMarginPerc.SelectedItem.Value / 100

    'End Sub

    Protected Sub ibtSearchQuotation_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles ibtSearchQuotation.Click
        Response.Redirect("QuotationPanel1.aspx")

    End Sub

    Protected Sub ibtSave1_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles ibtSave1.Click
        ibtSave_Click(sender, Nothing)

    End Sub

    Protected Sub cmdAuthorise2_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles cmdAuthorise2.Click
        cmdAuthorise_Click(sender, Nothing)

    End Sub

    Protected Sub ImageButton1_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        Response.Redirect("Quotation_Main.aspx")

    End Sub

    Protected Sub ibtBasicInfo_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles ibtBasicInfo.Click
        'Response.Redirect("Quotation_Main.aspx?quot=" & IIf(lblQuotationNo.Text = "", txtQuotationNo.Text, lblQuotationNo.Text))

    End Sub

    Protected Sub ibtPayTerms_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles ibtPayTerms.Click
        Response.Redirect("Quotation_Pay_Terms.aspx?quot=" & IIf(lblQuotationNo.Text = "", txtQuotationNo.Text, lblQuotationNo.Text))

    End Sub

    Protected Sub ibtDispatchDetail_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles ibtDispatchDetail.Click
        Response.Redirect("Quotation_Dispatch_Sch.aspx?quot=" & IIf(lblQuotationNo.Text = "", txtQuotationNo.Text, lblQuotationNo.Text))

    End Sub

    Protected Sub ibtShadeQty_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles ibtShadeQty.Click
        Response.Redirect("Quotation_Qty.aspx?quot=" & lblQuotationNo.Text)
    End Sub

    Protected Sub ibtFreeze_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles ibtFreeze.Click

    End Sub

    Protected Sub ImageButton12_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles ImageButton12.Click
        Response.Redirect("Quotation_Main.aspx")

    End Sub

    Protected Sub cmdEnquiryRequest_Click(sender As Object, e As System.EventArgs) Handles cmdEnquiryRequest.Click
        Dim sm As New SendMail
        Dim body As String = "<p>Hello,</p><p> Please provide production feasibility and cost sheet for the given particulars<p><p>" & _
                "Blend : " & txtBlend.Text & "<br/>" & _
                "EPI : " & txtEPI.Text & "<br/>" & _
                "PPI : " & txtPPI.Text & "<br/>" & _
                "Width : " & txtWidth.Text & "<br/>" & _
                "Weight(GSM) : " & txtWeightGSM.Text & "<br/>" & _
                "Weave : " & txtWeightGSM.Text & "<br/>" & _
                "</br>Thanks,<br/>" & Session("EmpName") & "<br/>JCT LTD, Phagwara</p>"

        sm.SendMail("jagdeep@jctltd.com", "dummy@jctltd.com", "Request for New Fabric Particular Enquiry and its Cost", body)
        sm.SendMail("harendra@jctltd.com", "dummy@jctltd.com", "Request for New Fabric Particular Enquiry and its Cost", body)

    End Sub

    Protected Sub cmdReqExtCost_Click(sender As Object, e As System.EventArgs) Handles cmdReqExtCost.Click
        Dim sm As New SendMail
        Dim str As String = ""
        Dim body As String = "<p>Hello,</p><p> Please provide external/market cost detail for the given particulars<p><p>" & _
                "Sort No : " & txtItemCode.Text & "<br/>" & _
                "Description : " & lblItemDescription.Text & "<br/>" & _
                "Blend : " & txtBlend.Text & "<br/>" & _
                "EPI : " & txtEPI.Text & "<br/>" & _
                "PPI : " & txtPPI.Text & "<br/>" & _
                "Width : " & txtWidth.Text & "<br/>" & _
                "Weight(GSM) : " & txtWeightGSM.Text & "<br/>" & _
                "Weave : " & txtWeightGSM.Text & "<br/><br/>"

        str += "Warp Weft Detail<br/>"
        For Each row As GridViewRow In grdWarpWeft.Rows

            str += row.Cells(0).Text & ", " & row.Cells(1).Text & ", " & row.Cells(3).Text '& ", " & row.Cells(3).Text & ", " & row.Cells(4).Text & ", " & row.Cells(5).Text & ", " & row.Cells(6).Text
            str += "<br/>"
        Next
        str += "</br>Thanks,<br/>" & Session("EmpName") & "<br/>JCT LTD, Phagwara</p>"
        sm.SendMail("jagdeep@jctltd.com", "dummy@jctltd.com", "Request for External Cost", body & str)
        sm.SendMail("harendra@jctltd.com", "dummy@jctltd.com", "Request for External Cost", body & str)

    End Sub

    Protected Sub cmdReqFreshCost_Click(sender As Object, e As System.EventArgs) Handles cmdReqFreshCost.Click

        Dim sm As New SendMail

        Dim body As String = "<p>Hello,</p><p> Please provide fresh cost sheet for the given quality/particulars<p><p>" & _
                "Sort No : " & txtItemCode.Text & "<br/>" & _
                "Description : " & lblItemDescription.Text & "<br/>" & _
                "Blend : " & txtBlend.Text & "<br/>" & _
                "EPI : " & txtEPI.Text & "<br/>" & _
                "PPI : " & txtPPI.Text & "<br/>" & _
                "Width : " & txtWidth.Text & "<br/>" & _
                "Weight(GSM) : " & txtWeightGSM.Text & "<br/>" & _
                "Weave : " & txtWeightGSM.Text & "<br/>" & _
                "</br>Thanks,<br/>" & Session("EmpName") & "<br/>JCT LTD, Phagwara</p>"

        sm.SendMail("jagdeep@jctltd.com", "dummy@jctltd.com", "Request for New Fabric Particular Enquiry and its Cost", body)
        sm.SendMail("harendra@jctltd.com", "dummy@jctltd.com", "Request for New Fabric Particular Enquiry and its Cost", body)

    End Sub

    Protected Sub ImageButton13_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles ImageButton13.Click
        Response.Redirect("Quotation_Preview.aspx?quot=" & lblQuotationNo.Text)
    End Sub

    Protected Sub txtItemType_TextChanged(sender As Object, e As System.EventArgs) Handles txtItemType.TextChanged

    End Sub

    Protected Sub txtCustomerCode_TextChanged(sender As Object, e As System.EventArgs) Handles txtCustomerCode.TextChanged

    End Sub

    Protected Sub txtSearchItem_TextChanged(sender As Object, e As System.EventArgs) Handles txtSearchItem.TextChanged
        Try
            lblItemDescription.Text = txtSearchItem.Text.Split("~c")(0).ToString
            txtItemCode.Text = txtSearchItem.Text.Split("~c")(1).ToString
            txtItemCode_TextChanged(sender, Nothing)
            txtItemType.Focus()
        Catch ex As Exception
            ofn.Alert("Please Type/Select Valid Item")
        End Try

    End Sub

    Protected Sub ibtRefresh_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles ibtRefresh.Click
        txtItemCode_TextChanged(sender, Nothing)
    End Sub

    Protected Sub cmdViewCostDetails_Click(sender As Object, e As System.EventArgs) Handles cmdViewCostDetails.Click
        grdCosting.DataSource = SqlDataSource1
        grdCosting.DataBind()

    End Sub

End Class
