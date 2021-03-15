Imports System.Data.SqlClient
Imports System.Data
Imports System.Web.HttpResponse
Imports vb = Microsoft.VisualBasic
Imports System.String
Imports System.Math

Partial Class ProductionPlanning_norm_master
    Inherits System.Web.UI.Page
    Dim sql As String
    Dim dr As SqlDataReader
    Dim cmd As SqlCommand
    Dim sqlpass As String
    Public obj As New HelpDeskClass
    Dim Ash As Integer

    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GridView1.PageIndex = e.NewPageIndex

        ''-----ReFill Current Norm Master in GridView1
        sqlpass = "exec jct_pp_norm_master_list '" & LTrim(RTrim(Me.ddl_normcatg.Text)) & "','" & _
        LTrim(RTrim(Me.ddl_catgcode.Text)) & "','" & _
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

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound

        If e.Row.RowType <> DataControlRowType.DataRow Then
            Exit Sub
        End If
        e.Row.Attributes.Add("OnClick", Me.Page.ClientScript.GetPostBackEventReference(e.Row.Cells(0).FindControl("Lnk_Select"), String.Empty))

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Session("Companycode") = "JCT00LTD"
        'Session("Empcode") = "C-00509"

        If Not IsPostBack Then

            ''txt_tranno.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)) {document.getElementById('" + btn_enter.UniqueID + "').click();return false;}} else {return true}; ")
            ''txt_tranno.Attributes.Add("onkeypress", "return clickButton(event,'" + btn_enter.ClientID + "')")

            sqlpass = "select convert(varchar(11),getdate(),103) "

            obj.opencn()
            cmd = New SqlCommand(sqlpass, obj.cn)
            dr = cmd.ExecuteReader

            If dr.HasRows = True Then
                dr.Read()
                Me.txt_effdate.Text = dr.Item(0)
                Me.txt_expdate.Text = dr.Item(0)
            End If
            dr.Close()
            obj.closecn()

            Me.rbt_yes.Checked = False
            Me.rbt_no.Checked = False
            Me.Panel2.Visible = False

            ''-----Fill Action Combo Box
            sqlpass = "/*select b.action,b.mnuname,b.description,b.parent_menu,b.seq " & _
                " from production..user_module_menus_mapping a inner join production..modules_menu_master b " & _
                " on a.module=b.module and a.mnuname=b.mnuname and a.action=b.action " & _
                " where a.module ='PP' and a.uname='" & Session("empcode") & "' and a.mnuname='mnunorms'" & _
                " union*/ select b.action,b.mnuname,b.description,parent_menu,case b.action when 'ADD' then '1' when 'VIEW' then '2' when 'MODIFY' then '3' when 'CANCEL' then '4' when 'SHORT CLOSE' then '5' when 'AUTHORIZE' then '6' end /*b.seq*/ " & _
                " from production..role_module_menus_mapping a inner join production..modules_menu_master b " & _
                " on a.module=b.module and a.mnuname=b.mnuname and a.action=b.action " & _
                " inner join production..role_user_mapping e on a.role=e.role " & _
                " where a.module ='PP' and e.uname='" & Session("empcode") & "' and a.mnuname='mnunorms'" & _
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
            Me.lnk_view_Click(sender, e)  '' set view mode at page loading time



            ''-----Fill Norm Catg. Combo Box
            sqlpass = "select distinct catg_desc from jct_pp_norm_master " & _
                        "where convert(datetime,convert(varchar(11),getdate())) " & _
                        "between effective_date and expire_date " & _
                        "and company_code='" & UCase(LTrim(RTrim(Session("companycode")))) & "' " & _
                        "order by catg_desc "

            obj.opencn()
            cmd = New SqlCommand(sqlpass, obj.cn)
            dr = cmd.ExecuteReader

            If dr.HasRows = True Then
                While dr.Read
                    Me.ddl_normcatg.Items.Add(dr.Item(0))
                End While
                Me.ddl_normcatg.SelectedIndex = 0
            End If
            dr.Close()
            obj.closecn()



            ''-----Fill Norm Unit Combo Box
            sqlpass = "select distinct norm_unit from jct_pp_norm_master " & _
                        "where convert(datetime,convert(varchar(11),getdate())) " & _
                        "between effective_date and expire_date " & _
                        "and company_code='" & UCase(LTrim(RTrim(Session("companycode")))) & "' "

            obj.opencn()
            cmd = New SqlCommand(sqlpass, obj.cn)
            dr = cmd.ExecuteReader

            If dr.HasRows = True Then
                While dr.Read
                    Me.ddl_uom.Items.Add(dr.Item(0))
                End While
                Me.ddl_uom.SelectedIndex = 0
            End If
            dr.Close()
            obj.closecn()


            ''-----Fill Team in Catg. Code Combo Box
            sqlpass = "select distinct team_code from miserp.som.dbo.jct_team_master " & _
                    "where convert(datetime,convert(varchar(11),getdate())) between eff_from and eff_to " & _
                    "and status='O' " & _
                    "and company='" & UCase(LTrim(RTrim(Session("companycode")))) & "' " & _
                    "and team_code<>'HOD' " & _
                    "order by team_code "

            obj.opencn()
            cmd = New SqlCommand(sqlpass, obj.cn)
            dr = cmd.ExecuteReader

            Me.ddl_catgcode.Items.Clear()

            If dr.HasRows = True Then
                While dr.Read
                    Me.ddl_catgcode.Items.Add(dr.Item(0))
                End While
                Me.ddl_catgcode.SelectedIndex = 0
            End If
            dr.Close()
            obj.closecn()


            If LTrim(RTrim(Me.ddl_normcatg.Text)) = "TEAM" Then
                Me.ddl_uom.Text = "LOOMS"
                Me.Label5.Text = "Loom Alloted"
                Dim i As Integer = 0
                For i = 0 To Me.ddl_catgcode.Items.Count - 1
                    If Me.ddl_catgcode.Items(i).Text = "..." Then
                        Me.ddl_catgcode.Items.RemoveAt(i)
                    End If
                Next
            Else
                Me.ddl_catgcode.Items.Clear()
                Me.ddl_uom.Text = "METRES"
                Me.Label5.Text = "Capacity"
                Me.ListBox1.Items.Clear()
                Dim i As Integer = 0
                For i = 0 To Me.ddl_catgcode.Items.Count - 1
                    If Me.ddl_catgcode.Items(i).Text = "..." Then
                        Me.ddl_catgcode.Items.RemoveAt(i)
                    End If
                Next
                Me.ddl_catgcode.Items.Add("...")
                Me.ddl_catgcode.Text = "..."
            End If


            ''-----Fill Sale Person under Team in Listbox1
            sqlpass = "select distinct b.group_desc " & _
                        "from miserp.som.dbo.jct_team_saleperson_mapping a, " & _
                        "miserp.som.dbo.m_cust_group b " & _
                        "where a.team_code ='" & Me.ddl_catgcode.Text & "' " & _
                        "and convert(datetime,convert(varchar(11),getdate())) " & _
                        "between a.eff_from and a.eff_to " & _
                        "and a.status='O' " & _
                        "and a.sale_person_code=b.group_no " & _
                        "and a.company='" & UCase(LTrim(RTrim(Session("companycode")))) & "' " & _
                        "and b.group_type='SALESP' " & _
                        "and a.status=b.status " & _
                        "and a.company=b.company_no " & _
                        "and (ltrim(rtrim(left(ltrim(b.group_no),1)+'-'+substring(b.group_no,2,len(b.group_no)))) " & _
                        "in (select distinct ltrim(rtrim(empcode)) from empmast " & _
                        "where deptcode in ('SAL','EXP','YSAL') and monthyear=(select top 1 monthyear from empmast " & _
                        "where deptcode in ('SAL','EXP','YSAL') order by monthyear desc)) or b.group_no='ANURAG') " & _
                        "order by b.group_desc "

            obj.opencn()
            cmd = New SqlCommand(sqlpass, obj.cn)
            dr = cmd.ExecuteReader

            Me.ListBox1.Items.Clear()

            If dr.HasRows = True Then
                While dr.Read
                    Me.ListBox1.Items.Add(dr.Item(0))
                End While
            End If
            dr.Close()
            obj.closecn()


            ''-----Fill Current Norm Master in GridView1
            sqlpass = "exec jct_pp_norm_master_list '" & LTrim(RTrim(Me.ddl_normcatg.Text)) & "','" & _
            LTrim(RTrim(Me.ddl_catgcode.Text)) & "','" & _
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

        End If

    End Sub

    Protected Sub lnk_apply_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnk_apply.Click

        Dim same As String = "N"
        Dim greater As String = "N"
        Dim i As Integer = 0

        If LTrim(RTrim(Me.ddl_normcatg.Text)) = "" And (UCase(LTrim(RTrim(Me.ddl_action.Text))) = "ADD" Or UCase(LTrim(RTrim(Me.ddl_action.Text))) = "MODIFY") Then
            FMsg.Message = "Invalid norm category "
            FMsg.CssClass = "errormsg"
            FMsg.Display()
            Me.ddl_normcatg.Focus()
            Exit Sub
        End If


        If LTrim(RTrim(Me.ddl_catgcode.Text)) = "" And (UCase(LTrim(RTrim(Me.ddl_action.Text))) = "ADD" Or UCase(LTrim(RTrim(Me.ddl_action.Text))) = "MODIFY") Then
            FMsg.Message = "Invalid category code "
            FMsg.CssClass = "errormsg"
            FMsg.Display()
            Me.ddl_catgcode.Focus()
            Exit Sub
        End If


        If LTrim(RTrim(Me.ddl_uom.Text)) = "" And (UCase(LTrim(RTrim(Me.ddl_action.Text))) = "ADD" Or UCase(LTrim(RTrim(Me.ddl_action.Text))) = "MODIFY") Then
            FMsg.Message = "Invalid u.o.m. "
            FMsg.CssClass = "errormsg"
            FMsg.Display()
            Me.ddl_uom.Focus()
            Exit Sub
        End If


        If LTrim(RTrim(txt_normvalue.Text)) = "" And (UCase(LTrim(RTrim(Me.ddl_action.Text))) = "ADD" Or UCase(LTrim(RTrim(Me.ddl_action.Text))) = "MODIFY") Then
            FMsg.Message = "Pl.enter norm value "
            FMsg.CssClass = "errormsg"
            FMsg.Display()
            Me.txt_normvalue.Focus()
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



        Dim effdt As Date
        Dim expdt As Date

        sqlpass = "select convert(datetime,'" & Me.txt_effdate.Text & "',103),convert(datetime,'" & Me.txt_expdate.Text & "',103) "

        obj.opencn()
        cmd = New SqlCommand(sqlpass, obj.cn)
        dr = cmd.ExecuteReader

        If dr.HasRows = True Then
            dr.Read()
            effdt = dr.Item(0)
            expdt = dr.Item(1)
        Else
            FMsg.Message = "Something wromg in Eff./Exp. Date"
            FMsg.CssClass = "errormsg"
            FMsg.Display()
            Me.txt_effdate.Focus()
            dr.Close()
            obj.closecn()
            Exit Sub
        End If

        dr.Close()
        obj.closecn()



        If effdt > expdt Then
            FMsg.Message = "Expire date should be greater than or equal to effective date"
            FMsg.CssClass = "errormsg"
            FMsg.Display()
            Me.txt_effdate.Focus()
            Exit Sub
        End If


        Dim btran As SqlTransaction
        Dim activate As String


        If UCase(LTrim(RTrim(Me.ddl_action.Text))) = "ADD" Then

            obj.opencn()
            btran = obj.cn.BeginTransaction

            Try

                sqlpass = "select top 1 convert(datetime,convert(char(12),effective_date)),convert(datetime,convert(char(12),expire_date)) " & _
                        "from jct_pp_norm_master " & _
                        "where ltrim(rtrim(catg_desc))='" & UCase(LTrim(RTrim(Me.ddl_normcatg.Text))) & "' " & _
                        "and ltrim(rtrim(code))='" & UCase(LTrim(RTrim(Me.ddl_catgcode.Text))) & "' " & _
                        "and ltrim(rtrim(active))='Y' " & _
                        "and ltrim(rtrim(company_code))='" & UCase(LTrim(RTrim(Session("companycode")))) & "' " & _
                        "order by expire_date desc"

                cmd = New SqlCommand(sqlpass, obj.cn)
                cmd.Transaction = btran
                dr = cmd.ExecuteReader

                If dr.HasRows = True Then

                    dr.Read()
                    If effdt >= CDate(dr.Item(0)).Date And expdt <= CDate(dr.Item(1)).Date Then
                        FMsg.Message = "Date Period already exists"
                        FMsg.CssClass = "errormsg"
                        FMsg.Display()
                        dr.Close()
                        obj.closecn()
                        Exit Sub
                    End If

                    If effdt <= CDate(dr.Item(0)).Date Or expdt <= CDate(dr.Item(1)).Date Then
                        FMsg.Message = "Back date entries are not allowed or effective date already exists"
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

                    If effdt > CDate(dr.Item(1)).Date Then
                        greater = "Y"
                    Else
                        greater = "N"
                    End If

                    dr.Close()



                    If Me.rbt_yes.Checked = False And Me.rbt_no.Checked = False Then
                        Me.Panel2.Visible = True
                        Me.rbt_no.Checked = True
                        Exit Sub
                    Else
                        Me.Panel2.Visible = False
                    End If

                    'If MsgBox("Item already exists,Do you want to create item with new parameters", MsgBoxStyle.YesNo) = vbYes Then

                    If Me.rbt_yes.Checked = True Then

                        sqlpass = "select top 1 date from jct_pp_forecast_detail " & _
                                "where ltrim(rtrim(blend))='" & UCase(LTrim(RTrim(Me.ddl_normcatg.Text))) & "' " & _
                                "and convert(datetime,convert(char(12),date),103)>='" & CDate(Me.txt_effdate.Text).Date & "' " & _
                                "and ltrim(rtrim(company_code))='" & UCase(LTrim(RTrim(Session("companycode")))) & "' " & _
                                "order by date desc "

                        cmd = New SqlCommand(sqlpass, obj.cn)
                        cmd.Transaction = btran
                        dr = cmd.ExecuteReader

                        If dr.HasRows = True Then

                            Dim dt As Date = dr.Item(0)

                            dr.Close()

                            sqlpass = "select convert(varchar(11),'" & DateAdd(DateInterval.Day, 1, dt) & "',103) "

                            cmd = New SqlCommand(sqlpass, obj.cn)
                            cmd.Transaction = btran
                            dr = cmd.ExecuteReader

                            If dr.HasRows = True Then
                                dr.Read()
                                Me.txt_effdate.Text = dr.Item(0)
                            Else
                                FMsg.Message = "Something wromg in Date"
                                FMsg.CssClass = "errormsg"
                                FMsg.Display()
                                Me.txt_effdate.Focus()
                                dr.Close()
                                obj.closecn()
                                Exit Sub
                            End If

                            dr.Close()


                            'Me.txt_effdate.Text = DateAdd(DateInterval.Day, 1, dr.Item(0))
                            'dr.Close()

                            sqlpass = "update jct_pp_norm_master set active='N',expire_date='" & dt & "' " & _
                                    "where ltrim(rtrim(catg_desc))='" & UCase(LTrim(RTrim(Me.ddl_normcatg.Text))) & "' " & _
                                    "and ltrim(rtrim(code))='" & UCase(LTrim(RTrim(Me.ddl_catgcode.Text))) & "' " & _
                                    "and ltrim(rtrim(active))='Y' " & _
                                    "and ltrim(rtrim(company_code))='" & UCase(LTrim(RTrim(Session("companycode")))) & "'"
                            dr.Close()
                        Else
                            ''Me.dtp_effdate.Text = Now()
                            dr.Close()

                            If greater = "Y" Then
                                sqlpass = "update jct_pp_norm_master set active='N' " & _
                                        "where ltrim(rtrim(catg_desc))='" & UCase(LTrim(RTrim(Me.ddl_normcatg.Text))) & "' " & _
                                        "and ltrim(rtrim(code))='" & UCase(LTrim(RTrim(Me.ddl_catgcode.Text))) & "' " & _
                                        "and ltrim(rtrim(active))='Y' " & _
                                        "and ltrim(rtrim(company_code))='" & UCase(LTrim(RTrim(Session("companycode")))) & "'"
                            ElseIf same = "Y" Then


                                sqlpass = "select dateadd(dd,-1,convert(datetime,'" & Me.txt_effdate.Text & "',103)), dateadd(dd,-1,convert(datetime,'" & Me.txt_expdate.Text & "',103)) "

                                cmd = New SqlCommand(sqlpass, obj.cn)
                                cmd.Transaction = btran
                                dr = cmd.ExecuteReader

                                If dr.HasRows = True Then
                                    dr.Read()
                                    effdt = dr.Item(0)
                                    expdt = dr.Item(1)
                                Else
                                    FMsg.Message = "Something wromg in Eff./Exp. Date"
                                    FMsg.CssClass = "errormsg"
                                    FMsg.Display()
                                    Me.txt_effdate.Focus()
                                    dr.Close()
                                    obj.closecn()
                                    Exit Sub
                                End If

                                dr.Close()


                                sqlpass = "update jct_pp_norm_master set active='N', " & _
                                        "effective_date='" & effdt & "', " & _
                                        "expire_date='" & effdt & "' " & _
                                        "where ltrim(rtrim(catg_desc))='" & UCase(LTrim(RTrim(Me.ddl_normcatg.Text))) & "' " & _
                                        "and ltrim(rtrim(code))='" & UCase(LTrim(RTrim(Me.ddl_catgcode.Text))) & "' " & _
                                        "and ltrim(rtrim(active))='Y' " & _
                                        "and ltrim(rtrim(company_code))='" & UCase(LTrim(RTrim(Session("companycode")))) & "'"
                            Else
                                sqlpass = "update jct_pp_norm_master set active='N', " & _
                                        "expire_date='" & effdt & "' " & _
                                        "where ltrim(rtrim(catg_desc))='" & UCase(LTrim(RTrim(Me.ddl_normcatg.Text))) & "' " & _
                                        "and ltrim(rtrim(code))='" & UCase(LTrim(RTrim(Me.ddl_catgcode.Text))) & "' " & _
                                        "and ltrim(rtrim(active))='Y' " & _
                                        "and ltrim(rtrim(company_code))='" & UCase(LTrim(RTrim(Session("companycode")))) & "'"
                            End If

                        End If

                        cmd = New SqlCommand(sqlpass, obj.cn)
                        cmd.Transaction = btran
                        cmd.ExecuteNonQuery()


                        'rbt_activeyes.Checked = True

                        'If Me.rbt_activeyes.Checked = True Then
                        activate = "Y"
                        'Else
                        'activate = "N"
                        'End If




                        sqlpass = "select convert(datetime,'" & Me.txt_effdate.Text & "',103),convert(datetime,'" & Me.txt_expdate.Text & "',103) "

                        cmd = New SqlCommand(sqlpass, obj.cn)
                        cmd.Transaction = btran
                        dr = cmd.ExecuteReader

                        If dr.HasRows = True Then
                            dr.Read()
                            effdt = dr.Item(0)
                            expdt = dr.Item(1)
                        Else
                            FMsg.Message = "Something wromg in Eff./Exp. Date"
                            FMsg.CssClass = "errormsg"
                            FMsg.Display()
                            Me.txt_effdate.Focus()
                            dr.Close()
                            obj.closecn()
                            Exit Sub
                        End If

                        dr.Close()




                        sqlpass = "exec jct_pp_norm_master_entry '" & _
                                    LTrim(RTrim(Me.ddl_action.Text)) & "','" & _
                                    LTrim(RTrim(Me.ddl_normcatg.Text)) & "','" & _
                                    LTrim(RTrim(Me.ddl_catgcode.Text)) & "','" & _
                                    LTrim(RTrim(Me.ddl_uom.Text)) & "'," & _
                                    Me.txt_normvalue.Text & ",'" & _
                                    effdt & "','" & _
                                    expdt & "','" & _
                                    activate & "','" & _
                                    UCase(LTrim(RTrim(Session("empcode")))) & "','" & _
                                    UCase(LTrim(RTrim(Session("companycode")))) & "'"

                        cmd = New SqlCommand(sqlpass, obj.cn)
                        cmd.Transaction = btran
                        cmd.ExecuteNonQuery()

                    Else  '' else of if add new parameters = yes 
                        dr.Close()
                        obj.closecn()
                        Me.ddl_normcatg.Focus()
                        Me.lnk_exit_Click(sender, e)       ''  Execute EXIT button script
                        Exit Sub
                    End If '' end of if add new parameters = yes

                Else  '' else of if hasrows = true

                    dr.Close()

                    'rbt_activeyes.Checked = True

                    'If Me.rbt_activeyes.Checked = True Then
                    activate = "Y"
                    'Else
                    'activate = "N"
                    'End If



                    sqlpass = "select convert(datetime,'" & Me.txt_effdate.Text & "',103),convert(datetime,'" & Me.txt_expdate.Text & "',103) "

                    cmd = New SqlCommand(sqlpass, obj.cn)
                    cmd.Transaction = btran
                    dr = cmd.ExecuteReader

                    If dr.HasRows = True Then
                        dr.Read()
                        effdt = dr.Item(0)
                        expdt = dr.Item(1)
                    Else
                        FMsg.Message = "Something wromg in Eff./Exp. Date"
                        FMsg.CssClass = "errormsg"
                        FMsg.Display()
                        Me.txt_effdate.Focus()
                        dr.Close()
                        obj.closecn()
                        Exit Sub
                    End If

                    dr.Close()



                    sqlpass = "exec jct_pp_norm_master_entry '" & _
                                LTrim(RTrim(Me.ddl_action.Text)) & "','" & _
                                LTrim(RTrim(Me.ddl_normcatg.Text)) & "','" & _
                                LTrim(RTrim(Me.ddl_catgcode.Text)) & "','" & _
                                LTrim(RTrim(Me.ddl_uom.Text)) & "'," & _
                                Me.txt_normvalue.Text & ",'" & _
                                effdt & "','" & _
                                expdt & "','" & _
                                activate & "','" & _
                                UCase(LTrim(RTrim(Session("empcode")))) & "','" & _
                                UCase(LTrim(RTrim(Session("companycode")))) & "'"

                    cmd = New SqlCommand(sqlpass, obj.cn)
                    cmd.Transaction = btran
                    cmd.ExecuteNonQuery()

                End If  '' end of if hasrows = true


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
                Me.lnk_exit_Click(sender, e)       ''  Execute EXIT button script
                Exit Sub
            End Try

        End If  '' end of ADD mode


        ''===========================================================


        If UCase(LTrim(RTrim(Me.ddl_action.Text))) = "MODIFY" Then

            Dim cnt As Integer = 0

            For i = 0 To GridView1.Rows.Count - 1
                If (CType(GridView1.Rows(i).FindControl("CheckBox1"), CheckBox).Checked) = True Then
                    cnt = cnt + 1
                End If
            Next

            If cnt > 1 Then
                FMsg.Message = "Pl. select single record for modification"
                FMsg.CssClass = "errormsg"
                FMsg.Display()
                'dr.Close()
                obj.closecn()
                Exit Sub
            End If

            obj.opencn()
            btran = obj.cn.BeginTransaction

            Try

                'rbt_activeyes.Checked = True

                'If Me.rbt_activeyes.Checked = True Then
                'activate = "Y"
                'Else
                'activate = "N"
                'End If

                For i = 0 To GridView1.Rows.Count - 1

                    If (CType(GridView1.Rows(i).FindControl("CheckBox1"), CheckBox).Checked) = True Then

                        If GridView1.Rows(i).Cells(7).Text = "Y" Then


                            sqlpass = "select convert(datetime,'" & Me.txt_effdate.Text & "',103),convert(datetime,'" & Me.txt_expdate.Text & "',103) "

                            cmd = New SqlCommand(sqlpass, obj.cn)
                            cmd.Transaction = btran
                            dr = cmd.ExecuteReader

                            If dr.HasRows = True Then
                                dr.Read()
                                effdt = dr.Item(0)
                                expdt = dr.Item(1)
                            Else
                                FMsg.Message = "Something wromg in Eff./Exp. Date"
                                FMsg.CssClass = "errormsg"
                                FMsg.Display()
                                Me.txt_effdate.Focus()
                                dr.Close()
                                obj.closecn()
                                Exit Sub
                            End If

                            dr.Close()



                            sqlpass = "exec jct_pp_norm_master_entry '" & _
                                        LTrim(RTrim(Me.ddl_action.Text)) & "','" & _
                                        LTrim(RTrim(Me.ddl_normcatg.Text)) & "','" & _
                                        LTrim(RTrim(Me.ddl_catgcode.Text)) & "','" & _
                                        LTrim(RTrim(Me.ddl_uom.Text)) & "'," & _
                                        Me.txt_normvalue.Text & ",'" & _
                                        effdt & "','" & _
                                        expdt & "','" & _
                                        LTrim(RTrim(GridView1.Rows(i).Cells(7).Text)) & "','" & _
                                        UCase(LTrim(RTrim(Session("empcode")))) & "','" & _
                                        UCase(LTrim(RTrim(Session("companycode")))) & "'"

                            cmd = New SqlCommand(sqlpass, obj.cn)
                            cmd.Transaction = btran
                            cmd.ExecuteNonQuery()


                            sqlpass = "insert into jct_pp_action_detail (date,detail,userid,hostname,company_code) " & _
                                    "Select getdate(),'" & _
                                    UCase(LTrim(RTrim(Me.ddl_action.Text))) & "'+'-'+'" & _
                                    Me.ddl_normcatg.Text & "'+'-'+'" & _
                                    LTrim(RTrim(Me.ddl_catgcode.Text)) & "'+'-'+'" & _
                                    Me.txt_effdate.Text & "'+'-'+'" & _
                                    Me.txt_expdate.Text & "','" & _
                                    UCase(LTrim(RTrim(Session("empcode")))) & "', " & _
                                    "LTrim(RTrim(host_name())) ,'" & _
                                    UCase(LTrim(RTrim(Session("companycode")))) & "'"

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

                        Else

                            FMsg.Message = "Modification of Deactivate records are not allowed"
                            FMsg.CssClass = "errormsg"
                            FMsg.Display()
                            'dr.Close()
                            obj.closecn()
                            Me.lnk_exit_Click(sender, e)       ''  Execute EXIT button script
                            Exit Sub

                        End If

                    End If

                Next


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


        ''===========================================================


        If UCase(LTrim(RTrim(Me.ddl_action.Text))) = "SHORT CLOSE" Then

            obj.opencn()
            btran = obj.cn.BeginTransaction

            Try

                For i = 0 To GridView1.Rows.Count - 1

                    If (CType(GridView1.Rows(i).FindControl("CheckBox1"), CheckBox).Checked) = True Then

                        sqlpass = "insert into jct_pp_action_detail (date,detail,userid,hostname,company_code) " & _
                                    "Select getdate(),'" & _
                                    UCase(LTrim(RTrim(Me.ddl_action.Text))) & "'+'-'+'" & _
                                    GridView1.Rows(i).Cells(1).Text & "'+'-'+'" & _
                                    GridView1.Rows(i).Cells(2).Text & "'+'-'+'" & _
                                    GridView1.Rows(i).Cells(5).Text & "'+'-'+'" & _
                                    GridView1.Rows(i).Cells(6).Text & "','" & _
                                    UCase(LTrim(RTrim(Session("empcode")))) & "', " & _
                                    "LTrim(RTrim(host_name())) ,'" & _
                                    UCase(LTrim(RTrim(Session("companycode")))) & "'"

                        cmd = New SqlCommand(sqlpass, obj.cn)
                        cmd.Transaction = btran
                        cmd.ExecuteNonQuery()



                        sqlpass = "select convert(datetime,'" & GridView1.Rows(i).Cells(5).Text & "',103),convert(datetime,'" & GridView1.Rows(i).Cells(6).Text & "',103) "

                        cmd = New SqlCommand(sqlpass, obj.cn)
                        cmd.Transaction = btran
                        dr = cmd.ExecuteReader

                        If dr.HasRows = True Then
                            dr.Read()
                            effdt = dr.Item(0)
                            expdt = dr.Item(1)
                        Else
                            FMsg.Message = "Something wromg in Eff./Exp. Date"
                            FMsg.CssClass = "errormsg"
                            FMsg.Display()
                            Me.txt_effdate.Focus()
                            dr.Close()
                            obj.closecn()
                            Exit Sub
                        End If

                        dr.Close()




                        sqlpass = "exec jct_pp_norm_master_entry '" & _
                                    LTrim(RTrim(Me.ddl_action.Text)) & "','" & _
                                    LTrim(RTrim(GridView1.Rows(i).Cells(1).Text)) & "','" & _
                                    LTrim(RTrim(GridView1.Rows(i).Cells(2).Text)) & "','" & _
                                    LTrim(RTrim(GridView1.Rows(i).Cells(3).Text)) & "'," & _
                                    GridView1.Rows(i).Cells(4).Text & ",'" & _
                                    effdt & "','" & _
                                    expdt & "','" & _
                                    GridView1.Rows(i).Cells(7).Text & "','" & _
                                    UCase(LTrim(RTrim(Session("empcode")))) & "','" & _
                                    UCase(LTrim(RTrim(Session("companycode")))) & "'"

                        '  Format(GridView1.Rows(i).Cells(5).Text, "MM/dd/yyyy") & "','" & _
                        '  Format(GridView1.Rows(i).Cells(6).Text, "MM/dd/yyyy") & "','" & _

                        ''0 Sel.
                        ''1 Category
                        ''2 Category Code
                        ''3 UOM
                        ''4 Norm Vlaue
                        ''5 Effective Date
                        ''6 Expire Date
                        ''7 Active
                        ''8 Company

                        cmd = New SqlCommand(sqlpass, obj.cn)
                        cmd.Transaction = btran
                        cmd.ExecuteNonQuery()

                    End If

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
        ''-----ReFill Current Norm Master in GridView1
        sqlpass = "exec jct_pp_norm_master_list '" & LTrim(RTrim(Me.ddl_normcatg.Text)) & "','" & _
                    LTrim(RTrim(Me.ddl_catgcode.Text)) & "','" & _
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

        Me.rbt_yes.Checked = False
        Me.rbt_no.Checked = False
        Me.Panel2.Visible = False

        If UCase(LTrim(RTrim(Me.ddl_action.Text))) = "ADD" And Me.lnk_add.Text = "ADD" Then

            Me.ListBox1.Items.Clear()

            Me.ddl_normcatg.Enabled = True
            Me.ddl_catgcode.Enabled = True
            Me.ddl_uom.Enabled = True
            Me.txt_normvalue.Enabled = True
            Me.txt_effdate.Enabled = True
            Me.txt_expdate.Enabled = True

            Me.lnk_apply.Enabled = True

            Me.ddl_normcatg.Focus()

        End If


        If UCase(LTrim(RTrim(Me.ddl_action.Text))) = "MODIFY" And Me.lnk_modify.Text = "MODIFY" Then

            Me.ListBox1.Items.Clear()

            Me.ddl_normcatg.Enabled = True
            Me.ddl_catgcode.Enabled = True
            Me.ddl_uom.Enabled = False
            Me.txt_normvalue.Enabled = True
            Me.txt_effdate.Enabled = False
            Me.txt_expdate.Enabled = False

            Me.lnk_apply.Enabled = True

            Me.ddl_normcatg.Focus()

        End If


        If UCase(LTrim(RTrim(Me.ddl_action.Text))) = "VIEW" Then

            Me.ListBox1.Items.Clear()

            Me.ddl_normcatg.Enabled = True
            Me.ddl_catgcode.Enabled = True
            Me.ddl_uom.Enabled = False
            Me.txt_normvalue.Enabled = False
            Me.txt_effdate.Enabled = False
            Me.txt_expdate.Enabled = False

            Me.lnk_apply.Enabled = True

        End If


        If UCase(LTrim(RTrim(Me.ddl_action.Text))) = "SHORT CLOSE" Or UCase(LTrim(RTrim(Me.ddl_action.Text))) = "AUTHORIZE" Then

            Me.ListBox1.Items.Clear()

            Me.ddl_normcatg.Enabled = True
            Me.ddl_catgcode.Enabled = True
            Me.ddl_uom.Enabled = False
            Me.txt_normvalue.Enabled = False
            Me.txt_effdate.Enabled = False
            Me.txt_expdate.Enabled = False

            Me.lnk_apply.Enabled = True

        End If

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

            'Me.lnk_add.CssClass = "Buttonc"
            'Me.lnk_view.CssClass = "ButtonDisable"
            'Me.lnk_modify.CssClass = "ButtonDisable"
            'Me.lnk_close.CssClass = "ButtonDisable"
            'Me.lnk_authorize.CssClass = "ButtonDisable"
            'Me.lnk_exit.CssClass = "Buttonc"

            Me.lnk_add.Text = "SAVE"
            Me.lnk_exit.Text = "CANCEL"  '' "UNDO"

        ElseIf lnk_add.Text = "SAVE" Then

            Me.ddl_action.SelectedIndex = 0    ''  Set action in ADD mode
            Me.lnk_apply_Click(sender, e)      ''  Execute APPLY button script through LinkButton1_Click event
            ''Me.lnk_exit_Click(sender, e)       ''  Execute EXIT button script

        End If

    End Sub

    Protected Sub lnk_exit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnk_exit.Click

        If lnk_exit.Text = "CLOSE" And Me.lnk_add.Enabled = True And Me.lnk_view.Enabled = True And Me.lnk_modify.Enabled = True And Me.lnk_close.Enabled = True And Me.lnk_authorize.Enabled = True And Me.lnk_exit.Enabled = True Then
            Me.Dispose()
            Response.Redirect("default.aspx")
        Else
            Me.ddl_action.SelectedIndex = 1
            ddl_action_SelectedIndexChanged(sender, e)

            Me.lnk_add.Enabled = True
            Me.lnk_view.Enabled = True
            Me.lnk_modify.Enabled = True
            'Me.lnk_cancel.Enabled = True
            Me.lnk_close.Enabled = True
            Me.lnk_authorize.Enabled = True
            Me.lnk_exit.Enabled = True

            'Me.lnk_add.CssClass = "Buttonc"
            'Me.lnk_view.CssClass = "Buttonc"
            'Me.lnk_modify.CssClass = "Buttonc"
            'Me.lnk_close.CssClass = "Buttonc"
            'Me.lnk_authorize.CssClass = "Buttonc"
            'Me.lnk_exit.CssClass = "Buttonc"

            Me.lnk_add.Text = "ADD"
            Me.lnk_view.Text = "VIEW"
            Me.lnk_modify.Text = "MODIFY"
            'Me.lnk_cancel.Text = "CANCEL"
            Me.lnk_close.Text = "DELETE"  '' "SHORT CLOSE"
            Me.lnk_authorize.Text = "AUTHORIZE"
            Me.lnk_exit.Text = "CLOSE"

            Me.ddl_normcatg.Enabled = False
            Me.ddl_catgcode.Enabled = False
            Me.ddl_uom.Enabled = False
            Me.txt_normvalue.Enabled = False
            Me.txt_effdate.Enabled = False
            Me.txt_expdate.Enabled = False
            'Me.ListBox1.Enabled = False

            Me.txt_normvalue.Text = ""

            sqlpass = "select convert(varchar(11),getdate(),103) "

            obj.opencn()
            cmd = New SqlCommand(sqlpass, obj.cn)
            dr = cmd.ExecuteReader

            If dr.HasRows = True Then
                dr.Read()
                Me.txt_effdate.Text = dr.Item(0)
                Me.txt_expdate.Text = dr.Item(0)
            End If
            dr.Close()
            obj.closecn()

            For i = 0 To GridView1.Rows.Count - 1
                CType(GridView1.Rows(i).FindControl("CheckBox1"), CheckBox).Checked = False
            Next

        End If

    End Sub

    Protected Sub lnk_view_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnk_view.Click

        Me.ddl_action.SelectedIndex = 1
        ddl_action_SelectedIndexChanged(sender, e)

        Me.lnk_add.Enabled = False
        Me.lnk_view.Enabled = True
        Me.lnk_modify.Enabled = False
        'Me.lnk_cancel.Enabled = False
        Me.lnk_close.Enabled = False
        Me.lnk_authorize.Enabled = False
        Me.lnk_exit.Enabled = True
        Me.lnk_exit.Text = "CANCEL"  '' "UNDO"

        'Me.lnk_add.CssClass = "ButtonDisable"
        'Me.lnk_view.CssClass = "Buttonc"
        'Me.lnk_modify.CssClass = "ButtonDisable"
        'Me.lnk_close.CssClass = "ButtonDisable"
        'Me.lnk_authorize.CssClass = "ButtonDisable"
        'Me.lnk_exit.CssClass = "Buttonc"

    End Sub

    Protected Sub lnk_modify_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnk_modify.Click

        If lnk_modify.Text = "MODIFY" Then

            Me.ddl_action.SelectedIndex = 2
            ddl_action_SelectedIndexChanged(sender, e)

            Me.lnk_add.Enabled = False
            Me.lnk_view.Enabled = False
            Me.lnk_modify.Enabled = True
            'Me.lnk_cancel.Enabled = False
            Me.lnk_close.Enabled = False
            Me.lnk_authorize.Enabled = False
            Me.lnk_exit.Enabled = True

            'Me.lnk_add.CssClass = "ButtonDisable"
            'Me.lnk_view.CssClass = "ButtonDisable"
            'Me.lnk_modify.CssClass = "Buttonc"
            'Me.lnk_close.CssClass = "ButtonDisable"
            'Me.lnk_authorize.CssClass = "ButtonDisable"
            'Me.lnk_exit.CssClass = "Buttonc"

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

            Me.lnk_add.Enabled = False
            Me.lnk_view.Enabled = False
            Me.lnk_modify.Enabled = False
            'Me.lnk_cancel.Enabled = False
            Me.lnk_close.Enabled = True
            Me.lnk_authorize.Enabled = False
            Me.lnk_exit.Enabled = True

            'Me.lnk_add.CssClass = "ButtonDisable"
            'Me.lnk_view.CssClass = "ButtonDisable"
            'Me.lnk_modify.CssClass = "ButtonDisable"
            'Me.lnk_close.CssClass = "Buttonc"
            'Me.lnk_authorize.CssClass = "ButtonDisable"
            'Me.lnk_exit.CssClass = "Buttonc"

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

            'Me.lnk_add.CssClass = "ButtonDisable"
            'Me.lnk_view.CssClass = "ButtonDisable"
            'Me.lnk_modify.CssClass = "ButtonDisable"
            'Me.lnk_close.CssClass = "ButtonDisable"
            'Me.lnk_authorize.CssClass = "Buttonc"
            'Me.lnk_exit.CssClass = "Buttonc"

            Me.lnk_authorize.Text = "UPDATE"
            Me.lnk_exit.Text = "CANCEL"  '' "UNDO"

        ElseIf lnk_authorize.Text = "UPDATE" Then

            Me.ddl_action.SelectedIndex = 5    ''  Set action in AUTHORIZE mode
            Me.lnk_apply_Click(sender, e)      ''  Execute APPLY button script through LinkButton1_Click event
            Me.lnk_exit_Click(sender, e)       ''  Execute EXIT button script

        End If

    End Sub

    Protected Sub ddl_catgcode_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl_catgcode.SelectedIndexChanged

            ''-----ReFill Sale Person under Team in Listbox1
        sqlpass = "select distinct b.group_desc " & _
                    "from miserp.som.dbo.jct_team_saleperson_mapping a, " & _
                    "miserp.som.dbo.m_cust_group b " & _
                    "where a.team_code ='" & Me.ddl_catgcode.Text & "' " & _
                    "and convert(datetime,convert(varchar(11),getdate())) " & _
                    "between a.eff_from and a.eff_to " & _
                    "and a.status='O' " & _
                    "and a.sale_person_code=b.group_no " & _
                    "and a.company='" & UCase(LTrim(RTrim(Session("companycode")))) & "' " & _
                    "and b.group_type='SALESP' " & _
                    "and a.status=b.status " & _
                    "and a.company=b.company_no " & _
                    "and (ltrim(rtrim(left(ltrim(b.group_no),1)+'-'+substring(b.group_no,2,len(b.group_no)))) " & _
                    "in (select distinct ltrim(rtrim(empcode)) from empmast " & _
                    "where deptcode in ('SAL','EXP','YSAL') and monthyear=(select top 1 monthyear from empmast " & _
                    "where deptcode in ('SAL','EXP','YSAL') order by monthyear desc)) or b.group_no='ANURAG') " & _
                    "order by b.group_desc "

            obj.opencn()
            cmd = New SqlCommand(sqlpass, obj.cn)
            dr = cmd.ExecuteReader

            Me.ListBox1.Items.Clear()

            If dr.HasRows = True Then
                While dr.Read
                    Me.ListBox1.Items.Add(dr.Item(0))
                End While
            End If
            dr.Close()
            obj.closecn()


        ''-----ReFill Current Norm Master in GridView1
        sqlpass = "exec jct_pp_norm_master_list '" & LTrim(RTrim(Me.ddl_normcatg.Text)) & "','" & _
                    LTrim(RTrim(Me.ddl_catgcode.Text)) & "','" & _
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


    Protected Sub ddl_normcatg_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl_normcatg.SelectedIndexChanged

        Me.ddl_catgcode.Items.Clear()

        If LTrim(RTrim(Me.ddl_normcatg.Text)) = "TEAM" Then

            ''-----Fill Team in Catg. Code Combo Box
            sqlpass = "select distinct team_code from miserp.som.dbo.jct_team_master " & _
                    "where convert(datetime,convert(varchar(11),getdate())) between eff_from and eff_to " & _
                    "and status='O' " & _
                    "and company='" & UCase(LTrim(RTrim(Session("companycode")))) & "' " & _
                    "and team_code<>'HOD' " & _
                    "order by team_code "

            obj.opencn()
            cmd = New SqlCommand(sqlpass, obj.cn)
            dr = cmd.ExecuteReader

            Me.ddl_catgcode.Items.Clear()

            If dr.HasRows = True Then
                While dr.Read
                    Me.ddl_catgcode.Items.Add(dr.Item(0))
                End While
                Me.ddl_catgcode.SelectedIndex = 0
            End If
            dr.Close()
            obj.closecn()

            ''If LTrim(RTrim(Me.ddl_normcatg.Text)) = "TEAM" Then
            Me.ddl_uom.Text = "LOOMS"
            Me.Label5.Text = "Looms Alloted"
            Dim i As Integer = 0
            For i = 0 To Me.ddl_catgcode.Items.Count - 1
                If Me.ddl_catgcode.Items(i).Text = "..." Then
                    Me.ddl_catgcode.Items.RemoveAt(i)
                End If
            Next
        Else

            Me.ddl_uom.Text = "METRES"
            Me.Label5.Text = "Capacity"
            Me.ListBox1.Items.Clear()
            Dim i As Integer = 0
            For i = 0 To Me.ddl_catgcode.Items.Count - 1
                If Me.ddl_catgcode.Items(i).Text = "..." Then
                    Me.ddl_catgcode.Items.RemoveAt(i)
                End If
            Next
            Me.ddl_catgcode.Items.Add("...")
            Me.ddl_catgcode.Text = "..."
        End If

        ''-----ReFill Current Norm Master in GridView1
        sqlpass = "exec jct_pp_norm_master_list '" & LTrim(RTrim(Me.ddl_normcatg.Text)) & "','" & _
                    LTrim(RTrim(Me.ddl_catgcode.Text)) & "','" & _
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

    Protected Sub rbt_yes_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbt_yes.CheckedChanged

        Me.lnk_apply_Click(sender, e)      ''  Execute APPLY button script through LinkButton1_Click event

    End Sub

    Protected Sub rbt_no_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbt_no.CheckedChanged

        Me.lnk_apply_Click(sender, e)      ''  Execute APPLY button script through LinkButton1_Click event

    End Sub

    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged

        If Me.GridView1.SelectedRow IsNot Nothing Then

            Me.ddl_normcatg.SelectedItem.Text = LTrim(RTrim(Me.GridView1.SelectedRow.Cells(1).Text.ToString()))
            Me.ddl_catgcode.SelectedItem.Text = LTrim(RTrim(Me.GridView1.SelectedRow.Cells(2).Text.ToString()))
            Me.ddl_uom.SelectedItem.Text = LTrim(RTrim(Me.GridView1.SelectedRow.Cells(3).Text.ToString()))
            Me.txt_normvalue.Text = LTrim(RTrim(Me.GridView1.SelectedRow.Cells(4).Text.ToString()))
            Me.txt_effdate.Text = Format(LTrim(RTrim(Me.GridView1.SelectedRow.Cells(5).Text.ToString())), "MM/dd/yyyy")
            Me.txt_expdate.Text = Format(LTrim(RTrim(Me.GridView1.SelectedRow.Cells(6).Text.ToString())), "MM/dd/yyyy")

        End If

    End Sub

    Protected Sub Lnk_Select_Click(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub


End Class

