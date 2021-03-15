using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient; 

public partial class OPS_missingDyeList : System.Web.UI.Page
{
   //SqlConnection con = new SqlConnection(@"Data Source=TEST2K;Initial Catalog=jctdev;User ID=trainee ;password=trainee");
    SqlConnection con = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["productionConnectionString1"].ConnectionString);
    

    
    protected void lnkfetch_Click(object sender, EventArgs e)
    {
      
       SqlCommand cmd = new SqlCommand("jct_ops_missing_dye_chemical_list", con);

        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@datefrom", SqlDbType. DateTime).Value = txtdatefrm.Text;
        cmd.Parameters.Add("@dateto", SqlDbType.DateTime).Value = txtdateto.Text;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        grdDetail.DataSource = ds.Tables[0];
        grdDetail.DataBind();
        
    }
    protected void grdDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        SqlCommand cmd = new SqlCommand("jct_ops_missing_dye_chemical_list", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@datefrom", SqlDbType.DateTime).Value = txtdatefrm.Text;
        cmd.Parameters.Add("@dateto", SqlDbType.DateTime).Value = txtdateto.Text;
        grdDetail.PageIndex = e.NewPageIndex;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        grdDetail.DataSource = ds.Tables[0];
        grdDetail.DataBind();

   
    }
    protected void lnk_excel_Click(object sender, EventArgs e)
    {
        SqlCommand cmd = new SqlCommand("jct_ops_missing_dye_chemical_list", con);

        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@datefrom", SqlDbType.DateTime).Value = txtdatefrm.Text;
        cmd.Parameters.Add("@dateto", SqlDbType.DateTime).Value = txtdateto.Text;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        grdDetail.DataSource = ds.Tables[0];
        grdDetail.DataBind();
        
        
        
        DataTable dt = ds.Tables[0];
        string attachment = "attachment;MissingDyeList.xls";
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

        con.Close();
    }
}
