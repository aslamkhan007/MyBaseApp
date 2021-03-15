Imports System.Data.SqlClient
Imports System.Data
Imports System.Web.HttpResponse
Imports vb = Microsoft.VisualBasic
Imports System.String
Imports System.Math
Partial Class Team_Budget_Entry
    Inherits System.Web.UI.Page
    Dim sql As String
    Dim dr As SqlDataReader
    Dim cmd As SqlCommand
    Dim sqlpass As String
    Public obj As New HelpDeskClass
    Dim Ash As Integer
    Dim obj1 As Functions = New Functions
    Dim obj2 As Connection = New Connection
    Dim mon As String
    Dim sm As SendMail = New SendMail()
    Dim sumLooms As Decimal = 0
    Dim sumMeters As Decimal = 0
    Dim flag As Boolean
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Session("Companycode") = "JCT00LTD"
        'Session("Empcode") = "C-00509"

        If Not IsPostBack Then

            Me.GridView1.Visible = True
            Me.GridView2.Visible = False
   
            ''-----Fill Action Combo Box
            sqlpass = "/*select b.action,b.mnuname,b.description,b.parent_menu,b.seq " & _
                " from production..user_module_menus_mapping a inner join production..modules_menu_master b " & _
                " on a.module=b.module and a.mnuname=b.mnuname and a.action=b.action " & _
                " where a.module ='PP' and a.uname='" & Session("empcode") & "' and a.mnuname='mnuteambudget'" & _
                " union*/ select b.action,b.mnuname,b.description,parent_menu, " & _
                " case b.action when 'ADD' then '1' when 'VIEW' then '2' when 'MODIFY' then '3' " & _
                " when 'CANCEL' then '4' when 'SHORT CLOSE' then '5' when 'AUTHORIZE' then '6' end /*b.seq*/ " & _
                " from production..role_module_menus_mapping a inner join production..modules_menu_master b " & _
                " on a.module=b.module and a.mnuname=b.mnuname and a.action=b.action " & _
                " inner join production..role_user_mapping e on a.role=e.role " & _
                " where a.module ='PP' and e.uname='" & Session("empcode") & "' and a.mnuname='mnuteambudget'" & _
                " order by b.parent_menu,b.mnuname, " & _
                " case b.action when 'ADD' then '1' when 'VIEW' then '2' when 'MODIFY' then '3' " & _
                " when 'CANCEL' then '4' when 'SHORT CLOSE' then '5' when 'AUTHORIZE' then '6' end /*b.seq*/ "

            obj.opencn()
            cmd = New SqlCommand(sqlpass, obj.cn)
            dr = cmd.ExecuteReader

            Me.ddl_action.Items.Insert(0, "ADD")
            Me.ddl_action.Items.Insert(1, "VIEW")
            Me.ddl_action.Items.Insert(2, "MODIFY")
            ' End While
            Me.ddl_action.SelectedIndex = 0
            'End If
            dr.Close()
            obj.closecn()
            Me.lnk_view_Click(sender, e)  '' set view mode at page loading time

            ''-----Fill Team Combo Box
            sqlpass = "select distinct team_code from miserp.som.dbo.jct_team_master " & _
                    "where convert(datetime,convert(varchar(11),getdate())) between eff_from and eff_to " & _
                    "and status='O' " & _
                    "and company='" & UCase(LTrim(RTrim(Session("companycode")))) & "' " & _
                    "order by team_code "

            obj.opencn()
            cmd = New SqlCommand(sqlpass, obj.cn)
            dr = cmd.ExecuteReader

            Me.ddl_team.Items.Clear()

            If dr.HasRows = True Then
                While dr.Read
                    Me.ddl_team.Items.Add(dr.Item(0))
                End While
                Me.ddl_team.SelectedIndex = 0
            End If
            dr.Close()
            obj.closecn()

        End If

    End Sub


    Protected Sub imb_fetch_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imb_fetch.Click

       

        Me.GridView1.Visible = True
        Me.GridView2.Visible = False
        ''-----ReFill GridView1
        sqlpass = "exec jct_OpS_sales_order_fetch '" & LTrim(RTrim(Me.ddl_action.Text)) & "'," & _
                    Right(RTrim(Me.ddl_yearmonth.Text), 6) & ",'" & _
                    LTrim(RTrim(Me.ddl_team.Text)) & "','" & _
                    LTrim(RTrim(Me.txt_orderno.Text)) & "','" & _
                    UCase(LTrim(RTrim(Session("empcode")))) & "','" & _
                    UCase(LTrim(RTrim(Session("companycode")))) & "' "

        obj.opencn()
        Dim Da As SqlDataAdapter = New SqlDataAdapter(sqlpass, obj.cn)

        Try
            Dim ds As DataSet = New DataSet()
            Da.Fill(ds)
            GridView1.DataSource = ds
            GridView1.DataBind()
            sql = "Select * from jct_ops_monthly_planning where mode='Freezed'"
            If (obj1.FetchValue(sql)) Then
            Else

                GridView1.Columns(11).Visible = False

            End If
        Catch ex As Exception
            obj.closecn()
            FMsg.Message = (ex.Message)
            FMsg.CssClass = "addmsg"
            FMsg.Display()
        Finally
            obj.closecn()
        End Try

    End Sub

    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging

        GridView1.PageIndex = e.NewPageIndex

        ''-----ReFill GridView1
        sqlpass = "exec jct_OpS_sales_order_fetch '" & LTrim(RTrim(Me.ddl_action.Text)) & "'," & _
                    Right(RTrim(Me.ddl_yearmonth.Text), 6) & ",'" & _
                    LTrim(RTrim(Me.ddl_team.Text)) & "','" & _
                    LTrim(RTrim(Me.txt_orderno.Text)) & "','" & _
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

    Protected Sub txt_orderno_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_orderno.TextChanged

        'Me.imb_fetch_Click(sender, e)

    End Sub

    Protected Sub lnk_view_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnk_view.Click

        Me.ddl_action.SelectedIndex = 1
        ddl_action_SelectedIndexChanged(sender, e)

        'Me.lnk_add.Enabled = False
        Me.lnk_view.Enabled = True
        Me.lnk_modify.Enabled = False
        'Me.lnk_cancel.Enabled = False
        Me.lnk_close.Enabled = False
        Me.lnk_authorize.Enabled = False
        Me.lnk_exit.Enabled = True
        Me.lnk_exit.Text = "CANCEL"  '' "UNDO"

    End Sub

    Protected Sub lnk_add_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnk_add.Click

        If lnk_add.Text = "ADD" Then

            Me.ddl_action.SelectedIndex = 0
            ddl_action_SelectedIndexChanged(sender, e)

            Me.lnk_add.Enabled = True
            Me.lnk_view.Enabled = False
            Me.lnk_modify.Enabled = False
            'Me.lnk_cancel.Enabled = False
            Me.lnk_close.Enabled = False
            Me.lnk_authorize.Enabled = False
            Me.lnk_exit.Enabled = True

            Me.lnk_add.Text = "SAVE"
            Me.lnk_exit.Text = "CANCEL"  '' "UNDO"

        ElseIf lnk_add.Text = "SAVE" Then

            Me.ddl_action.SelectedIndex = 0    ''  Set action in ADD mode
            Me.lnk_apply_Click(sender, e)      ''  Execute APPLY button script through LinkButton1_Click event
            ''Me.lnk_exit_Click(sender, e)       ''  Execute EXIT button script

        End If

    End Sub

    Protected Sub lnk_apply_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnk_apply.Click

        Dim same As String = "N"
        Dim greater As String = "N"
        Dim i As Integer = 0

        If LTrim(RTrim(Me.ddl_yearmonth.Text)) = "" Then
            FMsg.Message = "Invalid year month "
            FMsg.CssClass = "errormsg"
            FMsg.Display()
            Me.ddl_yearmonth.Focus()
            Exit Sub
        End If


        If LTrim(RTrim(Me.ddl_team.Text)) = "" Then
            FMsg.Message = "Invalid team code "
            FMsg.CssClass = "errormsg"
            FMsg.Display()
            Me.ddl_team.Focus()
            Exit Sub
        End If


        If LTrim(RTrim(Me.txt_orderno.Text)) = "" And UCase(LTrim(RTrim(Me.ddl_action.Text))) = "ADD" Then
            FMsg.Message = "Pl. enter order no. "
            FMsg.CssClass = "errormsg"
            FMsg.Display()
            Me.txt_orderno.Focus()
            Exit Sub
        End If

        For i = 0 To GridView1.Rows.Count - 1

            If Val(GridView1.Rows(i).Cells(9).Text) < Val(CType(GridView1.Rows(i).FindControl("txt_selqty"), TextBox).Text) Then
                FMsg.Message = "Sel.Qty. more than order Qty., Pl. check and re-enter. "
                FMsg.CssClass = "errormsg"
                FMsg.Display()
                Exit Sub
            End If

            sqlpass = "select isnull(sum(isnull(sel_qty,0)),0) " & _
                        "from JCT_OPS_MONTHLY_PLANNING " & _
                        "where order_no='" & LTrim(RTrim(GridView1.Rows(i).Cells(0).Text)) & "' " & _
                        "and amend_no=" & Val(GridView1.Rows(i).Cells(2).Text) & _
                        " and order_srl_no=" & Val(GridView1.Rows(i).Cells(3).Text) & _
                        " and item_no='" & LTrim(RTrim(GridView1.Rows(i).Cells(4).Text)) & "' " & _
                        "and variant='" & LTrim(RTrim(GridView1.Rows(i).Cells(5).Text)) & "' " & _
                        "and company_code='" & LTrim(RTrim(Session("companycode"))) & "' "


            obj.opencn()
            cmd = New SqlCommand(sqlpass, obj.cn)
            cmd.CommandTimeout = 0
            dr = cmd.ExecuteReader

            If dr.HasRows = True Then
                dr.Read()

                If (Val(dr.Item(0)) + Val(CType(GridView1.Rows(i).FindControl("txt_selqty"), TextBox).Text)) > Val(GridView1.Rows(i).Cells(9).Text) Then
                    FMsg.Message = "Order Qty. already booked. "
                    FMsg.CssClass = "errormsg"
                    FMsg.Display()
                    dr.Close()
                    obj.closecn()
                    Exit Sub
                End If

            End If
            dr.Close()
            obj.closecn()

        Next


        Dim btran As SqlTransaction
        Dim orddt As Date
        Dim reqdt As Date


        If UCase(LTrim(RTrim(Me.ddl_action.Text))) = "ADD" Then

            obj.opencn()
            btran = obj.cn.BeginTransaction

            Try

                For i = 0 To GridView1.Rows.Count - 1

                    sqlpass = "select convert(datetime,'" & GridView1.Rows(i).Cells(1).Text & "',103),convert(datetime,'" & GridView1.Rows(i).Cells(7).Text & "',103) "

                    cmd = New SqlCommand(sqlpass, obj.cn)
                    cmd.Transaction = btran
                    dr = cmd.ExecuteReader

                    If dr.HasRows = True Then
                        dr.Read()
                        orddt = dr.Item(0)
                        reqdt = dr.Item(1)
                    End If

                    dr.Close()


                    sqlpass = "exec jct_ops_sales_team_budget_entry '" & _
                            LTrim(RTrim(Me.ddl_action.Text)) & "'," & _
                            Right(RTrim(Me.ddl_yearmonth.Text), 6) & ",'" & _
                            LTrim(RTrim(Me.ddl_team.Text)) & "','" & _
                            LTrim(RTrim(GridView1.Rows(i).Cells(0).Text)) & "','" & _
                            orddt & "'," & _
                            GridView1.Rows(i).Cells(2).Text & "," & _
                            GridView1.Rows(i).Cells(3).Text & ",'" & _
                            LTrim(RTrim(GridView1.Rows(i).Cells(4).Text)) & "','" & _
                            LTrim(RTrim(GridView1.Rows(i).Cells(5).Text)) & "','" & _
                            LTrim(RTrim(GridView1.Rows(i).Cells(6).Text)) & "','" & _
                            reqdt & "'," & _
                            GridView1.Rows(i).Cells(9).Text & "," & _
                            CType(GridView1.Rows(i).FindControl("txt_selqty"), TextBox).Text & ",'" & _
                            UCase(LTrim(RTrim(Session("empcode")))) & "','" & _
                            UCase(LTrim(RTrim(Session("companycode")))) & "','" & _
                                CType(GridView1.Rows(i).FindControl("ddlReason"), DropDownList).SelectedItem.Text & "','" + CType(GridView1.Rows(i).FindControl("txtRemarks"), TextBox).Text + "'"

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
                Me.lnk_exit_Click(sender, e)       ''  Execute EXIT button script
                Exit Sub

            End Try

        End If  '' end of ADD mode


        ''===========================================================


        If UCase(LTrim(RTrim(Me.ddl_action.Text))) = "MODIFY" Or UCase(LTrim(RTrim(Me.ddl_action.Text))) = "SHORT CLOSE" Or UCase(LTrim(RTrim(Me.ddl_action.Text))) = "AUTHORIZE" Then

            obj.opencn()
            btran = obj.cn.BeginTransaction

            Try

                For i = 0 To GridView1.Rows.Count - 1

                    sqlpass = "select convert(datetime,'" & GridView1.Rows(i).Cells(1).Text & "',103),convert(datetime,'" & GridView1.Rows(i).Cells(7).Text & "',103) "

                    cmd = New SqlCommand(sqlpass, obj.cn)
                    cmd.Transaction = btran
                    dr = cmd.ExecuteReader

                    If dr.HasRows = True Then
                        dr.Read()
                        orddt = dr.Item(0)
                        reqdt = dr.Item(1)
                    End If

                    dr.Close()


                    sqlpass = "exec jct_ops_sales_team_budget_entry '" & _
                            LTrim(RTrim(Me.ddl_action.Text)) & "'," & _
                            Right(RTrim(Me.ddl_yearmonth.Text), 6) & ",'" & _
                            LTrim(RTrim(Me.ddl_team.Text)) & "','" & _
                            LTrim(RTrim(GridView1.Rows(i).Cells(0).Text)) & "','" & _
                            orddt & "'," & _
                            GridView1.Rows(i).Cells(2).Text & "," & _
                            GridView1.Rows(i).Cells(3).Text & ",'" & _
                            LTrim(RTrim(GridView1.Rows(i).Cells(4).Text)) & "','" & _
                            LTrim(RTrim(GridView1.Rows(i).Cells(5).Text)) & "','" & _
                            LTrim(RTrim(GridView1.Rows(i).Cells(6).Text)) & "','" & _
                            reqdt & "'," & _
                            GridView1.Rows(i).Cells(9).Text & "," & _
                            CType(GridView1.Rows(i).FindControl("txt_selqty"), TextBox).Text & ",'" & _
                            UCase(LTrim(RTrim(Session("empcode")))) & "','" & _
                            UCase(LTrim(RTrim(Session("companycode")))) & "','" & _
                            CType(GridView1.Rows(i).FindControl("ddlReason"), DropDownList).SelectedItem.Text & "','" + CType(GridView1.Rows(i).FindControl("txtRemarks"), TextBox).Text + "'"

                    cmd = New SqlCommand(sqlpass, obj.cn)
                    cmd.Transaction = btran
                    cmd.ExecuteNonQuery()


                    sqlpass = "insert into jct_pp_action_detail (date,detail,userid,hostname,company_code) " & _
                            "Select getdate(),'" & _
                            "TARGET-" & UCase(LTrim(RTrim(Me.ddl_action.Text))) & "'+'-'+'" & _
                            Me.ddl_yearmonth.Text & "'+'-'+'" & _
                            LTrim(RTrim(Me.ddl_team.Text)) & "'+'-'+'" & _
                            GridView1.Rows(i).Cells(0).Text & "'+'-','" & _
                            UCase(LTrim(RTrim(Session("empcode")))) & "', " & _
                            "LTrim(RTrim(host_name())) ,'" & _
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
                Me.lnk_exit_Click(sender, e)       ''  Execute EXIT button script
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
        'sqlpass = "exec jct_pp_sales_order_fetch '" & LTrim(RTrim(Me.ddl_action.Text)) & "'," & _
        '            Right(RTrim(Me.ddl_yearmonth.Text), 6) & ",'" & _
        '            LTrim(RTrim(Me.ddl_team.Text)) & "','" & _
        '            LTrim(RTrim(Me.txt_orderno.Text)) & "','" & _
        '            UCase(LTrim(RTrim(Session("empcode")))) & "','" & _
        '            UCase(LTrim(RTrim(Session("companycode")))) & "' "
        sqlpass = "exec jct_ops_sales_order_fetch '" & LTrim(RTrim(Me.ddl_action.Text)) & "'," & _
                  Right(RTrim(Me.ddl_yearmonth.Text), 6) & ",'" & _
                  LTrim(RTrim(Me.ddl_team.Text)) & "','" & _
                  LTrim(RTrim(Me.txt_orderno.Text)) & "','" & _
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

        Me.lnk_exit_Click(sender, e)       ''  Execute EXIT button script

    End Sub

    Protected Sub ddl_action_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl_action.SelectedIndexChanged

        If UCase(LTrim(RTrim(Me.ddl_action.Text))) = "ADD" And Me.lnk_add.Text = "ADD" Then

            Me.ddl_yearmonth.Enabled = True
            Me.ddl_team.Enabled = True
            Me.txt_orderno.Enabled = True

            Me.lnk_apply.Enabled = True

            Me.ddl_yearmonth.Focus()

        End If


        If UCase(LTrim(RTrim(Me.ddl_action.Text))) = "MODIFY" And Me.lnk_modify.Text = "MODIFY" Then

            Me.ddl_yearmonth.Enabled = True
            Me.ddl_team.Enabled = True
            Me.txt_orderno.Enabled = True

            Me.lnk_apply.Enabled = True

            Me.ddl_yearmonth.Focus()

        End If


        If UCase(LTrim(RTrim(Me.ddl_action.Text))) = "VIEW" Then

            Me.ddl_yearmonth.Enabled = True
            Me.ddl_team.Enabled = True
            Me.txt_orderno.Enabled = True

            Me.lnk_apply.Enabled = False
            Me.ddl_yearmonth.Focus()

        End If


        If UCase(LTrim(RTrim(Me.ddl_action.Text))) = "SHORT CLOSE" Or UCase(LTrim(RTrim(Me.ddl_action.Text))) = "AUTHORIZE" Then

            Me.ddl_yearmonth.Enabled = True
            Me.ddl_team.Enabled = True
            Me.txt_orderno.Enabled = True

            Me.lnk_apply.Enabled = True

            Me.ddl_yearmonth.Focus()

        End If

    End Sub

    Protected Sub lnk_modify_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnk_modify.Click

        If lnk_modify.Text = "MODIFY" Then

            Me.ddl_action.SelectedIndex = 2
            ddl_action_SelectedIndexChanged(sender, e)

            ' Me.lnk_add.Enabled = False
            Me.lnk_view.Enabled = False
            Me.lnk_modify.Enabled = True
            'Me.lnk_cancel.Enabled = False
            Me.lnk_close.Enabled = False
            Me.lnk_authorize.Enabled = False
            Me.lnk_exit.Enabled = True

            Me.lnk_modify.Text = "UPDATE"
            Me.lnk_exit.Text = "CANCEL"  '' "UNDO"

        ElseIf lnk_modify.Text = "UPDATE" Then

            Me.ddl_action.SelectedIndex = 2    ''  Set action in MODIFY mode
            Me.lnk_apply_Click(sender, e)      ''  Execute APPLY button script through LinkButton1_Click event
            ''Me.lnk_exit_Click(sender, e)       ''  Execute EXIT button script

        End If

    End Sub

    Protected Sub lnk_close_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnk_close.Click

        If lnk_close.Text = "DELETE" Then

            Me.ddl_action.SelectedIndex = 4
            ddl_action_SelectedIndexChanged(sender, e)

            '  Me.lnk_add.Enabled = False
            Me.lnk_view.Enabled = False
            Me.lnk_modify.Enabled = False
            'Me.lnk_cancel.Enabled = False
            Me.lnk_close.Enabled = True
            Me.lnk_authorize.Enabled = False
            Me.lnk_exit.Enabled = True

            Me.lnk_close.Text = "UPDATE"
            Me.lnk_exit.Text = "CANCEL"   '' "UNDO"

        ElseIf lnk_close.Text = "UPDATE" Then

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
            'Me.lnk_cancel.Enabled = False
            Me.lnk_close.Enabled = False
            Me.lnk_authorize.Enabled = True
            Me.lnk_exit.Enabled = True

            Me.lnk_authorize.Text = "UPDATE"
            Me.lnk_exit.Text = "CANCEL"  '' "UNDO"

        ElseIf lnk_authorize.Text = "UPDATE" Then

            Me.ddl_action.SelectedIndex = 5    ''  Set action in AUTHORIZE mode
            Me.lnk_apply_Click(sender, e)      ''  Execute APPLY button script through LinkButton1_Click event
            Me.lnk_exit_Click(sender, e)       ''  Execute EXIT button script

        End If

    End Sub

    Protected Sub lnk_exit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnk_exit.Click

        If lnk_exit.Text = "CLOSE" And Me.lnk_add.Enabled = True And Me.lnk_view.Enabled = True And Me.lnk_modify.Enabled = True And Me.lnk_close.Enabled = True And Me.lnk_authorize.Enabled = True And Me.lnk_exit.Enabled = True Then
            Me.Dispose()
            Response.Redirect("default.aspx")
        Else

            Me.GridView2.DataSource = Nothing
            Me.GridView2.DataBind()

            Me.GridView1.Visible = True
            Me.GridView2.Visible = False
            'Me.lnk_excel.Enabled = False

            Me.ddl_action.SelectedIndex = 1
            ddl_action_SelectedIndexChanged(sender, e)

            Me.lnk_add.Enabled = True
            Me.lnk_view.Enabled = True
            Me.lnk_modify.Enabled = True
            'Me.lnk_cancel.Enabled = True
            Me.lnk_close.Enabled = True
            Me.lnk_authorize.Enabled = True
            Me.lnk_exit.Enabled = True

            Me.lnk_add.Text = "ADD"
            Me.lnk_view.Text = "VIEW"
            Me.lnk_modify.Text = "MODIFY"
            'Me.lnk_cancel.Text = "CANCEL"
            Me.lnk_close.Text = "DELETE"  '' "SHORT CLOSE"
            Me.lnk_authorize.Text = "AUTHORIZE"
            Me.lnk_exit.Text = "CLOSE"

            Me.ddl_yearmonth.Enabled = True
            Me.ddl_team.Enabled = True
            Me.txt_orderno.Enabled = True

            Me.txt_orderno.Text = ""

        End If

    End Sub


    Protected Sub lnk_teamlist_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnk_teamlist.Click

        Me.GridView1.DataSource = Nothing
        Me.GridView1.DataBind()
        'Me.lnk_excel.Enabled = True

        Me.lnk_exit.Text = "CANCEL"  '' "UNDO"
        Me.txt_orderno.Text = ""
        Me.txt_orderno.Enabled = False
        Me.lnk_add.Enabled = False
        Me.lnk_view.Enabled = False
        Me.lnk_modify.Enabled = False
        Me.lnk_close.Enabled = True
        Me.GridView1.Visible = False
        Me.GridView2.Visible = True

        ''-----ReFill GridView2
        sqlpass = "exec jct_OPS_team_budget_check_list " & Right(RTrim(Me.ddl_yearmonth.Text), 6) & ",'" & _
                    LTrim(RTrim(Me.ddl_team.Text)) & "','" & _
                    "T" & "','" & _
                    UCase(LTrim(RTrim(Session("empcode")))) & "','" & _
                    UCase(LTrim(RTrim(Session("companycode")))) & "' "

        obj.opencn()
        Dim Da As SqlDataAdapter = New SqlDataAdapter(sqlpass, obj.cn)

        Try

            Dim ds As DataSet = New DataSet()
            Da.Fill(ds)
            GridView2.DataSource = ds
            GridView2.DataBind()
        Catch ex As Exception
            obj.closecn()
            FMsg.Message = (ex.Message)
            FMsg.CssClass = "addmsg"
            FMsg.Display()
        Finally
            obj.closecn()
        End Try

    End Sub

    Protected Sub lnk_blendlist_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnk_blendlist.Click

        Me.GridView1.DataSource = Nothing
        Me.GridView1.DataBind()
        'Me.lnk_excel.Enabled = True

        Me.lnk_exit.Text = "CANCEL"  '' "UNDO"
        Me.txt_orderno.Text = ""
        Me.txt_orderno.Enabled = False
        Me.lnk_add.Enabled = False
        Me.lnk_view.Enabled = False
        Me.lnk_modify.Enabled = False
        Me.lnk_close.Enabled = True
        Me.GridView1.Visible = False
        Me.GridView2.Visible = True

        ''-----ReFill GridView2
        sqlpass = "exec jct_OPS_team_budget_check_list " & Right(RTrim(Me.ddl_yearmonth.Text), 6) & ",'" & _
                    LTrim(RTrim(Me.ddl_team.Text)) & "','" & _
                    "B" & "','" & _
                    UCase(LTrim(RTrim(Session("empcode")))) & "','" & _
                    UCase(LTrim(RTrim(Session("companycode")))) & "' "

        obj.opencn()
        Dim Da As SqlDataAdapter = New SqlDataAdapter(sqlpass, obj.cn)

        Try

            Dim ds As DataSet = New DataSet()
            Da.Fill(ds)
            GridView2.DataSource = ds
            GridView2.DataBind()
        Catch ex As Exception
            obj.closecn()
            FMsg.Message = (ex.Message)
            FMsg.CssClass = "addmsg"
            FMsg.Display()
        Finally
            obj.closecn()
        End Try

    End Sub

    Protected Sub GridView2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView2.SelectedIndexChanged

    End Sub

    Protected Sub lnk_excel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnk_excel.Click

        If GridView1.Visible = False And GridView2.Visible = True Then

            ''GridViewExportUtil.Export("checklist.xls", Me.GridView2)
            Dim filename As String = "list_" + Right(RTrim(Me.ddl_yearmonth.Text), 6)
            GridViewExportUtil.Export(filename, Me.GridView2)

        End If

        Me.ddl_yearmonth.Enabled = True
        Me.ddl_team.Enabled = True

    End Sub


    Protected Sub lnk_update_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        ' If (ddl_action.SelectedItem.Text = "MODIFY") Then
        Dim lnk As LinkButton = sender

        For i = 0 To Me.GridView1.Rows.Count - 1

            If CType(GridView1.Rows(i).FindControl("lnk_update"), LinkButton).ClientID.Equals(lnk.ClientID) Then

                Dim orderqty As Integer = GridView1.Rows(i).Cells(9).Text
                Dim selqty As Integer = CType(GridView1.Rows(i).FindControl("txt_selqty"), TextBox).Text
                Dim reason As DropDownList = CType(GridView1.Rows(i).FindControl("ddlReason"), DropDownList)
                sql = "Select * from jct_ops_monthly_planning where yearmonth=" + ddl_yearmonth.SelectedItem.Text + " and mode='Freezed' and order_no='" + GridView1.Rows(i).Cells(0).Text + "' "
                If (obj1.CheckRecordExistInTransaction(sql)) Then
                    If (reason.SelectedItem.Text <> "") Then

                        sql = "exec JCT_OPS_MODIFIED_TARGET_PLANNING_MARKETING " & _
                             Right(RTrim(Me.ddl_yearmonth.Text), 6) & ",'" & _
                             LTrim(RTrim(Me.ddl_team.Text)) & "','" & _
                             LTrim(RTrim(GridView1.Rows(i).Cells(0).Text)) & "','" & _
                              LTrim(RTrim(GridView1.Rows(i).Cells(1).Text)) & "'," & _
                             GridView1.Rows(i).Cells(2).Text & "," & _
                             LTrim(RTrim(GridView1.Rows(i).Cells(4).Text)) & ",'" & _
                             GridView1.Rows(i).Cells(3).Text & "','" & _
                             LTrim(RTrim(GridView1.Rows(i).Cells(5).Text)) & "','" & _
                             LTrim(RTrim(GridView1.Rows(i).Cells(6).Text)) & "','" & _
                               LTrim(RTrim(GridView1.Rows(i).Cells(7).Text)) & "'," & _
                             GridView1.Rows(i).Cells(9).Text & "," & _
                             CType(GridView1.Rows(i).FindControl("txt_selqty"), TextBox).Text & ",'" & _
                             UCase(LTrim(RTrim(Session("empcode")))) & "','" & _
                             UCase(LTrim(RTrim(Session("companycode")))) & "','" & _
                             CType(GridView1.Rows(i).FindControl("ddlReason"), DropDownList).SelectedItem.Text & "','" + CType(GridView1.Rows(i).FindControl("txtRemarks"), TextBox).Text + "'"
                        If (obj1.UpdateRecord(sql)) Then
                            sql = "Select sel_qty from jct_ops_monthly_planning where yearmonth= " + ddl_yearmonth.SelectedItem.Text + " and Orderno='" + GridView1.Rows(i).Cells(0).Text + "' and Item_no='" + GridView1.Rows(i).Cells(3).Text + "' and variant='" + GridView1.Rows(i).Cells(5).Text + "'"
                            Dim sel_qty As Int16 = obj1.FetchValue(sql)
                            Dim body As String = "<p>Hello ,</p><p>You are receiving this email on the behalf of Marketing. It has been found that there is a need to change the  freezed plan for the month of - " + ddl_yearmonth.SelectedItem.Text + " . </p><p><H3> Modification is done in Order No. - " + GridView1.Rows(i).Cells(0).Text + "' </H3> </p> <p> <H3> Sort No. : " + GridView1.Rows(i).Cells(3).Text + "</H3>  </p> <p><h3>Variant :  " + GridView1.Rows(i).Cells(5).Text + "</h3></p><p> <H3>New Planned Quantity by marketing. : " + CType(GridView1.Rows(i).FindControl("txt_selqty"), TextBox).Text + "</H3></p><p>This quantity has been modified as per permission of : " + CType(GridView1.Rows(i).FindControl("ddlReason"), DropDownList).SelectedItem.Text + " .</p><p>This mail is a system generated mail and sent to you just for your information to change your Plan accordingly.</br>Please donot reply.</p><p>Thanks,<br/>JCT LTD, Phagwara</p>"
                            sm.SendMail("jatindutta@jctltd.com", "dummy@jctltd.com", "Plan Modified by Marketing of " + ddl_yearmonth.SelectedItem.Text + "", body)
                            Dim script1 As String = "alert('Record successfully changed. Planning Dept. has been intimated via email.');"
                            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ServerControlScript", script1, True)
                            Exit Sub
                        End If

                    Else
                        Dim script1 As String = "alert('This order has been freezed by planning dept, cant add or modify new items.If you want add/modify record, then please select appropriate permission from the list of items in the Reason Column');"
                        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ServerControlScript", script1, True)
                        Exit Sub
                    End If
                Else

                    If orderqty >= selqty Then

                        Dim btran As SqlTransaction
                        Dim orddt As Date
                        Dim reqdt As Date

                        obj.opencn()
                        btran = obj.cn.BeginTransaction

                        Try

                            sqlpass = "select convert(datetime,'" & GridView1.Rows(i).Cells(1).Text & "',103),convert(datetime,'" & GridView1.Rows(i).Cells(7).Text & "',103) "

                            cmd = New SqlCommand(sqlpass, obj.cn)
                            cmd.Transaction = btran
                            dr = cmd.ExecuteReader

                            If dr.HasRows = True Then
                                dr.Read()
                                orddt = dr.Item(0)
                                reqdt = dr.Item(1)
                            End If

                            dr.Close()


                            sqlpass = "exec jct_ops_sales_team_budget_entry '" & _
                                    LTrim(RTrim(Me.ddl_action.Text)) & "'," & _
                                    Right(RTrim(Me.ddl_yearmonth.Text), 6) & ",'" & _
                                    LTrim(RTrim(Me.ddl_team.Text)) & "','" & _
                                    LTrim(RTrim(GridView1.Rows(i).Cells(0).Text)) & "','" & _
                                    orddt & "'," & _
                                    GridView1.Rows(i).Cells(2).Text & "," & _
                                    LTrim(RTrim(GridView1.Rows(i).Cells(4).Text)) & ",'" & _
                                    GridView1.Rows(i).Cells(3).Text & "','" & _
                                    LTrim(RTrim(GridView1.Rows(i).Cells(5).Text)) & "','" & _
                                    LTrim(RTrim(GridView1.Rows(i).Cells(6).Text)) & "','" & _
                                    reqdt & "'," & _
                                    GridView1.Rows(i).Cells(9).Text & "," & _
                                    CType(GridView1.Rows(i).FindControl("txt_selqty"), TextBox).Text & ",'" & _
                                    UCase(LTrim(RTrim(Session("empcode")))) & "','" & _
                                    UCase(LTrim(RTrim(Session("companycode")))) & "','" & _
                                    CType(GridView1.Rows(i).FindControl("ddlReason"), DropDownList).SelectedItem.Text & "','" + CType(GridView1.Rows(i).FindControl("txtRemarks"), TextBox).Text + "'"


                            cmd = New SqlCommand(sqlpass, obj.cn)
                            cmd.Transaction = btran
                            cmd.ExecuteNonQuery()


                            btran.Commit()
                            'dr.Close()
                            obj.closecn()
                            ''''''''''Meaasage'''''''''''''
                             Dim script1 As String = "alert('Record Saved..');"
                            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ServerControlScript", script1, True)
                            '''''''''''''''''''''''''''''''
                            ' imb_fetch_Click(sender, Nothing)
                        Catch ex As Exception

                            btran.Rollback()
                            'dr.Close()
                            obj.closecn()
                            FMsg.Message = (ex.Message)
                            FMsg.CssClass = "addmsg"
                            FMsg.Display()
                            Me.lnk_exit_Click(sender, e)       ''  Execute EXIT button script
                            Exit Sub

                        End Try
                    Else
                        Dim script1 As String = "alert('Quantity cannot be greater than order qty. Please correct your entry.');"
                        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ServerControlScript", script1, True)
                        CType(GridView1.Rows(i).FindControl("txt_selqty"), TextBox).Text = ""
                        CType(GridView1.Rows(i).FindControl("txt_selqty"), TextBox).Focus()
                    End If
                End If

            End If

        Next
        'Else

        '    Dim script1 As String = "alert('Please select Modify option first.');"
        '    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ServerControlScript", script1, True)
        'End If
    End Sub


    Protected Sub lnk_list_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnk_list.Click

        Me.GridView1.DataSource = Nothing
        Me.GridView1.DataBind()
        'Me.lnk_excel.Enabled = True

        Me.lnk_exit.Text = "CANCEL"  '' "UNDO"
        Me.txt_orderno.Text = ""
        Me.txt_orderno.Enabled = False
        Me.lnk_add.Enabled = False
        Me.lnk_view.Enabled = False
        Me.lnk_modify.Enabled = False
        Me.lnk_close.Enabled = True
        Me.GridView1.Visible = False
        Me.GridView2.Visible = True

        ''-----ReFill GridView2
        sqlpass = "select a.team_code as [Team], isnull(c.group_desc,'') as [Sale Person], " & _
                    "a.order_no as [Order No.], a.item_no as [Item Code], a.variant as [Variant], " & _
                    "isnull(sum(isnull(a.sel_qty,0)),0) as [Sel.Qty.] " & _
                    "from JCT_OPS_MONTHLY_PLANNING a, " & _
                    "miserp.som.dbo.jct_so_team_catg b, " & _
                    "miserp.som.dbo.m_cust_group c " & _
                    "where a.yearmonth = " & Right(RTrim(Me.ddl_yearmonth.Text), 6) & _
                    " and a.company_code='" & UCase(LTrim(RTrim(Session("companycode")))) & "' " & _
                    "and b.team_code='" & Me.ddl_team.Text & "' " & _
                    "and a.company_code=b.company " & _
                    "and a.order_no=b.order_no " & _
                    "and b.sale_person_code*=c.group_no " & _
                    "and c.group_type='SALESP' " & _
                    "and b.company=c.company_no " & _
                    "group by a.team_code,c.group_desc,a.order_no,a.item_no,a.variant " & _
                    "having isnull(sum(isnull(a.sel_qty,0)),0)>0 " & _
                    "order by a.team_code,c.group_desc,a.order_no,a.item_no,a.variant"

        obj.opencn()
        Dim Da As SqlDataAdapter = New SqlDataAdapter(sqlpass, obj.cn)

        Try

            Dim ds As DataSet = New DataSet()
            Da.Fill(ds)
            GridView2.DataSource = ds
            GridView2.DataBind()
        Catch ex As Exception
            obj.closecn()
            FMsg.Message = (ex.Message)
            FMsg.CssClass = "addmsg"
            FMsg.Display()
        Finally
            obj.closecn()
        End Try

    End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound

      
        If e.Row.RowType = DataControlRowType.Header Then
            ' e.Row.Cells(8).Visible = False
            'e.Row.Cells(10).Visible = False

        End If
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim looms As Label = CType(e.Row.Cells(10).FindControl("lblLooms"), Label)
            Dim Meters As TextBox = CType(e.Row.Cells(12).FindControl("txt_selqty"), TextBox)

            'e.Row.Cells(8).Visible = False
            sumLooms = sumLooms + Decimal.Parse(looms.Text)
            sumMeters = sumMeters + Decimal.Parse(Meters.Text)

        End If
        If e.Row.RowType = DataControlRowType.Footer Then

            e.Row.Cells(9).Text = "Total Looms"
            e.Row.Cells(10).Text = sumLooms.ToString()
            e.Row.Cells(11).Text = "Total Meters"
            e.Row.Cells(12).Text = sumMeters.ToString()
        End If
    End Sub

    Protected Sub txtEffecTo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEffecTo.TextChanged
        If (txtEffecFrom.Text <> "") Then
            ddl_yearmonth.Items.Insert(0, yearMonth().ToString())

        End If
    End Sub

    Protected Function yearMonth() As Integer
        sql = "Select month('" + txtEffecFrom.Text & "')"
        mon = obj1.FetchValue(sql).ToString()
        Dim mon1 As Integer = Integer.Parse(mon)
        If mon1 < 10 Then
            mon = "0" & mon
        End If
        sql = "Select year('" + txtEffecFrom.Text & "')"
        Dim year As String = obj1.FetchValue(sql).ToString()
        Dim yearmonth1 As String = year + mon
        Dim year_month As Integer = Integer.Parse(yearmonth1)
        Return year_month
    End Function

    Protected Sub txt_selqty_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        'If (ddl_action.SelectedItem.Text = "MODIFY") Then
        Dim lnk As TextBox = sender

        For i = 0 To Me.GridView1.Rows.Count - 1

            If CType(GridView1.Rows(i).FindControl("txt_selqty"), TextBox).ClientID.Equals(lnk.ClientID) Then

                Dim orderqty As Integer = GridView1.Rows(i).Cells(9).Text
                Dim selqty As Integer = CType(GridView1.Rows(i).FindControl("txt_selqty"), TextBox).Text
                Dim reason As DropDownList = CType(GridView1.Rows(i).FindControl("ddlReason"), DropDownList)
                sql = "Select * from jct_ops_monthly_planning where yearmonth=" + ddl_yearmonth.SelectedItem.Text + " and mode='Freezed' and order_no='" + GridView1.Rows(i).Cells(0).Text + "' "
                If (obj1.CheckRecordExistInTransaction(sql)) Then
                    If (reason.SelectedItem.Text <> "") Then

                        sql = "exec JCT_OPS_MODIFIED_TARGET_PLANNING_MARKETING " & _
                             Right(RTrim(Me.ddl_yearmonth.Text), 6) & ",'" & _
                             LTrim(RTrim(Me.ddl_team.Text)) & "','" & _
                             LTrim(RTrim(GridView1.Rows(i).Cells(0).Text)) & "','" & _
                              LTrim(RTrim(GridView1.Rows(i).Cells(1).Text)) & "'," & _
                             GridView1.Rows(i).Cells(2).Text & "," & _
                             LTrim(RTrim(GridView1.Rows(i).Cells(4).Text)) & ",'" & _
                             GridView1.Rows(i).Cells(3).Text & "','" & _
                             LTrim(RTrim(GridView1.Rows(i).Cells(5).Text)) & "','" & _
                             LTrim(RTrim(GridView1.Rows(i).Cells(6).Text)) & "','" & _
                               LTrim(RTrim(GridView1.Rows(i).Cells(7).Text)) & "'," & _
                             GridView1.Rows(i).Cells(9).Text & "," & _
                             CType(GridView1.Rows(i).FindControl("txt_selqty"), TextBox).Text & ",'" & _
                             UCase(LTrim(RTrim(Session("empcode")))) & "','" & _
                             UCase(LTrim(RTrim(Session("companycode")))) & "','" & _
                             CType(GridView1.Rows(i).FindControl("ddlReason"), DropDownList).SelectedItem.Text & "','" + CType(GridView1.Rows(i).FindControl("txtRemarks"), TextBox).Text + "'"
                        If (obj1.UpdateRecord(sql)) Then
                            sql = "Select sel_qty from jct_ops_monthly_planning where yearmonth= " + ddl_yearmonth.SelectedItem.Text + " and Orderno='" + GridView1.Rows(i).Cells(0).Text + "' and Item_no='" + GridView1.Rows(i).Cells(3).Text + "' and variant='" + GridView1.Rows(i).Cells(5).Text + "'"
                            Dim sel_qty As Int16 = obj1.FetchValue(sql)
                            Dim body As String = "<p>Hello ,</p><p>You are receiving this email on the behalf of Marketing. It has been found that there is a need to change the  freezed plan for the month of - " + ddl_yearmonth.SelectedItem.Text + " . </p><p><H3> Modification is done in Order No. - " + GridView1.Rows(i).Cells(0).Text + "' </H3> </p> <p> <H3> Sort No. : " + GridView1.Rows(i).Cells(3).Text + "</H3>  </p> <p><h3>Variant :  " + GridView1.Rows(i).Cells(5).Text + "</h3></p><p> <H3>New Planned Quantity by marketing. : " + CType(GridView1.Rows(i).FindControl("txt_selqty"), TextBox).Text + "</H3></p><p>This quantity has been modified as per permission of : " + CType(GridView1.Rows(i).FindControl("ddlReason"), DropDownList).SelectedItem.Text + " .</p><p>This mail is a system generated mail and sent to you just for your information to change your Plan accordingly.</br>Please donot reply.</p><p>Thanks,<br/>JCT LTD, Phagwara</p>"
                            ' sm.SendMail("jatindutta@jctltd.com", "dummy@jctltd.com", "Plan Modified by Marketing of " + ddl_yearmonth.SelectedItem.Text + "", body)
                            Dim script1 As String = "alert('Record successfully changed. Planning Dept. has been intimated via email.');"
                            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ServerControlScript", script1, True)
                            Exit Sub
                        End If

                    Else
                        Dim script1 As String = "alert('This order has been freezed by planning dept, cant add or modify new items.If you want add/modify record, then please select appropriate permission from the list of items in the Reason Column');"
                        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ServerControlScript", script1, True)
                        Exit Sub
                    End If
                Else

                    If orderqty >= selqty Then

                        Dim btran As SqlTransaction
                        Dim orddt As Date
                        Dim reqdt As Date

                        obj.opencn()
                        btran = obj.cn.BeginTransaction

                        Try

                            sqlpass = "select convert(datetime,'" & GridView1.Rows(i).Cells(1).Text & "',103),convert(datetime,'" & GridView1.Rows(i).Cells(7).Text & "',103) "

                            cmd = New SqlCommand(sqlpass, obj.cn)
                            cmd.Transaction = btran
                            dr = cmd.ExecuteReader

                            If dr.HasRows = True Then
                                dr.Read()
                                orddt = dr.Item(0)
                                reqdt = dr.Item(1)
                            End If

                            dr.Close()
                            sqlpass = "exec jct_ops_sales_team_budget_entry '" & _
                                    LTrim(RTrim(Me.ddl_action.Text)) & "'," & _
                                    Right(RTrim(Me.ddl_yearmonth.Text), 6) & ",'" & _
                                    LTrim(RTrim(Me.ddl_team.Text)) & "','" & _
                                    LTrim(RTrim(GridView1.Rows(i).Cells(0).Text)) & "','" & _
                                    orddt & "'," & _
                                    GridView1.Rows(i).Cells(2).Text & "," & _
                                    LTrim(RTrim(GridView1.Rows(i).Cells(4).Text)) & ",'" & _
                                    GridView1.Rows(i).Cells(3).Text & "','" & _
                                    LTrim(RTrim(GridView1.Rows(i).Cells(5).Text)) & "','" & _
                                    LTrim(RTrim(GridView1.Rows(i).Cells(6).Text)) & "','" & _
                                    reqdt & "'," & _
                                    GridView1.Rows(i).Cells(9).Text & "," & _
                                    CType(GridView1.Rows(i).FindControl("txt_selqty"), TextBox).Text & ",'" & _
                                    UCase(LTrim(RTrim(Session("empcode")))) & "','" & _
                                    UCase(LTrim(RTrim(Session("companycode")))) & "','" & _
                                    CType(GridView1.Rows(i).FindControl("ddlReason"), DropDownList).SelectedItem.Text & "','" + CType(GridView1.Rows(i).FindControl("txtRemarks"), TextBox).Text + "'"


                            cmd = New SqlCommand(sqlpass, obj.cn)
                            cmd.Transaction = btran
                            cmd.ExecuteNonQuery()


                            btran.Commit()
                            'dr.Close()
                            obj.closecn()
                            ''''''''''Meaasage'''''''''''''
                            FMsg.Message = "Success"
                            FMsg.CssClass = "addmsg"
                            FMsg.Display()
                            '''''''''''''''''''''''''''''''
                            '  imb_fetch_Click(sender, Nothing)
                        Catch ex As Exception

                            btran.Rollback()
                            'dr.Close()
                            obj.closecn()
                            FMsg.Message = (ex.Message)
                            FMsg.CssClass = "addmsg"
                            FMsg.Display()
                            Me.lnk_exit_Click(sender, e)       ''  Execute EXIT button script
                            Exit Sub

                        End Try
                    Else
                        FMsg.Message = "Required quantity cannot be greater than order qty. Please correct your entry."
                        FMsg.CssClass = "errormsg"
                        FMsg.Display()
                        CType(GridView1.Rows(i).FindControl("txt_selqty"), TextBox).Text = ""
                        CType(GridView1.Rows(i).FindControl("txt_selqty"), TextBox).Focus()
                    End If
                End If

            End If

        Next
        '    Else
        '
        '  Dim script1 As String = "alert('Please select Modify option first.');"
        '  ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ServerControlScript", script1, True)
        '  End If
    End Sub
End Class
