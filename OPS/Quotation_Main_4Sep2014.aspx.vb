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
            grdCosting.DataSource = SqlDataSource1
            grdCosting.DataBind()
            grdCosting.SelectedIndex = -1
        Catch ex As Exception
            ofn.Alert("Please enter valid Item Code")
        End Try

        Get_Fabric_Particulars(txtItemCode.Text, lblEnqNo.Text, lblDevNo.Text)

    End Sub

    Protected Sub ResetCostDetail()

        txtRawMaterial.Text = ""
        txtSpinning.Text = ""
        txtWeaving.Text = ""
        txtSizing.Text = ""
        txtProcessing.Text = ""
        txtFinishing.Text = ""
        txtPacking.Text = ""
        'txtValueLoss.Text = ""
        'txtShrinkage.Text = ""
        txtSellingExp.Text = ""
        lblDnVCost.Text = ""
        lblPrefMarginPerc.Text = ""
        lblSellPrice.Text = ""
        lblGreighCost.Text = ""
        lblShrCost.Text = ""
        lblDyeChemCost.Text = ""
        lblValLoss.Text = ""
        lblFinishUpchrg.Text = ""
        lblSellExp.Text = ""
        lblPrintingCost.Text = ""
        lblDnv.Text = ""

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

    Protected Sub Get_Fabric_Particulars(sort As String, enqno As String, devno As String)

        Dim sqlstr As String = "jct_ops_get_fabric_param " & sort & ", " & enqno & ", " & devno
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

    Protected Sub Get_Cost_Details(sort As String, memo_no As String, memo_dt As String, plant As String, finish As String, printing As String, dyetype As String) ', loom As String, customer As String)

        Dim sqlstr As String = "jct_ops_get_cost_detail '" & sort & "','" & memo_no & "','" & memo_dt & "','" & plant & "','" & finish & "','" & dyetype & "','All','" & printing & "'"
        Dim dr As SqlDataReader = ofn.FetchReader(sqlstr)
        If dr.HasRows Then

            dr.Read()

            txtRawMaterial.Text = IIf(IsDBNull(dr("Raw Material")), "0", dr("Raw Material").ToString)
            txtSpinning.Text = IIf(IsDBNull(dr("Spinning")), "0", dr("Spinning").ToString)
            txtSizing.Text = IIf(IsDBNull(dr("Sizing")), "0", dr("Sizing").ToString)
            txtWeaving.Text = IIf(IsDBNull(dr("Weaving")), "0", dr("Weaving").ToString)
            txtProcessing.Text = IIf(IsDBNull(dr("Prc Mc Cost")), "0", dr("Prc Mc Cost").ToString)
            'txtShrinkage.Text = IIf(IsDBNull(dr("Shrinkage")), "0", dr("Shrinkage"))
            txtPacking.Text = IIf(IsDBNull(dr("Packing")), "0", dr("Packing").ToString)
            'txtValueLoss.Text = IIf(IsDBNull(dr("Value_Loss")), "0", dr("Value_Loss"))
            txtSellingExp.Text = IIf(IsDBNull(dr("Selling_Exp")), "0", dr("Selling_Exp").ToString)
            txtFinishing.Text = dr("fin_Cst").ToString
            lblSellPrice.Text = IIf(IsDBNull(dr("Selling_Price")), "0", dr("Selling_Price").ToString)
            lblDnVCost.Text = IIf(IsDBNull(dr("Dnv_Cost")), "0", dr("Dnv_Cost").ToString)

            'lblPrefMarginPerc.Text = Math.Round((Val(lblSellPrice.Text) - Val(lblDnVCost.Text)) * 100 / Val(lblDnVCost.Text), 2)
            lblPrefMarginPerc.Text = Math.Round(dr("Pref_SP%"), 2).ToString

            lblGreighCost.Text = Math.Round(dr("gry_cost"), 2).ToString
            lblShrCost.Text = Math.Round(dr("Shrinkage_Cost"), 2).ToString
            lblValLoss.Text = Math.Round(dr("Value_Loss"), 2).ToString
            lblSellExp.Text = Math.Round(dr("Selling_Exp"), 2).ToString
            lblDyeChemCost.Text = Math.Round(dr("Dye_Chem_Cost"), 2).ToString
            lblFinishUpchrg.Text = Math.Round(dr("Finishing_Cost"), 2).ToString
            lblPrintingCost.Text = Math.Round(dr("Printing_Cost"), 2).ToString

            lblDnv.Text = dr("DnV_Cost").ToString

        End If

    End Sub

    Protected Sub grdCosting_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles grdCosting.SelectedIndexChanged

        ResetCostDetail()
        Dim sort As String = txtItemCode.Text
        Dim sortno As String = grdCosting.SelectedRow.Cells(5).Text
        Dim memo_no As String = grdCosting.SelectedRow.Cells(2).Text
        Dim memo_dt As String = grdCosting.SelectedRow.Cells(15).Text
        'Dim loom As String = grdCosting.SelectedRow.Cells(7).Text
        Dim dyetype As String = grdCosting.SelectedRow.Cells(10).Text
        Dim finish As String = IIf(ddlFinish.SelectedItem.Value <> "", ddlFinish.SelectedItem.Value, "-")
        Dim printing As String = ddlPrintingType.SelectedItem.Value
        lblMemoNo.Text = memo_no
        lblMemoDate.Text = memo_dt

        Get_Cost_Details(sortno, memo_no, memo_dt, ddlPlant.SelectedItem.Value, finish, printing, dyetype) ', sortno, loom, txtCustomer.Text)

    End Sub

    Protected Sub ibtSave_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles ibtSave.Click

        Dim cn As New Connection
        Dim tr As SqlTransaction
        tr = cn.Connection.BeginTransaction
        Dim sqlstr As String = "jct_ops_create_quote"
        Dim cmd As SqlCommand = New SqlCommand(sqlstr, cn.Connection, tr)

        cmd.CommandType = CommandType.StoredProcedure

        cmd.Parameters.Add("@Quotation_No", SqlDbType.VarChar, 16)
        cmd.Parameters("@Quotation_No").Value = Trim(txtQuotationNo.Text)

        cmd.Parameters.Add("@Quotation_Type", SqlDbType.VarChar, 16)
        cmd.Parameters("@Quotation_Type").Value = ddlQuotationType.SelectedItem.Text

        cmd.Parameters.Add("@Sale_Order_Type", SqlDbType.VarChar, 16)
        cmd.Parameters("@Sale_Order_Type").Value = ddlSaleOrderType.SelectedItem.Text

        cmd.Parameters.Add("@Customer_Code", SqlDbType.VarChar, 10)
        cmd.Parameters("@Customer_Code").Value = txtCustomerCode.Text

        cmd.Parameters.Add("@Customer_Name", SqlDbType.VarChar, 100)
        cmd.Parameters("@Customer_Name").Value = lblCustomerName.Text

        Dim sp_code, sp_name As String

        sp_code = Session("EmpCode").ToString
        sp_name = Session("EmpName").ToString

        If ddlTeamLeader.SelectedIndex = 1 Then
            sp_code = ddlTeamLeader.SelectedItem.Value
            sp_name = ddlTeamLeader.SelectedItem.Text

        End If

        cmd.Parameters.Add("@Sales_Person_Code", SqlDbType.VarChar, 7)
        cmd.Parameters("@Sales_Person_Code").Value = sp_code

        cmd.Parameters.Add("@Sales_Person_Name", SqlDbType.VarChar, 40)
        cmd.Parameters("@Sales_Person_Name").Value = sp_name

        cmd.Parameters.Add("@Product_Catg", SqlDbType.VarChar, 20)
        cmd.Parameters("@Product_Catg").Value = ddlProductCatg.SelectedItem.Text

        cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 10)
        cmd.Parameters("@Plant").Value = ddlPlant.SelectedItem.Text

        cmd.Parameters.Add("@Item_Type", SqlDbType.VarChar, 20)
        cmd.Parameters("@Item_Type").Value = UCase(txtItemType.Text) 'ddlItemType.SelectedItem.Text

        cmd.Parameters.Add("@Enq_No", SqlDbType.VarChar, 10)
        cmd.Parameters("@Enq_No").Value = lblEnqNo.Text

        cmd.Parameters.Add("@Dev_No", SqlDbType.VarChar, 10)
        cmd.Parameters("@Dev_No").Value = lblDevNo.Text

        cmd.Parameters.Add("@Item_Code", SqlDbType.VarChar, 10)
        cmd.Parameters("@Item_Code").Value = txtItemCode.Text

        cmd.Parameters.Add("@Ramco_Item_Code", SqlDbType.VarChar, 10)
        cmd.Parameters("@Ramco_Item_Code").Value = UCase(txtRamcoItemCode.Text)

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

        cmd.Parameters.Add("@DyeType", SqlDbType.VarChar, 20)
        cmd.Parameters("@DyeType").Value = ddlDyeType.SelectedItem.Value

        cmd.Parameters.Add("@FinishType", SqlDbType.VarChar, 20)
        cmd.Parameters("@FinishType").Value = ddlFinish.SelectedItem.Value

        cmd.Parameters.Add("@PrintingType", SqlDbType.VarChar, 20)
        cmd.Parameters("@PrintingType").Value = ddlPrintingType.SelectedItem.Value

        cmd.Parameters.Add("@PeachingType", SqlDbType.VarChar, 20)
        cmd.Parameters("@PeachingType").Value = ddlPeachingType.SelectedItem.Value

        cmd.Parameters.Add("@PackingType", SqlDbType.VarChar, 40)
        cmd.Parameters("@PackingType").Value = ddlPackStyle.SelectedItem.Value

        cmd.Parameters.Add("@MaxShades", SqlDbType.Int)
        cmd.Parameters("@MaxShades").Value = ddlMaxShades.SelectedItem.Value

        cmd.Parameters.Add("@Memo_No", SqlDbType.VarChar, 10)
        'cmd.Parameters("@Memo_No").Value = lblMemoNo.Text

        cmd.Parameters.Add("@Memo_Dt", SqlDbType.DateTime)
        'cmd.Parameters("@Memo_Dt").Value = CDate(lblMemoDate.Text)

        cmd.Parameters.Add("@Raw_Material", SqlDbType.Float)
        'cmd.Parameters("@Raw_Material").Value = Val(txtRawMaterial.Text)

        cmd.Parameters.Add("@Spinning", SqlDbType.Float)
        'cmd.Parameters("@Spinning").Value = Val(txtSpinning.Text)

        cmd.Parameters.Add("@Weaving", SqlDbType.Float)
        'cmd.Parameters("@Weaving").Value = Val(txtWeaving.Text)

        cmd.Parameters.Add("@Sizing", SqlDbType.Float)
        'cmd.Parameters("@Sizing").Value = Val(txtSizing.Text)

        cmd.Parameters.Add("@Processing", SqlDbType.Float)
        'cmd.Parameters("@Processing").Value = Val(txtProcessing.Text)

        cmd.Parameters.Add("@Shrinkage", SqlDbType.Float)
        'cmd.Parameters("@Shrinkage").Value = Val(lblShrCost.Text)

        cmd.Parameters.Add("@Finishing", SqlDbType.Float)
        'cmd.Parameters("@Finishing").Value = Val(txtFinishing.Text)

        cmd.Parameters.Add("@Gry_Cost", SqlDbType.Float)
        'cmd.Parameters("@Gry_Cost").Value = Val(lblGreighCost.Text)

        cmd.Parameters.Add("@Dye_Chem_Cost", SqlDbType.Float)
        'cmd.Parameters("@Dye_Chem_Cost").Value = Val(lblDyeChemCost.Text)

        cmd.Parameters.Add("@Finish_Upcharge", SqlDbType.Float)
        'cmd.Parameters("@Finish_Upcharge").Value = Val(lblFinishUpchrg.Text)

        cmd.Parameters.Add("@Printing_Cost", SqlDbType.Float)
        'cmd.Parameters("@Printing_Cost").Value = Val(lblPrintingCost.Text)

        cmd.Parameters.Add("@Value_Loss", SqlDbType.Float)
        'cmd.Parameters("@Value_Loss").Value = Val(lblValLoss.Text)

        cmd.Parameters.Add("@Selling_Exp", SqlDbType.Float)
        'cmd.Parameters("@Selling_Exp").Value = Val(txtSellingExp.Text)

        cmd.Parameters.Add("@DNV_Cost", SqlDbType.Float)
        'cmd.Parameters("@DNV_Cost").Value = Val(lblDnVCost.Text)

        cmd.Parameters.Add("@Selling_Price", SqlDbType.Float)
        'cmd.Parameters("@Selling_Price").Value = Val(lblSellPrice.Text)

        cmd.Parameters.Add("@Pref_Margin_Perc", SqlDbType.Float)
        'cmd.Parameters("@Pref_Margin_Perc").Value = Val(lblPrefMarginPerc.Text)

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

        If sender.ToString = "FreshCost" Then

            cmd.Parameters("@Memo_No").Value = 0
            'cmd.Parameters("@Memo_Dt").Value = DateTime.Now.ToString()
            cmd.Parameters("@Memo_Dt").Value = CDate("01/01/1900")
            cmd.Parameters("@Raw_Material").Value = 0
            cmd.Parameters("@Spinning").Value = 0
            cmd.Parameters("@Weaving").Value = 0
            cmd.Parameters("@Sizing").Value = 0
            cmd.Parameters("@Processing").Value = 0
            cmd.Parameters("@Shrinkage").Value = 0
            cmd.Parameters("@Finishing").Value = 0
            cmd.Parameters("@Gry_Cost").Value = 0
            cmd.Parameters("@Dye_Chem_Cost").Value = 0
            cmd.Parameters("@Finish_Upcharge").Value = 0
            cmd.Parameters("@Printing_Cost").Value = 0
            cmd.Parameters("@Value_Loss").Value = 0
            cmd.Parameters("@Selling_Exp").Value = 0
            cmd.Parameters("@DNV_Cost").Value = 0
            cmd.Parameters("@Selling_Price").Value = 0
            cmd.Parameters("@Pref_Margin_Perc").Value = 0

        Else

            cmd.Parameters("@Memo_No").Value = lblMemoNo.Text
            cmd.Parameters("@Memo_Dt").Value = CDate(lblMemoDate.Text)
            cmd.Parameters("@Raw_Material").Value = Val(txtRawMaterial.Text)
            cmd.Parameters("@Spinning").Value = Val(txtSpinning.Text)
            cmd.Parameters("@Weaving").Value = Val(txtWeaving.Text)
            cmd.Parameters("@Sizing").Value = Val(txtSizing.Text)
            cmd.Parameters("@Processing").Value = Val(txtProcessing.Text)
            cmd.Parameters("@Shrinkage").Value = Val(lblShrCost.Text)
            cmd.Parameters("@Finishing").Value = Val(txtFinishing.Text)
            cmd.Parameters("@Gry_Cost").Value = Val(lblGreighCost.Text)
            cmd.Parameters("@Dye_Chem_Cost").Value = Val(lblDyeChemCost.Text)
            cmd.Parameters("@Finish_Upcharge").Value = Val(lblFinishUpchrg.Text)
            cmd.Parameters("@Printing_Cost").Value = Val(lblPrintingCost.Text)
            cmd.Parameters("@Value_Loss").Value = Val(lblValLoss.Text)
            cmd.Parameters("@Selling_Exp").Value = Val(txtSellingExp.Text)
            cmd.Parameters("@DNV_Cost").Value = Val(lblDnVCost.Text)
            cmd.Parameters("@Selling_Price").Value = Val(lblSellPrice.Text)
            cmd.Parameters("@Pref_Margin_Perc").Value = Val(lblPrefMarginPerc.Text)

        End If

        cn.ConOpen()
        Dim sm As New SendMail

        Try

            cmd.ExecuteNonQuery()
            SaveWarpWeftCountDetail(cn, tr, cmd.Parameters("@Quot_No").Value)

            Dim msg As String = ""
            Dim email_msg As String = ""

            If Trim(txtQuotationNo.Text) = "" Then
                msg = "Quotation # " & cmd.Parameters("@Quot_No").Value + " created successfully!"
            ElseIf lblQuotationNo.Text = cmd.Parameters("@Quot_No").Value Then
                msg = "Quotation # " & cmd.Parameters("@Quot_No").Value + " saved successfully!"
            End If

            If Trim(txtQuotationNo.Text) = "" Then
                email_msg = "Quotation # <a href = 'http://misdev/fusionapps/ops/Quotation_Main.aspx?quot=" & cmd.Parameters("@Quot_No").Value & "'> " & cmd.Parameters("@Quot_No").Value & "</a> created successfully! <br/> Click on Quotation Number to view details."
            ElseIf lblQuotationNo.Text = cmd.Parameters("@Quot_No").Value Then
                email_msg = "Quotation # <a href = 'http://misdev/fusionapps/ops/Quotation_Main.aspx?quot=" & cmd.Parameters("@Quot_No").Value & "'> " & cmd.Parameters("@Quot_No").Value & "</a> saved successfully! <br/> Click on Quotation Number to view details."
                'email_msg = "Quotation # " & cmd.Parameters("@Quot_No").Value + " saved successfully!"
            End If

            tr.Commit()

            lblQuotationNo.Text = cmd.Parameters("@Quot_No").Value
            txtQuotationNo.Text = cmd.Parameters("@Quot_No").Value

            'ofn.Alert(msg)
            lblMessage.Text = msg

            Try
                Dim bcc As String = "rbaksshi@jctltd.com;harendra@jctltd.com;jagdeep@jctltd.com"
                Dim dr As SqlDataReader = ofn.FetchReader("jct_fap_mistel_detail '" & Session("EmpCode").ToString & "'")
                If dr.HasRows Then
                    dr.Read()
                    sm.SendMail(dr("e_mailid").ToString(), "noreply@jctltd.com", msg + " by " + Session("EmpName"), email_msg + " <br/> " + Session("EmpName"))

                End If

                'sm.SendMail("jagjit@jctltd.com", "noreply@jctltd.com", msg + " by " + Session("EmpName"), email_msg + " <br/> Customer : " + lblCustomerName.Text + " <br/> Sales Person : " + Session("EmpName"))
                'sm.SendMail("nsaini@jctltd.com", "noreply@jctltd.com", msg + " by " + Session("EmpName"), email_msg + " <br/> Customer : " + lblCustomerName.Text + " <br/> Sales Person : " + Session("EmpName"))
                'sm.SendMail("jagdeep@jctltd.com", "noreply@jctltd.com", msg + " by " + Session("EmpName"), email_msg + " <br/> Customer : " + lblCustomerName.Text + " <br/> Sales Person : " + Session("EmpName"))
                'sm.SendMail("rbaksshi@jctltd.com", "noreply@jctltd.com", msg + " by " + Session("EmpName"), email_msg + " <br/> Customer : " + lblCustomerName.Text + " <br/> Sales Person : " + Session("EmpName"))
                'sm.SendMail("harendra@jctltd.com", "noreply@jctltd.com", msg + " by " + Session("EmpName"), email_msg + " <br/> Customer : " + lblCustomerName.Text + " <br/> Sales Person : " + Session("EmpName"))
                ''sm.SendMail("jagdeep@jctltd.com", "noreply@jctltd.com", "Quotation # " & lblQuotationNo.Text + " created successfully!", "Quotation # " & lblQuotationNo.Text + " created successfully!")

                sm.SendMail2("", "", bcc, "noreply@jctltd.com", msg + " by " + Session("EmpName"), email_msg + " <br/> Customer : " + lblCustomerName.Text + " <br/> Sales Person : " + Session("EmpName"))

                ibtViewQuotation_Click(sender, Nothing)

            Catch ex As Exception

            End Try

        Catch ex As Exception
            tr.Rollback()
            ofn.Alert(ex.Message)
            lblMessage.Text = "Error Occurred : " + ex.Message
            sm.SendMail("jagdeep@jctltd.com", "noreply@jctltd.com", "Error Occurred while creating/saving quotation" + lblQuotationNo.Text + " <br/> " + Session("EmpName"), ex.Message)

        End Try

    End Sub

    Protected Sub SaveWarpWeftCountDetail(cn As Connection, tr As SqlTransaction, quot_no As String)

        Dim sqlstr As String = "jct_ops_create_quote_fab_count"
        Dim cmd As SqlCommand = New SqlCommand(sqlstr, cn.Connection, tr)

        cmd.CommandType = CommandType.StoredProcedure

        cmd.Parameters.Add("@Quotation_no", SqlDbType.VarChar, 16)
        'cmd.Parameters.Add("@Rev_No", SqlDbType.Int)
        cmd.Parameters.Add("@Enq_No", SqlDbType.Decimal)
        cmd.Parameters.Add("@Dev_No", SqlDbType.Decimal)
        cmd.Parameters.Add("@Sort_No", SqlDbType.Decimal)
        cmd.Parameters.Add("@code", SqlDbType.Char, 1)
        cmd.Parameters.Add("@count_no", SqlDbType.VarChar, 20)
        cmd.Parameters.Add("@act_count", SqlDbType.Float)
        cmd.Parameters.Add("@count_name", SqlDbType.VarChar, 100)
        cmd.Parameters.Add("@blend", SqlDbType.VarChar, 30)
        cmd.Parameters.Add("@blend_perc", SqlDbType.VarChar, 20)
        cmd.Parameters.Add("@no_of_ends", SqlDbType.Int)
        cmd.Parameters.Add("@ClearFlag", SqlDbType.Char, 1)
        Dim cf As String = "1"
        For Each drow As GridViewRow In grdWarpWeft.Rows
            cmd.Parameters("@ClearFlag").Value = cf
            cmd.Parameters("@Quotation_no").Value = quot_no
            'cmd.Parameters("@Rev_No").Value = 0
            cmd.Parameters("@Enq_No").Value = Val(drow.Cells(0).Text)
            cmd.Parameters("@Dev_No").Value = Val(drow.Cells(1).Text)
            cmd.Parameters("@Sort_No").Value = Val(drow.Cells(2).Text)
            Dim code As String = drow.Cells(3).Text

            If code = "Weft" Then
                code = "F"
            End If

            cmd.Parameters("@code").Value = code
            cmd.Parameters("@count_no").Value = drow.Cells(4).Text
            cmd.Parameters("@act_count").Value = Val(drow.Cells(5).Text)
            cmd.Parameters("@count_name").Value = drow.Cells(6).Text
            cmd.Parameters("@blend").Value = drow.Cells(7).Text
            cmd.Parameters("@blend_perc").Value = drow.Cells(8).Text
            cmd.Parameters("@no_of_ends").Value = Val(drow.Cells(9).Text)
            cf = "0"

            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                'tr.Rollback()
                Throw New Exception("Error in saving Warp Weft Details")
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

                lblQuotationNo.Text = dr("Quotation_No").ToString
                lblStatus.Text = dr("status").ToString
                lblQuoteDate.Text = dr("Quot_Date").ToString

                txtCustomerCode.Text = dr("Customer_Code").ToString
                lblCustomerName.Text = dr("Customer_Name").ToString
                ddlPlant.Text = dr("Plant").ToString
                'ddlItemType.Text = dr("Item_Type")
                txtItemType.Text = dr("Item_Type").ToString
                txtItemCode.Text = dr("Item_Code").ToString
                lblEnqNo.Text = dr("Enq_No").ToString
                lblDevNo.Text = dr("Dev_No").ToString
                txtRamcoItemCode.Text = dr("Ramco_Item_Code").ToString
                lblItemDescription.Text = dr("Item_Desc").ToString
                txtBlend.Text = dr("Blend").ToString
                txtEPI.Text = dr("Epi").ToString
                txtPPI.Text = dr("Ppi").ToString
                txtWeightGSM.Text = dr("Gsm").ToString
                txtWeave.Text = dr("Weave").ToString
                txtWidth.Text = dr("Width").ToString
                lblSORequested.Text = dr("Req_SO").ToString

                ddlDyeType.SelectedIndex = ddlDyeType.Items.IndexOf(ddlDyeType.Items.FindByValue(dr("DyeType").ToString))
                ddlFinish.SelectedIndex = ddlFinish.Items.IndexOf(ddlFinish.Items.FindByValue(dr("FinishType").ToString))
                ddlPrintingType.SelectedIndex = ddlPrintingType.Items.IndexOf(ddlPrintingType.Items.FindByValue(dr("PrintingType").ToString))
                ddlPackStyle.SelectedIndex = ddlPackStyle.Items.IndexOf(ddlPackStyle.Items.FindByValue(dr("PackingType").ToString))
                ddlMaxShades.SelectedIndex = ddlMaxShades.Items.IndexOf(ddlMaxShades.Items.FindByValue(dr("Max_Shades").ToString))
                ddlTeamLeader.SelectedIndex = ddlTeamLeader.Items.IndexOf(ddlTeamLeader.Items.FindByValue(dr("Sales_Person_Code").ToString))

                Try
                    ddlQuotationType.SelectedIndex = ddlQuotationType.Items.IndexOf(ddlQuotationType.Items.FindByValue(dr("Quotation_Type").ToString))
                    ddlSaleOrderType.SelectedIndex = ddlSaleOrderType.Items.IndexOf(ddlSaleOrderType.Items.FindByValue(dr("Sale_Order_Type").ToString))

                Catch ex As Exception

                End Try

                chkSample.Checked = IIf(dr("Sample_Reqd") = 1, True, False)
                txtSampleRef.Text = dr("Sample_Ref").ToString
                chkLabDip.Checked = IIf(dr("Labdip_Reqd") = 1, True, False)
                txtLabdipRef.Text = dr("Labdip_Ref").ToString
                txtRemark.Text = dr("Remark").ToString
                lblRevision.Text = dr("Rev_No").ToString

            Else
                ScriptManager.RegisterClientScriptBlock(Me, Me.GetType, "scr", "alert('Please specify valid Quotation No. in Quotation No Field.');", True)
                txtQuotationNo.Text = ""
                lblQuotationNo.Text = ""
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
            txtRawMaterial.Text = dr("Raw_Material").ToString
            txtSpinning.Text = dr("Spinning").ToString
            txtWeaving.Text = dr("Weaving").ToString
            txtSizing.Text = dr("Sizing").ToString
            txtProcessing.Text = dr("Processing").ToString
            'txtShrinkage.Text = dr("Shrinkage")
            lblShrCost.Text = dr("Shrinkage").ToString
            txtFinishing.Text = dr("Finishing").ToString
            'txtValueLoss.Text = dr("Value_Loss")
            lblGreighCost.Text = dr("Gry_Cost").ToString
            lblFinishUpchrg.Text = dr("Finish_Upcharge").ToString
            lblDyeChemCost.Text = dr("Dye_Chem_Cost").ToString
            lblPrintingCost.Text = dr("Printing_Cost").ToString
            lblValLoss.Text = dr("Value_Loss").ToString
            txtSellingExp.Text = dr("Selling_Exp").ToString
            lblSellExp.Text = dr("Selling_Exp").ToString
            lblSellPrice.Text = IIf(dr("Selling_Price") Is Nothing, "0", dr("Selling_Price"))
            lblDnVCost.Text = dr("DNV_Cost").ToString
            lblDnv.Text = dr("DNV_Cost").ToString
            lblPrefMarginPerc.Text = dr("Margin_Perc").ToString
            lblMemoNo.Text = dr("Memo_No").ToString
            lblMemoDate.Text = dr("Memo_Date").ToString()

            If lblMemoDate.Text <> "01 Jan 1900" Then

                If ddlQuotationType.SelectedItem.Text = "Regular" Then
                    lblExpiryDate.Text = Convert.ToDateTime(lblMemoDate.Text).AddDays(11).ToString()
                ElseIf ddlQuotationType.SelectedItem.Text = "Forecast" Then
                    lblExpiryDate.Text = Convert.ToDateTime(lblQuoteDate.Text).AddDays(30).ToString()
                End If

            ElseIf lblMemoDate.Text = "01 Jan 1900" Then

                lblExpiryDate.Text = "N.A."
                lblExpiryDate.ForeColor = Drawing.Color.Red
            End If

            If lblExpiryDate.Text <> "N.A." Then
                If DateTime.Now >= Convert.ToDateTime(lblExpiryDate.Text) Then

                    lblValidity.Text = "Expired"
                    lblValidity.ForeColor = Drawing.Color.Red

                Else

                    lblValidity.Text = "Valid"
                    lblValidity.ForeColor = Drawing.Color.Green

                End If

            Else
                lblValidity.Text = "N.A."
                lblValidity.ForeColor = Drawing.Color.Red
            End If

        End If

        dr.Close()

        Get_Additional_Info(txtQuotationNo.Text)

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

        Dim sm As New SendMail
        Dim str, body_to, subject As String

        str = ""
        body_to = ""
        subject = ""

        Try
            cn.ConOpen()
            cmd.ExecuteNonQuery()
            cn.ConClose()
            lblMessage.Text = "Quotation # " + lblQuotationNo.Text + " has been authorised by " + Session("EmpName").ToString + " : " + Session("EmpCode").ToString

            Try

                Dim bcc As String = "rbaksshi@jctltd.com; jagdeep@jctltd.com; harendra@jctltd.com"
                subject = "Authorisation of Quotation No. " & lblQuotationNo.Text & " has been done by " + Session("EmpName").ToString '+ " : " + Session("EmpCode").ToString
                body_to = "Quotation # <a href = 'http://misdev/fusionapps/ops/Quotation_Main.aspx?quot=" & lblQuotationNo.Text & "'> " & lblQuotationNo.Text & "</a> has been Authorised successfully! " + Session("EmpName").ToString + "<br/> Click on Quotation Number to view details."

                sqlstr = "jct_ops_get_quot_mail_recipients"

                cmd = New SqlCommand(sqlstr, cn.Connection)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.Add("Quotation_No", SqlDbType.VarChar, 16)
                cmd.Parameters("Quotation_No").Value = lblQuotationNo.Text
                cmd.Parameters.Add("Action", SqlDbType.VarChar, 20)
                cmd.Parameters("Action").Value = "QuotAuthLM"
                cmd.Parameters.Add("User_Code", SqlDbType.VarChar, 10)
                cmd.Parameters("User_Code").Value = Session("EmpCode").ToString

                Dim dr As SqlDataReader
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)

                Dim recipients, m_sender, sender_name, recipient_name As String
                recipients = ""
                m_sender = ""
                sender_name = ""
                recipient_name = ""

                If dr.HasRows Then
                    While dr.Read
                        If dr(0).ToString = "To" Then
                            recipients += dr("e_mailid").ToString + ";"
                            recipient_name += dr("empname").ToString + ","
                        ElseIf dr(0).ToString = "From" Then
                            m_sender = dr("e_mailid").ToString
                            sender_name = dr("empname").ToString
                        End If
                    End While
                End If
                dr.Close()

                bcc = "rbaksshi@jctltd.com; jagdeep@jctltd.com; harendra@jctltd.com"
                sm.SendMail2(recipients, "", bcc, "noreply@jctltd.com", subject, body_to)

            Catch ex As Exception
                lblMessage.Text = "Error sending email to concerned person(s)."
            End Try

        Catch ex As Exception
            ofn.Alert(ex.Message)

        End Try

        ibtViewQuotation_Click(sender, Nothing)

    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        Dim quot_no As String = Request.QueryString("quot")
        Dim i As Integer
        ddlMaxShades.Items.Clear()

        For i = 1 To 20
            ddlMaxShades.Items.Add(i)
        Next

        If lblQuotationNo.Text = "" Then
            ddlMaxShades.Enabled = True
        ElseIf lblQuotationNo.Text <> "" Then
            ddlMaxShades.Enabled = False
        End If

        If Not IsPostBack Then
            Dim li As New ListItem(Session("EmpName"), Session("EmpCode"))

            'rblQuotOwner.Items.Add(li)
            ddlDyeType.DataBind()
            ddlFinish.DataBind()
            ddlPrintingType.DataBind()
            ddlPackStyle.DataBind()

            If dsPackingStyle.SelectParameters.Count > 0 Then
                If ddlPlant.SelectedItem.Value = "Cotton" Then
                    dsPackingStyle.SelectParameters("PackStyle").DefaultValue = "PackingStyle"
                ElseIf ddlPlant.SelectedItem.Value = "Taffeta" Then
                    dsPackingStyle.SelectParameters("PackStyle").DefaultValue = "TPackingStyle"
                Else
                    dsPackingStyle.SelectParameters("PackStyle").DefaultValue = ""
                End If
                ddlPackStyle.DataBind()

            End If

        End If

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
        Response.Redirect("Quotation_Panel.aspx")

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
        Dim str As String = ""

        Dim body_to As String = "<p>Hello,</p><p> Please provide production feasibility and cost sheet for the given particulars<p><p>" & _
                "Blend : " & txtBlend.Text & "<br/>" & _
                "EPI : " & txtEPI.Text & "<br/>" & _
                "PPI : " & txtPPI.Text & "<br/>" & _
                "Width : " & txtWidth.Text & "<br/>" & _
                "Weight(GSM) : " & txtWeightGSM.Text & "<br/>" & _
                "Weave : " & txtWeave.Text & "<br/>" & _
                "</br>Thanks,<br/>" & Session("EmpName") & "<br/>JCT LTD, Phagwara</p>"

        For Each row As GridViewRow In grdWarpWeft.Rows
            str += row.Cells(0).Text & ", " & row.Cells(1).Text & ", " & row.Cells(3).Text
            str += "<br/>"
        Next

        'sm.SendMail("jagdeep@jctltd.com", "noreply@jctltd.com", "Request for New Fabric Particular Enquiry and its Cost", body_to)
        'sm.SendMail("harendra@jctltd.com", "noreply@jctltd.com", "Request for New Fabric Particular Enquiry and its Cost", body_to)
        'sm.SendMail("rbaksshi@jctltd.com", "noreply@jctltd.com", "Request for New Fabric Particular Enquiry and its Cost", body_to)
        'sm.SendMail("nsaini@jctltd.com", "noreply@jctltd.com", "Request for New Fabric Particular Enquiry and its Cost", body_to)
        'sm.SendMail("jagjit@jctltd.com", "noreply@jctltd.com", "Request for New Fabric Particular Enquiry and its Cost", body_to)
        'sm.SendMail("tajinderpal@jctltd.com", "noreply@jctltd.com", "Request for External Cost", body_to & str)

        Dim bcc As String = "rbaksshi@jctltd.com; jagdeep@jctltd.com; harendra@jctltd.com"
        sm.SendMail2("jagjit@jctltd.com;nsaini@jctltd.com;tajinderpal@jctltd.com", "", bcc, "noreply@jctltd.com", "Request for New Fabric Particular Enquiry and its Cost ", body_to & str)

        Dim dr As SqlDataReader = ofn.FetchReader("jct_fap_mistel_detail '" & Session("EmpCode").ToString & "'")
        If dr.HasRows Then
            dr.Read()
            Dim body_from As String = "<p>Hello " & Session("EmpName") & ",</p><p> Your request has been forwarded to check production feasibility and to get cost sheet for the given particulars<p><p>" & _
               "Blend : " & txtBlend.Text & "<br/>" & _
               "EPI : " & txtEPI.Text & "<br/>" & _
               "PPI : " & txtPPI.Text & "<br/>" & _
               "Width : " & txtWidth.Text & "<br/>" & _
               "Weight(GSM) : " & txtWeightGSM.Text & "<br/>" & _
               "Weave : " & txtWeave.Text & "<br/>" & _
               "</br>Thanks,<br/>JCT LTD, Phagwara</p>"
            sm.SendMail(dr("e_mailid").ToString(), "noreply@jctltd.com", "Request for New Fabric Particular Enquiry and its Cost", body_from)
        End If

    End Sub

    Protected Sub cmdReqExtCost_Click(sender As Object, e As System.EventArgs) Handles cmdReqExtCost.Click

        Dim sm As New SendMail
        Dim str As String = ""

        ibtSave_Click("FreshCost", Nothing)

        Dim body_to As String = "<p>Hello,</p><p> Please provide external/market cost detail for the given particulars as per quotation no " & lblQuotationNo.Text & "<p><p>" & _
                "Customer : " & lblCustomerName.Text & " (" & txtCustomerCode.Text & ")" & "<br/>" & _
                "Item Type : " & txtItemType.Text & "<br/>" & _
                "Sort No : " & txtItemCode.Text & "<br/>" & _
                "Enq. No : " & lblEnqNo.Text & "<br/>" & _
                "Dev. No : " & lblDevNo.Text & "<br/>" & _
                "Description : " & lblItemDescription.Text & "<br/>" & _
                "Blend : " & txtBlend.Text & "<br/>" & _
                "EPI : " & txtEPI.Text & "<br/>" & _
                "PPI : " & txtPPI.Text & "<br/>" & _
                "Width : " & txtWidth.Text & "<br/>" & _
                "Weight(GSM) : " & txtWeightGSM.Text & "<br/>" & _
                "Weave : " & txtWeave.Text & "<br/>" & _
                "Dye Type : " & ddlDyeType.SelectedItem.Text & "<br/>" & _
                "Finish : " & ddlFinish.SelectedItem.Text & "<br/>" & _
                "Printing Type : " & ddlPrintingType.SelectedItem.Text & "<br/>" & _
                "Peaching Type : " & ddlPeachingType.SelectedItem.Text & "<br/>" & _
                "Remarks : " & txtRemark.Text & _
                "<br/>"

        str += "Warp Weft Detail<br/>"

        For Each row As GridViewRow In grdWarpWeft.Rows
            str += row.Cells(0).Text & ", " & row.Cells(1).Text & ", " & row.Cells(3).Text '& ", " & row.Cells(3).Text & ", " & row.Cells(4).Text & ", " & row.Cells(5).Text & ", " & row.Cells(6).Text
            str += "<br/>"
        Next

        str += "</br>Thanks,<br/>" & Session("EmpName") & "<br/>JCT LTD, Phagwara</p>"

        'sm.SendMail("jagdeep@jctltd.com", "noreply@jctltd.com", "Request for External Cost", body_to & str)
        'sm.SendMail("harendra@jctltd.com", "noreply@jctltd.com", "Request for External Cost", body_to & str)
        'sm.SendMail("rbaksshi@jctltd.com", "noreply@jctltd.com", "Request for External Cost", body_to & str)
        'sm.SendMail("nsaini@jctltd.com", "noreply@jctltd.com", "Request for External Cost", body_to & str)
        'sm.SendMail("jagjit@jctltd.com", "noreply@jctltd.com", "Request for External Cost", body_to & str)
        'sm.SendMail("rajgopal@jctltd.com", "noreply@jctltd.com", "Request for External Cost", body_to & str)
        'sm.SendMail("tajinderpal@jctltd.com", "noreply@jctltd.com", "Request for External Cost", body_to & str)

        Dim bcc As String = "rbaksshi@jctltd.com; jagdeep@jctltd.com; harendra@jctltd.com"

        sm.SendMail2("jagjit@jctltd.com;nsaini@jctltd.com;rajgopal@jctltd.com;tajinderpal@jctltd.com", "", bcc, "noreply@jctltd.com", "Request for External/Market Cost ", body_to & str)

        Dim dr As SqlDataReader = ofn.FetchReader("jct_fap_mistel_detail '" & Session("EmpCode").ToString & "'")
        If dr.HasRows Then
            dr.Read()
            Dim body_from As String = "<p>Hello, " & Session("EmpName") & "</p><p> Your request has been forwarded regrading external/market cost detail for the given particulars<p><p>" & _
                "Customer : " & lblCustomerName.Text & " (" & txtCustomerCode.Text & ")" & "<br/>" & _
                "Item Type : " & txtItemType.Text & "<br/>" & _
                "Sort No : " & txtItemCode.Text & "<br/>" & _
                "Enq. No : " & lblEnqNo.Text & "<br/>" & _
                "Dev. No : " & lblDevNo.Text & "<br/>" & _
                "Description : " & lblItemDescription.Text & "<br/>" & _
                "Blend : " & txtBlend.Text & "<br/>" & _
                "EPI : " & txtEPI.Text & "<br/>" & _
                "PPI : " & txtPPI.Text & "<br/>" & _
                "Width : " & txtWidth.Text & "<br/>" & _
                "Weight(GSM) : " & txtWeightGSM.Text & "<br/>" & _
                "Weave : " & txtWeave.Text & "<br/>" & _
                "Dye Type : " & ddlDyeType.SelectedItem.Text & "<br/>" & _
                "Finish : " & ddlFinish.SelectedItem.Text & "<br/>" & _
                "Printing Type : " & ddlPrintingType.SelectedItem.Text & "<br/>" & _
                "Peaching Type : " & ddlPeachingType.SelectedItem.Text & "<br/>" & _
                "Remarks : " & txtRemark.Text & _
                "<br/>"

            str += "Warp Weft Detail<br/>"

            For Each row As GridViewRow In grdWarpWeft.Rows
                str += row.Cells(0).Text & ", " & row.Cells(1).Text & ", " & row.Cells(3).Text '& ", " & row.Cells(3).Text & ", " & row.Cells(4).Text & ", " & row.Cells(5).Text & ", " & row.Cells(6).Text
                str += "<br/>"
            Next

            str += "</br>Thanks,<br/>JCT LTD, Phagwara</p>"
            sm.SendMail(dr("e_mailid").ToString(), "noreply@jctltd.com", "Request for External Cost", body_from)

        End If

    End Sub

    Protected Sub cmdReqFreshCost_Click(sender As Object, e As System.EventArgs) Handles cmdReqFreshCost.Click

        Dim sm As New SendMail
        ibtSave_Click("FreshCost", Nothing)

        Dim body_to As String = "<p>Hello,</p><p> Please provide fresh cost sheet for the given quality/particulars as per quotation no " & lblQuotationNo.Text & " <p><p>" & _
                "Customer : " & lblCustomerName.Text & " (" & txtCustomerCode.Text & ")" & "<br/>" & _
                "Item Type : " & txtItemType.Text & "<br/>" & _
                "Sort No : " & txtItemCode.Text & "<br/>" & _
                "Enq. No : " & lblEnqNo.Text & "<br/>" & _
                "Dev. No : " & lblDevNo.Text & "<br/>" & _
                "Description : " & lblItemDescription.Text & "<br/>" & _
                "Blend : " & txtBlend.Text & "<br/>" & _
                "EPI : " & txtEPI.Text & "<br/>" & _
                "PPI : " & txtPPI.Text & "<br/>" & _
                "Width : " & txtWidth.Text & "<br/>" & _
                "Weight(GSM) : " & txtWeightGSM.Text & "<br/>" & _
                "Weave : " & txtWeave.Text & "<br/>" & _
                "Dye Type : " & ddlDyeType.SelectedItem.Text & "<br/>" & _
                "Finish : " & ddlFinish.SelectedItem.Text & "<br/>" & _
                "Printing Type : " & ddlPrintingType.SelectedItem.Text & "<br/>" & _
                "Peaching Type : " & ddlPeachingType.SelectedItem.Text & "<br/>" & _
                "Remarks : " & txtRemark.Text & _
                "<br/>" & _
                "</br>Thanks<br/>" & Session("EmpName") & "<br/>JCT LTD, Phagwara</p>"

        Dim sort_dev_enq As String = ""

        If txtItemCode.Text <> "1" Then
            sort_dev_enq = "Sort No: " + txtItemCode.Text
        ElseIf lblDevNo.Text <> "1" Then
            sort_dev_enq = "Development No: " + txtItemCode.Text
        ElseIf lblEnqNo.Text <> "1" Then
            sort_dev_enq = "Enquiry No: " + txtItemCode.Text
        End If

        'sm.SendMail("jagdeep@jctltd.com", "noreply@jctltd.com", "Request for New Fabric Particular Enquiry and its Cost", body_to)
        'sm.SendMail("harendra@jctltd.com", "noreply@jctltd.com", "Request for New Fabric Particular Enquiry and its Cost", body_to)
        'sm.SendMail("rbaksshi@jctltd.com", "noreply@jctltd.com", "Request for New Fabric Particular Enquiry and its Cost", body_to)
        'sm.SendMail("nsaini@jctltd.com", "noreply@jctltd.com", "Request for New Fabric Particular Enquiry and its Cost", body_to)
        'sm.SendMail("jagjit@jctltd.com", "noreply@jctltd.com", "Request for New Fabric Particular Enquiry and its Cost", body_to)

        Dim bcc As String = "rbaksshi@jctltd.com; jagdeep@jctltd.com; harendra@jctltd.com"
        sm.SendMail2("jagjit@jctltd.com;nsaini@jctltd.com", "", bcc, "noreply@jctltd.com", "Request for Fresh Cost Sheet for Sort No : " & txtItemCode.Text, body_to)

        Dim dr2 As SqlDataReader = ofn.FetchReader("jct_fap_mistel_detail '" & Session("EmpCode").ToString & "'")
        If dr2.HasRows Then
            dr2.Read()

            Dim body_from As String = "<p>Hello, " & Session("EmpName") & "</p><p> Your request has been forwarded regrading fresh cost sheet for the given quality/particulars as per quotation no " & lblQuotationNo.Text & "<p><p>" & _
                "Customer : " & lblCustomerName.Text & " (" & txtCustomerCode.Text & ")" & "<br/>" & _
                "Item Type : " & txtItemType.Text & "<br/>" & _
                "Sort No : " & txtItemCode.Text & "<br/>" & _
                "Enq. No : " & lblEnqNo.Text & "<br/>" & _
                "Dev. No : " & lblDevNo.Text & "<br/>" & _
                "Description : " & lblItemDescription.Text & "<br/>" & _
                "Blend : " & txtBlend.Text & "<br/>" & _
                "EPI : " & txtEPI.Text & "<br/>" & _
                "PPI : " & txtPPI.Text & "<br/>" & _
                "Width : " & txtWidth.Text & "<br/>" & _
                "Weight(GSM) : " & txtWeightGSM.Text & "<br/>" & _
                "Weave : " & txtWeave.Text & "<br/>" & _
                "Dye Type : " & ddlDyeType.SelectedItem.Text & "<br/>" & _
                "Finish : " & ddlFinish.SelectedItem.Text & "<br/>" & _
                "Printing Type : " & ddlPrintingType.SelectedItem.Text & "<br/>" & _
                "Peaching Type : " & ddlPeachingType.SelectedItem.Text & "<br/>" & _
                "Remarks : " & txtRemark.Text & _
                "<br/>" & _
                "</br>Thanks<br/>JCT LTD, Phagwara</p>"

            Try
                sm.SendMail(dr2("e_mailid").ToString(), "noreply@jctltd.com", "Request for Fresh Cost for Sort No : " & txtItemCode.Text, body_from)
                'sm.SendMail2("jagjit@jctltd.com;nsaini@jctltd.com", dr2("e_mailid").ToString(), bcc, "noreply@jctltd.com", "Request for Fresh Cost Sheet for ", body_to)

            Catch ex As Exception

            End Try

        End If

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
            lblEnqNo.Text = txtSearchItem.Text.Split("~c")(2).ToString
            lblDevNo.Text = txtSearchItem.Text.Split("~c")(3).ToString
            txtItemCode_TextChanged(sender, Nothing)
            txtSearchItem.Text = ""
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

    Protected Sub BindCostingGrid()

        grdCosting.DataSource = SqlDataSource1
        grdCosting.DataBind()
        ResetCostDetail()

    End Sub

    Protected Sub ddlPlant_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlPlant.SelectedIndexChanged

        If dsPackingStyle.SelectParameters.Count > 0 Then

            If ddlPlant.SelectedItem.Value = "Cotton" Then
                dsPackingStyle.SelectParameters("PackStyle").DefaultValue = "PackingStyle"
            ElseIf ddlPlant.SelectedItem.Value = "Taffeta" Then
                dsPackingStyle.SelectParameters("PackStyle").DefaultValue = "TPackingStyle"
            Else
                dsPackingStyle.SelectParameters("PackStyle").DefaultValue = ""
            End If

        End If

        ddlPackStyle.DataBind()

    End Sub

    Protected Sub ddlDyeType_DataBound(sender As Object, e As System.EventArgs) Handles ddlDyeType.DataBound

    End Sub

    Protected Sub ddlDyeType_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlDyeType.SelectedIndexChanged
        BindCostingGrid()

    End Sub

    Protected Sub ddlFinish_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlFinish.SelectedIndexChanged
        BindCostingGrid()

    End Sub

    Protected Sub ddlPrintingType_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlPrintingType.SelectedIndexChanged
        BindCostingGrid()

    End Sub

    Protected Sub ddlPackStyle_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlPackStyle.SelectedIndexChanged
        BindCostingGrid()

    End Sub

    Protected Sub grdCosting_DataBound(sender As Object, e As System.EventArgs) Handles grdCosting.DataBound
        grdCosting.SelectedIndex = -1
        'ResetCostDetail()

    End Sub

    Protected Sub ibtDelete_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles ibtDelete.Click
        'jct_ops_cancel_quote

        Dim sqlstr As String = "jct_ops_cancel_quote"
        Dim cn As New Connection
        Dim cmd As SqlCommand = New SqlCommand(sqlstr, cn.Connection)
        cmd.CommandType = CommandType.StoredProcedure

        cmd.Parameters.Add("@Quotation_No", SqlDbType.VarChar, 16)
        cmd.Parameters("@Quotation_No").Value = lblQuotationNo.Text

        cmd.Parameters.Add("@User_Code", SqlDbType.VarChar, 10)
        cmd.Parameters("@User_Code").Value = Session("EmpCode").ToString

        Try
            cn.ConOpen()
            cmd.ExecuteNonQuery()
            cn.ConClose()

        Catch ex As Exception
            lblMessage.Text = ex.Message

        End Try

        ibtViewQuotation_Click(sender, Nothing)

    End Sub

    Protected Sub ddlPeachingType_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlPeachingType.SelectedIndexChanged
        BindCostingGrid()

    End Sub

    Protected Sub rblQuotOwner_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles rblQuotOwner.SelectedIndexChanged

        If rblQuotOwner.SelectedIndex = 0 Then
            'rfvSalesPerson.Enabled = False
            lblTeamLeader.Visible = False
            ddlTeamLeader.Visible = False
        ElseIf rblQuotOwner.SelectedIndex = 1 Then
            'rfvSalesPerson.Enabled = True
            lblTeamLeader.Visible = True
            ddlTeamLeader.Visible = True
        End If

    End Sub

    Protected Sub Get_Additional_Info(quot_no As String)

        If quot_no <> "" Then

            ' jct_ops_get_quot_additional_info
            Dim sqlstr As String = "jct_ops_get_quot_additional_info '" & txtQuotationNo.Text & "'"
            Dim cn As New Connection
            Dim cmd As SqlCommand = New SqlCommand(sqlstr, cn.Connection)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader()

            Try

                If dr.HasRows Then
                    dr.Read()
                    lblActualSalePrice.Text = dr("Sale_Price").ToString
                    lblActualMargin.Text = dr("Theoretical_Margin").ToString
                    lblNoOfShade.Text = dr("Shades").ToString
                    lblTotalQty.Text = dr("Quantity").ToString

                End If

            Catch ex As Exception
                lblActualSalePrice.Text = "Not Found"
                lblActualMargin.Text = "Not Found"
                lblNoOfShade.Text = "Not Found"
                lblTotalQty.Text = "Not Found"

            End Try

        End If

    End Sub

    Protected Sub cmdCancel_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles cmdCancel.Click

        Dim sqlstr As String = "jct_ops_reject_quote"
        Dim cn As New Connection
        Dim cmd As SqlCommand = New SqlCommand(sqlstr, cn.Connection)
        cmd.CommandType = CommandType.StoredProcedure

        cmd.Parameters.Add("@Quotation_no", SqlDbType.VarChar, 16)
        cmd.Parameters.Add("@User_Code", SqlDbType.VarChar, 10)
        cmd.Parameters.Add("@User_Type", SqlDbType.VarChar, 20)

        cmd.Parameters("@Quotation_no").Value = lblQuotationNo.Text
        cmd.Parameters("@User_Code").Value = Session("EmpCode").ToString
        cmd.Parameters("@User_Type").Value = "SP"

        Try
            cn.ConOpen()
            cmd.ExecuteNonQuery()
            cn.ConClose()

        Catch ex As Exception
            lblMessage.Text = ex.Message

        End Try

    End Sub

    Protected Sub ImageButton14_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles ImageButton14.Click
        Response.Redirect("Quotation_Detail_Preview.aspx?quot=" & lblQuotationNo.Text)

    End Sub

    Protected Sub cmdAuthorise_Push_SO_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles cmdAuthorise_Push_SO.Click

        Dim sqlstr As String = "jct_ops_authorise_quote"
        Dim cn As New Connection
        Dim cmd As SqlCommand = New SqlCommand(sqlstr, cn.Connection)

        cmd.CommandType = CommandType.StoredProcedure

        cmd.Parameters.Add("@Quotation_no", SqlDbType.VarChar, 16)
        cmd.Parameters.Add("@User_Code", SqlDbType.VarChar, 10)
        cmd.Parameters.Add("@User_Type", SqlDbType.VarChar, 20)
        cmd.Parameters.Add("@Req_SO", SqlDbType.Char, 1)

        cmd.Parameters("@Quotation_no").Value = lblQuotationNo.Text
        cmd.Parameters("@User_Code").Value = Session("EmpCode").ToString
        cmd.Parameters("@User_Type").Value = "SP"
        cmd.Parameters("@Req_SO").Value = "Y"

        '@Req_SO

        Try
            cn.ConOpen()
            cmd.ExecuteNonQuery()
            cn.ConClose()
            Try
                Req_PO_Mail()
            Catch ex As Exception

            End Try

        Catch ex As Exception
            lblMessage.Text += lblMessage.Text + "<br/>" + ex.Message

        End Try

    End Sub

    Protected Sub ibtDelete2_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles ibtDelete2.Click
        ibtDelete_Click(sender, Nothing)

    End Sub

    Protected Sub cmdPush_SO_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles cmdPush_SO.Click
        ' jct_ops_request_sale_order

        Dim sqlstr As String = "jct_ops_request_sale_order "
        Dim cn As New Connection
        Dim cmd As SqlCommand = New SqlCommand(sqlstr, cn.Connection)

        cmd.CommandType = CommandType.StoredProcedure

        cmd.Parameters.Add("@Quotation_no", SqlDbType.VarChar, 16)
        cmd.Parameters.Add("@User_Code", SqlDbType.VarChar, 10)

        cmd.Parameters("@Quotation_no").Value = lblQuotationNo.Text
        cmd.Parameters("@User_Code").Value = Session("EmpCode").ToString

        '@Req_SO

        Try
            cn.ConOpen()
            cmd.ExecuteNonQuery()
            cn.ConClose()

            Req_PO_Mail()
        
        Catch ex As Exception
            lblMessage.Text = ex.Message

        End Try

    End Sub

    Protected Sub Req_PO_Mail()

        Dim sm As New SendMail

        Try

            Dim subject As String = "Sale Order Request for Quotation No. " + lblQuotationNo.Text + " authorised by " + Session("EmpName").ToString

            Dim body As String = "You have got Sale Order Request for Quotation # <a href = 'http://misdev/fusionapps/ops/Quotation_Dispatch_Sch.aspx?quot=" & lblQuotationNo.Text & "'>" & lblQuotationNo.Text & "</a>.<br/> Click on Quotation Number to view details."

            'lblQuotationNo.Text = ""
            ''sm.SendMail("rbaksshi@jctltd.com; jagdeep@jctltd.com; harendra@jctltd.com", "noreply@jctltd.com", subject, body)
            'Sql = "jct_ops_get_quot_mail_recipients"
            'Dim cmd As SqlCommand = New SqlCommand(Sql, con.Connection)
            'cmd.CommandType = CommandType.StoredProcedure
            'cmd.Parameters.Add("Quotation_No", SqlDbType.VarChar, 16)
            'cmd.Parameters("Quotation_No").Value = lblQuotationNo.Text
            'cmd.Parameters.Add("Action", SqlDbType.VarChar, 20)
            'cmd.Parameters("Action").Value = "PPCAdvise"
            'cmd.Parameters.Add("User_Code", SqlDbType.VarChar, 10)
            'cmd.Parameters("User_Code").Value = Session("EmpCode").ToString
            'Dim dr As SqlDataReader
            'dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)

            Dim recipients, m_sender As String
            'recipients = "backofficesales@jctltd.com"
            recipients = "william@jctltd.com"

            m_sender = ""

            'sender_name = ""
            'recipient_name = ""

            'If dr.HasRows Then
            '    While dr.Read
            '        If dr(0).ToString = "To" Then
            '            recipients += dr("e_mailid").ToString + ";"
            '            recipient_name += dr("empname").ToString + ","
            '        ElseIf dr(0).ToString = "From" Then
            '            m_sender = dr("e_mailid").ToString
            '            sender_name = dr("empname").ToString
            '        End If
            '    End While
            'End If
            'dr.Close()

            Dim bcc As String = "rbaksshi@jctltd.com; jagdeep@jctltd.com; harendra@jctltd.com"
            sm.SendMail2(recipients, "", bcc, "noreply@jctltd.com", subject, body)

        Catch ex As Exception
            sm.SendMail2("jagdeep@jctltd.com", "", "", "noreply@jctltd.com", "Error Occurred while sending mail for Sale Order Request for Quotation # " + lblQuotationNo.Text, ex.Message)

        End Try

    End Sub

End Class

