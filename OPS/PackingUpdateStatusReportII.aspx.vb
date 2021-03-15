Imports System.Data
Imports System.Data.SqlClient
Imports System
Partial Class PackingUpdateStatusReportII
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
            If Session("empcode").ToString = "H-01436" Or Session("empcode").ToString = "R-03339" Or Session("empcode").ToString = "N-02643" Or Session("empcode").ToString = "G-01344" Or Session("empcode").ToString = "N-02644" Then

            Else

            End If
        Else
            Response.Redirect("~/login.aspx")
        End If
        If Not IsPostBack Then

        Else

            If Session("empcode").ToString = "H-01436" Or Session("empcode").ToString = "R-03339" Or Session("empcode").ToString = "N-02643" Or Session("empcode").ToString = "G-01344" Or Session("empcode").ToString = "N-02644" Then

            Else

            End If

        End If
    End Sub





    Protected Sub BtnGet_Click(sender As Object, e As System.EventArgs) Handles BtnGet.Click
        If txtType.Text = "Status VS SalePerson" Then
            SqlPass = "SELECT * FROM  JCTGEN..JCT_OPS_PACKED_Status_SalePersonII  ORDER BY  Status "
            Qry = "SELECT * FROM JCTGEN..LastUpdateReasonII  WHERE ReportType ='StatusSalePerson'         "

        ElseIf txtType.Text = "SalePerson VS Status" Then
            SqlPass = "SELECT * FROM JCTGEN..JCT_OPS_PACKED_SalePerson_StatusII ORDER BY  SalePerson "
            Qry = "SELECT * FROM JCTGEN..LastUpdateReasonII  WHERE ReportType ='SalePersonStatus'         "

        ElseIf txtType.Text = "CustomerName VS SalePerson" Then

            SqlPass = "SELECT * FROM  JCTGEN..JCT_OPS_PACKED_CustomerName_SalePersonII ORDER BY CustomerName"
            Qry = "SELECT * FROM JCTGEN..LastUpdateReasonII  WHERE ReportType ='CustomerNameSalePerson'         "

        ElseIf txtType.Text = "Status VS Date" Then

            SqlPass = "SELECT REPLACE(CASE WHEN CHARINDEX('--', Status) > 0 AND CHARINDEX('--', Status) + 1 <> LEN(STATUS)  THEN '=>' + SUBSTRING(status, CHARINDEX('--', Status) + 2,    LEN(Status))  ELSE Status  END, '-', '') AS Comment  ,* FROM  JCTGEN..JCT_OPS_PACKED_Status_DateII ORDER BY Status  "
            Qry = "SELECT * FROM JCTGEN..LastUpdateReasonII  WHERE ReportType ='StatusDate'        "



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

        If txtType.Text = "Status VS SalePerson" Then
            SqlPass = "EXEC JCTGEN..JCT_Packed_Stock_OPS_ReasonII  'Status' ,'SalePerson', '" & Trim(txtSalePerson.Text) & "' "

        ElseIf txtType.Text = "SalePerson VS Status" Then
            SqlPass = "EXEC JCTGEN..JCT_Packed_Stock_OPS_ReasonII  'SalePerson' ,'Status' ,  '" & Trim(txtSalePerson.Text) & "' "

        ElseIf txtType.Text = "CustomerName VS SalePerson" Then
            SqlPass = "EXEC JCTGEN..JCT_Packed_Stock_OPS_ReasonII  'CustomerName' ,'SalePerson' ,  '" & Trim(txtSalePerson.Text) & "' "

        ElseIf txtType.Text = "Status VS Date" Then
            SqlPass = "EXEC JCTGEN..JCT_Packed_Stock_OPS_ReasonII  'Status' ,'Date' , '" & Trim(txtSalePerson.Text) & "' "

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
        If txtType.Text = "Status VS Date" Then
            GridViewExportUtil.Export("PackedStockDay.xls", GridView2)
        End If
    End Sub

    Protected Sub GridView1_CellClicked(sender As Object, e As CustomControls.GridViewCellClickedEventArgs) Handles GridView1.CellClicked

        If e.Row.Cells(1).Text <> "[~Total~]" Then

            If e.Row.Cells(0).Text = "COMPLETE PACKING" Or e.Row.Cells(0).Text = "INCOMPLETE PACKING" Or e.Row.Cells(0).Text = "LIABILITY STOCK" Or e.Row.Cells(0).Text = "ON HOLD STOCK" Or e.Row.Cells(0).Text = "QA STOCK" Or e.Row.Cells(0).Text = "RETURNED OR REJECTED FABRIC" Or e.Row.Cells(0).Text = "STOCKED FABRIC FOR FUTURE DISPATCHES" Then
                If txtType.Text = "Status VS Date" Then

                    SqlPass = "EXEC JCTGEN..JCT_OPS_PACKSTOCK_REASON_COLUMN_DATEII '" & e.HeaderText & "',  '" & e.Row.Cells(1).Text & "'  "
                    Dim cmd As SqlCommand = New SqlCommand(SqlPass, Obj.Connection)
                    cmd.CommandTimeout = 1000000
                    Obj.ConOpen()
                    cmd.ExecuteNonQuery()
                    Obj.ConClose()

                    Qry = "SELECT * FROM  JCTGEN..JCT_OPS_PACKED_Status_Date_DayII  ORDER BY  Status "
                    PassStringII(Qry)
                    ViewState("Year") = e.HeaderText
                End If
            Else

                If txtType.Text = "Status VS Date" Then

                    SqlPass = "EXEC JCTGEN..JCT_OPS_PACKSTOCK_REASON_COLUMN_DATEII '" & e.HeaderText & "',   '" & e.Row.Cells(1).Text & "' "
                    Dim cmd As SqlCommand = New SqlCommand(SqlPass, Obj.Connection)
                    cmd.CommandTimeout = 1000000
                    Obj.ConOpen()
                    cmd.ExecuteNonQuery()
                    Obj.ConClose()

                    Qry = "SELECT * FROM  JCTGEN..JCT_OPS_PACKED_Status_Date_DayII  ORDER BY  Status "
                    PassStringII(Qry)
                    ViewState("Year") = e.HeaderText
                End If

            End If
        Else
            ViewState("Year") = ""

        End If
    End Sub


    Protected Sub GridView1_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If txtType.Text = "Status VS Date" Then
            e.Row.Cells(1).Visible = False

        End If





        If e.Row.RowType = DataControlRowType.DataRow Then




            If e.Row.Cells(0).Text = "COMPLETE PACKING" Or e.Row.Cells(0).Text = "INCOMPLETE PACKING" Or e.Row.Cells(0).Text = "LIABILITY STOCK" Or e.Row.Cells(0).Text = "EXCESS FABRIC" Or e.Row.Cells(0).Text = "FABRIC FOR INTERNAL CONSUMPTION" Or e.Row.Cells(0).Text = "NOT MAPPED" Or e.Row.Cells(0).Text = "ODS FABRIC" Or e.Row.Cells(0).Text = "ON HOLD STOCK" Or e.Row.Cells(0).Text = "QA STOCK" Or e.Row.Cells(0).Text = "RETURNED OR REJECTED FABRIC" Or e.Row.Cells(0).Text = "STOCKED FABRIC FOR FUTURE DISPATCHES" Or e.Row.Cells(0).Text = "REMNANT FABRIC" Then
                e.Row.ForeColor = Drawing.Color.Red
            Else

            End If

            If e.Row.Cells(0).Text = "EXCESS FABRIC" Or e.Row.Cells(0).Text = "FABRIC FOR INTERNAL CONSUMPTION" Or e.Row.Cells(0).Text = "NOT MAPPED" Or e.Row.Cells(0).Text = "ODS FABRIC" Then


            End If

            If e.Row.Cells(0).Text = "[~Total~]" Then
                e.Row.ForeColor = Drawing.Color.Green
            End If



            For Each I As Integer In GridView1.Columns
                If e.Row.Cells(I).Text = "0" Then
                    e.Row.Cells(I).Text = ""
                End If
            Next


 


        End If


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





    Protected Sub BtnExcel3_Click(sender As Object, e As System.EventArgs) Handles BtnExcel3.Click
        If txtType.Text = "Status VS Date" Then
            GridViewExportUtil.Export("PackedStockLot.xls", GridView3)
        End If
    End Sub

    Protected Sub GridView2_CellClicked(sender As Object, e As CustomControls.GridViewCellClickedEventArgs) Handles GridView2.CellClicked
        Qry = "SELECT  Status ,  SalePerson , CustomerName , lot_no AS [Lot No] , CONVERT(VARCHAR, recd_date, 101) AS PackingDate , qty_recd AS Qty , Shade , stock_no AS Item ,ISNULL(Advance,0) AS Advance,UpdateTime     FROM  JCTGEN..JCT_OPS_PACKSTOCK_REASON_DETAILII WHERE MONTH(recd_date) = RIGHT(" & ViewState("Year") & " ,2)  AND  YEAR(recd_date) = LEFT(" & ViewState("Year") & ",4) AND  DAY(RECD_DATE)='" & e.HeaderText & "' AND  Status='" & e.Row.Cells(0).Text & " ' ORDER BY Status,RECD_DATE"
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

    Protected Sub GridView3_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView3.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then

            If e.Row.Cells(8).Text = "0" Then
                e.Row.Cells(8).Text = ""
            Else


                e.Row.ForeColor = Drawing.Color.Red
            End If
        End If
    End Sub
End Class