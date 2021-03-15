Imports System.Data.SqlClient
Imports System.Data
Imports System.Web.HttpResponse
Imports vb = Microsoft.VisualBasic
Imports System.String
Imports System.Math
Partial Class Costing_fibre_master
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

            'sqlpass = "select convert(varchar(11),getdate(),101) "

            'obj.opencn()
            'cmd = New SqlCommand(sqlpass, obj.cn)
            'dr = cmd.ExecuteReader

            'If dr.HasRows = True Then
            '    dr.Read()
            '    Me.txt_efffrom.Text = dr.Item(0)
            '    Me.txt_effto.Text = dr.Item(0)
            'End If
            'dr.Close()
            'obj.closecn()

            Me.txt_efffrom.Text = Now().Date
            Me.txt_effto.Text = Now().Date

            ''-----Fill Action Combo Box
            sqlpass = "/*select b.action,b.mnuname,b.description,b.parent_menu,b.seq " & _
                " from production..user_module_menus_mapping a inner join production..modules_menu_master b " & _
                " on a.module=b.module and a.mnuname=b.mnuname and a.action=b.action " & _
                " where a.module ='OPS' and a.uname='" & Session("empcode") & "' and a.mnuname='Fibre Master'" & _
                " union*/ select b.action,b.mnuname,b.description,parent_menu,case b.action when 'ADD' then '1' when 'VIEW' then '2' when 'MODIFY' then '3' when 'CANCEL' then '4' when 'SHORT CLOSE' then '5' when 'AUTHORIZE' then '6' end /*b.seq*/ " & _
                " from production..role_module_menus_mapping a inner join production..modules_menu_master b " & _
                " on a.module=b.module and a.mnuname=b.mnuname and a.action=b.action " & _
                " inner join production..role_user_mapping e on a.role=e.role " & _
                " where a.module ='OPS' and e.uname='" & Session("empcode") & "' " & _
                "and a.mnuname='Fibre Master' and a.action<>'Load'" & _
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


            ''-----Fill Main Fibre Code Combo Box
            sqlpass = "select distinct main_fibre_code, main_sequence_no " & _
                    "from jct_costing_fibre_type_master " & _
                    "where company_code='" & UCase(LTrim(RTrim(Session("companycode")))) & "' " & _
                    "order by main_sequence_no, main_fibre_code "

            obj.opencn()
            cmd = New SqlCommand(sqlpass, obj.cn)
            dr = cmd.ExecuteReader

            If dr.HasRows = True Then
                While dr.Read
                    Me.ddl_main_fibre_code.Items.Add(dr.Item(0))
                End While
                Me.ddl_main_fibre_code.SelectedIndex = 0
            End If
            dr.Close()
            obj.closecn()


            ''-----Fill Main Fibre Code Desc. Text Box
            sqlpass = "select distinct top 1 main_fibre_desc, eff_to " & _
                    "from jct_costing_fibre_type_master " & _
                    "where main_fibre_code='" & Me.ddl_main_fibre_code.Text & "' " & _
                    "and company_code='" & UCase(LTrim(RTrim(Session("companycode")))) & "' " & _
                    "order by eff_to desc "

            obj.opencn()
            cmd = New SqlCommand(sqlpass, obj.cn)
            dr = cmd.ExecuteReader

            If dr.HasRows = True Then
                dr.Read()
                Me.txt_main_fibre_desc.Text = dr.Item(0)
            Else
                Me.txt_main_fibre_desc.Text = ""
            End If
            dr.Close()
            obj.closecn()


            ''-----Fill Sub Fibre Code Combo Box
            sqlpass = "select distinct sub_fibre_code, sub_sequence_no " & _
                    "from jct_costing_fibre_type_master " & _
                    "where company_code='" & UCase(LTrim(RTrim(Session("companycode")))) & "' " & _
                    "order by sub_sequence_no, sub_fibre_code "

            obj.opencn()
            cmd = New SqlCommand(sqlpass, obj.cn)
            dr = cmd.ExecuteReader

            If dr.HasRows = True Then
                While dr.Read
                    Me.ddl_sub_fibre_code.Items.Add(dr.Item(0))
                End While
                Me.ddl_sub_fibre_code.SelectedIndex = 0
            End If
            dr.Close()
            obj.closecn()


            ''-----Fill Sub Fibre Code Desc. Text Box
            sqlpass = "select distinct top 1 sub_fibre_desc, eff_to " & _
                    "from jct_costing_fibre_type_master " & _
                    "where sub_fibre_code='" & Me.ddl_sub_fibre_code.Text & "' " & _
                    "and company_code='" & UCase(LTrim(RTrim(Session("companycode")))) & "' " & _
                    "order by eff_to desc "

            obj.opencn()
            cmd = New SqlCommand(sqlpass, obj.cn)
            dr = cmd.ExecuteReader

            If dr.HasRows = True Then
                dr.Read()
                Me.txt_sub_fibre_desc.Text = dr.Item(0)
            Else
                Me.txt_sub_fibre_desc.Text = ""
            End If
            dr.Close()
            obj.closecn()


            ''-----Fill Currency Code Combo Box
            sqlpass = "select distinct currency_code, sequence_no " & _
                    "from jct_costing_currency_master " & _
                    "where company_code='" & UCase(LTrim(RTrim(Session("companycode")))) & "' " & _
                    "order by sequence_no, currency_code "

            obj.opencn()
            cmd = New SqlCommand(sqlpass, obj.cn)
            dr = cmd.ExecuteReader

            If dr.HasRows = True Then
                While dr.Read
                    Me.ddl_currency.Items.Add(dr.Item(0))
                End While
                Me.ddl_currency.SelectedIndex = 0
            End If
            dr.Close()
            obj.closecn()

            'Me.lbt_view_Click(sender, e)  '' set view mode at page loading time
            Me.lbt_add_Click(sender, e)  '' set add mode at page loading time


            ''-----Fill GridView1
            sqlpass = "exec jct_costing_fibre_master_fetch_all '" & _
                    LTrim(RTrim(Me.ddl_action.Text)) & "','" & _
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

        End If  '' end of If Not IsPostBack 

        'If Not IsPostBack Then
        '    grdbnd()
        'End If

    End Sub

    Protected Sub ddl_action_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl_action.SelectedIndexChanged

        If UCase(LTrim(RTrim(Me.ddl_action.Text))) = "ADD" Then ''And Me.lbt_add.Text = "ADD" Then

            If Me.lbt_add.Text = "ADD" Then

                'Me.lbt_apply.Enabled = True

                Me.ddl_location.Enabled = True
                Me.ddl_main_fibre_code.Enabled = True
                Me.ddl_sub_fibre_code.Enabled = True
                Me.ddl_fibre_group.Enabled = True
                Me.ddl_rate_type.Enabled = True
                Me.ddl_uom.Enabled = True
                Me.ddl_currency.Enabled = True
                Me.txt_rate.Enabled = True
                Me.txt_efffrom.Enabled = True
                Me.txt_effto.Enabled = True
                Me.txt_tranno.Enabled = False

                'Me.GridView1.DataSource = Nothing
                'GridView1.DataBind()

                Me.txt_tranno.Text = ""
                Me.lbl_status.Text = ""
                Me.txt_rate.Text = ""
                'Me.txt_main_fibre_desc.Text = ""
                'Me.txt_sub_fibre_desc.Text = ""
                Me.txt_efffrom.Text = Now().Date
                Me.txt_effto.Text = Now().Date

                'Me.lbt_add.Enabled = True
                'Me.lbt_view.Enabled = False
                'Me.lbt_modify.Enabled = False
                'Me.lbt_authorize.Enabled = False
                'Me.lbt_delete.Enabled = False
                'Me.lbt_close.Enabled = True

                Me.imb_tran_fetch.Enabled = False
                'Me.imb_insertrow.Enabled = True
                'Me.imb_deleterow.Enabled = True

                Me.imb_top.Enabled = False
                Me.imb_next.Enabled = False
                Me.imb_previous.Enabled = False
                Me.imb_last.Enabled = False

                Me.lbt_add.Text = "SAVE"
                'Me.lbt_close.Text = "CANCEL"  '' "UNDO"

                'Me.lbt_add.CssClass = "Buttonc"
                'Me.lbt_view.CssClass = "ButtonDisable"
                'Me.lbt_modify.CssClass = "ButtonDisable"
                'Me.lbt_close.CssClass = "ButtonDisable"
                'Me.lbt_authorize.CssClass = "ButtonDisable"
                'Me.lbt_close.CssClass = "Buttonc"

            ElseIf lbt_add.Text = "SAVE" Then

                Me.ddl_action.SelectedIndex = 0    ''  Set action in ADD mode
                Me.lbt_apply_Click(sender, e)      ''  Execute APPLY button script through LinkButton1_Click event
                ''Me.lnk_exit_Click(sender, e)       ''  Execute EXIT button script

            End If

        End If


        If UCase(LTrim(RTrim(Me.ddl_action.Text))) = "MODIFY" Then ''And Me.lbt_modify.Text = "MODIFY" Then

            If Me.lbt_modify.Text = "MODIFY" Then

                'Me.lbt_apply.Enabled = True

                Me.ddl_location.Enabled = True
                Me.ddl_main_fibre_code.Enabled = True
                Me.ddl_sub_fibre_code.Enabled = True
                Me.ddl_fibre_group.Enabled = True
                Me.ddl_rate_type.Enabled = True
                Me.ddl_uom.Enabled = True
                Me.ddl_currency.Enabled = True
                Me.txt_rate.Enabled = True
                Me.txt_efffrom.Enabled = True
                Me.txt_effto.Enabled = True
                Me.txt_tranno.Enabled = True

                'Me.GridView1.DataSource = Nothing
                'GridView1.DataBind()

                Me.txt_tranno.Text = ""
                Me.lbl_status.Text = ""
                Me.txt_rate.Text = ""
                'Me.txt_main_fibre_desc.Text = ""
                'Me.txt_sub_fibre_desc.Text = ""
                Me.txt_efffrom.Text = Now().Date
                Me.txt_effto.Text = Now().Date

                'Me.lbt_add.Enabled = False
                'Me.lbt_view.Enabled = False
                'Me.lbt_modify.Enabled = True
                'Me.lbt_authorize.Enabled = False
                'Me.lbt_delete.Enabled = False
                'Me.lbt_close.Enabled = True

                Me.imb_tran_fetch.Enabled = True
                'Me.imb_insertrow.Enabled = True
                ' Me.imb_deleterow.Enabled = True

                Me.imb_top.Enabled = True
                Me.imb_next.Enabled = True
                Me.imb_previous.Enabled = True
                Me.imb_last.Enabled = True

                Me.lbt_modify.Text = "UPDATE"
                'Me.lbt_close.Text = "CANCEL"  '' "UNDO"

                'Me.lbt_add.CssClass = "ButtonDisable"
                'Me.lbt_view.CssClass = "ButtonDisable"
                'Me.lbt_modify.CssClass = "Buttonc"
                'Me.lbt_close.CssClass = "ButtonDisable"
                'Me.lbt_authorize.CssClass = "ButtonDisable"
                'Me.lbt_close.CssClass = "Buttonc"

            ElseIf lbt_modify.Text = "UPDATE" Then

                Me.ddl_action.SelectedIndex = 2    ''  Set action in MODIFY mode
                Me.lbt_apply_Click(sender, e)      ''  Execute APPLY button script through LinkButton1_Click event
                ''Me.lnk_exit_Click(sender, e)       ''  Execute EXIT button script

            End If

        End If


        If UCase(LTrim(RTrim(Me.ddl_action.Text))) = "VIEW" Then

            'Me.lbt_apply.Enabled = True

            Me.ddl_location.Enabled = False
            Me.txt_efffrom.Enabled = False
            Me.ddl_main_fibre_code.Enabled = False
            Me.ddl_sub_fibre_code.Enabled = False
            Me.ddl_fibre_group.Enabled = False
            Me.ddl_rate_type.Enabled = False
            Me.ddl_uom.Enabled = False
            Me.ddl_currency.Enabled = False
            Me.txt_rate.Enabled = False
            Me.txt_effto.Enabled = False
            Me.txt_tranno.Enabled = True

            'Me.GridView1.DataSource = Nothing
            'GridView1.DataBind()

            Me.txt_tranno.Text = ""
            Me.lbl_status.Text = ""
            Me.txt_rate.Text = ""
            'Me.txt_main_fibre_desc.Text = ""
            'Me.txt_sub_fibre_desc.Text = ""
            Me.txt_efffrom.Text = Now().Date
            Me.txt_effto.Text = Now().Date

            'Me.lbt_add.Enabled = False
            'Me.lbt_view.Enabled = True
            'Me.lbt_modify.Enabled = False
            'Me.lbt_authorize.Enabled = False
            'Me.lbt_delete.Enabled = False
            'Me.lbt_close.Enabled = True

            Me.imb_tran_fetch.Enabled = True
            'Me.imb_insertrow.Enabled = False
            'Me.imb_deleterow.Enabled = False

            Me.imb_top.Enabled = True
            Me.imb_next.Enabled = True
            Me.imb_previous.Enabled = True
            Me.imb_last.Enabled = True

            'Me.lbt_close.Text = "CANCEL"  '' "UNDO"

            'Me.lbt_add.CssClass = "ButtonDisable"
            'Me.lbt_view.CssClass = "Buttonc"
            'Me.lbt_modify.CssClass = "ButtonDisable"
            'Me.lbt_close.CssClass = "ButtonDisable"
            'Me.lbt_authorize.CssClass = "ButtonDisable"
            'Me.lbt_close.CssClass = "Buttonc"

        End If


        If UCase(LTrim(RTrim(Me.ddl_action.Text))) = "AUTHORIZE" Then

            If lbt_authorize.Text = "AUTHORIZE" Then

                'Me.lbt_apply.Enabled = True

                Me.ddl_location.Enabled = False
                Me.ddl_main_fibre_code.Enabled = False
                Me.ddl_sub_fibre_code.Enabled = False
                Me.ddl_fibre_group.Enabled = False
                Me.ddl_rate_type.Enabled = False
                Me.ddl_uom.Enabled = False
                Me.ddl_currency.Enabled = False
                Me.txt_rate.Enabled = False
                Me.txt_efffrom.Enabled = False
                Me.txt_effto.Enabled = False
                Me.txt_tranno.Enabled = True

                'Me.GridView1.DataSource = Nothing
                'GridView1.DataBind()

                Me.txt_tranno.Text = ""
                Me.lbl_status.Text = ""
                Me.txt_rate.Text = ""
                'Me.txt_main_fibre_desc.Text = ""
                'Me.txt_sub_fibre_desc.Text = ""
                Me.txt_efffrom.Text = Now().Date
                Me.txt_effto.Text = Now().Date

                'Me.lbt_add.Enabled = False
                'Me.lbt_view.Enabled = False
                'Me.lbt_modify.Enabled = False
                'Me.lbt_authorize.Enabled = True
                'Me.lbt_delete.Enabled = False
                'Me.lbt_close.Enabled = True

                Me.imb_tran_fetch.Enabled = True
                'Me.imb_insertrow.Enabled = False
                ' Me.imb_deleterow.Enabled = False

                Me.imb_top.Enabled = True
                Me.imb_next.Enabled = True
                Me.imb_previous.Enabled = True
                Me.imb_last.Enabled = True

                'Me.lbt_add.CssClass = "ButtonDisable"
                'Me.lbt_view.CssClass = "ButtonDisable"
                'Me.lbt_modify.CssClass = "ButtonDisable"
                'Me.lbt_close.CssClass = "ButtonDisable"
                'Me.lbt_authorize.CssClass = "Buttonc"
                'Me.lbt_close.CssClass = "Buttonc"

                Me.lbt_authorize.Text = "UPDATE"
                'Me.lbt_close.Text = "CANCEL"  '' "UNDO"

            ElseIf lbt_authorize.Text = "UPDATE" Then

                Me.ddl_action.SelectedIndex = 5    ''  Set action in AUTHORIZE mode
                Me.lbt_apply_Click(sender, e)      ''  Execute APPLY button script through LinkButton1_Click event
                'Me.lbt_close_Click(sender, e)       ''  Execute EXIT button script

            End If

        End If


        If UCase(LTrim(RTrim(Me.ddl_action.Text))) = "SHORT CLOSE" Then

            If lbt_delete.Text = "DELETE" Then

                'Me.lbt_apply.Enabled = True

                Me.ddl_location.Enabled = False
                Me.ddl_main_fibre_code.Enabled = False
                Me.ddl_sub_fibre_code.Enabled = False
                Me.ddl_fibre_group.Enabled = False
                Me.ddl_rate_type.Enabled = False
                Me.ddl_uom.Enabled = False
                Me.ddl_currency.Enabled = False
                Me.txt_rate.Enabled = False
                Me.txt_efffrom.Enabled = False
                Me.txt_effto.Enabled = False
                Me.txt_tranno.Enabled = True

                'Me.GridView1.DataSource = Nothing
                'GridView1.DataBind()

                Me.txt_tranno.Text = ""
                Me.lbl_status.Text = ""
                Me.txt_rate.Text = ""
                'Me.txt_main_fibre_desc.Text = ""
                'Me.txt_sub_fibre_desc.Text = ""
                Me.txt_efffrom.Text = Now().Date
                Me.txt_effto.Text = Now().Date

                'Me.lbt_add.Enabled = False
                'Me.lbt_view.Enabled = False
                'Me.lbt_modify.Enabled = False
                'Me.lbt_delete.Enabled = True
                'Me.lbt_authorize.Enabled = False
                'Me.lbt_close.Enabled = True

                Me.imb_tran_fetch.Enabled = True
                'Me.imb_insertrow.Enabled = False
                '  Me.imb_deleterow.Enabled = False

                Me.imb_top.Enabled = True
                Me.imb_next.Enabled = True
                Me.imb_previous.Enabled = True
                Me.imb_last.Enabled = True

                Me.lbt_delete.Text = "UPDATE"
                'Me.lbt_close.Text = "CANCEL"   '' "UNDO"

            ElseIf lbt_delete.Text = "UPDATE" Then

                Me.ddl_action.SelectedIndex = 4    ''  Set action in SHORT CLOSE mode
                Me.lbt_apply_Click(sender, e)      ''  Execute APPLY button script through LinkButton1_Click event
                ''Me.lnk_exit_Click(sender, e)       ''  Execute EXIT button script

            End If

        End If

    End Sub

    Protected Sub lbt_apply_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbt_apply.Click

        Dim same As String = "N"
        Dim greater As String = "N"
        Dim sno1 As Integer = 0
        Dim sno2 As String = ""

        If LTrim(RTrim(Me.ddl_location.Text)) = "" Then
            FMsg.Message = "Pl. enter Location "
            FMsg.CssClass = "errormsg"
            FMsg.Display()
            Me.ddl_location.Focus()
            Exit Sub
        End If

        If LTrim(RTrim(Me.ddl_main_fibre_code.Text)) = "" Then
            FMsg.Message = "Pl. enter Main Fibre Code "
            FMsg.CssClass = "errormsg"
            FMsg.Display()
            Me.ddl_main_fibre_code.Focus()
            Exit Sub
        End If

        If LTrim(RTrim(Me.ddl_sub_fibre_code.Text)) = "" Then
            FMsg.Message = "Pl. enter Sub Fibre Code "
            FMsg.CssClass = "errormsg"
            FMsg.Display()
            Me.ddl_sub_fibre_code.Focus()
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

        ''If Me.dtp_effdate.Value.Date < Now.Date Then
        ''    MsgBox("Back date entries are not allowed")
        ''    Me.txt_effdate.Focus()
        ''    Exit Sub
        ''End If


        ''If Me.dtp_expdate.Value.Date < Now.Date Then
        ''    MsgBox("Back date entries are not allowed")
        ''    Me.txt_expdate.Focus()
        ''    Exit Sub
        ''End If

        Dim efrom As Date
        Dim eto As Date

        sqlpass = "select convert(datetime,'" & Me.txt_efffrom.Text & "'),convert(datetime,'" & Me.txt_effto.Text & "') "

        obj.opencn()
        cmd = New SqlCommand(sqlpass, obj.cn)
        cmd.CommandTimeout = 0
        dr = cmd.ExecuteReader

        If dr.HasRows = True Then
            dr.Read()
            efrom = CDate(dr.Item(0)).Date
            eto = CDate(dr.Item(1)).Date
        Else
            FMsg.Message = "Something wromg in Eff./Exp. Date"
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

            sqlpass = "select tran_no,isnull(status,'') " & _
                    "from jct_costing_fibre_master " & _
                    "where location='" & LTrim(RTrim(Me.ddl_location.Text)) & "' " & _
                    "and main_fibre_code='" & LTrim(RTrim(Me.ddl_main_fibre_code.Text)) & "' " & _
                    "and sub_fibre_code='" & LTrim(RTrim(Me.ddl_sub_fibre_code.Text)) & "' " & _
                    "and rate_type='" & Left(LTrim(Me.ddl_rate_type.Text), 1) & "' " & _
                    "and left(ltrim(status),1)='O' " & _
                    "and upper(ltrim(rtrim(company_code)))='" & UCase(LTrim(RTrim(Session("companycode")))) & "'"

            cmd = New SqlCommand(sqlpass, obj.cn)
            dr = cmd.ExecuteReader

            If dr.HasRows = True Then
                dr.Read()
                FMsg.Message = "Tran.No. " & dr.Item(0) & " of above parameters already exists in OPEN status, Pl. first AUTHORIZE the Tran.No. "
                FMsg.CssClass = "errormsg"
                FMsg.Display()
                dr.Close()
                obj.closecn()
                Me.ddl_location.Focus()
                Exit Sub
            End If
            dr.Close()
            obj.closecn()


            obj.opencn()
            btran = obj.cn.BeginTransaction

            Try

                '--SERIAL NUMBER GENERATION
                sqlpass = "select isnull(count_value,0)+1,ltrim(rtrim(prefix))+" & _
                "case len(ltrim(rtrim(convert(char,isnull(count_value,0)+1)))) when 1 then '000'" & _
                "when 2 then '00' when 3 then '0' end + ltrim(rtrim(convert(char,isnull(count_value,0)+1))) " & _
                "+ltrim(rtrim(suffix)) from jct_costing_serial_number_master " & _
                "where type_code='FM' " & _
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


                sqlpass = "select top 1 convert(datetime,convert(char(11),eff_from)), " & _
                        "convert(datetime,convert(char(11),eff_to)), tran_no " & _
                        "from jct_costing_fibre_master " & _
                        "where location='" & LTrim(RTrim(Me.ddl_location.Text)) & "' " & _
                        "and main_fibre_code='" & LTrim(RTrim(Me.ddl_main_fibre_code.Text)) & "' " & _
                        "and sub_fibre_code='" & LTrim(RTrim(Me.ddl_sub_fibre_code.Text)) & "' " & _
                        "and rate_type='" & Left(LTrim(Me.ddl_rate_type.Text), 1) & "' " & _
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
                        FMsg.Message = "Back date entries are not allowed or Eff.From date already exists"
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

                    If greater = "N" Then

                        If same = "Y" Then
                            FMsg.Message = "Eff.From already exists for one day"
                            FMsg.CssClass = "errormsg"
                            FMsg.Display()
                            dr.Close()
                            obj.closecn()
                            Exit Sub
                        Else
                            sqlpass = "update jct_costing_fibre_master set eff_to=convert(datetime,'" & efrom & "')-1 " & _
                                    "where location='" & LTrim(RTrim(Me.ddl_location.Text)) & "' " & _
                                    "and main_fibre_code='" & LTrim(RTrim(Me.ddl_main_fibre_code.Text)) & "' " & _
                                    "and sub_fibre_code='" & LTrim(RTrim(Me.ddl_sub_fibre_code.Text)) & "' " & _
                                    "and rate_type='" & Left(LTrim(Me.ddl_rate_type.Text), 1) & "' " & _
                                    "and tran_no='" & LTrim(RTrim(dr.Item(2))) & "' " & _
                                    "and company_code='" & UCase(LTrim(RTrim(Session("companycode")))) & "' "
                        End If

                    End If


                    dr.Close()

                    cmd = New SqlCommand(sqlpass, obj.cn)
                    cmd.CommandTimeout = 0
                    cmd.Transaction = btran
                    cmd.ExecuteNonQuery()


                End If  '' end of If dr.HasRows = True Then

                dr.Close()

                Dim i As Integer = 0

                'For i = 0 To GridView1.Rows.Count - 1

                sqlpass = "exec jct_costing_fibre_master_entry '" & _
                            LTrim(RTrim(Me.ddl_action.Text)) & "'," & _
                            sno1 & ",'" & Now() & "','" & _
                            UCase(LTrim(RTrim(Me.txt_tranno.Text))) & "','" & _
                            UCase(LTrim(RTrim(Me.ddl_location.Text))) & "','" & _
                            UCase(LTrim(RTrim(Me.ddl_main_fibre_code.Text))) & "','" & _
                            LTrim(RTrim(Me.txt_main_fibre_desc.Text)) & "','" & _
                            UCase(LTrim(RTrim(Me.ddl_sub_fibre_code.Text))) & "','" & _
                            LTrim(RTrim(Me.txt_sub_fibre_desc.Text)) & "','" & _
                            UCase(LTrim(RTrim(Me.ddl_fibre_group.Text))) & "','" & _
                            Left(LTrim(RTrim(Me.ddl_rate_type.Text)), 1) & "'," & _
                            LTrim(RTrim(Me.txt_rate.Text)) & ",'" & _
                            LTrim(RTrim(Me.ddl_uom.Text)) & "','" & _
                            LTrim(RTrim(Me.ddl_currency.Text)) & "','" & _
                            efrom & "','" & _
                            eto & "','" & _
                            UCase(LTrim(RTrim(Session("empcode")))) & "','" & _
                            UCase(LTrim(RTrim(Session("companycode")))) & "'"

                'CType(GridView1.Rows(i).FindControl("ddl_main_fibre_code"), DropDownList).SelectedItem.Text & "','" & _
                'CType(GridView1.Rows(i).FindControl("ddl_sub_fibre_code"), DropDownList).SelectedItem.Text & "'," & _
                'CType(GridView1.Rows(i).FindControl("txt_fibre_percent"), TextBox).Text & ",'" & _

                cmd = New SqlCommand(sqlpass, obj.cn)
                cmd.CommandTimeout = 0
                cmd.Transaction = btran
                cmd.ExecuteNonQuery()

                'Next


                'Else  '' else of If dr.HasRows = True Then

                'FMsg.Message = "Invalid Count Code "
                'FMsg.CssClass = "errormsg"
                'FMsg.Display()
                'dr.Close()
                'obj.closecn()
                'Me.txt_countcode.Focus()
                'Exit Sub

                'End If  '' end of If dr.HasRows = True Then

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
                Me.lbt_close_Click(sender, e)       ''  Execute EXIT button script
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

            If UCase(LTrim(RTrim(Me.ddl_action.Text))) = "CANCEL" Or UCase(LTrim(RTrim(Me.ddl_action.Text))) = "SHORT CLOSE" Then

                obj.opencn()

                sqlpass = "select tran_no,isnull(status,'') " & _
                        "from jct_costing_fibre_master " & _
                        "where tran_no<>'" & UCase(LTrim(RTrim(Me.txt_tranno.Text))) & "' " & _
                        "and location='" & LTrim(RTrim(Me.ddl_location.Text)) & "' " & _
                        "and main_fibre_code='" & LTrim(RTrim(Me.ddl_main_fibre_code.Text)) & "' " & _
                        "and sub_fibre_code='" & LTrim(RTrim(Me.ddl_sub_fibre_code.Text)) & "' " & _
                        "and rate_type='" & Left(LTrim(Me.ddl_rate_type.Text), 1) & "' " & _
                        "and eff_from>='" & CDate(Me.txt_efffrom.Text).Date & "' " & _
                        "and status not in ('C','S') " & _
                        "and company_code='" & UCase(LTrim(RTrim(Session("companycode")))) & "'"

                cmd = New SqlCommand(sqlpass, obj.cn)
                dr = cmd.ExecuteReader

                If dr.HasRows = True Then
                    dr.Read()
                    FMsg.Message = "Pl. first delete last active transaction of above parameters "
                    FMsg.CssClass = "errormsg"
                    FMsg.Display()
                    dr.Close()
                    obj.closecn()
                    Me.txt_tranno.Focus()
                    Exit Sub
                End If
                dr.Close()
                obj.closecn()

            End If


            obj.opencn()

            sqlpass = "select tran_no,isnull(status,'') " & _
                    "from jct_costing_fibre_master " & _
                    "where tran_no<>'" & UCase(LTrim(RTrim(Me.txt_tranno.Text))) & "' " & _
                    "and location='" & LTrim(RTrim(Me.ddl_location.Text)) & "' " & _
                    "and main_fibre_code='" & LTrim(RTrim(Me.ddl_main_fibre_code.Text)) & "' " & _
                    "and sub_fibre_code='" & LTrim(RTrim(Me.ddl_sub_fibre_code.Text)) & "' " & _
                    "and rate_type='" & Left(LTrim(Me.ddl_rate_type.Text), 1) & "' " & _
                    "and left(status,1)='O' " & _
                    "and company_code='" & UCase(LTrim(RTrim(Session("companycode")))) & "'"

            cmd = New SqlCommand(sqlpass, obj.cn)
            dr = cmd.ExecuteReader

            If dr.HasRows = True Then
                dr.Read()
                FMsg.Message = "Tran.No. " & dr.Item(0) & " of above count code already exists in OPEN status, Pl. first AUTHORIZE the Tran.No. "
                FMsg.CssClass = "errormsg"
                FMsg.Display()
                dr.Close()
                obj.closecn()
                Me.txt_tranno.Focus()
                Exit Sub
            End If
            dr.Close()
            obj.closecn()


            obj.opencn()
            btran = obj.cn.BeginTransaction

            Try

                ''sqlpass = "select case isnull(status,'') when 'O' then 'OPEN' when 'A' then 'AUTHORIZE' when 'C' then 'CANCEL' when 'S' then 'SHORT CLOSE' when 'F' then 'FINISH' end " & _
                sqlpass = "select case isnull(a.status,'') when 'O' then 'OPEN' when 'A' then 'AUTHORIZE' when 'C' then 'CANCEL' when 'S' then 'DELETE' when 'F' then 'FINISH' end " & _
                    "from jct_costing_fibre_master a " & _
                    "where location='" & LTrim(RTrim(Me.ddl_location.Text)) & "' " & _
                    "and a.tran_no='" & UCase(LTrim(RTrim(Me.txt_tranno.Text))) & "' " & _
                    "and a.company_code='" & UCase(LTrim(RTrim(Session("companycode")))) & "'"

                cmd = New SqlCommand(sqlpass, obj.cn)
                cmd.Transaction = btran
                dr = cmd.ExecuteReader

                If dr.HasRows = True Then
                    dr.Read()

                    ''If LTrim(RTrim(dr.Item(0))) = "CANCEL" Or LTrim(RTrim(dr.Item(0))) = "SHORT CLOSE" Or LTrim(RTrim(dr.Item(0))) = "AUTHORIZE" Then
                    If LTrim(RTrim(dr.Item(0))) = "CANCEL" Or LTrim(RTrim(dr.Item(0))) = "DELETE" Or LTrim(RTrim(dr.Item(0))) = "AUTHORIZE" Then
                        ''If (UCase(LTrim(RTrim(dr.Item(0)))) = UCase(LTrim(RTrim(Me.ddl_action.Text)))) Or ((UCase(LTrim(RTrim(dr.Item(0)))) = "CANCEL" Or UCase(LTrim(RTrim(dr.Item(0)))) = "SHORT CLOSE") And (UCase(LTrim(RTrim(Me.ddl_action.Text))) = "MODIFY" Or UCase(LTrim(RTrim(Me.ddl_action.Text))) = "AUTHORIZE" Or UCase(LTrim(RTrim(Me.ddl_action.Text))) = "CANCEL" Or UCase(LTrim(RTrim(Me.ddl_action.Text))) = "SHORT CLOSE" Or UCase(LTrim(RTrim(Me.ddl_action.Text))) = "FREEZE")) Or (UCase(LTrim(RTrim(dr.Item(0)))) = "OPEN" And (UCase(LTrim(RTrim(Me.ddl_action.Text))) = "ACTUAL OUT" Or UCase(LTrim(RTrim(Me.ddl_action.Text))) = "FREEZE")) Or (UCase(LTrim(RTrim(dr.Item(0)))) = "AUTHORIZE" And UCase(LTrim(RTrim(Me.ddl_action.Text))) = "CANCEL") Or (UCase(LTrim(RTrim(dr.Item(0)))) <> "OPEN" And UCase(LTrim(RTrim(Me.ddl_action.Text))) = "MODIFY") Or ((UCase(LTrim(RTrim(Me.ddl_action.Text))) = "CANCEL" Or UCase(LTrim(RTrim(Me.ddl_action.Text))) = "AUTHORIZE") And UCase(LTrim(RTrim(dr.Item(0)))) = "FREEZE") Then
                        If (UCase(LTrim(RTrim(dr.Item(0)))) = UCase(LTrim(RTrim(Me.ddl_action.Text)))) Or ((UCase(LTrim(RTrim(dr.Item(0)))) = "CANCEL" Or UCase(LTrim(RTrim(dr.Item(0)))) = "DELETE") And (UCase(LTrim(RTrim(Me.ddl_action.Text))) = "MODIFY" Or UCase(LTrim(RTrim(Me.ddl_action.Text))) = "AUTHORIZE" Or UCase(LTrim(RTrim(Me.ddl_action.Text))) = "CANCEL" Or UCase(LTrim(RTrim(Me.ddl_action.Text))) = "SHORT CLOSE" Or UCase(LTrim(RTrim(Me.ddl_action.Text))) = "FREEZE")) Or (UCase(LTrim(RTrim(dr.Item(0)))) = "OPEN" And (UCase(LTrim(RTrim(Me.ddl_action.Text))) = "ACTUAL OUT" Or UCase(LTrim(RTrim(Me.ddl_action.Text))) = "FREEZE")) Or (UCase(LTrim(RTrim(dr.Item(0)))) = "AUTHORIZE" And UCase(LTrim(RTrim(Me.ddl_action.Text))) = "CANCEL") Or (UCase(LTrim(RTrim(dr.Item(0)))) <> "OPEN" And UCase(LTrim(RTrim(Me.ddl_action.Text))) = "MODIFY") Or ((UCase(LTrim(RTrim(Me.ddl_action.Text))) = "CANCEL" Or UCase(LTrim(RTrim(Me.ddl_action.Text))) = "AUTHORIZE") And UCase(LTrim(RTrim(dr.Item(0)))) = "FREEZE") Then
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
                        "from jct_costing_fibre_master " & _
                        "where location='" & LTrim(RTrim(Me.ddl_location.Text)) & "' " & _
                        "and tran_no='" & LTrim(RTrim(Me.txt_tranno.Text)) & "' " & _
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


                    ''-- check based on eff.from - eff.to date
                    sqlpass = "select top 1 convert(datetime,convert(char(11),eff_from)), " & _
                            "convert(datetime,convert(char(11),eff_to)), tran_no " & _
                            "from jct_costing_fibre_master " & _
                            "where location='" & LTrim(RTrim(Me.ddl_location.Text)) & "' " & _
                            "and main_fibre_code='" & LTrim(RTrim(Me.ddl_main_fibre_code.Text)) & "' " & _
                            "and sub_fibre_code='" & LTrim(RTrim(Me.ddl_sub_fibre_code.Text)) & "' " & _
                            "and rate_type='" & Left(LTrim(Me.ddl_rate_type.Text), 1) & "' " & _
                            "and tran_no <> '" & LTrim(RTrim(Me.txt_tranno.Text)) & "' " & _
                            "and ltrim(rtrim(company_code))='" & UCase(LTrim(RTrim(Session("companycode")))) & "' " & _
                            "order by eff_to desc"

                    cmd = New SqlCommand(sqlpass, obj.cn)
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
                            FMsg.Message = "Back date entries are not allowed or Eff.From date already exists"
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

                        If greater = "N" Then

                            If same = "Y" Then
                                FMsg.Message = "Eff.From already exists for one day"
                                FMsg.CssClass = "errormsg"
                                FMsg.Display()
                                dr.Close()
                                obj.closecn()
                                Exit Sub
                            Else
                                sqlpass = "update jct_costing_fibre_master set eff_to=convert(datetime,'" & efrom & "')-1 " & _
                                        "from jct_costing_fibre_master " & _
                                        "where location='" & LTrim(RTrim(Me.ddl_location.Text)) & "' " & _
                                        "and main_fibre_code='" & LTrim(RTrim(Me.ddl_main_fibre_code.Text)) & "' " & _
                                        "and sub_fibre_code='" & LTrim(RTrim(Me.ddl_sub_fibre_code.Text)) & "' " & _
                                        "and rate_type='" & Left(LTrim(Me.ddl_rate_type.Text), 1) & "' " & _
                                        "and tran_no='" & LTrim(RTrim(dr.Item(2))) & "' " & _
                                        "and company_code='" & UCase(LTrim(RTrim(Session("companycode")))) & "' "
                            End If

                        End If

                        dr.Close()

                        cmd = New SqlCommand(sqlpass, obj.cn)
                        cmd.Transaction = btran
                        cmd.ExecuteNonQuery()


                    End If  '' end of If dr.HasRows = True Then

                    dr.Close()

                    sqlpass = "delete from jct_costing_fibre_master " & _
                                "where location='" & LTrim(RTrim(Me.ddl_location.Text)) & "' " & _
                                "and tran_no='" & LTrim(RTrim(Me.txt_tranno.Text)) & "' " & _
                                "and left(status,1)='O' " & _
                                "and company_code='" & UCase(LTrim(RTrim(Session("companycode")))) & "' "

                    cmd = New SqlCommand(sqlpass, obj.cn)
                    cmd.Transaction = btran
                    cmd.ExecuteNonQuery()

                End If


                ''REASON FOR CANCEL/SHORT CLOSE
                Dim reason As String = ""

                'If UCase(LTrim(RTrim(Me.ddl_action.Text))) = "CANCEL" Or UCase(LTrim(RTrim(Me.ddl_action.Text))) = "SHORT CLOSE" Then
                '    While reason = ""
                '        reason = (InputBox("Enter Reason for " + UCase(LTrim(RTrim(Me.ddl_action.Text))), " Tran. No.", ""))
                '    End While
                'End If


                ''STORE HERE EACH ACTIVITY IN ACTION TABLE
                sqlpass = "insert into jct_costing_action_detail (count_code,tran_no,date,detail,userid,hostname,company_code) " & _
                        "Select '" & LTrim(RTrim(Me.ddl_main_fibre_code.Text)) & "'+'-'+'" & LTrim(RTrim(Me.ddl_sub_fibre_code.Text)) & "','" & Me.txt_tranno.Text & "',getdate(),'" & _
                        LTrim(RTrim(Me.ddl_action.Text)) & "'+'-'+'" & reason & "','" & _
                        Session("empcode") & "',LTrim(RTrim(host_name())) ,'" & _
                        UCase(LTrim(RTrim(Session("companycode")))) & "' "

                cmd = New SqlCommand(sqlpass, obj.cn)
                cmd.Transaction = btran
                cmd.ExecuteNonQuery()



                ''ENTRY THROUGH SQL PROCEDURE

                Dim i As Integer = 0

                'For i = 0 To GridView1.Rows.Count - 1

                sqlpass = "exec jct_costing_fibre_master_entry '" & _
                            LTrim(RTrim(Me.ddl_action.Text)) & "'," & _
                            sno1 & ",'" & sysdate & "','" & _
                            UCase(LTrim(RTrim(Me.txt_tranno.Text))) & "','" & _
                            UCase(LTrim(RTrim(Me.ddl_location.Text))) & "','" & _
                            UCase(LTrim(RTrim(Me.ddl_main_fibre_code.Text))) & "','" & _
                            LTrim(RTrim(Me.txt_main_fibre_desc.Text)) & "','" & _
                            UCase(LTrim(RTrim(Me.ddl_sub_fibre_code.Text))) & "','" & _
                            LTrim(RTrim(Me.txt_sub_fibre_desc.Text)) & "','" & _
                            UCase(LTrim(RTrim(Me.ddl_fibre_group.Text))) & "','" & _
                            Left(UCase(LTrim(RTrim(Me.ddl_rate_type.Text))), 1) & "'," & _
                            LTrim(RTrim(Me.txt_rate.Text)) & ",'" & _
                            LTrim(RTrim(Me.ddl_uom.Text)) & "','" & _
                            LTrim(RTrim(Me.ddl_currency.Text)) & "','" & _
                            efrom & "','" & _
                            eto & "','" & _
                            UCase(LTrim(RTrim(Session("empcode")))) & "','" & _
                            UCase(LTrim(RTrim(Session("companycode")))) & "'"

                If Val(Me.txt_rate.Text) > 0 Then
                    cmd = New SqlCommand(sqlpass, obj.cn)
                    cmd.Transaction = btran
                    cmd.ExecuteNonQuery()
                End If

                'Next

                btran.Commit()
                dr.Close()
                obj.closecn()

                ''''''''''Meaasage'''''''''''''
                FMsg.Message = "Success"
                FMsg.CssClass = "addmsg"
                FMsg.Display()
                '''''''''''''''''''''''''''''''

                If UCase(LTrim(RTrim(Me.ddl_action.Text))) = "CANCEL" Or UCase(LTrim(RTrim(Me.ddl_action.Text))) = "SHORT CLOSE" Then
                    Me.lbl_status.Text = "DELETE" 'UCase(LTrim(RTrim(Me.ddl_action.Text)))
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


        ''-----ReFill GridView1
        sqlpass = "exec jct_costing_fibre_master_fetch_all '" & _
        LTrim(RTrim(Me.ddl_action.Text)) & "','" & _
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

    Protected Sub lbt_view_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbt_view.Click

        Me.lbt_add.Text = "ADD"
        Me.lbt_modify.Text = "MODIFY"
        Me.lbt_view.Text = "VIEW"
        Me.lbt_authorize.Text = "AUTHORIZE"
        Me.lbt_delete.Text = "DELETE"
        Me.lbt_close.Text = "CLOSE"

        Me.ddl_action.SelectedIndex = 1
        Me.ddl_action_SelectedIndexChanged(sender, e)

    End Sub

    Protected Sub lbt_add_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbt_add.Click

        'Me.lbt_add.Text = "ADD"
        Me.lbt_modify.Text = "MODIFY"
        Me.lbt_view.Text = "VIEW"
        Me.lbt_authorize.Text = "AUTHORIZE"
        Me.lbt_delete.Text = "DELETE"
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
        Me.lbt_delete.Text = "DELETE"
        Me.lbt_close.Text = "CLOSE"

        'If Me.lbt_modify.Text = "MODIFY" Then

        Me.ddl_action.SelectedIndex = 2
        Me.ddl_action_SelectedIndexChanged(sender, e)

    End Sub

    Protected Sub lbt_delete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbt_delete.Click

        Me.lbt_add.Text = "ADD"
        Me.lbt_modify.Text = "MODIFY"
        Me.lbt_view.Text = "VIEW"
        Me.lbt_authorize.Text = "AUTHORIZE"
        'Me.lbt_delete.Text = "DELETE"
        Me.lbt_close.Text = "CLOSE"

        'If lbt_delete.Text = "DELETE" Then

        Me.ddl_action.SelectedIndex = 4
        ddl_action_SelectedIndexChanged(sender, e)

    End Sub

    Protected Sub lbt_authorize_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbt_authorize.Click

        Me.lbt_add.Text = "ADD"
        Me.lbt_modify.Text = "MODIFY"
        Me.lbt_view.Text = "VIEW"
        'Me.lbt_authorize.Text = "AUTHORIZE"
        Me.lbt_delete.Text = "DELETE"
        Me.lbt_close.Text = "CLOSE"

        'If lbt_authorize.Text = "AUTHORIZE" Then

        Me.ddl_action.SelectedIndex = 5
        Me.ddl_action_SelectedIndexChanged(sender, e)

    End Sub

    Protected Sub lbt_close_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbt_close.Click

        Me.lbt_add.Text = "ADD"
        Me.lbt_modify.Text = "MODIFY"
        Me.lbt_view.Text = "VIEW"
        Me.lbt_authorize.Text = "AUTHORIZE"
        Me.lbt_delete.Text = "DELETE"
        Me.lbt_close.Text = "CLOSE"

        Me.Dispose()
        Response.Redirect("default.aspx")

    End Sub

    Protected Sub imb_close_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imb_close.Click

        Me.Dispose()
        Response.Redirect("default.aspx")

    End Sub

    Protected Sub ddl_main_fibre_code_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl_main_fibre_code.SelectedIndexChanged

        ''-----Fill Main Fibre Code Desc. Text Box
        sqlpass = "select distinct top 1 main_fibre_desc, eff_to from jct_costing_fibre_type_master " & _
                "where main_fibre_code='" & Me.ddl_main_fibre_code.Text & "' " & _
                "and company_code='" & UCase(LTrim(RTrim(Session("companycode")))) & "' " & _
                "order by eff_to desc "

        obj.opencn()
        cmd = New SqlCommand(sqlpass, obj.cn)
        dr = cmd.ExecuteReader

        If dr.HasRows = True Then
            dr.Read()
            Me.txt_main_fibre_desc.Text = dr.Item(0)
        Else
            Me.txt_main_fibre_desc.Text = ""
        End If
        dr.Close()
        obj.closecn()

    End Sub

    Protected Sub ddl_sub_fibre_code_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl_sub_fibre_code.SelectedIndexChanged

        ''-----Fill Sub Fibre Code Desc. Text Box
        sqlpass = "select distinct top 1 sub_fibre_desc, eff_to from jct_costing_fibre_type_master " & _
                "where sub_fibre_code='" & Me.ddl_sub_fibre_code.Text & "' " & _
                "and company_code='" & UCase(LTrim(RTrim(Session("companycode")))) & "' " & _
                "order by eff_to desc "

        obj.opencn()
        cmd = New SqlCommand(sqlpass, obj.cn)
        dr = cmd.ExecuteReader

        If dr.HasRows = True Then
            dr.Read()
            Me.txt_sub_fibre_desc.Text = dr.Item(0)
        Else
            Me.txt_sub_fibre_desc.Text = ""
        End If
        dr.Close()
        obj.closecn()

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
            sqlpass = "select case isnull(a.status,'') when 'O' then 'OPEN' when 'A' then 'AUTHORIZE' when 'C' then 'CANCEL' when 'S' then 'DELETE' when 'F' then 'FINISH' end " & _
                "from jct_costing_fibre_master a " & _
                "where a.tran_no='" & UCase(LTrim(RTrim(Me.txt_tranno.Text))) & "' " & _
                "and a.company_code='" & UCase(LTrim(RTrim(Session("companycode")))) & "'"

            obj.opencn()
            cmd = New SqlCommand(sqlpass, obj.cn)
            dr = cmd.ExecuteReader

            If dr.HasRows = True Then
                dr.Read()

                ' ''If LTrim(RTrim(dr.Item(0))) = "CANCEL" Or LTrim(RTrim(dr.Item(0))) = "SHORT CLOSE" Or LTrim(RTrim(dr.Item(0))) = "AUTHORIZE" Then
                'If LTrim(RTrim(dr.Item(0))) = "CANCEL" Or LTrim(RTrim(dr.Item(0))) = "DELETE" Or LTrim(RTrim(dr.Item(0))) = "AUTHORIZE" Then
                '    ''If (UCase(LTrim(RTrim(dr.Item(0)))) = UCase(LTrim(RTrim(Me.ddl_action.Text)))) Or ((UCase(LTrim(RTrim(dr.Item(0)))) = "CANCEL" Or UCase(LTrim(RTrim(dr.Item(0)))) = "SHORT CLOSE") And (UCase(LTrim(RTrim(Me.ddl_action.Text))) = "MODIFY" Or UCase(LTrim(RTrim(Me.ddl_action.Text))) = "AUTHORIZE" Or UCase(LTrim(RTrim(Me.ddl_action.Text))) = "CANCEL" Or UCase(LTrim(RTrim(Me.ddl_action.Text))) = "SHORT CLOSE" Or UCase(LTrim(RTrim(Me.ddl_action.Text))) = "FREEZE")) Or (UCase(LTrim(RTrim(dr.Item(0)))) = "OPEN" And (UCase(LTrim(RTrim(Me.ddl_action.Text))) = "ACTUAL OUT" Or UCase(LTrim(RTrim(Me.ddl_action.Text))) = "FREEZE")) Or (UCase(LTrim(RTrim(dr.Item(0)))) = "AUTHORIZE" And UCase(LTrim(RTrim(Me.ddl_action.Text))) = "CANCEL") Or (UCase(LTrim(RTrim(dr.Item(0)))) <> "OPEN" And UCase(LTrim(RTrim(Me.ddl_action.Text))) = "MODIFY") Or ((UCase(LTrim(RTrim(Me.ddl_action.Text))) = "CANCEL" Or UCase(LTrim(RTrim(Me.ddl_action.Text))) = "AUTHORIZE") And UCase(LTrim(RTrim(dr.Item(0)))) = "FREEZE") Then
                '    If (UCase(LTrim(RTrim(dr.Item(0)))) = UCase(LTrim(RTrim(Me.ddl_action.Text)))) Or ((UCase(LTrim(RTrim(dr.Item(0)))) = "CANCEL" Or UCase(LTrim(RTrim(dr.Item(0)))) = "DELETE") And (UCase(LTrim(RTrim(Me.ddl_action.Text))) = "MODIFY" Or UCase(LTrim(RTrim(Me.ddl_action.Text))) = "AUTHORIZE" Or UCase(LTrim(RTrim(Me.ddl_action.Text))) = "CANCEL" Or UCase(LTrim(RTrim(Me.ddl_action.Text))) = "SHORT CLOSE" Or UCase(LTrim(RTrim(Me.ddl_action.Text))) = "FREEZE")) Or (UCase(LTrim(RTrim(dr.Item(0)))) = "OPEN" And (UCase(LTrim(RTrim(Me.ddl_action.Text))) = "ACTUAL OUT" Or UCase(LTrim(RTrim(Me.ddl_action.Text))) = "FREEZE")) Or (UCase(LTrim(RTrim(dr.Item(0)))) = "AUTHORIZE" And UCase(LTrim(RTrim(Me.ddl_action.Text))) = "CANCEL") Or (UCase(LTrim(RTrim(dr.Item(0)))) <> "OPEN" And UCase(LTrim(RTrim(Me.ddl_action.Text))) = "MODIFY") Or ((UCase(LTrim(RTrim(Me.ddl_action.Text))) = "CANCEL" Or UCase(LTrim(RTrim(Me.ddl_action.Text))) = "AUTHORIZE") And UCase(LTrim(RTrim(dr.Item(0)))) = "FREEZE") Then
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
                Me.GridView1.DataSource = Nothing
                GridView1.DataBind()
                Me.lbl_status.Text = ""
                Me.txt_efffrom.Text = Now()
                Me.txt_effto.Text = Now()
                Me.txt_tranno.Focus()
                dr.Close()
                obj.closecn()
                Exit Sub
            End If
            'me.lbl_status.Text = dr.Item(0)
            'dr.Close()


            sqlpass = "select a.tran_no, a.location, " & _
                    "a.main_fibre_code, a.main_fibre_desc, a.sub_fibre_code, a.sub_fibre_desc, " & _
                    "a.fibre_group, a.rate_type, a.fibre_rate, a.fibre_uom, a.currency_code, " & _
                    "convert(varchar(11),a.eff_from,101) 'eff_from', " & _
                    "convert(varchar(11),a.eff_to,101) 'eff_to', " & _
                    "case isnull(a.status,'') when 'O' then 'OPEN' when 'A' then 'AUTHORIZE' " & _
                    "when 'C' then 'CANCEL' when 'S' then 'SHORT CLOSE' end 'status' " & _
                    "from jct_costing_fibre_master a " & _
                    "where a.tran_no='" & LTrim(RTrim(Me.txt_tranno.Text)) & "' " & _
                    "/*and a.status not in ('C','S')*/ " & _
                    "and a.company_code='" & UCase(LTrim(RTrim(Session("companycode")))) & "' " & _
                    "order by a.location, a.main_fibre_code, a.sub_fibre_code "

            obj.opencn()
            cmd = New SqlCommand(sqlpass, obj.cn)
            dr = cmd.ExecuteReader

            If dr.HasRows = True Then
                dr.Read()
                Me.ddl_location.Text = dr.Item(1)
                Me.ddl_main_fibre_code.Text = dr.Item(2)
                Me.txt_main_fibre_desc.Text = dr.Item(3)
                Me.ddl_sub_fibre_code.Text = dr.Item(4)
                Me.txt_sub_fibre_desc.Text = dr.Item(5)
                Me.ddl_fibre_group.Text = dr.Item(6)
                If dr.Item(7) = "B" Then
                    Me.ddl_rate_type.Text = "BOOK"
                Else
                    Me.ddl_rate_type.Text = "MARKET"
                End If
                Me.txt_rate.Text = dr.Item(8)
                Me.ddl_uom.Text = dr.Item(9)
                Me.ddl_currency.Text = dr.Item(10)
                Me.txt_efffrom.Text = dr.Item(11)
                Me.txt_effto.Text = dr.Item(12)
                Me.lbl_status.Text = dr.Item(13)

                dr.Close()
                obj.closecn()

                ''-----ReFill GridView1
                'sqlpass = "exec jct_costing_fibre_master_fetch '" & LTrim(RTrim(Me.ddl_action.Text)) & "','" & _
                '            LTrim(RTrim(Me.ddl_location.Text)) & "','" & _
                '            LTrim(RTrim(Me.ddl_main_fibre_code.Text)) & "','" & _
                '            LTrim(RTrim(Me.ddl_sub_fibre_code.Text)) & "','" & _
                '            Left(LTrim(RTrim(Me.ddl_rate_type.Text)), 1) & "','" & _
                '            LTrim(RTrim(Me.txt_tranno.Text)) & "','" & _
                '            UCase(LTrim(RTrim(Session("empcode")))) & "','" & _
                '            UCase(LTrim(RTrim(Session("companycode")))) & "' "

                sqlpass = "exec jct_costing_fibre_master_fetch_all '" & _
                            LTrim(RTrim(Me.ddl_action.Text)) & "','" & _
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

            End If

            Me.txt_tranno.Focus()

        End If ''end of MODIFY/CANCEL/SHORT CLOSE/AUTHORIZE

    End Sub

    Protected Sub imb_top_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imb_top.Click

        If Me.ddl_action.Text <> "ADD" Then

            If LTrim(RTrim(Me.ddl_location.Text)) = "" Then
                FMsg.Message = "Pl. select Location "
                FMsg.CssClass = "errormsg"
                FMsg.Display()
                Me.ddl_location.Focus()
                Exit Sub
            End If

            If LTrim(RTrim(Me.ddl_main_fibre_code.Text)) = "" Then
                FMsg.Message = "Pl. select Main Fibre Code "
                FMsg.CssClass = "errormsg"
                FMsg.Display()
                Me.ddl_main_fibre_code.Focus()
                Exit Sub
            End If

            If LTrim(RTrim(Me.ddl_sub_fibre_code.Text)) = "" Then
                FMsg.Message = "Pl. select Sub Fibre Code "
                FMsg.CssClass = "errormsg"
                FMsg.Display()
                Me.ddl_sub_fibre_code.Focus()
                Exit Sub
            End If

            If LTrim(RTrim(Me.ddl_rate_type.Text)) = "" Then
                FMsg.Message = "Pl. select Rate Type "
                FMsg.CssClass = "errormsg"
                FMsg.Display()
                Me.ddl_rate_type.Focus()
                Exit Sub
            End If

            sqlpass = "select top 1 a.tran_no, a.location, " & _
                    "a.main_fibre_code, a.main_fibre_desc, a.sub_fibre_code, a.sub_fibre_desc, " & _
                    "a.fibre_group, a.rate_type, a.fibre_rate, a.fibre_uom, a.currency_code, " & _
                    "convert(varchar(11),a.eff_from,101) 'eff_from', " & _
                    "convert(varchar(11),a.eff_to,101) 'eff_to', " & _
                    "case isnull(a.status,'') when 'O' then 'OPEN' when 'A' then 'AUTHORIZE' " & _
                    "when 'C' then 'CANCEL' when 'S' then 'SHORT CLOSE' end 'status' " & _
                    "from jct_costing_fibre_master a " & _
                    "where a.location='" & LTrim(RTrim(Me.ddl_location.Text)) & "' " & _
                    "and a.main_fibre_code='" & LTrim(RTrim(Me.ddl_main_fibre_code.Text)) & "' " & _
                    "and a.sub_fibre_code='" & LTrim(RTrim(Me.ddl_sub_fibre_code.Text)) & "' " & _
                    "and a.rate_type='" & Left(LTrim(RTrim(Me.ddl_rate_type.Text)), 1) & "' " & _
                    "/*and a.status not in ('C','S')*/ " & _
                    "and a.company_code='" & UCase(LTrim(RTrim(Session("companycode")))) & "' " & _
                    "order by a.location, a.main_fibre_code, a.sub_fibre_code, a.rate_type, a.system_date "

            obj.opencn()
            cmd = New SqlCommand(sqlpass, obj.cn)
            dr = cmd.ExecuteReader

            If dr.HasRows = True Then
                dr.Read()
                Me.txt_tranno.Text = dr.Item(0)
                Me.ddl_location.Text = dr.Item(1)
                Me.ddl_main_fibre_code.Text = dr.Item(2)
                Me.txt_main_fibre_desc.Text = dr.Item(3)
                Me.ddl_sub_fibre_code.Text = dr.Item(4)
                Me.txt_sub_fibre_desc.Text = dr.Item(5)
                Me.ddl_fibre_group.Text = dr.Item(6)
                If dr.Item(7) = "B" Then
                    Me.ddl_rate_type.Text = "BOOK"
                Else
                    Me.ddl_rate_type.Text = "MARKET"
                End If
                Me.txt_rate.Text = dr.Item(8)
                Me.ddl_uom.Text = dr.Item(9)
                Me.ddl_currency.Text = dr.Item(10)
                Me.txt_efffrom.Text = dr.Item(11)
                Me.txt_effto.Text = dr.Item(12)
                Me.lbl_status.Text = dr.Item(13)

                dr.Close()
                obj.closecn()

                ''-----ReFill GridView1
                'sqlpass = "exec jct_costing_fibre_master_fetch '" & LTrim(RTrim(Me.ddl_action.Text)) & "','" & _
                '            LTrim(RTrim(Me.ddl_location.Text)) & "','" & _
                '            LTrim(RTrim(Me.ddl_main_fibre_code.Text)) & "','" & _
                '            LTrim(RTrim(Me.ddl_sub_fibre_code.Text)) & "','" & _
                '            Left(LTrim(RTrim(Me.ddl_rate_type.Text)), 1) & "','" & _
                '            LTrim(RTrim(Me.txt_tranno.Text)) & "','" & _
                '            UCase(LTrim(RTrim(Session("empcode")))) & "','" & _
                '            UCase(LTrim(RTrim(Session("companycode")))) & "' "

                sqlpass = "exec jct_costing_fibre_master_fetch_all '" & _
                        LTrim(RTrim(Me.ddl_action.Text)) & "','" & _
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

            End If

                Me.txt_tranno.Focus()

            End If

    End Sub

    Protected Sub imb_next_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imb_next.Click

        If Me.ddl_action.Text <> "ADD" Then

            If LTrim(RTrim(Me.ddl_location.Text)) = "" Then
                FMsg.Message = "Pl. select Location "
                FMsg.CssClass = "errormsg"
                FMsg.Display()
                Me.ddl_location.Focus()
                Exit Sub
            End If

            If LTrim(RTrim(Me.ddl_main_fibre_code.Text)) = "" Then
                FMsg.Message = "Pl. select Main Fibre Code "
                FMsg.CssClass = "errormsg"
                FMsg.Display()
                Me.ddl_main_fibre_code.Focus()
                Exit Sub
            End If

            If LTrim(RTrim(Me.ddl_sub_fibre_code.Text)) = "" Then
                FMsg.Message = "Pl. select Sub Fibre Code "
                FMsg.CssClass = "errormsg"
                FMsg.Display()
                Me.ddl_sub_fibre_code.Focus()
                Exit Sub
            End If

            If LTrim(RTrim(Me.ddl_rate_type.Text)) = "" Then
                FMsg.Message = "Pl. select Rate Type "
                FMsg.CssClass = "errormsg"
                FMsg.Display()
                Me.ddl_rate_type.Focus()
                Exit Sub
            End If

            sqlpass = "select top 1 a.tran_no, a.location, " & _
                    "a.main_fibre_code, a.main_fibre_desc, a.sub_fibre_code, a.sub_fibre_desc, " & _
                    "a.fibre_group, a.rate_type, a.fibre_rate, a.fibre_uom, a.currency_code, " & _
                    "convert(varchar(11),a.eff_from,101) 'eff_from', " & _
                    "convert(varchar(11),a.eff_to,101) 'eff_to', " & _
                    "case isnull(a.status,'') when 'O' then 'OPEN' when 'A' then 'AUTHORIZE' " & _
                    "when 'C' then 'CANCEL' when 'S' then 'SHORT CLOSE' end 'status' " & _
                    "from jct_costing_fibre_master a " & _
                    "where a.location='" & LTrim(RTrim(Me.ddl_location.Text)) & "' " & _
                    "and a.main_fibre_code='" & LTrim(RTrim(Me.ddl_main_fibre_code.Text)) & "' " & _
                    "and a.sub_fibre_code='" & LTrim(RTrim(Me.ddl_sub_fibre_code.Text)) & "' " & _
                    "and a.rate_type='" & Left(LTrim(RTrim(Me.ddl_rate_type.Text)), 1) & "' " & _
                    "and a.tran_no>'" & LTrim(RTrim(Me.txt_tranno.Text)) & "' " & _
                    "/*and a.status not in ('C','S')*/ " & _
                    "and a.company_code='" & UCase(LTrim(RTrim(Session("companycode")))) & "' " & _
                    "order by a.location, a.main_fibre_code, a.sub_fibre_code, a.rate_type, a.system_date "

            obj.opencn()
            cmd = New SqlCommand(sqlpass, obj.cn)
            dr = cmd.ExecuteReader

            If dr.HasRows = True Then
                dr.Read()
                Me.txt_tranno.Text = dr.Item(0)
                Me.ddl_location.Text = dr.Item(1)
                Me.ddl_main_fibre_code.Text = dr.Item(2)
                Me.txt_main_fibre_desc.Text = dr.Item(3)
                Me.ddl_sub_fibre_code.Text = dr.Item(4)
                Me.txt_sub_fibre_desc.Text = dr.Item(5)
                Me.ddl_fibre_group.Text = dr.Item(6)
                If dr.Item(7) = "B" Then
                    Me.ddl_rate_type.Text = "BOOK"
                Else
                    Me.ddl_rate_type.Text = "MARKET"
                End If
                Me.txt_rate.Text = dr.Item(8)
                Me.ddl_uom.Text = dr.Item(9)
                Me.ddl_currency.Text = dr.Item(10)
                Me.txt_efffrom.Text = dr.Item(11)
                Me.txt_effto.Text = dr.Item(12)
                Me.lbl_status.Text = dr.Item(13)

                dr.Close()
                obj.closecn()

                ''-----ReFill GridView1
                'sqlpass = "exec jct_costing_fibre_master_fetch '" & LTrim(RTrim(Me.ddl_action.Text)) & "','" & _
                '            LTrim(RTrim(Me.ddl_location.Text)) & "','" & _
                '            LTrim(RTrim(Me.ddl_main_fibre_code.Text)) & "','" & _
                '            LTrim(RTrim(Me.ddl_sub_fibre_code.Text)) & "','" & _
                '            Left(LTrim(RTrim(Me.ddl_rate_type.Text)), 1) & "','" & _
                '            LTrim(RTrim(Me.txt_tranno.Text)) & "','" & _
                '            UCase(LTrim(RTrim(Session("empcode")))) & "','" & _
                '            UCase(LTrim(RTrim(Session("companycode")))) & "' "

                sqlpass = "exec jct_costing_fibre_master_fetch_all '" & _
                            LTrim(RTrim(Me.ddl_action.Text)) & "','" & _
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

            End If

            Me.txt_tranno.Focus()

        End If

    End Sub

    Protected Sub imb_previous_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imb_previous.Click

        If Me.ddl_action.Text <> "ADD" Then

            If LTrim(RTrim(Me.ddl_location.Text)) = "" Then
                FMsg.Message = "Pl. select Location "
                FMsg.CssClass = "errormsg"
                FMsg.Display()
                Me.ddl_location.Focus()
                Exit Sub
            End If

            If LTrim(RTrim(Me.ddl_main_fibre_code.Text)) = "" Then
                FMsg.Message = "Pl. select Main Fibre Code "
                FMsg.CssClass = "errormsg"
                FMsg.Display()
                Me.ddl_main_fibre_code.Focus()
                Exit Sub
            End If

            If LTrim(RTrim(Me.ddl_sub_fibre_code.Text)) = "" Then
                FMsg.Message = "Pl. select Sub Fibre Code "
                FMsg.CssClass = "errormsg"
                FMsg.Display()
                Me.ddl_sub_fibre_code.Focus()
                Exit Sub
            End If

            If LTrim(RTrim(Me.ddl_rate_type.Text)) = "" Then
                FMsg.Message = "Pl. select Rate Type "
                FMsg.CssClass = "errormsg"
                FMsg.Display()
                Me.ddl_rate_type.Focus()
                Exit Sub
            End If

            sqlpass = "select top 1 a.tran_no, a.location, " & _
                    "a.main_fibre_code, a.main_fibre_desc, a.sub_fibre_code, a.sub_fibre_desc, " & _
                    "a.fibre_group, a.rate_type, a.fibre_rate, a.fibre_uom, a.currency_code, " & _
                    "convert(varchar(11),a.eff_from,101) 'eff_from', " & _
                    "convert(varchar(11),a.eff_to,101) 'eff_to', " & _
                    "case isnull(a.status,'') when 'O' then 'OPEN' when 'A' then 'AUTHORIZE' " & _
                    "when 'C' then 'CANCEL' when 'S' then 'SHORT CLOSE' end 'status' " & _
                    "from jct_costing_fibre_master a " & _
                    "where a.location='" & LTrim(RTrim(Me.ddl_location.Text)) & "' " & _
                    "and a.main_fibre_code='" & LTrim(RTrim(Me.ddl_main_fibre_code.Text)) & "' " & _
                    "and a.sub_fibre_code='" & LTrim(RTrim(Me.ddl_sub_fibre_code.Text)) & "' " & _
                    "and a.rate_type='" & Left(LTrim(RTrim(Me.ddl_rate_type.Text)), 1) & "' " & _
                    "and a.tran_no<'" & LTrim(RTrim(Me.txt_tranno.Text)) & "' " & _
                    "/*and a.status not in ('C','S')*/ " & _
                    "and a.company_code='" & UCase(LTrim(RTrim(Session("companycode")))) & "' " & _
                    "order by a.location, a.main_fibre_code, a.sub_fibre_code, a.rate_type, a.system_date desc "

            obj.opencn()
            cmd = New SqlCommand(sqlpass, obj.cn)
            dr = cmd.ExecuteReader

            If dr.HasRows = True Then
                dr.Read()
                Me.txt_tranno.Text = dr.Item(0)
                Me.ddl_location.Text = dr.Item(1)
                Me.ddl_main_fibre_code.Text = dr.Item(2)
                Me.txt_main_fibre_desc.Text = dr.Item(3)
                Me.ddl_sub_fibre_code.Text = dr.Item(4)
                Me.txt_sub_fibre_desc.Text = dr.Item(5)
                Me.ddl_fibre_group.Text = dr.Item(6)
                If dr.Item(7) = "B" Then
                    Me.ddl_rate_type.Text = "BOOK"
                Else
                    Me.ddl_rate_type.Text = "MARKET"
                End If
                Me.txt_rate.Text = dr.Item(8)
                Me.ddl_uom.Text = dr.Item(9)
                Me.ddl_currency.Text = dr.Item(10)
                Me.txt_efffrom.Text = dr.Item(11)
                Me.txt_effto.Text = dr.Item(12)
                Me.lbl_status.Text = dr.Item(13)

                dr.Close()
                obj.closecn()

                ''-----ReFill GridView1
                'sqlpass = "exec jct_costing_fibre_master_fetch '" & LTrim(RTrim(Me.ddl_action.Text)) & "','" & _
                '            LTrim(RTrim(Me.ddl_location.Text)) & "','" & _
                '            LTrim(RTrim(Me.ddl_main_fibre_code.Text)) & "','" & _
                '            LTrim(RTrim(Me.ddl_sub_fibre_code.Text)) & "','" & _
                '            Left(LTrim(RTrim(Me.ddl_rate_type.Text)), 1) & "','" & _
                '            LTrim(RTrim(Me.txt_tranno.Text)) & "','" & _
                '            UCase(LTrim(RTrim(Session("empcode")))) & "','" & _
                '            UCase(LTrim(RTrim(Session("companycode")))) & "' "

                sqlpass = "exec jct_costing_fibre_master_fetch_all '" & _
                            LTrim(RTrim(Me.ddl_action.Text)) & "','" & _
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

            End If

            Me.txt_tranno.Focus()

        End If

    End Sub

    Protected Sub imb_last_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imb_last.Click

        If Me.ddl_action.Text <> "ADD" Then

            If LTrim(RTrim(Me.ddl_location.Text)) = "" Then
                FMsg.Message = "Pl. select Location "
                FMsg.CssClass = "errormsg"
                FMsg.Display()
                Me.ddl_location.Focus()
                Exit Sub
            End If

            If LTrim(RTrim(Me.ddl_main_fibre_code.Text)) = "" Then
                FMsg.Message = "Pl. select Main Fibre Code "
                FMsg.CssClass = "errormsg"
                FMsg.Display()
                Me.ddl_main_fibre_code.Focus()
                Exit Sub
            End If

            If LTrim(RTrim(Me.ddl_sub_fibre_code.Text)) = "" Then
                FMsg.Message = "Pl. select Sub Fibre Code "
                FMsg.CssClass = "errormsg"
                FMsg.Display()
                Me.ddl_sub_fibre_code.Focus()
                Exit Sub
            End If

            If LTrim(RTrim(Me.ddl_rate_type.Text)) = "" Then
                FMsg.Message = "Pl. select Rate Type "
                FMsg.CssClass = "errormsg"
                FMsg.Display()
                Me.ddl_rate_type.Focus()
                Exit Sub
            End If

            sqlpass = "select top 1 a.tran_no, a.location, " & _
                    "a.main_fibre_code, a.main_fibre_desc, a.sub_fibre_code, a.sub_fibre_desc, " & _
                    "a.fibre_group, a.rate_type, a.fibre_rate, a.fibre_uom, a.currency_code, " & _
                    "convert(varchar(11),a.eff_from,101) 'eff_from', " & _
                    "convert(varchar(11),a.eff_to,101) 'eff_to', " & _
                    "case isnull(a.status,'') when 'O' then 'OPEN' when 'A' then 'AUTHORIZE' " & _
                    "when 'C' then 'CANCEL' when 'S' then 'SHORT CLOSE' end 'status' " & _
                    "from jct_costing_fibre_master a " & _
                    "where a.location='" & LTrim(RTrim(Me.ddl_location.Text)) & "' " & _
                    "and a.main_fibre_code='" & LTrim(RTrim(Me.ddl_main_fibre_code.Text)) & "' " & _
                    "and a.sub_fibre_code='" & LTrim(RTrim(Me.ddl_sub_fibre_code.Text)) & "' " & _
                    "and a.rate_type='" & Left(LTrim(RTrim(Me.ddl_rate_type.Text)), 1) & "' " & _
                    "/*and a.status not in ('C','S')*/ " & _
                    "and a.company_code='" & UCase(LTrim(RTrim(Session("companycode")))) & "' " & _
                    "order by a.location, a.main_fibre_code, a.sub_fibre_code, a.rate_type, a.system_date desc "

            obj.opencn()
            cmd = New SqlCommand(sqlpass, obj.cn)
            dr = cmd.ExecuteReader

            If dr.HasRows = True Then
                dr.Read()
                Me.txt_tranno.Text = dr.Item(0)
                Me.ddl_location.Text = dr.Item(1)
                Me.ddl_main_fibre_code.Text = dr.Item(2)
                Me.txt_main_fibre_desc.Text = dr.Item(3)
                Me.ddl_sub_fibre_code.Text = dr.Item(4)
                Me.txt_sub_fibre_desc.Text = dr.Item(5)
                Me.ddl_fibre_group.Text = dr.Item(6)
                If dr.Item(7) = "B" Then
                    Me.ddl_rate_type.Text = "BOOK"
                Else
                    Me.ddl_rate_type.Text = "MARKET"
                End If
                Me.txt_rate.Text = dr.Item(8)
                Me.ddl_uom.Text = dr.Item(9)
                Me.ddl_currency.Text = dr.Item(10)
                Me.txt_efffrom.Text = dr.Item(11)
                Me.txt_effto.Text = dr.Item(12)
                Me.lbl_status.Text = dr.Item(13)

                dr.Close()
                obj.closecn()

                ''-----ReFill GridView1
                'sqlpass = "exec jct_costing_fibre_master_fetch '" & LTrim(RTrim(Me.ddl_action.Text)) & "','" & _
                '            LTrim(RTrim(Me.ddl_location.Text)) & "','" & _
                '            LTrim(RTrim(Me.ddl_main_fibre_code.Text)) & "','" & _
                '            LTrim(RTrim(Me.ddl_sub_fibre_code.Text)) & "','" & _
                '            Left(LTrim(RTrim(Me.ddl_rate_type.Text)), 1) & "','" & _
                '            LTrim(RTrim(Me.txt_tranno.Text)) & "','" & _
                '            UCase(LTrim(RTrim(Session("empcode")))) & "','" & _
                '            UCase(LTrim(RTrim(Session("companycode")))) & "' "

                sqlpass = "exec jct_costing_fibre_master_fetch_all '" & _
                        LTrim(RTrim(Me.ddl_action.Text)) & "','" & _
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

            End If

            Me.txt_tranno.Focus()

        End If

    End Sub

End Class
