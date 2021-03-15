Imports System.Data
Imports System.Data.SqlClient
Imports System
Partial Class SampleIssueReport
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

        End If
    End Sub





    Protected Sub BtnGet_Click(sender As Object, e As System.EventArgs) Handles BtnGet.Click

        SqlPass = "SELECT  DISTINCT  a.invoice_no AS InvoiceNo , CONVERT(VARCHAR(11),invoice_dt,103) AS InvoiceDate ,  bill_to_cust AS CustNo , cust_name AS CustomerName ,  SUM(invoice_qty) AS Qty , invoice_amt AS InvoiceAmount ,  CASE WHEN status = 'A' THEN 'Authorized'  WHEN status = 'S' THEN 'Shipped'  WHEN status = 'D' THEN 'Cancelled'   WHEN status = 'L' THEN 'Allocated'  WHEN status = 'O' THEN 'Open' END AS Status FROM    ARDB..dms_t_invoice_hdr a ( NOLOCK ) ,  ARDB..dms_t_invoice_item b ( NOLOCK ) , som..m_customer F ( NOLOCK ) WHERE   a.company_no = 'JCT00LTD'  AND a.invoice_locn = 'PHG'" & _
                    " AND a.invoice_type = 'DIRINV'    AND a.invoice_dt  BETWEEN '" & TxtDateFrom.Text & "' AND  '" & txtDateTo.Text & "' AND LEFT( A.invoice_no,4)= '" & TxtSeries.Text & "'  AND b.company_no = a.company_no   AND b.invoice_locn = a.invoice_locn  AND b.invoice_type = 'DIRINV'  AND b.invoice_no = a.invoice_no  AND LEFT(A.invoice_no, 4) IN( 'DINV','NDIN') AND A.bill_to_cust = F.cust_no GROUP BY a.invoice_no , invoice_dt,  bill_to_cust,  cust_name,  invoice_amt,   status ORDER BY a.invoice_no   "
        


        PassString(SqlPass, Qry)


    End Sub

    Protected Sub PassString(ByVal SqlPass As String, ByVal Qry As String)
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
        GridViewExportUtil.Export("Sample Status.xls", GridView1)
    End Sub
   

  End Class