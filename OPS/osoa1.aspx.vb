Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.UI.DataVisualization.Charting
Partial Class OPS_soa1
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
            Cust = Right(txtCustomer.Text, 5)
        Else
            Cust = ""
        End If

        Dim cn As SqlConnection = New SqlConnection(constr)
        sqlpass = "exec ops_statement_of_account_det  'JCT00LTD','PHG',1 ,'" & Cust & "','" & Cust & "','" & txtStartDate.Text & "' , '" & txtEndDate.Text & "'"
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
        Sqlpass = "select cust_no,cust_name,city,doc_no 'invoice_no',convert(varchar(10),doc_date,103) 'Invoice_dt',act_reasons 'adjust_reason',isnull(crdoc_no,' ')'perticular',isnull(convert(varchar(10),crdoc_dt,103),' ') 'perticulat_dt',isnull(inst_no,' ')'Chk_No',isnull(Convert(varchar,bal),' ') 'Adjust_Amt',isnull(Convert(varchar,debit),' ') 'Debit',isnull(Convert(varchar,credit),' ') 'Credit',isnull(Convert(varchar,prev_uptodate),'') 'Balance' FROM ops_customer_statement_of_account  order by serial"
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
        GridViewExportUtil.Export("soa.xls", Me.GridView1)
    End Sub
    Protected Sub LnkClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LnkClose.Click
        Response.Redirect("default.aspx")
        Me.Visible = False
    End Sub
End Class
