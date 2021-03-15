Imports System.Data
Imports System.Data.SqlClient

Partial Class OPS_Quotation
    Inherits System.Web.UI.Page

    Dim dt As DataTable = New DataTable
    Dim dtDispatch As DataTable = New DataTable
    Protected Sub ibtAddShade_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles ibtAddShade.Click

        If Not ViewState("data") Is Nothing Then
            dt = ViewState("data")
        Else
            dt.Columns.Add("ShadeCode")
            dt.Columns.Add("ShadeName")
            dt.Columns.Add("Quantity")
        End If

        Dim drow As DataRow = dt.NewRow
        drow("ShadeCode") = ddlShade.SelectedItem.Value
        drow("ShadeName") = ddlShade.SelectedItem.Text
        drow("Quantity") = txtQuantity.Text
        dt.Rows.Add(drow)

        ViewState.Add("data", dt)
        grdShades.DataSource = dt
        grdShades.DataBind()

    End Sub

    Protected Sub ibtAddDispatchItem_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles ibtAddDispatchItem.Click
        If Not ViewState("dataDispatch") Is Nothing Then
            dtDispatch = ViewState("dataDispatch")
        Else
            dtDispatch.Columns.Add("ShadeCode")
            dtDispatch.Columns.Add("ShadeName")
            dtDispatch.Columns.Add("Quantity")
            dtDispatch.Columns.Add("DispatchDt")
        End If

        Dim drow As DataRow = dtDispatch.NewRow
        drow("ShadeCode") = ddlDispatchShade.SelectedItem.Value
        drow("ShadeName") = ddlDispatchShade.SelectedItem.Text
        drow("Quantity") = txtDispatchQuantity.Text
        drow("DispatchDt") = txtDispatchDate.Text
        dtDispatch.Rows.Add(drow)

        ViewState.Add("dataDispatch", dtDispatch)
        grdDispatchDetail.DataSource = dtDispatch
        grdDispatchDetail.DataBind()

    End Sub

    Protected Sub ibtSave_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles ibtSave.Click

    End Sub

End Class
