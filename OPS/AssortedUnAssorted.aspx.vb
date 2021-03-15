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

Partial Class AssortedUnAssorted
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

        'SqlPass = "EXEC UnAssortAssort '" & rdpFrom.SelectedDate.Value & "', '" & rdpTo.SelectedDate.Value & "'  "
        SqlPass = "  SELECT Plant, CONVERT(VARCHAR(17), order_no) AS OrderNo ,  CONVERT(VARCHAR(17), ParentOrder) AS ParentOrder ,  CONVERT(VARCHAR(17), DispatchOrder) AS DispatchOrder,         CONVERT(VARCHAR(5), OrderInitalStatus) AS OrderInitalStatus ,CONVERT(VARCHAR(2), order_srl_no) AS Line , team_code AS TeamCode ,   UPPER(group_desc) AS SalePerson ,   " & _
                  "CONVERT(VARCHAR(50), cust_name) AS Customer ,UPPER(Shade) AS Shade ,   item_no AS Sort ,  variant ,REPLACE(CONVERT(VARCHAR(11), order_dt, 106), ' ', '-') AS OrderDate ,   " & _
            "REPLACE(CONVERT(VARCHAR(11), req_dt, 106), ' ', '-') AS RequiredDate , CONVERT(VARCHAR(10), CONVERT(REAL, unit_price)) AS UnitPrice ," & _
            "CONVERT(VARCHAR(10), CONVERT(REAL, sales_price)) AS SalePrice ,   DNV ," & _
            "CONVERT (VARCHAR, CASE WHEN CONVERT(REAL, DNV) IS NULL THEN '0' ELSE CONVERT(REAL, sales_price)     - CONVERT(REAL, DNV) END) AS Diff ," & _
            "CONVERT(REAL, req_qty) AS ReqQty ,CONVERT(REAL, TotalGreyIssue) AS TotalGreyIssue ,REPLACE(CONVERT(VARCHAR(11), GreyIssueDate, 106), ' ', '-') AS GreyIssueDate ,     " & _
            "REPLACE(CONVERT(VARCHAR(11), LastPackingDate, 106), ' ', '-') AS LastPackingDate ,    CONVERT(REAL, LastPacking) AS LastPackQty ,  CONVERT(REAL, TotalPackQty) AS TotalPackQty ,    CONVERT(REAL, unis_qty) AS UNIS, " & _
            "CONVERT(REAL, TotalDisQty) AS TotalDisQty , REPLACE(CONVERT(VARCHAR(11), LastDisDate, 106), ' ', '-') AS LastDispatchDate ,CONVERT(REAL, PackedStock) AS PackedStock , CONVERT(VARCHAR(50), LineWise) AS LineWise ," & _
            "CONVERT(VARCHAR(50), OrderWise) AS OrderWise ,ISNULL(OrderComments,'') AS  OrderComments, status FROM    TableForUnAssortAssort WHERE   status NOT IN (     'D'  ) AND item_no NOT IN ('FMS','DEPB','SHIS') AND  CONVERT(SMALLDATETIME, CONVERT(VARCHAR(11), CreatedDate))  BETWEEN '" & rdpFrom.SelectedDate.Value & "' AND '" & rdpTo.SelectedDate.Value & "'    ORDER BY ORDER_NO  "
        If SqlPass <> "" Then
            BindGrid(SqlPass)
        End If
    End Sub


    Protected Sub CallToBind()


        ' SqlPass = "EXEC UnAssortAssort '" & rdpFrom.SelectedDate.Value & "', '" & rdpTo.SelectedDate.Value & "'  "
        SqlPass = "  SELECT  Plant,CONVERT(VARCHAR(17), order_no) AS OrderNo , CONVERT(VARCHAR(17), ParentOrder) AS ParentOrder ,   CONVERT(VARCHAR(17), DispatchOrder) AS DispatchOrder,      CONVERT(VARCHAR(5), OrderInitalStatus) AS OrderInitalStatus ,CONVERT(VARCHAR(2), order_srl_no) AS Line , team_code AS TeamCode ,   UPPER(group_desc) AS SalePerson ,   " & _
                    "CONVERT(VARCHAR(50), cust_name) AS Customer ,UPPER(Shade) AS Shade ,   item_no AS Sort ,  variant ,REPLACE(CONVERT(VARCHAR(11), order_dt, 106), ' ', '-') AS OrderDate ,   " & _
              "REPLACE(CONVERT(VARCHAR(11), req_dt, 106), ' ', '-') AS RequiredDate , CONVERT(VARCHAR(10), CONVERT(REAL, unit_price)) AS UnitPrice ," & _
              "CONVERT(VARCHAR(10), CONVERT(REAL, sales_price)) AS SalePrice ,   DNV ," & _
              "CONVERT (VARCHAR, CASE WHEN CONVERT(REAL, DNV) IS NULL THEN '0' ELSE CONVERT(REAL, sales_price)     - CONVERT(REAL, DNV) END) AS Diff ," & _
              "CONVERT(REAL, req_qty) AS ReqQty ,CONVERT(REAL, TotalGreyIssue) AS TotalGreyIssue ,REPLACE(CONVERT(VARCHAR(11), GreyIssueDate, 106), ' ', '-') AS GreyIssueDate ,     " & _
              "REPLACE(CONVERT(VARCHAR(11), LastPackingDate, 106), ' ', '-') AS LastPackingDate ,    CONVERT(REAL, LastPacking) AS LastPackQty ,  CONVERT(REAL, TotalPackQty) AS TotalPackQty ,   CONVERT(REAL, unis_qty) AS UNIS,  " & _
              "CONVERT(REAL, TotalDisQty) AS TotalDisQty , REPLACE(CONVERT(VARCHAR(11), LastDisDate, 106), ' ', '-') AS LastDispatchDate ,CONVERT(REAL, PackedStock) AS PackedStock , CONVERT(VARCHAR(50), LineWise) AS LineWise ," & _
              "CONVERT(VARCHAR(50), OrderWise) AS OrderWise , ISNULL(OrderComments,'') AS  OrderComments,status FROM    TableForUnAssortAssort WHERE   status NOT IN (    'D'  ) AND item_no NOT IN ('FMS','DEPB','SHIS') AND  CONVERT(SMALLDATETIME, CONVERT(VARCHAR(11), CreatedDate))  BETWEEN '" & rdpFrom.SelectedDate.Value & "' AND '" & rdpTo.SelectedDate.Value & "'    ORDER BY ORDER_NO  "

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

    'Protected Sub RadButton2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadButton2.Click
    '    RadDispatch.MasterTableView.GridLines = GridLines.Both
    '    RadDispatch.ExportSettings.IgnorePaging = True
    '    RadDispatch.ExportSettings.OpenInNewWindow = True
    '    RadDispatch.ExportSettings.ExportOnlyData = True
    '    RadDispatch.ExportSettings.Excel.Format = Telerik.Web.UI.GridExcelExportFormat.ExcelML
    '    RadDispatch.MasterTableView.ExportToExcel()
    'End Sub
    Protected Sub RadButton2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadButton2.Click


        SqlPass = "  SELECT  Plant,CONVERT(VARCHAR(17), order_no) AS OrderNo , CONVERT(VARCHAR(17), ParentOrder) AS ParentOrder ,  CONVERT(VARCHAR(17), DispatchOrder) AS DispatchOrder,   CONVERT(VARCHAR(5), OrderInitalStatus) AS OrderInitalStatus ,CONVERT(VARCHAR(2), order_srl_no) AS Line , team_code AS TeamCode ,   UPPER(group_desc) AS SalePerson ,   " & _
                  "CONVERT(VARCHAR(50), cust_name) AS Customer ,UPPER(Shade) AS Shade ,   item_no AS Sort ,  variant ,REPLACE(CONVERT(VARCHAR(11), order_dt, 106), ' ', '-') AS OrderDate ,   " & _
            "REPLACE(CONVERT(VARCHAR(11), req_dt, 106), ' ', '-') AS RequiredDate , CONVERT(VARCHAR(10), CONVERT(REAL, unit_price)) AS UnitPrice ," & _
            "CONVERT(VARCHAR(10), CONVERT(REAL, sales_price)) AS SalePrice ,   DNV ," & _
            "CONVERT (VARCHAR, CASE WHEN CONVERT(REAL, DNV) IS NULL THEN '0' ELSE CONVERT(REAL, sales_price)     - CONVERT(REAL, DNV) END) AS Diff ," & _
            "CONVERT(REAL, req_qty) AS ReqQty ,CONVERT(REAL, TotalGreyIssue) AS TotalGreyIssue ,REPLACE(CONVERT(VARCHAR(11), GreyIssueDate, 106), ' ', '-') AS GreyIssueDate ,     " & _
            "REPLACE(CONVERT(VARCHAR(11), LastPackingDate, 106), ' ', '-') AS LastPackingDate ,    CONVERT(REAL, LastPacking) AS LastPackQty ,  CONVERT(REAL, TotalPackQty) AS TotalPackQty ,    CONVERT(REAL, unis_qty) AS UNIS, " & _
            "CONVERT(REAL, TotalDisQty) AS TotalDisQty , REPLACE(CONVERT(VARCHAR(11), LastDisDate, 106), ' ', '-') AS LastDispatchDate ,CONVERT(REAL, PackedStock) AS PackedStock , CONVERT(VARCHAR(50), LineWise) AS LineWise ," & _
            "CONVERT(VARCHAR(50), OrderWise) AS OrderWise ,ISNULL(OrderComments,'') AS  OrderComments, status FROM    TableForUnAssortAssort (NOLOCK) WHERE   status NOT IN (    'D'  ) AND item_no NOT IN ('FMS','DEPB','SHIS') AND  CONVERT(SMALLDATETIME, CONVERT(VARCHAR(11), CreatedDate))  BETWEEN '" & rdpFrom.SelectedDate.Value & "' AND '" & rdpTo.SelectedDate.Value & "'   ORDER BY ORDER_NO  "



        Dim cmd As SqlCommand = New SqlCommand(SqlPass, Obj.Connection())

        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet()
        da.Fill(ds)

        Dim dt As DataTable = ds.Tables(0)


        Dim attachment As String = "attachment; filename=HiteshExcel.xls"
        Response.ClearContent()
        Response.AddHeader("content-disposition", attachment)
        Response.ContentType = "application/vnd.ms-excel"
        Dim tab As String = ""
        For Each dc As DataColumn In dt.Columns
            Response.Write(tab + dc.ColumnName)
            tab = vbTab
        Next
        Response.Write(vbLf)
        Dim i As Integer
        For Each dr As DataRow In dt.Rows
            tab = ""
            For i = 0 To dt.Columns.Count - 1
                Response.Write(tab & dr(i).ToString())
                tab = vbTab
            Next
            Response.Write(vbLf)
        Next
        Response.[End]()

        Obj.ConClose()



    End Sub
End Class
