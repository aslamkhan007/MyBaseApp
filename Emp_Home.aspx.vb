Imports System
Imports System.Data
Imports System.Data.SqlClient
Partial Class oEmp_Home
    Inherits System.Web.UI.Page
    'Dim constr As String = "Data source = misdev; user id = itgrp; password = power; initial catalog = jctdev"
    Dim WithEvents dlsNested As DataList = New DataList
    Dim WithEvents dlsEmpArea As DataList = New DataList
    Dim WithEvents lnkItem As LinkButton = New LinkButton

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Session("Empcode") = "" Then
            Response.Redirect("Login.aspx")
        End If

    End Sub



    Protected Sub dlsNested_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles dlsNested.ItemCommand

        ClientScript.RegisterClientScriptBlock(Me.GetType(), "scr", "<script language = 'javascript'>alert('Application not presently available')</script>")

    End Sub


    Protected Sub dlsNested_ItemCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs) Handles dlsNested.ItemCreated

        Dim ctrl As HtmlGenericControl = CType(e.Item.FindControl("Item"), HtmlGenericControl)
        ctrl.Attributes.Add("onmouseover", "this.className = 'SelItem'")
        ctrl.Attributes.Add("onmouseout", "this.className = ''")

    End Sub

End Class
