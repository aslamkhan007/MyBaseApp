using System;
using System.Linq;
using System.Data;
using System.Data.SqlClient;

public partial class OPS_sanctionnotedetail : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(@"Data Source=MISDEV;Initial Catalog=jctgen;Persist Security Info=True;User ID=itgrp;Password=power;Connect Timeout = 100000;");
    Connection ObjCon=new Connection();


    protected void Page_Load(object sender, EventArgs e)
    {
        

    }
    
    protected void grdDetail_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void reset_Click(object sender, EventArgs e)
    {
      
        Response.Redirect("~/ops/sanctionnotedetail.aspx");
    }
    protected void lnkFetch_Click(object sender, EventArgs e)
    {
     //SqlConnection con = new SqlConnection(@"Data Source=TEST2K;Initial Catalog=jctdev1;User ID=trainee ;password=trainee");

        SqlCommand cmd = new SqlCommand("Jct_Ops_SanctionNote_Analysis", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@sanctionnoteid ", SqlDbType.VarChar, 14).Value = txtsanction.Text;
            cmd.Parameters.Add("@usercode", SqlDbType.VarChar, 30).Value = txtusercode.Text;
            cmd.Parameters.Add("@areacode", SqlDbType.VarChar, 20).Value = ddlselectares.SelectedItem.Value;
            cmd.Parameters.Add("@datefrom", SqlDbType.DateTime).Value = txtdatefrom.Text;
            cmd.Parameters.Add("@dateto", SqlDbType.DateTime).Value = txtdateto.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            grdDetail.DataSource = ds.Tables[0];
            grdDetail.DataBind();
        }
    protected void grdDetail_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {
        for (int i = 0; i < e.Row.Cells.Count; i++)
        {
            e.Row.Cells[i].Attributes.Add("style", "white-space: nowrap;");
        }

    }
}
