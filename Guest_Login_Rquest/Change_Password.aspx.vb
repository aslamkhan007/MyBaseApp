Imports System.Data
Imports System.Data.SqlClient
Partial Class Guest_Login_Rquest_Change_Password
    Inherits System.Web.UI.Page
    Dim sql As String
    Dim obj As Connection
    Dim obj1 As Functions
  

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        SqlDataSource1.InsertParameters("UserName").DefaultValue = txtUsername.Text
        SqlDataSource1.InsertParameters("Password").DefaultValue = txtPassword.Text
        SqlDataSource1.InsertParameters("Status").DefaultValue = "A"
        SqlDataSource1.Insert()
    End Sub

    Protected Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Response.Redirect("Change_Password.aspx")
    End Sub
End Class
