Imports System
Imports System.Collections.Generic
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Data
Imports System.IO
Imports System.Text
Imports System.Data.SqlClient

Imports System.IO.StreamWriter
Imports Telerik.Web.UI

Partial Class AssortedUnAssortedPivot
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


        If Not IsPostBack Then



            rdpFrom.SelectedDate = Now.AddDays(-2)
            rdpTo.SelectedDate = DateTime.Today


        End If




    End Sub



    Public Sub BindGrid(ByVal SqlPass As String)


        Dim cmd As New SqlCommand(SqlPass, Obj.Connection())
        cmd.CommandTimeout = 0
        Dim Da As SqlDataAdapter = New SqlDataAdapter(cmd)

        Try

            Dim ds As DataSet = New DataSet()
            ds.Clear()
            Da.Fill(ds)

            RadDispatch.DataSource = ds
            RadDispatch.DataBind()




        Catch ex As Exception
            ClientScript.RegisterClientScriptBlock(GetType(Page), "scr", "<script language = javascript>alert('" & ex.Message & "!!')</script>")
        Finally
            Obj.ConClose()
        End Try

    End Sub





    Protected Sub ItemGroup()

        SqlPass = "  SELECT  CONVERT(VARCHAR(17), order_no) AS OrderNo , CONVERT(VARCHAR(2), order_srl_no) AS Line , team_code AS TeamCode ,   UPPER(group_desc) AS SalePerson ,   " & _
                  "CONVERT(VARCHAR(50), cust_name) AS Customer ,UPPER(Shade) AS Shade ,   item_no AS Sort ,  variant ,REPLACE(CONVERT(VARCHAR(11), order_dt, 106), ' ', '-') AS OrderDate ,   " & _
            "REPLACE(CONVERT(VARCHAR(11), req_dt, 106), ' ', '-') AS RequiredDate , CONVERT(VARCHAR(10), CONVERT(REAL, unit_price)) AS UnitPrice ," & _
            "CONVERT(VARCHAR(10), CONVERT(REAL, sales_price)) AS SalePrice ,   DNV ," & _
            "CONVERT (VARCHAR, CASE WHEN CONVERT(REAL, DNV) IS NULL THEN '0' ELSE CONVERT(REAL, sales_price)     - CONVERT(REAL, DNV) END) AS Diff ," & _
            "CONVERT(REAL, req_qty) AS ReqQty ,CONVERT(REAL, TotalGreyIssue) AS TotalGreyIssue ,REPLACE(CONVERT(VARCHAR(11), GreyIssueDate, 106), ' ', '-') AS GreyIssueDate ,     " & _
            "REPLACE(CONVERT(VARCHAR(11), LastPackingDate, 106), ' ', '-') AS LastPackingDate ,CONVERT(REAL, TotalPackQty) AS TotalPackQty ,   " & _
            "CONVERT(REAL, TotalDisQty) AS TotalDisQty ,CONVERT(REAL, PackedStock) AS PackedStock , CONVERT(VARCHAR(50), LineWise) AS LineWise ," & _
            "CONVERT(VARCHAR(50), OrderWise) AS OrderWise , status FROM    TableForUnAssortAssort WHERE   status NOT IN (   'D'  ) AND item_no NOT IN ('FMS','DEPB') AND  CONVERT(SMALLDATETIME, CONVERT(VARCHAR(11), CreatedDate))  BETWEEN '" & rdpFrom.SelectedDate.Value & "' AND '" & rdpTo.SelectedDate.Value & "'   ORDER BY ORDER_NO   "

        If SqlPass <> "" Then
            BindGrid(SqlPass)
        End If
    End Sub


    Protected Sub CallToBind()


        SqlPass = "  SELECT  CONVERT(VARCHAR(17), order_no) AS OrderNo , CONVERT(VARCHAR(2), order_srl_no) AS Line , team_code AS TeamCode ,   UPPER(group_desc) AS SalePerson ,   " & _
                    "CONVERT(VARCHAR(50), cust_name) AS Customer ,UPPER(Shade) AS Shade ,   item_no AS Sort ,  variant ,REPLACE(CONVERT(VARCHAR(11), order_dt, 106), ' ', '-') AS OrderDate ,   " & _
              "REPLACE(CONVERT(VARCHAR(11), req_dt, 106), ' ', '-') AS RequiredDate , CONVERT(VARCHAR(10), CONVERT(REAL, unit_price)) AS UnitPrice ," & _
              "CONVERT(VARCHAR(10), CONVERT(REAL, sales_price)) AS SalePrice ,   DNV ," & _
              "CONVERT (VARCHAR, CASE WHEN CONVERT(REAL, DNV) IS NULL THEN '0' ELSE CONVERT(REAL, sales_price)     - CONVERT(REAL, DNV) END) AS Diff ," & _
              "CONVERT(REAL, req_qty) AS ReqQty ,CONVERT(REAL, TotalGreyIssue) AS TotalGreyIssue ,REPLACE(CONVERT(VARCHAR(11), GreyIssueDate, 106), ' ', '-') AS GreyIssueDate ,     " & _
              "REPLACE(CONVERT(VARCHAR(11), LastPackingDate, 106), ' ', '-') AS LastPackingDate ,CONVERT(REAL, TotalPackQty) AS TotalPackQty ,   " & _
              "CONVERT(REAL, TotalDisQty) AS TotalDisQty ,CONVERT(REAL, PackedStock) AS PackedStock , CONVERT(VARCHAR(50), LineWise) AS LineWise ," & _
              "CONVERT(VARCHAR(50), OrderWise) AS OrderWise , status FROM    TableForUnAssortAssort WHERE   status NOT IN (   'D'  ) AND item_no NOT IN ('FMS','DEPB') AND  CONVERT(SMALLDATETIME, CONVERT(VARCHAR(11), CreatedDate))  BETWEEN '" & rdpFrom.SelectedDate.Value & "' AND '" & rdpTo.SelectedDate.Value & "'   ORDER BY ORDER_NO  "

        If SqlPass <> "" Then
            Dim cmd As New SqlCommand(SqlPass, Obj.Connection())
            cmd.CommandTimeout = 0
            Dim Da As SqlDataAdapter = New SqlDataAdapter(cmd)


            Try
                Dim ds As DataSet = New DataSet()
                ds.Clear()
                Da.Fill(ds)
                RadDispatch.DataSource = ds

            Catch ex As Exception
                ClientScript.RegisterClientScriptBlock(GetType(Page), "scr", "<script language = javascript>alert('" & ex.Message & "!!')</script>")
            Finally
                Obj.ConClose()
            End Try

        End If



    End Sub

    Protected Sub RadButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadButton1.Click

        ItemGroup()

    End Sub

    

End Class
