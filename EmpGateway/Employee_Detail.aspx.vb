Imports System.Data
Imports System.Data.SqlClient
Partial Class EmpGateway_Employee_Detail
    Inherits System.Web.UI.Page
    Dim obj As Connection = New Connection
    Dim obj1 As Functions = New Functions
    Dim sql As String
    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        sql = "Exec MistelDetail '" & txtCommon.Text & "' "
        obj1.FillGrid(sql, GridView1)
    End Sub
End Class
