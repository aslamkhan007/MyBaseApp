using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class OPS_DispatchDetails : System.Web.UI.Page
{
    Connection obj = new Connection();
    Functions obj1 = new Functions();
    string sql;
    decimal InvoiceQty=0, InvoiceValue=0;
    protected void Page_Load(object sender, EventArgs e)
    {

        String OrderNo = Request.QueryString["OrderNo"];

        String LineItem = Request.QueryString["LineItem"];

        sql = "JCT_OPS_ORDER_DISPATCH_DETAILS";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());

        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 0;

        cmd.Parameters.Add("@Order", SqlDbType.VarChar, 30).Value = OrderNo;
        cmd.Parameters.Add("@LineItem", SqlDbType.Int).Value = Convert.ToInt16(LineItem);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();

        da.Fill(ds);
        GridView1.DataSource = ds.Tables[0];
        GridView1.DataBind();
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            InvoiceQty = InvoiceQty + Convert.ToDecimal(e.Row.Cells[5].Text);
            InvoiceValue = InvoiceValue + Convert.ToDecimal(e.Row.Cells[10].Text);
        }
        else if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[4].Text = "Total";
            e.Row.Cells[5].Text = Convert.ToString(InvoiceQty);
            e.Row.Cells[10].Text = Convert.ToString(InvoiceValue);
        }
    }
}