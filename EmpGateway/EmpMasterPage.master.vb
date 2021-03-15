Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Partial Class MasterPage
    Inherits System.Web.UI.MasterPage
    Dim i, cnt As Integer
    Public obj As New HelpDeskClass
    Public qry As String
    Public dr As SqlDataReader
    Public cmd As New SqlCommand
    '-----
    Dim Obj1 As Connection = New Connection
    Dim SqlPass As String
    Public Total As Integer = 0
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Response.Cache.SetCacheability(HttpCacheability.NoCache)
        'Response.Cache.SetExpires(Now.AddSeconds(-1))
        'Response.Cache.SetNoStore()
        'Response.AppendHeader("Pragma", "no-cache")
        ' AddBlurAtt(ContentPlaceHolder1)
        lblUserName.Text = "Welcome! " & Session("EmpName")
        ''For i = 0 To Me.Menu1.Items.Count - 1
        ''    Menu1.Items(i).Enabled = False
        ''Next
        'Time.Text = "at " & DateTime.Now.ToShortTimeString.ToString()
        'Today's Knocks
        '----------------------------------------------------------------------------------------------------
        SqlPass = "select  distinct emp_code from JCT_emp_Login_Hit  where convert(smalldatetime,convert(char(12),login_dt))=convert(smalldatetime,convert(char(12),getdate())) and Company_Code='" & Session("Location") & "'  order by emp_code"

        Dim Dr1 As SqlDataReader = Obj1.FetchReader(SqlPass)

        If Dr1.HasRows = True Then
            While Dr1.Read()
                Total = Total + 1
            End While
            Session("Knocks") = Total
            Knocks.Text = Session("Knocks") & " till " & DateTime.Now.ToShortTimeString.ToString()
        End If
        Dr1.Close()
        Obj1.ConClose()
        '----------------------------------------------------------------------------------------------------------
        If IsPostBack = False Then

            Menu1.Items.Clear()
            obj.opencn()
            qry = "select b.description,c.page_name,parent_menu,seq from production..user_module_menus_mapping a inner join production..modules_menu_master b on a.module=b.module and a.mnuname=b.mnuname left outer join jctdev..JCT_Menu_Form_Mapping c on b.module = c.module and b.mnuname=c.mnuname where a.module ='employee gateway' and uname='" & Session("empcode") & "' union select b.description,c.page_name,parent_menu,seq from production..role_module_menus_mapping a inner join production..modules_menu_master b on a.module=b.module and a.mnuname=b.mnuname inner join production..role_user_mapping e on a.role=e.role left outer join jctdev..JCT_Menu_Form_Mapping c on b.module = c.module and b.mnuname=c.mnuname  where a.module ='employee gateway' and uname='" & Trim(Session("empcode")) & "' order by parent_menu,seq"
            cmd = New SqlCommand(qry, obj.cn)
            dr = cmd.ExecuteReader
            If dr.HasRows = True Then
                While dr.Read()
                    If Trim(dr.Item(2)) = "" Then
                        Me.Menu1.Items.Add(New MenuItem(Trim(dr.Item(0))))
                        If dr.Item(1) Is System.DBNull.Value Then
                        Else
                            Me.Menu1.Items(cnt).NavigateUrl = Trim(dr.Item(1))
                        End If
                        cnt = cnt + 1
                    Else
                        For i = 0 To Me.Menu1.Items.Count - 1
                            If Trim(dr.Item(2)) = Trim(Me.Menu1.Items(i).Text) Then
                                Exit For
                            End If
                        Next
                        If i < Me.Menu1.Items.Count Then
                            Me.Menu1.Items(i).ChildItems.Add(New MenuItem(Trim(dr.Item(0))))

                            If dr.Item(1) Is System.DBNull.Value Then
                            Else
                                Me.Menu1.Items(i).ChildItems(Me.Menu1.Items(i).ChildItems.Count - 1).NavigateUrl = Trim(dr.Item(1))
                            End If
                            cnt = cnt + 1
                        End If
                    End If
                End While
            End If
            obj.closecn()
        End If

        If IsPostBack = False Then
            Menu1.Items.Clear()
            PopulateMenu()
        End If

    End Sub

    Protected Sub Menu1_MenuItemClick(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.MenuEventArgs) Handles Menu1.MenuItemClick

        If e.Item.Text = "Presentation" Then
            Response.Redirect("Downloadfile.aspx?filepth=D:/WebApplications/EmpGateway/presentation/pre.pps")
        ElseIf e.Item.Text = "Policies" Then
            Response.Redirect("Downloadfile.aspx?filepth=D:/WebApplications/EmpGateway/policies/policies.pdf")
        ElseIf e.Item.Text = "Logout" Then
            Session("empcode") = ""
            Response.Redirect("Default.aspx")
        ElseIf e.Item.Text = "Help - HOW DO I ?" Then
            Page.RegisterClientScriptBlock("scr", "<script language = javascript> window.open('http://90.0.1.251/howdoi');</script>")
        ElseIf e.Item.Text = "Close Window" Then
            Response.Write("<script language='javascript'> { window.close();}</script>")
        ElseIf e.Item.Text = "JCT Website" Then
            Page.RegisterClientScriptBlock("scr", "<script language = javascript> window.open('http://jct.co.in');</script>")
        ElseIf e.Item.Text = "JCT Football" Then
            Page.RegisterClientScriptBlock("scr", "<script language = javascript> window.open('http://jctfootball.com');</script>")

        End If

    End Sub

    Protected Sub lnkLogout_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkLogout.Click
        Session("empcode") = ""
    End Sub

    
    




    Private Sub PopulateMenu()

        Try

            '//Define new menu

            'Dim menu As New Menu()

            '//Retrieve menu data

            Dim menuData As DataTable = GetMenuData()

            AddTopMenuItems(menuData, Menu1)

            'Me.Panel1.Controls.Add(menu)

            Me.Panel1.DataBind()

        Catch ex As Exception

            Response.Write(ex.Message.ToString() & "<br />")

        End Try

    End Sub

    Private Function GetMenuData() As DataTable

        Try

            '//Populate DataTable

            Dim strSQL As String = "select b.description,page_name=isnull(c.page_name,''),parent_menu,seq from production..user_module_menus_mapping a inner join production..modules_menu_master b on a.module=b.module and a.mnuname=b.mnuname left outer join jctdev..JCT_Menu_Form_Mapping c on b.module = c.module and b.mnuname=c.mnuname where a.module ='employee gateway' and uname='" & Session("Empcode") & "' union select b.description,page_name=isnull(c.page_name,''),parent_menu,seq from production..role_module_menus_mapping a inner join production..modules_menu_master b on a.module=b.module and a.mnuname=b.mnuname inner join production..role_user_mapping e on a.role=e.role left outer join jctdev..JCT_Menu_Form_Mapping c on b.module = c.module and b.mnuname=c.mnuname  where a.module ='employee gateway' and uname='" & Trim(Session("Empcode")) & "' order by parent_menu,seq" '"select b.description,page_name=isnull(c.page_name,''),parent_menu,seq from production..user_module_menus_mapping a inner join production..modules_menu_master b on a.module=b.module and a.mnuname=b.mnuname left outer join jctdev..JCT_Menu_Form_Mapping c on b.mnuname=c.mnuname where a.module ='Costing System' and uname='" & Session("Empcode") & "' union select b.description,page_name=isnull(c.page_name,''),parent_menu,seq from production..role_module_menus_mapping a inner join production..modules_menu_master b on a.module=b.module and a.mnuname=b.mnuname inner join production..role_user_mapping e on a.role=e.role left outer join jctdev..JCT_Menu_Form_Mapping c on b.mnuname=c.mnuname  where a.module ='Costing System' and uname='" & Trim(Session("Empcode")) & "' order by parent_menu,seq"

            obj.opencn()

            Dim datMenu As SqlDataAdapter = New SqlDataAdapter(strSQL, obj.cn)

            Dim tblMenu As DataTable = New DataTable()

            datMenu.Fill(tblMenu)

            Return tblMenu

        Catch ex As Exception

            Response.Write(ex.Message.ToString() & "<br/>")

        End Try

    End Function

    Private Sub AddTopMenuItems(ByVal menuData As DataTable, ByVal menu As Menu)

        Try

            '//Populate DataView

            Dim datView As DataView = New DataView(menuData)

            '//Filter parent menu items

            datView.RowFilter = "parent_menu=''" '= 0"

            '//Populate menu with top menu items

            Dim datRow As DataRowView

            For Each datRow In datView

                '//Define new menu item

                Dim parentMenu As MenuItem

                parentMenu = CreateMenuItem(datRow("Description"), datRow("page_name"), datRow("Description"))

                menu.Items.Add(parentMenu)

                '//Populate child items of this parent

                AddChildMenuItems(menuData, datRow("Description"), parentMenu)

            Next

        Catch ex As Exception

            Response.Write(ex.Message.ToString() & "<br />")

        End Try

    End Sub

    Private Sub AddChildMenuItems(ByVal menuData As DataTable, ByVal parentID As String, ByVal parentMenu As MenuItem)

        Try

            '//Populate DataView

            Dim datView As DataView = New DataView(menuData)



            '//Filter child menu items

            'datView.RowFilter = "parent_Menu=parent_menu   "  'parentID '"parentid = " & parentID

            datView.RowFilter = "parent_menu ='" & parentID & "'"

            '//Populate parent menu item with child menu items

            Dim datRow As DataRowView

            For Each datRow In datView

                '//Define new menu item

                Dim childMenu As MenuItem

                childMenu = CreateMenuItem(datRow("Description"), datRow("page_name"), datRow("description"))

                parentMenu.ChildItems.Add(childMenu)

                '//Populate child items of this parent

                'AddChildMenuItems(menuData, datRow("seq"), childMenu)

                AddChildMenuItems(menuData, datRow("description"), childMenu)

            Next

        Catch ex As Exception

            Response.Write(ex.Message.ToString() & "<br />")

        End Try

    End Sub

    Private Function CreateMenuItem(ByVal strText As String, ByVal strUrl As String, ByVal strToolTip As String) As MenuItem

        Try

            '//Create new menu item

            Dim menuItem As New MenuItem()

            '//Set properties of the menu item

            With menuItem

                .Text = strText

                .NavigateUrl = strUrl

                .ToolTip = strToolTip

            End With

            Return menuItem

        Catch ex As Exception

            Response.Write(ex.Message.ToString() & "<br />")

        End Try

    End Function

    Public Sub AddBlurAtt(ByVal Cntrl As Control)



        If Cntrl.Controls.Count > 0 Then

            For Each ChildControl As Control In Cntrl.Controls

                AddBlurAtt(ChildControl)

            Next

        End If

        If Cntrl.[GetType]() Is GetType(TextBox) Then

            Dim TempTextBox As TextBox = DirectCast(Cntrl, TextBox)

            TempTextBox.Attributes.Add("onFocus", "DoFocus(this);")

            TempTextBox.Attributes.Add("onBlur", "DoBlur(this);")

        End If



    End Sub


End Class



