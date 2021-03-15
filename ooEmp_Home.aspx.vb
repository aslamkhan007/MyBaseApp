Imports System
Imports System.Data
Imports System.Data.SqlClient
Partial Class Emp_Home
    Inherits System.Web.UI.Page
    Dim constr As String = Web.Configuration.WebConfigurationManager.ConnectionStrings("misjctdev").ConnectionString
    '"Data source = misdev; user id = itgrp; password = power; initial catalog = jctdev"
    Dim WithEvents dlsNested As DataList = New DataList
    Dim WithEvents dlsEmpArea As DataList = New DataList
    Dim WithEvents lnkItem As LinkButton = New LinkButton
    Dim ofn As Functions = New Functions
    Dim empcode As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        Response.Cache.SetExpires(Now.AddSeconds(-1))
        Response.Cache.SetNoStore()
        Response.AppendHeader("Pragma", "no-cache")

        If (Session("empcode").ToString <> "") Then
            empcode = Session("empcode")
        Else
            Response.Redirect("~/login.aspx")
        End If

        'Dim cn As SqlConnection = New SqlConnection(constr)
        Dim sql As String = "select distinct case when web_flag = 'T' then 'Web Applications' " & _
        " when web_flag = 'R' then 'RAMCO ERP' when web_flag = 'W' then 'Other Apps' end 'data', Web_Flag from production..modules where web_flag <> '' order by web_flag"
        '"union select 'Others' 'data' union select 'Others2' 'data'"

        'Dim da As SqlDataAdapter = New SqlDataAdapter(sql, cn)
        'Dim ds As DataSet = New DataSet()
        'da.Fill(ds)
    
        dlsRight.DataSource = ofn.FetchDS(sql) 'ds.Tables(0)
        dlsRight.DataBind()

        sql = "select 'My Area' 'data'"

        dlsLeft.DataSource = ofn.FetchDS(sql) 'ds.Tables(0)
        dlsLeft.DataBind()

        CType(Master.FindControl("lnkMyArea"), LinkButton).Visible = False

    End Sub

    Protected Sub dlsLeft_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs) Handles dlsLeft.ItemDataBound
        Dim qs As String = "" '"?" & "UserName=Jagdeep" & "App= "
        Dim cn As SqlConnection = New SqlConnection(constr)

        Dim sql As String
        'Commented By Jagdeep on 6 Mar 2010
        'If ucase(session("Empcode")) = "R-03339" Or ucase(session("Empcode")) = "J-01838" Or ucase(session("Empcode")) = "N-02632" Then
        '    sql = "select 'Consent Area' 'data', '~\Image\Buttons_Tabs\Ball_Green.png' 'icon' , 'EmpGateway/MyWorkArae.aspx" & qs & "' 'url'  union select 'Action Area' 'data', '~\Image\Buttons_Tabs\Ball_Red.png' 'icon', 'EmpGateway/MyActions.aspx" & qs & "' 'url'  union select 'Leave Status' 'data', '~\Image\Buttons_Tabs\Ball_Yellow.png' 'icon', 'EmpGateway/Default2.aspx" & qs & "' 'url' union select 'Blog' 'data', '~\Image\Buttons_Tabs\Ball_Blue.png' 'icon', 'Blog.aspx" & qs & "' 'url' "
        'Else
        '    sql = "select 'Consent Area' 'data', '~\Image\Buttons_Tabs\Ball_Green.png' 'icon' , 'EmpGateway/MyWorkArae.aspx" & qs & "' 'url'  union select 'Action Area' 'data', '~\Image\Buttons_Tabs\Ball_Red.png' 'icon', 'EmpGateway/MyActions.aspx" & qs & "' 'url'  union select 'Leave Status' 'data', '~\Image\Buttons_Tabs\Ball_Yellow.png' 'icon', 'EmpGateway/Default2.aspx" & qs & "' 'url' "
        'End If

        'Written by Jagdeep to include Pending Leave Status of Self & Subordinate Hods
        If UCase(Session("Empcode")) = "R-03339" Or UCase(Session("Empcode")) = "J-01838" Or UCase(Session("Empcode")) = "N-02632" Then
            sql = "select 'Consent Area' 'data', '~\Image\Buttons_Tabs\Ball_Green.png' 'icon' , 'EmpGateway/MyWorkArae.aspx" & qs & "' 'url'  union select 'Action Area' 'data', '~\Image\Buttons_Tabs\Ball_Red.png' 'icon', 'EmpGateway/MyActions.aspx" & qs & "' 'url'  union select 'Leave Status' 'data', '~\Image\Buttons_Tabs\Ball_Yellow.png' 'icon', 'EmpGateway/Default2.aspx" & qs & "' 'url' union select 'Blog' 'data', '~\Image\Buttons_Tabs\Ball_Blue.png' 'icon', 'Blog.aspx" & qs & "' 'url' union select 'Pending Leaves' 'data', '~\Image\Buttons_Tabs\Ball_Blue.png' 'icon', 'Pending_Leaves.aspx" & qs & "' 'url' union select 'Survey' 'data', '~\Image\Buttons_Tabs\Ball_Red.png' 'icon', 'EmpGateway/Survey.aspx" & qs & "' 'url'"
            'Check if Logged in Employee is entitled to authorise leaves or have subordinates who are entitled for the same
        ElseIf (ofn.CheckRecordExistInTransaction("select top 1 Resp_Emp from jct_emp_hod where resp_Emp = '" & Session("Empcode").ToString & "' and status is null")) Then 'Check if Logged in Employee is entitled to authorise leaves or have subordinates who are entitled for the same
            sql = "select 'Consent Area' 'data', '~\Image\Buttons_Tabs\Ball_Green.png' 'icon' , 'EmpGateway/MyWorkArae.aspx" & qs & "' 'url'  union select 'Action Area' 'data', '~\Image\Buttons_Tabs\Ball_Red.png' 'icon', 'EmpGateway/MyActions.aspx" & qs & "' 'url'  union select 'Leave Status' 'data', '~\Image\Buttons_Tabs\Ball_Yellow.png' 'icon', 'EmpGateway/Default2.aspx" & qs & "' 'url' union select 'Pending Leaves' 'data', '~\Image\Buttons_Tabs\Ball_Blue.png' 'icon', 'Pending_Leaves.aspx" & qs & "' 'url' union select 'Survey' 'data', '~\Image\Buttons_Tabs\Ball_Red.png' 'icon', 'EmpGateway/Survey.aspx" & qs & "' 'url'"
        Else
            sql = "select 'Consent Area' 'data', '~\Image\Buttons_Tabs\Ball_Green.png' 'icon' , 'EmpGateway/MyWorkArae.aspx" & qs & "' 'url'  union select 'Action Area' 'data', '~\Image\Buttons_Tabs\Ball_Red.png' 'icon', 'EmpGateway/MyActions.aspx" & qs & "' 'url'  union select 'Leave Status' 'data', '~\Image\Buttons_Tabs\Ball_Yellow.png' 'icon', 'EmpGateway/Default2.aspx" & qs & "' 'url' union select 'Survey' 'data', '~\Image\Buttons_Tabs\Ball_Red.png' 'icon', 'EmpGateway/Survey.aspx" & qs & "' 'url'"
        End If

        Dim da As SqlDataAdapter = New SqlDataAdapter(sql, cn)
        Dim ds As DataSet = New DataSet()
        da.Fill(ds)

        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            'Dim dl1 As DataList = CType(e.Item.FindControl("DataList3"), DataList)
            dlsNested = CType(e.Item.FindControl("dlsEmpArea"), DataList)
            dlsNested.DataSource = ds.Tables(0)
            dlsNested.DataBind()
        End If

    End Sub

    Protected Sub dlsRight_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs) Handles dlsRight.ItemDataBound

        Dim item As String = CType(e.Item.FindControl("hiddenfield1"), HiddenField).Value
        Dim sql As String
        Dim cn As SqlConnection = New SqlConnection(constr)

        sql = "jct_fap_user_modules '" & Session("Empcode") & "','" & item & "','" & DetectOS() & "'"
      
        Dim da As SqlDataAdapter = New SqlDataAdapter(sql, cn)
        Dim ds As DataSet = New DataSet()
        da.Fill(ds)

        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            'Dim dlsNested As DataList '= CType(e.Item.FindControl("DataList3"), DataList)
            dlsNested = CType(e.Item.FindControl("dlsNested"), DataList)
            dlsNested.DataSource = ds.Tables(0)
            dlsNested.DataBind()
        End If

    End Sub

    Protected Sub dlsEmpArea_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs) Handles dlsEmpArea.ItemDataBound

        'Dim cn As SqlConnection = New SqlConnection(constr)
        'Dim sql As String = "select 'Image\Buttons_Tabs\Ball_Green.png' 'icon' union select 'Image\Buttons_Tabs\Ball_Red.png' 'icon' union select 'Image\Buttons_Tabs\Ball_Yellow.png' 'icon'"
        'Dim da As SqlDataAdapter = New SqlDataAdapter(sql, cn)
        'Dim ds As DataSet = New DataSet()
        'da.Fill(ds)

        'If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
        '    'Dim icon As Image = CType(e.Item.FindControl("imgIcon"), Image)
        '    dl1 = CType(e.Item.FindControl("dlsAppShrts"), DataList)
        '    dl1.DataSource = ds.Tables(0)
        '    dl1.DataBind()

        'End If

    End Sub

    Protected Sub dlsNested_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles dlsNested.ItemCommand

        ClientScript.RegisterClientScriptBlock(Me.GetType(), "scr", "<script language = 'javascript'>alert('Application not presently available')</script>")

    End Sub

    Protected Sub lnkItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkItem.Click

    End Sub

    Protected Sub dlsNested_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Protected Function DetectOS() As String
        Dim strAgent As String
        strAgent = Request.ServerVariables("HTTP_USER_AGENT")
        'Label14.Text = InStr(strAgent, "Windows98")

        'Label14.Text = InStr(strAgent, "Windows NT 6.1")

        'Commented for picking same path for old as well as new OSes------------------------
        If InStr(strAgent, "Windows 98") > 0 Or InStr(strAgent, "Windows NT 5.0") > 0 Then
            Return "O"
        Else
            Return "N"
        End If
        '-----------------------------------------------------------------------------------
        'Return "N"
    End Function

    Protected Sub dlsNested_ItemCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs) Handles dlsNested.ItemCreated

        Dim ctrl As HtmlGenericControl = CType(e.Item.FindControl("Item"), HtmlGenericControl)
        ctrl.Attributes.Add("onmouseover", "this.className = 'SelItem'")
        ctrl.Attributes.Add("onmouseout", "this.className = ''")

    End Sub

End Class
