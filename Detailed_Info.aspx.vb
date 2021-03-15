Imports System
Imports System.Data
Imports System.Data.SqlClient
Partial Class Detailed_Info
    Inherits System.Web.UI.Page
    Dim constr As String = "Data source = test2k; user id = itgrp; password = power; initial catalog = jctdev"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim cn As SqlConnection = New SqlConnection(constr)
        Dim sql As String = "select 'News' 'data' " 'union select 'JCT Links' 'data' "
        '"union select 'Others' 'data' union select 'Others2' 'data'"

        Dim da As SqlDataAdapter = New SqlDataAdapter(sql, cn)
        Dim ds As DataSet = New DataSet()
        da.Fill(ds)
        Dim xmlds As XmlDataSource = New XmlDataSource
        xmlds.Data = ds.GetXml

        dlsDetail.DataSource = ds.Tables(0)
        dlsDetail.DataBind()

    End Sub
End Class
