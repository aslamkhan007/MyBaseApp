﻿
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
        grdStage.MasterTableView.GridLines = GridLines.Both
        grdStage.ExportSettings.IgnorePaging = True
        grdStage.ExportSettings.OpenInNewWindow = True
        grdStage.MasterTableView.ExportToExcel()

    End Sub



    Protected Sub lnkFetch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkFetch.Click
        ItemGroup()

    End Sub

 
    Protected Sub ItemGroup()

        If RadioButtonList1.SelectedValue = "ALL" Then
            SqlPass = "SELECT    item_group_no AS ItemGroup ,LOT_NO AS LotNo, DATEDIFF(dd,recd_date,GETDATE()) AS Ageing,Wh_no AS Godown, ISNULL(Shade,'') AS Shade ,stock_no AS SortNo ,variant_no AS Variant , ISNULL(CONVERT(VARCHAR,CONVERT(REAL,(qty_recd ))),'') AS Qty ,   REPLACE(CONVERT(VARCHAR(11), recd_date, 106), ' ', '-')   AS PackedDate , SalePerson AS SalePerson , CustomerCode AS CustomerCode , UPPER(order_no) AS SaleOrderNo ,ISNULL(CustomerName, '') AS CustomerName , ISNULL(CONVERT(varchar,OrderDate,103),'')  AS OrderDate   FROM       JCT_Pack_Stock_UptoDate_MIS ORDER BY item_group_no,Stock_no"

        ElseIf RadioButtonList1.SelectedValue = "ITEM GROUP WISE" Then
            SqlPass = "SELECT  item_group_no AS ItemGroup, stock_no AS SortNo ,variant_no AS Variant,ISNULL(CONVERT(VARCHAR, CONVERT(NUMERIC(8, 2), SUM(qty_recd))),'') AS Qty   FROM    JCT_Pack_Stock_UptoDate_MIS  GROUP BY item_group_no , stock_no , variant_no    ORDER BY item_group_no , stock_no , variant_no"

        ElseIf RadioButtonList1.SelectedValue = "ITEM GROUP WISE AGEING" Then

            SqlPass = "SELECT    item_group_no AS ItemGroup ," & _
                "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 0 AND 30   THEN  qty_recd END))),'') AS [0-30] , " & _
                "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 31 AND 60  THEN  qty_recd END))),'') AS [31-60] , " & _
                "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 61 AND 90  THEN  qty_recd END))),'') AS [61-90] , " & _
                "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 91 AND 120 THEN  qty_recd END))),'') AS [91-120] ," & _
                "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 121 AND 150 THEN qty_recd END),2)),'') AS [121-150] ," & _
                "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 151 AND 180 THEN qty_recd END),2)),'') AS [151-180] ," & _
                "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 181 AND 210 THEN qty_recd END),2)),'') AS [181-210] ," & _
                "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 211 AND 240 THEN qty_recd END),2)),'') AS [211-240] ," & _
                "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 241 AND 270 THEN qty_recd END),2)),'') AS [241-270] ," & _
                "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 271 AND 300 THEN qty_recd END),2)),'') AS [271-300] ," & _
                "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 301 AND 330 THEN qty_recd END),2)),'') AS [301-330] ," & _
                "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 331 AND 365 THEN qty_recd END),2)),'') AS [331-365]," & _
                 "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since > 365 THEN qty_recd END),2)),'') AS [>365]" & _
                "FROM      ( SELECT item_group_no ,stock_no ,variant_no ,DATEDIFF(day, recd_date, GETDATE()) Since ,qty_recd FROM      JCT_Pack_Stock_UptoDate_MIS" & _
                " ) AS Sinc GROUP BY  item_group_no ORDER BY item_group_no   "


        ElseIf RadioButtonList1.SelectedValue = "CUSTOMER WISE AGEING" Then

            SqlPass = "SELECT    CUSTOMERNAME ," & _
               "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 0 AND 30   THEN  qty_recd END))),'') AS [0-30] , " & _
               "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 31 AND 60  THEN  qty_recd END))),'') AS [31-60] , " & _
               "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 61 AND 90  THEN  qty_recd END))),'') AS [61-90] , " & _
               "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 91 AND 120 THEN  qty_recd END))),'') AS [91-120] ," & _
               "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 121 AND 150 THEN qty_recd END),2)),'') AS [121-150] ," & _
               "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 151 AND 180 THEN qty_recd END),2)),'') AS [151-180] ," & _
               "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 181 AND 210 THEN qty_recd END),2)),'') AS [181-210] ," & _
               "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 211 AND 240 THEN qty_recd END),2)),'') AS [211-240] ," & _
               "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 241 AND 270 THEN qty_recd END),2)),'') AS [241-270] ," & _
               "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 271 AND 300 THEN qty_recd END),2)),'') AS [271-300] ," & _
               "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 301 AND 330 THEN qty_recd END),2)),'') AS [301-330] ," & _
               "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 331 AND 365 THEN qty_recd END),2)),'') AS [331-365]," & _
               "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since > 365 THEN qty_recd END),2)),'') AS [>365]" & _
               "FROM      ( SELECT UPPER(CASE WHEN  ISNULL(CUSTOMERNAME,'') = '' THEN 'UNMAPPED' ELSE CUSTOMERNAME END) AS CUSTOMERNAME ,stock_no ,variant_no ,DATEDIFF(day, recd_date, GETDATE()) Since ,qty_recd FROM      JCT_Pack_Stock_UptoDate_MIS" & _
               " ) AS Sinc GROUP BY  CUSTOMERNAME ORDER BY CUSTOMERNAME   "


        ElseIf RadioButtonList1.SelectedValue = "CUSTOMER WISE AGEING +" Then

            SqlPass = "SELECT    CUSTOMERNAME ,stock_no AS SortNo, order_no as OrderNo, " & _
               "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 0 AND 30   THEN  qty_recd END))),'') AS [0-30] , " & _
               "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 31 AND 60  THEN  qty_recd END))),'') AS [31-60] , " & _
               "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 61 AND 90  THEN  qty_recd END))),'') AS [61-90] , " & _
               "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 91 AND 120 THEN  qty_recd END))),'') AS [91-120] ," & _
               "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 121 AND 150 THEN qty_recd END),2)),'') AS [121-150] ," & _
               "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 151 AND 180 THEN qty_recd END),2)),'') AS [151-180] ," & _
               "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 181 AND 210 THEN qty_recd END),2)),'') AS [181-210] ," & _
               "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 211 AND 240 THEN qty_recd END),2)),'') AS [211-240] ," & _
               "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 241 AND 270 THEN qty_recd END),2)),'') AS [241-270] ," & _
               "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 271 AND 300 THEN qty_recd END),2)),'') AS [271-300] ," & _
               "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 301 AND 330 THEN qty_recd END),2)),'') AS [301-330] ," & _
               "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 331 AND 365 THEN qty_recd END),2)),'') AS [331-365]," & _
               "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since > 365 THEN qty_recd END),2)),'') AS [>365]" & _
               "FROM      ( SELECT UPPER(CASE WHEN  ISNULL(CUSTOMERNAME,'') = '' THEN 'UNMAPPED' ELSE CUSTOMERNAME END) AS CUSTOMERNAME ,stock_no ,order_no ,variant_no ,DATEDIFF(day, recd_date, GETDATE()) Since ,qty_recd FROM      JCT_Pack_Stock_UptoDate_MIS" & _
               " ) AS Sinc GROUP BY  CUSTOMERNAME, stock_no ,order_no ORDER BY CUSTOMERNAME  ,order_no,stock_no "




        ElseIf RadioButtonList1.SelectedValue = "SALEPERSON WISE AGEING" Then



            SqlPass = "SELECT  SUBSTRING(Segment,3, 10 ) as SEGMENT, Type ,SalePerson , CONVERT(REAL,[0-30]) as '0' , CONVERT(REAL,[31-60]) AS [31-60] , CONVERT(REAL,[61-90] ) AS [61-90] ,  CONVERT(REAL,[91-120] ) AS [91-120] , CONVERT(REAL,[121-150] ) AS [121-150] , CONVERT(REAL, [151-180]) AS [151-180] , CONVERT(REAL,[181-210] ) AS [181-210] ,  CONVERT(REAL,[211-240]) AS [211-240] ,  CONVERT(REAL, [241-270] ) AS [241-270] ,      CONVERT(REAL,[271-300] ) AS [271-300] ,     CONVERT(REAL, [301-330]) AS [301-330] ,      CONVERT(REAL, [331-365]) AS [331-365] ,     CONVERT(REAL, [>365]) AS [>365] , Total FROM    PackedStockAgeing WHERE   SalePerson IS NOT NULL ORDER BY Segment ,SalePerson"




        ElseIf RadioButtonList1.SelectedValue = "ORDER WISE AGEING" Then

            SqlPass = "SELECT    Order_no AS OrderNo," & _
              "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 0 AND 30   THEN  qty_recd END))),'') AS [0-30] , " & _
              "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 31 AND 60  THEN  qty_recd END))),'') AS [31-60] , " & _
              "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 61 AND 90  THEN  qty_recd END))),'') AS [61-90] , " & _
              "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 91 AND 120 THEN  qty_recd END))),'') AS [91-120] ," & _
              "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 121 AND 150 THEN qty_recd END),2)),'') AS [121-150] ," & _
              "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 151 AND 180 THEN qty_recd END),2)),'') AS [151-180] ," & _
              "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 181 AND 210 THEN qty_recd END),2)),'') AS [181-210] ," & _
              "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 211 AND 240 THEN qty_recd END),2)),'') AS [211-240] ," & _
              "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 241 AND 270 THEN qty_recd END),2)),'') AS [241-270] ," & _
              "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 271 AND 300 THEN qty_recd END),2)),'') AS [271-300] ," & _
              "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 301 AND 330 THEN qty_recd END),2)),'') AS [301-330] ," & _
              "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 331 AND 365 THEN qty_recd END),2)),'') AS [331-365]," & _
              "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since > 365 THEN qty_recd END),2)),'') AS [>365]" & _
              "FROM      ( SELECT Order_no ,stock_no ,variant_no ,DATEDIFF(day, recd_date, GETDATE()) Since ,qty_recd FROM      JCT_Pack_Stock_UptoDate_MIS" & _
              " ) AS Sinc GROUP BY  Order_no ORDER BY Order_no   "

        ElseIf RadioButtonList1.SelectedValue = "GODOWNWISE+" Then

            SqlPass = "SELECT    Wh_no AS GodownNo,stock_no AS Sort,variant_no AS Variant ," & _
              "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 0 AND 30   THEN  qty_recd END))),'') AS [0-30] , " & _
              "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 31 AND 60  THEN  qty_recd END))),'') AS [31-60] , " & _
              "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 61 AND 90  THEN  qty_recd END))),'') AS [61-90] , " & _
              "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 91 AND 120 THEN  qty_recd END))),'') AS [91-120] ," & _
              "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 121 AND 150 THEN qty_recd END),2)),'') AS [121-150] ," & _
              "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 151 AND 180 THEN qty_recd END),2)),'') AS [151-180] ," & _
              "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 181 AND 210 THEN qty_recd END),2)),'') AS [181-210] ," & _
              "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 211 AND 240 THEN qty_recd END),2)),'') AS [211-240] ," & _
              "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 241 AND 270 THEN qty_recd END),2)),'') AS [241-270] ," & _
              "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 271 AND 300 THEN qty_recd END),2)),'') AS [271-300] ," & _
              "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 301 AND 330 THEN qty_recd END),2)),'') AS [301-330] ," & _
              "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 331 AND 365 THEN qty_recd END),2)),'') AS [331-365]," & _
              "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since > 365 THEN qty_recd END),2)),'') AS [>365]" & _
              "FROM      ( SELECT Wh_no,Order_no ,stock_no ,variant_no ,DATEDIFF(day, recd_date, GETDATE()) Since ,qty_recd FROM      JCT_Pack_Stock_UptoDate_MIS" & _
              " ) AS Sinc GROUP BY  Wh_no , variant_no,stock_no ORDER BY Wh_no,stock_no,variant_no   "

        ElseIf RadioButtonList1.SelectedValue = "GODOWNWISE" Then

            SqlPass = "SELECT    Wh_no AS GodownNo ,variant_no AS Variant," & _
              "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 0 AND 30   THEN  qty_recd END))),'') AS [0-30] , " & _
              "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 31 AND 60  THEN  qty_recd END))),'') AS [31-60] , " & _
              "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 61 AND 90  THEN  qty_recd END))),'') AS [61-90] , " & _
              "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 91 AND 120 THEN  qty_recd END))),'') AS [91-120] ," & _
              "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 121 AND 150 THEN qty_recd END),2)),'') AS [121-150] ," & _
              "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 151 AND 180 THEN qty_recd END),2)),'') AS [151-180] ," & _
              "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 181 AND 210 THEN qty_recd END),2)),'') AS [181-210] ," & _
              "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 211 AND 240 THEN qty_recd END),2)),'') AS [211-240] ," & _
              "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 241 AND 270 THEN qty_recd END),2)),'') AS [241-270] ," & _
              "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 271 AND 300 THEN qty_recd END),2)),'') AS [271-300] ," & _
              "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 301 AND 330 THEN qty_recd END),2)),'') AS [301-330] ," & _
              "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 331 AND 365 THEN qty_recd END),2)),'') AS [331-365]," & _
              "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since > 365 THEN qty_recd END),2)),'') AS [>365]" & _
              "FROM      ( SELECT Wh_no,Order_no ,stock_no ,variant_no ,DATEDIFF(day, recd_date, GETDATE()) Since ,qty_recd FROM      JCT_Pack_Stock_UptoDate_MIS" & _
              " ) AS Sinc GROUP BY  Wh_no , variant_no  ORDER BY Wh_no,variant_no   "

        End If



        If SqlPass <> "" Then
            BindGrid(SqlPass)
        End If
    End Sub


    Protected Sub CallToBind()
        If RadioButtonList1.SelectedValue = "ALL" Then
            SqlPass = "SELECT    item_group_no AS ItemGroup ,LOT_NO AS LotNo, DATEDIFF(dd,recd_date,GETDATE()) AS Ageing,Wh_no AS Godown, ISNULL(Shade,'') AS Shade ,stock_no AS SortNo ,variant_no AS Variant , ISNULL(CONVERT(VARCHAR,CONVERT(REAL,(qty_recd ))),'') AS Qty ,   REPLACE(CONVERT(VARCHAR(11), recd_date, 106), ' ', '-')   AS PackedDate , SalePerson AS SalePerson , CustomerCode AS CustomerCode , UPPER(order_no) AS SaleOrderNo ,ISNULL(CustomerName, '') AS CustomerName , ISNULL(CONVERT(varchar,OrderDate,103),'')  AS OrderDate   FROM       JCT_Pack_Stock_UptoDate_MIS ORDER BY item_group_no,Stock_no"

        ElseIf RadioButtonList1.SelectedValue = "ITEM GROUP WISE" Then
            SqlPass = "SELECT  item_group_no AS ItemGroup, stock_no AS SortNo ,variant_no AS Variant,ISNULL(CONVERT(VARCHAR, CONVERT(NUMERIC(8, 2), SUM(qty_recd))),'') AS Qty   FROM    JCT_Pack_Stock_UptoDate_MIS  GROUP BY item_group_no , stock_no , variant_no    ORDER BY item_group_no , stock_no , variant_no"

        ElseIf RadioButtonList1.SelectedValue = "ITEM GROUP WISE AGEING" Then

            SqlPass = "SELECT    item_group_no AS ItemGroup ," & _
                "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 0 AND 30   THEN  qty_recd END))),'') AS [0-30] , " & _
                "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 31 AND 60  THEN  qty_recd END))),'') AS [31-60] , " & _
                "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 61 AND 90  THEN  qty_recd END))),'') AS [61-90] , " & _
                "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 91 AND 120 THEN  qty_recd END))),'') AS [91-120] ," & _
                "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 121 AND 150 THEN qty_recd END),2)),'') AS [121-150] ," & _
                "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 151 AND 180 THEN qty_recd END),2)),'') AS [151-180] ," & _
                "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 181 AND 210 THEN qty_recd END),2)),'') AS [181-210] ," & _
                "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 211 AND 240 THEN qty_recd END),2)),'') AS [211-240] ," & _
                "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 241 AND 270 THEN qty_recd END),2)),'') AS [241-270] ," & _
                "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 271 AND 300 THEN qty_recd END),2)),'') AS [271-300] ," & _
                "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 301 AND 330 THEN qty_recd END),2)),'') AS [301-330] ," & _
                "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 331 AND 365 THEN qty_recd END),2)),'') AS [331-365]," & _
                 "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since > 365 THEN qty_recd END),2)),'') AS [>365]" & _
                "FROM      ( SELECT item_group_no ,stock_no ,variant_no ,DATEDIFF(day, recd_date, GETDATE()) Since ,qty_recd FROM      JCT_Pack_Stock_UptoDate_MIS" & _
                " ) AS Sinc GROUP BY  item_group_no ORDER BY item_group_no   "


        ElseIf RadioButtonList1.SelectedValue = "CUSTOMER WISE AGEING" Then

            SqlPass = "SELECT    CUSTOMERNAME ," & _
               "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 0 AND 30   THEN  qty_recd END))),'') AS [0-30] , " & _
               "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 31 AND 60  THEN  qty_recd END))),'') AS [31-60] , " & _
               "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 61 AND 90  THEN  qty_recd END))),'') AS [61-90] , " & _
               "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 91 AND 120 THEN  qty_recd END))),'') AS [91-120] ," & _
               "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 121 AND 150 THEN qty_recd END),2)),'') AS [121-150] ," & _
               "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 151 AND 180 THEN qty_recd END),2)),'') AS [151-180] ," & _
               "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 181 AND 210 THEN qty_recd END),2)),'') AS [181-210] ," & _
               "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 211 AND 240 THEN qty_recd END),2)),'') AS [211-240] ," & _
               "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 241 AND 270 THEN qty_recd END),2)),'') AS [241-270] ," & _
               "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 271 AND 300 THEN qty_recd END),2)),'') AS [271-300] ," & _
               "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 301 AND 330 THEN qty_recd END),2)),'') AS [301-330] ," & _
               "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 331 AND 365 THEN qty_recd END),2)),'') AS [331-365]," & _
               "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since > 365 THEN qty_recd END),2)),'') AS [>365]" & _
               "FROM      ( SELECT UPPER(CASE WHEN  ISNULL(CUSTOMERNAME,'') = '' THEN 'UNMAPPED' ELSE CUSTOMERNAME END) AS CUSTOMERNAME ,stock_no ,variant_no ,DATEDIFF(day, recd_date, GETDATE()) Since ,qty_recd FROM      JCT_Pack_Stock_UptoDate_MIS" & _
               " ) AS Sinc GROUP BY  CUSTOMERNAME ORDER BY CUSTOMERNAME   "


        ElseIf RadioButtonList1.SelectedValue = "CUSTOMER WISE AGEING +" Then

            SqlPass = "SELECT    CUSTOMERNAME ,stock_no AS SortNo, order_no as OrderNo, " & _
               "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 0 AND 30   THEN  qty_recd END))),'') AS [0-30] , " & _
               "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 31 AND 60  THEN  qty_recd END))),'') AS [31-60] , " & _
               "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 61 AND 90  THEN  qty_recd END))),'') AS [61-90] , " & _
               "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 91 AND 120 THEN  qty_recd END))),'') AS [91-120] ," & _
               "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 121 AND 150 THEN qty_recd END),2)),'') AS [121-150] ," & _
               "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 151 AND 180 THEN qty_recd END),2)),'') AS [151-180] ," & _
               "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 181 AND 210 THEN qty_recd END),2)),'') AS [181-210] ," & _
               "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 211 AND 240 THEN qty_recd END),2)),'') AS [211-240] ," & _
               "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 241 AND 270 THEN qty_recd END),2)),'') AS [241-270] ," & _
               "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 271 AND 300 THEN qty_recd END),2)),'') AS [271-300] ," & _
               "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 301 AND 330 THEN qty_recd END),2)),'') AS [301-330] ," & _
               "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 331 AND 365 THEN qty_recd END),2)),'') AS [331-365]," & _
               "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since > 365 THEN qty_recd END),2)),'') AS [>365]" & _
               "FROM      ( SELECT UPPER(CASE WHEN  ISNULL(CUSTOMERNAME,'') = '' THEN 'UNMAPPED' ELSE CUSTOMERNAME END) AS CUSTOMERNAME ,stock_no ,order_no ,variant_no ,DATEDIFF(day, recd_date, GETDATE()) Since ,qty_recd FROM      JCT_Pack_Stock_UptoDate_MIS" & _
               " ) AS Sinc GROUP BY  CUSTOMERNAME, stock_no ,order_no ORDER BY CUSTOMERNAME  ,order_no,stock_no "




        ElseIf RadioButtonList1.SelectedValue = "SALEPERSON WISE AGEING" Then



            SqlPass = "SELECT  SUBSTRING(Segment,3, 10 ) as SEGMENT, Type ,SalePerson , CONVERT(REAL,[0-30]) as '0' , CONVERT(REAL,[31-60]) AS [31-60] , CONVERT(REAL,[61-90] ) AS [61-90] ,  CONVERT(REAL,[91-120] ) AS [91-120] , CONVERT(REAL,[121-150] ) AS [121-150] , CONVERT(REAL, [151-180]) AS [151-180] , CONVERT(REAL,[181-210] ) AS [181-210] ,  CONVERT(REAL,[211-240]) AS [211-240] ,  CONVERT(REAL, [241-270] ) AS [241-270] ,      CONVERT(REAL,[271-300] ) AS [271-300] ,     CONVERT(REAL, [301-330]) AS [301-330] ,      CONVERT(REAL, [331-365]) AS [331-365] ,     CONVERT(REAL, [>365]) AS [>365] , Total FROM    PackedStockAgeing WHERE   SalePerson IS NOT NULL ORDER BY Segment ,SalePerson"




        ElseIf RadioButtonList1.SelectedValue = "ORDER WISE AGEING" Then

            SqlPass = "SELECT    Order_no AS OrderNo," & _
              "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 0 AND 30   THEN  qty_recd END))),'') AS [0-30] , " & _
              "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 31 AND 60  THEN  qty_recd END))),'') AS [31-60] , " & _
              "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 61 AND 90  THEN  qty_recd END))),'') AS [61-90] , " & _
              "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 91 AND 120 THEN  qty_recd END))),'') AS [91-120] ," & _
              "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 121 AND 150 THEN qty_recd END),2)),'') AS [121-150] ," & _
              "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 151 AND 180 THEN qty_recd END),2)),'') AS [151-180] ," & _
              "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 181 AND 210 THEN qty_recd END),2)),'') AS [181-210] ," & _
              "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 211 AND 240 THEN qty_recd END),2)),'') AS [211-240] ," & _
              "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 241 AND 270 THEN qty_recd END),2)),'') AS [241-270] ," & _
              "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 271 AND 300 THEN qty_recd END),2)),'') AS [271-300] ," & _
              "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 301 AND 330 THEN qty_recd END),2)),'') AS [301-330] ," & _
              "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 331 AND 365 THEN qty_recd END),2)),'') AS [331-365]," & _
              "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since > 365 THEN qty_recd END),2)),'') AS [>365]" & _
              "FROM      ( SELECT Order_no ,stock_no ,variant_no ,DATEDIFF(day, recd_date, GETDATE()) Since ,qty_recd FROM      JCT_Pack_Stock_UptoDate_MIS" & _
              " ) AS Sinc GROUP BY  Order_no ORDER BY Order_no   "

        ElseIf RadioButtonList1.SelectedValue = "GODOWNWISE+" Then

            SqlPass = "SELECT    Wh_no AS GodownNo,stock_no AS SortNo,variant_no AS Variant, " & _
              "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 0 AND 30   THEN  qty_recd END))),'') AS [0-30] , " & _
              "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 31 AND 60  THEN  qty_recd END))),'') AS [31-60] , " & _
              "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 61 AND 90  THEN  qty_recd END))),'') AS [61-90] , " & _
              "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 91 AND 120 THEN  qty_recd END))),'') AS [91-120] ," & _
              "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 121 AND 150 THEN qty_recd END),2)),'') AS [121-150] ," & _
              "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 151 AND 180 THEN qty_recd END),2)),'') AS [151-180] ," & _
              "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 181 AND 210 THEN qty_recd END),2)),'') AS [181-210] ," & _
              "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 211 AND 240 THEN qty_recd END),2)),'') AS [211-240] ," & _
              "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 241 AND 270 THEN qty_recd END),2)),'') AS [241-270] ," & _
              "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 271 AND 300 THEN qty_recd END),2)),'') AS [271-300] ," & _
              "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 301 AND 330 THEN qty_recd END),2)),'') AS [301-330] ," & _
              "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 331 AND 365 THEN qty_recd END),2)),'') AS [331-365]," & _
              "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since > 365 THEN qty_recd END),2)),'') AS [>365]" & _
              "FROM      ( SELECT Wh_no,Order_no ,stock_no ,variant_no ,DATEDIFF(day, recd_date, GETDATE()) Since ,qty_recd FROM      JCT_Pack_Stock_UptoDate_MIS" & _
              " ) AS Sinc GROUP BY  Wh_no ,stock_no, variant_no ORDER BY Wh_no,stock_no,variant_no   "

        ElseIf RadioButtonList1.SelectedValue = "GODOWNWISE" Then

            SqlPass = "SELECT    Wh_no AS GodownNo ,variant_no AS Variant," & _
              "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 0 AND 30   THEN  qty_recd END))),'') AS [0-30] , " & _
              "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 31 AND 60  THEN  qty_recd END))),'') AS [31-60] , " & _
              "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 61 AND 90  THEN  qty_recd END))),'') AS [61-90] , " & _
              "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 91 AND 120 THEN  qty_recd END))),'') AS [91-120] ," & _
              "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 121 AND 150 THEN qty_recd END),2)),'') AS [121-150] ," & _
              "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 151 AND 180 THEN qty_recd END),2)),'') AS [151-180] ," & _
              "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 181 AND 210 THEN qty_recd END),2)),'') AS [181-210] ," & _
              "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 211 AND 240 THEN qty_recd END),2)),'') AS [211-240] ," & _
              "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 241 AND 270 THEN qty_recd END),2)),'') AS [241-270] ," & _
              "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 271 AND 300 THEN qty_recd END),2)),'') AS [271-300] ," & _
              "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 301 AND 330 THEN qty_recd END),2)),'') AS [301-330] ," & _
              "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since BETWEEN 331 AND 365 THEN qty_recd END),2)),'') AS [331-365]," & _
              "ISNULL(CONVERT(VARCHAR,CONVERT(REAL,SUM(CASE WHEN Since > 365 THEN qty_recd END),2)),'') AS [>365]" & _
              "FROM      ( SELECT Wh_no,Order_no ,stock_no ,variant_no ,DATEDIFF(day, recd_date, GETDATE()) Since ,qty_recd FROM      JCT_Pack_Stock_UptoDate_MIS" & _
              " ) AS Sinc GROUP BY  Wh_no , variant_no  ORDER BY Wh_no,variant_no   "

        End If

        If SqlPass <> "" Then
            Dim Dr As SqlDataReader = Obj.FetchReader(SqlPass)
            Dim Da As SqlDataAdapter = New SqlDataAdapter(SqlPass, Obj.Connection())

            Try
                If Dr.HasRows = True Then
                    Dr.Close()
                    Dim ds As DataSet = New DataSet()
                    ds.Clear()
                    Da.Fill(ds)

                    grdStage.DataSource = ds
                    Dr.Close()

                End If
            Catch ex As Exception
                ClientScript.RegisterClientScriptBlock(GetType(Page), "scr", "<script language = javascript>alert('" & ex.Message & "!!')</script>")
            Finally
                Obj.ConClose()
            End Try

        End If

     

    End Sub



 
End Class

  