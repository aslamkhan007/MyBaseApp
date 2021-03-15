
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Data
Imports System.IO
Imports System.Text
Imports System.Data.SqlClient
Imports System.Web.UI.DataVisualization.Charting
Imports System.Web.UI.HtmlControls
Imports System.IO.StreamWriter


Partial Class BarCode
    Inherits System.Web.UI.Page
    Dim Obj As Connection = New Connection()
    Dim SqlPass As String, SqlChartParm As String
    Dim Xl As GridViewExportUtil = New GridViewExportUtil
    Dim sum As Decimal

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        Response.Cache.SetExpires(Now.AddSeconds(-1))
        Response.Cache.SetNoStore()
        Response.AppendHeader("Pragma", "no-cache")
        ItemGroup()
    End Sub



    Public Sub BindGrid(ByVal SqlPass As String)

        Dim Dr As SqlDataReader = Obj.FetchReader(SqlPass)
        Dim Da As SqlDataAdapter = New SqlDataAdapter(SqlPass, Obj.Connection())

        Try
            If Dr.HasRows = True Then
                Dr.Close()
                Dim ds As DataSet = New DataSet()
                ds.Clear()
                Da.Fill(ds)

                grdStage.DataSource = ds
                grdStage.DataBind()

                Dr.Close()

            End If
        Catch ex As Exception
            ClientScript.RegisterClientScriptBlock(GetType(Page), "scr", "<script language = javascript>alert('" & ex.Message & "!!')</script>")
        Finally
            Obj.ConClose()
        End Try

    End Sub



    Protected Sub lnkExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkExcel.Click

        GridViewExportUtil.Export("PackedStock.xls", grdStage)
    End Sub



    Protected Sub lnkFetch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkFetch.Click

        ItemGroup()

    End Sub

    Protected Sub grdStage_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdStage.PageIndexChanging

        grdStage.PageIndex = e.NewPageIndex
        ItemGroup()

    End Sub
    Protected Sub ItemGroup()
        If RadioButtonList1.SelectedValue = "Summary" Then
            SqlPass = " SELECT  Date ,[Godown No] ,SUM(ISNULL(ScannedLots,0)) AS [Scanned Lots] ,SUM(ISNULL(NotScannedLots,0)) AS [Not Scanned Lots] FROM (SELECT  CONVERT(VARCHAR(11), CONVERT(SMALLDATETIME, CONVERT(VARCHAR(11), LEFT(PckListNo,9))), 103) AS Date , GodownNo AS [Godown No] ,CASE WHEN ISNULL(GodInStatus, '') = 'R' THEN COUNT(Lot_No) END AS [ScannedLots] , CASE WHEN ISNULL(GodInStatus, '') <> 'R' THEN COUNT(Lot_No)  END AS [NotScannedLots] FROM    PRODUCTION..Barcode2 WHERE   CONVERT(SMALLDATETIME, CONVERT(VARCHAR(11), LEFT(PckListNo, 9))) BETWEEN '" & txtFrDate.Text & "' AND '" & txtToDate.Text & "'  AND GodownNo = '" & ddlGodown.Text & "' GROUP BY CONVERT(SMALLDATETIME, CONVERT(VARCHAR(11), LEFT(PckListNo, 9))) , GodownNo , GodInStatus ) AS Total GROUP BY   Date ,  [Godown No] ORDER BY Date DESC "
            'SELECT CONVERT(VARCHAR(11), CONVERT(SMALLDATETIME, CONVERT(VARCHAR(11), LEFT(PckListNo, 9))),103) AS Date , GodownNo as [Godown No] , COUNT(Lot_No) AS [Total Lots] , SUM(CONVERT(NUMERIC, Qty)) AS Qty ,      PckStatus , ISNULL(GodInStatus, '') AS [Godown In Status] FROM   PRODUCTION.. Barcode2 WHERE   CONVERT(SMALLDATETIME, CONVERT(VARCHAR(11), LEFT(PckListNo, 9))) BETWEEN   '" & txtFrDate.Text & "' AND '" & txtToDate.Text & "'  AND GodownNo = '" & ddlGodown.Text & "' GROUP BY CONVERT(SMALLDATETIME, CONVERT(VARCHAR(11), LEFT(PckListNo, 9))) ,GodownNo,PckStatus,GodInStatus ORDER BY CONVERT(SMALLDATETIME, CONVERT(VARCHAR(11), LEFT(PckListNo, 9)))    DESC"
        Else
            SqlPass = " SELECT  CONVERT(VARCHAR(11), CONVERT(SMALLDATETIME, CONVERT(VARCHAR(11), LEFT(PckListNo, 9))),103) AS Date , Lot_No AS [Lot No] , Qty , GodownNo , PckStatus , ISNULL(GodInStatus, '') AS [God In Status]  FROM   PRODUCTION..Barcode2  WHERE   CONVERT(SMALLDATETIME, CONVERT(VARCHAR(11), LEFT(PckListNo, 9))) BETWEEN   '" & txtFrDate.Text & "' AND '" & txtToDate.Text & "' AND GodownNo = '" & ddlGodown.Text & "' ORDER BY CONVERT(VARCHAR(11), CONVERT(SMALLDATETIME, CONVERT(VARCHAR(11), LEFT(PckListNo, 9))),103) "
        End If
        BindGrid(SqlPass)
    End Sub


    Function CreateExcelFile(ByVal dt As DataTable) As Boolean

        Dim bFileCreated As Boolean = False
        Dim sTableStart As String = "<HTML><BODY><TABLE Border=1><TR><TH>Packed Stock UptoDate </TH></TR>"
        Dim sTableEnd As String = "</TABLE></BODY></HTML>"
        Dim sTableData As String = ""
        Dim nRow As Long
        sTableData &= "<TR>"
        For nCol = 0 To dt.Columns.Count - 1
            sTableData &= "<TD><B>" & dt.Columns(nCol).ColumnName & "</B></TD>"
        Next
        sTableData &= "</TR>"
        For nRow = 0 To dt.Rows.Count - 1
            sTableData &= "<TR>"
            For nCol = 0 To dt.Columns.Count - 1
                sTableData &= "<TD>" & dt.Rows(nRow).Item(nCol).ToString & "</TD>"
            Next
            sTableData &= "</TR>"
        Next
        Dim sTable As String = sTableStart & sTableData & sTableEnd
        '  Dim oExcelFile As System.IO.File
        Dim oExcelWrite As System.IO.StreamWriter
        Dim sExcelFile As String = Server.MapPath("DnV_Detail.xls")
        oExcelWrite = IO.File.CreateText(sExcelFile)
        oExcelWrite.WriteLine(sTable)
        oExcelWrite.Close()
        bFileCreated = True
        Return bFileCreated

    End Function


End Class

  