
Partial Class Transaction_Type_Mapping
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        If (Session("empcode").ToString <> "") Then
            'empcode = Session("empcode")
        Else
            Response.Redirect("login.aspx")
        End If
    End Sub
End Class
