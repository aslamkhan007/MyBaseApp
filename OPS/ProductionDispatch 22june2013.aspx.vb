Imports System
Imports System.Data
Imports System.Data.SqlClient

Partial Class ProductionDispatch
    Inherits System.Web.UI.Page
    Dim Cmd As New SqlCommand
    Dim SqlPass, Qry, Cust As String
    Dim ObjFun As Functions = New Functions
    Public AutoStr As String
    Dim ShpConStr As String = System.Web.Configuration.WebConfigurationManager.ConnectionStrings("shpConnectionString").ConnectionString
    Dim Obj As Connection = New Connection(ShpConStr)
    Dim AId As Integer, I As Integer, Tot As String
    Dim Xl As GridViewExportUtil = New GridViewExportUtil
    Dim Fun As Functions

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        If (Session("empcode").ToString <> "") Then

            If Session("empcode").ToString = "A-00224" Or Session("empcode").ToString = "W-04403" Or Session("empcode").ToString = "Backofc" Or Session("empcode").ToString = "H-01436" Or Session("empcode").ToString = "R-03339" Or Session("empcode").ToString = "N-02643" Or Session("empcode").ToString = "G-01344" Then
                BtnRefresh.Enabled = True
            Else
                BtnRefresh.Enabled = False
            End If

        Else

            Response.Redirect("~/login.aspx")

        End If

        If Not IsPostBack Then

        Else

            If Session("empcode").ToString = "A-00224" Or Session("empcode").ToString = "W-04403" Or Session("empcode").ToString = "Backofc" Or Session("empcode").ToString = "H-01436" Or Session("empcode").ToString = "R-03339" Or Session("empcode").ToString = "N-02643" Or Session("empcode").ToString = "G-01344" Then
                BtnRefresh.Enabled = True
            Else
                BtnRefresh.Enabled = False
            End If

        End If

    End Sub


    Protected Sub PassString(ByVal SqlPass As String)
        Dim Da As SqlDataAdapter = New SqlDataAdapter(SqlPass, Obj.Connection())
        Da.SelectCommand.CommandTimeout = 0
        Try

            Dim ds As DataSet = New DataSet()
            ds.Clear()
            Da.Fill(ds)

            GridView1.DataSource = ds
            GridView1.DataBind()



        Catch ex As Exception

        Finally
            Obj.ConClose()
        End Try
    End Sub


    Protected Sub BtnRefresh_Click(sender As Object, e As System.EventArgs) Handles BtnRefresh.Click

        SqlPass = "EXEC SHP..JCT_OPS_DAILY_PRODUCTION_DISPATCH_PG   "
        Dim cmd As SqlCommand = New SqlCommand(SqlPass, Obj.Connection)
        cmd.CommandTimeout = 1000000
        Obj.ConOpen()
        cmd.ExecuteNonQuery()
        Obj.ConClose()

    End Sub

    Protected Sub BtnExcel_Click(sender As Object, e As System.EventArgs) Handles BtnExcel.Click
        GridViewExportUtil.Export("ProductionDispatch.xls", GridView1)
    End Sub

    Protected Sub BtnFetch_Click(sender As Object, e As System.EventArgs) Handles BtnFetch.Click
        Qry = "SELECT CONVERT(VARCHAR, CONVERT(VARCHAR(11), GETDATE()-1),101)"
        Dim R As String

        Dim Dr As SqlDataReader = Obj.FetchReader(Qry)
        Try
            If Dr.HasRows = True Then
                While Dr.Read()
                    R = Dr.Item(0)
                End While
            End If
            Dr.Close()
        Catch ex As Exception
        Finally
            Obj.ConClose()
        End Try

        If Session("empcode").ToString = "P-03055" Then
            'SqlPass = "SELECT Plant  AS  Segment,    UOM,  OpeningStock ,    LASTPACKING AS LastMonthPacking	,LASTDISPATCH  AS LastMonthDispatch,  YP AS '" & R & " - Packing'  ,  TillPacking AS MTDPacking , YD AS '" & R & " - Dispatch'  , LDV AS '" & R & " - Dispatch Value' , TillDispatch AS MTDDispatch,  MonDispVal AS [Month Dispatch Value] ,   Balance,TillUnis AS MTDUnis  FROM SHP..JCT_OPS_PRODUCTION_DISPATCH_TABLE_PG  WHERE   SNO BETWEEN '1' AND '7' ORDER BY SNO  "
            'SqlPass = "SELECT Plant  AS  Segment,    UOM,  OpeningStock ,    LASTPACKING -LASTUNIS AS LastMonthPacking	,LASTDISPATCH  AS LastMonthDispatch,  YP AS '" & R & " - Packing'  ,  TillPacking-TillUnis AS MTDPacking , YD AS '" & R & " - Dispatch'  , LDV AS '" & R & " - Dispatch Value' , TillDispatch AS MTDDispatch,  MonDispVal AS [Month Dispatch Value] ,   Balance,TillUnis AS MTDUnis FROM SHP..JCT_OPS_PRODUCTION_DISPATCH_TABLE_PG  WHERE   SNO BETWEEN '1' AND '7' ORDER BY SNO  "
            SqlPass = "SELECT Plant  AS  Segment,    UOM,  OpeningStock ,    ISNULL(LASTPACKING,0) -ISNULL(LASTUNIS,0) AS LastMonthPacking	,LASTDISPATCH  AS LastMonthDispatch,  YP AS '" & R & " - Packing'  ,  ISNULL(TillPacking,0)- ISNULL(TillUnis,0) AS MTDPacking , YD AS '" & R & " - Dispatch'  , LDV AS '" & R & " - Dispatch Value' , TillDispatch AS MTDDispatch,  MonDispVal AS [Month Dispatch Value] ,   Balance  FROM SHP..JCT_OPS_PRODUCTION_DISPATCH_TABLE_PG  WHERE   SNO BETWEEN '1' AND '7' ORDER BY SNO "
        Else
            SqlPass = "SELECT Plant AS  Segment,  UOM,  OpeningStock ,     LASTPACKING AS LastMonthPacking	,LASTDISPATCH  AS LastMonthDispatch,	LASTUNIS AS LastMonthUNIS,TillPacking AS MTDPacking , TodayPacking , TillDispatch AS MTDDispatch,  TodayDispatch ,MonDispVal AS [Month Dispatch Value],TdyDispVal AS [Today Dispatch Value] ,TillUnis AS MTDUnis, TodayUnis ,YP AS '" & R & " - Packing'  ,YD AS '" & R & " - Dispatch'   ,  Balance FROM SHP..JCT_OPS_PRODUCTION_DISPATCH_TABLE_PG  WHERE   SNO BETWEEN '1' AND '7' ORDER BY SNO"
        End If
        PassString(SqlPass)
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