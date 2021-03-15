Imports System.Data
Imports System.Data.SqlClient
Partial Class Default_New
    Inherits System.Web.UI.Page

    Dim constr As String = System.Web.Configuration.WebConfigurationManager.ConnectionStrings("misjctdev").ConnectionString
    Dim WithEvents dl1 As DataList = New DataList
    Dim WithEvents mnu As Menu = New Menu
    'Dim WithEvents mnu1 As Menu = New Menu

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        '--Check for Cookie
        'If Not Request.Cookies("userName") Is Nothing Then
        '    lblUser.Text = Server.HtmlEncode(Request.Cookies("userName").Value)
        '    lnkLogin.Text = "Logout"
        'ElseIf Request.Cookies("userName") Is Nothing Then
        '    lblUser.Text = "JCTians"
        'End If
        '----
        'OR
        '--Check for Active User Session

        'If Not Session("EmpCode") = "" Then

        '    Session("EmpName") = FetchValue("select FullName from jct_epor_master_employee where status = 'A' and emp_code ='" & Session("EmpCode").ToString & "'")
        '    lblUser.Text = Session("EmpName")
        '    lnkLogin.Text = "Logout"
        'Else
        '    lblUser.Text = "JCTians"
        '    lnkLogin.Text = "Login"
        'End If

        ''--Init Greet and Username
        'lblGreeting.Text = Greet()
        'lblUser.Text += "!"
        '----

        '--Save user hit on application 

        '--Fetch Data to fill Page Data in Frames
        Dim cn As SqlConnection = New SqlConnection(constr)

        'Dim sql As String = "select 'News' 'data' union select 'JCT Links' 'data' union select 'Coming Up' 'data' union select 'Office Orders' 'data'"

        Dim sql As String = "jct_fap_main_page_frames"

        Dim da As SqlDataAdapter = New SqlDataAdapter(sql, cn)
        Dim ds As DataSet = New DataSet()
        da.Fill(ds)
        'Dim xmlds As XmlDataSource = New XmlDataSource
        'xmlds.ID = "xmlds1"
        'xmlds.Data = ds.GetXml
        'mnu1.DataSource = xmlds
        'mnu1.DataBind()
        DataList2.DataSource = ds.Tables(0)
        DataList2.DataBind()

    End Sub

    Protected Sub DataList2_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs) Handles DataList2.ItemDataBound

        'If Not IsPostBack Then
        Try
            Dim item As String = CType(e.Item.FindControl("hiddenfield1"), HiddenField).Value
            Dim cn As SqlConnection = New SqlConnection(constr)
            'Dim sql As String = "select 'News' 'text' union select 'JCT Links' 'text' union select 'Coming Up' 'text'"

            'To Fetch Menu Items

            Dim sql As String = "select itemcode 'value', sdescription 'text', ldescription 'desc' from jct_fap_item_master where parentitemcode = '" & item & "'"
            Dim da As SqlDataAdapter = New SqlDataAdapter(sql, cn)
            Dim ds As DataSet = New DataSet()
            da.Fill(ds)
            da.Dispose()
            ds.DataSetName = "Menus"
            ds.Tables(0).TableName = "Menu"

            Dim m1 As Menu = CType(e.Item.FindControl("Menu1"), Menu)

            'To Fill Menu Items

            Dim xmlds1 As XmlDataSource = New XmlDataSource
            xmlds1.ID = "xmlds1"
            xmlds1.EnableCaching = False
            xmlds1.TransformFile = "FrameMenuTrans.xslt"
            xmlds1.Data = ds.GetXml()
            ds.Dispose()
            xmlds1.XPath = "MenuItems/MenuItem"
            'ds.WriteXml("Samplexmlfile.xml")
            m1.DataSource = xmlds1
            m1.DataBind()

            item = m1.Items(0).Value

            sql = "select itemcode 'value', sdescription 'text', url, iconimage, ldescription 'desc', effFrom 'date' from jct_fap_item_master where parentitemcode = '" & item & "'"

            If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
                'Dim dl1 As DataList = CType(e.Item.FindControl("DataList3"), DataList)
                dl1 = CType(e.Item.FindControl("DataList3"), DataList)
                dl1.DataSource = FetchRecords(sql)
                dl1.DataBind()
            End If
            'mnu = CType(e.Item.FindControl("Menu1"), Menu)

            Dim img As Image = CType(e.Item.FindControl("Image1"), Image)
            sql = "select iconimage from jct_fap_item_master where itemcode = '" & item & "'"
            img.ImageUrl = FetchValue(sql).ToString

        Catch ex As Exception
            Alert(ex.ToString)
        End Try
        'End If

    End Sub

    Protected Sub Menu1_MenuItemClick(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.MenuEventArgs) Handles mnu.MenuItemClick
        Dim item As String = e.Item.Value
        Dim sql As String = "select itemcode 'value', sdescription 'text', url, ldescription 'desc', effFrom 'date' from jct_fap_item_master where parentitemcode = '" & item & "'"
        Dim dl As DataList = CType(sender, Menu).Parent.FindControl("Datalist3")
        dl.DataSource = FetchRecords(sql)
        dl.DataBind()

        Dim img As Image = CType(sender, Menu).Parent.FindControl("Image1")
        sql = "select iconimage from jct_fap_item_master where itemcode = '" & item & "'"
        img.ImageUrl = FetchValue(sql).ToString
        'img.DataBind()

    End Sub


End Class
