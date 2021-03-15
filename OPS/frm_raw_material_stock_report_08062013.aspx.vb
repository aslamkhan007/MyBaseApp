Imports System.Data.SqlClient
Imports System.Data
Imports System.Web.HttpResponse
Imports vb = Microsoft.VisualBasic
Imports System.String
Imports System.Math
Partial Class OPS_frm_raw_material_stock_report
    Inherits System.Web.UI.Page
    Dim sql As String
    Dim dr As SqlDataReader
    Dim cmd As SqlCommand
    Dim sqlpass As String
    Public obj As New HelpDeskClass
    Dim dt As New Data.DataTable

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



            ''-----Fill Action Combo Box
            'sqlpass = "/*select b.action,b.mnuname,b.description,b.parent_menu,b.seq " & _
            '    " from production..user_module_menus_mapping a inner join production..modules_menu_master b " & _
            '    " on a.module=b.module and a.mnuname=b.mnuname and a.action=b.action " & _
            '    " where a.module ='OPS' and a.uname='" & Session("empcode") & "' and a.mnuname='Raw Material Budget'" & _
            '    " union*/ select b.action,b.mnuname,b.description,parent_menu,case b.action when 'ADD' then '1' when 'VIEW' then '2' when 'MODIFY' then '3' when 'CANCEL' then '4' when 'SHORT CLOSE' then '5' when 'AUTHORIZE' then '6' end /*b.seq*/ " & _
            '    " from production..role_module_menus_mapping a inner join production..modules_menu_master b " & _
            '    " on a.module=b.module and a.mnuname=b.mnuname and a.action=b.action " & _
            '    " inner join production..role_user_mapping e on a.role=e.role " & _
            '    " where a.module ='OPS' and e.uname='" & Session("empcode") & "' " & _
            '    "and a.mnuname='Raw Material Budget' and a.action<>'Load'" & _
            '    " order by b.parent_menu,b.mnuname,case b.action when 'ADD' then '1' when 'VIEW' then '2' when 'MODIFY' then '3' when 'CANCEL' then '4' when 'SHORT CLOSE' then '5' when 'AUTHORIZE' then '6' end /*b.seq*/ "


            'obj.opencn()
            'cmd = New SqlCommand(sqlpass, obj.cn)
            'dr = cmd.ExecuteReader

            'If dr.HasRows = True Then
            '    While dr.Read
            '        'Me.ddl_action.Items.Add(dr.Item(0))
            '    End While
            '    Me.ddl_action.SelectedIndex = 0
            'End If
            'dr.Close()
            'obj.closecn()

            Me.ddl_action.Items.Add("VIEW")


            ''-----Fill Action Combo Box
            sqlpass = "select ltrim(rtrim(description)) + '|' + ltrim(rtrim(wh_no)) " & _
                        "from miserp.common.dbo.ims_warehouse_master " & _
                        "where wh_no = 'GT' " & _
                        "and disabled = '0' " & _
                        "and company_no = '" & UCase(LTrim(RTrim(Session("companycode")))) & "' "

            obj.opencn()
            cmd = New SqlCommand(sqlpass, obj.cn)
            dr = cmd.ExecuteReader

            If dr.HasRows = True Then
                While dr.Read
                    Me.ddl_warehouse.Items.Add(dr.Item(0))
                End While
                Me.ddl_action.SelectedIndex = 0
            End If
            dr.Close()
            obj.closecn()


            'e.lbt_view_Click(sender, e)  '' set view mode at page loading time


        End If  '' end of If Not IsPostBack 

        'If Not IsPostBack Then
        '    grdbnd()
        'End If

    End Sub

    Protected Sub imb_close_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imb_close.Click

        Me.Dispose()
        Response.Redirect("default.aspx")

    End Sub

    Protected Sub imb_fetch_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imb_fetch.Click

        If Me.chk_agewise.Checked = True Or Me.chk_lotwise.Checked = True Then

            ''----Prepare data through sql procedure
            sqlpass = "exec jct_ops_ims_age_wise_stock '" & _
                        UCase(LTrim(RTrim(Me.ddl_action.Text))) & "','" & _
                        Mid(LTrim(RTrim(Me.ddl_warehouse.Text)), InStr(LTrim(RTrim(Me.ddl_warehouse.Text)), "|") + 1, 10) & "','" & _
                        UCase(LTrim(RTrim(Session("empcode")))) & "','" & _
                        UCase(LTrim(RTrim(Session("companycode")))) & "' "

            obj.opencn()
            cmd = New SqlCommand(sqlpass, obj.cn)
            cmd.CommandTimeout = 0
            cmd.ExecuteNonQuery()

            obj.closecn()


            ''----Fill data in GridView1
            '' Age wise
            If Me.chk_agewise.Checked = True And Me.chk_lotwise.Checked <> True Then

                sqlpass = "select a.wh_no as [WAREHOUSE], a.stock_no as [ITEM CODE], " & _
                            "a.variant_no as [VARIANT], a.description as [DESC.], " & _
                            "a.short_description as [SHORT DESC.], a.purchase_uom as [UOM], " & _
                            "convert(numeric(14,3),sum(a.qty_old_upto_30_days)) as [0 - 30], " & _
                            "convert(numeric(14,3),sum(a.qty_old_upto_60_days)) as [31 - 60], " & _
                            "convert(numeric(14,3),sum(a.qty_old_upto_90_days)) as [61 - 90], " & _
                            "convert(numeric(14,3),sum(a.qty_old_upto_180_days)) as [91 - 180], " & _
                            "convert(numeric(14,3),sum(a.qty_old_upto_365_days)) as [181 - 365]," & _
                            "convert(numeric(14,3),sum(a.qty_old_above_365_days)) as [>365] " & _
                            "from jct_ops_ims_agewise_stock a " & _
                            "where a.userid ='" & UCase(LTrim(RTrim(Session("empcode")))) & "' " & _
                            "and a.company_code ='" & UCase(LTrim(RTrim(Session("companycode")))) & "' " & _
                            "group by a.wh_no, a.stock_no, a.variant_no, a.description, a.short_description, a.purchase_uom " & _
                            "order by a.wh_no, a.stock_no, a.variant_no, a.description, a.short_description, a.purchase_uom "
            End If

            ''Age + Lot wise
            If Me.chk_agewise.Checked = True And Me.chk_lotwise.Checked = True Then

                sqlpass = "select a.wh_no as [WAREHOUSE], a.stock_no as [ITEM CODE], " & _
                            "a.variant_no as [VARIANT], a.description as [DESC.], " & _
                            "a.short_description as [SHORT DESC.], a.purchase_uom as [UOM], " & _
                            "convert(numeric(14,3),sum(a.qty_old_upto_30_days)) as [0 - 30], " & _
                            "convert(numeric(14,3),sum(a.qty_old_upto_60_days)) as [31 - 60], " & _
                            "convert(numeric(14,3),sum(a.qty_old_upto_90_days)) as [61 - 90], " & _
                            "convert(numeric(14,3),sum(a.qty_old_upto_180_days)) as [91 - 180], " & _
                            "convert(numeric(14,3),sum(a.qty_old_upto_365_days)) as [181 - 365]," & _
                            "convert(numeric(14,3),sum(a.qty_old_above_365_days)) as [>365], " & _
                            "a.remarks as [SUPPLIER LOT NO.] " & _
                            "from jct_ops_ims_agewise_stock a " & _
                            "where a.userid ='" & UCase(LTrim(RTrim(Session("empcode")))) & "' " & _
                            "and a.company_code ='" & UCase(LTrim(RTrim(Session("companycode")))) & "' " & _
                            "group by a.wh_no, a.stock_no, a.variant_no, a.description, a.short_description, a.purchase_uom, a.remarks " & _
                            "order by a.wh_no, a.stock_no, a.variant_no, a.description, a.short_description, a.purchase_uom, a.remarks "
            End If

            ''
            If Me.chk_agewise.Checked <> True And Me.chk_lotwise.Checked = True Then

                sqlpass = "select a.wh_no as [WAREHOUSE], a.stock_no as [ITEM CODE], " & _
                            "a.variant_no as [VARIANT], a.description as [DESC.], " & _
                            "a.short_description as [SHORT DESC.], a.purchase_uom as [UOM], " & _
                            "convert(numeric(14,3),sum(a.qty_old_upto_30_days + " & _
                            "a.qty_old_upto_60_days + a.qty_old_upto_90_days + " & _
                            "a.qty_old_upto_180_days + a.qty_old_upto_365_days + " & _
                            "a.qty_old_above_365_days)) as [Qty.], " & _
                            "a.remarks as [SUPPLIER LOT NO.] " & _
                            "from jct_ops_ims_agewise_stock a " & _
                            "where a.userid ='" & UCase(LTrim(RTrim(Session("empcode")))) & "' " & _
                            "and a.company_code ='" & UCase(LTrim(RTrim(Session("companycode")))) & "' " & _
                            "group by a.wh_no, a.stock_no, a.variant_no, a.description, a.short_description, a.purchase_uom, a.remarks " & _
                            "order by a.wh_no, a.stock_no, a.variant_no, a.description, a.short_description, a.purchase_uom, a.remarks "
            End If

        Else

            ''----Prepare data through sql procedure
            sqlpass = "exec jct_ops_ims_stock_report '" & _
                        UCase(LTrim(RTrim(Me.ddl_action.Text))) & "','" & _
                        Mid(LTrim(RTrim(Me.ddl_warehouse.Text)), InStr(LTrim(RTrim(Me.ddl_warehouse.Text)), "|") + 1, 10) & "','" & _
                        UCase(LTrim(RTrim(Session("empcode")))) & "','" & _
                        UCase(LTrim(RTrim(Session("companycode")))) & "' "

            obj.opencn()
            cmd = New SqlCommand(sqlpass, obj.cn)
            cmd.CommandTimeout = 0
            cmd.ExecuteNonQuery()

            obj.closecn()


            ''----Fill data in GridView1
            sqlpass = "select a.group_no as [GROUPNO],a.wh_no as [WAREHOUSE]," & _
                     "a.stock_no as [ITEMCODE],a.variant_no as [VARIANT]," & _
                     "a.description as [ITEMDESC],a.short_description as [ITEMSHORTDESC]," & _
                     "a.purchase_uom as [UOM],convert(numeric(12,3),a.stock_qty) as [QTY]," & _
                     "convert(numeric(12),a.value) as [VALUE]," & _
                     "convert(numeric(10,2),a.last_rate) as [LASTRATE]," & _
                     "convert(numeric(6,2),a.last_rate_per) as [RATEPER]," & _
                     "convert(varchar(11),a.last_date,103) as [LASTDATE],a.userid as [USERID]," & _
                     "a.company_code as [COMPANY] " & _
                     "from jct_ops_ims_stock a (nolock) " & _
                     "where a.userid ='" & UCase(LTrim(RTrim(Session("empcode")))) & "' " & _
                     "and a.company_code ='" & UCase(LTrim(RTrim(Session("companycode")))) & "' " & _
                     "order by a.group_no, a.wh_no, a.stock_no, a.variant_no, a.description, a.short_description "

        End If

        obj.opencn()
        Dim Da As SqlDataAdapter = New SqlDataAdapter(sqlpass, obj.cn)

        Try

            Dim ds As DataSet = New DataSet()
            Da.Fill(ds)
            ViewState("dt") = ds.Tables(0)
            GridView1.DataSource = ds
            GridView1.DataBind()
        Catch ex As Exception
            obj.closecn()
            FMsg.Message = (ex.Message)
            FMsg.CssClass = "addmsg"
            FMsg.Display()
        Finally
            obj.closecn()
        End Try

    End Sub

    Protected Sub imb_excel_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imb_excel.Click

        If Me.chk_agewise.Checked = True Then

            'GridViewExportUtil.Export("age_wise_current_stock.xls", Me.GridView1)
            Dim filename As String = "age_wise_current_stock.xls"
            GridViewExportUtil.Export(filename, Me.GridView1)

        Else

            'GridViewExportUtil.Export("current_stock.xls", Me.GridView1)
            Dim filename As String = "current_stock.xls"
            GridViewExportUtil.Export(filename, Me.GridView1)

        End If

    End Sub

End Class
