
Partial Class DOCMgmt_FileDeletion
    Inherits System.Web.UI.Page
    Dim sql As String
    Dim objfun As functions = New functions



    Protected Sub LinkButton4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton4.Click
        Response.Redirect("ResultGrid.aspx?catg=" & Request.QueryString("Catg"))
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("Empcode") = "" Then
            Response.Redirect("~/Login.aspx")
        End If
        sql = "update JCT_DMS_Trans_Upload set status='D', DeletionDt=getdate(), DeletedBy='" & Session("Empcode") & "' where status='' and transno=" & Request.QueryString("TransNo")
        objfun.UpdateRecord(sql)

        sql = "update JCT_DMS_Trans_Upload_Files set status='D', DeletionDt=getdate(), DeletedBy='" & Session("Empcode") & "' where status='' and transno=" & Request.QueryString("TransNo")
        objfun.UpdateRecord(sql)

        sql = "update JCT_DMS_Trans_Upload_Param set status='D' where status='A' and transno=" & Request.QueryString("TransNo")
        objfun.UpdateRecord(sql)
    End Sub
End Class
