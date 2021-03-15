
Partial Class Default2
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Session("empcode").ToString <> "") Then
            'empcode = Session("empcode")
        Else
            Response.Redirect("login.aspx")
            Exit Sub
        End If

        Dim path As String = Request.QueryString.Get("filepth") 'get file object as FileInfo  
        Dim file As System.IO.FileInfo = New System.IO.FileInfo(path) '-- if the file exists on the server  
        If file.Exists Then 'set appropriate headers  
            Response.Clear()
            Response.AddHeader("Content-Disposition", "attachment; filename=" & file.Name)
            Response.AddHeader("Content-Length", file.Length.ToString())
            'Response.ContentType = "application/octet-stream"
            Response.WriteFile(file.FullName)
            Response.End() 'if file does not exist  
            Response.Write("This file does not exist.")
        End If 'nothing in the URL as HTTP GET  

    End Sub
End Class
