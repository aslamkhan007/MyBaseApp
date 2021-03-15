Imports System.Data
Imports System.Data.SqlClient
Imports System
Partial Class PackingToDispatch
    Inherits System.Web.UI.Page
    Dim Cmd As New SqlCommand
    Dim Cmd1 As New SqlCommand
    Dim SqlPass, SqlPass1, Qry, Cust As String
    Dim ObjFun As Functions = New Functions
    Public AutoStr As String
    Dim ShpConStr As String = System.Web.Configuration.WebConfigurationManager.ConnectionStrings("shpConnectionString").ConnectionString
    Dim Obj As Connection = New Connection(ShpConStr)
    Dim Obj1 As Connection = New Connection(ShpConStr)
    Dim AId As Integer, I As Integer, Tot As String
    Dim Xl As GridViewExportUtil = New GridViewExportUtil
    Dim Fun As Functions
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        If (Session("empcode").ToString <> "") Then

        End If
    End Sub

    Protected Sub BtnGet_Click(sender As Object, e As System.EventArgs) Handles BtnGet.Click

        SqlPass = " SELECT  order_no AS OrderNo ,team_code AS TeamCode , group_desc AS SalePerosn  , cust_name AS Customer , order_srl_no As LineNos  ,item_no AS Sort  , variant as Variant  , Shade ," & _
                   " REPLACE(CONVERT(VARCHAR(11), createddate, 106), ' ', '-')  AS CreatedDt, REPLACE(CONVERT(VARCHAR(11), order_dt, 106), ' ', '-')  AS OrderDt , REPLACE(CONVERT(VARCHAR(11), AmendDate, 106), ' ', '-')  AS AmendDt ,CONVERT(NUMERIC(20,2),req_qty) AS ReqQty, REPLACE(CONVERT(VARCHAR(11), req_dt, 106), ' ', '-') AS ReqDt   ,CONVERT(NUMERIC(20,2),unit_price) AS UP   ,CONVERT(NUMERIC(20,2),sales_price) AS SP  ,DNV,status AS Status  ,GreyIssue AS [Grey Issue], TotalGreyIssueDate AS [Grey Issue Date], CONVERT(NUMERIC(20,2),TotalPackQty) AS TotalPackQty , CONVERT(NUMERIC(20,2),TotalDisQty) AS TotalDisQty ,CONVERT(NUMERIC(20,2),PackedStock) AS PackedStock , " & _
                    "  CONVERT( VARCHAR(11),FirstPackDate ,103) AS FirstPackDate,  CONVERT( VARCHAR(11),LastPackDate,103) As LastPackDate  ,CONVERT( VARCHAR(11),FirstDisDate,103) As FirstDisDate , CONVERT( VARCHAR(11),LastDisDate,103) As LastDisDate ,TotalPackingDate , TotalDispatchDate , CH , FN , FR , RG , SA , SF , SLP ," & _
                    " SLT , SM ,SO , SP , ST , SW, '    '  AS [UNPLANNED ISSUE =>], CHU , FNU , FRU , RGU , SAU , SFU , SLPU ,SLTU , SMU ,SOU , SPU , STU , SWU, ' ' AS [DISPATCH =>],CHD , FND , FRD , RGD , SAD , SFD , SLPD ,SLTD , SMD ,SOD , SPD , STD , SWD ,CASE WHEN FirstPackDate > req_dt THEN 'DELAYED'     WHEN ISNULL(FirstPackDate, '') = '' THEN 'NOT STARTED' ELSE 'ON TIME' END AS 'OTP' ,  " & _
        "CASE WHEN ISNULL(FirstPackDate, '') = ''   THEN 'NOT STARTED' WHEN DATEDIFF(dd, order_dt, FirstPackDate) < 1.1 THEN 'LESS THAN 1'  WHEN DATEDIFF(dd, order_dt, FirstPackDate) < 7.1  THEN 'LESS THAN 7'  WHEN DATEDIFF(dd, order_dt, FirstPackDate) < 15   THEN 'LESS THAN 15'   " & _
         "    WHEN DATEDIFF(dd, order_dt, FirstPackDate) < 25  THEN 'LESS THAN 25' WHEN DATEDIFF(dd, order_dt, FirstPackDate) < 35   THEN 'LESS THAN 35' WHEN DATEDIFF(dd, order_dt, FirstPackDate) < 45   THEN 'LESS THAN 45'   " & _
          " WHEN DATEDIFF(dd, order_dt, FirstPackDate) < 60  THEN 'LESS THAN 60' ELSE 'GREATER THAN 60' END AS 'OrderLeadTime' ,  " & _
         " CASE WHEN DATEDIFF(dd, order_dt, req_dt) < 1.1 THEN 'LESS THAN 1' WHEN DATEDIFF(dd, order_dt, req_dt) < 7.1 THEN 'LESS THAN 7' WHEN DATEDIFF(dd, order_dt, req_dt) < 15 THEN 'LESS THAN 15' WHEN DATEDIFF(dd, order_dt, req_dt) < 25 THEN 'LESS THAN 25'   " & _
           "  WHEN DATEDIFF(dd, order_dt, req_dt) < 35 THEN 'LESS THAN 35' WHEN DATEDIFF(dd, order_dt, req_dt) < 45 THEN 'LESS THAN 45' WHEN DATEDIFF(dd, order_dt, req_dt) < 60 THEN 'LESS THAN 60' ELSE 'GREATER THAN 60'  END AS 'Lead Time'   " & _
      " FROM SOM..JCT_PACKING_DISPATCH_GARDE  WHERE   ( Order_no='" & TxtOrderNo.Text & "' OR  '" & TxtOrderNo.Text & " '='')  "
        PassString(SqlPass, GridView1)


    End Sub

    Protected Sub PassString(ByVal SqlPass As String, ByVal Grd As GridView)
        Dim Da As SqlDataAdapter = New SqlDataAdapter(SqlPass, Obj.Connection())
        Da.SelectCommand.CommandTimeout = 0
        Try

            Dim ds As DataSet = New DataSet()
            ds.Clear()
            Da.Fill(ds)

            Grd.DataSource = ds
            Grd.DataBind()

        Catch ex As Exception

        Finally
            Obj.ConClose()
        End Try

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

    Protected Sub BtnExcel_Click(sender As Object, e As System.EventArgs) Handles BtnExcel.Click

        SqlPass = " SELECT  order_no AS OrderNo ,team_code AS TeamCode , group_desc AS SalePerosn  , cust_name AS Customer , order_srl_no As LineNos  ,item_no AS Sort  , variant as Variant  , Shade ," & _
                       " REPLACE(CONVERT(VARCHAR(11), createddate, 106), ' ', '-')  AS CreatedDt, REPLACE(CONVERT(VARCHAR(11), order_dt, 106), ' ', '-')  AS OrderDt ,  REPLACE(CONVERT(VARCHAR(11), AmendDate, 106), ' ', '-')  AS AmendDt , CONVERT(NUMERIC(20,2),req_qty) AS ReqQty, REPLACE(CONVERT(VARCHAR(11), req_dt, 106), ' ', '-') AS ReqDt   ,CONVERT(NUMERIC(20,2),unit_price) AS UP   ,CONVERT(NUMERIC(20,2),sales_price) AS SP  ,DNV,status AS Status  ,GreyIssue AS [Grey Issue], TotalGreyIssueDate AS [Grey Issue Date], CONVERT(NUMERIC(20,2),TotalPackQty) AS TotalPackQty , CONVERT(NUMERIC(20,2),TotalDisQty) AS TotalDisQty ,CONVERT(NUMERIC(20,2),PackedStock) AS PackedStock , " & _
                        "  CONVERT( VARCHAR(11),FirstPackDate ,103) AS FirstPackDate,  CONVERT( VARCHAR(11),LastPackDate,103) As LastPackDate  ,CONVERT( VARCHAR(11),FirstDisDate,103) As FirstDisDate , CONVERT( VARCHAR(11),LastDisDate,103) As LastDisDate ,TotalPackingDate , TotalDispatchDate , CH , FN , FR , RG , SA , SF , SLP ," & _
                        " SLT , SM ,SO , SP , ST , SW, '    '  AS [UNPLANNED ISSUE =>], CHU , FNU , FRU , RGU , SAU , SFU , SLPU ,SLTU , SMU ,SOU , SPU , STU , SWU, ' ' AS [DISPATCH =>],CHD , FND , FRD , RGD , SAD , SFD , SLPD ,SLTD , SMD ,SOD , SPD , STD , SWD ,CASE WHEN FirstPackDate > req_dt THEN 'DELAYED'     WHEN ISNULL(FirstPackDate, '') = '' THEN 'NOT STARTED' ELSE 'ON TIME' END AS 'OTP' ,  " & _
            "CASE WHEN ISNULL(FirstPackDate, '') = ''   THEN 'NOT STARTED' WHEN DATEDIFF(dd, order_dt, FirstPackDate) < 1.1 THEN 'LESS THAN 1'  WHEN DATEDIFF(dd, order_dt, FirstPackDate) < 7.1  THEN 'LESS THAN 7'  WHEN DATEDIFF(dd, order_dt, FirstPackDate) < 15   THEN 'LESS THAN 15'   " & _
             "    WHEN DATEDIFF(dd, order_dt, FirstPackDate) < 25  THEN 'LESS THAN 25' WHEN DATEDIFF(dd, order_dt, FirstPackDate) < 35   THEN 'LESS THAN 35' WHEN DATEDIFF(dd, order_dt, FirstPackDate) < 45   THEN 'LESS THAN 45'   " & _
              " WHEN DATEDIFF(dd, order_dt, FirstPackDate) < 60  THEN 'LESS THAN 60' ELSE 'GREATER THAN 60' END AS 'OrderLeadTime' ,  " & _
             " CASE WHEN DATEDIFF(dd, order_dt, req_dt) < 1.1 THEN 'LESS THAN 1' WHEN DATEDIFF(dd, order_dt, req_dt) < 7.1 THEN 'LESS THAN 7' WHEN DATEDIFF(dd, order_dt, req_dt) < 15 THEN 'LESS THAN 15' WHEN DATEDIFF(dd, order_dt, req_dt) < 25 THEN 'LESS THAN 25'   " & _
               "  WHEN DATEDIFF(dd, order_dt, req_dt) < 35 THEN 'LESS THAN 35' WHEN DATEDIFF(dd, order_dt, req_dt) < 45 THEN 'LESS THAN 45' WHEN DATEDIFF(dd, order_dt, req_dt) < 60 THEN 'LESS THAN 60' ELSE 'GREATER THAN 60'  END AS 'Lead Time'   " & _
          " FROM SOM..JCT_PACKING_DISPATCH_GARDE  WHERE   ( Order_no='" & TxtOrderNo.Text & "' OR  '" & TxtOrderNo.Text & " '='')  "

        Dim cmd As New SqlCommand(SqlPass, Obj.Connection())
        cmd.CommandType = CommandType.Text
        cmd.CommandTimeout = 0

        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet()
        da.Fill(ds)
        Dim dt As DataTable = ds.Tables(0)

        Dim attachment As String = "attachment; filename=DnV_Detail.xls"
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

        ' GridViewExportUtil.Export("Grade wise Packing Dispatch.xls", GridView1)
    End Sub


    Protected Sub BtnRefresh_Click(sender As Object, e As System.EventArgs) Handles BtnRefresh.Click

        SqlPass = " EXEC SOM..JCT_PACK_DISPATH_GARDE_PROC '" & DropDownList1.SelectedItem.Value & "', '" & TxtDateFrom.Text & "' ,  '" & txtDateTo.Text & "' , '" & TxtOrderNo.Text & "' "
        Dim cmd As SqlCommand = New SqlCommand(SqlPass, Obj.Connection)
        cmd.CommandTimeout = 1000000
        Obj.ConOpen()
        cmd.ExecuteNonQuery()
        Obj.ConClose()

        GridView1.DataSource = Nothing
        GridView1.DataBind()


    End Sub



    'Protected Sub GridView1_RowCreated(ByVal sender As Object, ByVal e As GridViewRowEventArgs)


    '    If e.Row.RowType = DataControlRowType.DataRow Then





    '        If e.Row.Cells(0).Text = "CH" Or e.Row.Cells(0).Text = "FN" Or e.Row.Cells(0).Text = "FR" Or e.Row.Cells(0).Text = "RG" Or e.Row.Cells(0).Text = "SA" Or e.Row.Cells(0).Text = "SF" Or e.Row.Cells(0).Text = "SLP" Or e.Row.Cells(0).Text = "SLT" Or e.Row.Cells(0).Text = "SM" Or e.Row.Cells(0).Text = "SO" Or e.Row.Cells(0).Text = "SP" Or e.Row.Cells(0).Text = "ST" Or e.Row.Cells(0).Text = "SW" Then
    '            e.Row.ForeColor = Drawing.Color.Red
    '        Else

    '        End If
    '    End If

    'End Sub



    Protected Sub BtnSummary_Click(sender As Object, e As System.EventArgs) Handles BtnSummary.Click


        SqlPass1 = "EXEC SOM..OTP '" & TxtDateFrom.Text & "' ,  '" & txtDateTo.Text & "' "
        Dim cmd1 As SqlCommand = New SqlCommand(SqlPass1, Obj1.Connection)
        cmd1.CommandTimeout = 1000000
        Obj1.ConOpen()
        cmd1.ExecuteNonQuery()
        Obj1.ConClose()


        Dim SqlPass2 = "SELECT OTP,OTPPER AS [OTP %] FROM som..OTPSUMMARY WHERE OTP IS NOT NULL"

        PassString(SqlPass2, GridView2)

        Dim SqlPass3 = "SELECT DESCRIPTION,LTDelReqDt  AS [Lead Time Order Dt VS Required Dt],LTOrddtPckDt  AS [Lead Time OrderDt VS Packing Dt] FROM som..OTPSUMMARY WHERE DESCRIPTION IS NOT NULL"
        PassString(SqlPass3, GridView3)


    End Sub
End Class