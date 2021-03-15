Imports System.Data.SqlClient
Imports System.Data
Imports System.Web.HttpResponse
Imports vb = Microsoft.VisualBasic
Imports System.String
Imports System.Math
Partial Class OPS_frm_raw_material_receipt_detail
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

            sqlpass = "select convert(varchar(11),getdate(),101) "

            obj.opencn()
            cmd = New SqlCommand(sqlpass, obj.cn)
            dr = cmd.ExecuteReader

            If dr.HasRows = True Then
                dr.Read()
                Me.txt_fromdate.Text = dr.Item(0)
                Me.txt_todate.Text = dr.Item(0)
            End If
            dr.Close()
            obj.closecn()

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


            ''-----Fill Item Group in Item group Combo Box
            'sqlpass = "select ltrim(rtrim(description)) + '|' + ltrim(rtrim(group_no)) " & _
            '        "from miserp.common.dbo.ims_stock_group_master " & _
            '        "where type = 1 and disabled = 0 " & _
            '        "and company_no='" & UCase(LTrim(RTrim(Session("companycode")))) & "' " & _
            '        "order by ltrim(rtrim(description)) + '|' + ltrim(rtrim(group_no)) "

            sqlpass = "select distinct ltrim(rtrim(group_desc)) + '|' + ltrim(rtrim(group_code)) " & _
                        "from jct_ops_raw_material_receipt_header " & _
                        "where company_code='" & UCase(LTrim(RTrim(Session("companycode")))) & "' " & _
                        "order by ltrim(rtrim(group_desc)) + '|' + ltrim(rtrim(group_code)) "

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

            'Me.txt_groupcode.Text = LTrim(RTrim(Mid(Me.ddl_itemgroup.Text, InStr(Me.ddl_itemgroup.Text, "|") + 1, 20)))


            ''-----Fill Vendor Name and Code in Supplier Combo Box
            'sqlpass = "select distinct ltrim(rtrim(d.vendor_name)) + '|' + ltrim(rtrim(a.vendor_code)) " & _
            '        "from miserp.pomdb.dbo.pur_gi_header a, miserp.pomdb.dbo.pur_gi_detail b, " & _
            '        "miserp.common.dbo.ims_stock_master c, miserp.common.dbo.pur_company_vendor_master d " & _
            '        "where a.gi_no = b.gi_no " & _
            '        "and b.stock_no = c.stock_no " & _
            '        "and c.stock_type = '0' " & _
            '        "/*and c.purchase_uom='KG'*/ " & _
            '        "and a.vendor_code = d.vendor_code " & _
            '        "and a.company_code='" & UCase(LTrim(RTrim(Session("companycode")))) & "' " & _
            '        "and a.company_code = b.company_code " & _
            '        "order by ltrim(rtrim(d.vendor_name)) + '|' + ltrim(rtrim(a.vendor_code)) "

            sqlpass = "select distinct ltrim(rtrim(supplier_name)) + '|' + ltrim(rtrim(supplier_code)) " & _
                        "from jct_ops_raw_material_receipt_header_supplier " & _
                        "where company_code='" & UCase(LTrim(RTrim(Session("companycode")))) & "' " & _
                        "order by ltrim(rtrim(supplier_name)) + '|' + ltrim(rtrim(supplier_code)) "

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
            'Me.txt_supplier_code.Text = LTrim(RTrim(Mid(Me.ddl_supplier.Text, InStr(Me.ddl_supplier.Text, "|") + 1, 10)))


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

    Protected Sub txt_itemcode_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_itemcode.TextChanged

        If InStr(LTrim(RTrim(Me.txt_itemcode.Text)), "-") > 0 Then

            Me.txt_itemcode.Text = Mid(LTrim(RTrim(Me.txt_itemcode.Text)), 1, InStr(LTrim(RTrim(Me.txt_itemcode.Text)), "-") - 2)
            Dim modal As AjaxControlToolkit.AutoCompleteExtender = DirectCast(txt_variant.FindControl("AutoCompleteExtender2"), AjaxControlToolkit.AutoCompleteExtender)
            modal.ContextKey = txt_itemcode.Text

        End If

    End Sub

    Protected Sub txt_variant_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_variant.TextChanged

        If InStr(LTrim(RTrim(Me.txt_variant.Text)), "-") > 0 Then

            Me.txt_variant.Text = Mid(LTrim(RTrim(Me.txt_variant.Text)), 1, InStr(LTrim(RTrim(Me.txt_variant.Text)), "-") - 2)

        End If

    End Sub

    Protected Sub imb_fetch_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imb_fetch.Click

        ''-----ReFill GridView1
        sqlpass = "exec jct_ops_raw_material_purchase_budget_report '" & _
                    UCase(LTrim(RTrim(Me.ddl_action.Text))) & "','" & _
                    UCase(LTrim(RTrim(Me.ddl_plant.Text))) & "','" & _
                    UCase(Mid(LTrim(RTrim(Me.ddl_itemgroup.Text)), InStr(LTrim(RTrim(Me.ddl_itemgroup.Text)), "|") + 1, 20)) & "','" & _
                    UCase(Mid(LTrim(RTrim(Me.ddl_supplier.Text)), InStr(LTrim(RTrim(Me.ddl_supplier.Text)), "|") + 1, 10)) & "','" & _
                    UCase(LTrim(RTrim(Me.txt_itemcode.Text))) & "','" & _
                    UCase(LTrim(RTrim(Me.txt_variant.Text))) & "','" & _
                    UCase(LTrim(RTrim(Me.txt_fromdate.Text))) & "','" & _
                    UCase(LTrim(RTrim(Me.txt_todate.Text))) & "','" & _
                    UCase(LTrim(RTrim(Session("empcode")))) & "','" & _
                    UCase(LTrim(RTrim(Session("companycode")))) & "' "

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

        ''GridViewExportUtil.Export("checklist.xls", Me.GridView1)
        Dim filename As String = "jct_ops_raw_material_purchase_budget.xls"
        GridViewExportUtil.Export(filename, Me.GridView1)

    End Sub

End Class
