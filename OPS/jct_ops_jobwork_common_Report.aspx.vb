Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.Web
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Partial Class OPS_jct_ops_jobwork_common_Report
    Inherits System.Web.UI.Page
    Dim Cmd As New SqlCommand
    Dim Obj As New Connection
    Dim SqlPass As String
    Dim rpt As ReportDocument
    'Dim qry As String = ConfigurationManager.ConnectionStrings("test").ToString()
    'Dim con As SqlConnection = New SqlConnection(qry)
    'Dim obj As New Connection()
    'Dim con As New SqlConnection("Data Source=misdev;Initial Catalog=jctdev;User ID=itgrp ;password=power")

    Protected Sub lnkBtnView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkBtnView.Click
        'con.Open()
        SqlPass = "jct_ops_jobwork_invoice_report"
        Cmd = New SqlCommand(SqlPass, obj.Connection())
        Cmd.CommandType = CommandType.StoredProcedure
        Cmd.Parameters.Add("@InvoiceNo", SqlDbType.VarChar).Value = txtEinvNo.Text
        Dim Da As SqlDataAdapter = New SqlDataAdapter(Cmd)
        Dim ds As DataSet = New DataSet()
        Da.Fill(ds)
        rpt.Load(Server.MapPath("jct_ops_jobwork_common_Report.rpt"))
        'rpt.SetDatabaseLogon("itgrp", "power", "misdev", "jctdev")
        rpt.SetDataSource(ds.Tables(0))
        CrystalReportViewer1.ReportSource = rpt
        'con.Close()
        ds.Clear()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'con.Open()
        rpt = New ReportDocument()
        SqlPass = "jct_ops_jobwork_invoice_report"
        Cmd = New SqlCommand(SqlPass, obj.Connection())
        Cmd.CommandType = CommandType.StoredProcedure
        Cmd.Parameters.Add("@InvoiceNo", SqlDbType.VarChar).Value = txtEinvNo.Text
        Dim Da As SqlDataAdapter = New SqlDataAdapter(Cmd)
        Dim ds As DataSet = New DataSet()
        Da.Fill(ds)
        rpt.Load(Server.MapPath("jct_ops_jobwork_common_Report.rpt"))
        'rpt.SetDatabaseLogon("itgrp", "power", "misdev", "jctdev")
        rpt.SetDataSource(ds.Tables(0))
        CrystalReportViewer1.ReportSource = rpt
        'con.Close()
        ds.Clear()
    End Sub
    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload

        If (Not rpt Is Nothing) Then
            If rpt.IsLoaded = True Then
                rpt.Close()
                rpt.Dispose()
            End If
        End If

    End Sub
End Class
