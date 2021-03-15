
Partial Class JCT_Times
    Inherits System.Web.UI.Page
    Dim ob As CostModule = New CostModule
    Dim issue As String '= "Oct-Nov09"
    Dim obFunction As Functions = New Functions
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            obFunction.RegAppHit("JCT00LTD", "Anonymous", "FusionApps", Request.UserHostAddress)

            Dim sql As String = "select distinct issuecode, issuecode, max(createddt) from jct_fap_jct_times group by issuecode"
            ob.fillList(ddlIssue, sql)

            Dim issue As String = ddlIssue.SelectedItem.Text '"Oct-Nov09"

            sql = "select NewsCode, Title, Description, NewsType, IconImage, Convert(varchar(20),CreatedDt,106) as CreatedDt from jct_fap_jct_times where newstype = 'newmain' and issuecode = '" & issue & "' and status is null"
            dlsNewsMain.DataSource = ob.FetchDS(sql)
            dlsNewsMain.DataBind()

            sql = "select NewsCode, Title, Description, NewsType, IconImage, Convert(varchar(20),CreatedDt,106) as CreatedDt from jct_fap_jct_times where newstype = 'NewsUpd' and  status is null" 'issuecode = '" & issue & "' and
            dlsNewsLeft.DataSource = ob.FetchDS(sql)
            dlsNewsLeft.DataBind()

            sql = "select NewsCode, Title, Description, NewsType, IconImage, Convert(varchar(20),CreatedDt,106) as CreatedDt from jct_fap_jct_times where newstype = 'GenNews' and issuecode = '" & issue & "' and status is null order by seq_no"
            dlsNewsRight.DataSource = ob.FetchDS(sql)
            dlsNewsRight.DataBind()

        End If

    End Sub

    Protected Sub dlsNewsLeft_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs) Handles dlsNewsLeft.ItemDataBound
        Dim parentitem As String = CType(e.Item.FindControl("HiddenField1"), HiddenField).Value
        Dim issue As String = ddlIssue.SelectedItem.Text
        Dim sql As String = "select NewsCode, Title, Description, NewsType, IconImage, Convert(varchar(20),CreatedDt,106) as CreatedDt from jct_fap_jct_times where newstype = 'RctNews' and ParentItem = '" & parentitem & "' and issuecode = '" & issue & "' and status is null order by createddt desc"
        Dim dl1 As DataList = New DataList
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            'Dim dl1 As DataList = CType(e.Item.FindControl("DataList3"), DataList)
            dl1 = CType(e.Item.FindControl("dlsNewsUpd"), DataList)
            dl1.DataSource = ob.FetchDS(sql)
            dl1.DataBind()
        End If
        dl1.DataSource = ob.FetchDS(sql)
        dl1.DataBind()
    End Sub

    Protected Sub ddlIssue_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlIssue.SelectedIndexChanged

        Dim issue As String = ddlIssue.SelectedItem.Text '"Oct-Nov09"
        Dim sql As String
        sql = "select NewsCode, Title, Description, NewsType, IconImage, Convert(varchar(20),CreatedDt,106) as CreatedDt from jct_fap_jct_times where newstype = 'newmain' and issuecode = '" & issue & "' and status is null"
        dlsNewsMain.DataSource = ob.FetchDS(sql)
        dlsNewsMain.DataBind()

        sql = "select NewsCode, Title, Description, NewsType, IconImage, Convert(varchar(20),CreatedDt,106) as CreatedDt from jct_fap_jct_times where newstype = 'NewsUpd' and status is null"
        dlsNewsLeft.DataSource = ob.FetchDS(sql)
        dlsNewsLeft.DataBind()

        sql = "select NewsCode, Title, Description, NewsType, IconImage, Convert(varchar(20),CreatedDt,106) as CreatedDt from jct_fap_jct_times where newstype = 'GenNews' and issuecode = '" & issue & "' and status is null order by seq_no"
        dlsNewsRight.DataSource = ob.FetchDS(sql)
        dlsNewsRight.DataBind()

    End Sub

End Class