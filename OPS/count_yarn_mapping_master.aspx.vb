Imports System.Data.SqlClient
Imports System.Data
Imports System.Web.HttpResponse
Imports vb = Microsoft.VisualBasic
Imports System.String
Imports System.Math
Partial Class Costing_count_yarn_mapping_master
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

            'Me.txt_efffrom.Text = Now().Date
            'Me.txt_effto.Text = Now().Date

            ''-----Fill Action Combo Box
            sqlpass = "/*select b.action,b.mnuname,b.description,b.parent_menu,b.seq " & _
                " from production..user_module_menus_mapping a inner join production..modules_menu_master b " & _
                " on a.module=b.module and a.mnuname=b.mnuname and a.action=b.action " & _
                " where a.module ='OPS' and a.uname='" & Session("empcode") & "' and a.mnuname='Count Yarn Mapping'" & _
                " union*/ select b.action,b.mnuname,b.description,parent_menu,case b.action when 'ADD' then '1' when 'VIEW' then '2' when 'MODIFY' then '3' when 'CANCEL' then '4' when 'SHORT CLOSE' then '5' when 'AUTHORIZE' then '6' end /*b.seq*/ " & _
                " from production..role_module_menus_mapping a inner join production..modules_menu_master b " & _
                " on a.module=b.module and a.mnuname=b.mnuname and a.action=b.action " & _
                " inner join production..role_user_mapping e on a.role=e.role " & _
                " where a.module ='OPS' and e.uname='" & Session("empcode") & "' " & _
                "and a.mnuname='Count Yarn Mapping' and a.action<>'Load'" & _
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


            sqlpass = "select distinct ltrim(rtrim(convert(varchar,a.doubling)))+'/'+ltrim(rtrim(a.count_no))+' | '+a.count_name as [yarn_desc], " & _
                     "a.count_code_spg as [count_code], '' as [count_desc], '' as [mixing_desc], " & _
                     "'' as [eff_from], '' as [eff_to], '' as [status], '' as [tran_no] " & _
                     "from production..jct_warp_weft_dtl a " & _
                    "where a.sort_no Is Not null " & _
                    "and isnull(a.Count_Code_Spg,'') = '' " & _
                    "order by ltrim(rtrim(convert(varchar,a.doubling)))+'/'+ltrim(rtrim(a.count_no))+' | '+a.count_name, a.count_code_spg "

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

            'Me.lbt_view_Click(sender, e)  '' set view mode at page loading time
            Me.lbt_add_Click(sender, e)  '' set add mode at page loading time


        End If  '' end of If Not IsPostBack 

        'If Not IsPostBack Then
        '    grdbnd()
        'End If

    End Sub

    Protected Sub ddl_action_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl_action.SelectedIndexChanged

        If UCase(LTrim(RTrim(Me.ddl_action.Text))) = "ADD" Then ''And Me.lbt_add.Text = "ADD" Then

            If Me.lbt_add.Text = "ADD" Then

                'Me.lbt_apply.Enabled = True

                Me.txt_count_code.Enabled = True
                Me.txt_count_desc.Enabled = False
                Me.txt_mixing_desc.Enabled = False
                Me.lsb_main_fibre_code.Enabled = False
                Me.lsb_sub_fibre_code.Enabled = False
                Me.lsb_sub_fibre_desc.Enabled = False
                Me.lsb_fibre_percent.Enabled = False
                Me.txt_efffrom.Enabled = True
                Me.txt_effto.Enabled = True
                Me.txt_tranno.Enabled = False

                'Me.GridView1.DataSource = Nothing
                'GridView1.DataBind()

                Me.txt_tranno.Text = ""
                Me.lbl_status.Text = ""
                Me.lsb_main_fibre_code.Items.Clear()
                Me.lsb_sub_fibre_code.Items.Clear()
                Me.lsb_sub_fibre_desc.Items.Clear()
                Me.lsb_fibre_percent.Items.Clear()
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

                'Me.imb_top.Enabled = False
                'Me.imb_next.Enabled = False
                'Me.imb_previous.Enabled = False
                'Me.imb_last.Enabled = False

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

                Me.txt_count_code.Enabled = False
                Me.txt_count_desc.Enabled = False
                Me.txt_mixing_desc.Enabled = False
                Me.lsb_main_fibre_code.Enabled = False
                Me.lsb_sub_fibre_code.Enabled = False
                Me.lsb_sub_fibre_desc.Enabled = False
                Me.lsb_fibre_percent.Enabled = False
                Me.txt_efffrom.Enabled = True
                Me.txt_effto.Enabled = True
                Me.txt_tranno.Enabled = True

                'Me.GridView1.DataSource = Nothing
                'GridView1.DataBind()

                Me.txt_tranno.Text = ""
                Me.lbl_status.Text = ""
                Me.lsb_main_fibre_code.Items.Clear()
                Me.lsb_sub_fibre_code.Items.Clear()
                Me.lsb_sub_fibre_desc.Items.Clear()
                Me.lsb_fibre_percent.Items.Clear()
                Me.txt_efffrom.Text = Now().Date
                Me.txt_effto.Text = Now().Date

                'Me.lbt_add.Enabled = True
                'Me.lbt_view.Enabled = False
                'Me.lbt_modify.Enabled = False
                'Me.lbt_authorize.Enabled = False
                'Me.lbt_delete.Enabled = False
                'Me.lbt_close.Enabled = True

                Me.imb_tran_fetch.Enabled = True
                'Me.imb_insertrow.Enabled = True
                'Me.imb_deleterow.Enabled = True

                'Me.imb_top.Enabled = True
                'Me.imb_next.Enabled = True
                'Me.imb_previous.Enabled = True
                'Me.imb_last.Enabled = True

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

            Me.txt_count_code.Enabled = False
            Me.txt_count_desc.Enabled = False
            Me.txt_mixing_desc.Enabled = False
            Me.lsb_main_fibre_code.Enabled = False
            Me.lsb_sub_fibre_code.Enabled = False
            Me.lsb_sub_fibre_desc.Enabled = False
            Me.lsb_fibre_percent.Enabled = False
            Me.txt_efffrom.Enabled = False
            Me.txt_effto.Enabled = False
            Me.txt_tranno.Enabled = True

            'Me.GridView1.DataSource = Nothing
            'GridView1.DataBind()

            Me.txt_tranno.Text = ""
            Me.lbl_status.Text = ""
            Me.lsb_main_fibre_code.Items.Clear()
            Me.lsb_sub_fibre_code.Items.Clear()
            Me.lsb_sub_fibre_desc.Items.Clear()
            Me.lsb_fibre_percent.Items.Clear()
            Me.txt_efffrom.Text = Now().Date
            Me.txt_effto.Text = Now().Date

            'Me.lbt_add.Enabled = True
            'Me.lbt_view.Enabled = False
            'Me.lbt_modify.Enabled = False
            'Me.lbt_authorize.Enabled = False
            'Me.lbt_delete.Enabled = False
            'Me.lbt_close.Enabled = True

            Me.imb_tran_fetch.Enabled = True
            'Me.imb_insertrow.Enabled = True
            'Me.imb_deleterow.Enabled = True

            'Me.imb_top.Enabled = True
            'Me.imb_next.Enabled = True
            'Me.imb_previous.Enabled = True
            'Me.imb_last.Enabled = True

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

                Me.txt_count_code.Enabled = False
                Me.txt_count_desc.Enabled = False
                Me.txt_mixing_desc.Enabled = False
                Me.lsb_main_fibre_code.Enabled = False
                Me.lsb_sub_fibre_code.Enabled = False
                Me.lsb_sub_fibre_desc.Enabled = False
                Me.lsb_fibre_percent.Enabled = False
                Me.txt_efffrom.Enabled = False
                Me.txt_effto.Enabled = False
                Me.txt_tranno.Enabled = True

                'Me.GridView1.DataSource = Nothing
                'GridView1.DataBind()

                Me.txt_tranno.Text = ""
                Me.lbl_status.Text = ""
                Me.lsb_main_fibre_code.Items.Clear()
                Me.lsb_sub_fibre_code.Items.Clear()
                Me.lsb_sub_fibre_desc.Items.Clear()
                Me.lsb_fibre_percent.Items.Clear()
                Me.txt_efffrom.Text = Now().Date
                Me.txt_effto.Text = Now().Date

                'Me.lbt_add.Enabled = True
                'Me.lbt_view.Enabled = False
                'Me.lbt_modify.Enabled = False
                'Me.lbt_authorize.Enabled = False
                'Me.lbt_delete.Enabled = False
                'Me.lbt_close.Enabled = True

                Me.imb_tran_fetch.Enabled = True
                'Me.imb_insertrow.Enabled = True
                'Me.imb_deleterow.Enabled = True

                'Me.imb_top.Enabled = True
                'Me.imb_next.Enabled = True
                'Me.imb_previous.Enabled = True
                'Me.imb_last.Enabled = True

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

                Me.txt_count_code.Enabled = False
                Me.txt_count_desc.Enabled = False
                Me.txt_mixing_desc.Enabled = False
                Me.lsb_main_fibre_code.Enabled = False
                Me.lsb_sub_fibre_code.Enabled = False
                Me.lsb_sub_fibre_desc.Enabled = False
                Me.lsb_fibre_percent.Enabled = False
                Me.txt_efffrom.Enabled = False
                Me.txt_effto.Enabled = False
                Me.txt_tranno.Enabled = True

                'Me.GridView1.DataSource = Nothing
                'GridView1.DataBind()

                Me.txt_tranno.Text = ""
                Me.lbl_status.Text = ""
                Me.lsb_main_fibre_code.Items.Clear()
                Me.lsb_sub_fibre_code.Items.Clear()
                Me.lsb_sub_fibre_desc.Items.Clear()
                Me.lsb_fibre_percent.Items.Clear()
                Me.txt_efffrom.Text = Now().Date
                Me.txt_effto.Text = Now().Date

                'Me.lbt_add.Enabled = True
                'Me.lbt_view.Enabled = False
                'Me.lbt_modify.Enabled = False
                'Me.lbt_authorize.Enabled = False
                'Me.lbt_delete.Enabled = False
                'Me.lbt_close.Enabled = True

                Me.imb_tran_fetch.Enabled = True
                'Me.imb_insertrow.Enabled = True
                'Me.imb_deleterow.Enabled = True

                'Me.imb_top.Enabled = True
                'Me.imb_next.Enabled = True
                'Me.imb_previous.Enabled = True
                'Me.imb_last.Enabled = True

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

        If LTrim(RTrim(Me.txt_count_code.Text)) = "" Then
            FMsg.Message = "Pl. enter Count code "
            FMsg.CssClass = "errormsg"
            FMsg.Display()
            Me.txt_count_code.Focus()
            Exit Sub
        End If

        If LTrim(RTrim(Me.txt_count_desc.Text)) = "" Then
            FMsg.Message = "Count desc. not entered "
            FMsg.CssClass = "errormsg"
            FMsg.Display()
            Me.txt_count_code.Focus()
            Exit Sub
        End If

        If LTrim(RTrim(Me.txt_mixing_desc.Text)) = "" Then
            FMsg.Message = "Mixing desc. not entered "
            FMsg.CssClass = "errormsg"
            FMsg.Display()
            Me.txt_count_code.Focus()
            Exit Sub
        End If

        If LTrim(RTrim(Me.lsb_main_fibre_code.Items(1).Text)) = "" Then
            FMsg.Message = "Main Fibre Code not mapped with count "
            FMsg.CssClass = "errormsg"
            FMsg.Display()
            Me.txt_count_code.Focus()
            Exit Sub
        End If

        If LTrim(RTrim(Me.lsb_sub_fibre_code.Text)) = "" Then
            FMsg.Message = "Pl. enter Sub Fibre Code "
            FMsg.CssClass = "errormsg"
            FMsg.Display()
            Me.txt_count_code.Focus()
            Exit Sub
        End If

        If LTrim(RTrim(Me.lsb_sub_fibre_desc.Text)) = "" Then
            FMsg.Message = "Pl. enter Sub Fibre Code "
            FMsg.CssClass = "errormsg"
            FMsg.Display()
            Me.txt_count_code.Focus()
            Exit Sub
        End If

        If LTrim(RTrim(Me.lsb_fibre_percent.Text)) = "" Then
            FMsg.Message = "Pl. enter Sub Fibre Code "
            FMsg.CssClass = "errormsg"
            FMsg.Display()
            Me.txt_count_code.Focus()
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

            sqlpass = "select distinct tran_no,isnull(status,'') " & _
                    "from jct_costing_count_yarn_mapping_master " & _
                    "where count_code='" & LTrim(RTrim(Me.txt_count_code.Text)) & "' " & _
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
                Me.txt_count_code.Focus()
                Exit Sub
            End If
            dr.Close()
            obj.closecn()


            obj.opencn()
            btran = obj.cn.BeginTransaction

            Try

                '--SERIAL NUMBER GENERATION
                sqlpass = "select isnull(count_value,0)+1,ltrim(rtrim(prefix))+" & _
                "case len(ltrim(rtrim(convert(char,isnull(count_value,0)+1)))) when 1 then '0000'" & _
                "when 2 then '000' when 3 then '00' when 4 then '0' end + ltrim(rtrim(convert(char,isnull(count_value,0)+1))) " & _
                "+ltrim(rtrim(suffix)) from jct_costing_serial_number_master " & _
                "where type_code='CYM' " & _
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
                        "from jct_costing_count_yarn_mapping_master " & _
                        "where count_code='" & LTrim(RTrim(Me.txt_count_code.Text)) & "' " & _
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
                            sqlpass = "update jct_costing_count_yarn_mapping_master set eff_to=convert(datetime,'" & efrom & "')-1 " & _
                                    "where count_code='" & LTrim(RTrim(Me.txt_count_code.Text)) & "' " & _
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

                For i = 0 To GridView1.Rows.Count - 1

                    If (CType(GridView1.Rows(i).FindControl("chk_select_yarn_desc"), CheckBox).Checked) = True Then

                        sqlpass = "exec jct_costing_count_yarn_mapping_entry '" & _
                                    LTrim(RTrim(Me.ddl_action.Text)) & "'," & _
                                    sno1 & ",'" & Now() & "','" & _
                                    UCase(LTrim(RTrim(Me.txt_tranno.Text))) & "','" & _
                                    UCase(LTrim(RTrim(Me.txt_count_code.Text))) & "','" & _
                                    UCase(LTrim(RTrim(Me.txt_count_desc.Text))) & "','" & _
                                    LTrim(RTrim(Me.txt_mixing_desc.Text)) & "','" & _
                                    efrom & "','" & _
                                    eto & "','" & _
                                    LTrim(RTrim(GridView1.Rows(i).Cells(1).Text)) & "','" & _
                                    UCase(LTrim(RTrim(Session("empcode")))) & "','" & _
                                    UCase(LTrim(RTrim(Session("companycode")))) & "'"

                        'CType(GridView1.Rows(i).FindControl("ddl_main_fibre_code"), DropDownList).SelectedItem.Text 
                        'CType(GridView1.Rows(i).FindControl("ddl_sub_fibre_code"), DropDownList).SelectedItem.Text 
                        'CType(GridView1.Rows(i).FindControl("txt_fibre_percent"), TextBox).Text 
                        'CType(GridView1.Rows(i).FindControl("CheckBox1"), CheckBox).Checked = True
                        'GridView1.Rows(i).Cells(1).Text

                        cmd = New SqlCommand(sqlpass, obj.cn)
                        cmd.CommandTimeout = 0
                        cmd.Transaction = btran
                        cmd.ExecuteNonQuery()

                    End If

                Next


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

                sqlpass = "select distinct tran_no,isnull(status,'') " & _
                        "from jct_costing_count_yarn_mapping_master " & _
                        "where tran_no<>'" & UCase(LTrim(RTrim(Me.txt_tranno.Text))) & "' " & _
                        "and count_code='" & LTrim(RTrim(Me.txt_count_code.Text)) & "' " & _
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

            sqlpass = "select distinct tran_no,isnull(status,'') " & _
                    "from jct_costing_count_yarn_mapping_master " & _
                    "where tran_no<>'" & UCase(LTrim(RTrim(Me.txt_tranno.Text))) & "' " & _
                    "and count_code='" & LTrim(RTrim(Me.txt_count_code.Text)) & "' " & _
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
                    "from jct_costing_count_yarn_mapping_master a " & _
                    "where a.tran_no='" & UCase(LTrim(RTrim(Me.txt_tranno.Text))) & "' " & _
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
                        "from jct_costing_count_yarn_mapping_master " & _
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


                    ''-- check based on eff.from - eff.to date
                    sqlpass = "select top 1 convert(datetime,convert(char(11),eff_from)), " & _
                            "convert(datetime,convert(char(11),eff_to)), tran_no " & _
                            "from jct_costing_count_yarn_mapping_master " & _
                            "where count_code='" & LTrim(RTrim(Me.txt_count_code.Text)) & "' " & _
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
                                sqlpass = "update jct_costing_count_yarn_mapping_master set eff_to=convert(datetime,'" & efrom & "')-1 " & _
                                        "where count_code='" & LTrim(RTrim(Me.txt_count_code.Text)) & "' " & _
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

                    sqlpass = "delete from jct_costing_count_yarn_mapping_master " & _
                                "where tran_no='" & LTrim(RTrim(Me.txt_tranno.Text)) & "' " & _
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
                        "Select '" & LTrim(RTrim(Me.txt_count_code.Text)) & "','" & Me.txt_tranno.Text & "',getdate(),'" & _
                        LTrim(RTrim(Me.ddl_action.Text)) & "'+'-'+'" & reason & "','" & _
                        Session("empcode") & "',LTrim(RTrim(host_name())) ,'" & _
                        UCase(LTrim(RTrim(Session("companycode")))) & "' "

                cmd = New SqlCommand(sqlpass, obj.cn)
                cmd.Transaction = btran
                cmd.ExecuteNonQuery()



                ''ENTRY THROUGH SQL PROCEDURE

                Dim i As Integer = 0


                For i = 0 To GridView1.Rows.Count - 1

                    If (CType(GridView1.Rows(i).FindControl("chk_select_yarn_desc"), CheckBox).Checked) = True Then

                        sqlpass = "exec jct_costing_count_yarn_mapping_entry '" & _
                                    LTrim(RTrim(Me.ddl_action.Text)) & "'," & _
                                    sno1 & ",'" & Now() & "','" & _
                                    UCase(LTrim(RTrim(Me.txt_tranno.Text))) & "','" & _
                                    UCase(LTrim(RTrim(Me.txt_count_code.Text))) & "','" & _
                                    UCase(LTrim(RTrim(Me.txt_count_desc.Text))) & "','" & _
                                    LTrim(RTrim(Me.txt_mixing_desc.Text)) & "','" & _
                                    efrom & "','" & _
                                    eto & "','" & _
                                    LTrim(RTrim(GridView1.Rows(i).Cells(1).Text)) & "','" & _
                                    UCase(LTrim(RTrim(Session("empcode")))) & "','" & _
                                    UCase(LTrim(RTrim(Session("companycode")))) & "'"

                        'CType(GridView1.Rows(i).FindControl("ddl_main_fibre_code"), DropDownList).SelectedItem.Text 
                        'CType(GridView1.Rows(i).FindControl("ddl_sub_fibre_code"), DropDownList).SelectedItem.Text 
                        'CType(GridView1.Rows(i).FindControl("txt_fibre_percent"), TextBox).Text 
                        'CType(GridView1.Rows(i).FindControl("CheckBox1"), CheckBox).Checked = True
                        'GridView1.Rows(i).Cells(1).Text

                        cmd = New SqlCommand(sqlpass, obj.cn)
                        cmd.CommandTimeout = 0
                        cmd.Transaction = btran
                        cmd.ExecuteNonQuery()

                    End If

                Next

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
        Me.GridView1.DataSource = Nothing
        GridView1.DataBind()

        sqlpass = "exec jct_costing_count_yarn_mapping_fetch '" & _
                    LTrim(RTrim(Me.ddl_action.Text)) & "','" & _
                    LTrim(RTrim(Me.txt_tranno.Text)) & "','" & _
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
            sqlpass = "select distinct case isnull(a.status,'') when 'O' then 'OPEN' when 'A' then 'AUTHORIZE' when 'C' then 'CANCEL' when 'S' then 'DELETE' when 'F' then 'FINISH' end " & _
                "from jct_costing_count_yarn_mapping_master a " & _
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

            sqlpass = "select a.count_code, a.count_desc, a.mixing_desc, " & _
                        "Convert(varchar(11), a.eff_from, 101) 'eff_from', " & _
                        "convert(varchar(11),a.eff_to,101) 'eff_to', " & _
                        "case isnull(a.status,'') when 'O' then 'OPEN' when 'A' then 'AUTHORIZE' " & _
                        "when 'C' then 'CANCEL' when 'S' then 'SHORT CLOSE' end 'status' " & _
                        "from jct_costing_count_yarn_mapping_master a " & _
                        "where a.tran_no='" & LTrim(RTrim(Me.txt_tranno.Text)) & "' " & _
                        "/*and a.status not in ('C','S')*/ " & _
                        "and a.company_code='" & UCase(LTrim(RTrim(Session("companycode")))) & "' " & _
                        "order by a.count_code "

            obj.opencn()
            cmd = New SqlCommand(sqlpass, obj.cn)
            dr = cmd.ExecuteReader

            If dr.HasRows = True Then
                dr.Read()
                Me.txt_count_code.Text = dr.Item(0)
                Me.txt_count_desc.Text = dr.Item(1)
                Me.txt_mixing_desc.Text = dr.Item(2)
                Me.txt_efffrom.Text = dr.Item(3)
                Me.txt_effto.Text = dr.Item(4)
                Me.lbl_status.Text = dr.Item(5)

                dr.Close()
                obj.closecn()


                ''-----Fill Main Fibre Code Box
                sqlpass = "select distinct main_fibre_code " & _
                        "from jct_costing_count_fibre_mapping_master " & _
                        "where count_code='" & Me.txt_count_code.Text & "' " & _
                        "and convert(datetime,convert(varchar(11),getdate())) between eff_from and eff_to " & _
                        "and company_code='" & UCase(LTrim(RTrim(Session("companycode")))) & "' " & _
                        "order by main_fibre_code "

                obj.opencn()
                cmd = New SqlCommand(sqlpass, obj.cn)
                dr = cmd.ExecuteReader

                Me.lsb_main_fibre_code.Items.Clear()

                If dr.HasRows = True Then
                    While dr.Read
                        Me.lsb_main_fibre_code.Items.Add(dr.Item(0))
                    End While
                End If
                dr.Close()
                obj.closecn()

                ''-----Fill Sub Fibre Code Box
                sqlpass = "select distinct sub_fibre_code, main_fibre_code " & _
                        "from jct_costing_count_fibre_mapping_master " & _
                        "where count_code='" & Me.txt_count_code.Text & "' " & _
                        "and convert(datetime,convert(varchar(11),getdate())) between eff_from and eff_to " & _
                        "and company_code='" & UCase(LTrim(RTrim(Session("companycode")))) & "' " & _
                        "order by main_fibre_code, sub_fibre_code "

                obj.opencn()
                cmd = New SqlCommand(sqlpass, obj.cn)
                dr = cmd.ExecuteReader

                Me.lsb_sub_fibre_code.Items.Clear()

                If dr.HasRows = True Then
                    While dr.Read
                        Me.lsb_sub_fibre_code.Items.Add(dr.Item(0))
                    End While
                End If
                dr.Close()
                obj.closecn()

                ''-----Fill Sub Fibre Code Desc. Box
                sqlpass = "select distinct b.sub_fibre_desc, a.main_fibre_code, a.sub_fibre_code " & _
                        "from jct_costing_count_fibre_mapping_master a, jct_costing_fibre_type_master b " & _
                        "where a.count_code = '" & Me.txt_count_code.Text & "' " & _
                        "and convert(datetime,convert(varchar(11),getdate())) between a.eff_from and a.eff_to " & _
                        "and a.company_code='" & UCase(LTrim(RTrim(Session("companycode")))) & "' " & _
                        "and a.main_fibre_code = b.main_fibre_code " & _
                        "and a.sub_fibre_code = b.sub_fibre_code " & _
                        "and convert(datetime,convert(varchar(11),getdate())) between b.eff_from and b.eff_to " & _
                        "and a.company_code = b.company_code " & _
                        "order by a.main_fibre_code, a.sub_fibre_code "

                obj.opencn()
                cmd = New SqlCommand(sqlpass, obj.cn)
                dr = cmd.ExecuteReader

                Me.lsb_sub_fibre_desc.Items.Clear()

                If dr.HasRows = True Then
                    While dr.Read
                        Me.lsb_sub_fibre_desc.Items.Add(dr.Item(0))
                    End While
                End If
                dr.Close()
                obj.closecn()

                ''-----Fill Fibre Percentage Box
                sqlpass = "select distinct fibre_percent, sub_fibre_code, main_fibre_code " & _
                        "from jct_costing_count_fibre_mapping_master " & _
                        "where count_code='" & Me.txt_count_code.Text & "' " & _
                        "and convert(datetime,convert(varchar(11),getdate())) between eff_from and eff_to " & _
                        "and company_code='" & UCase(LTrim(RTrim(Session("companycode")))) & "' " & _
                        "order by main_fibre_code, sub_fibre_code "

                obj.opencn()
                cmd = New SqlCommand(sqlpass, obj.cn)
                dr = cmd.ExecuteReader

                Me.lsb_fibre_percent.Items.Clear()

                If dr.HasRows = True Then
                    While dr.Read
                        Me.lsb_fibre_percent.Items.Add(dr.Item(0))
                    End While
                End If
                dr.Close()
                obj.closecn()



                Me.GridView1.DataSource = Nothing
                GridView1.DataBind()

                ''-----ReFill GridView1
                sqlpass = "exec jct_costing_count_yarn_mapping_fetch '" & _
                            LTrim(RTrim(Me.ddl_action.Text)) & "','" & _
                            LTrim(RTrim(Me.txt_tranno.Text)) & "','" & _
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

            dr.Close()
            obj.closecn()

            Me.txt_tranno.Focus()

        End If ''end of MODIFY/CANCEL/SHORT CLOSE/AUTHORIZE

    End Sub

    Protected Sub txt_yarndesc_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_yarndesc.TextChanged

        If LTrim(RTrim(Me.txt_yarndesc.Text)) = "" Then

            'dr.Close()
            'obj.closecn()
            Exit Sub

        End If

        If InStr(LTrim(RTrim(Me.txt_yarndesc.Text)), "-") > 0 Then

            'Me.txt_yarndesc.Text = Mid(LTrim(RTrim(Me.txt_yarndesc.Text)), 1, InStr(LTrim(RTrim(Me.txt_yarndesc.Text)), "-") - 2)
            'Dim modal As AjaxControlToolkit.AutoCompleteExtender = DirectCast(txt_variant.FindControl("AutoCompleteExtender2"), AjaxControlToolkit.AutoCompleteExtender)
            'modal.ContextKey = txt_yarndesc.Text

        End If

    End Sub

    Protected Sub imb_fetch_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imb_fetch.Click

        If LTrim(RTrim(Me.txt_count_code.Text)) = "" Then
            FMsg.Message = "Pl. enter Count Code "
            FMsg.CssClass = "errormsg"
            FMsg.Display()
            Me.txt_count_code.Focus()
            Exit Sub
        End If

        If UCase(Me.ddl_action.Text) = "ADD" Then

            If InStr(LTrim(RTrim(Me.txt_count_code.Text)), "/") Then
                sqlpass = "select a.count_desc, a.mixing_desc, " & _
                        "convert(varchar(11),getdate(),101) 'eff_date' " & _
                        "from jct_costing_count_fibre_mapping_master a " & _
                        "where a.count_code='" & LTrim(RTrim(Me.txt_count_code.Text)) & "' " & _
                        "and convert(datetime,convert(varchar(11), getdate())) between a.eff_from and a.eff_to " & _
                        "and a.company_code = '" & UCase(LTrim(RTrim(Session("companycode")))) & "' "
            End If

            obj.opencn()
            cmd = New SqlCommand(sqlpass, obj.cn)
            dr = cmd.ExecuteReader

            If dr.HasRows = True Then
                dr.Read()

                Me.txt_tranno.Text = ""
                Me.txt_count_desc.Text = dr.Item(0)
                Me.txt_mixing_desc.Text = dr.Item(1)
                Me.txt_efffrom.Text = dr.Item(2)
                Me.txt_effto.Text = dr.Item(2)
                Me.lbl_status.Text = "OPEN"
                dr.Close()
                obj.closecn()

                ''-----Fill Main Fibre Code Box
                sqlpass = "select distinct main_fibre_code " & _
                        "from jct_costing_count_fibre_mapping_master " & _
                        "where count_code='" & Me.txt_count_code.Text & "' " & _
                        "and convert(datetime,convert(varchar(11),getdate())) between eff_from and eff_to " & _
                        "and company_code='" & UCase(LTrim(RTrim(Session("companycode")))) & "' " & _
                        "order by main_fibre_code "

                obj.opencn()
                cmd = New SqlCommand(sqlpass, obj.cn)
                dr = cmd.ExecuteReader

                Me.lsb_main_fibre_code.Items.Clear()

                If dr.HasRows = True Then
                    While dr.Read
                        Me.lsb_main_fibre_code.Items.Add(dr.Item(0))
                    End While
                End If
                dr.Close()
                obj.closecn()


                ''-----Fill Sub Fibre Code Box
                sqlpass = "select distinct sub_fibre_code, main_fibre_code " & _
                        "from jct_costing_count_fibre_mapping_master " & _
                        "where count_code='" & Me.txt_count_code.Text & "' " & _
                        "and convert(datetime,convert(varchar(11),getdate())) between eff_from and eff_to " & _
                        "and company_code='" & UCase(LTrim(RTrim(Session("companycode")))) & "' " & _
                        "order by main_fibre_code, sub_fibre_code "

                obj.opencn()
                cmd = New SqlCommand(sqlpass, obj.cn)
                dr = cmd.ExecuteReader

                Me.lsb_sub_fibre_code.Items.Clear()

                If dr.HasRows = True Then
                    While dr.Read
                        Me.lsb_sub_fibre_code.Items.Add(dr.Item(0))
                    End While
                End If
                dr.Close()
                obj.closecn()


                ''-----Fill Sub Fibre Code Desc. Box
                sqlpass = "select distinct b.sub_fibre_desc, a.main_fibre_code, a.sub_fibre_code " & _
                        "from jct_costing_count_fibre_mapping_master a, jct_costing_fibre_type_master b " & _
                        "where a.count_code = '" & Me.txt_count_code.Text & "' " & _
                        "and convert(datetime,convert(varchar(11),getdate())) between a.eff_from and a.eff_to " & _
                        "and a.company_code='" & UCase(LTrim(RTrim(Session("companycode")))) & "' " & _
                        "and a.main_fibre_code = b.main_fibre_code " & _
                        "and a.sub_fibre_code = b.sub_fibre_code " & _
                        "and convert(datetime,convert(varchar(11),getdate())) between b.eff_from and b.eff_to " & _
                        "and a.company_code = b.company_code " & _
                        "order by a.main_fibre_code, a.sub_fibre_code "

                obj.opencn()
                cmd = New SqlCommand(sqlpass, obj.cn)
                dr = cmd.ExecuteReader

                Me.lsb_sub_fibre_desc.Items.Clear()

                If dr.HasRows = True Then
                    While dr.Read
                        Me.lsb_sub_fibre_desc.Items.Add(dr.Item(0))
                    End While
                End If
                dr.Close()
                obj.closecn()


                ''-----Fill Fibre Percentage Box
                sqlpass = "select distinct fibre_percent, sub_fibre_code, main_fibre_code " & _
                        "from jct_costing_count_fibre_mapping_master " & _
                        "where count_code='" & Me.txt_count_code.Text & "' " & _
                        "and convert(datetime,convert(varchar(11),getdate())) between eff_from and eff_to " & _
                        "and company_code='" & UCase(LTrim(RTrim(Session("companycode")))) & "' " & _
                        "order by main_fibre_code, sub_fibre_code "

                obj.opencn()
                cmd = New SqlCommand(sqlpass, obj.cn)
                dr = cmd.ExecuteReader

                Me.lsb_fibre_percent.Items.Clear()

                If dr.HasRows = True Then
                    While dr.Read
                        Me.lsb_fibre_percent.Items.Add(dr.Item(0))
                    End While
                End If
                dr.Close()
                obj.closecn()


                sqlpass = "select distinct ltrim(rtrim(convert(varchar,a.doubling)))+'/'+ltrim(rtrim(a.count_no))+' | '+a.count_name as [yarn_desc], " & _
                         "a.count_code_spg as [count_code], '' as [count_desc], '' as [mixing_desc], " & _
                         "'' as [eff_from], '' as [eff_to], '' as [status], '' as [tran_no] " & _
                         "from production..jct_warp_weft_dtl a " & _
                        "where a.sort_no Is Not null " & _
                        "and isnull(a.Count_Code_Spg,'') = '' " & _
                        "order by ltrim(rtrim(convert(varchar,a.doubling)))+'/'+ltrim(rtrim(a.count_no))+' | '+a.count_name, a.count_code_spg "

                Me.GridView1.DataSource = Nothing
                GridView1.DataBind()

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

            Else
                FMsg.Message = "Invalid Count Code "
                FMsg.CssClass = "errormsg"
                FMsg.Display()
                dr.Close()
                obj.closecn()
                'Exit Sub
            End If

        End If  ''end of if action = "ADD"

    End Sub

End Class
