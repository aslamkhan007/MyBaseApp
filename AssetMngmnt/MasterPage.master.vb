Imports System.Data.SqlClient
Imports System.Data
'Imports System.Data.OleDb
'Imports System.Configuration
'Imports System.Collections
'Imports System.Web
'Imports System.Web.Security
'Imports System.Web.UI
'Imports System.Web.UI.WebControls
'Imports System.Web.UI.WebControls.WebParts
'Imports System.Web.UI.HtmlControls

Partial Class Asset_MasterPage
    Inherits System.Web.UI.MasterPage
    Dim constr As String = System.Web.Configuration.WebConfigurationManager.ConnectionStrings("misjctdev").ConnectionString
    Dim i, cnt As Integer, Total As Integer = 0
    Public Qry As String, Dept As String
    Dim Obj1 As Connection = New Connection
    Dim ObjClassFUnction As Functions = New Functions
    Public Dr As SqlDataReader
    Public cmd As New SqlCommand
    Dim Row As DataRow

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'If Session("EmpCode") = "" Then
        '    Response.Redirect("~/Login.aspx")
        'Else
        '    lblDateTime.Text = DateTime.Today.ToString("dddd, dd-MMMM-yyyy")
        '    lblGreeting.Text = "Welcome! "
        '    lbluser.Text = Session("EmpName")
        'End If

        '  AddBlurAtt(ContentPlaceHolder1)

        If Not Page.IsPostBack Then
            ObjClassFUnction.RegAppHit(Session("Companycode"), Session("Empcode"), "Asset Management", Request.UserHostAddress)
            'RegAppHit(Session("Companycode"), Session("Empcode"), "Courier Management", Request.UserHostAddress)

            Dim Sqlpass As String = "select description,page_name=isnull(c.page_name,''),parent_menu,seq from production..user_module_menus_mapping a inner join production..modules_menu_master b on a.module=b.module and a.mnuname=b.mnuname left outer join jctdev..JCT_Menu_Form_Mapping c on b.module = c.module and b.mnuname=c.mnuname where a.module ='Asset Management' and uname='" & Session("Empcode") & "'   and parent_menu=''   UNION select b.description,page_name=isnull(c.page_name,''),parent_menu,seq from production..role_module_menus_mapping a inner join production..modules_menu_master b on a.module=b.module and a.mnuname=b.mnuname inner join production..role_user_mapping e on a.role=e.role left outer join jctdev..JCT_Menu_Form_Mapping c on b.module = c.module and b.mnuname=c.mnuname  where a.module ='Asset Management' and uname='" & Session("Empcode") & "'  and parent_menu='' order by parent_menu,seq"
            Dim Dr As SqlDataReader = Obj1.FetchReader(Sqlpass)
            Dim daHod As SqlDataAdapter = New SqlDataAdapter(Sqlpass, Obj1.Connection())
            If Dr.IsClosed = False Then
                Dr.Close()
            End If
            Dim objDS As New DataSet
            daHod.Fill(objDS, "Parent")

            Obj1.ConClose()

            Dim nodeResp, nodeUnder, nodeUnder2, nodeUnder3 As TreeNode
            Dim rowResp, rowUnder, rowUnder2, rowUnder3 As DataRow
            Dim ID1 As String
            For Each rowResp In objDS.Tables("Parent").Rows

                nodeResp = New TreeNode
                nodeResp.Text = rowResp("description")
                ID1 = rowResp("description")
                TreeView1.Nodes.Add(nodeResp)

                '---------------Parent Node-----------------------
                Dim Sqlpass1 As String = "select  description,page_name=replace(replace(replace(isnull(c.page_name,''),'~',''),'/',''),'\',''),parent_menu,seq from production..user_module_menus_mapping a inner join production..modules_menu_master b on a.module=b.module and a.mnuname=b.mnuname left outer join jctdev..JCT_Menu_Form_Mapping c on b.module = c.module and b.mnuname=c.mnuname where a.module ='Asset Management' and uname='" & Session("Empcode") & "'   and parent_menu='" & ID1 & " '   UNION select b.description,page_name=replace(replace(replace(isnull(c.page_name,''),'~',''),'/',''),'\',''),parent_menu,seq from production..role_module_menus_mapping a inner join production..modules_menu_master b on a.module=b.module and a.mnuname=b.mnuname inner join production..role_user_mapping e on a.role=e.role left outer join jctdev..JCT_Menu_Form_Mapping c on b.module = c.module and b.mnuname=c.mnuname  where a.module ='Asset Management' and uname='" & Session("Empcode") & "'  and parent_menu='" & ID1 & " ' order by parent_menu,seq"
                Dim Dr1 As SqlDataReader = Obj1.FetchReader(Sqlpass1)
                Dim daUnder As SqlDataAdapter = New SqlDataAdapter(Sqlpass1, Obj1.Connection())

                Dr1.Close()

                Dim objDS1 As New DataSet
                daUnder.Fill(objDS1, "dtUnder")
                Dim ID2 As String
                For Each rowUnder In objDS1.Tables("dtUnder").Rows

                    nodeUnder = New TreeNode
                    nodeUnder.Text = rowUnder("description")
                    ID2 = rowUnder("description")

                    nodeResp.ChildNodes.Add(nodeUnder)

                    Dim Sqlpass2 As String = "select description,page_name=replace(replace(replace(isnull(c.page_name,''),'~',''),'/',''),'\',''),parent_menu,seq from production..user_module_menus_mapping a inner join production..modules_menu_master b on a.module=b.module and a.mnuname=b.mnuname left outer join jctdev..JCT_Menu_Form_Mapping c on b.module = c.module and b.mnuname=c.mnuname where a.module ='Asset Management' and uname='" & Session("Empcode") & "'   and parent_menu='" & ID2 & " '  UNION select b.description,page_name=replace(replace(replace(isnull(c.page_name,''),'~',''),'/',''),'\',''),parent_menu,seq from production..role_module_menus_mapping a inner join production..modules_menu_master b on a.module=b.module and a.mnuname=b.mnuname inner join production..role_user_mapping e on a.role=e.role left outer join jctdev..JCT_Menu_Form_Mapping c on b.module = c.module and b.mnuname=c.mnuname  where a.module ='Asset Management' and uname='" & Session("Empcode") & "'  and parent_menu='" & ID2 & " ' order by parent_menu,seq"

                    Dim Dr2 As SqlDataReader = Obj1.FetchReader(Sqlpass2)
                    Dim daUnder2 As SqlDataAdapter = New SqlDataAdapter(Sqlpass2, Obj1.Connection())
                    Dr2.Close()

                    Dim objDS2 As New DataSet
                    daUnder2.Fill(objDS2, "dtUnder2")

                    Dim ID3 As String
                    For Each rowUnder2 In objDS2.Tables("dtUnder2").Rows

                        nodeUnder2 = New TreeNode
                        nodeUnder2.Text = rowUnder2("description")
                        ID3 = rowUnder2("description")

                        nodeUnder.ChildNodes.Add(nodeUnder2)

                        '----------------------------Level 4----------------------

                        Dim Sqlpass3 As String = "select  description,page_name=replace(replace(replace(isnull(c.page_name,''),'~',''),'/',''),'\',''),parent_menu,seq from production..user_module_menus_mapping a inner join production..modules_menu_master b on a.module=b.module and a.mnuname=b.mnuname left outer join jctdev..JCT_Menu_Form_Mapping c on b.module = c.module and b.mnuname=c.mnuname where a.module ='Asset Management' and uname='" & Session("Empcode") & "'    and parent_menu='" & ID3 & " '  UNION select b.description,page_name=replace(replace(replace(isnull(c.page_name,''),'~',''),'/',''),'\',''),parent_menu,seq from production..role_module_menus_mapping a inner join production..modules_menu_master b on a.module=b.module and a.mnuname=b.mnuname inner join production..role_user_mapping e on a.role=e.role left outer join jctdev..JCT_Menu_Form_Mapping c on b.module = c.module and b.mnuname=c.mnuname  where a.module ='Asset Management' and uname='" & Session("Empcode") & "'  and parent_menu='" & ID3 & " ' order by parent_menu,seq"
                        Dim Dr3 As SqlDataReader = Obj1.FetchReader(Sqlpass3)
                        Dim daUnder3 As SqlDataAdapter = New SqlDataAdapter(Sqlpass3, Obj1.Connection())
                        Dr3.Close()

                        Dim objDS3 As New DataSet
                        daUnder3.Fill(objDS3, "dtUnder3")

                        Dim ID4 As String
                        For Each rowUnder3 In objDS3.Tables("dtUnder3").Rows

                            nodeUnder3 = New TreeNode
                            nodeUnder3.Text = rowUnder3("description")
                            ID4 = rowUnder3("description")

                            nodeUnder2.ChildNodes.Add(nodeUnder3)

                        Next
                        daUnder3.Dispose()
                        '---------------------------------------------------------

                    Next
                    daUnder2.Dispose()
                Next

                daUnder.Dispose()

                'objDS.Dispose()

                'daHod.Dispose()
            Next
            'clean up

            objDS.Dispose()

            daHod.Dispose()



            Obj1.ConClose()
            TreeView1.ExpandAll()
        End If

    End Sub

    Protected Sub TreeView1_SelectedNodeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TreeView1.SelectedNodeChanged
        Dim Sqlpass As String = "select  page_name=replace(replace(replace(isnull(c.page_name,''),'~',''),'/',''),'\','') from production..user_module_menus_mapping a inner join production..modules_menu_master b on a.module=b.module and a.mnuname=b.mnuname left outer join jctdev..JCT_Menu_Form_Mapping c on b.module = c.module and b.mnuname=c.mnuname where a.module ='Asset Management'  and description='" & TreeView1.SelectedValue & " '  union select  page_name=replace(replace(replace(isnull(c.page_name,''),'~',''),'/',''),'\','')  from production..role_module_menus_mapping a inner join production..modules_menu_master b on a.module=b.module and a.mnuname=b.mnuname inner join production..role_user_mapping e on a.role=e.role left outer join jctdev..JCT_Menu_Form_Mapping c on b.module = c.module and b.mnuname=c.mnuname  where a.module ='Asset Management'   and description='" & TreeView1.SelectedValue & " '  "
        Dim Dr As SqlDataReader = Obj1.FetchReader(Sqlpass)
        Try
            If Dr.HasRows = True Then
                While Dr.Read()
                    Sqlpass = Dr.Item("Page_name")
                End While
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Dr.Close()
            Obj1.ConClose()
            Response.Redirect(Sqlpass)
        End Try
    End Sub

    Protected Sub lnkLogin_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkLogin.Click
        Session("Empcode") = ""
        Response.Redirect("~/Login.aspx")
    End Sub
End Class


