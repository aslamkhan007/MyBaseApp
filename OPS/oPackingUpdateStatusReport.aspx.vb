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

            If Session("empcode").ToString = "H-01436" Or Session("empcode").ToString = "R-03339" Or Session("empcode").ToString = "N-02643" Then
                BtnRefresh.Enabled = True
            Else
                BtnRefresh.Enabled = False
            End If

        End If
    End Sub





    Protected Sub BtnGet_Click(sender As Object, e As System.EventArgs) Handles BtnGet.Click
        If txtSalePerson.Text = "Status VS SalePerson" Then
            SqlPass = "SELECT * FROM  JCTGEN..JCT_OPS_PACKED_Status_SalePerson  ORDER BY  Status "

        ElseIf txtSalePerson.Text = "SalePerson VS Status" Then
            SqlPass = "SELECT * FROM JCTGEN..JCT_OPS_PACKED_SalePerson_Status ORDER BY  SalePerson "

        ElseIf txtSalePerson.Text = "CustomerName VS SalePerson" Then

            SqlPass = "SELECT * FROM  JCTGEN..JCT_OPS_PACKED_CustomerName_SalePerson ORDER BY CustomerName"
        ElseIf txtSalePerson.Text = "Status VS Date" Then

            SqlPass = "SELECT * FROM  JCTGEN..JCT_OPS_PACKED_Status_Date ORDER BY Status  "



        End If

        'Dim Dr As SqlDataReader = Obj.FetchReader(SqlPass)

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

        If txtSalePerson.Text = "Status VS SalePerson" Then
            SqlPass = "EXEC JCTGEN..JCT_Packed_Stock_OPS_Reason  'Status' ,'SalePerson' "
        ElseIf txtSalePerson.Text = "SalePerson VS Status" Then
            SqlPass = "EXEC JCTGEN..JCT_Packed_Stock_OPS_Reason  'SalePerson' ,'Status' "
        ElseIf txtSalePerson.Text = "CustomerName VS SalePerson" Then
            SqlPass = "EXEC JCTGEN..JCT_Packed_Stock_OPS_Reason  'CustomerName' ,'SalePerson' "
        ElseIf txtSalePerson.Text = "Status VS Date" Then
            SqlPass = "EXEC JCTGEN..JCT_Packed_Stock_OPS_Reason  'Status' ,'Date' "
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

End Class