using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;

public partial class AssetMngmnt_asset_history_report : System.Web.UI.Page
{

    SqlConnection conjctgen = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["misjctgen"].ConnectionString);
   // Connection obj = new Connection();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void lnkfetch_Click(object sender, EventArgs e)
    {
        string sql = "jct_ops_asset_history";
        SqlCommand cmd = new SqlCommand(sql, conjctgen);
        conjctgen.Open();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@jctSr_no", SqlDbType.VarChar, 100).Value = txtsrno.Text;
        cmd.Parameters.Add("@computer_name", SqlDbType.VarChar, 15).Value = txtcompname.Text;
        if (!string.IsNullOrEmpty(txtdatefrm.Text))
        {
            cmd.Parameters.Add("@datefrom", SqlDbType.VarChar, 100).Value = txtdatefrm.Text;
        }
           if (!string.IsNullOrEmpty(txtdatefrm.Text))
        {
            cmd.Parameters.Add("@dateto", SqlDbType.VarChar, 100).Value = txtdateto.Text;
        }

          
        cmd.ExecuteNonQuery();
        conjctgen.Close();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        grdDetail.DataSource = ds.Tables[0];
        grdDetail.DataBind();
        Panel1.Visible = true;

    }
    protected void grdDetail_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.Cells[19].Text.Equals("A"))
            {
                e.Row.BackColor = Color.LightGreen;
            }
        }
    }
}