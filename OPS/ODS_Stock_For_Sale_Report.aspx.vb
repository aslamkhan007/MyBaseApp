Imports System
Imports System.Data.SqlClient
Imports System.Reflection
Imports System.Net.Mail
Imports System.IO
Imports System.Data
Imports System.Web
Partial Class OPS_ODS_Stock_For_Sale_Report
    Inherits System.Web.UI.Page
    Dim objFun As Functions = New Functions
    Dim obj As Connection = New Connection
    Dim qry As String
    Dim dr As SqlDataReader
    Dim cmd As SqlCommand = New SqlCommand
    Protected Sub cmdFetch_Click(sender As Object, e As System.EventArgs) Handles cmdFetch.Click
        grdRequestDetail.DataSource = Nothing
        grdRequestDetail.DataBind()
        Dim Auth As String = ""
        If ddlAuthStatus.SelectedItem.Text <> "" Then
            Auth = ddlAuthStatus.SelectedItem.Text.Substring(0, 1).ToString
        End If
        qry = "Exec Jct_Ops_Bale_Status_Temp '" & txtSearchSaleOrder.Text & "','" & txtSearchSort.Text & "','" & txtSearchShade.Text & "','" & txtSearchVariant.Text & "','','" & ddlPlant.Text & "','" & Auth & "','" & txtREquestID.Text & "'"
        objFun.FillGrid(qry, grdRequestDetail)
    End Sub

    Protected Sub cmdFetch0_Click(sender As Object, e As System.EventArgs) Handles cmdFetch0.Click
        grdRequestDetail.DataSource = Nothing
        grdRequestDetail.DataBind()
    End Sub

    Protected Sub CmdXl_Click(sender As Object, e As System.EventArgs) Handles CmdXl.Click
        GridViewExportUtil.Export("ODS" & ".xls", grdRequestDetail)
    End Sub
End Class
