Imports System.Data
Partial Class Medical_Tips
    Inherits System.Web.UI.Page
    Dim ob As CostModule = New CostModule
    Dim obFunction As Functions = New Functions

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Menu Generation using XML Data Source----------------------------
        If Not IsPostBack Then
            obFunction.RegAppHit("JCT00LTD", "Anonymous", "FusionApps", Request.UserHostAddress)

            'Dim sql As String = "select ItemCode as text, SDescription 'Desc', LDescription 'LDesc', url, case ParentItem when '' then null else ParentItem end as ParentID from jct_fap_shared_area where status <> 'D' and ItemCat = 'MedTips'" 'union select 'Home' 'text',Null 'ParentID'"
            Dim sql As String = "select ItemCode as text, SDescription 'Desc', LDescription 'LDesc', url, case ParentItem when '' then null else ParentItem end as ParentID from jct_fap_shared_area where status <> 'D' and ItemCat = 'MedTips' order by createddt desc, SDescription asc" 'union select 'Home' 'text',Null 'ParentID'"

            '"select 'Home' 'text', null 'ParentID' union select 'News' 'text', null 'ParentID' union select 'JCTLinks' 'text', null 'ParentID' union select 'Coming Up' 'text', 'Home' 'ParentID'"
            Dim ds As DataSet = ob.FetchDS(sql)
            ds.DataSetName = "Menus"
            ds.Tables(0).TableName = "Menu"

            '------------------
            Dim relation As DataRelation = New DataRelation("ParentChild", ds.Tables("Menu").Columns("text"), ds.Tables("Menu").Columns("ParentID"), True)
            relation.Nested = True
            ds.Relations.Add(relation)
            '------------------

            Dim xmlds1 As XmlDataSource = New XmlDataSource
            xmlds1.ID = "xmlds1"
            xmlds1.EnableCaching = False
            'ds.WriteXml("E:/Samplexmlfile.xml")
            xmlds1.TransformFile = "~/FrameTreeTrans.xslt"
            xmlds1.Data = ds.GetXml()
            'xmlds1.XPath = "MenuItems/MenuItem"
            xmlds1.XPath = "/MenuItems/MenuItem"

            treDept.DataSource = xmlds1
            treDept.DataBind()

            'Dim trnode As TreeNode
            'trnode = treDept.FindNode("May2010")
            'trnode.Expand()

            treDept.Nodes.Item(0).Expand()

        End If
        'GridView1.DataSource = ds.Tables(0)
        'GridView1.DataBind()

    End Sub

    Protected Sub treDept_SelectedNodeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles treDept.SelectedNodeChanged
        'GridView1.DataSource = Nothing
        'GridView1.DataBind()
        'lblTitle.Text = ""
        'If (treDept.SelectedNode.ChildNodes.Count = 0) Then
        '    'Dim sql As String = "select DataSourceProc from jct_fap_notice_board where itemcode = '" & treDept.SelectedValue & "'"
        '    Dim sql As String = "select * from "

        '    Dim item As String = ob.FetchScalar(sql)
        '    GridView1.DataSource = ob.FetchDS(item)
        '    GridView1.DataBind()
        '    lblTitle.Text = treDept.SelectedNode.Text
        '    treDept.SelectedNode.Select()
        'Else
        '    treDept.SelectedNode.Expand()
        'End If
    End Sub
End Class
