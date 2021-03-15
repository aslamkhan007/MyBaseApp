Imports System.Data
Imports System.Data.SqlClient
Partial Class Hits
    Inherits System.Web.UI.Page
    Dim Obj As New Connection
    Dim Cmd As New SqlCommand
    Dim Qry As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Session("Companycode") = "jct00ltd"
        '  TextBox1.Attributes.Add("onkeypress", "return clickButton(event,'" + Button1.ClientID + "')")
        If IsPostBack = False Then
            'If (Session("empcode") <> "") Then
            'Else
            '    Response.Redirect("~/login.aspx")
            'End If
            Get_Application_Name()
            Me.TxtEffFrom.Text = Now.Date()
            Me.TxtEffTo.Text = Now.Date()
            RadioButtonList1_SelectedIndexChanged(sender, e)
            DrpApp_SelectedIndexChanged(sender, e)
        End If
    End Sub
    Protected Sub Grid()
        If Me.RadioButtonList1.Items(1).Selected = True Then
            Qry = "EXEC HITS_FUSION_APPS '" & Me.TxtEffFrom.Text & "','" & Me.TxtEffTo.Text & "','" & Trim(Me.DrpApp.SelectedValue) & "','" & Trim(Me.DrpPage.SelectedValue) & "'"
        ElseIf Me.RadioButtonList1.Items(0).Selected = True Then
            If DrpApp.SelectedValue = "FusionApps" Then
                Qry = "SELECT  Hostip as [Host IP],pagehit as [Page Name],count(Hostip)AS [Hits] from jct_fap_application_hits where convert(varchar(11),hitdt,101) BETWEEN convert(varchar(11),'" & Me.TxtEffFrom.Text & "',101 ) AND convert(varchar(11),'" & Me.TxtEffTo.Text & "',101 )  and (apphit='" & Trim(Me.DrpApp.SelectedValue) & "' or '" & Trim(Me.DrpApp.SelectedValue) & "'='ALL') and (pagehit='" & Trim(Me.DrpPage.SelectedValue) & "' or '" & Trim(Me.DrpPage.SelectedValue) & "'='ALL')  group by pagehit,hostip order by hostip"
            Else
                Qry = "SELECT  usercode as [User Code],b.empname as [User Name],b.deptcode as [Department Code],pagehit as [Page Name],count(Usercode)AS [Hits] from jct_fap_application_hits a,jct_empmast_base b where convert(varchar(11),hitdt,101) BETWEEN convert(varchar(11),'" & Me.TxtEffFrom.Text & "',101 ) AND convert(varchar(11),'" & Me.TxtEffTo.Text & "',101 ) and a.usercode=b.empcode and (apphit='" & Trim(Me.DrpApp.SelectedValue) & "' or '" & Trim(Me.DrpApp.SelectedValue) & "'='ALL') and (pagehit='" & Trim(Me.DrpPage.SelectedValue) & "' or '" & Trim(Me.DrpPage.SelectedValue) & "'='ALL')  group by pagehit,usercode,b.empname,b.deptcode order by empname"
            End If
        End If
        ViewState.Add("Qry", Qry)
        FillGrid(ViewState("Qry"), GridView1)
    End Sub
    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GridView1.PageIndex = e.NewPageIndex
        FillGrid(ViewState("Qry"), GridView1)
    End Sub
    'Protected Sub GridView1_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GridView1.Sorting
    '    SqlPass = "exec JctDev..jct_Empg_Leave_status '" & Session("Empcode") & "'"
    '    sorting(SqlPass, GridView2, e)
    'End Sub
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Qry = "SELECT Name,Designation,Deptname AS [Department],isnull(convert(varchar,nullif(Int_Off,0)),'') AS [Int Off No],isnull(convert(varchar,nullif(Int_Res,0)),'') AS [Int Res No],isnull(convert(varchar,nullif(EPB_OFF,0)),'') AS [EPBX OFF NO],isnull(convert(varchar,nullif(EPB_RES,0)),'') AS [EPBX RES NO],Mobile FROM JCT_FUSION_MISTEL WHERE  " & DropDownList1.SelectedValue & "  LIKE '%" & TextBox1.Text & "%' and name<>'' ORDER BY name"
        'ViewState.Add("Qry", Qry)
        'FillGrid(ViewState("Qry"), GridView1)
    End Sub
    Protected Sub LnkFetch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LnkFetch.Click
        Grid()
    End Sub
    Protected Sub Get_Application_Name()
        If RadioButtonList1.Items(0).Selected = True Then
            Qry = " select distinct module, module from JCT_Menu_Form_Mapping WHERE MODULE<>''"
            FillList(DrpApp, Qry)
        Else
            Qry = "select 'ALL','ALL' UNION select distinct module, module from JCT_Menu_Form_Mapping WHERE MODULE<>''"
            FillList(DrpApp, Qry)
            DrpApp.SelectedValue = "ALL"
        End If



    End Sub
    Protected Sub Get_Page_Name()
       
        Qry = "select 'ALL','ALL' UNION select distinct replace(replace(replace(page_name,'~',''),'/',''),'\',''),replace(replace(replace(page_name,'~',''),'/',''),'\','') from JCT_Menu_Form_Mapping where module='" & Trim(Me.DrpApp.SelectedValue) & "'"
        FillList(DrpPage, Qry)
        DrpPage.SelectedValue = "ALL"

    End Sub
    Protected Sub DrpApp_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DrpApp.SelectedIndexChanged
        If Me.DrpApp.SelectedValue = "ALL" Then
            Me.DrpPage.Items.Clear()
            Me.DrpPage.Items.Add("ALL")
        Else
            Get_Page_Name()
        End If
    End Sub
    Protected Sub RadioButtonList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonList1.SelectedIndexChanged
        'If Me.RadioButtonList1.Items(1).Selected = True Then
        '    Me.DrpPage.Enabled = False
        '    Me.DrpPage.SelectedValue = Nothing
        'Else
        '    Me.DrpPage.Enabled = True
        'End If
        Get_Application_Name()
        Get_Page_Name()

    End Sub
End Class

