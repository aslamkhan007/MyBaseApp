Imports System.Data
Imports System.Data.SqlClient
Partial Class MasterPage
    Inherits System.Web.UI.MasterPage
    Dim constr As String = System.Web.Configuration.WebConfigurationManager.ConnectionStrings("misjctdev").ConnectionString
    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

        'Top.Attributes.Add("style", "background-position: center bottom; width: 100%; height: 100px;" & _
        '                   "background-image: url('Image/Header_Background_Glassy.png'); background-repeat: no-repeat;" & _
        '                   "text-align: center;")
        'min_width.Attributes.Add("style", "background-position: center; width: 780px; height: 100%;" & _
        '                         "background-image: url('Image/Header_Background_Glassy.png')" & _
        '                         "background-repeat: no-repeat; text-align: right; vertical-align: bottom;")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Session("EmpCode") = "" Then
            Response.Redirect("Login.aspx")
        Else
            lblDateTime.Text = DateTime.Today.ToString("dddd, dd-MMMM-yyyy")
            lblGreeting.Text = Greet()
            lblUser.Text = Session("EmpName")
        End If


        'DatePart(DateInterval.Weekday) & ", " & DatePart(DateInterval.Day)

        Dim cn As SqlConnection = New SqlConnection(constr)
        Dim sql As String = "select 'Home' 'text', null 'ParentID' union select 'News' 'text', null 'ParentID' union select 'JCTLinks' 'text', null 'ParentID' union select 'Coming Up' 'text', 'Home' 'ParentID'"
        Dim da As SqlDataAdapter = New SqlDataAdapter(sql, cn)
        Dim ds As DataSet = New DataSet()
        da.Fill(ds)
        da.Dispose()
        ds.DataSetName = "Menus"
        ds.Tables(0).TableName = "Menu"

        '------------------
        'Dim relation As DataRelation = New DataRelation("ParentChild", ds.Tables("Menu").Columns("MenuID"), ds.Tables("Menu").Columns("ParentID"), True)
        Dim relation As DataRelation = New DataRelation("ParentChild", ds.Tables("Menu").Columns("text"), ds.Tables("Menu").Columns("ParentID"), True)
        relation.Nested = True
        ds.Relations.Add(relation)
        '------------------

        Dim xmlds1 As XmlDataSource = New XmlDataSource
        xmlds1.ID = "xmlds1"
        xmlds1.EnableCaching = False
        xmlds1.TransformFile = "~/FrameMenuTrans.xslt"
        xmlds1.Data = ds.GetXml()
        'xmlds1.XPath = "MenuItems/MenuItem"
        xmlds1.XPath = "/MenuItems/MenuItem"
        'ds.WriteXml("E:/Samplexmlfile.xml")
        Menu1.DataSource = xmlds1
        Menu1.DataBind()

    End Sub
End Class
