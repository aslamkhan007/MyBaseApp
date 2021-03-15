
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


Partial Class PackedStock
    Inherits System.Web.UI.Page
    Dim ShpConStr As String = System.Web.Configuration.WebConfigurationManager.ConnectionStrings("shpConnectionString").ConnectionString
    Dim Obj As Connection = New Connection(ShpConStr)
    Dim SqlPass As String, SqlChartParm As String
    Dim Xl As GridViewExportUtil = New GridViewExportUtil
    Dim sum As Decimal

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        Response.Cache.SetExpires(Now.AddSeconds(-1))
        Response.Cache.SetNoStore()
        Response.AppendHeader("Pragma", "no-cache")



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

        If RadioButtonList1.SelectedValue = "ALL" Then
            SqlPass = "SELECT    item_group_no AS ItemGroup ,LOT_NO AS LotNo, DATEDIFF(dd,recd_date,GETDATE()) AS Ageing,Wh_no AS Godown, ISNULL(Shade,'') AS Shade ,stock_no AS SortNo ,variant_no AS Variant , ISNULL(CONVERT(VARCHAR,CONVERT(NUMERIC(8,2),(qty_recd ))),'') AS Qty , CONVERT(varchar,recd_date,103)  AS PackedDate , SalePerson AS SalePerson , CustomerCode AS CustomerCode , UPPER(order_no) AS SaleOrderNo ,ISNULL(CustomerName, '') AS CustomerName , ISNULL(CONVERT(varchar,OrderDate,103),'')  AS OrderDate   FROM       JCT_Pack_Stock_UptoDate_MIS ORDER BY item_group_no,Stock_no"

        ElseIf RadioButtonList1.SelectedValue = "ITEM GROUP WISE" Then
            SqlPass = "SELECT  item_group_no AS ItemGroup, stock_no AS SortNo ,variant_no AS Variant,ISNULL(CONVERT(VARCHAR, CONVERT(NUMERIC(8, 2), SUM(qty_recd))),'') AS Qty   FROM    JCT_Pack_Stock_UptoDate_MIS  GROUP BY item_group_no , stock_no , variant_no    ORDER BY item_group_no , stock_no , variant_no"

        ElseIf RadioButtonList1.SelectedValue = "ITEM GROUP WISE AGEING" Then

            SqlPass = "SELECT    item_group_no AS ItemGroup ," & _
                "ISNULL(CONVERT(VARCHAR,CONVERT(NUMERIC(8,2),SUM(CASE WHEN Since BETWEEN 0 AND 30   THEN  qty_recd END))),'') AS [0-30] , " & _
                "ISNULL(CONVERT(VARCHAR,CONVERT(NUMERIC(8,2),SUM(CASE WHEN Since BETWEEN 31 AND 60  THEN  qty_recd END))),'') AS [31-60] , " & _
                "ISNULL(CONVERT(VARCHAR,CONVERT(NUMERIC(8,2),SUM(CASE WHEN Since BETWEEN 61 AND 90  THEN  qty_recd END))),'') AS [61-90] , " & _
                "ISNULL(CONVERT(VARCHAR,CONVERT(NUMERIC(8,2),SUM(CASE WHEN Since BETWEEN 91 AND 120 THEN  qty_recd END))),'') AS [91-120] ," & _
                "ISNULL(CONVERT(VARCHAR,CONVERT(NUMERIC(8,2),SUM(CASE WHEN Since BETWEEN 121 AND 150 THEN qty_recd END),2)),'') AS [121-150] ," & _
                "ISNULL(CONVERT(VARCHAR,CONVERT(NUMERIC(8,2),SUM(CASE WHEN Since BETWEEN 151 AND 180 THEN qty_recd END),2)),'') AS [151-180] ," & _
                "ISNULL(CONVERT(VARCHAR,CONVERT(NUMERIC(8,2),SUM(CASE WHEN Since BETWEEN 181 AND 210 THEN qty_recd END),2)),'') AS [181-210] ," & _
                "ISNULL(CONVERT(VARCHAR,CONVERT(NUMERIC(8,2),SUM(CASE WHEN Since BETWEEN 211 AND 240 THEN qty_recd END),2)),'') AS [211-240] ," & _
                "ISNULL(CONVERT(VARCHAR,CONVERT(NUMERIC(8,2),SUM(CASE WHEN Since BETWEEN 241 AND 270 THEN qty_recd END),2)),'') AS [241-270] ," & _
                "ISNULL(CONVERT(VARCHAR,CONVERT(NUMERIC(8,2),SUM(CASE WHEN Since BETWEEN 271 AND 300 THEN qty_recd END),2)),'') AS [271-300] ," & _
                "ISNULL(CONVERT(VARCHAR,CONVERT(NUMERIC(8,2),SUM(CASE WHEN Since BETWEEN 301 AND 330 THEN qty_recd END),2)),'') AS [301-330] ," & _
                "ISNULL(CONVERT(VARCHAR,CONVERT(NUMERIC(8,2),SUM(CASE WHEN Since BETWEEN 331 AND 365 THEN qty_recd END),2)),'') AS [331-365]," & _
                 "ISNULL(CONVERT(VARCHAR,CONVERT(NUMERIC(8,2),SUM(CASE WHEN Since > 365 THEN qty_recd END),2)),'') AS [>365]" & _
                "FROM      ( SELECT item_group_no ,stock_no ,variant_no ,DATEDIFF(day, recd_date, GETDATE()) Since ,qty_recd FROM      JCT_Pack_Stock_UptoDate_MIS" & _
                " ) AS Sinc GROUP BY  item_group_no ORDER BY item_group_no   "


        ElseIf RadioButtonList1.SelectedValue = "CUSTOMER WISE AGEING" Then

            SqlPass = "SELECT    CUSTOMERNAME ," & _
               "ISNULL(CONVERT(VARCHAR,CONVERT(NUMERIC(8,2),SUM(CASE WHEN Since BETWEEN 0 AND 30   THEN  qty_recd END))),'') AS [0-30] , " & _
               "ISNULL(CONVERT(VARCHAR,CONVERT(NUMERIC(8,2),SUM(CASE WHEN Since BETWEEN 31 AND 60  THEN  qty_recd END))),'') AS [31-60] , " & _
               "ISNULL(CONVERT(VARCHAR,CONVERT(NUMERIC(8,2),SUM(CASE WHEN Since BETWEEN 61 AND 90  THEN  qty_recd END))),'') AS [61-90] , " & _
               "ISNULL(CONVERT(VARCHAR,CONVERT(NUMERIC(8,2),SUM(CASE WHEN Since BETWEEN 91 AND 120 THEN  qty_recd END))),'') AS [91-120] ," & _
               "ISNULL(CONVERT(VARCHAR,CONVERT(NUMERIC(8,2),SUM(CASE WHEN Since BETWEEN 121 AND 150 THEN qty_recd END),2)),'') AS [121-150] ," & _
               "ISNULL(CONVERT(VARCHAR,CONVERT(NUMERIC(8,2),SUM(CASE WHEN Since BETWEEN 151 AND 180 THEN qty_recd END),2)),'') AS [151-180] ," & _
               "ISNULL(CONVERT(VARCHAR,CONVERT(NUMERIC(8,2),SUM(CASE WHEN Since BETWEEN 181 AND 210 THEN qty_recd END),2)),'') AS [181-210] ," & _
               "ISNULL(CONVERT(VARCHAR,CONVERT(NUMERIC(8,2),SUM(CASE WHEN Since BETWEEN 211 AND 240 THEN qty_recd END),2)),'') AS [211-240] ," & _
               "ISNULL(CONVERT(VARCHAR,CONVERT(NUMERIC(8,2),SUM(CASE WHEN Since BETWEEN 241 AND 270 THEN qty_recd END),2)),'') AS [241-270] ," & _
               "ISNULL(CONVERT(VARCHAR,CONVERT(NUMERIC(8,2),SUM(CASE WHEN Since BETWEEN 271 AND 300 THEN qty_recd END),2)),'') AS [271-300] ," & _
               "ISNULL(CONVERT(VARCHAR,CONVERT(NUMERIC(8,2),SUM(CASE WHEN Since BETWEEN 301 AND 330 THEN qty_recd END),2)),'') AS [301-330] ," & _
               "ISNULL(CONVERT(VARCHAR,CONVERT(NUMERIC(8,2),SUM(CASE WHEN Since BETWEEN 331 AND 365 THEN qty_recd END),2)),'') AS [331-365]," & _
               "ISNULL(CONVERT(VARCHAR,CONVERT(NUMERIC(8,2),SUM(CASE WHEN Since > 365 THEN qty_recd END),2)),'') AS [>365]" & _
               "FROM      ( SELECT UPPER(CASE WHEN  ISNULL(CUSTOMERNAME,'') = '' THEN 'UNMAPPED' ELSE CUSTOMERNAME END) AS CUSTOMERNAME ,stock_no ,variant_no ,DATEDIFF(day, recd_date, GETDATE()) Since ,qty_recd FROM      JCT_Pack_Stock_UptoDate_MIS" & _
               " ) AS Sinc GROUP BY  CUSTOMERNAME ORDER BY CUSTOMERNAME   "


        ElseIf RadioButtonList1.SelectedValue = "CUSTOMER WISE AGEING +" Then

            SqlPass = "SELECT    CUSTOMERNAME ,stock_no AS SortNo, order_no as OrderNo, " & _
               "ISNULL(CONVERT(VARCHAR,CONVERT(NUMERIC(8,2),SUM(CASE WHEN Since BETWEEN 0 AND 30   THEN  qty_recd END))),'') AS [0-30] , " & _
               "ISNULL(CONVERT(VARCHAR,CONVERT(NUMERIC(8,2),SUM(CASE WHEN Since BETWEEN 31 AND 60  THEN  qty_recd END))),'') AS [31-60] , " & _
               "ISNULL(CONVERT(VARCHAR,CONVERT(NUMERIC(8,2),SUM(CASE WHEN Since BETWEEN 61 AND 90  THEN  qty_recd END))),'') AS [61-90] , " & _
               "ISNULL(CONVERT(VARCHAR,CONVERT(NUMERIC(8,2),SUM(CASE WHEN Since BETWEEN 91 AND 120 THEN  qty_recd END))),'') AS [91-120] ," & _
               "ISNULL(CONVERT(VARCHAR,CONVERT(NUMERIC(8,2),SUM(CASE WHEN Since BETWEEN 121 AND 150 THEN qty_recd END),2)),'') AS [121-150] ," & _
               "ISNULL(CONVERT(VARCHAR,CONVERT(NUMERIC(8,2),SUM(CASE WHEN Since BETWEEN 151 AND 180 THEN qty_recd END),2)),'') AS [151-180] ," & _
               "ISNULL(CONVERT(VARCHAR,CONVERT(NUMERIC(8,2),SUM(CASE WHEN Since BETWEEN 181 AND 210 THEN qty_recd END),2)),'') AS [181-210] ," & _
               "ISNULL(CONVERT(VARCHAR,CONVERT(NUMERIC(8,2),SUM(CASE WHEN Since BETWEEN 211 AND 240 THEN qty_recd END),2)),'') AS [211-240] ," & _
               "ISNULL(CONVERT(VARCHAR,CONVERT(NUMERIC(8,2),SUM(CASE WHEN Since BETWEEN 241 AND 270 THEN qty_recd END),2)),'') AS [241-270] ," & _
               "ISNULL(CONVERT(VARCHAR,CONVERT(NUMERIC(8,2),SUM(CASE WHEN Since BETWEEN 271 AND 300 THEN qty_recd END),2)),'') AS [271-300] ," & _
               "ISNULL(CONVERT(VARCHAR,CONVERT(NUMERIC(8,2),SUM(CASE WHEN Since BETWEEN 301 AND 330 THEN qty_recd END),2)),'') AS [301-330] ," & _
               "ISNULL(CONVERT(VARCHAR,CONVERT(NUMERIC(8,2),SUM(CASE WHEN Since BETWEEN 331 AND 365 THEN qty_recd END),2)),'') AS [331-365]," & _
               "ISNULL(CONVERT(VARCHAR,CONVERT(NUMERIC(8,2),SUM(CASE WHEN Since > 365 THEN qty_recd END),2)),'') AS [>365]" & _
               "FROM      ( SELECT UPPER(CASE WHEN  ISNULL(CUSTOMERNAME,'') = '' THEN 'UNMAPPED' ELSE CUSTOMERNAME END) AS CUSTOMERNAME ,stock_no ,order_no ,variant_no ,DATEDIFF(day, recd_date, GETDATE()) Since ,qty_recd FROM      JCT_Pack_Stock_UptoDate_MIS" & _
               " ) AS Sinc GROUP BY  CUSTOMERNAME, stock_no ,order_no ORDER BY CUSTOMERNAME  ,order_no,stock_no "




        ElseIf RadioButtonList1.SelectedValue = "SALEPERSON WISE AGEING" Then

            SqlPass = "SELECT    SalePerson ," & _
               "ISNULL(CONVERT(VARCHAR,CONVERT(NUMERIC(8,2),SUM(CASE WHEN Since BETWEEN 0 AND 30   THEN  qty_recd END))),'') AS [0-30] , " & _
               "ISNULL(CONVERT(VARCHAR,CONVERT(NUMERIC(8,2),SUM(CASE WHEN Since BETWEEN 31 AND 60  THEN  qty_recd END))),'') AS [31-60] , " & _
               "ISNULL(CONVERT(VARCHAR,CONVERT(NUMERIC(8,2),SUM(CASE WHEN Since BETWEEN 61 AND 90  THEN  qty_recd END))),'') AS [61-90] , " & _
               "ISNULL(CONVERT(VARCHAR,CONVERT(NUMERIC(8,2),SUM(CASE WHEN Since BETWEEN 91 AND 120 THEN  qty_recd END))),'') AS [91-120] ," & _
               "ISNULL(CONVERT(VARCHAR,CONVERT(NUMERIC(8,2),SUM(CASE WHEN Since BETWEEN 121 AND 150 THEN qty_recd END),2)),'') AS [121-150] ," & _
               "ISNULL(CONVERT(VARCHAR,CONVERT(NUMERIC(8,2),SUM(CASE WHEN Since BETWEEN 151 AND 180 THEN qty_recd END),2)),'') AS [151-180] ," & _
               "ISNULL(CONVERT(VARCHAR,CONVERT(NUMERIC(8,2),SUM(CASE WHEN Since BETWEEN 181 AND 210 THEN qty_recd END),2)),'') AS [181-210] ," & _
               "ISNULL(CONVERT(VARCHAR,CONVERT(NUMERIC(8,2),SUM(CASE WHEN Since BETWEEN 211 AND 240 THEN qty_recd END),2)),'') AS [211-240] ," & _
               "ISNULL(CONVERT(VARCHAR,CONVERT(NUMERIC(8,2),SUM(CASE WHEN Since BETWEEN 241 AND 270 THEN qty_recd END),2)),'') AS [241-270] ," & _
               "ISNULL(CONVERT(VARCHAR,CONVERT(NUMERIC(8,2),SUM(CASE WHEN Since BETWEEN 271 AND 300 THEN qty_recd END),2)),'') AS [271-300] ," & _
               "ISNULL(CONVERT(VARCHAR,CONVERT(NUMERIC(8,2),SUM(CASE WHEN Since BETWEEN 301 AND 330 THEN qty_recd END),2)),'') AS [301-330] ," & _
               "ISNULL(CONVERT(VARCHAR,CONVERT(NUMERIC(8,2),SUM(CASE WHEN Since BETWEEN 331 AND 365 THEN qty_recd END),2)),'') AS [331-365]," & _
               "ISNULL(CONVERT(VARCHAR,CONVERT(NUMERIC(8,2),SUM(CASE WHEN Since > 365 THEN qty_recd END),2)),'') AS [>365]" & _
               "FROM      ( SELECT UPPER(CASE WHEN  SalePerson = '' THEN 'UNMAPPED' ELSE SalePerson END) AS SalePerson ,stock_no ,variant_no ,DATEDIFF(day, recd_date, GETDATE()) Since ,qty_recd FROM      JCT_Pack_Stock_UptoDate_MIS" & _
               " ) AS Sinc WHERE SalePerson IS NOT NULL GROUP BY  SalePerson " & _
               " UNION  SELECT '[TOTAL]', CONVERT(VARCHAR,SUM(CASE WHEN  DATEDIFF(day, recd_date, GETDATE()) BETWEEN 0 AND 30 THEN CONVERT(NUMERIC(10,2),ISNULL(qty_recd,0)) END ) )," & _
" CONVERT(VARCHAR,SUM(CASE WHEN  DATEDIFF(day, recd_date, GETDATE())   BETWEEN 31 AND 60 THEN CONVERT(NUMERIC(10,2),ISNULL(qty_recd,0)) END ))   ," & _
" CONVERT(VARCHAR,SUM(CASE WHEN  DATEDIFF(day, recd_date, GETDATE()) BETWEEN 61 AND 90 THEN CONVERT(NUMERIC(10,2),ISNULL(qty_recd,0)) END ))  , " & _
"CONVERT(VARCHAR,SUM(CASE WHEN  DATEDIFF(day, recd_date, GETDATE()) BETWEEN 91 AND 120 THEN CONVERT(NUMERIC(10,2),ISNULL(qty_recd,0)) END ) ) , " & _
"CONVERT(VARCHAR,SUM(CASE WHEN  DATEDIFF(day, recd_date, GETDATE()) BETWEEN 121 AND 150 THEN CONVERT(NUMERIC(10,2),ISNULL(qty_recd,0)) END ))  , " & _
"CONVERT(VARCHAR,SUM(CASE WHEN  DATEDIFF(day, recd_date, GETDATE()) BETWEEN 151 AND 180 THEN CONVERT(NUMERIC(10,2),ISNULL(qty_recd,0)) END )) ,  " & _
"CONVERT(VARCHAR,SUM(CASE WHEN  DATEDIFF(day, recd_date, GETDATE()) BETWEEN 181 AND 210 THEN CONVERT(NUMERIC(10,2),ISNULL(qty_recd,0)) END )),   " & _
"CONVERT(VARCHAR,SUM(CASE WHEN  DATEDIFF(day, recd_date, GETDATE()) BETWEEN 211 AND 240 THEN CONVERT(NUMERIC(10,2),ISNULL(qty_recd,0)) END) ), " & _
"CONVERT(VARCHAR,SUM(CASE WHEN  DATEDIFF(day, recd_date, GETDATE()) BETWEEN 241 AND 270 THEN CONVERT(NUMERIC(10,2),ISNULL(qty_recd,0)) END) ),   " & _
"CONVERT(VARCHAR,SUM(CASE WHEN  DATEDIFF(day, recd_date, GETDATE()) BETWEEN 271 AND 300 THEN CONVERT(NUMERIC(10,2),ISNULL(qty_recd,0)) END) ) ,  " & _
"CONVERT(VARCHAR,SUM(CASE WHEN  DATEDIFF(day, recd_date, GETDATE()) BETWEEN 301 AND 330 THEN CONVERT(NUMERIC(10,2),ISNULL(qty_recd,0)) END) ) ,  " & _
"CONVERT(VARCHAR,SUM(CASE WHEN  DATEDIFF(day, recd_date, GETDATE()) BETWEEN 331 AND 365 THEN CONVERT(NUMERIC(10,2),ISNULL(qty_recd,0)) END )) ,  " & _
"CONVERT(VARCHAR,SUM(CASE WHEN  DATEDIFF(day, recd_date, GETDATE())   > 365 THEN CONVERT(NUMERIC(10,2),ISNULL(qty_recd,0)) END ))  " & _
 "FROM      JCT_Pack_Stock_UptoDate_MIS  ORDER BY SalePerson   "


        ElseIf RadioButtonList1.SelectedValue = "ORDER WISE AGEING" Then

            SqlPass = "SELECT    Order_no AS OrderNo," & _
              "ISNULL(CONVERT(VARCHAR,CONVERT(NUMERIC(8,2),SUM(CASE WHEN Since BETWEEN 0 AND 30   THEN  qty_recd END))),'') AS [0-30] , " & _
              "ISNULL(CONVERT(VARCHAR,CONVERT(NUMERIC(8,2),SUM(CASE WHEN Since BETWEEN 31 AND 60  THEN  qty_recd END))),'') AS [31-60] , " & _
              "ISNULL(CONVERT(VARCHAR,CONVERT(NUMERIC(8,2),SUM(CASE WHEN Since BETWEEN 61 AND 90  THEN  qty_recd END))),'') AS [61-90] , " & _
              "ISNULL(CONVERT(VARCHAR,CONVERT(NUMERIC(8,2),SUM(CASE WHEN Since BETWEEN 91 AND 120 THEN  qty_recd END))),'') AS [91-120] ," & _
              "ISNULL(CONVERT(VARCHAR,CONVERT(NUMERIC(8,2),SUM(CASE WHEN Since BETWEEN 121 AND 150 THEN qty_recd END),2)),'') AS [121-150] ," & _
              "ISNULL(CONVERT(VARCHAR,CONVERT(NUMERIC(8,2),SUM(CASE WHEN Since BETWEEN 151 AND 180 THEN qty_recd END),2)),'') AS [151-180] ," & _
              "ISNULL(CONVERT(VARCHAR,CONVERT(NUMERIC(8,2),SUM(CASE WHEN Since BETWEEN 181 AND 210 THEN qty_recd END),2)),'') AS [181-210] ," & _
              "ISNULL(CONVERT(VARCHAR,CONVERT(NUMERIC(8,2),SUM(CASE WHEN Since BETWEEN 211 AND 240 THEN qty_recd END),2)),'') AS [211-240] ," & _
              "ISNULL(CONVERT(VARCHAR,CONVERT(NUMERIC(8,2),SUM(CASE WHEN Since BETWEEN 241 AND 270 THEN qty_recd END),2)),'') AS [241-270] ," & _
              "ISNULL(CONVERT(VARCHAR,CONVERT(NUMERIC(8,2),SUM(CASE WHEN Since BETWEEN 271 AND 300 THEN qty_recd END),2)),'') AS [271-300] ," & _
              "ISNULL(CONVERT(VARCHAR,CONVERT(NUMERIC(8,2),SUM(CASE WHEN Since BETWEEN 301 AND 330 THEN qty_recd END),2)),'') AS [301-330] ," & _
              "ISNULL(CONVERT(VARCHAR,CONVERT(NUMERIC(8,2),SUM(CASE WHEN Since BETWEEN 331 AND 365 THEN qty_recd END),2)),'') AS [331-365]," & _
              "ISNULL(CONVERT(VARCHAR,CONVERT(NUMERIC(8,2),SUM(CASE WHEN Since > 365 THEN qty_recd END),2)),'') AS [>365]" & _
              "FROM      ( SELECT Order_no ,stock_no ,variant_no ,DATEDIFF(day, recd_date, GETDATE()) Since ,qty_recd FROM      JCT_Pack_Stock_UptoDate_MIS" & _
              " ) AS Sinc GROUP BY  Order_no ORDER BY Order_no   "


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

  