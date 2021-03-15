Imports System.Data.SqlClient
Imports System.Data
Imports System.Web.HttpResponse
Imports vb = Microsoft.VisualBasic
Imports System.String
Imports System.Math
Partial Class OPS_frm_issued_items_against_mr_order
    Inherits System.Web.UI.Page
    Dim sql As String
    Dim dr As SqlDataReader
    Dim cmd As SqlCommand
    Dim sqlpass As String
    Public obj As New HelpDeskClass

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Session("Companycode") = "JCT00LTD"
        'Session("Empcode") = "C-00509"

        If Not IsPostBack Then

            Me.txt_datefrom.Text = Now().Date
            Me.txt_dateto.Text = Now().Date

            ''-----Fill Action Combo Box
            'sqlpass = "/*select b.action,b.mnuname,b.description,b.parent_menu,b.seq " & _
            '    " from production..user_module_menus_mapping a inner join production..modules_menu_master b " & _
            '    " on a.module=b.module and a.mnuname=b.mnuname and a.action=b.action " & _
            '    " where a.module ='OPS' and a.uname='" & Session("empcode") & "' and a.mnuname='Process Rate Master'" & _
            '    " union*/ select b.action,b.mnuname,b.description,parent_menu,case b.action when 'ADD' then '1' when 'VIEW' then '2' when 'MODIFY' then '3' when 'CANCEL' then '4' when 'SHORT CLOSE' then '5' when 'AUTHORIZE' then '6' end /*b.seq*/ " & _
            '    " from production..role_module_menus_mapping a inner join production..modules_menu_master b " & _
            '    " on a.module=b.module and a.mnuname=b.mnuname and a.action=b.action " & _
            '    " inner join production..role_user_mapping e on a.role=e.role " & _
            '    " where a.module ='OPS' and e.uname='" & Session("empcode") & "' " & _
            '    "and a.mnuname='Process Rate Master' and a.action<>'Load'" & _
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


            ''-----Fill Sales Order Combo Box
            Me.ddl_orderno.Items.Add("ALL")

            sqlpass = "select distinct order_no " & _
                    "from miserp.imsdb.dbo.jct_edk_mr_detail " & _
                    "where company_code='" & UCase(LTrim(RTrim(Session("companycode")))) & "' " & _
                    "and isnull(order_no,'') like '%/%' " & _
                    "and system_date>='01/01/2013' " & _
                    "order by order_no "

            obj.opencn()
            cmd = New SqlCommand(sqlpass, obj.cn)
            dr = cmd.ExecuteReader

            If dr.HasRows = True Then
                While dr.Read
                    Me.ddl_orderno.Items.Add(dr.Item(0))
                End While
                Me.ddl_orderno.SelectedIndex = 0
            End If
            dr.Close()
            obj.closecn()


            ''-----Fill MR No. Combo Box
            Me.ddl_mrno.Items.Add("ALL")

            sqlpass = "select distinct mr_no " & _
                    "from miserp.imsdb.dbo.jct_edk_mr_detail " & _
                    "where company_code='" & UCase(LTrim(RTrim(Session("companycode")))) & "' " & _
                    "and left(ltrim(isnull(mr_no,'')),2)='MR' " & _
                    "and isnull(order_no,'') like '%/%' " & _
                    "and system_date>='01/01/2013' " & _
                    "order by mr_no "

            obj.opencn()
            cmd = New SqlCommand(sqlpass, obj.cn)
            dr = cmd.ExecuteReader

            If dr.HasRows = True Then
                While dr.Read
                    Me.ddl_mrno.Items.Add(dr.Item(0))
                End While
                Me.ddl_mrno.SelectedIndex = 0
            End If
            dr.Close()
            obj.closecn()

        End If

    End Sub

    Protected Sub imb_close_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imb_close.Click

        Me.Dispose()
        Response.Redirect("default.aspx")

    End Sub

    Protected Sub imb_fetch_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imb_fetch.Click

        If LTrim(RTrim(Me.txt_datefrom.Text)) = "" And Me.ddl_orderno.Text = "ALL" And Me.ddl_mrno.Text = "ALL" Then
            FMsg.Message = "Pl. select Date From"
            FMsg.CssClass = "errormsg"
            FMsg.Display()
            Exit Sub
        End If

        If LTrim(RTrim(Me.txt_dateto.Text)) = "" And Me.ddl_orderno.Text = "ALL" And Me.ddl_mrno.Text = "ALL" Then
            FMsg.Message = "Pl. select Date To"
            FMsg.CssClass = "errormsg"
            FMsg.Display()
            Exit Sub
        End If

        ''-----Order No. Validation check
        If LTrim(RTrim(Me.ddl_orderno.Text)) = "" Then
            FMsg.Message = "Pl. select Order No."
            FMsg.CssClass = "errormsg"
            FMsg.Display()
            Exit Sub
        End If

        ''-----MR No. Validation check
        If LTrim(RTrim(Me.ddl_mrno.Text)) = "" Then
            FMsg.Message = "Pl. select MR No."
            FMsg.CssClass = "errormsg"
            FMsg.Display()
            Exit Sub
        End If

        If UCase(LTrim(RTrim(Me.ddl_orderno.Text))) = "ALL" Or UCase(LTrim(RTrim(Me.ddl_mrno.Text))) = "ALL" Then
            Me.txt_dateto.Text = Me.txt_datefrom.Text
        End If

        obj.opencn()

        sqlpass = "exec jct_ops_ims_issued_items_against_sales_order_in_mr '" & _
                    LTrim(RTrim(Me.txt_datefrom.Text)) & "','" & _
                    LTrim(RTrim(Me.txt_dateto.Text)) & "','" & _
                    LTrim(RTrim(Me.ddl_orderno.Text)) & "','" & _
                    LTrim(RTrim(Me.ddl_mrno.Text)) & "','" & _
                    UCase(LTrim(RTrim(Session("empcode")))) & "','" & _
                    UCase(LTrim(RTrim(Session("companycode")))) & "'"

        Dim Da As SqlDataAdapter = New SqlDataAdapter(sqlpass, obj.cn)
        Da.SelectCommand.CommandTimeout = 0

        Try

            Dim ds As DataSet = New DataSet()
            Da.Fill(ds)
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

    Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imb_excel.Click

        ''GridViewExportUtil.Export("checklist.xls", Me.GridView1)
        Dim filename As String = "issued_items_against_sales_order.xls"
        GridViewExportUtil.Export(filename, Me.GridView1)

    End Sub

End Class
