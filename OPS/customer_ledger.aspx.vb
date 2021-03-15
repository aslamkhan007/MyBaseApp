Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.UI.DataVisualization.Charting
Partial Class OPS_customer_ledger
    Inherits System.Web.UI.Page
    Dim sql As String
    Dim dr As SqlDataReader
    Dim cmd As SqlCommand
    Dim obj As New MiserpCon
    Dim obj2 As New Functions
    Dim sqlpass, sno2 As String, Cust As String
    Dim scrpt_str As String
    Dim Ash, sno1 As Integer
    Dim constr As String = System.Web.Configuration.WebConfigurationManager.ConnectionStrings("arconnectionString").ConnectionString

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Protected Sub LnkView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LnkView.Click
        If Len(Trim(txtCustomer.Text)) > 0 Then
            'Cust = Trim(Mid(txtCustomer.Text, 1, txtCustomer.Text.IndexOf("~")))
            Cust = Right(txtCustomer.Text, 6)
        Else
            Cust = ""
        End If

        Dim cn As SqlConnection = New SqlConnection(constr)
        sqlpass = "exec ops_jct_ar_cust_ledger_new2  'JCT00LTD','PHG',1 ,'" & Cust & "','" & Cust & "','" & txtStartDate.Text & "' , '" & txtEndDate.Text & "'"
        Dim cmd As SqlCommand = New SqlCommand(sqlpass, cn)
        cmd.CommandTimeout = 0
        cn.Open()
        cmd.ExecuteNonQuery()
        sqlpass = ""

        BindData()
    End Sub

    Public Sub BindData()

        Dim Sqlpass As String
        'Sqlpass = "select cust_no,cust_name,city,doc_no 'invoice_no',convert(varchar(10),doc_date,103) 'Invoice_dt',act_reasons 'adjust_reason',sale_remarks,isnull(crdoc_no,' ')'perticular',isnull(convert(varchar(10),crdoc_dt,103),' ') 'perticulat_dt',isnull(inst_no,' ')'Chk_No',isnull(debit,0.0) 'Debit',isnull(credit,0.0) 'Credit',isnull(prev_uptodate,0.0)'Balance' FROM ops_customer_statement_of_account "
        'Sqlpass = "select cust_no, cust_name, cust_city,auth_no 'Tran No',Convert(varchar(10), tran_date, 103) 'Tran Dt',act_deduction_reason 'adjust_reason',sale_remarks,crdoc_no 'DocNo',isnull(inst_no,' ')'Chk_No',isnull(convert(varchar(10),inst_date,103),' ') 'Chk_dt',isnull(Convert(varchar,act_reason_amount),' ') 'Adjust_Amt',isnull(Convert(varchar,opening),' ') 'Opening',isnull(Convert(varchar,debit),' ') 'Debit',isnull(Convert(varchar,credit),' ') 'Credit',isnull(Convert(varchar,balance),' ') 'Balance' from jct_ops_customer_ledger   where host_id = host_id() order by ref_no1"

        Sqlpass = "SELECT  ISNULL(cust_no, '') + ' ' + ISNULL(cust_name, '') + '    '+ ISNULL(cust_city, '') AS Customer , ISNULL(CONVERT(VARCHAR(10), tran_date, 103), ' ') 'Invoice_dt' ,  ISNULL(auth_no, '') 'Invoice_no' ,  ISNULL(inst_no, ' ') 'Chk_No' ,  ISNULL(CONVERT(VARCHAR(10), inst_date, 103), ' ') 'Chk_dt' ,  ISNULL(CONVERT(VARCHAR, debit), ' ') 'Debit' ,  ISNULL(CONVERT(VARCHAR, credit), ' ') 'Credit' ,  ISNULL(CONVERT(VARCHAR, balance), ' ') 'Balance' ,  CASE WHEN balance > 0 THEN 'DR'  ELSE CASE WHEN balance < 0 THEN 'CR'  ELSE ''  End END AS CR_DR FROM jct_ops_customer_ledger WHERE(HOST_ID = HOST_ID())  ORDER BY ref_no1 "

        Dim conn = New SqlConnection(constr)
        conn.Open()
        Dim cmd As SqlCommand = New SqlCommand(Sqlpass, conn)
        'cmd.ExecuteNonQuery()
        Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
        Dim ds As DataSet = New DataSet()
        da.Fill(ds)
        GridView1.DataSource = ds
        GridView1.DataBind()
        conn.Close()

    End Sub
    Protected Sub LnkExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LnkExcel.Click
        ' GridViewExportUtil.Export("ledger.xls", Me.GridView1)


        Dim Sqlpass As String
        'Sqlpass = "select cust_no,cust_name,city,doc_no 'invoice_no',convert(varchar(10),doc_date,103) 'Invoice_dt',act_reasons 'adjust_reason',sale_remarks,isnull(crdoc_no,' ')'perticular',isnull(convert(varchar(10),crdoc_dt,103),' ') 'perticulat_dt',isnull(inst_no,' ')'Chk_No',isnull(debit,0.0) 'Debit',isnull(credit,0.0) 'Credit',isnull(prev_uptodate,0.0)'Balance' FROM ops_customer_statement_of_account "
        'Sqlpass = "select cust_no, cust_name, cust_city,auth_no 'Tran No',Convert(varchar(10), tran_date, 103) 'Tran Dt',act_deduction_reason 'adjust_reason',sale_remarks,isnull(inst_no,' ')'Chk_No',isnull(convert(varchar(10),inst_date,103),' ') 'Chk_dt',isnull(Convert(varchar,opening),' ') 'Opening',isnull(Convert(varchar,act_reason_amount),' ') 'Adjust_Amt' ,isnull(Convert(varchar,debit),' ') 'Debit',isnull(Convert(varchar,credit),' ') 'Credit',isnull(Convert(varchar,balance),' ') 'Balance' from jct_ops_customer_ledger   where host_id = host_id() order by ref_no1"
        Sqlpass = "SELECT  ISNULL(cust_no, '') + ' ' + ISNULL(cust_name, '') + '    '+ ISNULL(cust_city, '') AS Customer , ISNULL(CONVERT(VARCHAR(10), tran_date, 103), ' ') 'Invoice_dt' ,  ISNULL(auth_no, '') 'Invoice_no' ,  ISNULL(inst_no, ' ') 'Chk_No' ,  ISNULL(CONVERT(VARCHAR(10), inst_date, 103), ' ') 'Chk_dt' ,  ISNULL(CONVERT(VARCHAR, debit), ' ') 'Debit' ,  ISNULL(CONVERT(VARCHAR, credit), ' ') 'Credit' ,  ISNULL(CONVERT(VARCHAR, balance), ' ') 'Balance' ,  CASE WHEN balance > 0 THEN 'DR'  ELSE CASE WHEN balance < 0 THEN 'CR'  ELSE ''  End END AS CR_DR FROM jct_ops_customer_ledger WHERE(HOST_ID = HOST_ID())  ORDER BY ref_no1 "
        Dim conn = New SqlConnection(constr)
        conn.Open()
        Dim cmd As SqlCommand = New SqlCommand(Sqlpass, conn)
        'cmd.ExecuteNonQuery()
        Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
        Dim ds As DataSet = New DataSet()
        da.Fill(ds)
        Dim dt As DataTable = ds.Tables(0)


        Dim attachment As String = "attachment; filename=ledger.xls"
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
        obj.ConClose()


    End Sub
    Protected Sub LnkClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LnkClose.Click
        Response.Redirect("default.aspx")
        Me.Visible = False
    End Sub
End Class
