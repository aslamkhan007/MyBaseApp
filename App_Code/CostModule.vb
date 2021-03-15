Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data

Public Class CostModule
    Public constr As String = System.Web.Configuration.WebConfigurationManager.ConnectionStrings("misjctdev").ConnectionString
    Public con As SqlConnection = New SqlConnection(constr)
    Public con1 As New SqlClient.SqlConnection
    Public adap As New SqlClient.SqlDataAdapter
    Public ds As New DataSet
    Public dr As SqlClient.SqlDataReader
    Public dr1 As SqlClient.SqlDataReader
    Public cmd As New SqlClient.SqlCommand
    Public cmd1 As New SqlClient.SqlCommand
    Public user, pwd, server, UserId, qry, delqry, UserServer As String
    Dim dt As Date
    Public mnu_flag As Boolean
    Public mnu() As String
    Public role, UserLevel As Integer
    Public company, emp_code As String
    'Public cmd As New SqlCommand
    Public obj1 As New HelpDeskClass
    'Public qry As String
    'Public dr As SqlDataReader
    'Public common_help As New frm_common_help
    'Public search As New frm_search
    Public Sub GetConn()
        Try
            con = New SqlConnection(constr)
            'If con.State <> ConnectionState.Open Then ' ConnectionState.Closed Then
            con.Open()
            'End If
        Catch ex As Exception

        End Try
    End Sub

    Public Sub CloseCn()
        con.Close()
    End Sub

    'Public Sub SecondConn()
    '    Try
    '        'If con.State = ConnectionState.Open Then con.Close()
    '        If con1.State = ConnectionState.Closed Then
    '            'con.ConnectionString = "Password= " & pwd & " ;Persist Security Info=True;User ID= " & user & " ;connection timeout=2000000;Initial Catalog=reportdb;Data Source= " & server
    '            con1.ConnectionString = "Password= power; Persist Security Info=True; User ID= itgrp; connection timeout=2000000;Initial Catalog=jctdev  ;Data Source= miserp"
    '            con1.Open()
    '        End If
    '    Catch ex As Exception
    '        'MessageBox.Show("error" & ex.Message, "error", MessageBoxButtons.OK)
    '    End Try
    'End Sub
    Public Function CheckProc(ByVal proc As String) As Integer
        If Trim(proc) <> "" Then
            obj1.opencn()
            qry = "select * from sysobjects where name='" & Trim(proc) & "' and OBJECTPROPERTY(id, N'IsProcedure') = 1"
            cmd = New SqlCommand(qry, obj1.cn)
            dr = cmd.ExecuteReader
            If dr.HasRows = False Then
                'MsgBox("Please Check Procedure Name. No Such Proc exists in database.")
                CheckProc = 1
            End If
            dr.Close()
            obj1.closecn()
        End If
    End Function
    Public Function FormatDate(ByVal objDate As Date) As String
        Dim tempdate As String
        tempdate = objDate.Month
        If Len(CStr(objDate.Month)) = 2 Then
            tempdate = objDate.Month & "/"
        Else
            tempdate = "0" & CStr(objDate.Month) & "/"
        End If
        If Len(CStr(objDate.Day)) = 2 Then
            tempdate = tempdate & objDate.Day & "/"
        Else
            tempdate = tempdate & "0" & CStr(objDate.Day) & "/"
        End If
        tempdate = tempdate & CStr(objDate.Year)
        FormatDate = tempdate
    End Function
    Public Function checkNullSpace(ByVal objitem As Object) As Object
        If objitem Is System.DBNull.Value Then
            checkNullSpace = ""
        Else
            checkNullSpace = objitem
        End If
    End Function
    Public Function Set_Date() As Date
        Dim qry As String
        qry = "execute production..common_date_initialize"
        GetConn()
        cmd = New SqlCommand(qry, con)
        dr = cmd.ExecuteReader()

        dr.Read()

        Set_Date = dr.Item(0)

        dr.Close()
        con.Close()
    End Function
    'Private Sub CheckPermission(ByVal FrmName As Windows.Forms.Form)
    '    qry = "select right(ltrim(rtrim(b.page_name)),len(b.page_name)-2),a.action from production..modules_menu_master a,jctdev..JCT_Menu_Form_Mapping b,production..user_module_menus_mapping c where a.action<>'load' and b.module=a.module and a.mnuname=b.mnuname and a.module=c.module and a.module='Costing System' and uname='" & Session("Empcode") & "' and right(ltrim(rtrim(b.page_name)),len(b.page_name)-2)='Sub_Grp_Mapping.aspx' group by b.page_name,a.action order by a.action"
    '    'qry = "select type_no from jct_cst_subgroup_mapping where flag ='' or flag is NULL order by type_no"
    '    obj.opencn()
    '    cmd = New SqlCommand(qry, obj.cn)
    '    dr = cmd.ExecuteReader
    '    If dr.HasRows = True Then

    '        While dr.Read()
    '            If dr(1).ToString = "Add" Then
    '                cmdAdd.Enabled = True
    '            ElseIf dr(1).ToString = "Edit" Then
    '                cmdEdit.Enabled = True
    '            ElseIf dr(1).ToString = "Delete" Then
    '                cmdDelete.Enabled = True
    '            End If
    '        End While
    '    End If

    'Cmd2.Enabled = True
    ''Cmd3.Enabled = True
    '    dr.Close()
    '    obj.closecn()
    'End Sub

    Public Sub DisableReqdField(ByVal ctrl As RequiredFieldValidator, ByVal callout As AjaxControlToolkit.ValidatorCalloutExtender)
        ctrl.Enabled = False
        callout.Enabled = False
    End Sub

    Public Sub EnableReqdField(ByVal ctrl As RequiredFieldValidator, ByVal callout As AjaxControlToolkit.ValidatorCalloutExtender)
        ctrl.Enabled = True
        callout.Enabled = True
    End Sub

    Public Sub CheckPermission(ByVal frmname As String, ByVal BtnAdd As LinkButton, ByVal BtnEdit As LinkButton, ByVal BtnDelete As LinkButton, ByVal Empcode As String)
        'qry = "select right(ltrim(rtrim(b.page_name)),len(b.page_name)-2),C.action from production..modules_menu_master a,jctdev..JCT_Menu_Form_Mapping b,production..user_module_menus_mapping c where a.action<>'load' and b.module=a.module and a.mnuname=b.mnuname and C.mnuname=A.mnuname and a.module=c.module and a.module='Costing System' and c.uname='" & Session("Empcode") & "' and right(ltrim(rtrim(b.page_name)),len(b.page_name)-2)='Sub_Grp_Mapping.aspx' group by b.page_name,C.action order by C.action"
        '02-Dec-2008 qry = "select right(ltrim(rtrim(b.page_name)),len(b.page_name)-2),C.action from production..modules_menu_master a,jctdev..JCT_Menu_Form_Mapping b,production..user_module_menus_mapping c where a.action<>'load' and b.module=a.module and a.mnuname=b.mnuname and C.mnuname=A.mnuname  and a.action=c.action and a.module=c.module and a.module='Costing System' and c.uname='" & Empcode & "' and right(ltrim(rtrim(b.page_name)),len(b.page_name)-2)='" & frmname & "'  "
        qry = "select right(ltrim(rtrim(b.page_name)),len(b.page_name)-2),C.action from production..modules_menu_master a,jctdev..JCT_Menu_Form_Mapping b,production..user_module_menus_mapping c where a.action<>'load' and b.module=a.module and a.mnuname=b.mnuname and C.mnuname=A.mnuname  and a.action=c.action and a.module=c.module and a.module='Costing System' and c.uname='" & Empcode & "' and right(ltrim(rtrim(b.page_name)),len(b.page_name)-2)='" & frmname & "'   union    select right(ltrim(rtrim(b.page_name)),len(b.page_name)-2),C.action from production..modules_menu_master a,jctdev..JCT_Menu_Form_Mapping b,production..role_module_menus_mapping c,production..role_user_mapping d where a.action<>'load' and b.module=a.module and a.mnuname=b.mnuname and a.action=c.action and c.role=d.role and C.mnuname=A.mnuname and a.module=c.module and a.module='Costing System' and  d.uname='" & Empcode & "' and right(ltrim(rtrim(b.page_name)),len(b.page_name)-2)='" & frmname & "' "
        obj1.opencn()
        cmd = New SqlCommand(qry, obj1.cn)
        dr = cmd.ExecuteReader
        If dr.HasRows = True Then
            While dr.Read()
                If dr(1).ToString = "Add" Then
                    obj1.Enable_Buttons(BtnAdd)
                ElseIf dr(1).ToString = "Edit" Then
                    obj1.Enable_Buttons(BtnEdit)
                ElseIf dr(1).ToString = "Delete" Then
                    obj1.Enable_Buttons(BtnDelete)
                End If
            End While
        End If
        dr.Close()
        obj1.closecn()
    End Sub
    Public Sub CheckPermission(ByVal frmname As String, ByVal Btn As LinkButton, ByVal Grant As String, ByVal Empcode As String)
        qry = "select right(ltrim(rtrim(b.page_name)),len(b.page_name)-2),C.action from production..modules_menu_master a,jctdev..JCT_Menu_Form_Mapping b,production..user_module_menus_mapping c where a.action<>'load' and b.module=a.module and a.mnuname=b.mnuname and C.mnuname=A.mnuname  and a.action=c.action and a.module=c.module and a.module='Costing System' and c.uname='" & Empcode & "' and right(ltrim(rtrim(b.page_name)),len(b.page_name)-2)='" & frmname & "'   union    select right(ltrim(rtrim(b.page_name)),len(b.page_name)-2),C.action from production..modules_menu_master a,jctdev..JCT_Menu_Form_Mapping b,production..role_module_menus_mapping c,production..role_user_mapping d where a.action<>'load' and b.module=a.module and a.mnuname=b.mnuname and a.action=c.action and c.role=d.role and C.mnuname=A.mnuname and a.module=c.module and a.module='Costing System' and  d.uname='" & Empcode & "' and right(ltrim(rtrim(b.page_name)),len(b.page_name)-2)='" & frmname & "' "
        obj1.opencn()
        cmd = New SqlCommand(qry, obj1.cn)
        dr = cmd.ExecuteReader
        If dr.HasRows = True Then
            While dr.Read()
                If LCase(dr(1).ToString) = LCase(Grant) Then
                    Enable_Buttons(Btn)
                    ApplyBtnStyle(Btn)
                End If
            End While
        End If
        dr.Close()
        obj1.closecn()
    End Sub
    Public Sub ApplyBtnStyle(ByVal Btn As LinkButton)
        Btn.Attributes.Add("onmouseover", "this.className='buttonhover';")
        Btn.Attributes.Add("onmouseout", "this.className='buttonc';")
        'cmdEdit.Attributes.Add("onmouseover", "this.className='buttonhover';")
        'cmdEdit.Attributes.Add("onmouseout", "this.className='buttonc';")
        'cmdDelete.Attributes.Add("onmouseover", "this.className='buttonhover';")
        'cmdDelete.Attributes.Add("onmouseout", "this.className='buttonc';")
        'cmdClose.Attributes.Add("onmouseover", "this.className='buttonhover';")
        'cmdClose.Attributes.Add("onmouseout", "this.className='buttonc';")
    End Sub

    'Public Function Fetch() As DataSet
    '    obj1.opencn()
    '    Dim ds As DataSet = New DataSet()
    '    'Dim Sqlpass = "select parent_group,ma_center_ldesc,a.* from jct_cst_last_yr_std a, jct_cst_standard_master b,mac..mac_cost_center c where b.std_name=  left(a.acc_grp,charindex(' - ',a.acc_grp))  and a.cost_center=c.ma_center_no and status=''"
    '    'Dim SqlPass = "select parent_group,ma_center_ldesc,a.* from jct_cst_last_yr_std a inner join jct_cst_standard_master b on  left(a.acc_grp,charindex(' - ',a.acc_grp))=b.std_name inner join mac..mac_cost_center c on a.cost_center=c.ma_center_no left outer join JCT_CST_mapping_trans d on a.cost_center=d.item2 and d.status='x'  order by d.item1,parent_group, acc_grp, acc_no, cost_center"
    '    Dim SqlPass = "select parent_group as [Group],a.Acc_Grp as [A/c Group],a.Acc_No as [A/c No.],a.Cost_Center as [Cost Center],ma_center_ldesc as [Description],a.Net_Value as [Net Value],isnull(a.Provision,0) as [Provision],a.Remarks,a.net_value+isnull(provision,0) as [Value],a.Acc_Prd_Code as [Year Code] from jct_cst_last_yr_std a, jct_cst_standard_master b,mac..mac_cost_center c where b.std_name=left(a.acc_grp,charindex(' - ',a.acc_grp))  and a.cost_center=c.ma_center_no and status=''"
    '    Dim Da As SqlDataAdapter = New SqlDataAdapter(SqlPass, obj1.cn)
    '    Try

    '        Da.Fill(ds)
    '        '    grdgrid.DataSource = ds
    '        'grdgrid.Columns(1).ControlStyle.Width = 100
    '        '   grdgrid.RowStyle.Wrap = False
    '        Return ds
    '        '  grdgrid.DataBind()
    '    Catch ex As Exception

    '    Finally
    '        obj1.closecn()
    '    End Try
    'End Function

    Public Function Fetch(ByVal AcYr As Integer) As DataSet
        obj1.opencn()
        Dim ds As DataSet = New DataSet()
        'Dim Sqlpass = "select parent_group,ma_center_ldesc,a.* from jct_cst_last_yr_std a, jct_cst_standard_master b,mac..mac_cost_center c where b.std_name=  left(a.acc_grp,charindex(' - ',a.acc_grp))  and a.cost_center=c.ma_center_no and status=''"
        'Dim SqlPass = "select parent_group,ma_center_ldesc,a.* from jct_cst_last_yr_std a inner join jct_cst_standard_master b on  left(a.acc_grp,charindex(' - ',a.acc_grp))=b.std_name inner join mac..mac_cost_center c on a.cost_center=c.ma_center_no left outer join JCT_CST_mapping_trans d on a.cost_center=d.item2 and d.status='x'  order by d.item1,parent_group, acc_grp, acc_no, cost_center"
        Dim SqlPass = "select parent_group as [Group],a.Acc_Grp as [A/c Group],a.Acc_No as [A/c No.],a.Cost_Center as [Cost Center],ma_center_ldesc as [Description],a.Net_Value as [Net Value],isnull(a.Provision,0) as [Provision],a.Remarks,a.net_value+isnull(provision,0) as [Value],a.Acc_Prd_Code as [Year Code] from jct_cst_last_yr_std a, jct_cst_standard_master b,miserp.mac.dbo.mac_cost_center c where b.std_name=left(a.acc_grp,charindex(' - ',a.acc_grp)) and a.cost_center=c.ma_center_no and a.status<>'D' and b.status <>'D' and acc_prd_code='" & AcYr & "'"
        Dim Da As SqlDataAdapter = New SqlDataAdapter(SqlPass, obj1.cn)
        Try
            Da.Fill(ds)
            Return ds
        Catch ex As Exception
        Finally
            obj1.closecn()
        End Try
    End Function


    Public Function FetchDS(ByVal sql As String) As DataSet
        obj1.opencn()
        Dim ds As DataSet = New DataSet()
        Dim Da As SqlDataAdapter = New SqlDataAdapter(sql, obj1.cn)
        Try
            Da.Fill(ds)
            Return ds
        Catch ex As Exception
            Return New DataSet
        Finally
            obj1.closecn()
        End Try

    End Function

    Public Sub FillGrid(ByVal sql As String, ByVal grdview As GridView)
        Try
            grdview.DataSource = FetchDS(sql)
            grdview.DataBind()
        Catch ex As Exception

        End Try

    End Sub

    Public Function FetchReader(ByVal sql As String) As SqlDataReader

        Try
            cmd = New SqlCommand(sql, con)
            'GetConn()
            If con.State = ConnectionState.Closed Then con.Open()
            dr = cmd.ExecuteReader()
            If dr.IsDBNull(0) Or dr.HasRows Then
                cmd = New SqlCommand("select 'No Data Found'", con)
                dr = cmd.ExecuteReader()
                Return dr
            Else
                Return dr
            End If
        Catch ex As Exception
            Return dr
            'MsgBox(ex.Message)
        End Try

    End Function

    Public Sub CloseReader()
        dr.Close()
    End Sub

    Public Function FetchScalar(ByVal sql As String) As String
        Try

            GetConn()
            cmd = New SqlCommand(sql, con)
            Dim v = cmd.ExecuteScalar
            Return Trim(v)
        Catch ex As Exception
        End Try

    End Function

    Public Sub ErrvalidatorEnable(ByVal err As RequiredFieldValidator)
        err.Enabled = True
    End Sub
    Public Sub ErrvalidatorDisable(ByVal err As RequiredFieldValidator)
        err.Enabled = False
    End Sub
    'Public Sub fillList(ByVal cbl As CheckBoxList, ByVal sql As String)
    '    Dim cn As SqlConnection = New SqlConnection(constr)
    '    Dim cmd As SqlCommand = New SqlCommand(sql, cn)
    '    cn.Open()
    '    Dim dr As SqlDataReader = cmd.ExecuteReader()
    '    If dr.HasRows Then
    '        While dr.Read
    '            cbl.Items.Add(dr.Item(0))
    '        End While

    '    End If
    '    cn.Close()
    'End Sub

    Public Sub fillList(ByVal ddl As DropDownList, ByVal sql As String)
        Dim cn As SqlConnection = New SqlConnection(constr)
        Dim cmd As SqlCommand = New SqlCommand(sql, cn)

        cn.Open()
        Dim dr As SqlDataReader = cmd.ExecuteReader()
        If dr.HasRows Then
            While dr.Read
                Dim li As New ListItem
                li.Value = dr.Item(0)
                li.Text = dr.Item(1)
                ddl.Items.Add(li)
            End While
        End If
        cn.Close()

    End Sub

    Public Sub fillList(ByVal cbl As CheckBoxList, ByVal sql As String)
        Dim cn As SqlConnection = New SqlConnection(constr)
        Dim cmd As SqlCommand = New SqlCommand(sql, cn)
        cn.Open()
        Dim dr As SqlDataReader = cmd.ExecuteReader()
        If dr.HasRows Then
            While dr.Read
                'cbl.Items.Add(dr.Item(0))
                Dim li As New ListItem
                li.Value = dr.Item(0)
                li.Text = dr.Item(1)
                cbl.Items.Add(li)
            End While

        End If
        cn.Close()
    End Sub



    Public Function DBValue(ByVal sql) As String
        Dim cn As SqlConnection = New SqlConnection(constr)
        Dim cmd As SqlCommand = New SqlCommand(sql, cn)
        cn.Open()
        Dim dr As SqlDataReader = cmd.ExecuteReader()
        If dr.HasRows Then
            DBValue = dr.Item(0)
        Else
            DBValue = Nothing
        End If
        cn.Close()
    End Function
    Public Sub Disable_Buttons(ByVal btn As LinkButton)
        btn.Enabled = False
        btn.CssClass = "buttondisable"
    End Sub

    Public Sub Enable_Buttons(ByVal btn As LinkButton)
        btn.Enabled = True
        btn.CssClass = "buttonc"
    End Sub
    Public Function GetCurrentPageName() As String
        Dim sPath As String = System.Web.HttpContext.Current.Request.Url.AbsolutePath
        Dim oInfo As System.IO.FileInfo = New System.IO.FileInfo(sPath)
        Dim sRet As String = oInfo.Name
        Return sRet
    End Function
    Public Sub sorting(ByVal sql1 As String, ByVal Grd As GridView, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs)

        Dim ds As DataSet = New DataSet
        Dim Da As SqlDataAdapter
        Da = New SqlDataAdapter(Sql1, obj1.cn)
        Da.Fill(ds)
        grd.DataSource = ds
        grd.DataBind()
        Dim dv As DataView = New DataView(ds.Tables(0))
        dv.Sort = e.SortExpression & " ASC"
        grd.DataSource = dv
        grd.DataBind()
        obj1.closecn()
        grd.SelectedIndex = -1
    End Sub
    Public Sub sorting(ByVal sql1 As String, ByVal sql2 As String, ByVal Grd As GridView, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs, ByVal cb As CheckBox)
        obj1.opencn()
        Dim ds As DataSet = New DataSet
        Dim Da As SqlDataAdapter
        If cb.checked = True Then
            Da = New SqlDataAdapter(Sql1, obj1.cn)
        Else
            Da = New SqlDataAdapter(Sql2, obj1.cn)
        End If
        Da.Fill(ds)
        grd.DataSource = ds
        grd.DataBind()
        Dim dv As DataView = New DataView(ds.Tables(0))
        'dv.Sort = e.SortExpression & " ASC"
        Dim session As HttpSessionState = HttpContext.Current.Session
        If session("a") = False Then
            dv.Sort = e.SortExpression & " ASC"
            session("b") = False
            session("a") = True

        ElseIf session("b") = False Then

            dv.Sort = e.SortExpression & " DESC"
            session("a") = False
            session("b") = True

        End If
        grd.DataSource = dv
        grd.DataBind()
        obj1.closecn()
        grd.SelectedIndex = -1
    End Sub
    Public Function FindcolumnIndex(ByVal Grd As GridView, ByVal ColName As String)
        Dim I As Int16
        For I = 0 To Grd.Columns.Count
            If (String.Compare(Grd.Columns(I).HeaderText, ColName, True) = 0) Then
                Return I
            End If
        Next
        Return -1
    End Function


End Class
