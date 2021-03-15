Imports System.Data.SqlClient
Imports System.Data
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine

Partial Class Sticker
    Inherits System.Web.UI.Page
    Dim Obj As Connection = New Connection
    Dim Fun As Functions = New Functions
    Dim SqlPass As String, SqlPass1 As String, Dr As SqlDataReader, Ds As New DataSet
    Dim rpt As New ReportDocument
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        REPORT()
    End Sub
    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        If (Not rpt Is Nothing) Then
            If rpt.IsLoaded = True Then
                rpt.Close()
                rpt.Dispose()
            End If
        End If
    End Sub
    Protected Sub REPORT()
        Dim Da As SqlDataAdapter = New SqlDataAdapter("SELECT * FROM production..tmp_sample_sticker", Obj.Connection())
        Dim ds As DataSet = New DataSet()
        Obj.ConClose()
        ds.Clear()
        Da.Fill(ds)
        rpt = New ReportDocument()
        rpt.Load(Server.MapPath("CrystalReport2.rpt"))
        rpt.SetDataSource(ds.Tables(0))
        CrystalReportViewer2.ReportSource = rpt
        Obj.ConClose()
    End Sub
    Protected Sub cmdGetReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGetReport.Click
    End Sub
    Protected Sub Close_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Close.Click
    End Sub
End Class
