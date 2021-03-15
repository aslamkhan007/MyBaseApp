
Imports System.Data
Imports System.Data.SqlClient


Partial Class EmpGateway_retailpunch_rpt
    Inherits System.Web.UI.Page
    Dim Obj As New Connection, Cmd As New SqlCommand, Dr As SqlDataReader, da As SqlDataAdapter, ds As DataSet, Sql As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub cmdview_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdview.Click
        GetData()
    End Sub

    Protected Sub cmdXL_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdXL.Click
        GridViewExportUtil.Export("XL.xls", GridView1)
    End Sub

    Protected Sub GetData()

        Sql = "JCT_Retail_Punch_Rpt"
        Cmd = New SqlCommand(Sql, Obj.Connection())

        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandTimeout = 0

        Cmd.Parameters.Add("@SDate", SqlDbType.SmallDateTime).Value = Me.TxtEffFrom.Text
        Cmd.Parameters.Add("@EDate", SqlDbType.SmallDateTime).Value = Me.TxtEffTo.Text
        Cmd.Parameters.Add("@RtlType", SqlDbType.Char, 5).Value = Me.ddlstype.Text
        Cmd.Parameters.Add("@CardNo", SqlDbType.Char, 20).Value = Me.txtCardNo.Text

        da = New SqlDataAdapter(cmd)
        ds = New DataSet()

        da.Fill(ds)
        GridView1.DataSource = ds.Tables(0)
        GridView1.DataBind()

    End Sub


    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GridView1.PageIndex = e.NewPageIndex
        GetData()

    End Sub
End Class
