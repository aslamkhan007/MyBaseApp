Imports System.Data
Imports System.Data.SqlClient
Partial Class Excess_material_Issued
    Inherits System.Web.UI.Page
    Dim cmd, cmd1 As SqlCommand
    Dim sqlquery1, sqlpass, pid As String
    Dim da As SqlDataAdapter
    Dim ds As DataSet
    Dim obj As New MiserpCon
    Dim obj2 As New Functions
    'Dim cn As SqlConnection = New SqlConnection(constr)
    Dim constr As String = System.Web.Configuration.WebConfigurationManager.ConnectionStrings("misjctdev").ConnectionString
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'ScriptManager.GetCurrent(Page).AsyncPostBackTimeout = 500

    End Sub
    Protected Sub btnfetch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnfetch.Click
        ' GridView1.Visible = False
        'GridView2.Visible = False

        Dim cn As SqlConnection = New SqlConnection(constr)
        cn.Open()
        sqlpass = " exec Jct_issue_slip_excess_authorise '" & txtfromdate.Text & "' ,'" & todate.Text & "', '" & ddlstocktype.SelectedItem.Text & "'"
        Dim cmd As SqlCommand = New SqlCommand(sqlpass, cn)
        cmd.CommandTimeout = 0
        cmd.ExecuteNonQuery()
        sqlpass = ""
        BindData()
        cn.Close()
    End Sub

    Public Sub BindData()

        If (ddlstocktype.SelectedItem.Text = "ALL") Then
            sqlpass = " select description as 'Description' , stock_no as  'StockNo' , variant_no as 'Variant' ,sum(Convert(numeric(15,3),requested_quantity)) as 'RequestQty' , sum(Convert(numeric(15,3),authorised_quantity))  as 'AuthorisedQty', sum(Convert(numeric(15,3),issued_quantity)) as  'IssuedQty'  from jct_ecess_material_authorise_in_issue_slip   group by description, variant_no,stock_no order by description"
            Dim cn = New SqlConnection(constr)

            cn.Open()
            Dim cmd As SqlCommand = New SqlCommand(sqlpass, cn)
            Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim ds As DataSet = New DataSet()
            da.Fill(ds)
            GridView1.DataSource = ds
            GridView1.DataBind()
            cn.Close()
        Else
            sqlpass = " select description as 'Description' , stock_no as  'StockNo' , variant_no as 'Variant' ,sum(Convert(numeric(15,3),requested_quantity)) as 'RequestQty' , sum(Convert(numeric(15,3),authorised_quantity))  as 'AuthorisedQty', sum(Convert(numeric(15,3),issued_quantity)) as  'IssuedQty'  from jct_ecess_material_authorise_in_issue_slip  where left(stock_no,2)='" & ddlstocktype.SelectedItem.Text & "' group by description, variant_no,stock_no order by description   "
            Dim cn = New SqlConnection(constr)
            cn.Open()
            Dim cmd As SqlCommand = New SqlCommand(sqlpass, cn)
            Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim ds As DataSet = New DataSet()
            da.Fill(ds)
            GridView1.DataSource = ds
            GridView1.DataBind()
            cn.Close()
        End If
    End Sub
    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged
        'Dim con As String
        'Dim pid As String
        Dim ds As DataSet
        Dim sqladp As SqlDataAdapter


        Dim cn As SqlConnection = New SqlConnection(constr)
        cn.Open()
        pid = GridView1.SelectedRow.Cells(2).Text.ToString()
        sqladp = New SqlDataAdapter("select mr_no as 'MrNo',Convert(varchar(10),mr_date,101) as 'Date',ma_center_ldesc as 'Cost Center', stock_no as 'StockNo',description as 'Description',variant_no as 'Variant',stock_uom as 'UNIT' ,convert(numeric(15,3),requested_quantity) as 'RequestedQty',convert(numeric(15,3),authorised_quantity) as 'AutorisedQty', convert(numeric(15,3),issued_quantity)  as  'IssuedQty'   from jct_ecess_material_authorise_in_issue_slip  where stock_no = '" & pid.ToString() & "' ", cn)
        ds = New DataSet()

        sqladp.Fill(ds)
        GridView2.DataSource = ds
        GridView2.DataBind()
        GridView2.Visible = True
        GridView1.Visible = True
        cn.Close()
    End Sub
    Protected Sub btnclose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnclose.Click
        Response.Redirect("default.aspx")
        Me.Visible = False
    End Sub
    Protected Sub btnexcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnexcel.Click
        'Dim Sqlpass As String
        'Sqlpass = "select cust_no,cust_name,city,doc_no 'invoice_no',convert(varchar(10),doc_date,103) 'Invoice_dt',act_reasons 'adjust_reason',sale_remarks,isnull(crdoc_no,' ')'perticular',isnull(convert(varchar(10),crdoc_dt,103),' ') 'perticulat_dt',isnull(inst_no,' ')'Chk_No',isnull(debit,0.0) 'Debit',isnull(credit,0.0) 'Credit',isnull(prev_uptodate,0.0)'Balance' FROM ops_customer_statement_of_account "

        Dim cn = New SqlConnection(constr)
        cn.Open()
        pid = GridView1.SelectedRow.Cells(2).Text.ToString()
        sqlpass = "select mr_no as 'MrNo',Convert(varchar(10),mr_date,101) as 'Date',ma_center_ldesc as 'Cost Center', stock_no as 'StockNo',description as 'Description',variant_no as 'Variant',stock_uom as 'UNIT' ,convert(numeric(15,3),requested_quantity) as 'RequestedQty',convert(numeric(15,3),authorised_quantity) as 'AutorisedQty', convert(numeric(15,3),issued_quantity)  as  'IssuedQty'   from jct_ecess_material_authorise_in_issue_slip  where   stock_no  = '" & pid.ToString() & "' "

        Dim cmd As SqlCommand = New SqlCommand(sqlpass, cn)
        cmd.ExecuteNonQuery()
        Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
        Dim ds As DataSet = New DataSet()
        da.Fill(ds)
        Dim dt As DataTable = ds.Tables(0)


        Dim attachment As String = "attachment; filename=excessissue.xls"
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
        cn.Close()
    End Sub
End Class
