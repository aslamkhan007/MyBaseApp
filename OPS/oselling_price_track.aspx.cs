using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class OPS_selling_price_track : System.Web.UI.Page
{
    Connection obj = new Connection();

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void fetch_Click(object sender, EventArgs e)
    {
        Panel1.Visible = true;
        ////if (txtorderdateto.Text== "" || txtorderdatefrm.Text== "" || txtorder.Text == "" || txtsort.Text =="" || txtdeldateto.Text== "" || txtdeldatefrm.Text =="")
        ////{
        ////}
        ////else
        //{
            SqlCommand cmd = new SqlCommand("jct_ops_selling_price_dnv_track", obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 0;
            cmd.Parameters.Add("@DateFrom ", SqlDbType.VarChar, 20).Value = txtorderdatefrm.Text;
            cmd.Parameters.Add("@DateTo ", SqlDbType.VarChar, 20).Value = txtorderdateto.Text;
            cmd.Parameters.Add("@DelDateFrom", SqlDbType.VarChar, 20).Value = txtdeldatefrm.Text;
            cmd.Parameters.Add("@DelDateTo  ", SqlDbType.VarChar, 20).Value = txtdeldateto.Text;
            cmd.Parameters.Add("@SortNo", SqlDbType.VarChar, 10).Value = txtsort.Text;
            cmd.Parameters.Add("@OrderNo ", SqlDbType.VarChar, 16).Value = txtorder.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            grdDetail.DataSource = ds.Tables[0];
            grdDetail.DataBind();
       // }

    }
    private void gridbind()
    {
        SqlCommand cmd = new SqlCommand("jct_ops_selling_price_dnv_track", obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 0;
        cmd.Parameters.Add("@DateFrom ", SqlDbType.VarChar, 20).Value = txtorderdatefrm.Text;
        cmd.Parameters.Add("@DateTo ", SqlDbType.VarChar, 20).Value = txtorderdateto.Text;
        cmd.Parameters.Add("@DelDateFrom", SqlDbType.VarChar, 20).Value = txtdeldatefrm.Text;
        cmd.Parameters.Add("@DelDateTo  ", SqlDbType.VarChar, 20).Value = txtdeldateto.Text;
        cmd.Parameters.Add("@SortNo", SqlDbType.VarChar, 10).Value = txtsort.Text;
        cmd.Parameters.Add("@OrderNo ", SqlDbType.VarChar, 16).Value = txtorder.Text;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        grdDetail.DataSource = ds.Tables[0];
        grdDetail.DataBind();
     
        
    }
    protected void reset_Click(object sender, EventArgs e)
    {
        txtorder.Text = " ";
        txtsort.Text = " ";
        txtorderdatefrm .Text= " ";
       txtorderdateto.Text = " ";
        txtdeldateto.Text = " ";
        txtdeldatefrm.Text = " ";
        txtorder.Text = " ";
        txtsort.Text = " ";
    }

    protected void grdDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        grdDetail.PageIndex = e.NewPageIndex;
        gridbind();

    }
    protected void excel_Click(object sender, EventArgs e)
    {
        SqlCommand cmd = new SqlCommand("jct_ops_selling_price_dnv_track", obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 0;
        cmd.Parameters.Add("@DateFrom ", SqlDbType.VarChar, 20).Value = txtorderdatefrm.Text;
        cmd.Parameters.Add("@DateTo ", SqlDbType.VarChar, 20).Value = txtorderdateto.Text;
        cmd.Parameters.Add("@DelDateFrom", SqlDbType.VarChar, 20).Value = txtdeldatefrm.Text;
        cmd.Parameters.Add("@DelDateTo  ", SqlDbType.VarChar, 20).Value = txtdeldateto.Text;
        cmd.Parameters.Add("@SortNo", SqlDbType.VarChar, 10).Value = txtsort.Text;
        cmd.Parameters.Add("@OrderNo ", SqlDbType.VarChar, 16).Value = txtorder.Text;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        grdDetail.DataSource = ds.Tables[0];
        grdDetail.DataBind();
        DataTable dt = ds.Tables[0];

        string attachment = "attachment; filename=OrderProductionTracking.xls";
        Response.ClearContent();
        Response.AddHeader("content-disposition", attachment);
        Response.ContentType = "application/vnd.ms-excel";
        string tab = "";
        foreach (DataColumn dc in dt.Columns)
        {
            Response.Write(tab + dc.ColumnName);
            tab = "\t";
        }
        Response.Write("\n");
        int i;
        foreach (DataRow dr in dt.Rows)
        {
            tab = "";
            for (i = 0; i < dt.Columns.Count; i++)
            {
                Response.Write(tab + dr[i].ToString());
                tab = "\t";
            }
            Response.Write("\n");
        }
        Response.End(); 

    }
}