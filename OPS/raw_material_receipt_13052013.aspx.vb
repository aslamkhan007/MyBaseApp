Imports System.Data.SqlClient
Imports System.Data
Imports System.Web.HttpResponse
Imports vb = Microsoft.VisualBasic
Imports System.String
Imports System.Math
Partial Class OPS_raw_material_receipt
    Inherits System.Web.UI.Page
    Dim sql As String
    Dim dr As SqlDataReader
    Dim cmd As SqlCommand
    Dim sqlpass, sno2 As String
    Public obj As New HelpDeskClass
    Dim Ash, sno1 As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Session("Companycode") = "JCT00LTD"
        'Session("Empcode") = "C-00509"

        If Not IsPostBack Then

            'Dim cl(3) As String
            'Dim k As Integer
            'cl(0) = "MAIN_FIBRE_CODE"
            'cl(1) = "SUB_FIBRE_CODE"
            'cl(2) = "FIBRE_PERCENT"
            'For k = 0 To 2
            '    Dim dc As New Data.DataColumn
            '    dc.ColumnName = cl(k)
            '    dt.Columns.Add(dc)
            'Next
            'ViewState("dt") = dt

            '  imb_insertrow_Click(sender,Nothing)
            ''txt_tranno.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)) {document.getElementById('" + btn_enter.UniqueID + "').click();return false;}} else {return true}; ")
            ''txt_tranno.Attributes.Add("onkeypress", "return clickButton(event,'" + btn_enter.ClientID + "')")

            sqlpass = "select convert(varchar(11),getdate(),101) "

            obj.opencn()
            cmd = New SqlCommand(sqlpass, obj.cn)
            dr = cmd.ExecuteReader

            If dr.HasRows = True Then
                dr.Read()
                Me.txt_efffrom.Text = dr.Item(0)
                Me.txt_effto.Text = dr.Item(0)
            End If
            dr.Close()
            obj.closecn()

            ''-----Fill Action Combo Box
            sqlpass = "/*select b.action,b.mnuname,b.description,b.parent_menu,b.seq " & _
                " from production..user_module_menus_mapping a inner join production..modules_menu_master b " & _
                " on a.module=b.module and a.mnuname=b.mnuname and a.action=b.action " & _
                " where a.module ='OPS' and a.uname='" & Session("empcode") & "' and a.mnuname='Raw Material Receipt'" & _
                " union*/ select b.action,b.mnuname,b.description,parent_menu,case b.action when 'ADD' then '1' when 'VIEW' then '2' when 'MODIFY' then '3' when 'CANCEL' then '4' when 'SHORT CLOSE' then '5' when 'AUTHORIZE' then '6' end /*b.seq*/ " & _
                " from production..role_module_menus_mapping a inner join production..modules_menu_master b " & _
                " on a.module=b.module and a.mnuname=b.mnuname and a.action=b.action " & _
                " inner join production..role_user_mapping e on a.role=e.role " & _
                " where a.module ='OPS' and e.uname='" & Session("empcode") & "' " & _
                "and a.mnuname='Raw Material Receipt' and a.action<>'Load'" & _
                " order by b.parent_menu,b.mnuname,case b.action when 'ADD' then '1' when 'VIEW' then '2' when 'MODIFY' then '3' when 'CANCEL' then '4' when 'SHORT CLOSE' then '5' when 'AUTHORIZE' then '6' end /*b.seq*/ "


            obj.opencn()
            cmd = New SqlCommand(sqlpass, obj.cn)
            dr = cmd.ExecuteReader

            If dr.HasRows = True Then
                While dr.Read
                    Me.ddl_action.Items.Add(dr.Item(0))
                End While
                Me.ddl_action.SelectedIndex = 0
            End If
            dr.Close()
            obj.closecn()


            ''-----Fill Item Group in Item group Combo Box
            sqlpass = "select ltrim(rtrim(description)) + '|' + ltrim(rtrim(group_no)) " & _
                    "from miserp.common.dbo.ims_stock_group_master " & _
                    "where type = 1 and disabled = 0 " & _
                    "and company_no='" & UCase(LTrim(RTrim(Session("companycode")))) & "' " & _
                    "order by ltrim(rtrim(description)) + '|' + ltrim(rtrim(group_no)) "

            obj.opencn()
            cmd = New SqlCommand(sqlpass, obj.cn)
            cmd.CommandTimeout = 0
            dr = cmd.ExecuteReader

            If dr.HasRows = True Then
                While dr.Read
                    Me.ddl_itemgroup.Items.Add(dr.Item(0))
                End While
                Me.ddl_itemgroup.SelectedIndex = 0
            End If
            dr.Close()
            obj.closecn()

            Me.txt_groupcode.Text = LTrim(RTrim(Mid(Me.ddl_itemgroup.Text, InStr(Me.ddl_itemgroup.Text, "|") + 1, 20)))


            ''-----Fill Vendor Name and Code in Supplier Combo Box
            'sqlpass = "select ltrim(rtrim(vendor_name)) + '|' + ltrim(rtrim(vendor_code)) " & _
            '        "from miserp.common.dbo.pur_company_vendor_master " & _
            '        "where company_code='" & UCase(LTrim(RTrim(Session("companycode")))) & "' " & _
            '        "order by ltrim(rtrim(vendor_name)) + '|' + ltrim(rtrim(vendor_code)) "

            sqlpass = "select distinct ltrim(rtrim(d.vendor_name)) + '|' + ltrim(rtrim(a.vendor_code)) " & _
                    "from miserp.pomdb.dbo.pur_gi_header a, miserp.pomdb.dbo.pur_gi_detail b, " & _
                    "miserp.common.dbo.ims_stock_master c, miserp.common.dbo.pur_company_vendor_master d " & _
                    "where a.gi_no = b.gi_no " & _
                    "and b.stock_no = c.stock_no " & _
                    "and c.stock_type = '0' " & _
                    "/*and c.purchase_uom='KG'*/ " & _
                    "and a.vendor_code = d.vendor_code " & _
                    "and a.company_code='" & UCase(LTrim(RTrim(Session("companycode")))) & "' " & _
                    "and a.company_code = b.company_code " & _
                    "order by ltrim(rtrim(d.vendor_name)) + '|' + ltrim(rtrim(a.vendor_code)) "

            obj.opencn()
            cmd = New SqlCommand(sqlpass, obj.cn)
            cmd.CommandTimeout = 0
            dr = cmd.ExecuteReader

            If dr.HasRows = True Then
                While dr.Read
                    Me.ddl_supplier.Items.Add(dr.Item(0))
                End While
                Me.ddl_supplier.SelectedIndex = 0
            End If
            dr.Close()
            obj.closecn()

            ''Fill Supplier Code
            Me.txt_supplier_code.Text = LTrim(RTrim(Mid(Me.ddl_supplier.Text, InStr(Me.ddl_supplier.Text, "|") + 1, 10)))


            sqlpass = "select distinct ltrim(rtrim(isnull(vendor_add1,''))) +', ' + ltrim(rtrim(isnull(vendor_add2,''))) + ', ' + ltrim(rtrim(isnull(vendor_add3,''))), isnull(city,'') " & _
                    "from miserp.common.dbo.pur_company_vendor_master " & _
                    "where vendor_code = '" & LTrim(RTrim(Me.txt_supplier_code.Text)) & "' " & _
                    "and company_code='" & UCase(LTrim(RTrim(Session("companycode")))) & "' "

            obj.opencn()
            cmd = New SqlCommand(sqlpass, obj.cn)
            cmd.CommandTimeout = 0
            dr = cmd.ExecuteReader

            If dr.HasRows = True Then
                dr.Read()
                Me.lbl_address.Text = dr.Item(0)
                Me.lbl_city.Text = dr.Item(1)
            End If
            dr.Close()
            obj.closecn()


            ''-----Fill Pay term & Desc. in text box
            sqlpass = "select a.pay_term_no, b.pay_term_desc, " & _
                    "isnull(convert(varchar(11),b.effective_date,101),''), isnull(convert(varchar(11),b.expiry_date,101),'') " & _
                    "from miserp.common.dbo.pur_company_vendor_master a, " & _
                    "miserp.common.dbo.pur_payterm_header b " & _
                    "where a.vendor_code='" & LTrim(RTrim(Me.txt_supplier_code.Text)) & "' " & _
                    "and a.pay_term_no = b.pay_term_no " & _
                    "/*and convert(datetime,convert(varchar(11),getdate())) between b.effective_date and b.expiry_date*/ " & _
                    "and a.company_code='" & UCase(LTrim(RTrim(Session("companycode")))) & "' " & _
                    "and a.company_code = b.company_code "

            obj.opencn()
            cmd = New SqlCommand(sqlpass, obj.cn)
            dr = cmd.ExecuteReader

            If dr.HasRows = True Then
                dr.Read()
                Me.txt_pay_term_code.Text = dr.Item(0)
                Me.txt_pay_term_desc.Text = dr.Item(1)
                Me.txt_efffrom.Text = dr.Item(2)
                Me.txt_effto.Text = dr.Item(3)
            Else
                FMsg.Message = "Pay term not defined or Pay term expired "
                FMsg.CssClass = "errormsg"
                FMsg.Display()
                Me.txt_itemcode.Focus()
                Exit Sub
            End If
            dr.Close()
            obj.closecn()


            'Me.lbt_view_Click(sender, e)  '' set view mode at page loading time
            Me.lbt_add_Click(sender, e)  '' set add mode at page loading time


        End If  '' end of If Not IsPostBack 

        'If Not IsPostBack Then
        '    grdbnd()
        'End If

    End Sub

    Protected Sub imb_close_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imb_close.Click

        Me.Dispose()
        Response.Redirect("default.aspx")

    End Sub

    Protected Sub lbt_view_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbt_view.Click

        Me.lbt_add.Text = "ADD"
        Me.lbt_modify.Text = "MODIFY"
        Me.lbt_view.Text = "VIEW"
        Me.lbt_authorize.Text = "AUTHORIZE"
        Me.lbt_delete.Text = "SHORT CLOSE"
        Me.lbt_close.Text = "CLOSE"

        Me.ddl_action.SelectedIndex = 1
        Me.ddl_action_SelectedIndexChanged(sender, e)

    End Sub

    Protected Sub lbt_add_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbt_add.Click

        'Me.lbt_add.Text = "ADD"
        Me.lbt_modify.Text = "MODIFY"
        Me.lbt_view.Text = "VIEW"
        Me.lbt_authorize.Text = "AUTHORIZE"
        Me.lbt_delete.Text = "SHORT CLOSE"
        Me.lbt_close.Text = "CLOSE"

        'If Me.lbt_add.Text = "ADD" Then

        Me.ddl_action.SelectedIndex = 0
        Me.ddl_action_SelectedIndexChanged(sender, e)

    End Sub

    Protected Sub lbt_modify_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbt_modify.Click

        Me.lbt_add.Text = "ADD"
        'Me.lbt_modify.Text = "MODIFY"
        Me.lbt_view.Text = "VIEW"
        Me.lbt_authorize.Text = "AUTHORIZE"
        Me.lbt_delete.Text = "SHORT CLOSE"
        Me.lbt_close.Text = "CLOSE"

        'If Me.lbt_modify.Text = "MODIFY" Then

        Me.ddl_action.SelectedIndex = 2
        Me.ddl_action_SelectedIndexChanged(sender, e)

    End Sub

    Protected Sub lbt_authorize_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbt_authorize.Click

        Me.lbt_add.Text = "ADD"
        Me.lbt_modify.Text = "MODIFY"
        Me.lbt_view.Text = "VIEW"
        'Me.lbt_authorize.Text = "AUTHORIZE"
        Me.lbt_delete.Text = "SHORT CLOSE"
        Me.lbt_close.Text = "CLOSE"

        'If lbt_authorize.Text = "AUTHORIZE" Then

        Me.ddl_action.SelectedIndex = 5
        Me.ddl_action_SelectedIndexChanged(sender, e)

    End Sub

    Protected Sub lbt_delete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbt_delete.Click

        Me.lbt_add.Text = "ADD"
        Me.lbt_modify.Text = "MODIFY"
        Me.lbt_view.Text = "VIEW"
        Me.lbt_authorize.Text = "AUTHORIZE"
        'Me.lbt_delete.Text = "SHORT CLOSE"
        Me.lbt_close.Text = "CLOSE"

        'If lbt_delete.Text = "SHORT CLOSE" Then

        Me.ddl_action.SelectedIndex = 4
        ddl_action_SelectedIndexChanged(sender, e)

    End Sub

    Protected Sub ddl_action_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl_action.SelectedIndexChanged

        If UCase(LTrim(RTrim(Me.ddl_action.Text))) = "ADD" Then ''And Me.lbt_add.Text = "ADD" Then

            If Me.lbt_add.Text = "ADD" Then

                'Me.lbt_apply.Enabled = True

                Me.txt_tranno.Enabled = False
                Me.ddl_plant.Enabled = True
                Me.ddl_itemgroup.Enabled = True
                Me.txt_groupcode.Enabled = False
                Me.ddl_supplier.Enabled = True
                Me.txt_supplier_code.Enabled = False
                Me.ddl_supplier_code.Enabled = True
                Me.txt_itemcode.Enabled = True
                Me.txt_item_desc.Enabled = False
                Me.txt_variant.Enabled = True
                Me.txt_variant_desc.Enabled = False
                Me.txt_qty.Enabled = True
                Me.txt_value.Enabled = True
                Me.txt_rate.Enabled = True
                Me.txt_last_rate.Enabled = False
                Me.ddl_uom.Enabled = True
                Me.txt_pay_term_code.Enabled = False
                Me.txt_pay_term_desc.Enabled = False
                Me.txt_efffrom.Enabled = False
                Me.txt_effto.Enabled = False
                Me.imb_get_new_payterm.Enabled = True
                Me.imb_set_new_payterm.Enabled = True
                Me.txt_required_date.Enabled = True
                Me.txt_receive_date.Enabled = False
                Me.txt_lead_time.Enabled = False
                Me.txt_procurement_date.Enabled = False
                Me.txt_invno.Enabled = False
                Me.txt_budget_qty.Enabled = False
                Me.txt_plan_qty.Enabled = False
                Me.txt_actual_qty.Enabled = False
                Me.txt_budget_value.Enabled = False
                Me.txt_plan_value.Enabled = False
                Me.txt_actual_value.Enabled = False
                Me.txt_reason.Enabled = False

                'Me.GridView1.DataSource = Nothing
                'GridView1.DataBind()

                Me.txt_tranno.Text = ""
                Me.lbl_status.Text = ""

                'Me.txt_groupcode.Text = ""
                'Me.txt_supplier_code.Text = ""
                'Me.lbl_city.Text = ""
                Me.txt_itemcode.Text = ""
                Me.txt_item_desc.Text = ""
                Me.txt_variant.Text = ""
                Me.txt_variant_desc.Text = ""
                Me.txt_pay_term_code.Text = ""
                Me.txt_pay_term_desc.Text = ""
                Me.txt_efffrom.Text = Now().Date
                Me.txt_effto.Text = Now().Date

                Me.txt_qty.Text = "0"
                Me.txt_value.Text = "0"
                Me.txt_rate.Text = "0"
                Me.txt_last_rate.Text = "0"
                Me.txt_required_date.Text = Now().Date
                Me.txt_receive_date.Text = Now().Date
                Me.txt_lead_time.Text = "0"
                Me.txt_procurement_date.Text = Now().Date
                Me.txt_invno.Text = ""
                Me.txt_budget_qty.Text = "0"
                Me.txt_plan_qty.Text = "0"
                Me.txt_actual_qty.Text = "0"
                Me.txt_budget_value.Text = "0"
                Me.txt_plan_value.Text = "0"
                Me.txt_actual_value.Text = "0"
                Me.txt_reason.Text = ""

                Me.imb_tran_fetch.Enabled = False

                Me.lbt_add.Text = "SAVE"

            ElseIf lbt_add.Text = "SAVE" Then

                Me.ddl_action.SelectedIndex = 0    ''  Set action in ADD mode
                Me.lbt_apply_Click(sender, e)      ''  Execute APPLY button script through LinkButton1_Click event
                ''Me.lnk_exit_Click(sender, e)       ''  Execute EXIT button script

            End If

        End If


        If UCase(LTrim(RTrim(Me.ddl_action.Text))) = "MODIFY" Then ''And Me.lbt_modify.Text = "MODIFY" Then

            If Me.lbt_modify.Text = "MODIFY" Then

                'Me.lbt_apply.Enabled = True

                Me.txt_tranno.Enabled = True
                Me.ddl_plant.Enabled = True
                Me.ddl_itemgroup.Enabled = True
                Me.txt_groupcode.Enabled = False
                Me.ddl_supplier.Enabled = True
                Me.txt_supplier_code.Enabled = False
                Me.ddl_supplier_code.Enabled = True
                Me.txt_itemcode.Enabled = True
                Me.txt_item_desc.Enabled = False
                Me.txt_variant.Enabled = True
                Me.txt_variant_desc.Enabled = False
                Me.txt_qty.Enabled = True
                Me.txt_value.Enabled = True
                Me.txt_rate.Enabled = True
                Me.txt_last_rate.Enabled = False
                Me.ddl_uom.Enabled = True
                Me.txt_pay_term_code.Enabled = False
                Me.txt_pay_term_desc.Enabled = False
                Me.txt_efffrom.Enabled = False
                Me.txt_effto.Enabled = False
                Me.imb_get_new_payterm.Enabled = True
                Me.imb_set_new_payterm.Enabled = True
                Me.txt_required_date.Enabled = True
                Me.txt_receive_date.Enabled = False
                Me.txt_lead_time.Enabled = False
                Me.txt_procurement_date.Enabled = False
                Me.txt_invno.Enabled = False
                Me.txt_budget_qty.Enabled = False
                Me.txt_plan_qty.Enabled = False
                Me.txt_actual_qty.Enabled = False
                Me.txt_budget_value.Enabled = False
                Me.txt_plan_value.Enabled = False
                Me.txt_actual_value.Enabled = False
                Me.txt_reason.Enabled = False

                'Me.GridView1.DataSource = Nothing
                'GridView1.DataBind()

                Me.txt_tranno.Text = ""
                Me.lbl_status.Text = ""

                'Me.txt_groupcode.Text = ""
                'Me.txt_supplier_code.Text = ""
                'Me.lbl_city.Text = ""
                Me.txt_itemcode.Text = ""
                Me.txt_item_desc.Text = ""
                Me.txt_variant.Text = ""
                Me.txt_variant_desc.Text = ""
                Me.txt_pay_term_code.Text = ""
                Me.txt_pay_term_desc.Text = ""
                Me.txt_efffrom.Text = Now().Date
                Me.txt_effto.Text = Now().Date

                Me.txt_qty.Text = "0"
                Me.txt_value.Text = "0"
                Me.txt_rate.Text = "0"
                Me.txt_last_rate.Text = "0"
                Me.txt_required_date.Text = Now().Date
                Me.txt_receive_date.Text = Now().Date
                Me.txt_lead_time.Text = "0"
                Me.txt_procurement_date.Text = Now().Date
                Me.txt_invno.Text = ""
                Me.txt_budget_qty.Text = "0"
                Me.txt_plan_qty.Text = "0"
                Me.txt_actual_qty.Text = "0"
                Me.txt_budget_value.Text = "0"
                Me.txt_plan_value.Text = "0"
                Me.txt_actual_value.Text = "0"
                Me.txt_reason.Text = ""

                Me.imb_tran_fetch.Enabled = True

                Me.lbt_modify.Text = "UPDATE"
                'Me.lbt_close.Text = "CANCEL"  '' "UNDO"

            ElseIf lbt_modify.Text = "UPDATE" Then

                Me.ddl_action.SelectedIndex = 2    ''  Set action in MODIFY mode
                Me.lbt_apply_Click(sender, e)      ''  Execute APPLY button script through LinkButton1_Click event
                ''Me.lnk_exit_Click(sender, e)       ''  Execute EXIT button script

            End If

        End If


        If UCase(LTrim(RTrim(Me.ddl_action.Text))) = "VIEW" Then

            'Me.lbt_apply.Enabled = True

            'Me.lbt_apply.Enabled = True

            Me.txt_tranno.Enabled = True
            Me.ddl_plant.Enabled = False
            Me.ddl_itemgroup.Enabled = False
            Me.txt_groupcode.Enabled = False
            Me.ddl_supplier.Enabled = False
            Me.txt_supplier_code.Enabled = False
            Me.ddl_supplier_code.Enabled = False
            Me.txt_itemcode.Enabled = False
            Me.txt_item_desc.Enabled = False
            Me.txt_variant.Enabled = False
            Me.txt_variant_desc.Enabled = False
            Me.txt_qty.Enabled = False
            Me.txt_value.Enabled = False
            Me.txt_rate.Enabled = False
            Me.txt_last_rate.Enabled = False
            Me.ddl_uom.Enabled = False
            Me.txt_pay_term_code.Enabled = False
            Me.txt_pay_term_desc.Enabled = False
            Me.txt_efffrom.Enabled = False
            Me.txt_effto.Enabled = False
            Me.imb_get_new_payterm.Enabled = False
            Me.imb_set_new_payterm.Enabled = False
            Me.txt_required_date.Enabled = False
            Me.txt_receive_date.Enabled = False
            Me.txt_lead_time.Enabled = False
            Me.txt_procurement_date.Enabled = False
            Me.txt_invno.Enabled = False
            Me.txt_budget_qty.Enabled = False
            Me.txt_plan_qty.Enabled = False
            Me.txt_actual_qty.Enabled = False
            Me.txt_budget_value.Enabled = False
            Me.txt_plan_value.Enabled = False
            Me.txt_actual_value.Enabled = False
            Me.txt_reason.Enabled = False

            'Me.GridView1.DataSource = Nothing
            'GridView1.DataBind()

            Me.txt_tranno.Text = ""
            Me.lbl_status.Text = ""

            'Me.txt_groupcode.Text = ""
            'Me.txt_supplier_code.Text = ""
            'Me.lbl_city.Text = ""
            Me.txt_itemcode.Text = ""
            Me.txt_item_desc.Text = ""
            Me.txt_variant.Text = ""
            Me.txt_variant_desc.Text = ""
            Me.txt_pay_term_code.Text = ""
            Me.txt_pay_term_desc.Text = ""
            Me.txt_efffrom.Text = Now().Date
            Me.txt_effto.Text = Now().Date

            Me.txt_qty.Text = "0"
            Me.txt_value.Text = "0"
            Me.txt_rate.Text = "0"
            Me.txt_last_rate.Text = "0"
            Me.txt_required_date.Text = Now().Date
            Me.txt_receive_date.Text = Now().Date
            Me.txt_lead_time.Text = "0"
            Me.txt_procurement_date.Text = Now().Date
            Me.txt_invno.Text = ""
            Me.txt_budget_qty.Text = "0"
            Me.txt_plan_qty.Text = "0"
            Me.txt_actual_qty.Text = "0"
            Me.txt_budget_value.Text = "0"
            Me.txt_plan_value.Text = "0"
            Me.txt_actual_value.Text = "0"
            Me.txt_reason.Text = ""

            Me.imb_tran_fetch.Enabled = True

        End If


        If UCase(LTrim(RTrim(Me.ddl_action.Text))) = "AUTHORIZE" Then

            If lbt_authorize.Text = "AUTHORIZE" Then

                'Me.lbt_apply.Enabled = True

                'Me.lbt_apply.Enabled = True

                Me.txt_tranno.Enabled = True
                Me.ddl_plant.Enabled = False
                Me.ddl_itemgroup.Enabled = False
                Me.txt_groupcode.Enabled = False
                Me.ddl_supplier.Enabled = False
                Me.txt_supplier_code.Enabled = False
                Me.ddl_supplier_code.Enabled = False
                Me.txt_itemcode.Enabled = False
                Me.txt_item_desc.Enabled = False
                Me.txt_variant.Enabled = False
                Me.txt_variant_desc.Enabled = False
                Me.txt_qty.Enabled = False
                Me.txt_value.Enabled = False
                Me.txt_rate.Enabled = False
                Me.txt_last_rate.Enabled = False
                Me.ddl_uom.Enabled = False
                Me.txt_pay_term_code.Enabled = False
                Me.txt_pay_term_desc.Enabled = False
                Me.txt_efffrom.Enabled = False
                Me.txt_effto.Enabled = False
                Me.imb_get_new_payterm.Enabled = False
                Me.imb_set_new_payterm.Enabled = False
                Me.txt_required_date.Enabled = False
                Me.txt_receive_date.Enabled = False
                Me.txt_lead_time.Enabled = False
                Me.txt_procurement_date.Enabled = False
                Me.txt_invno.Enabled = False
                Me.txt_budget_qty.Enabled = False
                Me.txt_plan_qty.Enabled = False
                Me.txt_actual_qty.Enabled = False
                Me.txt_budget_value.Enabled = False
                Me.txt_plan_value.Enabled = False
                Me.txt_actual_value.Enabled = False
                Me.txt_reason.Enabled = False

                'Me.GridView1.DataSource = Nothing
                'GridView1.DataBind()

                Me.txt_tranno.Text = ""
                Me.lbl_status.Text = ""

                'Me.txt_groupcode.Text = ""
                'Me.txt_supplier_code.Text = ""
                'Me.lbl_city.Text = ""
                Me.txt_itemcode.Text = ""
                Me.txt_item_desc.Text = ""
                Me.txt_variant.Text = ""
                Me.txt_variant_desc.Text = ""
                Me.txt_pay_term_code.Text = ""
                Me.txt_pay_term_desc.Text = ""
                Me.txt_efffrom.Text = Now().Date
                Me.txt_effto.Text = Now().Date

                Me.txt_qty.Text = "0"
                Me.txt_value.Text = "0"
                Me.txt_rate.Text = "0"
                Me.txt_last_rate.Text = "0"
                Me.txt_required_date.Text = Now().Date
                Me.txt_receive_date.Text = Now().Date
                Me.txt_lead_time.Text = "0"
                Me.txt_procurement_date.Text = Now().Date
                Me.txt_invno.Text = ""
                Me.txt_budget_qty.Text = "0"
                Me.txt_plan_qty.Text = "0"
                Me.txt_actual_qty.Text = "0"
                Me.txt_budget_value.Text = "0"
                Me.txt_plan_value.Text = "0"
                Me.txt_actual_value.Text = "0"
                Me.txt_reason.Text = ""

                Me.imb_tran_fetch.Enabled = True

                Me.lbt_authorize.Text = "UPDATE"
                'Me.lbt_close.Text = "CANCEL"  '' "UNDO"

            ElseIf lbt_authorize.Text = "UPDATE" Then

                Me.ddl_action.SelectedIndex = 5    ''  Set action in AUTHORIZE mode
                Me.lbt_apply_Click(sender, e)      ''  Execute APPLY button script through LinkButton1_Click event
                'Me.lbt_close_Click(sender, e)       ''  Execute EXIT button script

            End If

        End If


        If UCase(LTrim(RTrim(Me.ddl_action.Text))) = "SHORT CLOSE" Then

            If lbt_delete.Text = "SHORT CLOSE" Then

                'Me.lbt_apply.Enabled = True

                'Me.lbt_apply.Enabled = True

                Me.txt_tranno.Enabled = True
                Me.ddl_plant.Enabled = False
                Me.ddl_itemgroup.Enabled = False
                Me.txt_groupcode.Enabled = False
                Me.ddl_supplier.Enabled = False
                Me.txt_supplier_code.Enabled = False
                Me.ddl_supplier_code.Enabled = False
                Me.txt_itemcode.Enabled = False
                Me.txt_item_desc.Enabled = False
                Me.txt_variant.Enabled = False
                Me.txt_variant_desc.Enabled = False
                Me.txt_qty.Enabled = False
                Me.txt_value.Enabled = False
                Me.txt_rate.Enabled = False
                Me.txt_last_rate.Enabled = False
                Me.ddl_uom.Enabled = False
                Me.txt_pay_term_code.Enabled = False
                Me.txt_pay_term_desc.Enabled = False
                Me.txt_efffrom.Enabled = False
                Me.txt_effto.Enabled = False
                Me.imb_get_new_payterm.Enabled = False
                Me.imb_set_new_payterm.Enabled = False
                Me.txt_required_date.Enabled = False
                Me.txt_receive_date.Enabled = False
                Me.txt_lead_time.Enabled = False
                Me.txt_procurement_date.Enabled = False
                Me.txt_invno.Enabled = False
                Me.txt_budget_qty.Enabled = False
                Me.txt_plan_qty.Enabled = False
                Me.txt_actual_qty.Enabled = False
                Me.txt_budget_value.Enabled = False
                Me.txt_plan_value.Enabled = False
                Me.txt_actual_value.Enabled = False
                Me.txt_reason.Enabled = True

                'Me.GridView1.DataSource = Nothing
                'GridView1.DataBind()

                Me.txt_tranno.Text = ""
                Me.lbl_status.Text = ""

                'Me.txt_groupcode.Text = ""
                'Me.txt_supplier_code.Text = ""
                'Me.lbl_city.Text = ""
                Me.txt_itemcode.Text = ""
                Me.txt_item_desc.Text = ""
                Me.txt_variant.Text = ""
                Me.txt_variant_desc.Text = ""
                Me.txt_pay_term_code.Text = ""
                Me.txt_pay_term_desc.Text = ""
                Me.txt_efffrom.Text = Now().Date
                Me.txt_effto.Text = Now().Date

                Me.txt_qty.Text = "0"
                Me.txt_value.Text = "0"
                Me.txt_rate.Text = "0"
                Me.txt_last_rate.Text = "0"
                Me.txt_required_date.Text = Now().Date
                Me.txt_receive_date.Text = Now().Date
                Me.txt_lead_time.Text = "0"
                Me.txt_procurement_date.Text = Now().Date
                Me.txt_invno.Text = ""
                Me.txt_budget_qty.Text = "0"
                Me.txt_plan_qty.Text = "0"
                Me.txt_actual_qty.Text = "0"
                Me.txt_budget_value.Text = "0"
                Me.txt_plan_value.Text = "0"
                Me.txt_actual_value.Text = "0"
                Me.txt_reason.Text = ""

                Me.imb_tran_fetch.Enabled = True

                Me.lbt_delete.Text = "UPDATE"
                'Me.lbt_close.Text = "CANCEL"   '' "UNDO"

            ElseIf lbt_delete.Text = "UPDATE" Then

                Me.ddl_action.SelectedIndex = 4    ''  Set action in SHORT CLOSE mode
                Me.lbt_apply_Click(sender, e)      ''  Execute APPLY button script through LinkButton1_Click event
                ''Me.lnk_exit_Click(sender, e)     ''  Execute EXIT button script

            End If

        End If

    End Sub

    Protected Sub lbt_apply_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbt_apply.Click

        Dim same As String = "N"
        Dim greater As String = "N"
        Dim sno1 As Integer = 0
        Dim sno2 As String = ""

        If LTrim(RTrim(Me.ddl_plant.Text)) = "" Then
            FMsg.Message = "Pl. select Plant. "
            FMsg.CssClass = "errormsg"
            FMsg.Display()
            Me.ddl_plant.Focus()
            Exit Sub
        End If

        If LTrim(RTrim(Me.ddl_itemgroup.Text)) = "" Then
            FMsg.Message = "Pl. select Item Group. "
            FMsg.CssClass = "errormsg"
            FMsg.Display()
            Me.ddl_itemgroup.Focus()
            Exit Sub
        End If

        If LTrim(RTrim(Me.txt_groupcode.Text)) = "" Then
            FMsg.Message = "Pl. select Group Code. "
            FMsg.CssClass = "errormsg"
            FMsg.Display()
            Me.txt_groupcode.Focus()
            Exit Sub
        End If

        If LTrim(RTrim(Me.ddl_supplier.Text)) = "" Then
            FMsg.Message = "Pl. select Supplier. "
            FMsg.CssClass = "errormsg"
            FMsg.Display()
            Me.ddl_supplier.Focus()
            Exit Sub
        End If

        If LTrim(RTrim(Me.ddl_supplier_code.Text)) = "" Then
            FMsg.Message = "Pl. select Supplier. "
            FMsg.CssClass = "errormsg"
            FMsg.Display()
            Me.ddl_supplier.Focus()
            Exit Sub
        End If

        If LTrim(RTrim(Me.txt_pay_term_code.Text)) = "" Then
            FMsg.Message = "Pl. enter Pay Term Code. "
            FMsg.CssClass = "errormsg"
            FMsg.Display()
            Me.txt_pay_term_code.Focus()
            Exit Sub
        End If

        If LTrim(RTrim(Me.txt_pay_term_desc.Text)) = "" Then
            FMsg.Message = "Pl. enter Pay Term Desc. "
            FMsg.CssClass = "errormsg"
            FMsg.Display()
            Me.txt_pay_term_desc.Focus()
            Exit Sub
        End If

        If LTrim(RTrim(Me.txt_efffrom.Text)) = "" Then
            FMsg.Message = "Pl. select Eff. From Date "
            FMsg.CssClass = "errormsg"
            FMsg.Display()
            Me.txt_efffrom.Focus()
            Exit Sub
        End If

        If LTrim(RTrim(Me.txt_effto.Text)) = "" Then
            FMsg.Message = "Pl. select Eff. To Date "
            FMsg.CssClass = "errormsg"
            FMsg.Display()
            Me.txt_effto.Focus()
            Exit Sub
        End If

        If LTrim(RTrim(Me.txt_itemcode.Text)) = "" Then
            FMsg.Message = "Pl. enter Item Code. "
            FMsg.CssClass = "errormsg"
            FMsg.Display()
            Me.txt_itemcode.Focus()
            Exit Sub
        End If

        If LTrim(RTrim(Me.txt_variant.Text)) = "" Then
            FMsg.Message = "Pl. enter Item Variant. "
            FMsg.CssClass = "errormsg"
            FMsg.Display()
            Me.txt_variant.Focus()
            Exit Sub
        End If

        If LTrim(RTrim(Me.txt_item_desc.Text)) = "" Then
            FMsg.Message = "Item Description not found. "
            FMsg.CssClass = "errormsg"
            FMsg.Display()
            Me.txt_item_desc.Focus()
            Exit Sub
        End If

        If LTrim(RTrim(Me.txt_variant_desc.Text)) = "" Then
            FMsg.Message = "Variant Description not found. "
            FMsg.CssClass = "errormsg"
            FMsg.Display()
            Me.txt_variant_desc.Focus()
            Exit Sub
        End If

        If LTrim(RTrim(Me.txt_qty.Text)) = "" Then
            FMsg.Message = "Pl. enter Qty. "
            FMsg.CssClass = "errormsg"
            FMsg.Display()
            Me.txt_qty.Focus()
            Exit Sub
        End If

        If LTrim(RTrim(Me.txt_value.Text)) = "" Then
            FMsg.Message = "Pl. enter Value. "
            FMsg.CssClass = "errormsg"
            FMsg.Display()
            Me.txt_value.Focus()
            Exit Sub
        End If

        If LTrim(RTrim(Me.txt_rate.Text)) = "" Then
            FMsg.Message = "Pl. enter Rate. "
            FMsg.CssClass = "errormsg"
            FMsg.Display()
            Me.txt_rate.Focus()
            Exit Sub
        End If

        If LTrim(RTrim(Me.txt_last_rate.Text)) = "" Then
            FMsg.Message = "Pl. enter Last Rate. "
            FMsg.CssClass = "errormsg"
            FMsg.Display()
            Me.txt_last_rate.Focus()
            Exit Sub
        End If

        If LTrim(RTrim(Me.txt_required_date.Text)) = "" Then
            FMsg.Message = "Pl. select Required Date. "
            FMsg.CssClass = "errormsg"
            FMsg.Display()
            Me.txt_required_date.Focus()
            Exit Sub
        End If

        If LTrim(RTrim(Me.txt_receive_date.Text)) = "" Then
            FMsg.Message = "Pl. select Receive Date. "
            FMsg.CssClass = "errormsg"
            FMsg.Display()
            Me.txt_receive_date.Focus()
            Exit Sub
        End If

        If LTrim(RTrim(Me.txt_lead_time.Text)) = "" Then
            FMsg.Message = "Pl. enter Lead Time. "
            FMsg.CssClass = "errormsg"
            FMsg.Display()
            Me.txt_lead_time.Focus()
            Exit Sub
        End If

        If LTrim(RTrim(Me.txt_procurement_date.Text)) = "" Then
            FMsg.Message = "Pl. select Procurement Date. "
            FMsg.CssClass = "errormsg"
            FMsg.Display()
            Me.txt_procurement_date.Focus()
            Exit Sub
        End If

        'If LTrim(RTrim(Me.txt_invno.Text)) = "" Then
        '    FMsg.Message = "Pl. enter Invoice No. "
        '    FMsg.CssClass = "errormsg"
        '    FMsg.Display()
        '    Me.txt_invno.Focus()
        '    Exit Sub
        'End If

        'If LTrim(RTrim(Me.txt_budget_qty.Text)) = "" Then
        '    FMsg.Message = "Pl. enter Budget Qty. "
        '    FMsg.CssClass = "errormsg"
        '    FMsg.Display()
        '    Me.txt_budget_qty.Focus()
        '    Exit Sub
        'End If

        'If LTrim(RTrim(Me.txt_budget_value.Text)) = "" Then
        '    FMsg.Message = "Pl. enter Budget Value "
        '    FMsg.CssClass = "errormsg"
        '    FMsg.Display()
        '    Me.txt_budget_value.Focus()
        '    Exit Sub
        'End If

        'If LTrim(RTrim(Me.txt_plan_qty.Text)) = "" Then
        '    FMsg.Message = "Pl. enter Plan Qty. "
        '    FMsg.CssClass = "errormsg"
        '    FMsg.Display()
        '    Me.txt_plan_qty.Focus()
        '    Exit Sub
        'End If

        'If LTrim(RTrim(Me.txt_plan_value.Text)) = "" Then
        '    FMsg.Message = "Pl. enter Plan Value "
        '    FMsg.CssClass = "errormsg"
        '    FMsg.Display()
        '    Me.txt_plan_value.Focus()
        '    Exit Sub
        'End If

        'If LTrim(RTrim(Me.txt_actual_qty.Text)) = "" Then
        '    FMsg.Message = "Pl. enter Actual Qty. "
        '    FMsg.CssClass = "errormsg"
        '    FMsg.Display()
        '    Me.txt_actual_qty.Focus()
        '    Exit Sub
        'End If

        'If LTrim(RTrim(Me.txt_actual_value.Text)) = "" Then
        '    FMsg.Message = "Pl. enter Actual Value "
        '    FMsg.CssClass = "errormsg"
        '    FMsg.Display()
        '    Me.txt_actual_value.Focus()
        '    Exit Sub
        'End If

        Dim curdate As Date

        sqlpass = "select convert(datetime,convert(varchar(11),getdate())) "

        obj.opencn()
        cmd = New SqlCommand(sqlpass, obj.cn)
        cmd.CommandTimeout = 0
        dr = cmd.ExecuteReader

        If dr.HasRows = True Then
            dr.Read()
            curdate = dr.Item(0)
        Else
            FMsg.Message = "Error during current system date stored in variable"
            FMsg.CssClass = "errormsg"
            FMsg.Display()
            Me.txt_efffrom.Focus()
            dr.Close()
            obj.closecn()
            Exit Sub
        End If
        dr.Close()
        obj.closecn()


        If curdate < CDate(Me.txt_efffrom.Text).Date Or curdate > CDate(Me.txt_effto.Text).Date Then
            FMsg.Message = "Pay term period expired"
            FMsg.CssClass = "errormsg"
            FMsg.Display()
            Me.txt_pay_term_code.Focus()
            dr.Close()
            obj.closecn()
            Exit Sub
        End If

        ''Reset Supplier & Supplier code according to multiple suppliers selected in combo box
        Me.ddl_supplier.Text = LTrim(RTrim(Me.ddl_supplier_code.Text))
        Me.txt_supplier_code.Text = LTrim(RTrim(Mid(Me.ddl_supplier.Text, InStr(Me.ddl_supplier.Text, "|") + 1, 10)))


        If LTrim(RTrim(Me.txt_supplier_code.Text)) <> Right(LTrim(RTrim(Me.ddl_supplier.Text)), Len(LTrim(RTrim(Me.txt_supplier_code.Text)))) Then
            FMsg.Message = "Supplier code not match with Supplier "
            FMsg.CssClass = "errormsg"
            FMsg.Display()
            Me.ddl_supplier.Focus()
            dr.Close()
            obj.closecn()
            Exit Sub
        End If


        ''-----Fill Item Desc. text box
        sqlpass = "select description from miserp.common.dbo.ims_stock_master " & _
                "where stock_no ='" & LTrim(RTrim(Me.txt_itemcode.Text)) & "' " & _
                "and company_no='" & UCase(LTrim(RTrim(Session("companycode")))) & "' "

        obj.opencn()
        cmd = New SqlCommand(sqlpass, obj.cn)
        dr = cmd.ExecuteReader

        If dr.HasRows = True Then
            dr.Read()
            Me.txt_item_desc.Text = dr.Item(0)
        Else
            FMsg.Message = "Invalid Item Code "
            FMsg.CssClass = "errormsg"
            FMsg.Display()
            Me.txt_itemcode.Focus()
            Exit Sub
        End If
        dr.Close()
        obj.closecn()


        ''-----Fill Item Desc. text box
        sqlpass = "select short_description from miserp.common.dbo.ims_variant_master " & _
                "where stock_no ='" & LTrim(RTrim(Me.txt_itemcode.Text)) & "' " & _
                "and variant_no='" & LTrim(RTrim(Me.txt_variant.Text)) & "' " & _
                "and company_no='" & UCase(LTrim(RTrim(Session("companycode")))) & "' "

        obj.opencn()
        cmd = New SqlCommand(sqlpass, obj.cn)
        dr = cmd.ExecuteReader

        If dr.HasRows = True Then
            dr.Read()
            Me.txt_variant_desc.Text = dr.Item(0)
        Else
            FMsg.Message = "Invalid Item Code/Variant "
            FMsg.CssClass = "errormsg"
            FMsg.Display()
            Me.txt_itemcode.Focus()
            Exit Sub
        End If
        dr.Close()
        obj.closecn()


        ''-----Fill Last Rate text box
        sqlpass = "select top 1 convert(numeric(10,2),rate/rate_per) " & _
                "from miserp.pomdb.dbo.pur_po_detail a, miserp.pomdb.dbo.pur_po_header b " & _
                "where a.stock_no ='" & LTrim(RTrim(Me.txt_itemcode.Text)) & "' " & _
                "and a.stock_variant='" & LTrim(RTrim(Me.txt_variant.Text)) & "' " & _
                "and a.company_code='" & UCase(LTrim(RTrim(Session("companycode")))) & "' " & _
                "and a.po_no = b.po_no " & _
                "order by b.po_date desc "

        obj.opencn()
        cmd = New SqlCommand(sqlpass, obj.cn)
        dr = cmd.ExecuteReader

        If dr.HasRows = True Then
            dr.Read()
            Me.txt_last_rate.Text = dr.Item(0)
        Else
            Me.txt_last_rate.Text = "0"
            'FMsg.Message = "Last rate not available "
            'FMsg.CssClass = "errormsg"
            'FMsg.Display()
            'Me.txt_variant.Focus()
            'Exit Sub
        End If
        dr.Close()
        obj.closecn()


        ''========== end of validation checks



        Dim efrom As Date
        Dim eto As Date
        Dim reqddt As Date
        Dim recvdt As Date
        Dim procdt As Date

        sqlpass = "select convert(datetime,'" & Me.txt_efffrom.Text & "'), " & _
                    "convert(datetime,'" & Me.txt_effto.Text & "'), " & _
                    "convert(datetime,'" & Me.txt_required_date.Text & "'), " & _
                    "convert(datetime,'" & Me.txt_receive_date.Text & "'), " & _
                    "convert(datetime,'" & Me.txt_procurement_date.Text & "') "

        obj.opencn()
        cmd = New SqlCommand(sqlpass, obj.cn)
        cmd.CommandTimeout = 0
        dr = cmd.ExecuteReader

        If dr.HasRows = True Then
            dr.Read()
            efrom = CDate(dr.Item(0)).Date
            eto = CDate(dr.Item(1)).Date
            reqddt = CDate(dr.Item(2)).Date
            recvdt = CDate(dr.Item(3)).Date
            procdt = CDate(dr.Item(4)).Date
        Else
            FMsg.Message = "Error during date fields value stored in variables "
            FMsg.CssClass = "errormsg"
            FMsg.Display()
            Me.txt_efffrom.Focus()
            dr.Close()
            obj.closecn()
            Exit Sub
        End If

        dr.Close()
        obj.closecn()

        If efrom > eto Then
            FMsg.Message = "Eff.To date should be greater than or equal to Eff.From date"
            FMsg.CssClass = "errormsg"
            FMsg.Display()
            Me.txt_efffrom.Focus()
            Exit Sub
        End If


        Dim btran As SqlTransaction

        If UCase(LTrim(RTrim(Me.ddl_action.Text))) = "ADD" Then

            obj.opencn()
            btran = obj.cn.BeginTransaction

            Try

                '--SERIAL NUMBER GENERATION
                sqlpass = "select isnull(count_value,0)+1,ltrim(rtrim(prefix))+" & _
                "case len(ltrim(rtrim(convert(char,isnull(count_value,0)+1)))) when 1 then '000'" & _
                "when 2 then '00' when 3 then '0' end + ltrim(rtrim(convert(char,isnull(count_value,0)+1))) + ltrim(rtrim(suffix)) " & _
                "from jct_ops_serial_number_master " & _
                "where type_code='RMR' " & _
                "and convert(datetime,convert(varchar(11),getdate())) " & _
                "between convert(datetime,convert(varchar(11),eff_from)) " & _
                "and convert(datetime,convert(varchar(11),eff_to)) " & _
                "and company_code='" & UCase(LTrim(RTrim(Session("companycode")))) & "'"

                cmd = New SqlCommand(sqlpass, obj.cn)
                cmd.Transaction = btran
                dr = cmd.ExecuteReader

                If dr.HasRows = True Then
                    dr.Read()
                    sno1 = dr.Item(0)
                    sno2 = dr.Item(1)
                    Me.txt_tranno.Text = dr.Item(1)
                Else
                    FMsg.Message = "Series not defined"
                    FMsg.CssClass = "errormsg"
                    FMsg.Display()
                    dr.Close()
                    obj.closecn()
                    Exit Sub
                End If
                dr.Close()


                'sqlpass = "select top 1 convert(datetime,convert(char(11),eff_from)), " & _
                '        "convert(datetime,convert(char(11),eff_to)), tran_no " & _
                '        "from jct_ops_raw_material_receipt_header " & _
                '        "where pay_term_code='" & LTrim(RTrim(Me.txt_pay_term_code.Text)) & "' " & _
                '        "and ltrim(rtrim(company_code))='" & UCase(LTrim(RTrim(Session("companycode")))) & "' " & _
                '        "order by eff_to desc"

                'cmd = New SqlCommand(sqlpass, obj.cn)
                'cmd.CommandTimeout = 0
                'cmd.Transaction = btran
                'dr = cmd.ExecuteReader

                'If dr.HasRows = True Then

                '    dr.Read()
                '    If efrom >= CDate(dr.Item(0)).Date And eto <= CDate(dr.Item(1)).Date Then
                '        FMsg.Message = "Date Period already exists"
                '        FMsg.CssClass = "errormsg"
                '        FMsg.Display()
                '        dr.Close()
                '        obj.closecn()
                '        Exit Sub
                '    End If

                '    If efrom <= CDate(dr.Item(0)).Date Or eto <= CDate(dr.Item(1)).Date Then
                '        FMsg.Message = "Back date Pay Term period are not allowed or Eff.From date already exists"
                '        FMsg.CssClass = "errormsg"
                '        FMsg.Display()
                '        dr.Close()
                '        obj.closecn()
                '        Exit Sub
                '    End If

                '    If CDate(dr.Item(0)).Date = CDate(dr.Item(1)).Date Then
                '        same = "Y"
                '    Else
                '        same = "N"
                '    End If

                '    If efrom > CDate(dr.Item(1)).Date Then
                '        greater = "Y"
                '    Else
                '        greater = "N"
                '    End If

                '    If greater = "N" Then

                '        If same = "Y" Then
                '            FMsg.Message = "Eff.From already exists for one day"
                '            FMsg.CssClass = "errormsg"
                '            FMsg.Display()
                '            dr.Close()
                '            obj.closecn()
                '            Exit Sub
                '        Else
                '            sqlpass = "update jct_ops_raw_material_receipt_header set eff_to=convert(datetime,'" & efrom & "')-1 " & _
                '                    "where tran_no='" & LTrim(RTrim(dr.Item(2))) & "' " & _
                '                    "and company_code='" & UCase(LTrim(RTrim(Session("companycode")))) & "' "
                '        End If

                '    End If


                '    dr.Close()

                '    cmd = New SqlCommand(sqlpass, obj.cn)
                '    cmd.CommandTimeout = 0
                '    cmd.Transaction = btran
                '    cmd.ExecuteNonQuery()


                'End If  '' end of If dr.HasRows = True Then

                'dr.Close()

                Dim i As Integer = 0

                For i = 0 To Me.ddl_supplier_code.Items.Count - 1

                    sqlpass = "insert into jct_ops_raw_material_receipt_header_supplier " & _
                            "(tran_no,location,supplier_code,supplier_name," & _
                            "userid,hostname,company_code) " & _
                            "Select '" & Me.txt_tranno.Text & "','" & _
                            Me.ddl_plant.Text & "','" & _
                            LTrim(RTrim(Mid(Me.ddl_supplier_code.Items(i).Text, InStr(Me.ddl_supplier_code.Items(i).Text, "|") + 1, 10))) & "','" & _
                            LTrim(RTrim(Mid(Me.ddl_supplier_code.Items(i).Text, 1, InStr(Me.ddl_supplier_code.Items(i).Text, "|") - 1))) & "','" & _
                            Session("empcode") & "',LTrim(RTrim(host_name())) ,'" & _
                            UCase(LTrim(RTrim(Session("companycode")))) & "' "

                    cmd = New SqlCommand(sqlpass, obj.cn)
                    cmd.Transaction = btran
                    cmd.ExecuteNonQuery()

                Next


                sqlpass = "exec jct_ops_raw_material_receipt_entry '" & _
                            LTrim(RTrim(Me.ddl_action.Text)) & "'," & _
                            sno1 & ",'" & Now() & "','" & _
                            UCase(LTrim(RTrim(Me.txt_tranno.Text))) & "','" & _
                            UCase(LTrim(RTrim(Me.ddl_plant.Text))) & "','" & _
                            UCase(LTrim(RTrim(Me.txt_groupcode.Text))) & "','" & _
                            Mid(LTrim(RTrim(Me.ddl_itemgroup.Text)), 1, Len(LTrim(RTrim(Me.ddl_itemgroup.Text))) - (Len(LTrim(RTrim(Me.txt_groupcode.Text))) + 1)) & "','" & _
                            LTrim(RTrim(Me.txt_supplier_code.Text)) & "','" & _
                            Mid(LTrim(RTrim(Me.ddl_supplier.Text)), 1, Len(LTrim(RTrim(Me.ddl_supplier.Text))) - (Len(LTrim(RTrim(Me.txt_supplier_code.Text))) + 1)) & "','" & _
                            LTrim(RTrim(Me.txt_pay_term_code.Text)) & "','" & _
                            LTrim(RTrim(Me.txt_pay_term_desc.Text)) & "','" & _
                            efrom & "','" & _
                            eto & "','" & _
                            LTrim(RTrim(Me.txt_itemcode.Text)) & "','" & _
                            LTrim(RTrim(Me.txt_variant.Text)) & "','" & _
                            LTrim(RTrim(Me.txt_item_desc.Text)) & "','" & _
                            LTrim(RTrim(Me.txt_variant_desc.Text)) & "'," & _
                            LTrim(RTrim(Me.txt_qty.Text)) & ",'" & _
                            LTrim(RTrim(Me.ddl_uom.Text)) & "'," & _
                            LTrim(RTrim(Me.txt_rate.Text)) & "," & _
                            LTrim(RTrim(Me.txt_value.Text)) & ",'" & _
                            reqddt & "'," & _
                            LTrim(RTrim(Me.txt_last_rate.Text)) & ",'" & _
                            recvdt & "'," & _
                            LTrim(RTrim(Me.txt_lead_time.Text)) & ",'" & _
                            procdt & "','" & _
                            LTrim(RTrim(Me.txt_invno.Text)) & "'," & _
                            LTrim(RTrim(Me.txt_budget_qty.Text)) & "," & _
                            LTrim(RTrim(Me.txt_budget_value.Text)) & "," & _
                            LTrim(RTrim(Me.txt_plan_qty.Text)) & "," & _
                            LTrim(RTrim(Me.txt_plan_value.Text)) & "," & _
                            LTrim(RTrim(Me.txt_actual_qty.Text)) & "," & _
                            LTrim(RTrim(Me.txt_actual_value.Text)) & ",'','" & _
                            LTrim(RTrim(Me.txt_reason.Text)) & "','" & _
                            UCase(LTrim(RTrim(Session("empcode")))) & "','" & _
                            UCase(LTrim(RTrim(Session("companycode")))) & "'"

                cmd = New SqlCommand(sqlpass, obj.cn)
                cmd.CommandTimeout = 0
                cmd.Transaction = btran
                cmd.ExecuteNonQuery()


                btran.Commit()
                dr.Close()
                obj.closecn()
                ''''''''''Meaasage'''''''''''''
                FMsg.Message = "Success"
                FMsg.CssClass = "addmsg"
                FMsg.Display()
                '''''''''''''''''''''''''''''''

            Catch ex As Exception

                btran.Rollback()
                dr.Close()
                obj.closecn()
                FMsg.Message = (ex.Message)
                FMsg.CssClass = "addmsg"
                FMsg.Display()
                'Me.lbt_close_Click(sender, e)       ''  Execute EXIT button script
                Exit Sub

            End Try


        End If  '' end of ADD mode


        ''================================================================


        If (UCase(LTrim(RTrim(Me.ddl_action.Text))) = "MODIFY" Or UCase(LTrim(RTrim(Me.ddl_action.Text))) = "CANCEL" Or UCase(LTrim(RTrim(Me.ddl_action.Text))) = "SHORT CLOSE" Or UCase(LTrim(RTrim(Me.ddl_action.Text))) = "AUTHORIZE") Then

            Dim sysdate As Date

            If LTrim(RTrim(Me.txt_tranno.Text)) = "" Then
                FMsg.Message = "Pl. enter Tran. No. "
                FMsg.CssClass = "errormsg"
                FMsg.Display()
                Me.txt_tranno.Focus()
                Exit Sub
            End If

            If UCase(LTrim(RTrim(Me.ddl_action.Text))) = "SHORT CLOSE" And LTrim(RTrim(Me.txt_reason.Text)) = "" Then
                FMsg.Message = "Pl. enter reason for Short Close "
                FMsg.CssClass = "errormsg"
                FMsg.Display()
                Me.txt_reason.Focus()
                Exit Sub
            End If


            'If UCase(LTrim(RTrim(Me.ddl_action.Text))) = "CANCEL" Or UCase(LTrim(RTrim(Me.ddl_action.Text))) = "SHORT CLOSE" Then

            '    obj.opencn()

            '    sqlpass = "select tran_no,isnull(status,'') " & _
            '            "from jct_costing_count_process_mapping_header " & _
            '            "where tran_no<>'" & UCase(LTrim(RTrim(Me.txt_tranno.Text))) & "' " & _
            '            "and location='" & LTrim(RTrim(Me.ddl_location.Text)) & "' " & _
            '            "and count_code='" & LTrim(RTrim(Me.txt_countcode.Text)) & "' " & _
            '            "/*and process_location_code='" & LTrim(RTrim(Me.ddl_process_location_code.Text)) & "' " & _
            '            "and process_stage_code='" & LTrim(RTrim(Me.ddl_process_stage_code.Text)) & "'*/ " & _
            '            "and rate_type='" & Left(LTrim(Me.ddl_ratetype.Text), 1) & "' " & _
            '            "and eff_from>='" & CDate(Me.txt_efffrom.Text).Date & "' " & _
            '            "and status not in ('C','S') " & _
            '            "and company_code='" & UCase(LTrim(RTrim(Session("companycode")))) & "'"

            '    cmd = New SqlCommand(sqlpass, obj.cn)
            '    dr = cmd.ExecuteReader

            '    If dr.HasRows = True Then
            '        dr.Read()
            '        FMsg.Message = "Pl. first delete last active transaction of above parameters "
            '        FMsg.CssClass = "errormsg"
            '        FMsg.Display()
            '        dr.Close()
            '        obj.closecn()
            '        Me.txt_tranno.Focus()
            '        Exit Sub
            '    End If
            '    dr.Close()
            '    obj.closecn()

            'End If


            'obj.opencn()

            'sqlpass = "select tran_no,isnull(status,'') " & _
            '        "from jct_ops_raw_material_receipt_header " & _
            '        "where location='" & LTrim(RTrim(Me.ddl_plant.Text)) & "' " & _
            '        "and item_group='" & LTrim(RTrim(Me.ddl_itemgroup.Text)) & "' " & _
            '        "and ltrim(rtrim(supplier_name))+" - "+ltrim(rtrim(supplier_code))='" & LTrim(Me.ddl_supplier.Text) & "' " & _
            '        "and left(ltrim(status),1)='O' " & _
            '        "and upper(ltrim(rtrim(company_code)))='" & UCase(LTrim(RTrim(Session("companycode")))) & "'"

            'cmd = New SqlCommand(sqlpass, obj.cn)
            'dr = cmd.ExecuteReader

            'If dr.HasRows = True Then
            '    dr.Read()
            '    FMsg.Message = "Tran.No. " & dr.Item(0) & " of above parameters already exists in OPEN status, Pl. first AUTHORIZE the Tran.No. "
            '    FMsg.CssClass = "errormsg"
            '    FMsg.Display()
            '    dr.Close()
            '    obj.closecn()
            '    Me.ddl_plant.Focus()
            '    Exit Sub
            'End If
            'dr.Close()
            'obj.closecn()


            obj.opencn()
            btran = obj.cn.BeginTransaction

            Try

                ''sqlpass = "select case isnull(status,'') when 'O' then 'OPEN' when 'A' then 'AUTHORIZE' when 'C' then 'CANCEL' when 'S' then 'SHORT CLOSE' when 'F' then 'FINISH' end " & _
                sqlpass = "select case isnull(a.status,'') when 'O' then 'OPEN' when 'A' then 'AUTHORIZE' when 'C' then 'CANCEL' when 'S' then 'SHORT CLOSE' when 'F' then 'FINISH' end " & _
                    "from jct_ops_raw_material_receipt_header a " & _
                    "where a.tran_no='" & UCase(LTrim(RTrim(Me.txt_tranno.Text))) & "' " & _
                    "and a.company_code='" & UCase(LTrim(RTrim(Session("companycode")))) & "'"

                cmd = New SqlCommand(sqlpass, obj.cn)
                cmd.Transaction = btran
                dr = cmd.ExecuteReader

                If dr.HasRows = True Then
                    dr.Read()

                    ''If LTrim(RTrim(dr.Item(0))) = "CANCEL" Or LTrim(RTrim(dr.Item(0))) = "SHORT CLOSE" Or LTrim(RTrim(dr.Item(0))) = "AUTHORIZE" Then
                    If LTrim(RTrim(dr.Item(0))) = "CANCEL" Or LTrim(RTrim(dr.Item(0))) = "SHORT CLOSE" Or LTrim(RTrim(dr.Item(0))) = "AUTHORIZE" Then
                        ''If (UCase(LTrim(RTrim(dr.Item(0)))) = UCase(LTrim(RTrim(Me.ddl_action.Text)))) Or ((UCase(LTrim(RTrim(dr.Item(0)))) = "CANCEL" Or UCase(LTrim(RTrim(dr.Item(0)))) = "SHORT CLOSE") And (UCase(LTrim(RTrim(Me.ddl_action.Text))) = "MODIFY" Or UCase(LTrim(RTrim(Me.ddl_action.Text))) = "AUTHORIZE" Or UCase(LTrim(RTrim(Me.ddl_action.Text))) = "CANCEL" Or UCase(LTrim(RTrim(Me.ddl_action.Text))) = "SHORT CLOSE" Or UCase(LTrim(RTrim(Me.ddl_action.Text))) = "FREEZE")) Or (UCase(LTrim(RTrim(dr.Item(0)))) = "OPEN" And (UCase(LTrim(RTrim(Me.ddl_action.Text))) = "ACTUAL OUT" Or UCase(LTrim(RTrim(Me.ddl_action.Text))) = "FREEZE")) Or (UCase(LTrim(RTrim(dr.Item(0)))) = "AUTHORIZE" And UCase(LTrim(RTrim(Me.ddl_action.Text))) = "CANCEL") Or (UCase(LTrim(RTrim(dr.Item(0)))) <> "OPEN" And UCase(LTrim(RTrim(Me.ddl_action.Text))) = "MODIFY") Or ((UCase(LTrim(RTrim(Me.ddl_action.Text))) = "CANCEL" Or UCase(LTrim(RTrim(Me.ddl_action.Text))) = "AUTHORIZE") And UCase(LTrim(RTrim(dr.Item(0)))) = "FREEZE") Then
                        If (UCase(LTrim(RTrim(dr.Item(0)))) = UCase(LTrim(RTrim(Me.ddl_action.Text)))) Or ((UCase(LTrim(RTrim(dr.Item(0)))) = "CANCEL" Or UCase(LTrim(RTrim(dr.Item(0)))) = "SHORT CLOSE") And (UCase(LTrim(RTrim(Me.ddl_action.Text))) = "MODIFY" Or UCase(LTrim(RTrim(Me.ddl_action.Text))) = "AUTHORIZE" Or UCase(LTrim(RTrim(Me.ddl_action.Text))) = "CANCEL" Or UCase(LTrim(RTrim(Me.ddl_action.Text))) = "SHORT CLOSE" Or UCase(LTrim(RTrim(Me.ddl_action.Text))) = "FREEZE")) Or (UCase(LTrim(RTrim(dr.Item(0)))) = "OPEN" And (UCase(LTrim(RTrim(Me.ddl_action.Text))) = "ACTUAL OUT" Or UCase(LTrim(RTrim(Me.ddl_action.Text))) = "FREEZE")) Or (UCase(LTrim(RTrim(dr.Item(0)))) = "AUTHORIZE" And UCase(LTrim(RTrim(Me.ddl_action.Text))) = "CANCEL") Or (UCase(LTrim(RTrim(dr.Item(0)))) <> "OPEN" And UCase(LTrim(RTrim(Me.ddl_action.Text))) = "MODIFY") Or ((UCase(LTrim(RTrim(Me.ddl_action.Text))) = "CANCEL" Or UCase(LTrim(RTrim(Me.ddl_action.Text))) = "AUTHORIZE") And UCase(LTrim(RTrim(dr.Item(0)))) = "FREEZE") Then
                            FMsg.Message = "Tran. No. already " + LTrim(RTrim(dr.Item(0)))
                            FMsg.CssClass = "errormsg"
                            FMsg.Display()
                            Me.txt_tranno.Focus()
                            dr.Close()
                            obj.closecn()
                            Exit Sub
                        Else
                            'Me.lnk_print.Enabled = True
                        End If
                    Else
                        'Me.lnk_print.Enabled = False
                    End If

                    If LTrim(RTrim(dr.Item(0))) <> "OPEN" And LTrim(RTrim(Me.ddl_action.Text)) = "MODIFY" Then
                        FMsg.Message = "Tran. No. already " + LTrim(RTrim(dr.Item(0)))
                        FMsg.CssClass = "errormsg"
                        FMsg.Display()
                        Me.lbl_status.Text = LTrim(RTrim(dr.Item(0)))
                        Me.txt_tranno.Focus()
                        dr.Close()
                        obj.closecn()
                        Exit Sub
                    Else
                        Me.lbl_status.Text = dr.Item(0)
                        dr.Close()
                        'obj.closecn()
                    End If
                Else
                    FMsg.Message = "Invalid Tran. No."
                    FMsg.CssClass = "errormsg"
                    FMsg.Display()
                    Me.lbl_status.Text = ""
                    Me.txt_tranno.Focus()
                    dr.Close()
                    obj.closecn()
                    Exit Sub
                End If
                'me.lbl_status.Text = dr.Item(0)
                'dr.Close()


                ''DELETION OF EXISTING TRANSACTION
                If UCase(LTrim(RTrim(Me.ddl_action.Text))) = "MODIFY" Then

                    sqlpass = "select top 1 system_date " & _
                        "from jct_ops_raw_material_receipt_header " & _
                        "where tran_no='" & LTrim(RTrim(Me.txt_tranno.Text)) & "' " & _
                        "and left(status,1)='O' " & _
                        "and company_code='" & UCase(LTrim(RTrim(Session("companycode")))) & "' " & _
                        "order by system_date "

                    cmd = New SqlCommand(sqlpass, obj.cn)
                    cmd.Transaction = btran
                    dr = cmd.ExecuteReader

                    If dr.HasRows = True Then
                        dr.Read()
                        'Me.txt_date.Text = dr.Item(0)
                        sysdate = dr.Item(0)
                    Else
                        FMsg.Message = "Invalid Tran. No."
                        FMsg.CssClass = "errormsg"
                        FMsg.Display()
                        dr.Close()
                        obj.closecn()
                        Me.txt_tranno.Focus()
                        Exit Sub
                    End If
                    dr.Close()

                    sqlpass = "delete from jct_ops_raw_material_receipt_header " & _
                                "where tran_no='" & LTrim(RTrim(Me.txt_tranno.Text)) & "' " & _
                                "and left(status,1)='O' " & _
                                "and company_code='" & UCase(LTrim(RTrim(Session("companycode")))) & "' "

                    cmd = New SqlCommand(sqlpass, obj.cn)
                    cmd.Transaction = btran
                    cmd.ExecuteNonQuery()

                    ''==== open below area in case detail table exists in database
                    'sqlpass = "delete from jct_ops_raw_material_receipt_detail " & _
                    '            "where tran_no='" & LTrim(RTrim(Me.txt_tranno.Text)) & "' " & _
                    '            "and company_code='" & UCase(LTrim(RTrim(Session("companycode")))) & "' "

                    'cmd = New SqlCommand(sqlpass, obj.cn)
                    'cmd.Transaction = btran
                    'cmd.ExecuteNonQuery()


                    sqlpass = "delete from jct_ops_raw_material_receipt_header_supplier " & _
                            "where tran_no = '" & LTrim(RTrim(Me.txt_tranno.Text)) & "' " & _
                            "and company_code='" & UCase(LTrim(RTrim(Session("companycode")))) & "' "

                    cmd = New SqlCommand(sqlpass, obj.cn)
                    cmd.Transaction = btran
                    cmd.ExecuteNonQuery()


                    For i = 0 To Me.ddl_supplier_code.Items.Count - 1

                        sqlpass = "insert into jct_ops_raw_material_receipt_header_supplier " & _
                                "(tran_no,location,supplier_code,supplier_name," & _
                                "userid,hostname,company_code) " & _
                                "Select '" & Me.txt_tranno.Text & "','" & _
                                Me.ddl_plant.Text & "','" & _
                                LTrim(RTrim(Mid(Me.ddl_supplier_code.Items(i).Text, InStr(Me.ddl_supplier_code.Items(i).Text, "|") + 1, 10))) & "','" & _
                                LTrim(RTrim(Mid(Me.ddl_supplier_code.Items(i).Text, 1, InStr(Me.ddl_supplier_code.Items(i).Text, "|") - 1))) & "','" & _
                                Session("empcode") & "',LTrim(RTrim(host_name())) ,'" & _
                                UCase(LTrim(RTrim(Session("companycode")))) & "' "

                        cmd = New SqlCommand(sqlpass, obj.cn)
                        cmd.Transaction = btran
                        cmd.ExecuteNonQuery()

                    Next

                End If


                ''REASON FOR CANCEL/SHORT CLOSE
                Dim reason As String = ""

                'If UCase(LTrim(RTrim(Me.ddl_action.Text))) = "CANCEL" Or UCase(LTrim(RTrim(Me.ddl_action.Text))) = "SHORT CLOSE" Then
                '    While reason = ""
                '        reason = (InputBox("Enter Reason for " + UCase(LTrim(RTrim(Me.ddl_action.Text))), " Tran. No.", ""))
                '    End While
                'End If


                ''STORE HERE EACH ACTIVITY IN ACTION TABLE
                sqlpass = "insert into jct_ops_action_detail (tran_no,date,detail,userid,hostname,company_code) " & _
                        "Select '" & Me.txt_tranno.Text & "',getdate(),'" & _
                        LTrim(RTrim(Me.ddl_action.Text)) & "'+'-'+'" & reason & "','" & _
                        Session("empcode") & "',LTrim(RTrim(host_name())) ,'" & _
                        UCase(LTrim(RTrim(Session("companycode")))) & "' "

                cmd = New SqlCommand(sqlpass, obj.cn)
                cmd.Transaction = btran
                cmd.ExecuteNonQuery()


                ''ENTRY THROUGH SQL PROCEDURE

                sqlpass = "exec jct_ops_raw_material_receipt_entry '" & _
                        LTrim(RTrim(Me.ddl_action.Text)) & "'," & _
                        sno1 & ",'" & sysdate & "','" & _
                        UCase(LTrim(RTrim(Me.txt_tranno.Text))) & "','" & _
                        UCase(LTrim(RTrim(Me.ddl_plant.Text))) & "','" & _
                        UCase(LTrim(RTrim(Me.txt_groupcode.Text))) & "','" & _
                        Mid(LTrim(RTrim(Me.ddl_itemgroup.Text)), 1, Len(LTrim(RTrim(Me.ddl_itemgroup.Text))) - (Len(LTrim(RTrim(Me.txt_groupcode.Text))) + 1)) & "','" & _
                        LTrim(RTrim(Me.txt_supplier_code.Text)) & "','" & _
                        Mid(LTrim(RTrim(Me.ddl_supplier.Text)), 1, Len(LTrim(RTrim(Me.ddl_supplier.Text))) - (Len(LTrim(RTrim(Me.txt_supplier_code.Text))) + 1)) & "','" & _
                        LTrim(RTrim(Me.txt_pay_term_code.Text)) & "','" & _
                        LTrim(RTrim(Me.txt_pay_term_desc.Text)) & "','" & _
                        efrom & "','" & _
                        eto & "','" & _
                        LTrim(RTrim(Me.txt_itemcode.Text)) & "','" & _
                        LTrim(RTrim(Me.txt_variant.Text)) & "','" & _
                        LTrim(RTrim(Me.txt_item_desc.Text)) & "','" & _
                        LTrim(RTrim(Me.txt_variant_desc.Text)) & "'," & _
                        LTrim(RTrim(Me.txt_qty.Text)) & ",'" & _
                        LTrim(RTrim(Me.ddl_uom.Text)) & "'," & _
                        LTrim(RTrim(Me.txt_rate.Text)) & "," & _
                        LTrim(RTrim(Me.txt_value.Text)) & ",'" & _
                        reqddt & "'," & _
                        LTrim(RTrim(Me.txt_last_rate.Text)) & ",'" & _
                        recvdt & "'," & _
                        LTrim(RTrim(Me.txt_lead_time.Text)) & ",'" & _
                        procdt & "','" & _
                        LTrim(RTrim(Me.txt_invno.Text)) & "'," & _
                        LTrim(RTrim(Me.txt_budget_qty.Text)) & "," & _
                        LTrim(RTrim(Me.txt_budget_value.Text)) & "," & _
                        LTrim(RTrim(Me.txt_plan_qty.Text)) & "," & _
                        LTrim(RTrim(Me.txt_plan_value.Text)) & "," & _
                        LTrim(RTrim(Me.txt_actual_qty.Text)) & "," & _
                        LTrim(RTrim(Me.txt_actual_value.Text)) & ",'','" & _
                        LTrim(RTrim(Me.txt_reason.Text)) & "','" & _
                        UCase(LTrim(RTrim(Session("empcode")))) & "','" & _
                        UCase(LTrim(RTrim(Session("companycode")))) & "'"

                cmd = New SqlCommand(sqlpass, obj.cn)
                cmd.CommandTimeout = 0
                cmd.Transaction = btran
                cmd.ExecuteNonQuery()


                btran.Commit()
                dr.Close()
                obj.closecn()

                ''''''''''Meaasage'''''''''''''
                FMsg.Message = "Success"
                FMsg.CssClass = "addmsg"
                FMsg.Display()
                '''''''''''''''''''''''''''''''

                If UCase(LTrim(RTrim(Me.ddl_action.Text))) = "CANCEL" Or UCase(LTrim(RTrim(Me.ddl_action.Text))) = "SHORT CLOSE" Then
                    Me.lbl_status.Text = "SHORT CLOSE" 'UCase(LTrim(RTrim(Me.ddl_action.Text)))
                    'Me.btn_print.Enabled = True
                Else
                    'Me.btn_print.Enabled = False
                End If
                If UCase(LTrim(RTrim(Me.ddl_action.Text))) = "AUTHORIZE" Then
                    Me.lbl_status.Text = UCase(LTrim(RTrim(Me.ddl_action.Text)))
                End If


            Catch ex As Exception

                btran.Rollback()
                dr.Close()
                obj.closecn()
                FMsg.Message = (ex.Message)
                FMsg.CssClass = "addmsg"
                FMsg.Display()

            End Try

        End If  ''end of Modify/Cancel/Short Close/Authorise Part 

    End Sub

    Protected Sub imb_tran_fetch_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imb_tran_fetch.Click

        If UCase(LTrim(RTrim(Me.ddl_action.Text))) = "MODIFY" Or UCase(LTrim(RTrim(Me.ddl_action.Text))) = "VIEW" Or UCase(LTrim(RTrim(Me.ddl_action.Text))) = "CANCEL" Or UCase(LTrim(RTrim(Me.ddl_action.Text))) = "SHORT CLOSE" Or UCase(LTrim(RTrim(Me.ddl_action.Text))) = "AUTHORIZE" Then

            If LTrim(RTrim(Me.txt_tranno.Text)) = "" Then
                FMsg.Message = "Pl. enter Tran. No. "
                FMsg.CssClass = "errormsg"
                FMsg.Display()
                Me.txt_tranno.Focus()
                Exit Sub
            End If

            ''sqlpass = "select case isnull(status,'') when 'O' then 'OPEN' when 'A' then 'AUTHORIZE' when 'C' then 'CANCEL' when 'S' then 'SHORT CLOSE' when 'F' then 'FINISH' end " & _
            sqlpass = "select case isnull(a.status,'') when 'O' then 'OPEN' when 'A' then 'AUTHORIZE' when 'C' then 'CANCEL' when 'S' then 'SHORT CLOSE' when 'F' then 'FINISH' end " & _
                "from jct_ops_raw_material_receipt_header a " & _
                "where a.tran_no='" & UCase(LTrim(RTrim(Me.txt_tranno.Text))) & "' " & _
                "and a.company_code='" & UCase(LTrim(RTrim(Session("companycode")))) & "'"

            obj.opencn()
            cmd = New SqlCommand(sqlpass, obj.cn)
            dr = cmd.ExecuteReader

            If dr.HasRows = True Then
                dr.Read()

                ' ''If LTrim(RTrim(dr.Item(0))) = "CANCEL" Or LTrim(RTrim(dr.Item(0))) = "SHORT CLOSE" Or LTrim(RTrim(dr.Item(0))) = "AUTHORIZE" Then
                'If LTrim(RTrim(dr.Item(0))) = "CANCEL" Or LTrim(RTrim(dr.Item(0))) = "SHORT CLOSE" Or LTrim(RTrim(dr.Item(0))) = "AUTHORIZE" Then
                '    ''If (UCase(LTrim(RTrim(dr.Item(0)))) = UCase(LTrim(RTrim(Me.ddl_action.Text)))) Or ((UCase(LTrim(RTrim(dr.Item(0)))) = "CANCEL" Or UCase(LTrim(RTrim(dr.Item(0)))) = "SHORT CLOSE") And (UCase(LTrim(RTrim(Me.ddl_action.Text))) = "MODIFY" Or UCase(LTrim(RTrim(Me.ddl_action.Text))) = "AUTHORIZE" Or UCase(LTrim(RTrim(Me.ddl_action.Text))) = "CANCEL" Or UCase(LTrim(RTrim(Me.ddl_action.Text))) = "SHORT CLOSE" Or UCase(LTrim(RTrim(Me.ddl_action.Text))) = "FREEZE")) Or (UCase(LTrim(RTrim(dr.Item(0)))) = "OPEN" And (UCase(LTrim(RTrim(Me.ddl_action.Text))) = "ACTUAL OUT" Or UCase(LTrim(RTrim(Me.ddl_action.Text))) = "FREEZE")) Or (UCase(LTrim(RTrim(dr.Item(0)))) = "AUTHORIZE" And UCase(LTrim(RTrim(Me.ddl_action.Text))) = "CANCEL") Or (UCase(LTrim(RTrim(dr.Item(0)))) <> "OPEN" And UCase(LTrim(RTrim(Me.ddl_action.Text))) = "MODIFY") Or ((UCase(LTrim(RTrim(Me.ddl_action.Text))) = "CANCEL" Or UCase(LTrim(RTrim(Me.ddl_action.Text))) = "AUTHORIZE") And UCase(LTrim(RTrim(dr.Item(0)))) = "FREEZE") Then
                '    If (UCase(LTrim(RTrim(dr.Item(0)))) = UCase(LTrim(RTrim(Me.ddl_action.Text)))) Or ((UCase(LTrim(RTrim(dr.Item(0)))) = "CANCEL" Or UCase(LTrim(RTrim(dr.Item(0)))) = "SHORT CLOSE") And (UCase(LTrim(RTrim(Me.ddl_action.Text))) = "MODIFY" Or UCase(LTrim(RTrim(Me.ddl_action.Text))) = "AUTHORIZE" Or UCase(LTrim(RTrim(Me.ddl_action.Text))) = "CANCEL" Or UCase(LTrim(RTrim(Me.ddl_action.Text))) = "SHORT CLOSE" Or UCase(LTrim(RTrim(Me.ddl_action.Text))) = "FREEZE")) Or (UCase(LTrim(RTrim(dr.Item(0)))) = "OPEN" And (UCase(LTrim(RTrim(Me.ddl_action.Text))) = "ACTUAL OUT" Or UCase(LTrim(RTrim(Me.ddl_action.Text))) = "FREEZE")) Or (UCase(LTrim(RTrim(dr.Item(0)))) = "AUTHORIZE" And UCase(LTrim(RTrim(Me.ddl_action.Text))) = "CANCEL") Or (UCase(LTrim(RTrim(dr.Item(0)))) <> "OPEN" And UCase(LTrim(RTrim(Me.ddl_action.Text))) = "MODIFY") Or ((UCase(LTrim(RTrim(Me.ddl_action.Text))) = "CANCEL" Or UCase(LTrim(RTrim(Me.ddl_action.Text))) = "AUTHORIZE") And UCase(LTrim(RTrim(dr.Item(0)))) = "FREEZE") Then
                '        FMsg.Message = "Tran. No. already " + LTrim(RTrim(dr.Item(0)))
                '        FMsg.CssClass = "errormsg"
                '        FMsg.Display()
                '        Me.lbl_status.Text = LTrim(RTrim(dr.Item(0)))
                '        Me.txt_tranno.Focus()
                '        dr.Close()
                '        obj.closecn()
                '        Exit Sub
                '    Else
                '        'Me.lnk_print.Enabled = True
                '    End If
                'Else
                '    'Me.lnk_print.Enabled = False
                'End If

                'If LTrim(RTrim(dr.Item(0))) <> "OPEN" And LTrim(RTrim(Me.ddl_action.Text)) = "MODIFY" Then
                '    FMsg.Message = "Tran. No. already " + LTrim(RTrim(dr.Item(0)))
                '    FMsg.CssClass = "errormsg"
                '    FMsg.Display()
                '    Me.lbl_status.Text = LTrim(RTrim(dr.Item(0)))
                '    Me.txt_tranno.Focus()
                '    dr.Close()
                '    obj.closecn()
                '    Exit Sub
                'Else
                Me.lbl_status.Text = LTrim(RTrim(dr.Item(0)))
                dr.Close()
                obj.closecn()
                'End If
            Else
                FMsg.Message = "Invalid Tran. No."
                FMsg.CssClass = "errormsg"
                FMsg.Display()
                'Me.GridView1.DataSource = Nothing
                'GridView1.DataBind()
                Me.lbl_status.Text = ""
                Me.txt_efffrom.Text = Now().Date
                Me.txt_effto.Text = Now().Date
                Me.txt_tranno.Focus()
                dr.Close()
                obj.closecn()
                Exit Sub
            End If
            'me.lbl_status.Text = dr.Item(0)
            'dr.Close()

            Dim trandate As Date = Now().Date

            ''Fill Header Part
            sqlpass = "select a.tran_no, a.location, a.group_code, a.group_desc, a.supplier_code, a.supplier_name, " & _
                    "isnull(a.address1,''), isnull(a.address2,''), isnull(a.address3,''), isnull(a.city,''), isnull(a.state,''), " & _
                    "a.pay_term_code, isnull(a.pay_term_desc,''), isnull(convert(varchar(11),a.eff_from,101),''), " & _
                    "isnull(convert(varchar(11),a.eff_to,101),''), " & _
                    "a.item_code, a.item_variant, a.item_desc, a.item_short_desc, " & _
                    "a.quantity, a.uom, isnull(a.rate,0), isnull(a.value,0), " & _
                    "convert(varchar(11),a.required_date,101), " & _
                    "isnull(a.last_rate,0), convert(varchar(11),a.receive_date,101), " & _
                    "isnull(a.lead_time,0), convert(varchar(11), a.procurement_date,101), " & _
                    "isnull(a.invoice_no,''), isnull(a.budget_qty,0), isnull(a.budget_value,0), " & _
                    "isnull(a.plan_qty,0), isnull(a.plan_value,0), isnull(a.actual_qty,0), isnull(a.actual_value,0), " & _
                    "case isnull(a.status,'') when 'O' then 'OPEN' when 'A' then 'AUTHORIZE' " & _
                    "when 'C' then 'CANCEL' when 'S' then 'SHORT CLOSE' end 'status', a.system_date " & _
                    "from jct_ops_raw_material_receipt_header a " & _
                    "where a.tran_no='" & LTrim(RTrim(Me.txt_tranno.Text)) & "' " & _
                    "/*and a.status not in ('C','S')*/ " & _
                    "and a.company_code='" & UCase(LTrim(RTrim(Session("companycode")))) & "' "


            obj.opencn()
            cmd = New SqlCommand(sqlpass, obj.cn)
            dr = cmd.ExecuteReader

            If dr.HasRows = True Then
                dr.Read()
                Me.ddl_plant.Text = dr.Item(1)
                Me.txt_groupcode.Text = dr.Item(2)
                Me.ddl_itemgroup.Text = LTrim(RTrim(dr.Item(3))) + "|" + LTrim(RTrim(dr.Item(2)))
                Me.txt_supplier_code.Text = dr.Item(4)
                Me.ddl_supplier.Text = LTrim(RTrim(dr.Item(5))) + "|" + LTrim(RTrim(dr.Item(4)))
                Me.lbl_address.Text = LTrim(RTrim(dr.Item(6))) + LTrim(RTrim(dr.Item(7))) + LTrim(RTrim(dr.Item(8)))
                Me.lbl_city.Text = dr.Item(9)
                Me.txt_pay_term_code.Text = dr.Item(11)
                Me.txt_pay_term_desc.Text = dr.Item(12)
                Me.txt_efffrom.Text = dr.Item(13)
                Me.txt_effto.Text = dr.Item(14)
                Me.txt_itemcode.Text = dr.Item(15)
                Me.txt_variant.Text = dr.Item(16)
                Me.txt_item_desc.Text = dr.Item(17)
                Me.txt_variant_desc.Text = dr.Item(18)
                Me.txt_qty.Text = dr.Item(19)
                Me.ddl_uom.Text = dr.Item(20)
                Me.txt_rate.Text = dr.Item(21)
                Me.txt_value.Text = dr.Item(22)
                Me.txt_required_date.Text = dr.Item(23)
                Me.txt_last_rate.Text = dr.Item(24)
                Me.txt_receive_date.Text = dr.Item(25)
                Me.txt_lead_time.Text = dr.Item(26)
                Me.txt_procurement_date.Text = dr.Item(27)
                Me.txt_invno.Text = dr.Item(28)
                Me.txt_budget_qty.Text = dr.Item(29)
                Me.txt_budget_value.Text = dr.Item(30)
                Me.txt_plan_qty.Text = dr.Item(31)
                Me.txt_plan_value.Text = dr.Item(32)
                Me.txt_actual_qty.Text = dr.Item(33)
                Me.txt_actual_value.Text = dr.Item(34)
                Me.lbl_status.Text = dr.Item(35)
                trandate = dr.Item(36)

                dr.Close()
                obj.closecn()

            End If


            ''Fill Detail Part
            sqlpass = "select distinct ltrim(rtrim(a.supplier_name)) + '|' + ltrim(rtrim(a.supplier_code)) " & _
                    "from jct_ops_raw_material_receipt_header_supplier a " & _
                    "where a.tran_no='" & LTrim(RTrim(Me.txt_tranno.Text)) & "' " & _
                    "and a.company_code='" & UCase(LTrim(RTrim(Session("companycode")))) & "' " & _
                    "order by ltrim(rtrim(a.supplier_name)) + '|' + ltrim(rtrim(a.supplier_code)) "

            obj.opencn()
            cmd = New SqlCommand(sqlpass, obj.cn)
            dr = cmd.ExecuteReader

            Me.ddl_supplier_code.Items.Clear()

            If dr.HasRows = True Then

                While dr.Read
                    Me.ddl_supplier_code.Items.Add(dr.Item(0))
                End While
                Me.ddl_supplier_code.SelectedIndex = 0

                dr.Close()
                obj.closecn()

                ''Reset Supplier & Supplier code according to multiple suppliers selected in combo box
                Me.ddl_supplier.Text = LTrim(RTrim(Me.ddl_supplier_code.Text))
                Me.txt_supplier_code.Text = LTrim(RTrim(Mid(Me.ddl_supplier.Text, InStr(Me.ddl_supplier.Text, "|") + 1, 10)))

            End If

            Me.txt_tranno.Focus()


            ''=================================================

            ''-----Fill Last Rate text box
            ''Last Rate pick from Purchase Order file
            'sqlpass = "select top 1 convert(numeric(10,2),a.rate/a.rate_per) " & _
            '            "from miserp.pomdb.dbo.pur_po_detail a, miserp.pomdb.dbo.pur_po_header b " & _
            '            "where a.stock_no ='" & LTrim(RTrim(Me.txt_itemcode.Text)) & "' " & _
            '            "and a.stock_variant='" & LTrim(RTrim(Me.txt_variant.Text)) & "' " & _
            '            "and a.company_code='" & UCase(LTrim(RTrim(Session("companycode")))) & "' " & _
            '            "and a.po_no = b.po_no " & _
            '            "order by b.po_date desc "

            ''Rate pick from order based pur_gi_detail file
            sqlpass = "select top 1 convert(numeric(10,2),a.rate/a.rate_per), b.gi_date " & _
                        "from miserp.pomdb.dbo.pur_gi_detail a, miserp.pomdb.dbo.pur_gi_header b " & _
                        "where a.stock_no ='" & LTrim(RTrim(Me.txt_itemcode.Text)) & "' " & _
                        "and a.stock_variant='" & LTrim(RTrim(Me.txt_variant.Text)) & "' " & _
                        "and a.company_code='" & UCase(LTrim(RTrim(Session("companycode")))) & "' " & _
                        "and a.gi_no = b.gi_no " & _
                        "order by b.gi_date desc "

            obj.opencn()
            cmd = New SqlCommand(sqlpass, obj.cn)
            dr = cmd.ExecuteReader

            If dr.HasRows = True Then
                dr.Read()
                Me.txt_last_rate.Text = dr.Item(0)
                'Me.txt_receive_date.Text = CDate(dr.Item(1)).Date

                dr.Close()
                obj.closecn()

                ''Fill latest unplanned receive date
                sqlpass = "select top 1 b.gi_date " & _
                    "from miserp.pomdb.dbo.pur_gi_detail a, miserp.pomdb.dbo.pur_gi_header b " & _
                    "where a.stock_no = '" & LTrim(RTrim(Me.txt_itemcode.Text)) & "' " & _
                    "and a.stock_variant = '" & LTrim(RTrim(Me.txt_variant.Text)) & "' " & _
                    "and a.company_code = '" & UCase(LTrim(RTrim(Session("companycode")))) & "' " & _
                    "and a.gi_no = b.gi_no " & _
                    "and b.gi_date >= case when '" & LTrim(RTrim(Me.txt_tranno.Text)) & "' = '' then getdate() else " & _
                    "(select system_date from jct_ops_raw_material_receipt_header " & _
                    "where tran_no = '" & LTrim(RTrim(Me.txt_tranno.Text)) & "' " & _
                    "and company_code = '" & UCase(LTrim(RTrim(Session("companycode")))) & "') end " & _
                    "order by b.gi_date "

                obj.opencn()
                cmd = New SqlCommand(sqlpass, obj.cn)
                dr = cmd.ExecuteReader

                If dr.HasRows = True Then
                    dr.Read()
                    Me.txt_receive_date.Text = CDate(dr.Item(0)).Date
                Else
                    'FMsg.Message = "Order based material still not received "
                    'FMsg.CssClass = "errormsg"
                    'FMsg.Display()
                    'Me.txt_variant.Focus()
                    'Exit Sub
                End If
            Else
                'FMsg.Message = "Last rate not available in gi file "
                'FMsg.CssClass = "errormsg"
                'FMsg.Display()
                'Me.txt_variant.Focus()
                'Exit Sub
            End If
            dr.Close()
            obj.closecn()


            ''Last Rate pick from Unplanned ims_receipt_detail file
            If Right(RTrim(Me.txt_itemcode.Text), 1) = "1" Then

                sqlpass = "select top 1 convert(numeric(10,2),a.value/a.confirmed_qty_in_stock_uom), b.receipt_date " & _
                            "from miserp.imsdb.dbo.ims_receipt_account_detail a, miserp.imsdb.dbo.ims_receipt_header b " & _
                            "where a.stock_no ='" & LTrim(RTrim(Me.txt_itemcode.Text)) & "' " & _
                            "and a.variant_no='" & LTrim(RTrim(Me.txt_variant.Text)) & "' " & _
                            "and a.company_no='" & UCase(LTrim(RTrim(Session("companycode")))) & "' " & _
                            "and a.receipt_no = b.receipt_no " & _
                            "order by b.receipt_date desc "

                obj.opencn()
                cmd = New SqlCommand(sqlpass, obj.cn)
                dr = cmd.ExecuteReader

                If dr.HasRows = True Then
                    dr.Read()
                    Me.txt_last_rate.Text = dr.Item(0)
                    'Me.txt_receive_date.Text = CDate(dr.Item(1)).Date

                    dr.Close()
                    obj.closecn()

                    ''Fill latest unplanned receive date
                    sqlpass = "select top 1 b.receipt_date " & _
                        "from miserp.imsdb.dbo.ims_receipt_account_detail a, miserp.imsdb.dbo.ims_receipt_header b " & _
                        "where a.stock_no ='" & LTrim(RTrim(Me.txt_itemcode.Text)) & "' " & _
                        "and a.variant_no='" & LTrim(RTrim(Me.txt_variant.Text)) & "' " & _
                        "and a.company_no='" & UCase(LTrim(RTrim(Session("companycode")))) & "' " & _
                        "and a.receipt_no = b.receipt_no " & _
                        "and b.receipt_date >= case when '" & LTrim(RTrim(Me.txt_tranno.Text)) & "' = '' then getdate() else " & _
                        "(select system_date from jct_ops_raw_material_receipt_header " & _
                        "where tran_no = '" & LTrim(RTrim(Me.txt_tranno.Text)) & "' " & _
                        "and company_code = '" & UCase(LTrim(RTrim(Session("companycode")))) & "') end " & _
                        "order by b.receipt_date "

                    obj.opencn()
                    cmd = New SqlCommand(sqlpass, obj.cn)
                    dr = cmd.ExecuteReader

                    If dr.HasRows = True Then
                        dr.Read()
                        Me.txt_receive_date.Text = CDate(dr.Item(0)).Date
                    Else
                        'FMsg.Message = "Unplanned material still not received "
                        'FMsg.CssClass = "errormsg"
                        'FMsg.Display()
                        'Me.txt_variant.Focus()
                        'Exit Sub
                    End If
                Else
                    'FMsg.Message = "Last rate not available in unplanned receipt file "
                    'FMsg.CssClass = "errormsg"
                    'FMsg.Display()
                    'Me.txt_variant.Focus()
                    'Exit Sub
                End If
                dr.Close()
                obj.closecn()

            End If

            dr.Close()
            obj.closecn()

            Me.txt_lead_time.Text = DateDiff(DateInterval.Day, CDate(Me.txt_receive_date.Text).Date, trandate.Date)

            ''=====================================

        End If ''end of MODIFY/CANCEL/SHORT CLOSE/AUTHORIZE

    End Sub

    Protected Sub ddl_supplier_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl_supplier.TextChanged

        ''Fill Supplier Code in text box
        Me.txt_supplier_code.Text = LTrim(RTrim(Mid(Me.ddl_supplier.Text, InStr(Me.ddl_supplier.Text, "|") + 1, 10)))


        ''====================================
        ''Fill Supplier code in combo box
        If UCase(LTrim(RTrim(Me.ddl_action.Text))) = "ADD" Or UCase(LTrim(RTrim(Me.ddl_action.Text))) = "MODIFY" Then
            Dim i As Integer = 0
            Dim exist As String = "N"

            ''Check Supplier code already exist or not
            For i = 0 To Me.ddl_supplier_code.Items.Count - 1
                If UCase(LTrim(RTrim(Me.ddl_supplier_code.Items(i).Text))) = UCase(LTrim(RTrim(Me.ddl_supplier.Text))) Then
                    exist = "Y"
                    Exit For
                Else
                    exist = "N"
                End If
            Next

            If exist = "N" Then
                Me.ddl_supplier_code.Items.Add(LTrim(RTrim(Me.ddl_supplier.Text)))
                Me.ddl_supplier_code.Text = LTrim(RTrim(Me.ddl_supplier.Text))
                'Me.ddl_supplier_code.SelectedIndex = Me.ddl_supplier_code.Items.IndexOf(LTrim(RTrim(Me.txt_supplier_code.Text)))
                'Me.txt_supplier_code.Text = ""
            Else
                FMsg.Message = "Supplier already selected"
                FMsg.CssClass = "errormsg"
                FMsg.Display()
                Me.ddl_supplier_code.Text = LTrim(RTrim(Me.ddl_supplier.Text))
                'Exit Sub
            End If
        End If
        ''====================================


        ''Fill Supplier address
        sqlpass = "select distinct ltrim(rtrim(isnull(vendor_add1,''))) + ', ' + ltrim(rtrim(isnull(vendor_add2,''))) + ', ' + ltrim(rtrim(isnull(vendor_add3,''))), isnull(city,'') " & _
        "from miserp.common.dbo.pur_company_vendor_master " & _
        "where vendor_code = '" & LTrim(RTrim(Me.txt_supplier_code.Text)) & "' " & _
        "and company_code='" & UCase(LTrim(RTrim(Session("companycode")))) & "' "

        obj.opencn()
        cmd = New SqlCommand(sqlpass, obj.cn)
        cmd.CommandTimeout = 0
        dr = cmd.ExecuteReader

        If dr.HasRows = True Then
            dr.Read()
            Me.lbl_address.Text = dr.Item(0)
            Me.lbl_city.Text = dr.Item(1)
        End If
        dr.Close()
        obj.closecn()


        ''-----Set Pay term according to Supplier in case multiple supplier selected by user
        sqlpass = "select a.pay_term_no, b.pay_term_desc, " & _
                "isnull(convert(varchar(11),b.effective_date,101),''), isnull(convert(varchar(11),b.expiry_date,101),'') " & _
                "from miserp.common.dbo.pur_company_vendor_master a, " & _
                "miserp.common.dbo.pur_payterm_header b " & _
                "where a.vendor_code='" & LTrim(RTrim(Me.txt_supplier_code.Text)) & "' " & _
                "and a.pay_term_no = b.pay_term_no " & _
                "/*and convert(datetime,convert(varchar(11),getdate())) between b.effective_date and b.expiry_date*/ " & _
                "and a.company_code='" & UCase(LTrim(RTrim(Session("companycode")))) & "' " & _
                "and a.company_code = b.company_code "

        obj.opencn()
        cmd = New SqlCommand(sqlpass, obj.cn)
        dr = cmd.ExecuteReader

        If dr.HasRows = True Then
            dr.Read()
            Me.txt_pay_term_code.Text = dr.Item(0)
            Me.txt_pay_term_desc.Text = dr.Item(1)
            Me.txt_efffrom.Text = dr.Item(2)
            Me.txt_effto.Text = dr.Item(3)
        Else
            'FMsg.Message = "Pay term not defined or Pay term expired "
            'FMsg.CssClass = "errormsg"
            'FMsg.Display()
            'Me.txt_itemcode.Focus()
            'Exit Sub
        End If
        dr.Close()
        obj.closecn()


        ''-----Fill Pay Term Desc. text box
        sqlpass = "select a.pay_term_no, a.pay_term_desc, " & _
                "isnull(convert(varchar(11),a.effective_date,101),''), " & _
                "isnull(convert(varchar(11),a.expiry_date,101),'') " & _
                "from jct_ops_pay_term_header a " & _
                "where a.pay_term_no='" & LTrim(RTrim(Me.txt_pay_term_code.Text)) & "' " & _
                "and convert(datetime,convert(varchar(11),getdate())) between a.effective_date and a.expiry_date " & _
                "and a.company_code='" & UCase(LTrim(RTrim(Session("companycode")))) & "' "

        obj.opencn()
        cmd = New SqlCommand(sqlpass, obj.cn)
        dr = cmd.ExecuteReader

        If dr.HasRows = True Then
            dr.Read()
            'Me.txt_pay_term_code.Text = dr.Item(0)
            Me.txt_pay_term_desc.Text = dr.Item(1)
            Me.txt_efffrom.Text = dr.Item(2)
            Me.txt_effto.Text = dr.Item(3)
        Else
            dr.Close()
            obj.closecn()

            ''-----Fill Pay Term Desc. text box
            sqlpass = "select a.pay_term_no, b.pay_term_desc, " & _
                    "isnull(convert(varchar(11),b.effective_date,101),''), isnull(convert(varchar(11),b.expiry_date,101),'') " & _
                    "from miserp.common.dbo.pur_company_vendor_master a, " & _
                    "miserp.common.dbo.pur_payterm_header b " & _
                    "where a.vendor_code='" & LTrim(RTrim(Me.txt_supplier_code.Text)) & "' " & _
                    "and ltrim(rtrim(isnull(a.pay_term_no,''))) <> '' " & _
                    "and a.pay_term_no = b.pay_term_no " & _
                    "/*and convert(datetime,convert(varchar(11),getdate())) between b.effective_date and b.expiry_date*/ " & _
                    "and a.company_code='" & UCase(LTrim(RTrim(Session("companycode")))) & "' " & _
                    "and a.company_code = b.company_code "

            obj.opencn()
            cmd = New SqlCommand(sqlpass, obj.cn)
            dr = cmd.ExecuteReader

            If dr.HasRows = True Then
                dr.Read()
                Me.txt_pay_term_code.Text = dr.Item(0)
                Me.txt_pay_term_desc.Text = dr.Item(1)
                Me.txt_efffrom.Text = dr.Item(2)
                Me.txt_effto.Text = dr.Item(3)
            Else
                FMsg.Message = "Pay term not defined or Pay term expired "
                FMsg.CssClass = "errormsg"
                FMsg.Display()
                Me.txt_itemcode.Focus()
                dr.Close()
                obj.closecn()
                Exit Sub
            End If

        End If
        dr.Close()
        obj.closecn()

        Me.txt_itemcode.Focus()

    End Sub

    Protected Sub txt_itemcode_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_itemcode.TextChanged

        ''-----Fill Item Desc. text box
        sqlpass = "select description from miserp.common.dbo.ims_stock_master " & _
                "where stock_no ='" & LTrim(RTrim(Me.txt_itemcode.Text)) & "' " & _
                "and stock_type='0' " & _
                "and company_no='" & UCase(LTrim(RTrim(Session("companycode")))) & "' "

        obj.opencn()
        cmd = New SqlCommand(sqlpass, obj.cn)
        dr = cmd.ExecuteReader

        If dr.HasRows = True Then
            dr.Read()
            Me.txt_item_desc.Text = dr.Item(0)
            Me.txt_variant.Focus()
        Else
            FMsg.Message = "Invalid Item Code "
            FMsg.CssClass = "errormsg"
            FMsg.Display()
            Me.txt_itemcode.Focus()
            Exit Sub
        End If
        dr.Close()
        obj.closecn()

    End Sub

    Protected Sub txt_variant_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_variant.TextChanged

        ''-----Fill Item Desc. text box
        sqlpass = "select short_description from miserp.common.dbo.ims_variant_master " & _
                "where stock_no ='" & LTrim(RTrim(Me.txt_itemcode.Text)) & "' " & _
                "and variant_no='" & LTrim(RTrim(Me.txt_variant.Text)) & "' " & _
                "and company_no='" & UCase(LTrim(RTrim(Session("companycode")))) & "' "

        obj.opencn()
        cmd = New SqlCommand(sqlpass, obj.cn)
        dr = cmd.ExecuteReader

        If dr.HasRows = True Then
            dr.Read()
            Me.txt_variant_desc.Text = dr.Item(0)
        Else
            FMsg.Message = "Invalid Item Code/Variant "
            FMsg.CssClass = "errormsg"
            FMsg.Display()
            Me.txt_itemcode.Focus()
            Exit Sub
        End If
        dr.Close()
        obj.closecn()


        ''-----Fill Last Rate text box
        ''Last Rate pick from Purchase Order file
        'sqlpass = "select top 1 convert(numeric(10,2),a.rate/a.rate_per) " & _
        '            "from miserp.pomdb.dbo.pur_po_detail a, miserp.pomdb.dbo.pur_po_header b " & _
        '            "where a.stock_no ='" & LTrim(RTrim(Me.txt_itemcode.Text)) & "' " & _
        '            "and a.stock_variant='" & LTrim(RTrim(Me.txt_variant.Text)) & "' " & _
        '            "and a.company_code='" & UCase(LTrim(RTrim(Session("companycode")))) & "' " & _
        '            "and a.po_no = b.po_no " & _
        '            "order by b.po_date desc "

        ''Rate pick from order based pur_gi_detail file
        sqlpass = "select top 1 convert(numeric(10,2),a.rate/a.rate_per), b.gi_date " & _
                    "from miserp.pomdb.dbo.pur_gi_detail a, miserp.pomdb.dbo.pur_gi_header b " & _
                    "where a.stock_no ='" & LTrim(RTrim(Me.txt_itemcode.Text)) & "' " & _
                    "and a.stock_variant='" & LTrim(RTrim(Me.txt_variant.Text)) & "' " & _
                    "and a.company_code='" & UCase(LTrim(RTrim(Session("companycode")))) & "' " & _
                    "and a.gi_no = b.gi_no " & _
                    "order by b.gi_date desc "

        obj.opencn()
        cmd = New SqlCommand(sqlpass, obj.cn)
        dr = cmd.ExecuteReader

        If dr.HasRows = True Then
            dr.Read()
            Me.txt_last_rate.Text = dr.Item(0)
            'Me.txt_receive_date.Text = CDate(dr.Item(1)).Date

            dr.Close()
            obj.closecn()

            ''Fill latest unplanned receive date
            sqlpass = "select top 1 b.gi_date " & _
                "from miserp.pomdb.dbo.pur_gi_detail a, miserp.pomdb.dbo.pur_gi_header b " & _
                "where a.stock_no = '" & LTrim(RTrim(Me.txt_itemcode.Text)) & "' " & _
                "and a.stock_variant = '" & LTrim(RTrim(Me.txt_variant.Text)) & "' " & _
                "and a.company_code = '" & UCase(LTrim(RTrim(Session("companycode")))) & "' " & _
                "and a.gi_no = b.gi_no " & _
                "and b.gi_date >= case when '" & LTrim(RTrim(Me.txt_tranno.Text)) & "' = '' then getdate() else " & _
                "(select system_date from jct_ops_raw_material_receipt_header " & _
                "where tran_no = '" & LTrim(RTrim(Me.txt_tranno.Text)) & "' " & _
                "and company_code = '" & UCase(LTrim(RTrim(Session("companycode")))) & "') end " & _
                "order by b.gi_date "

            obj.opencn()
            cmd = New SqlCommand(sqlpass, obj.cn)
            dr = cmd.ExecuteReader

            If dr.HasRows = True Then
                dr.Read()
                Me.txt_receive_date.Text = CDate(dr.Item(0)).Date
            Else
                'FMsg.Message = "Order based material still not received "
                'FMsg.CssClass = "errormsg"
                'FMsg.Display()
                'Me.txt_variant.Focus()
                'Exit Sub
            End If
        Else
            FMsg.Message = "Last rate not available in gi file "
            FMsg.CssClass = "errormsg"
            FMsg.Display()
            Me.txt_variant.Focus()
            Exit Sub
        End If
        dr.Close()
        obj.closecn()


        ''Last Rate pick from Unplanned ims_receipt_detail file
        If Right(RTrim(Me.txt_itemcode.Text), 1) = "1" Then

            sqlpass = "select top 1 convert(numeric(10,2),a.value/a.confirmed_qty_in_stock_uom), b.receipt_date " & _
                        "from miserp.imsdb.dbo.ims_receipt_account_detail a, miserp.imsdb.dbo.ims_receipt_header b " & _
                        "where a.stock_no ='" & LTrim(RTrim(Me.txt_itemcode.Text)) & "' " & _
                        "and a.variant_no='" & LTrim(RTrim(Me.txt_variant.Text)) & "' " & _
                        "and a.company_no='" & UCase(LTrim(RTrim(Session("companycode")))) & "' " & _
                        "and a.receipt_no = b.receipt_no " & _
                        "order by b.receipt_date desc "

            obj.opencn()
            cmd = New SqlCommand(sqlpass, obj.cn)
            dr = cmd.ExecuteReader

            If dr.HasRows = True Then
                dr.Read()
                Me.txt_last_rate.Text = dr.Item(0)
                'Me.txt_receive_date.Text = CDate(dr.Item(1)).Date

                dr.Close()
                obj.closecn()

                ''Fill latest unplanned receive date
                sqlpass = "select top 1 b.receipt_date " & _
                    "from miserp.imsdb.dbo.ims_receipt_account_detail a, miserp.imsdb.dbo.ims_receipt_header b " & _
                    "where a.stock_no ='" & LTrim(RTrim(Me.txt_itemcode.Text)) & "' " & _
                    "and a.variant_no='" & LTrim(RTrim(Me.txt_variant.Text)) & "' " & _
                    "and a.company_no='" & UCase(LTrim(RTrim(Session("companycode")))) & "' " & _
                    "and a.receipt_no = b.receipt_no " & _
                    "and b.receipt_date >= case when '" & LTrim(RTrim(Me.txt_tranno.Text)) & "' = '' then getdate() else " & _
                    "(select system_date from jct_ops_raw_material_receipt_header " & _
                    "where tran_no = '" & LTrim(RTrim(Me.txt_tranno.Text)) & "' " & _
                    "and company_code = '" & UCase(LTrim(RTrim(Session("companycode")))) & "') end " & _
                    "order by b.receipt_date "

                obj.opencn()
                cmd = New SqlCommand(sqlpass, obj.cn)
                dr = cmd.ExecuteReader

                If dr.HasRows = True Then
                    dr.Read()
                    Me.txt_receive_date.Text = CDate(dr.Item(0)).Date
                Else
                    'FMsg.Message = "Unplanned material still not received "
                    'FMsg.CssClass = "errormsg"
                    'FMsg.Display()
                    'Me.txt_variant.Focus()
                    'Exit Sub
                End If
            Else
                FMsg.Message = "Last rate not available in unplanned receipt file "
                FMsg.CssClass = "errormsg"
                FMsg.Display()
                Me.txt_variant.Focus()
                Exit Sub
            End If
            dr.Close()
            obj.closecn()

        End If


        dr.Close()
        obj.closecn()

    End Sub

    Protected Sub ddl_itemgroup_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl_itemgroup.TextChanged

        Me.txt_groupcode.Text = LTrim(RTrim(Mid(Me.ddl_itemgroup.Text, InStr(Me.ddl_itemgroup.Text, "|") + 1, 20)))

    End Sub

    Protected Sub txt_lead_time_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_lead_time.TextChanged

        Me.txt_procurement_date.Text = DateAdd(DateInterval.Day, -Val(Me.txt_lead_time.Text), CDate(Me.txt_receive_date.Text))

    End Sub

    Protected Sub txt_receive_date_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_receive_date.TextChanged

        Me.txt_procurement_date.Text = DateAdd(DateInterval.Day, -Val(Me.txt_lead_time.Text), CDate(Me.txt_receive_date.Text))

    End Sub

    Protected Sub imb_get_new_payterm_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imb_get_new_payterm.Click

        If Me.ddl_action.Text = "ADD" Or Me.ddl_action.Text = "MODIFY" Then

            Me.txt_pay_term_code.Enabled = True
            Me.txt_pay_term_desc.Enabled = True
            Me.txt_efffrom.Enabled = True
            Me.txt_effto.Enabled = True
            'Me.imb_set_new_payterm.Enabled = True
            'Me.imb_set_new_payterm.Visible = True

        End If

    End Sub

    Protected Sub imb_set_new_pay_term_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imb_set_new_payterm.Click

        If Me.ddl_action.Text = "ADD" Or Me.ddl_action.Text = "MODIFY" Then

            If LTrim(RTrim(Me.ddl_plant.Text)) = "" Then
                FMsg.Message = "Pl. select Plant "
                FMsg.CssClass = "errormsg"
                FMsg.Display()
                Me.ddl_plant.Focus()
                Exit Sub
            End If

            If LTrim(RTrim(Me.ddl_supplier.Text)) = "" Then
                FMsg.Message = "Pl. select Supplier "
                FMsg.CssClass = "errormsg"
                FMsg.Display()
                Me.ddl_supplier.Focus()
                Exit Sub
            End If

            If LTrim(RTrim(Me.txt_supplier_code.Text)) = "" Then
                FMsg.Message = "Pl. select Supplier Code "
                FMsg.CssClass = "errormsg"
                FMsg.Display()
                Me.txt_supplier_code.Focus()
                Exit Sub
            End If

            If LTrim(RTrim(Me.txt_pay_term_code.Text)) = "" Then
                FMsg.Message = "Pl. enter pay term code "
                FMsg.CssClass = "errormsg"
                FMsg.Display()
                Me.txt_pay_term_code.Focus()
                Exit Sub
            End If

            If LTrim(RTrim(Me.txt_pay_term_desc.Text)) = "" Then
                FMsg.Message = "Pl. enter pay term description "
                FMsg.CssClass = "errormsg"
                FMsg.Display()
                Me.txt_pay_term_desc.Focus()
                Exit Sub
            End If

            If LTrim(RTrim(Me.txt_efffrom.Text)) = "" Then
                FMsg.Message = "Pl. enter from date "
                FMsg.CssClass = "errormsg"
                FMsg.Display()
                Me.txt_efffrom.Focus()
                Exit Sub
            End If

            If LTrim(RTrim(Me.txt_effto.Text)) = "" Then
                FMsg.Message = "Pl. enter from to "
                FMsg.CssClass = "errormsg"
                FMsg.Display()
                Me.txt_effto.Focus()
                Exit Sub
            End If

            Dim same As String = "N"
            Dim greater As String = "N"

            Dim efrom As Date
            Dim eto As Date
            Dim recvdt As Date
            Dim procdt As Date

            sqlpass = "select convert(datetime,'" & Me.txt_efffrom.Text & "'), " & _
                        "convert(datetime,'" & Me.txt_effto.Text & "'), " & _
                        "convert(datetime,'" & Me.txt_receive_date.Text & "'), " & _
                        "convert(datetime,'" & Me.txt_procurement_date.Text & "') "

            obj.opencn()
            cmd = New SqlCommand(sqlpass, obj.cn)
            cmd.CommandTimeout = 0
            dr = cmd.ExecuteReader

            If dr.HasRows = True Then
                dr.Read()
                efrom = CDate(dr.Item(0)).Date
                eto = CDate(dr.Item(1)).Date
                recvdt = CDate(dr.Item(2)).Date
                procdt = CDate(dr.Item(3)).Date
            Else
                FMsg.Message = "Error during date fields value stored in variables "
                FMsg.CssClass = "errormsg"
                FMsg.Display()
                Me.txt_efffrom.Focus()
                dr.Close()
                obj.closecn()
                Exit Sub
            End If

            dr.Close()
            obj.closecn()

            If efrom > eto Then
                FMsg.Message = "Eff.To date should be greater than or equal to Eff.From date"
                FMsg.CssClass = "errormsg"
                FMsg.Display()
                Me.txt_efffrom.Focus()
                Exit Sub
            End If


            Dim btran As SqlTransaction

            obj.opencn()
            btran = obj.cn.BeginTransaction

            Try
                sqlpass = "select top 1 convert(datetime,convert(char(11),eff_from)), " & _
                        "convert(datetime,convert(char(11),eff_to)), tran_no " & _
                        "from jct_ops_raw_material_receipt_header " & _
                        "where pay_term_code='" & LTrim(RTrim(Me.txt_pay_term_code.Text)) & "' " & _
                        "and ltrim(rtrim(company_code))='" & UCase(LTrim(RTrim(Session("companycode")))) & "' " & _
                        "order by eff_to desc"

                cmd = New SqlCommand(sqlpass, obj.cn)
                cmd.CommandTimeout = 0
                cmd.Transaction = btran
                dr = cmd.ExecuteReader

                If dr.HasRows = True Then

                    dr.Read()
                    If efrom >= CDate(dr.Item(0)).Date And eto <= CDate(dr.Item(1)).Date Then
                        FMsg.Message = "Date Period already exists"
                        FMsg.CssClass = "errormsg"
                        FMsg.Display()
                        dr.Close()
                        obj.closecn()
                        Exit Sub
                    End If

                    If efrom <= CDate(dr.Item(0)).Date Or eto <= CDate(dr.Item(1)).Date Then
                        FMsg.Message = "Back date Pay Term period are not allowed or Eff.From date already exists"
                        FMsg.CssClass = "errormsg"
                        FMsg.Display()
                        dr.Close()
                        obj.closecn()
                        Exit Sub
                    End If

                    If CDate(dr.Item(0)).Date = CDate(dr.Item(1)).Date Then
                        same = "Y"
                    Else
                        same = "N"
                    End If

                    If efrom > CDate(dr.Item(1)).Date Then
                        greater = "Y"
                    Else
                        greater = "N"
                    End If


                    dr.Close()


                    If greater = "N" Then

                        If same = "Y" Then

                            FMsg.Message = "Eff.From already exists for one day"
                            FMsg.CssClass = "errormsg"
                            FMsg.Display()
                            dr.Close()
                            obj.closecn()
                            Exit Sub

                        Else

                            sqlpass = "update jct_ops_raw_material_receipt_header set eff_to=convert(datetime,'" & efrom & "')-1 " & _
                                    "where tran_no='" & LTrim(RTrim(dr.Item(2))) & "' " & _
                                    "and pay_term_code='" & LTrim(RTrim(Me.txt_pay_term_code.Text)) & "' " & _
                                    "and company_code='" & UCase(LTrim(RTrim(Session("companycode")))) & "' "

                            cmd = New SqlCommand(sqlpass, obj.cn)
                            cmd.CommandTimeout = 0
                            cmd.Transaction = btran
                            cmd.ExecuteNonQuery()


                            sqlpass = "update jct_ops_pay_term_header set expiry_date=convert(datetime,'" & efrom & "')-1 " & _
                                    "where pay_term_code='" & LTrim(RTrim(Me.txt_pay_term_code.Text)) & "' " & _
                                    "and company_code='" & UCase(LTrim(RTrim(Session("companycode")))) & "' "

                            dr.Close()

                            cmd = New SqlCommand(sqlpass, obj.cn)
                            cmd.CommandTimeout = 0
                            cmd.Transaction = btran
                            cmd.ExecuteNonQuery()

                        End If  '' end of If same = "Y"

                    End If  '' end of If greater = "N"

                Else

                    dr.Close()

                End If  '' end of If dr.HasRows = True Then

                sqlpass = "insert into jct_ops_pay_term_header " & _
                        "(pay_term_no,pay_term_desc," & _
                        "effective_date,expiry_date,status,userid,hostname,company_code,system_date) " & _
                        "select '" & Me.txt_pay_term_code.Text & "','" & _
                        Me.txt_pay_term_desc.Text & "','" & _
                        Me.txt_efffrom.Text & "','" & _
                        Me.txt_effto.Text & "','O','" & _
                        UCase(LTrim(RTrim(Session("empcode")))) & "',host_name(),'" & _
                        UCase(LTrim(RTrim(Session("companycode")))) & "',getdate() "

                cmd = New SqlCommand(sqlpass, obj.cn)
                cmd.CommandTimeout = 0
                cmd.Transaction = btran
                cmd.ExecuteNonQuery()

                'dr.Close()

                btran.Commit()
                dr.Close()
                obj.closecn()
                ''''''''''Meaasage'''''''''''''
                FMsg.Message = "Pay Term Successfully Created/Changed"
                FMsg.CssClass = "addmsg"
                FMsg.Display()
                '''''''''''''''''''''''''''''''

                Me.txt_pay_term_code.Enabled = False
                Me.txt_pay_term_desc.Enabled = False
                Me.txt_efffrom.Enabled = False
                Me.txt_effto.Enabled = False
                'Me.imb_set_new_payterm.Enabled = False
                'Me.imb_set_new_payterm.Visible = False

            Catch ex As Exception

                btran.Rollback()
                dr.Close()
                obj.closecn()
                FMsg.Message = (ex.Message)
                FMsg.CssClass = "addmsg"
                FMsg.Display()
                'Me.lbt_close_Click(sender, e)       ''  Execute EXIT button script
                Exit Sub

            End Try

        End If

    End Sub

    Protected Sub lbt_close_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbt_close.Click

        Me.Dispose()
        Response.Redirect("default.aspx")

    End Sub

    Protected Sub txt_pay_term_code_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_pay_term_code.TextChanged

        If LTrim(RTrim(Me.txt_pay_term_code.Text)) = "" Then
            FMsg.Message = "Pl. enter payment term code "
            FMsg.CssClass = "errormsg"
            FMsg.Display()
            Me.txt_pay_term_code.Focus()
            Exit Sub
        End If


        ''-----Fill Item Desc. text box
        sqlpass = "select a.pay_term_no, a.pay_term_desc, " & _
                "isnull(convert(varchar(11),a.effective_date,101),''), " & _
                "isnull(convert(varchar(11),a.expiry_date,101),'') " & _
                "from jct_ops_pay_term_header a " & _
                "where a.pay_term_no='" & LTrim(RTrim(Me.txt_pay_term_code.Text)) & "' " & _
                "and convert(datetime,convert(varchar(11),getdate())) between a.effective_date and a.expiry_date " & _
                "and a.company_code='" & UCase(LTrim(RTrim(Session("companycode")))) & "' "

        obj.opencn()
        cmd = New SqlCommand(sqlpass, obj.cn)
        dr = cmd.ExecuteReader

        If dr.HasRows = True Then
            dr.Read()
            'Me.txt_pay_term_code.Text = dr.Item(0)
            Me.txt_pay_term_desc.Text = dr.Item(1)
            Me.txt_efffrom.Text = dr.Item(2)
            Me.txt_effto.Text = dr.Item(3)
        Else
            'FMsg.Message = "Pay term not defined or Pay term expired "
            'FMsg.CssClass = "errormsg"
            'FMsg.Display()
            Me.txt_efffrom.Text = ""
            Me.txt_effto.Text = ""
            Me.txt_pay_term_desc.Text = ""
            Me.txt_pay_term_code.Focus()
            Exit Sub
        End If
        dr.Close()
        obj.closecn()

    End Sub

    Protected Sub txt_rate_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_rate.TextChanged

        Me.txt_value.Text = Val(Me.txt_qty.Text) * Val(Me.txt_rate.Text)

    End Sub

    Protected Sub txt_required_date_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_required_date.TextChanged

        If UCase(LTrim(RTrim(Me.ddl_action.Text))) = "ADD" Or UCase(LTrim(RTrim(Me.ddl_action.Text))) = "MODIFY" Then

            Me.txt_receive_date.Text = Now().Date

        End If

    End Sub

    Protected Sub imb_remove_supplier_code_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imb_remove_supplier_code.Click

        'Dim i As Integer

        'For i = Me.chk_selected_process.Items.Count - 1 To 0 Step -1
        '    If Me.chk_selected_process.Items(i).Selected = True Then
        '        Me.chk_selected_process.Items.RemoveAt(i)
        '    End If
        'Next

        Me.ddl_supplier_code.Items.Remove(Me.ddl_supplier_code.Text)

        ''Reset Supplier & Supplier code according to multiple suppliers selected in combo box
        Me.ddl_supplier.Text = LTrim(RTrim(Me.ddl_supplier_code.Text))
        Me.txt_supplier_code.Text = LTrim(RTrim(Mid(Me.ddl_supplier.Text, InStr(Me.ddl_supplier.Text, "|") + 1, 10)))

    End Sub

    Protected Sub ddl_supplier_code_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl_supplier_code.TextChanged

        ''Reset Supplier & Supplier code according to multiple suppliers selected in combo box
        Me.ddl_supplier.Text = LTrim(RTrim(Me.ddl_supplier_code.Text))
        Me.txt_supplier_code.Text = LTrim(RTrim(Mid(Me.ddl_supplier.Text, InStr(Me.ddl_supplier.Text, "|") + 1, 10)))


        ''Fill Supplier address
        sqlpass = "select distinct ltrim(rtrim(isnull(vendor_add1,''))) + ', ' + ltrim(rtrim(isnull(vendor_add2,''))) + ', ' + ltrim(rtrim(isnull(vendor_add3,''))), isnull(city,'') " & _
        "from miserp.common.dbo.pur_company_vendor_master " & _
        "where vendor_code = '" & LTrim(RTrim(Me.txt_supplier_code.Text)) & "' " & _
        "and company_code='" & UCase(LTrim(RTrim(Session("companycode")))) & "' "

        obj.opencn()
        cmd = New SqlCommand(sqlpass, obj.cn)
        cmd.CommandTimeout = 0
        dr = cmd.ExecuteReader

        If dr.HasRows = True Then
            dr.Read()
            Me.lbl_address.Text = dr.Item(0)
            Me.lbl_city.Text = dr.Item(1)
        End If
        dr.Close()
        obj.closecn()

        ''-----Set Pay term according to Supplier in case multiple supplier selected by user
        sqlpass = "select a.pay_term_no, b.pay_term_desc, " & _
                "isnull(convert(varchar(11),b.effective_date,101),''), isnull(convert(varchar(11),b.expiry_date,101),'') " & _
                "from miserp.common.dbo.pur_company_vendor_master a, " & _
                "miserp.common.dbo.pur_payterm_header b " & _
                "where a.vendor_code='" & LTrim(RTrim(Me.txt_supplier_code.Text)) & "' " & _
                "and a.pay_term_no = b.pay_term_no " & _
                "/*and convert(datetime,convert(varchar(11),getdate())) between b.effective_date and b.expiry_date*/ " & _
                "and a.company_code='" & UCase(LTrim(RTrim(Session("companycode")))) & "' " & _
                "and a.company_code = b.company_code "

        obj.opencn()
        cmd = New SqlCommand(sqlpass, obj.cn)
        dr = cmd.ExecuteReader

        If dr.HasRows = True Then
            dr.Read()
            Me.txt_pay_term_code.Text = dr.Item(0)
            Me.txt_pay_term_desc.Text = dr.Item(1)
            Me.txt_efffrom.Text = dr.Item(2)
            Me.txt_effto.Text = dr.Item(3)
        Else
            'FMsg.Message = "Pay term not defined or Pay term expired "
            'FMsg.CssClass = "errormsg"
            'FMsg.Display()
            'Me.txt_itemcode.Focus()
            'Exit Sub
        End If
        dr.Close()
        obj.closecn()


        ''-----Fill Pay Term Desc. text box
        sqlpass = "select a.pay_term_no, a.pay_term_desc, " & _
                "isnull(convert(varchar(11),a.effective_date,101),''), " & _
                "isnull(convert(varchar(11),a.expiry_date,101),'') " & _
                "from jct_ops_pay_term_header a " & _
                "where a.pay_term_no='" & LTrim(RTrim(Me.txt_pay_term_code.Text)) & "' " & _
                "and convert(datetime,convert(varchar(11),getdate())) between a.effective_date and a.expiry_date " & _
                "and a.company_code='" & UCase(LTrim(RTrim(Session("companycode")))) & "' "

        obj.opencn()
        cmd = New SqlCommand(sqlpass, obj.cn)
        dr = cmd.ExecuteReader

        If dr.HasRows = True Then
            dr.Read()
            'Me.txt_pay_term_code.Text = dr.Item(0)
            Me.txt_pay_term_desc.Text = dr.Item(1)
            Me.txt_efffrom.Text = dr.Item(2)
            Me.txt_effto.Text = dr.Item(3)
        Else
            dr.Close()
            obj.closecn()

            ''-----Fill Pay Term Desc. text box
            sqlpass = "select a.pay_term_no, b.pay_term_desc, " & _
                    "isnull(convert(varchar(11),b.effective_date,101),''), isnull(convert(varchar(11),b.expiry_date,101),'') " & _
                    "from miserp.common.dbo.pur_company_vendor_master a, " & _
                    "miserp.common.dbo.pur_payterm_header b " & _
                    "where a.vendor_code='" & LTrim(RTrim(Me.txt_supplier_code.Text)) & "' " & _
                    "and ltrim(rtrim(isnull(a.pay_term_no,''))) <> '' " & _
                    "and a.pay_term_no = b.pay_term_no " & _
                    "/*and convert(datetime,convert(varchar(11),getdate())) between b.effective_date and b.expiry_date*/ " & _
                    "and a.company_code='" & UCase(LTrim(RTrim(Session("companycode")))) & "' " & _
                    "and a.company_code = b.company_code "

            obj.opencn()
            cmd = New SqlCommand(sqlpass, obj.cn)
            dr = cmd.ExecuteReader

            If dr.HasRows = True Then
                dr.Read()
                Me.txt_pay_term_code.Text = dr.Item(0)
                Me.txt_pay_term_desc.Text = dr.Item(1)
                Me.txt_efffrom.Text = dr.Item(2)
                Me.txt_effto.Text = dr.Item(3)
            Else
                FMsg.Message = "Pay term not defined or Pay term expired "
                FMsg.CssClass = "errormsg"
                FMsg.Display()
                Me.txt_itemcode.Focus()
                dr.Close()
                obj.closecn()
                Exit Sub
            End If

        End If
        dr.Close()
        obj.closecn()

    End Sub

End Class
