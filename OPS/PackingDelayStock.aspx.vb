Imports System.Data
Imports System.Data.SqlClient
Imports System
Imports System.IO
Imports Microsoft.Office.Interop

Partial Class PackingDelayStock
    Inherits System.Web.UI.Page
    Dim Cmd As New SqlCommand
    Dim SqlPass, Qry, Cust As String
    Dim ObjFun As Functions = New Functions
    Public AutoStr As String, TrueFalse As Boolean = False

    Dim Obj As Connection = New Connection
    Dim AId As Integer, I As Integer, Tot As String
    Dim Xl As GridViewExportUtil = New GridViewExportUtil
    Dim Fun As Functions

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' Response.Cache.SetCacheability(HttpCacheability.NoCache)

    End Sub

    Protected Sub BtnGet_Click(sender As Object, e As System.EventArgs) Handles BtnGet.Click



        SqlPass = "EXEC JCTGEN..JCT_OPS_DELAY_PACK_STOCK_SP "

        Dim cmd As SqlCommand = New SqlCommand(SqlPass, Obj.Connection)
        cmd.CommandTimeout = 1000000
        Obj.ConOpen()
        cmd.ExecuteNonQuery()
        Obj.ConClose()

        Qry = "SELECT    ItemGroupNo ,OrderNo ,LotNo , STATUS , SalePerson ,CustomerName , Rate ,RecdDate , QtyRecd ,MinPacking ,MaxPacking ,UpdateTime , Days  FROM  JCTGEN..JCT_OPS_DELAY_STOCK  ORDER BY  Status "
        Dim Da As SqlDataAdapter = New SqlDataAdapter(Qry, Obj.Connection())

        Da.SelectCommand.CommandTimeout = 0
        Dim ds As DataSet = New DataSet()
        Da.Fill(ds)
        Dim dt As DataTable = ds.Tables(0)



        Dim strFileFullPath As String = Server.MapPath("PackStockDelay.xls")

        If IO.File.Exists(strFileFullPath) Then
            IO.File.Delete(strFileFullPath)
        End If

        Dim filepath As String = Server.MapPath("PackStockDelay.xls")

        ExportToExcelTo(dt, filepath)


        Obj.ConClose()

        Response.ContentType = "application/octet-stream"
        Response.AddHeader("Content-Disposition", String.Format("attachment; filename = {0}", System.IO.Path.GetFileName("PackStockDelay.xls")))
        Response.AppendHeader("Content-Disposition", "attachment; filename=PackStockDelay.xls")
        Response.TransmitFile(Server.MapPath("PackStockDelay.xls"))
        Response.End()




    End Sub


    Private Sub ExportToExcelTo(ByVal dtTemp As DataTable, ByVal filepath As String)
        Dim strFileName As String = filepath

        Dim _excel As New Excel.Application
        Dim wBook As Excel.Workbook
        Dim wSheet As Excel.Worksheet

        wBook = _excel.Workbooks.Add()
        wSheet = wBook.ActiveSheet()

        Dim dt As System.Data.DataTable = dtTemp
        Dim dc As System.Data.DataColumn
        Dim dr As System.Data.DataRow
        Dim colIndex As Integer = 0
        Dim rowIndex As Integer = 0

        For Each dc In dt.Columns
            colIndex = colIndex + 1
            wSheet.Cells(1, colIndex) = dc.ColumnName
        Next

        For Each dr In dt.Rows
            rowIndex = rowIndex + 1
            colIndex = 0
            For Each dc In dt.Columns
                colIndex = colIndex + 1
                wSheet.Cells(rowIndex + 1, colIndex) = dr(dc.ColumnName)
            Next
        Next
        wSheet.Columns.AutoFit()
        wBook.SaveAs(strFileName)

        ReleaseObject(wSheet)
        wBook.Close(False)
        ReleaseObject(wBook)
        _excel.Quit()
        ReleaseObject(_excel)
        GC.Collect()


    End Sub
    Private Sub ReleaseObject(ByVal o As Object)
        Try
            While (System.Runtime.InteropServices.Marshal.ReleaseComObject(o) > 0)
            End While
        Catch
        Finally
            o = Nothing
        End Try
    End Sub







    Public Shared Sub ExportToExcel(dt As DataTable, filename As String)
        Dim response As HttpResponse = HttpContext.Current.Response

        ' first let's clean up the response.object
        response.Clear()
        response.Charset = ""

        ' set the response mime type for excel
        response.ContentType = "application/vnd.ms-excel"
        ' response.ContentType = "application/vnd.xls";
        response.AddHeader("Content-Disposition", "attachment;filename=""" & filename & """")

        ' create a string writer
        Using sw As New StringWriter()
            Using htw As New HtmlTextWriter(sw)
                ' instantiate a datagrid
                Dim dg As New DataGrid()
                dg.DataSource = dt
                dg.DataBind()
                dg.RenderControl(htw)
                response.Write(sw.ToString())
                'response.End()
            End Using
        End Using
    End Sub

    Public Sub exportExcel(ByVal p As Page, ByRef dt As DataTable)


        Dim pageName As String = p.Request.RawUrl()

        Dim attachment As String = "attachment; filename=ExcelData.xls"
        p.Response.ClearContent()
        p.Response.ContentType = "application/vnd.ms-excel"
        p.Response.AddHeader("content-disposition", attachment)
        p.Response.ContentEncoding = System.Text.Encoding.Unicode
        p.Response.BinaryWrite(System.Text.Encoding.Unicode.GetPreamble())
        p.Response.Cache.SetCacheability(HttpCacheability.NoCache)


        Dim stringWrite As StringWriter = New StringWriter
        Dim htmlWrite As HtmlTextWriter = New HtmlTextWriter(stringWrite)


        Dim tab As String = ""
        For Each dc As DataColumn In dt.Columns
            htmlWrite.Write(tab + dc.ColumnName)
            tab = vbTab
        Next


        Dim i As Integer
        For Each dr As DataRow In dt.Rows
            tab = ""
            For i = 0 To dt.Columns.Count - 1

                htmlWrite.Write(tab & dr(i).ToString())
                tab = vbTab
            Next
            p.Response.Write(vbLf)
        Next

        '   p.Response.End()

    End Sub



End Class