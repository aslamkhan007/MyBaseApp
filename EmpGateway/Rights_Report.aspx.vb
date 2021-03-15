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
            ' DropDownList1_SelectedIndexChanged(sender, e)
            ' DrpSub_SelectedIndexChanged(sender, e)
        End If
    End Sub
    Protected Sub Grid()
    End Sub

    Protected Sub Get_Parent()
        Qry = "select 'ALL','ALL' UNION select mnuname, description from production..MODULES_MENU_MASTER where (module = '" & Trim(Me.DrpApp.SelectedValue) & "'  or '" & Trim(Me.DrpApp.SelectedValue) & "'='ALL' ) and  parent_menu is not null and parent_menu='' ORDER BY 1 "
        FillList(DrpParent, Qry)
        ' DrpParent.SelectedValue = "ALL"
    End Sub
    Protected Sub Get_SubItem()
        Qry = "select 'ALL','ALL' UNION select mnuname, description from production..MODULES_MENU_MASTER where (module = '" & Trim(Me.DrpApp.SelectedValue) & "'  or '" & Trim(Me.DrpApp.SelectedValue) & "'='ALL' )  and (parent_menu='" & Trim(Me.DrpParent.SelectedValue) & "'  OR '" & Trim(Me.DrpParent.SelectedValue) & "'='ALL') "
        FillList(DrpSub, Qry)
        '  DrpSub.SelectedValue = "ALL"
    End Sub
    Protected Sub Get_Application_Name()
        Qry = " select distinct module, module from JCT_Menu_Form_Mapping WHERE MODULE<>'' order by 1"
        FillList(DrpApp, Qry)
    End Sub
    Protected Sub Get_Actions()
        Qry = "select 'ALL','ALL' UNION select distinct action, action from production..MODULES_MENU_MASTER where (module = '" & Trim(Me.DrpApp.SelectedValue) & "'  or '" & Trim(Me.DrpApp.SelectedValue) & "'='ALL') and (mnuname='" & Trim(Me.DrpSub.SelectedValue) & "' or '" & Trim(Me.DrpSub.SelectedValue) & "'='ALL') ORDER BY 1"
        FillList(DrpAction, Qry)
        'DrpAction.SelectedValue = "ALL"
    End Sub
    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GridView1.PageIndex = e.NewPageIndex
    End Sub
    Protected Sub LnkFetch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LnkFetch.Click
        Grid()
    End Sub
    Protected Sub DrpApp_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DrpApp.SelectedIndexChanged
        Get_Parent()
    End Sub
    Protected Sub DrpParent_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DrpParent.SelectedIndexChanged
        Get_SubItem()
    End Sub

    Protected Sub DrpAction_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DrpAction.SelectedIndexChanged

    End Sub

    Protected Sub DrpSub_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DrpSub.SelectedIndexChanged
        Get_Actions()
    End Sub
 
End Class

