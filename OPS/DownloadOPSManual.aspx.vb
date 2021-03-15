
Partial Class OPS_DownloadOPSManual
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Response.Redirect("docs\OPSManual.pdf")

    End Sub

End Class
