Imports System.Data
Imports System.Data.SqlClient
Imports System
Partial Class OPS_Default2
    Inherits System.Web.UI.Page
    Dim ShpConStr As String = System.Web.Configuration.WebConfigurationManager.ConnectionStrings("shpConnectionString").ConnectionString
    Dim SomConStr As String = System.Web.Configuration.WebConfigurationManager.ConnectionStrings("SOMConnectionString").ConnectionString
    Dim Obj As Connection = New Connection(ShpConStr)
    Dim SomCon As Connection = New Connection(SomConStr)
    Dim Cmd As New SqlCommand
    Dim SqlPass, Qry As String
   





    Protected Sub BtnGet_Click(sender As Object, e As System.EventArgs) Handles BtnGet.Click
         

        SqlPass = "SELECT  CustNo ,CustName , OrderNo , UPPER(SalePersonName) AS SalePersonName , invoice_no AS InvoiceNo ,CONVERT(VARCHAR,invoice_dt,106) AS InvoiceDate ," & _
        "CASE WHEN invoice_net_amt > 0 THEN CONVERT(VARCHAR, CONVERT(NUMERIC, invoice_net_amt))       ELSE ''  END AS InvoiceAmt ,  " & _
        " CASE WHEN GetAmount > 0       THEN CONVERT(VARCHAR, CONVERT(NUMERIC, GetAmount))             ELSE ''  END AS TotalAmt , " & _
        " CASE WHEN OthAmt > 0 THEN CONVERT(VARCHAR, CONVERT(NUMERIC, OthAmt))      ELSE ''      END AS BankReceipt , " & _
        " CASE WHEN CredAmt > 0 THEN CONVERT(VARCHAR, CONVERT(NUMERIC, CredAmt))       ELSE ''      END AS CredAmt , " & _
        " CASE WHEN outstanding_amt > 0         THEN CONVERT(VARCHAR, CONVERT(NUMERIC, outstanding_amt))     ELSE ''  END AS Outstanding " & _
        "   FROM    shp..Combine_Invoice_OPS_Detail WHERE   ISNULL(outstanding_amt, 0) > 0 ORDER BY invoice_dt ,    CustNo"




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


     
     
    Protected Sub BtnExcel_Click(sender As Object, e As System.EventArgs) Handles BtnExcel.Click
        GridViewExportUtil.Export("Invoice Wise Outstanding.xls", GridView1)
    End Sub

    Protected Sub btnAgeing_Click(sender As Object, e As System.EventArgs) Handles btnAgeing.Click
        SqlPass = "jct_ops_invoice_outstanding_age"
        Dim cmd As SqlCommand = New SqlCommand(SqlPass, SomCon.Connection())
        cmd.CommandType = CommandType.StoredProcedure
        Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
        Dim ds As DataSet = New DataSet()
        da.Fill(ds)
        GridView1.DataSource = ds.Tables(0)
        GridView1.DataBind()
    End Sub
End Class
