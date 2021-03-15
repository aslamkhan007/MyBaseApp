Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Partial Class CrystalPopUp
    Inherits System.Web.UI.Page
    Dim Obj As Connection = New Connection
    Dim Fun As Functions = New Functions
    Dim SqlPass As String, SqlPass1 As String, Dr As SqlDataReader, Ds As New DataSet
    Dim rpt As ReportDocument
    
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("RadioButton") = "a" Then
            REPORT()
        End If

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
        Dim Da As SqlDataAdapter = New SqlDataAdapter(Session("SqlPass1"), Obj.Connection())
        Dim ds As DataSet = New DataSet()
        Obj.ConClose()
        ds.Clear()
        Da.Fill(ds)

        rpt = New ReportDocument()
        rpt.Load(Server.MapPath("CrystalReport.rpt"))
        rpt.SetDataSource(ds.Tables(0))


        CrystalReportViewer1.ReportSource = rpt

        CrystalReportViewer1.Height = 600
        CrystalReportViewer1.Width = 800

        Obj.ConClose()
    End Sub
End Class
