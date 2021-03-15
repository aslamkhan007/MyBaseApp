Imports System.Data.SqlClient
Imports System.Data
Imports System.Web.HttpResponse
Imports vb = Microsoft.VisualBasic
Imports System.String
Imports System.Math
Partial Class OPS_frm_items_movement_before_transaction
    Inherits System.Web.UI.Page
    Dim sql As String
    Dim dr As SqlDataReader
    Dim cmd As SqlCommand
    Dim sqlpass As String
    Public obj As New HelpDeskClass
    Dim Ash As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Session("Companycode") = "JCT00LTD"
        'Session("Empcode") = "C-00509"

        If Not IsPostBack Then

            'Me.lnk_excel.Enabled = False

            ''txt_tranno.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)) {document.getElementById('" + btn_enter.UniqueID + "').click();return false;}} else {return true}; ")
            'txt_tranno.Attributes.Add("onkeypress", "return clickButton(event,'" + btn_enter.ClientID + "')")


            ''-----Fill Action Combo Box
            sqlpass = "/*select b.action,b.mnuname,b.description,b.parent_menu,b.seq " & _
                " from production..user_module_menus_mapping a inner join production..modules_menu_master b " & _
                " on a.module=b.module and a.mnuname=b.mnuname and a.action=b.action " & _
                " where a.module ='PP' and a.uname='C-00509' and a.mnuname='mnuteambudget'" & _
                " union*/ select b.action,b.mnuname,b.description,parent_menu, " & _
                " case b.action when 'ADD' then '1' when 'VIEW' then '2' when 'MODIFY' then '3' " & _
                " when 'CANCEL' then '4' when 'SHORT CLOSE' then '5' when 'AUTHORIZE' then '6' end /*b.seq*/ " & _
                " from production..role_module_menus_mapping a inner join production..modules_menu_master b " & _
                " on a.module=b.module and a.mnuname=b.mnuname and a.action=b.action " & _
                " inner join production..role_user_mapping e on a.role=e.role " & _
                " where a.module ='PP' and e.uname='C-00509' and a.mnuname='mnuteambudget'" & _
                " order by b.parent_menu,b.mnuname, " & _
                " case b.action when 'ADD' then '1' when 'VIEW' then '2' when 'MODIFY' then '3' " & _
                " when 'CANCEL' then '4' when 'SHORT CLOSE' then '5' when 'AUTHORIZE' then '6' end /*b.seq*/ "

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

            Me.ddl_action.SelectedIndex = 0


            ''Delete previous user based fetch record 
            sqlpass = "delete from jct_ops_items_movement_before_transaction_header_fetch " & _
                        "where userid = '" & UCase(LTrim(RTrim(Session("empcode")))) & "' " & _
                        "and company_code = '" & UCase(LTrim(RTrim(Session("companycode")))) & "' "
 
            obj.opencn()
            cmd = New SqlCommand(sqlpass, obj.cn)
            dr = cmd.ExecuteReader

            dr.Close()
            obj.closecn()

            Me.lnk_view_Click(sender, e)  '' set view mode at page loading time

        End If

    End Sub

    Protected Sub lnk_excel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnk_excel.Click

            ''GridViewExportUtil.Export("checklist.xls", Me.GridView1)
            Dim filename As String = "items_movement_before_transaction"
            GridViewExportUtil.Export(filename, Me.GridView1)

    End Sub

    Protected Sub imb_fetch_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imb_fetch.Click

        Dim i As Integer = 0

        If LTrim(RTrim(Me.txt_grupr_no.Text)) = "" Then
            FMsg.Message = "Pl. enter Gr/Upr No. "
            FMsg.CssClass = "errormsg"
            FMsg.Display()
            Me.txt_grupr_no.Focus()
            Exit Sub
        End If


        For i = 0 To GridView1.Rows.Count - 1

            If LTrim(RTrim(Me.txt_grupr_no.Text)) = LTrim(RTrim(GridView1.Rows(i).Cells(0).Text)) Then
                FMsg.Message = "Gr/Upr No. Already Exist in above Rows "
                FMsg.CssClass = "errormsg"
                FMsg.Display()
                Me.txt_grupr_no.Focus()
                Exit Sub
            End If

        Next


        ''-----ReFill GridView1
        sqlpass = "exec jct_ops_gr_upr_fetch '" & LTrim(RTrim(Me.ddl_action.Text)) & "','" & _
                    LTrim(RTrim(Me.txt_grupr_no.Text)) & "','" & _
                    UCase(LTrim(RTrim(Session("empcode")))) & "','" & _
                    UCase(LTrim(RTrim(Session("companycode")))) & "' "

        obj.opencn()
        Dim Da As SqlDataAdapter = New SqlDataAdapter(sqlpass, obj.cn)

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

    Protected Sub ddl_action_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl_action.SelectedIndexChanged

        If UCase(LTrim(RTrim(Me.ddl_action.Text))) = "ADD" And Me.lnk_add.Text = "ADD" Then

            Me.txt_grupr_no.Text = ""
            Me.txt_grupr_no.Enabled = True
            Me.lnk_apply.Enabled = True
            Me.txt_grupr_no.Focus()

        End If


        If UCase(LTrim(RTrim(Me.ddl_action.Text))) = "MODIFY" And Me.lnk_modify.Text = "MODIFY" Then

            Me.txt_grupr_no.Text = ""
            Me.txt_grupr_no.Enabled = True
            Me.lnk_apply.Enabled = True
            Me.txt_grupr_no.Focus()

        End If


        If UCase(LTrim(RTrim(Me.ddl_action.Text))) = "VIEW" Then

            Me.txt_grupr_no.Text = ""
            Me.txt_grupr_no.Enabled = True
            Me.lnk_apply.Enabled = False
            Me.txt_grupr_no.Focus()

        End If


        If UCase(LTrim(RTrim(Me.ddl_action.Text))) = "SHORT CLOSE" Or UCase(LTrim(RTrim(Me.ddl_action.Text))) = "AUTHORIZE" Then

            Me.txt_grupr_no.Text = ""
            Me.txt_grupr_no.Enabled = True
            Me.lnk_apply.Enabled = True
            Me.txt_grupr_no.Focus()

        End If

    End Sub

    Protected Sub lnk_view_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnk_view.Click

        Me.ddl_action.SelectedIndex = 1
        ddl_action_SelectedIndexChanged(sender, e)

        Me.lnk_add.Enabled = False
        Me.lnk_view.Enabled = True
        Me.lnk_modify.Enabled = False
        Me.lnk_delete.Enabled = False
        'Me.lnk_cancel.Enabled = False
        Me.lnk_close.Enabled = False
        Me.lnk_authorize.Enabled = False

        Me.lnk_close.Enabled = True
        Me.lnk_close.Text = "CANCEL"  '' "UNDO"

        Me.lnk_next.Enabled = True
        Me.lnk_previous.Enabled = True

        Me.imb_fetch.Enabled = False
        Me.txt_grupr_no.Enabled = False
        Me.txt_grupr_no.Text = ""

        Me.imb_fetch2.Enabled = False
        Me.txt_itemcode.Enabled = False
        Me.txt_itemcode.Text = ""

        Me.imb_fetch3.Enabled = False
        Me.txt_variant.Enabled = False
        Me.txt_variant.Text = ""

        Me.imb_fetch_entryno.Enabled = True
        Me.txt_entryno.Text = ""

    End Sub

    Protected Sub lnk_add_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnk_add.Click

        If lnk_add.Text = "ADD" Then

            Me.ddl_action.SelectedIndex = 0
            ddl_action_SelectedIndexChanged(sender, e)

            Me.lnk_add.Enabled = True
            Me.lnk_view.Enabled = False
            Me.lnk_modify.Enabled = False
            Me.lnk_delete.Enabled = False
            'Me.lnk_cancel.Enabled = False
            Me.lnk_close.Enabled = False
            Me.lnk_authorize.Enabled = False
            Me.lnk_close.Enabled = True

            Me.lnk_add.Text = "SAVE"
            Me.lnk_close.Text = "CANCEL"  '' "UNDO"

            Me.lnk_next.Enabled = True
            Me.lnk_previous.Enabled = True

            Me.imb_fetch.Enabled = True
            Me.txt_grupr_no.Enabled = True
            Me.txt_grupr_no.Text = ""

            Me.imb_fetch2.Enabled = True
            Me.txt_itemcode.Enabled = True
            Me.txt_itemcode.Text = ""

            Me.imb_fetch3.Enabled = True
            Me.txt_variant.Enabled = True
            Me.txt_variant.Text = ""

            Me.imb_fetch_entryno.Enabled = False
            Me.txt_entryno.Text = ""

        ElseIf lnk_add.Text = "SAVE" Then

            Me.ddl_action.SelectedIndex = 0    ''  Set action in ADD mode
            Me.lnk_apply_Click(sender, e)      ''  Execute APPLY button script through LinkButton1_Click event
            ''Me.lnk_exit_Click(sender, e)       ''  Execute EXIT button script

        End If

    End Sub

    Protected Sub lnk_modify_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnk_modify.Click

        If lnk_modify.Text = "MODIFY" Then

            Me.ddl_action.SelectedIndex = 2
            ddl_action_SelectedIndexChanged(sender, e)

            Me.lnk_add.Enabled = False
            Me.lnk_view.Enabled = False
            Me.lnk_modify.Enabled = True
            Me.lnk_delete.Enabled = False
            'Me.lnk_cancel.Enabled = False
            Me.lnk_close.Enabled = False
            Me.lnk_authorize.Enabled = False
            Me.lnk_close.Enabled = True

            Me.lnk_modify.Text = "UPDATE"
            Me.lnk_close.Text = "CANCEL"  '' "UNDO"

            Me.lnk_next.Enabled = True
            Me.lnk_previous.Enabled = True

            Me.imb_fetch.Enabled = False
            Me.txt_grupr_no.Enabled = False
            Me.txt_grupr_no.Text = ""

            Me.imb_fetch2.Enabled = False
            Me.txt_itemcode.Enabled = False
            Me.txt_itemcode.Text = ""

            Me.imb_fetch3.Enabled = False
            Me.txt_variant.Enabled = False
            Me.txt_variant.Text = ""

            Me.imb_fetch_entryno.Enabled = True
            Me.txt_entryno.Text = ""

        ElseIf lnk_modify.Text = "UPDATE" Then

            Me.ddl_action.SelectedIndex = 2    ''  Set action in MODIFY mode
            Me.lnk_apply_Click(sender, e)      ''  Execute APPLY button script through LinkButton1_Click event
            ''Me.lnk_exit_Click(sender, e)       ''  Execute EXIT button script

        End If

    End Sub

    Protected Sub lnk_delete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnk_delete.Click

        If lnk_delete.Text = "DELETE" Then

            Me.ddl_action.SelectedIndex = 4
            ddl_action_SelectedIndexChanged(sender, e)

            Me.lnk_add.Enabled = False
            Me.lnk_view.Enabled = False
            Me.lnk_modify.Enabled = False
            Me.lnk_delete.Enabled = True
            'Me.lnk_cancel.Enabled = False
            Me.lnk_close.Enabled = True
            Me.lnk_authorize.Enabled = False
            Me.lnk_close.Enabled = True

            Me.lnk_delete.Text = "UPDATE"
            Me.lnk_close.Text = "CANCEL"   '' "UNDO"

            Me.lnk_next.Enabled = True
            Me.lnk_previous.Enabled = True

            Me.imb_fetch.Enabled = False
            Me.txt_grupr_no.Enabled = False
            Me.txt_grupr_no.Text = ""

            Me.imb_fetch2.Enabled = False
            Me.txt_itemcode.Enabled = False
            Me.txt_itemcode.Text = ""

            Me.imb_fetch3.Enabled = False
            Me.txt_variant.Enabled = False
            Me.txt_variant.Text = ""

            Me.imb_fetch_entryno.Enabled = True
            Me.txt_entryno.Text = ""

        ElseIf lnk_delete.Text = "UPDATE" Then

            Me.ddl_action.SelectedIndex = 4    ''  Set action in SHORT CLOSE mode
            Me.lnk_apply_Click(sender, e)      ''  Execute APPLY button script through LinkButton1_Click event
            ''Me.lnk_exit_Click(sender, e)       ''  Execute EXIT button script

        End If

    End Sub

    Protected Sub lnk_authorize_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnk_authorize.Click


        If lnk_authorize.Text = "AUTHORIZE" Then

            Me.ddl_action.SelectedIndex = 5
            ddl_action_SelectedIndexChanged(sender, e)

            Me.lnk_add.Enabled = False
            Me.lnk_view.Enabled = False
            Me.lnk_modify.Enabled = False
            Me.lnk_delete.Enabled = False
            'Me.lnk_cancel.Enabled = False
            Me.lnk_close.Enabled = False
            Me.lnk_authorize.Enabled = True
            Me.lnk_close.Enabled = True

            Me.lnk_authorize.Text = "UPDATE"
            Me.lnk_close.Text = "CANCEL"  '' "UNDO"

            Me.lnk_next.Enabled = True
            Me.lnk_previous.Enabled = True

            Me.imb_fetch.Enabled = False
            Me.txt_grupr_no.Enabled = False
            Me.txt_grupr_no.Text = ""

            Me.imb_fetch2.Enabled = False
            Me.txt_itemcode.Enabled = False
            Me.txt_itemcode.Text = ""

            Me.imb_fetch3.Enabled = False
            Me.txt_variant.Enabled = False
            Me.txt_variant.Text = ""

            Me.imb_fetch_entryno.Enabled = True
            Me.txt_entryno.Text = ""

        ElseIf lnk_authorize.Text = "UPDATE" Then

            Me.ddl_action.SelectedIndex = 5    ''  Set action in AUTHORIZE mode
            Me.lnk_apply_Click(sender, e)      ''  Execute APPLY button script through LinkButton1_Click event
            Me.lnk_close_Click(sender, e)      ''  Execute EXIT button script

        End If

    End Sub

    Protected Sub lnk_close_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnk_close.Click

        If lnk_close.Text = "CLOSE" And Me.lnk_add.Enabled = True And Me.lnk_view.Enabled = True And Me.lnk_modify.Enabled = True And Me.lnk_close.Enabled = True And Me.lnk_authorize.Enabled = True And Me.lnk_close.Enabled = True Then
            Me.Dispose()
            Response.Redirect("default.aspx")
        Else

            'Me.GridView2.DataSource = Nothing
            'Me.GridView2.DataBind()

            Me.GridView1.Visible = True
            'Me.GridView2.Visible = False
            'Me.lnk_excel.Enabled = False

            Me.ddl_action.SelectedIndex = 1
            ddl_action_SelectedIndexChanged(sender, e)

            Me.lnk_add.Enabled = True
            Me.lnk_view.Enabled = True
            Me.lnk_modify.Enabled = True
            Me.lnk_delete.Enabled = True
            'Me.lnk_cancel.Enabled = True
            Me.lnk_close.Enabled = True
            Me.lnk_authorize.Enabled = True
            Me.lnk_close.Enabled = True

            Me.lnk_add.Text = "ADD"
            Me.lnk_view.Text = "VIEW"
            Me.lnk_modify.Text = "MODIFY"
            'Me.lnk_cancel.Text = "CANCEL"
            Me.lnk_delete.Text = "DELETE"  '' "SHORT CLOSE"
            Me.lnk_authorize.Text = "AUTHORIZE"
            Me.lnk_close.Text = "CLOSE"

            Me.lnk_next.Enabled = False
            Me.lnk_previous.Enabled = False

            Me.txt_grupr_no.Enabled = True
            Me.txt_grupr_no.Text = ""

            Me.imb_fetch.Enabled = False
            Me.txt_grupr_no.Enabled = False
            Me.txt_grupr_no.Text = ""

            Me.imb_fetch2.Enabled = False
            Me.txt_itemcode.Enabled = False
            Me.txt_itemcode.Text = ""

            Me.imb_fetch3.Enabled = False
            Me.txt_variant.Enabled = False
            Me.txt_variant.Text = ""

            Me.imb_fetch_entryno.Enabled = False
            Me.txt_entryno.Text = ""

            ''Delete previous user based fetch record 
            sqlpass = "delete from jct_ops_items_movement_before_transaction_header_fetch " & _
                        "where userid = '" & UCase(LTrim(RTrim(Session("empcode")))) & "' " & _
                        "and company_code = '" & UCase(LTrim(RTrim(Session("companycode")))) & "' "

            obj.opencn()
            cmd = New SqlCommand(sqlpass, obj.cn)
            dr = cmd.ExecuteReader

            dr.Close()
            obj.closecn()

            Me.GridView1.DataSource = Nothing
            Me.GridView1.DataBind()

        End If

    End Sub

    Protected Sub lnk_apply_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnk_apply.Click

        Dim same As String = "N"
        Dim greater As String = "N"
        Dim wh_type As String = ""
        Dim zn_type As String = ""
        Dim gruprdt As Date
        Dim i As Integer = 0


        ''Starts of check/validations
        If (UCase(LTrim(RTrim(Me.ddl_action.Text))) = "ADD" Or UCase(LTrim(RTrim(Me.ddl_action.Text))) = "MODIFY") Then

            'If LTrim(RTrim(Me.txt_grupr_no.Text)) = "" And LTrim(RTrim(Me.txt_itemcode.Text)) = "" Then
            '    FMsg.Message = "Pl. enter GrUpr No./Item Code "
            '    FMsg.CssClass = "errormsg"
            '    FMsg.Display()
            '    Me.txt_grupr_no.Focus()
            '    Exit Sub
            'End If

        End If



        For i = 0 To GridView1.Rows.Count - 1

            If Val(CType(GridView1.Rows(i).FindControl("txt_move_qty"), TextBox).Text) > 0 Then

                'If Val(GridView1.Rows(i).Cells(9).Text) < 0 Then
                '    FMsg.Message = "Pl. enter Move Qty. "
                '    FMsg.CssClass = "errormsg"
                '    FMsg.Display()
                '    Exit Sub
                'End If

                If LTrim(RTrim(GridView1.Rows(i).Cells(13).Text)) <> "OPEN" And (Me.ddl_action.Text = "ADD" Or Me.ddl_action.Text = "MODIFY" Or Me.ddl_action.Text = "SHORT CLOSE") Then
                    FMsg.Message = "Transaction Already " + LTrim(RTrim(GridView1.Rows(i).Cells(13).Text))
                    FMsg.CssClass = "errormsg"
                    FMsg.Display()
                    Exit Sub
                End If


                sqlpass = "select isnull(sum(isnull(moved_qty,0)),0) " & _
                "from jct_ops_items_movement_before_transaction_header " & _
                "where grupr_no='" & LTrim(RTrim(GridView1.Rows(i).Cells(0).Text)) & "' " & _
                "and item_serial=" & Val(GridView1.Rows(i).Cells(2).Text) & _
                " and item_code='" & LTrim(RTrim(GridView1.Rows(i).Cells(3).Text)) & "' " & _
                "and item_variant='" & LTrim(RTrim(GridView1.Rows(i).Cells(4).Text)) & "' " & _
                "and company_code='" & LTrim(RTrim(Session("companycode"))) & "' "


                obj.opencn()
                cmd = New SqlCommand(sqlpass, obj.cn)
                cmd.CommandTimeout = 0
                dr = cmd.ExecuteReader

                If dr.HasRows = True Then
                    dr.Read()

                    If (Val(dr.Item(0)) + Val(GridView1.Rows(i).Cells(9).Text)) > Val(GridView1.Rows(i).Cells(8).Text) Then
                        FMsg.Message = "Prev. " + dr.Item(0) + " Sel.Qty. " + GridView1.Rows(i).Cells(9).Text + "  More than Total Qty. of " + LTrim(RTrim(GridView1.Rows(i).Cells(0).Text)) + " - " + LTrim(RTrim(GridView1.Rows(i).Cells(2).Text))
                        FMsg.CssClass = "errormsg"
                        FMsg.Display()
                        dr.Close()
                        obj.closecn()
                        Exit Sub
                    End If

                End If
                dr.Close()
                obj.closecn()



                ''Check & Fetch warehouse type
                wh_type = ""

                sqlpass = "select ltrim(RTrim(isnull(storage_type,''))) " & _
                "from miserp.common.dbo.ims_warehouse_master " & _
                "where wh_no='" & CType(GridView1.Rows(i).FindControl("txt_move_warehouse"), TextBox).Text & "' " & _
                "and company_no='" & LTrim(RTrim(Session("companycode"))) & "' "

                obj.opencn()
                cmd = New SqlCommand(sqlpass, obj.cn)
                cmd.CommandTimeout = 0
                dr = cmd.ExecuteReader

                If dr.HasRows = True Then
                    dr.Read()
                    wh_type = dr.Item(0)
                Else
                    FMsg.Message = "Invalid Warehouse No. against " + LTrim(RTrim(GridView1.Rows(i).Cells(0).Text)) + " - " + LTrim(RTrim(GridView1.Rows(i).Cells(2).Text))
                    FMsg.CssClass = "errormsg"
                    FMsg.Display()
                    dr.Close()
                    obj.closecn()
                    Exit Sub
                End If
                dr.Close()
                obj.closecn()



                ''Fetch zone type
                zn_type = ""

                sqlpass = "select ltrim(RTrim(isnull(type,''))) " & _
                "from miserp.common.dbo.ims_zone_master " & _
                "where wh_no='" & CType(GridView1.Rows(i).FindControl("txt_move_warehouse"), TextBox).Text & "' " & _
                "and zone_no='" & CType(GridView1.Rows(i).FindControl("txt_move_zone"), TextBox).Text & "' " & _
                "and company_no='" & LTrim(RTrim(Session("companycode"))) & "' "

                obj.opencn()
                cmd = New SqlCommand(sqlpass, obj.cn)
                cmd.CommandTimeout = 0
                dr = cmd.ExecuteReader

                If dr.HasRows = True Then
                    dr.Read()
                    zn_type = dr.Item(0)
                Else
                    FMsg.Message = "Invalid Zone No. against " + LTrim(RTrim(GridView1.Rows(i).Cells(0).Text)) + " - " + LTrim(RTrim(GridView1.Rows(i).Cells(2).Text))
                    FMsg.CssClass = "errormsg"
                    FMsg.Display()
                    dr.Close()
                    obj.closecn()
                    Exit Sub
                End If
                dr.Close()
                obj.closecn()



                ''Fetch bin no.
                sqlpass = "select ltrim(RTrim(isnull(bin_no,''))) " & _
                        "from miserp.common.dbo.ims_bin_master " & _
                        "where wh_no ='" & CType(GridView1.Rows(i).FindControl("txt_move_warehouse"), TextBox).Text & "' " & _
                        "and zone_no ='" & CType(GridView1.Rows(i).FindControl("txt_move_zone"), TextBox).Text & "' " & _
                        "and bin_no ='" & CType(GridView1.Rows(i).FindControl("txt_move_bin"), TextBox).Text & "' " & _
                        "and company_no='" & LTrim(RTrim(Session("companycode"))) & "' "

                obj.opencn()
                cmd = New SqlCommand(sqlpass, obj.cn)
                cmd.CommandTimeout = 0
                dr = cmd.ExecuteReader

                If dr.HasRows = False Then
                    FMsg.Message = "Invalid Bin No. " + LTrim(RTrim(GridView1.Rows(i).Cells(0).Text)) + " - " + LTrim(RTrim(GridView1.Rows(i).Cells(2).Text))
                    FMsg.CssClass = "errormsg"
                    FMsg.Display()
                    dr.Close()
                    obj.closecn()
                    Exit Sub
                End If
                dr.Close()
                obj.closecn()


                If wh_type = "1" And (LTrim(RTrim(CType(GridView1.Rows(i).FindControl("txt_move_zone"), TextBox).Text)) <> "" Or LTrim(RTrim(CType(GridView1.Rows(i).FindControl("txt_move_bin"), TextBox).Text <> ""))) Then
                    FMsg.Message = "Do not enter Zone/Bin No. for Free Warehouse against " + LTrim(RTrim(GridView1.Rows(i).Cells(0).Text)) + " - " + LTrim(RTrim(GridView1.Rows(i).Cells(2).Text))
                    FMsg.CssClass = "errormsg"
                    FMsg.Display()
                    dr.Close()
                    obj.closecn()
                    Exit Sub
                End If

                If zn_type = "1" And LTrim(RTrim(CType(GridView1.Rows(i).FindControl("txt_move_bin"), TextBox).Text)) <> "" Then
                    FMsg.Message = "Do not enter Bin No. for Free Zone against " + LTrim(RTrim(GridView1.Rows(i).Cells(0).Text)) + " - " + LTrim(RTrim(GridView1.Rows(i).Cells(2).Text))
                    FMsg.CssClass = "errormsg"
                    FMsg.Display()
                    dr.Close()
                    obj.closecn()
                    Exit Sub
                End If


                If wh_type = "0" And (LTrim(RTrim(CType(GridView1.Rows(i).FindControl("txt_move_zone"), TextBox).Text)) = "" Or LTrim(RTrim(CType(GridView1.Rows(i).FindControl("txt_move_bin"), TextBox).Text = ""))) Then
                    FMsg.Message = "Pl. enter Zone/Bin No. against " + LTrim(RTrim(GridView1.Rows(i).Cells(0).Text)) + " - " + LTrim(RTrim(GridView1.Rows(i).Cells(2).Text))
                    FMsg.CssClass = "errormsg"
                    FMsg.Display()
                    dr.Close()
                    obj.closecn()
                    Exit Sub
                End If

                If zn_type = "0" And LTrim(RTrim(CType(GridView1.Rows(i).FindControl("txt_move_bin"), TextBox).Text)) = "" Then
                    FMsg.Message = "Pl. enter Bin No. against " + LTrim(RTrim(GridView1.Rows(i).Cells(0).Text)) + " - " + LTrim(RTrim(GridView1.Rows(i).Cells(2).Text))
                    FMsg.CssClass = "errormsg"
                    FMsg.Display()
                    dr.Close()
                    obj.closecn()
                    Exit Sub
                End If


            End If  ''end of if Val(GridView1.Rows(i).Cells(9).Text)) > 0

        Next
        '' end of check/validations



        Dim btran As SqlTransaction

        If UCase(LTrim(RTrim(Me.ddl_action.Text))) = "ADD" Then

            obj.opencn()
            btran = obj.cn.BeginTransaction

            Try

                For i = 0 To GridView1.Rows.Count - 1

                    sqlpass = "select convert(datetime,'" & GridView1.Rows(i).Cells(15).Text & "',103) "

                    cmd = New SqlCommand(sqlpass, obj.cn)
                    cmd.Transaction = btran
                    dr = cmd.ExecuteReader

                    If dr.HasRows = True Then
                        dr.Read()
                        gruprdt = dr.Item(0)
                    Else
                        btran.Rollback()
                        dr.Close()
                        obj.closecn()
                        FMsg.Message = "Error during GR/Upr date convert in MM/dd/yyyy format against " + LTrim(RTrim(GridView1.Rows(i).Cells(0).Text)) + " - " + LTrim(RTrim(GridView1.Rows(i).Cells(2).Text))
                        FMsg.CssClass = "errormsg"
                        FMsg.Display()
                        Exit Sub
                    End If

                    dr.Close()

                    sqlpass = "exec jct_ops_items_movement_before_transaction_entry '" & _
                            LTrim(RTrim(Me.ddl_action.Text)) & "','" & _
                            LTrim(RTrim(GridView1.Rows(i).Cells(0).Text)) & "'," & _
                            LTrim(RTrim(GridView1.Rows(i).Cells(1).Text)) & "," & _
                            LTrim(RTrim(GridView1.Rows(i).Cells(2).Text)) & ",'" & _
                            LTrim(RTrim(GridView1.Rows(i).Cells(3).Text)) & "','" & _
                            LTrim(RTrim(GridView1.Rows(i).Cells(4).Text)) & "','" & _
                            LTrim(RTrim(GridView1.Rows(i).Cells(5).Text)) & "','" & _
                            LTrim(RTrim(GridView1.Rows(i).Cells(6).Text)) & "','" & _
                            LTrim(RTrim(GridView1.Rows(i).Cells(7).Text)) & "'," & _
                            LTrim(RTrim(GridView1.Rows(i).Cells(8).Text)) & "," & _
                            CType(GridView1.Rows(i).FindControl("txt_move_qty"), TextBox).Text & ",'" & _
                            CType(GridView1.Rows(i).FindControl("txt_move_warehouse"), TextBox).Text & "','" & _
                            CType(GridView1.Rows(i).FindControl("txt_move_zone"), TextBox).Text & "','" & _
                            CType(GridView1.Rows(i).FindControl("txt_move_bin"), TextBox).Text & "','" & _
                            LTrim(RTrim(GridView1.Rows(i).Cells(13).Text)) & "','" & _
                            LTrim(RTrim(GridView1.Rows(i).Cells(14).Text)) & "','" & _
                            gruprdt & "','" & _
                            UCase(LTrim(RTrim(Session("empcode")))) & "','" & _
                            UCase(LTrim(RTrim(Session("companycode")))) & "'"


                    ' 0 = gr/upr no.
                    ' 1 = entry no.
                    ' 2 = item serial
                    ' 3 = item code
                    ' 4 = variant
                    ' 5 = desc.
                    ' 6 = short desc.
                    ' 7 = uom
                    ' 8 = total qty.
                    ' 9 = move qty.
                    '10 = move warehouse
                    '11 = move zone
                    '12 = move bin
                    '13 = status
                    '14 = Temp Bin. 
                    '15 = Gr/Upr Date
                    '16 = userid
                    '17 = company

                    cmd = New SqlCommand(sqlpass, obj.cn)
                    cmd.Transaction = btran
                    cmd.ExecuteNonQuery()

                Next

                btran.Commit()
                'dr.Close()
                obj.closecn()
                ''''''''''Meaasage'''''''''''''
                FMsg.Message = "Success"
                FMsg.CssClass = "addmsg"
                FMsg.Display()
                '''''''''''''''''''''''''''''''

            Catch ex As Exception

                btran.Rollback()
                'dr.Close()
                obj.closecn()
                FMsg.Message = (ex.Message)
                FMsg.CssClass = "addmsg"
                FMsg.Display()
                Me.lnk_close_Click(sender, e)       ''  Execute EXIT button script
                Exit Sub

            End Try

        End If  '' end of ADD mode

        ''===========================================================


        If UCase(LTrim(RTrim(Me.ddl_action.Text))) = "MODIFY" Or UCase(LTrim(RTrim(Me.ddl_action.Text))) = "SHORT CLOSE" Or UCase(LTrim(RTrim(Me.ddl_action.Text))) = "AUTHORIZE" Then

            obj.opencn()
            btran = obj.cn.BeginTransaction

            Try

                For i = 0 To GridView1.Rows.Count - 1

                    sqlpass = "select convert(datetime,'" & GridView1.Rows(i).Cells(15).Text & "',103) "

                    cmd = New SqlCommand(sqlpass, obj.cn)
                    cmd.Transaction = btran
                    dr = cmd.ExecuteReader

                    If dr.HasRows = True Then
                        dr.Read()
                        gruprdt = dr.Item(0)
                    Else
                        btran.Rollback()
                        dr.Close()
                        obj.closecn()
                        FMsg.Message = "Error during GR/Upr date convert in MM/dd/yyyy format against " + LTrim(RTrim(GridView1.Rows(i).Cells(0).Text)) + " - " + LTrim(RTrim(GridView1.Rows(i).Cells(2).Text))
                        FMsg.CssClass = "errormsg"
                        FMsg.Display()
                        Exit Sub
                    End If

                    dr.Close()

                    sqlpass = "exec jct_ops_items_movement_before_transaction_entry '" & _
                            LTrim(RTrim(Me.ddl_action.Text)) & "','" & _
                            LTrim(RTrim(GridView1.Rows(i).Cells(0).Text)) & "'," & _
                            LTrim(RTrim(GridView1.Rows(i).Cells(1).Text)) & "," & _
                            LTrim(RTrim(GridView1.Rows(i).Cells(2).Text)) & ",'" & _
                            LTrim(RTrim(GridView1.Rows(i).Cells(3).Text)) & "','" & _
                            LTrim(RTrim(GridView1.Rows(i).Cells(4).Text)) & "','" & _
                            LTrim(RTrim(GridView1.Rows(i).Cells(5).Text)) & "','" & _
                            LTrim(RTrim(GridView1.Rows(i).Cells(6).Text)) & "','" & _
                            LTrim(RTrim(GridView1.Rows(i).Cells(7).Text)) & "'," & _
                            LTrim(RTrim(GridView1.Rows(i).Cells(8).Text)) & "," & _
                            CType(GridView1.Rows(i).FindControl("txt_move_qty"), TextBox).Text & ",'" & _
                            CType(GridView1.Rows(i).FindControl("txt_move_warehouse"), TextBox).Text & "','" & _
                            CType(GridView1.Rows(i).FindControl("txt_move_zone"), TextBox).Text & "','" & _
                            CType(GridView1.Rows(i).FindControl("txt_move_bin"), TextBox).Text & "','" & _
                            LTrim(RTrim(GridView1.Rows(i).Cells(13).Text)) & "','" & _
                            LTrim(RTrim(GridView1.Rows(i).Cells(14).Text)) & "','" & _
                            gruprdt & "','" & _
                            UCase(LTrim(RTrim(Session("empcode")))) & "','" & _
                            UCase(LTrim(RTrim(Session("companycode")))) & "'"

                    cmd = New SqlCommand(sqlpass, obj.cn)
                    cmd.Transaction = btran
                    cmd.ExecuteNonQuery()


                    sqlpass = "insert into jct_ops_action_detail (tran_no,entry_no,date,detail,userid,hostname,company_code) " & _
                            "Select '" & GridView1.Rows(i).Cells(0).Text & "'," & _
                            GridView1.Rows(i).Cells(1).Text & "," & _
                            "getdate(),'" & _
                            UCase(LTrim(RTrim(Me.ddl_action.Text))) & "','" & _
                            UCase(LTrim(RTrim(Session("empcode")))) & "',LTrim(RTrim(host_name())),'" & _
                            UCase(LTrim(RTrim(Session("companycode")))) & "'"

                    cmd = New SqlCommand(sqlpass, obj.cn)
                    cmd.Transaction = btran
                    cmd.ExecuteNonQuery()

                Next

                btran.Commit()
                'dr.Close()
                obj.closecn()
                ''''''''''Meaasage'''''''''''''
                FMsg.Message = "Success"
                FMsg.CssClass = "addmsg"
                FMsg.Display()
                '''''''''''''''''''''''''''''''

            Catch ex As Exception

                btran.Rollback()
                'dr.Close()
                obj.closecn()
                FMsg.Message = (ex.Message)
                FMsg.CssClass = "addmsg"
                FMsg.Display()
                Me.lnk_close_Click(sender, e)       ''  Execute EXIT button script
                Exit Sub

            End Try

        End If

        ''===============================================================================



        ''rbt_activeyes.Checked = True

        ' ''If UCase(LTrim(RTrim(Me.cmb_action.Text))) = "ADD" Then

        ''If Me.rbt_activeyes.Checked = True Then
        ''    activate = "Y"
        ''Else
        ''    activate = "N"
        ''End If

        ''getconn()
        ''btran = con.BeginTransaction

        ''Try

        ''qry = "exec jct_garmenting_item_type_master_entry '" & _
        ''            Me.cbo_action.Text & "','" & _
        ''            Me.txt_itemcode.Text & "','" & _
        ''            Me.txt_itemdesc.Text & "','" & _
        ''            vb.Format(CDate(CStr(Me.dtp_effdate.Value.Date) + " " + vb.Right(RTrim(CStr(Now())), 11)), "MM/dd/yyyy HH:mm:ss") & "','" & _
        ''            vb.Format(CDate(CStr(Me.dtp_expdate.Value.Date) + " " + vb.Right(RTrim(CStr(Now())), 11)), "MM/dd/yyyy HH:mm:ss") & "','" & _
        ''            activate & "','" & _
        ''            userid & "','" & _
        ''            UCase(LTrim(RTrim(ucompany))) & "'"

        ''    ''getconn()
        ''    cmd = New SqlCommand(qry, con)
        ''    cmd.Transaction = btran
        ''    cmd.ExecuteNonQuery()
        ''    ''con.Close()

        ''    btran.Commit()
        ''    con.Close()
        ''    MessageBox.Show("Success")

        ''Catch ex As Exception
        ''    btran.Rollback()
        ''    con.Close()
        ''    MessageBox.Show(ex.Message)
        ''    Exit Sub
        ''End Try

        ' ''End If




        ''after success refresh grid data
        ''-----ReFill GridView1
        'sqlpass = "exec jct_ops_gr_upr_fetch '" & LTrim(RTrim(Me.ddl_action.Text)) & "','" & _
        '            LTrim(RTrim(Me.txt_grupr_no.Text)) & "','" & _
        '            UCase(LTrim(RTrim(Session("empcode")))) & "','" & _
        '            UCase(LTrim(RTrim(Session("companycode")))) & "' "

        'obj.opencn()

        'Dim Da As SqlDataAdapter = New SqlDataAdapter(sqlpass, obj.cn)

        'Try

        '    Dim ds As DataSet = New DataSet()
        '    Da.Fill(ds)
        '    GridView1.DataSource = ds
        '    GridView1.DataBind()
        'Catch ex As Exception
        '    obj.closecn()
        '    FMsg.Message = (ex.Message)
        '    FMsg.CssClass = "addmsg"
        '    FMsg.Display()
        'Finally
        '    obj.closecn()
        'End Try

        'Me.lnk_close_Click(sender, e)       ''  Execute EXIT button script

    End Sub

    Protected Sub lnk_next_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnk_next.Click

        If LTrim(RTrim(Me.txt_entryno.Text)) = "" Then
            FMsg.Message = "Pl. enter Entry No. "
            FMsg.CssClass = "errormsg"
            FMsg.Display()
            Me.txt_grupr_no.Focus()
            Exit Sub
        End If

        Me.GridView1.Visible = True
        ''-----ReFill GridView1
        sqlpass = "exec jct_ops_gr_upr_fetch_next '" & LTrim(RTrim(Me.ddl_action.Text)) & "'," & _
                    GridView1.Rows(0).Cells(1).Text & ",'" & _
                    UCase(LTrim(RTrim(Session("empcode")))) & "','" & _
                    UCase(LTrim(RTrim(Session("companycode")))) & "' "

        obj.opencn()
        Dim Da As SqlDataAdapter = New SqlDataAdapter(sqlpass, obj.cn)

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

    Protected Sub lnk_previous_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnk_previous.Click

        If LTrim(RTrim(Me.txt_entryno.Text)) = "" Then
            FMsg.Message = "Pl. enter Enry No. "
            FMsg.CssClass = "errormsg"
            FMsg.Display()
            Me.txt_grupr_no.Focus()
            Exit Sub
        End If

        Me.GridView1.Visible = True
        ''-----ReFill GridView1
        sqlpass = "exec jct_ops_gr_upr_fetch_previous '" & LTrim(RTrim(Me.ddl_action.Text)) & "'," & _
                    GridView1.Rows(0).Cells(1).Text & ",'" & _
                    UCase(LTrim(RTrim(Session("empcode")))) & "','" & _
                    UCase(LTrim(RTrim(Session("companycode")))) & "' "

        obj.opencn()
        Dim Da As SqlDataAdapter = New SqlDataAdapter(sqlpass, obj.cn)

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

    Protected Sub imb_fetch2_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imb_fetch2.Click

        Dim i As Integer = 0

        If LTrim(RTrim(Me.txt_itemcode.Text)) = "" Then
            FMsg.Message = "Pl. enter Item Code "
            FMsg.CssClass = "errormsg"
            FMsg.Display()
            Me.txt_itemcode.Focus()
            Exit Sub
        End If

        For i = 0 To GridView1.Rows.Count - 1

            If LTrim(RTrim(Me.txt_itemcode.Text)) = LTrim(RTrim(GridView1.Rows(i).Cells(3).Text)) Then
                FMsg.Message = "Item Code Already Exist in above Rows "
                FMsg.CssClass = "errormsg"
                FMsg.Display()
                Me.txt_itemcode.Focus()
                Exit Sub
            End If

        Next


        Dim entryno As Double = 0

        If Me.GridView1.Rows.Count() > 0 Then
            entryno = Val(LTrim(RTrim(GridView1.Rows(0).Cells(1).Text)))
        Else
            entryno = 0
        End If


        ''-----ReFill GridView1
        sqlpass = "exec jct_ops_gr_upr_fetch2 '" & LTrim(RTrim(Me.ddl_action.Text)) & "','" & _
                    LTrim(RTrim(Me.txt_itemcode.Text)) & "'," & _
                    entryno & ",'" & _
                    UCase(LTrim(RTrim(Session("empcode")))) & "','" & _
                    UCase(LTrim(RTrim(Session("companycode")))) & "' "

        obj.opencn()
        Dim Da As SqlDataAdapter = New SqlDataAdapter(sqlpass, obj.cn)

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

    Protected Sub imb_fetch3_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imb_fetch3.Click

        Dim i As Integer = 0

        If LTrim(RTrim(Me.txt_itemcode.Text)) = "" Or LTrim(RTrim(Me.txt_variant.Text)) = "" Then
            FMsg.Message = "Pl. enter Item Code/Variant "
            FMsg.CssClass = "errormsg"
            FMsg.Display()
            Me.txt_itemcode.Focus()
            Exit Sub
        End If

        If LTrim(RTrim(Me.txt_itemcode.Text)) = "" And LTrim(RTrim(Me.txt_variant.Text)) <> "" Then
            FMsg.Message = "Pl. enter Item Code "
            FMsg.CssClass = "errormsg"
            FMsg.Display()
            Me.txt_grupr_no.Focus()
            Exit Sub
        End If


        For i = 0 To GridView1.Rows.Count - 1

            If LTrim(RTrim(Me.txt_itemcode.Text)) = LTrim(RTrim(GridView1.Rows(i).Cells(3).Text)) And LTrim(RTrim(Me.txt_variant.Text)) = LTrim(RTrim(GridView1.Rows(i).Cells(4).Text)) Then
                FMsg.Message = "Item Code & Variant Already Exist in above Rows "
                FMsg.CssClass = "errormsg"
                FMsg.Display()
                Me.txt_itemcode.Focus()
                Exit Sub
            End If

        Next


        Dim entryno As Double = 0

        If GridView1.Rows.Count > 0 Then
            entryno = Val(LTrim(RTrim(GridView1.Rows(0).Cells(1).Text)))
        Else
            entryno = 0
        End If


        ''-----ReFill GridView1
        sqlpass = "exec jct_ops_gr_upr_fetch3 '" & LTrim(RTrim(Me.ddl_action.Text)) & "','" & _
                    LTrim(RTrim(Me.txt_itemcode.Text)) & "','" & _
                    LTrim(RTrim(Me.txt_variant.Text)) & "'," & _
                    entryno & ",'" & _
                    UCase(LTrim(RTrim(Session("empcode")))) & "','" & _
                    UCase(LTrim(RTrim(Session("companycode")))) & "' "

        obj.opencn()
        Dim Da As SqlDataAdapter = New SqlDataAdapter(sqlpass, obj.cn)

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

    Protected Sub imb_fetch_entryno_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imb_fetch_entryno.Click

        Dim i As Integer = 0

        If LTrim(RTrim(Me.txt_entryno.Text)) = "" Then
            FMsg.Message = "Pl. enter Entry No. "
            FMsg.CssClass = "errormsg"
            FMsg.Display()
            Me.txt_entryno.Focus()
            Exit Sub
        End If


        For i = 0 To GridView1.Rows.Count - 1

            If LTrim(RTrim(Me.txt_entryno.Text)) = LTrim(RTrim(GridView1.Rows(i).Cells(1).Text)) Then
                FMsg.Message = "Entry No. Already Exist in above Rows "
                FMsg.CssClass = "errormsg"
                FMsg.Display()
                Me.txt_entryno.Focus()
                Exit Sub
            End If

        Next


        ''-----ReFill GridView1
        sqlpass = "exec jct_ops_gr_upr_fetch_entryno '" & LTrim(RTrim(Me.ddl_action.Text)) & "','" & _
                    LTrim(RTrim(Me.txt_entryno.Text)) & "','" & _
                    UCase(LTrim(RTrim(Session("empcode")))) & "','" & _
                    UCase(LTrim(RTrim(Session("companycode")))) & "' "

        obj.opencn()
        Dim Da As SqlDataAdapter = New SqlDataAdapter(sqlpass, obj.cn)

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

End Class
