Imports System.Data
Imports System.Data.SqlClient
Partial Class Rights
    Inherits System.Web.UI.Page
    Dim Obj As New Connection
    Dim Cmd As New SqlCommand
    Dim Qry As String
    Dim OBJ2 As New FUNCTIONS
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Session("Companycode") = "jct00ltd"
        '  TextBox1.Attributes.Add("onkeypress", "return clickButton(event,'" + Button1.ClientID + "')")
        If IsPostBack = False Then
            If (Session("empcode") <> "") Then
            Else
                Response.Redirect("~/login.aspx")
            End If
            Get_Application_Name()
            DrpApp_SelectedIndexChanged(sender, e)
            DrpParent_SelectedIndexChanged(sender, e)
            DrpSub_SelectedIndexChanged(sender, e)
        End If
    End Sub
    Protected Sub Grid()
        If Me.txtEmpName.Text = "" Then
            Me.txtEmpName.Text = "ALL"
        End If
        If Me.RadioButtonList1.Items(0).Selected = True Then
            Qry = "select a.module as [Module Name],a.uname as [Employee Code],H.EMPNAME AS [Employee Name],H.DEPTCODE AS [Department],parent_menu as [Parent Menu],b.description as [Sub Menu],a.action as [Action] from production..user_module_menus_mapping a inner join production..modules_menu_master b on a.module=b.module and a.mnuname=b.mnuname left outer join jctdev..JCT_Menu_Form_Mapping c on b.module = c.module and b.mnuname=c.mnuname  INNER JOIN JCTDEV..JCT_EMPMAST_BASE H ON H.EMPCODE=A.UNAME where  h.company_code='" & trim(session("Companycode")) & "' and  (a.module ='" & Trim(Me.DrpApp.SelectedValue) & "' or '" & Trim(Me.DrpApp.SelectedValue) & "'='ALL' ) and (b.parent_menu='" & Trim(Me.DrpParent.SelectedValue) & "'OR '" & Trim(Me.DrpParent.SelectedValue) & "'='ALL') and (b.mnuname='" & Trim(Me.DrpSub.SelectedValue) & "' OR '" & Trim(Me.DrpSub.SelectedValue) & "'='ALL' )and (uname='" & Right(Trim(Me.txtEmpName.Text), 7) & "' or '" & Trim(Me.txtEmpName.Text) & "'='ALL') AND (A.ACTION='" & Trim(Me.DrpAction.SelectedValue) & "' or '" & Trim(Me.DrpAction.SelectedValue) & "'='ALL' ) union select a.module as [Module Name],e.uname as [Employee Code],H.EMPNAME AS [Employee Name],H.DEPTCODE AS [Department],parent_menu as [Parent Menu],b.description as [Sub Menu] ,a.action as [Action] from production..role_module_menus_mapping a inner join production..modules_menu_master b on a.module=b.module and a.mnuname=b.mnuname inner join production..role_user_mapping e on a.role=e.role left outer join jctdev..JCT_Menu_Form_Mapping c on b.module = c.module and b.mnuname=c.mnuname  INNER JOIN JCTDEV..JCT_EMPMAST_BASE H ON H.EMPCODE=e.UNAME  where h.company_code='" & trim(session("Companycode")) & "' and (a.module='" & Trim(Me.DrpApp.SelectedValue) & "' or '" & Trim(Me.DrpApp.SelectedValue) & "'='ALL' ) and (b.parent_menu='" & Trim(Me.DrpParent.SelectedValue) & "'OR '" & Trim(Me.DrpParent.SelectedValue) & "'='ALL') and (b.mnuname='" & Trim(Me.DrpSub.SelectedValue) & "'OR '" & Trim(Me.DrpSub.SelectedValue) & "'='ALL') and (uname='" & Right(Trim(Me.txtEmpName.Text), 7) & "' or '" & Trim(Me.txtEmpName.Text) & "'='ALL') AND (A.ACTION='" & Trim(Me.DrpAction.SelectedValue) & "' or '" & Trim(Me.DrpAction.SelectedValue) & "'='ALL' ) order by h.empname,a.module,parent_menu,b.description"
        Else
            Qry = "select a.module as [Module Name],a.uname as [User],parent_menu as [Parent Menu],b.description as [Sub Menu],a.action as [Action] from production..user_module_menus_mapping a inner join production..modules_menu_master b on a.module=b.module and a.mnuname=b.mnuname left outer join jctdev..JCT_Menu_Form_Mapping c on b.module = c.module and b.mnuname=c.mnuname  where (a.module ='" & Trim(Me.DrpApp.SelectedValue) & "' or '" & Trim(Me.DrpApp.SelectedValue) & "'='ALL' ) and (b.parent_menu='" & Trim(Me.DrpParent.SelectedValue) & "'OR '" & Trim(Me.DrpParent.SelectedValue) & "'='ALL') and (b.mnuname='" & Trim(Me.DrpSub.SelectedValue) & "' OR '" & Trim(Me.DrpSub.SelectedValue) & "'='ALL' )and (uname='" & Trim(Me.txtEmpName.Text) & "' or '" & Trim(Me.txtEmpName.Text) & "'='ALL') AND (A.ACTION='" & Trim(Me.DrpAction.SelectedValue) & "' or '" & Trim(Me.DrpAction.SelectedValue) & "'='ALL' ) union select a.module as [Module Name],e.uname as [User],parent_menu as [Parent Menu],b.description as [Sub Menu] ,a.action as [Action] from production..role_module_menus_mapping a inner join production..modules_menu_master b on a.module=b.module and a.mnuname=b.mnuname inner join production..role_user_mapping e on a.role=e.role left outer join jctdev..JCT_Menu_Form_Mapping c on b.module = c.module and b.mnuname=c.mnuname where (a.module='" & Trim(Me.DrpApp.SelectedValue) & "' or '" & Trim(Me.DrpApp.SelectedValue) & "'='ALL' ) and (b.parent_menu='" & Trim(Me.DrpParent.SelectedValue) & "'OR '" & Trim(Me.DrpParent.SelectedValue) & "'='ALL') and (b.mnuname='" & Trim(Me.DrpSub.SelectedValue) & "'OR '" & Trim(Me.DrpSub.SelectedValue) & "'='ALL') and (uname='" & Trim(Me.txtEmpName.Text) & "' or '" & Trim(Me.txtEmpName.Text) & "'='ALL') AND (A.ACTION='" & Trim(Me.DrpAction.SelectedValue) & "' or '" & Trim(Me.DrpAction.SelectedValue) & "'='ALL' ) order by a.uname,a.module,parent_menu,b.description"
        End If

        OBJ2.FillGrid(Qry, GridView1)
    End Sub
    Protected Sub Get_Parent()
        Qry = "select 'ALL','ALL' UNION select distinct parent_menu, parent_menu from production..MODULES_MENU_MASTER where (module = '" & Trim(Me.DrpApp.SelectedValue) & "'  or '" & Trim(Me.DrpApp.SelectedValue) & "'='ALL' ) and  parent_menu is not null ORDER BY 1 "
        FillList(DrpParent, Qry)
        DrpParent.SelectedValue = "ALL"
    End Sub
    Protected Sub Get_SubItem()
        Qry = "select 'ALL','ALL' UNION select mnuname, description from production..MODULES_MENU_MASTER where (module = '" & Trim(Me.DrpApp.SelectedValue) & "'  or '" & Trim(Me.DrpApp.SelectedValue) & "'='ALL' )  and (parent_menu='" & Trim(Me.DrpParent.SelectedValue) & "'  OR '" & Trim(Me.DrpParent.SelectedValue) & "'='ALL') "
        FillList(DrpSub, Qry)
        DrpSub.SelectedValue = "ALL"
    End Sub
    Protected Sub Get_Application_Name()
        If Me.RadioButtonList1.Items(0).Selected = True Then
            Qry = " select 'ALL','ALL' UNION select distinct module_name, module_name from production..modules WHERE module_name<>'' and web_flag='T' order by 1"
        Else
            Qry = " select 'ALL','ALL' UNION select distinct module_name, module_name from production..modules  WHERE module_name<>'' and web_flag<>'T' and web_flag<>'R'  order by 1"
        End If

        FillList(DrpApp, Qry)
    End Sub
    Protected Sub Get_Actions()
        Qry = "select 'ALL','ALL' UNION select distinct action, action from production..MODULES_MENU_MASTER where (module = '" & Trim(Me.DrpApp.SelectedValue) & "'  or '" & Trim(Me.DrpApp.SelectedValue) & "'='ALL') and (mnuname='" & Trim(Me.DrpSub.SelectedValue) & "' or '" & Trim(Me.DrpSub.SelectedValue) & "'='ALL') ORDER BY 1"
        FillList(DrpAction, Qry)
        DrpAction.SelectedValue = "ALL"
    End Sub
    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GridView1.PageIndex = e.NewPageIndex
        Grid()
    End Sub
    Protected Sub LnkFetch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LnkFetch.Click
        Grid()
    End Sub
    Protected Sub DrpApp_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DrpApp.SelectedIndexChanged
        Get_Parent()
        Get_SubItem()
        Get_Actions()
    End Sub
    Protected Sub DrpParent_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DrpParent.SelectedIndexChanged
        Get_SubItem()
        Get_Actions()
    End Sub
    Protected Sub DrpAction_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DrpAction.SelectedIndexChanged
    End Sub
    Protected Sub DrpSub_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DrpSub.SelectedIndexChanged
        Get_Actions()
    End Sub
    Protected Sub RadioButtonList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonList1.SelectedIndexChanged
        Get_Application_Name()
    End Sub
    Protected Sub LnkFetch0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LnkFetch0.Click
        GridViewExportUtil.Export("User_Rights.xls", Me.GridView1)
    End Sub
End Class
