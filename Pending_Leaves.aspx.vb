Imports System.Data
Imports System.Data.SqlClient

Partial Class Pending_Leaves
    Inherits System.Web.UI.Page
    Dim Obj As New Connection
    Dim ObjFunction As New Functions
    Dim Cmd As New SqlCommand
    Dim Qry As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Session("Companycode") = "jct00ltd"
        If IsPostBack = False Then
            'If (Session("empcode") <> "") Then
            'Else
            '    Response.Redirect("~/login.aspx")
            'End If
            Grid()
        End If
    End Sub
    Protected Sub Grid()
        Qry = "EXEC JCT_LEAVE_STATUS_HOD '" & Session("Empcode") & "'"
        ViewState.Add("Qry", Qry)
        ObjFunction.FillGrid(ViewState("Qry"), GridView1)
    End Sub
    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GridView1.PageIndex = e.NewPageIndex
        ObjFunction.FillGrid(ViewState("Qry"), GridView1)
    End Sub
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
     
    End Sub
    Protected Sub HoverImages()
    End Sub
    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
    End Sub
End Class





















































































































