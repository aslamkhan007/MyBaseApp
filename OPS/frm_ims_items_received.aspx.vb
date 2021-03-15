Imports System.Data.SqlClient
Imports System.Data
Imports System.Web.HttpResponse
Imports vb = Microsoft.VisualBasic
Imports System.String
Imports System.Math
Imports System.IO
Partial Class OPS_frm_ims_items_received
    Inherits System.Web.UI.Page
    Dim sql As String
    Dim dr As SqlDataReader
    Dim cmd As SqlCommand
    Dim sqlpass, sno2, sqlpass1, sqlpass2 As String
    Public obj As New HelpDeskClass
    Dim Ash, sno1 As Integer
    Dim Obj2 As Connection = New Connection
    Dim row As DataRow

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Session("Companycode") = "JCT00LTD"
        'Session("Empcode") = "C-00509"

        If Not Page.IsPostBack Then

            '-------Start TreeView Part

            'sqlpass1 = "select distinct group_code, group_desc from jct_ops_ims_items_received where group_code='BB' order by group_desc"

            '' Dim Dr As SqlDataReader = Obj.FetchReader(Sqlpass)

            'obj.opencn()
            'Dim daHod As SqlDataAdapter = New SqlDataAdapter(sqlpass1, obj.cn)

            '' Dr.Close()
            'Dim objDS As New DataSet
            'daHod.Fill(objDS, "dtHod")

            'obj.closecn()

            'Dim nodeResp, nodeUnder As TreeNode
            'Dim rowResp, rowUnder As DataRow
            'Dim ID1 As String

            'For Each rowResp In objDS.Tables("dtHod").Rows

            '    nodeResp = New TreeNode
            '    nodeResp.Text = rowResp("group_desc")
            '    ID1 = rowResp("group_code")
            '    TreeView1.Nodes.Add(nodeResp)

            '    '---------------Paent Node-----------------------
            '    'sqlpass2 = "select 'GROUP CODE' as [group_code],'GROUP DESC.' as [group_desc],'TRAN.DATE' as [tran_date],'TRAN.NO.' as [tran_no],'TRAN.STATUS' as [tran_status],'ITEM SERIAL' as [item_serial],'ITEM STATUS' as [item_status],'VENDOR CODE' as [vendor_code], " & _
            '    '        "'VENDOR NAME' as [vendor_name],'CITY' as [city],'ITEM CODE' as [stock_no],'VARIANT' as [stock_variant],'ITEM DESC.' as [description],'ITEM SHORT DESC.' as [short_description], " & _
            '    '        "'ITEM U.O.M.' as [item_uom],'ORDER QTY.' as [order_qty],'MOVED QTY.' as [moved_qty],'MOVED VALUE' as [moved_value],'RATE' as [rate],'RATE PER.' as [rate_per], 0 " & _
            '    '        "union " & _
            '    '        "select a.group_code, a.group_desc, convert(varchar(11),a.tran_date,103) as [tran_date], " & _
            '    '        "a.tran_no, a.tran_status, convert(varchar,a.item_serial) as [item_serial], a.item_status, a.vendor_code, " & _
            '    '        "a.vendor_name as [vendor_name], a.city, a.stock_no, a.stock_variant, a.description, a.short_description, " & _
            '    '        "a.item_uom, convert(varchar(18),a.order_qty) as [order_qty], convert(varchar(18),a.moved_qty) as [moved_qty], " & _
            '    '        "convert(varchar(18),a.moved_value) as [moved_value], convert(varchar(10),a.rate) as [rate], convert(varchar(8),a.rate_per) as [rate_per], 1 " & _
            '    '        "from jct_ops_ims_items_received a " & _
            '    '        "where group_code = '" & ID1 & "' " & _
            '    '        "and userid = '" & UCase(LTrim(RTrim(Session("empcode")))) & "' " & _
            '    '        "and company_code = '" & UCase(LTrim(RTrim(Session("companycode")))) & "' " & _
            '    '        "order by 21, 3, 4 "
            '    ''order by a.tran_date, a.tran_no "

            '    sqlpass2 = "select 'GROUP CODE' as [group_code], " & _
            '                "'GROUP DESC.' + replicate('_', 29) as [group_desc], " & _
            '                "'TRAN.DATE' as [tran_date], " & _
            '                "'TRAN.NO.' + replicate('_',11) as [tran_no], " & _
            '                "'TRAN.STATUS' as [tran_status], " & _
            '                "'ITEM SERIAL' as [item_serial], " & _
            '                "'ITEM STATUS' as [item_status], " & _
            '                "'VENDOR CODE' + replicate('_', 8) as [vendor_code], " & _
            '                "'VENDOR NAME' + replicate('_', 48 ) as [vendor_name], " & _
            '                "'CITY' + replicate('_', 35) as [city], " & _
            '                "'ITEM CODE' + replicate('_', 8) as [stock_no], " & _
            '                "'VARIANT' as [stock_variant], " & _
            '                "'ITEM DESC.' + replicate('_', 29) as [description], " & _
            '                "'ITEM SHORT DESC.' + replicate('_', 3) as [short_description], " & _
            '                "'ITEM UOM' as [item_uom], " & _
            '                "'ORDER QTY.' + replicate('_', 9) as [order_qty], " & _
            '                "'MOVED QTY.' + replicate('_', 9) as [moved_qty], " & _
            '                "'MOVED VALUE' + replicate('_', 8 ) as [moved_value], " & _
            '                "'RATE' + replicate('_', 5) as [rate], " & _
            '                "'RATE PER.' as [rate_per], 0 " & _
            '                "union " & _
            '                "select ltrim(rtrim(a.group_code)) + replicate('_', 10 - len(ltrim(rtrim(a.group_code)))) as [group_code], " & _
            '                "ltrim(rtrim(a.group_desc)) + replicate('_', 40 - len(ltrim(rtrim(a.group_desc)))) as [group_desc], " & _
            '                "convert(varchar(11),a.tran_date,103) as [tran_date], " & _
            '                "ltrim(rtrim(a.tran_no)) + replicate('_', 20 - len(ltrim(rtrim(a.tran_no)))) as [tran_no], " & _
            '                "a.tran_status + replicate('_',10) as [tran_status], " & _
            '                "ltrim(rtrim(convert(varchar,a.item_serial))) + replicate('_', 11 - len(ltrim(rtrim(convert(varchar,a.item_serial))))) as [item_serial], " & _
            '                "a.item_status + replicate('_',10) as [item_status], " & _
            '                "ltrim(rtrim(a.vendor_code)) + replicate('_', 20 - len(ltrim(rtrim(a.vendor_code)))) as [vendor_code], " & _
            '                "ltrim(rtrim(a.vendor_name)) + replicate('_', 60 - len(ltrim(rtrim(a.vendor_name)))) as [vendor_name], " & _
            '                "ltrim(rtrim(a.city)) + replicate('_', 40 - len(ltrim(rtrim(a.city)))) as [city], " & _
            '                "ltrim(rtrim(a.stock_no)) + replicate('_', 18 - len(ltrim(rtrim(a.stock_no)))) as [stock_no], " & _
            '                "ltrim(rtrim(a.stock_variant)) + replicate('_', 7 - len(ltrim(rtrim(a.stock_variant)))) as [stock_variant], " & _
            '                "ltrim(rtrim(a.description)) + replicate('_', 40 - len(ltrim(rtrim(a.description)))) as [description], " & _
            '                "ltrim(rtrim(a.short_description)) + replicate('_', 20 - len(ltrim(rtrim(a.short_description)))) as [short_description], " & _
            '                "ltrim(rtrim(a.item_uom)) + replicate('_', 8 - len(ltrim(rtrim(a.item_uom)))) as [item_uom], " & _
            '                "ltrim(rtrim(convert(varchar(18),a.order_qty))) + replicate('_', 20 - len(ltrim(rtrim(a.order_qty)))) as [order_qty], " & _
            '                "ltrim(rtrim(convert(varchar(18),a.moved_qty))) + replicate('_', 20 - len(ltrim(rtrim(a.moved_qty)))) as [moved_qty], " & _
            '                "ltrim(rtrim(convert(varchar(18),a.moved_value))) + replicate('_', 20 - len(ltrim(rtrim(a.moved_value)))) as [moved_value], " & _
            '                "ltrim(rtrim(convert(varchar(10),a.rate))) + replicate('_', 10 - len(ltrim(rtrim(a.rate)))) as [rate], " & _
            '                "ltrim(rtrim(convert(varchar(8),a.rate_per))) + replicate('_', 10 - len(ltrim(rtrim(a.rate_per)))) as [rate_per], 1 " & _
            '                "from jct_ops_ims_items_received a " & _
            '                "where group_code = '" & ID1 & "' " & _
            '                "and userid = '" & UCase(LTrim(RTrim(Session("empcode")))) & "' " & _
            '                "and company_code = '" & UCase(LTrim(RTrim(Session("companycode")))) & "' " & _
            '                "order by 21, 3, 4 "
            '    'order by a.tran_date, a.tran_no "

            '    obj.opencn()

            '    Dim Dr1 As SqlDataReader = Obj2.FetchReader(SqlPass2)

            '    Dim daUnder As SqlDataAdapter = New SqlDataAdapter(SqlPass2, obj.cn)

            '    Dr1.Close()

            '    Dim objDS1 As New DataSet
            '    daUnder.Fill(objDS1, "dtUnder")
            '    Dim ID2 As String

            '    obj.closecn()

            '    For Each rowUnder In objDS1.Tables("dtUnder").Rows

            '        nodeUnder = New TreeNode
            '        nodeUnder.Text = CStr(rowUnder("tran_date")) + ":" + rowUnder("tran_no") + ":" + rowUnder("tran_status") + ":" + CStr(rowUnder("item_serial")) + ":" + rowUnder("item_status") + ":" + rowUnder("vendor_code") + ":" + rowUnder("vendor_name") + ":" + rowUnder("city") + ":" + rowUnder("stock_no") + ":" + rowUnder("stock_variant") + ":" + rowUnder("description") + ":" + rowUnder("short_description") + ":" + rowUnder("item_uom") + ":" + CStr(rowUnder("order_qty")) + ":" + CStr(rowUnder("moved_qty")) + ":" + CStr(rowUnder("moved_value")) + ":" + CStr(rowUnder("rate")) + ":" + CStr(rowUnder("rate_per"))
            '        ID2 = rowUnder("group_code")
            '        nodeResp.ChildNodes.Add(nodeUnder)

            '    Next

            '    daUnder.Dispose()

            'Next

            ''clean up

            'objDS.Dispose()

            'daHod.Dispose()

            'obj.closecn()
            ''obj.ConClose()

            'Me.TreeView1.CollapseAll()


            '-------------End of TreeView Part


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
            '    " where a.module ='OPS' and a.uname='" & Session("empcode") & "' and a.mnuname='Raw Material Purchase'" & _
            '    " union*/ select b.action,b.mnuname,b.description,parent_menu,case b.action when 'ADD' then '1' when 'VIEW' then '2' when 'MODIFY' then '3' when 'CANCEL' then '4' when 'SHORT CLOSE' then '5' when 'AUTHORIZE' then '6' end /*b.seq*/ " & _
            '    " from production..role_module_menus_mapping a inner join production..modules_menu_master b " & _
            '    " on a.module=b.module and a.mnuname=b.mnuname and a.action=b.action " & _
            '    " inner join production..role_user_mapping e on a.role=e.role " & _
            '    " where a.module ='OPS' and e.uname='" & Session("empcode") & "' " & _
            '    "and a.mnuname='Raw Material Purchase' and a.action<>'Load'" & _
            '    " order by b.parent_menu,b.mnuname,case b.action when 'ADD' then '1' when 'VIEW' then '2' when 'MODIFY' then '3' when 'CANCEL' then '4' when 'SHORT CLOSE' then '5' when 'AUTHORIZE' then '6' end /*b.seq*/ "


            'obj.opencn()
            'cmd = New SqlCommand(sqlpass, obj.cn)
            'dr = cmd.ExecuteReader

            'If dr.HasRows = True Then
            '    While dr.Read
            '        Me.ddl_action.Items.Add(dr.Item(0))
            '    End While
            '    Me.ddl_action.SelectedIndex = 0
            'End If
            'dr.Close()
            'obj.closecn()

            Me.ddl_action.Items.Add("view")


            ''-----Fill Item Group in Item group Combo Box
            sqlpass = "select ltrim(rtrim(group_desc)) + '|' + ltrim(rtrim(group_code)) " & _
                    "from jct_ops_ims_group_master " & _
                    "where company_code='" & UCase(LTrim(RTrim(Session("companycode")))) & "' " & _
                    "order by ltrim(rtrim(group_desc)) + '|' + ltrim(rtrim(group_code)) "

            obj.opencn()
            cmd = New SqlCommand(sqlpass, obj.cn)
            cmd.CommandTimeout = 0
            dr = cmd.ExecuteReader

            Me.ddl_itemgroup.Items.Add("ALL|ALL")

            If dr.HasRows = True Then
                While dr.Read
                    Me.ddl_itemgroup.Items.Add(dr.Item(0))
                End While
                Me.ddl_itemgroup.SelectedIndex = 0
            End If
            dr.Close()
            obj.closecn()

            ''Fill Vendor name and code in Supplier combo box
            sqlpass = "select distinct ltrim(rtrim(vendor_name)) + '|' + ltrim(rtrim(vendor_code)) " & _
            "from miserp.common.dbo.pur_company_vendor_master " & _
            "where company_code='" & UCase(LTrim(RTrim(Session("companycode")))) & "' " & _
            "order by ltrim(rtrim(vendor_name)) + '|' + ltrim(rtrim(vendor_code)) "

            obj.opencn()
            cmd = New SqlCommand(sqlpass, obj.cn)
            cmd.CommandTimeout = 0
            dr = cmd.ExecuteReader

            Me.ddl_supplier.Items.Add("ALL|ALL")

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

        End If

    End Sub

    Protected Sub TreeView1_SelectedNodeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TreeView1.SelectedNodeChanged

        'Try
        '    If LCase(Session("Companycode")) = "jct00ltd" Then 'Session("Location") = "JCT00LTD" Then
        '        sqlpass = "SELECT Top 1 CardNo,EmpName,Desg,deptcode,Mr_Mrs FROM  JCTDEV..JCT_EmpMast_Base where EmpCode='" & Right(Trim(TreeView1.SelectedNode.Text), 7) & "' "
        '    Else
        '        sqlpass = "SELECT Top 1 CardNo,EmpName,Desg,deptcode,Mr_Mrs FROM  JCTDEV..JCT_EmpMast_Base where EmpCode='" & RTrim(LTrim(Right(Trim(Replace(TreeView1.SelectedNode.Text, ":", "")), 6))) & "' "
        '    End If
        '    Dim Dr11 As SqlDataReader = obj.FetchReader(sqlpass)
        '    If Dr11.HasRows = True Then
        '        While Dr11.Read()
        '            Image1.ImageUrl = "..\EmployeePortal\EmpImages\" & Trim(Dr11.Item("CardNo")) & ".jpg"
        '            Label1.Text = Dr11.Item("Mr_Mrs") + " " + Dr11.Item("EmpName")
        '            Label2.Text = Dr11.Item("Desg")
        '            Dept = Dr11.Item("Deptcode")
        '        End While

        '    End If
        '    Dr11.Close()
        'Finally
        '    obj.ConClose()
        'End Try

        'Try
        '    SqlPass1 = "SELECT DeptNAME,DEPTCODE FROM  JCTDEV..Deptmast where Deptcode='" & Dept & "' "
        '    Dim Dr12 As SqlDataReader = obj.FetchReader(SqlPass1)
        '    If Dr12.HasRows = True Then
        '        While Dr12.Read()
        '            Label3.Text = Dr12.Item(0)
        '        End While

        '    End If
        '    Dr12.Close()
        'Finally
        '    obj.ConClose()
        'End Try

    End Sub

    Protected Sub imb_tran_fetch_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imb_tran_fetch.Click

        ''----Prepare data through sql procedure
        sqlpass = "exec jct_ops_ims_items_received_fetch '" & _
                    UCase(LTrim(RTrim(Me.ddl_action.Text))) & "','" & _
                    Mid(LTrim(RTrim(Me.ddl_itemgroup.Text)), InStr(LTrim(RTrim(Me.ddl_itemgroup.Text)), "|") + 1, 10) & "','" & _
                    Mid(LTrim(RTrim(Me.ddl_supplier.Text)), InStr(LTrim(RTrim(Me.ddl_supplier.Text)), "|") + 1, 10) & "','" & _
                    LTrim(RTrim(Me.txt_itemcode.Text)) & "','" & _
                    LTrim(RTrim(Me.txt_variant.Text)) & "','" & _
                    Me.txt_fromdate.Text & "','" & _
                    Me.txt_todate.Text & "','" & _
                    UCase(LTrim(RTrim(Session("empcode")))) & "','" & _
                    UCase(LTrim(RTrim(Session("companycode")))) & "' "

        obj.opencn()
        cmd = New SqlCommand(sqlpass, obj.cn)
        cmd.CommandTimeout = 0
        cmd.ExecuteNonQuery()

        obj.closecn()

        ''----Fill data in GridView1

        sqlpass = "select a.group_code as [GROUP CODE], a.group_desc as [GROUP DESC.], convert(varchar(11),a.tran_date,103) as [TRAN.DATE], " & _
                "a.tran_no as [TRAN.NO.], a.tran_status as [TRAN.STATUS], convert(varchar,a.item_serial) as [ITEM SERIAL], a.item_status as [ITEM STATUS], a.vendor_code as [VENDOR CODE], " & _
                "a.vendor_name as [VENDOR NAME], a.city as [CITY], a.stock_no as [ITEM CODE], a.stock_variant as [VARIANT], a.description as [ITEM DESC.], a.short_description as [ITEM SHORT DESC.], " & _
                "a.item_uom as [UOM], convert(varchar(18),a.order_qty) as [ORDER QTY.], convert(varchar(18),a.moved_qty) as [MOVED QTY.], " & _
                "convert(varchar(18),a.moved_value) as [MOVED VALUE], convert(varchar(10),a.rate) as [RATE], convert(varchar(8),a.rate_per) as [RATE PER.] " & _
                "from jct_ops_ims_items_received a " & _
                "where userid = '" & UCase(LTrim(RTrim(Session("empcode")))) & "' " & _
                "and company_code = '" & UCase(LTrim(RTrim(Session("companycode")))) & "' " & _
                "order by a.group_code, a.tran_date, a.tran_no, a.item_serial, a.stock_no, a.stock_variant "

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

    Protected Sub imb_close_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imb_close.Click

        Me.Dispose()
        Response.Redirect("default.aspx")

    End Sub

    Protected Sub imb_excel_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imb_excel.Click

        GridViewExportUtil.Export("ims_items_received.xls", Me.GridView1)
        'Dim filename As String = LTrim(RTrim(Me.ddl_reporttype.Text)) + "_" + Right(RTrim(Me.ddl_yearmonth.Text), 6) + "-" + LTrim(RTrim(Me.ddl_revno.Text)) + ".xls"
        'GridViewExportUtil.Export(filename, Me.GridView1)

    End Sub

    Protected Sub txt_itemcode_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_itemcode.TextChanged


        If LTrim(RTrim(Me.txt_itemcode.Text)) = "" Then

            'dr.Close()
            'obj.closecn()
            Exit Sub

        End If

        If InStr(LTrim(RTrim(Me.txt_itemcode.Text)), "-") > 0 Then

            Me.txt_itemcode.Text = Mid(LTrim(RTrim(Me.txt_itemcode.Text)), 1, InStr(LTrim(RTrim(Me.txt_itemcode.Text)), "-") - 2)
            Dim modal As AjaxControlToolkit.AutoCompleteExtender = DirectCast(txt_variant.FindControl("AutoCompleteExtender2"), AjaxControlToolkit.AutoCompleteExtender)
            modal.ContextKey = txt_itemcode.Text

        End If

        ''-----Fill Item Desc. text box
        ''dr.Close()
        'sqlpass = "select description from miserp.common.dbo.ims_stock_master " & _
        '        "where stock_no ='" & LTrim(RTrim(Me.txt_itemcode.Text)) & "' " & _
        '        "and stock_type = '0' " & _
        '        "and company_no='" & UCase(LTrim(RTrim(Session("companycode")))) & "' "

        'obj.opencn()
        'cmd = New SqlCommand(sqlpass, obj.cn)
        'dr = cmd.ExecuteReader

        'If dr.HasRows = True Then
        '    dr.Read()
        '    Me.txt_item_desc.Text = dr.Item(0)
        '    Me.txt_variant.Text = ""
        '    Me.txt_variant.Focus()
        'Else
        '    FMsg.Message = "Invalid Item Code or Item code not related with Raw Material items "
        '    FMsg.CssClass = "errormsg"
        '    FMsg.Display()
        '    Me.txt_itemcode.Focus()
        '    dr.Close()
        '    obj.closecn()
        '    Exit Sub
        'End If
        'dr.Close()
        'obj.closecn()

    End Sub

    Protected Sub txt_variant_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_variant.TextChanged

        If LTrim(RTrim(Me.txt_variant.Text)) = "" Then

            'dr.Close()
            'obj.closecn()
            Exit Sub

        End If

        If InStr(LTrim(RTrim(Me.txt_variant.Text)), "-") > 0 Then

            Me.txt_variant.Text = Mid(LTrim(RTrim(Me.txt_variant.Text)), 1, InStr(LTrim(RTrim(Me.txt_variant.Text)), "-") - 2)

        End If

        ' ''-----Fill Item Desc. text box
        ''dr.Close()
        'sqlpass = "select short_description from miserp.common.dbo.ims_variant_master " & _
        '        "where stock_no ='" & LTrim(RTrim(Me.txt_itemcode.Text)) & "' " & _
        '        "and variant_no='" & LTrim(RTrim(Me.txt_variant.Text)) & "' " & _
        '        "and company_no='" & UCase(LTrim(RTrim(Session("companycode")))) & "' "

        'obj.opencn()
        'cmd = New SqlCommand(sqlpass, obj.cn)
        'dr = cmd.ExecuteReader

        'If dr.HasRows = True Then
        '    dr.Read()
        '    Me.txt_variant_desc.Text = dr.Item(0)
        'Else
        '    FMsg.Message = "Invalid Item Code/Variant "
        '    FMsg.CssClass = "errormsg"
        '    FMsg.Display()
        '    Me.txt_variant.Focus()
        '    dr.Close()
        '    obj.closecn()
        '    Exit Sub
        'End If
        'dr.Close()
        'obj.closecn()

    End Sub

End Class
