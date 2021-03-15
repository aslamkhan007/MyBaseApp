Imports System.Data.SqlClient
Imports System.Data
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Partial Class DailyProductionAndDispatch
    Inherits System.Web.UI.Page
    Dim Cmd As New SqlCommand
    Dim rpt As ReportDocument
    Dim SqlPass, Qry, Cust As String
    Dim ShpConStr As String = System.Web.Configuration.WebConfigurationManager.ConnectionStrings("shpConnectionString").ConnectionString
    Dim Obj As Connection = New Connection()
    Dim Obj1 As Connection = New Connection(ShpConStr)

    Private Sub Page_Unload(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Unload
        If (Not rpt Is Nothing) Then
            If rpt.IsLoaded = True Then
                rpt.Close()
                rpt.Dispose()
            End If
        End If
    End Sub

    Protected Sub CrystalReportSource1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles CrystalReportSource1.Load

        CrystalReportSource1.ReportDocument.SetDatabaseLogon("ITGRP", "power")

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If ispostback Then
            TabelFetch()
        End If

    End Sub

    Protected Sub BtnFetch_Click(sender As Object, e As System.EventArgs) Handles BtnFetch.Click

        SqlPass = " EXEC SHP..JCT_NEWTPM '" & TxtDateFrom.Text & "' ,  '" & txtDateTo.Text & "'   "
        Dim cmd As SqlCommand = New SqlCommand(SqlPass, Obj1.Connection)
        cmd.CommandTimeout = 1000000
        Obj1.ConOpen()
        cmd.ExecuteNonQuery()
        Obj.ConClose()

        'TabelFetch()


    End Sub

    Protected Sub TabelFetch()
        SqlPass = "SELECT ItemGroup,DESCRIPTION ,[Group] ,SubGroup ,MainGroup ,Type,PckgTdy,PckgUTD,DisTdy,DisTdyVal,DisUTD,DisUTDVal,NSR,FromDate , ToDate  FROM   shp..JCT_NEW_TPM_FINAL_FIGURE ORDER BY [Group] ,  SubGroup ,  Type "

        Dim Da As SqlDataAdapter = New SqlDataAdapter(SqlPass, Obj1.Connection())
        Dim ds As DataSet = New DataSet()

        ds.Clear()
        Da.Fill(ds)
        '       
        rpt = New ReportDocument()
        rpt.Load(Server.MapPath("ProductionAndDispatch.rpt"))
        rpt.SetDataSource(ds.Tables(0))

        CrystalReportViewer1.ReportSource = rpt

        CrystalReportViewer1.Height = 600
        CrystalReportViewer1.Width = 820
        Obj1.ConClose()

    End Sub

    'Protected Sub CrystalReportViewer1_ReportRefresh(source As Object, e As CrystalDecisions.Web.ViewerEventArgs) Handles CrystalReportViewer1.ReportRefresh
    '    TabelFetch()
    'End Sub

    Protected Sub BtnRefresh_Click(sender As Object, e As System.EventArgs) Handles BtnRefresh.Click
        TabelFetch()

    End Sub


End Class
