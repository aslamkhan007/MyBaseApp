Imports System.Data
Imports System.Data.SqlClient
Partial Class Hits
    Inherits System.Web.UI.Page
    Dim Obj As New Connection
    Dim Cmd As New SqlCommand
    Dim Qry As String
    Dim OBJ2 As New FUNCTIONS
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '  TextBox1.Attributes.Add("onkeypress", "return clickButton(event,'" + Button1.ClientID + "')")
        If IsPostBack = False Then
            LnkChart.visible = "false"
            If (Session("empcode") <> "") Then
            Else
                Response.Redirect("~/login.aspx")
            End If
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
            Session("Chart") = "EXEC HITS_FUSION_APPS '" & Me.TxtEffFrom.Text & "','" & Me.TxtEffTo.Text & "','" & Trim(Me.DrpApp.SelectedValue) & "','" & Trim(Me.DrpPage.SelectedValue) & "'"
        ElseIf Me.RadioButtonList1.Items(0).Selected = True Then
            If DrpApp.SelectedValue = "FusionApps" Then
                Qry = "SELECT  b.Emp_Code as [Employee Code],b.FullName as [FullName],a.Hostip as [Host IP],a.pagehit as [Page Name],count(a.Hostip)AS [Hits] from jct_fap_application_hits a Inner join Jct_epor_master_employee b on a.UserCode=b.Emp_Code  where convert(varchar(11),a.hitdt,101) BETWEEN convert(varchar(11),'" & Me.TxtEffFrom.Text & "',101 ) AND convert(varchar(11),'" & Me.TxtEffTo.Text & "',101 )  and (apphit='" & Trim(Me.DrpApp.SelectedValue) & "' or '" & Trim(Me.DrpApp.SelectedValue) & "'='ALL') and (pagehit='" & Trim(Me.DrpPage.SelectedValue) & "' or '" & Trim(Me.DrpPage.SelectedValue) & "'='ALL') and b.status='A'  group by a.pagehit ,a.hostip,b.Emp_Code,b.FullName order by a.hostip"
                Session("Chart") = "SELECT  b.Emp_Code as [Employee Code],b.FullName as [FullName],a.Hostip as [Host IP],a.pagehit as [Page Name],count(a.Hostip)AS [Hits] from jct_fap_application_hits a Inner join Jct_epor_master_employee b on a.UserCode=b.Emp_Code  where convert(varchar(11),a.hitdt,101) BETWEEN convert(varchar(11),'" & Me.TxtEffFrom.Text & "',101 ) AND convert(varchar(11),'" & Me.TxtEffTo.Text & "',101 )  and (apphit='" & Trim(Me.DrpApp.SelectedValue) & "' or '" & Trim(Me.DrpApp.SelectedValue) & "'='ALL') and (pagehit='" & Trim(Me.DrpPage.SelectedValue) & "' or '" & Trim(Me.DrpPage.SelectedValue) & "'='ALL') and b.status='A'  group by a.pagehit ,a.hostip,b.Emp_Code,b.FullName order by a.hostip"
            Else
                Qry = "SELECT  usercode as [User Code],b.empname as [User Name],b.deptcode as [Department Code],pagehit as [Page Name],count(Usercode)AS [Hits] from jct_fap_application_hits a,jct_empmast_base b where convert(datetime,convert(varchar(12),hitdt,101)) BETWEEN convert(datetime,convert(varchar(12),'" & Me.TxtEffFrom.Text & "',101)) AND convert(datetime,convert(datetime,'" & Me.TxtEffTo.Text & "',101 )) and a.usercode=b.empcode and (apphit='" & Trim(Me.DrpApp.SelectedValue) & "' or '" & Trim(Me.DrpApp.SelectedValue) & "'='ALL') and (pagehit='" & Trim(Me.DrpPage.SelectedValue) & "' or '" & Trim(Me.DrpPage.SelectedValue) & "'='ALL')  group by pagehit,usercode,b.empname,b.deptcode order by empname"
                Session("Chart") = "SELECT  usercode as [User Code],b.empname as [User Name],b.deptcode as [Department Code],pagehit as [Page Name],count(Usercode)AS [Hits] from jct_fap_application_hits a,jct_empmast_base b where convert(datetime,convert(varchar(12),hitdt,101)) BETWEEN convert(datetime,convert(varchar(12),'" & Me.TxtEffFrom.Text & "',101)) AND convert(datetime,convert(datetime,'" & Me.TxtEffTo.Text & "',101 )) and a.usercode=b.empcode and (apphit='" & Trim(Me.DrpApp.SelectedValue) & "' or '" & Trim(Me.DrpApp.SelectedValue) & "'='ALL') and (pagehit='" & Trim(Me.DrpPage.SelectedValue) & "' or '" & Trim(Me.DrpPage.SelectedValue) & "'='ALL')  group by pagehit,usercode,b.empname,b.deptcode order by empname"
            End If
        End If
        ViewState.Add("Qry", Qry)
        OBJ2.FillGrid(ViewState("Qry"), GridView1)
        Session("AppName") = Me.DrpApp.SelectedItem.Text
        Session("ToDate") = Me.TxtEffTo.Text
        Session("PageName") = Me.DrpPage.SelectedItem.Text
        Session("Heading") = "Application Hits"
        Session("Param1Heading") = "From Date"
        Session("Param1Value") = Me.TxtEffFrom.Text
        Session("Param2Heading") = "To Date"
        Session("Param2Value") = Me.TxtEffFrom.Text
        Session("Param3Heading") = "Application Name"
        Session("Param3Value") = Me.DrpApp.SelectedItem.Text
        Session("Param4Heading") = "Page Name"
        Session("Param4Value") = Me.DrpPage.SelectedItem.Text
        Session("PageType") = "Hits"

        If Me.DrpApp.SelectedItem.Text = "ALL" Then
            Session("X-Parameter") = "Application Name"
        Else
            Session("X-Parameter") = "Page Name"
        End If

    End Sub
    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GridView1.PageIndex = e.NewPageIndex
        OBJ2.FillGrid(ViewState("Qry"), GridView1)
    End Sub
    'Protected Sub GridView1_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GridView1.Sorting
    '    SqlPass = "exec JctDev..jct_Empg_Leave_status '" & Session("Empcode") & "'"
    '    sorting(SqlPass, GridView2, e)
    'End Sub
 
    Protected Sub LnkFetch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LnkFetch.Click
        Grid()
    End Sub
    Protected Sub Get_Application_Name()
        If RadioButtonList1.Items(0).Selected = True Then
            Qry = " select distinct module, module from JCT_Menu_Form_Mapping WHERE MODULE<>''"
            OBJ2.FillList(DrpApp, Qry)
        Else
            Qry = "select 'ALL','ALL' UNION select distinct module, module from JCT_Menu_Form_Mapping WHERE MODULE<>''"
            OBJ2.fillList(DrpApp, Qry)
            DrpApp.SelectedValue = "ALL"
        End If



    End Sub
    Protected Sub Get_Page_Name()
       
        Qry = "select 'ALL','ALL' UNION select distinct replace(replace(replace(page_name,'~',''),'/',''),'\',''),replace(replace(replace(page_name,'~',''),'/',''),'\','') from JCT_Menu_Form_Mapping where module='" & Trim(Me.DrpApp.SelectedValue) & "'"
        OBJ2.FillList(DrpPage, Qry)
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
        If Me.RadioButtonList1.Items(1).Selected = True Then
            Me.LnkChart.Visible = True
        Else
            Me.LnkChart.Visible = False
        End If
        Get_Application_Name()
        Get_Page_Name()

    End Sub
    Protected Sub LnkChart_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LnkChart.Click
        Grid()
        Dim scrpt_str As String = "<script language='javascript'>window.opener=null;window.open('','_top'); window.open('\PopupChart.aspx','','height=700, width= 900, status=yes, resizable= yes, scrollbars= yes, toolbar= no,location= center, menubar= no'); </script> "
        ScriptManager.RegisterClientScriptBlock(Me.UpdatePanel9, Me.UpdatePanel9.GetType(), "scr", scrpt_str, False)
    End Sub
End Class

