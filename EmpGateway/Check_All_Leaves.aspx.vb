Imports System.Data
Imports System.Data.SqlClient
Partial Class EmpGateway_Check_All_Leaves
    Inherits System.Web.UI.Page
    Dim obj As Connection = New Connection
    Dim obj1 As Functions = New Functions
    Dim sql As String
    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        BindData()
    End Sub

    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GridView1.PageIndex = e.NewPageIndex
        BindData()
    End Sub
    Public Sub BindData()
        sql = "Exec empg_leave_status_all_employee_Jatin '" & txtSdate.Text & "','" & txtEdate.Text & "'"
        obj1.FillGrid(sql, GridView1)
    End Sub

    Protected Sub LinkButton2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton2.Click
        BindData()
        GridViewExportUtil.Export("Standard Cost for Acc Period.xls", GridView1)
    End Sub
End Class
