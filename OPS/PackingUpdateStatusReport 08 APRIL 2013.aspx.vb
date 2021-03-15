Imports System.Data
Imports System.Data.SqlClient
Imports System
Partial Class PackingUpdateStatusReport
    Inherits System.Web.UI.Page
    Dim Cmd As New SqlCommand
    Dim SqlPass, Qry, Cust As String
    Dim ObjFun As Functions = New Functions
    Public AutoStr As String

    Dim Obj As Connection = New Connection
    Dim AId As Integer, I As Integer, Tot As String
    Dim Xl As GridViewExportUtil = New GridViewExportUtil
    Dim Fun As Functions

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        If (Session("empcode").ToString <> "") Then
            'empcode = Session("empcode")
            If Session("empcode").ToString = "H-01436" Or Session("empcode").ToString = "R-03339" Or Session("empcode").ToString = "N-02643" Or Session("empcode").ToString = "G-01344" Then
                BtnRefresh.Enabled = True
            Else
                BtnRefresh.Enabled = False
            End If
        Else
            Response.Redirect("~/login.aspx")
        End If
        If Not IsPostBack Then

        Else

            If Session("empcode").ToString = "H-01436" Or Session("empcode").ToString = "R-03339" Or Session("empcode").ToString = "N-02643" Or Session("empcode").ToString = "G-01344" Then
                BtnRefresh.Enabled = True
            Else
                BtnRefresh.Enabled = False
            End If

        End If
    End Sub





    Protected Sub BtnGet_Click(sender As Object, e As System.EventArgs) Handles BtnGet.Click
        If txtSalePerson.Text = "Status VS SalePerson" Then
            SqlPass = "SELECT * FROM  JCTGEN..JCT_OPS_PACKED_Status_SalePerson  ORDER BY  Status "
            Qry = "SELECT * FROM JCTGEN..LastUpdateReason  WHERE ReportType ='StatusSalePerson'         "

        ElseIf txtSalePerson.Text = "SalePerson VS Status" Then
            SqlPass = "SELECT * FROM JCTGEN..JCT_OPS_PACKED_SalePerson_Status ORDER BY  SalePerson "
            Qry = "SELECT * FROM JCTGEN..LastUpdateReason  WHERE ReportType ='SalePersonStatus'         "

        ElseIf txtSalePerson.Text = "CustomerName VS SalePerson" Then

            SqlPass = "SELECT * FROM  JCTGEN..JCT_OPS_PACKED_CustomerName_SalePerson ORDER BY CustomerName"
            Qry = "SELECT * FROM JCTGEN..LastUpdateReason  WHERE ReportType ='CustomerNameSalePerson'         "

        ElseIf txtSalePerson.Text = "Status VS Date" Then

            SqlPass = "SELECT REPLACE(CASE WHEN CHARINDEX('--', Status) > 0 AND CHARINDEX('--', Status) + 1 <> LEN(STATUS)  THEN '=>' + SUBSTRING(status, CHARINDEX('--', Status) + 2,    LEN(Status))  ELSE Status  END, '-', '') AS Comment  ,* FROM  JCTGEN..JCT_OPS_PACKED_Status_Date ORDER BY Status  "
            Qry = "SELECT * FROM JCTGEN..LastUpdateReason  WHERE ReportType ='StatusDate'        "



        End If

        'Dim Dr As SqlDataReader = Obj.FetchReader(SqlPass)
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

            GridView2.DataSource = Nothing
            GridView2.DataBind()

            GridView3.DataSource = Nothing
            GridView3.DataBind()

             


 

        Catch ex As Exception

        Finally
            Obj.ConClose()
        End Try




        Dim Dr1 As SqlDataReader = Obj.FetchReader(Qry)
        Dim Da1 As SqlDataAdapter = New SqlDataAdapter(SqlPass, Obj.Connection())

        Try
            If Dr1.HasRows = True Then
                While Dr1.Read
                    lblName.Text = Dr1.Item(0)
                    lblTime.Text = Dr1.Item(1)
                End While
                Dr1.Close()

            End If


        Catch ex As Exception

        Finally
            Obj.ConClose()
        End Try
    End Sub



    Protected Sub BtnRefresh_Click(sender As Object, e As System.EventArgs) Handles BtnRefresh.Click

        If txtSalePerson.Text = "Status VS SalePerson" Then
            SqlPass = "EXEC JCTGEN..JCT_Packed_Stock_OPS_Reason  'Status' ,'SalePerson', ' " & Session("empname").ToString & " ' "
        ElseIf txtSalePerson.Text = "SalePerson VS Status" Then
            SqlPass = "EXEC JCTGEN..JCT_Packed_Stock_OPS_Reason  'SalePerson' ,'Status' , ' " & Session("empname").ToString & " ' "
        ElseIf txtSalePerson.Text = "CustomerName VS SalePerson" Then
            SqlPass = "EXEC JCTGEN..JCT_Packed_Stock_OPS_Reason  'CustomerName' ,'SalePerson' , ' " & Session("empname").ToString & " ' "
        ElseIf txtSalePerson.Text = "Status VS Date" Then
            SqlPass = "EXEC JCTGEN..JCT_Packed_Stock_OPS_Reason  'Status' ,'Date' , ' " & Session("empname").ToString & " '"
        End If

        Dim cmd As SqlCommand = New SqlCommand(SqlPass, Obj.Connection)
        cmd.CommandTimeout = 1000000
        Obj.ConOpen()
        cmd.ExecuteNonQuery()
        Obj.ConClose()




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
        GridViewExportUtil.Export("PackedStock.xls", GridView1)
    End Sub
    Protected Sub BtnExcel1_Click(sender As Object, e As System.EventArgs) Handles BtnExcel1.Click
        If txtSalePerson.Text = "Status VS Date" Then
            GridViewExportUtil.Export("PackedStockDay.xls", GridView2)
        End If
    End Sub

 

    Protected Sub GridView1_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If txtSalePerson.Text = "Status VS Date" Then
            e.Row.Cells(1).Visible = False
        End If

     


        If e.Row.RowType = DataControlRowType.DataRow Then


            If e.Row.Cells(0).Text = "COMPLETE PACKING" Or e.Row.Cells(0).Text = "INCOMPLETE PACKING" Or e.Row.Cells(0).Text = "LIABILITY STOCK" Or e.Row.Cells(0).Text = "EXCESS FABRIC" Or e.Row.Cells(0).Text = "FABRIC FOR INTERNAL CONSUMPTION" Or e.Row.Cells(0).Text = "NOT MAPPED" Or e.Row.Cells(0).Text = "ODS FABRIC" Or e.Row.Cells(0).Text = "ON HOLD STOCK" Or e.Row.Cells(0).Text = "QA STOCK" Or e.Row.Cells(0).Text = "RETURNED OR REJECTED FABRIC" Or e.Row.Cells(0).Text = "STOCKED FABRIC FOR FUTURE DISPATCHES" Then
                e.Row.ForeColor = Drawing.Color.Red
            End If

            If e.Row.Cells(0).Text = "[~Total~]" Then
                e.Row.ForeColor = Drawing.Color.Green
            End If

            If e.Row.Cells(1).Text = "0" Then
                e.Row.Cells(1).Text = ""
            End If

            If e.Row.Cells(2).Text = "0" Then
                e.Row.Cells(2).Text = ""
            End If


            If e.Row.Cells(3).Text = "0" Then
                e.Row.Cells(3).Text = ""
            End If


            If e.Row.Cells(4).Text = "0" Then
                e.Row.Cells(4).Text = ""
            End If


            If e.Row.Cells(5).Text = "0" Then
                e.Row.Cells(5).Text = ""
            End If


            If e.Row.Cells(6).Text = "0" Then
                e.Row.Cells(6).Text = ""
            End If


            If e.Row.Cells(7).Text = "0" Then
                e.Row.Cells(7).Text = ""
            End If


            If e.Row.Cells(8).Text = "0" Then
                e.Row.Cells(8).Text = ""
            End If


            If e.Row.Cells(9).Text = "0" Then
                e.Row.Cells(9).Text = ""
            End If


            If e.Row.Cells(10).Text = "0" Then
                e.Row.Cells(10).Text = ""
            End If


            If e.Row.Cells(11).Text = "0" Then
                e.Row.Cells(11).Text = ""
            End If


            If e.Row.Cells(12).Text = "0" Then
                e.Row.Cells(12).Text = ""
            End If



        End If


    End Sub




    Protected Sub GridView1_Sorting(sender As Object, e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GridView1.Sorting
        e.Cancel = True
        If IsNumeric(e.SortExpression) And txtSalePerson.Text = "Status VS Date" Then
            ViewState("Grid1") = e.SortExpression
            SqlPass = "EXEC JCTGEN..JCT_OPS_PACKSTOCK_REASON_COLUMN_DATE '" & e.SortExpression & "' "
            Dim cmd As SqlCommand = New SqlCommand(SqlPass, Obj.Connection)
            cmd.CommandTimeout = 1000000
            Obj.ConOpen()
            cmd.ExecuteNonQuery()
            Obj.ConClose()

            Qry = "SELECT * FROM  JCTGEN..JCT_OPS_PACKED_Status_Date_Day  ORDER BY  Status "
            PassStringII(Qry)

        End If
        e.Cancel = True
    End Sub
    Protected Sub PassStringII(ByVal Qry As String)
        Dim Da As SqlDataAdapter = New SqlDataAdapter(Qry, Obj.Connection())
        Da.SelectCommand.CommandTimeout = 0
        Try

            Dim ds As DataSet = New DataSet()
            ds.Clear()
            Da.Fill(ds)
            GridView2.DataSource = ds
            GridView2.DataBind()


            GridView3.DataSource = Nothing
            GridView3.DataBind()

        Catch ex As Exception

        Finally
            Obj.ConClose()
        End Try
    End Sub


    Protected Sub GridView2_Sorting(sender As Object, e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GridView2.Sorting

        Dim ClickValue As String = ViewState("Grid1").ToString

        Qry = "SELECT  Status ,  SalePerson , CustomerName , lot_no AS [Lot No] , CONVERT(VARCHAR, recd_date, 101) AS PackingDate , qty_recd AS Qty ,UpdateTime     FROM  JCTGEN..JCT_OPS_PACKSTOCK_REASON_DETAIL WHERE MONTH(recd_date) = RIGHT(" & ClickValue & " ,2)  AND  YEAR(recd_date) = LEFT(" & ClickValue & ",4) AND  DAY(RECD_DATE)='" & e.SortExpression & "' ORDER BY Status,RECD_DATE"
        Dim Da As SqlDataAdapter = New SqlDataAdapter(Qry, Obj.Connection())
        Da.SelectCommand.CommandTimeout = 0
        Try

            Dim ds As DataSet = New DataSet()
            ds.Clear()
            Da.Fill(ds)
            If ds.Tables(0).Rows.Count > 0 Then
                GridView3.DataSource = ds
                GridView3.DataBind()
            Else
                GridView3.DataSource = Nothing
            End If


        Catch ex As Exception

        Finally
            Obj.ConClose()
        End Try


    End Sub


    Protected Sub BtnExcel3_Click(sender As Object, e As System.EventArgs) Handles BtnExcel3.Click
        If txtSalePerson.Text = "Status VS Date" Then
            GridViewExportUtil.Export("PackedStockLot.xls", GridView3)
        End If
    End Sub
End Class