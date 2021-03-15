Imports System.Data.SqlClient
Imports System.Data


Partial Class OPS_SaleOrderAnalysis
    Inherits System.Web.UI.Page
    Dim obj As Connection = New Connection
    Dim ObjFun As Functions = New Functions
    Dim Query As String
    Dim ObjXl As GridViewExportUtil = New GridViewExportUtil
    Protected Sub CmdFetch_Click(sender As Object, e As System.EventArgs) Handles CmdFetch.Click
        'Query = "Exec production..Jct_Active_Order_RajeshKapoor '" & txtEff_From.Text & "','" & txtEff_To.Text & "'"
        'ObjFun.FillGrid(Query, GridView1)

        Query = "production..Jct_Active_Order_RajeshKapoor"
        Dim cmd As SqlCommand = New SqlCommand(Query, obj.Connection())
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandTimeout = 0
        cmd.Parameters.Add("@dtFrm", SqlDbType.VarChar, 20).Value = txtEff_From.Text
        cmd.Parameters.Add("@dtTo", SqlDbType.VarChar, 20).Value = txtEff_To.Text
        Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
        Dim ds As DataSet = New DataSet
        da.Fill(ds)
        GridView1.DataSource = ds.Tables(0)
        GridView1.DataBind()
        'ObjFun.FillGrid(Query, GridView1)


    End Sub

    Protected Sub CmdXl_Click(sender As Object, e As System.EventArgs) Handles CmdXl.Click
        ObjXl.Export("SalOrderAnalysis.xls", GridView1)
    End Sub
End Class
