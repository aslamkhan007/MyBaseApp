using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class OPS_QualityAnalysisReport : System.Web.UI.Page
{
   // SqlConnection con = new SqlConnection(@"Data Source=TEST2K;Initial Catalog=jctdev1;User ID=trainee ;password=trainee");
   // conn
    Connection ObjCon=new Connection();

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void lnkFetch_Click(object sender, EventArgs e)
    {
       
        
       
        
            SqlCommand cmd = new SqlCommand("Jct_Ops_Quality_Analysis_Fetch", ObjCon.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@datefrom", SqlDbType.DateTime).Value = txtdatefrom.Text;
            cmd.Parameters.Add("@dateto", SqlDbType.DateTime).Value = txtdateto.Text;
            cmd.Parameters.Add("@orderno", SqlDbType.VarChar, 30).Value = txtorderno.Text;
            cmd.Parameters.Add("@sortno", SqlDbType.VarChar, 20).Value = txtsortno.Text;
            cmd.Parameters.Add("@result", SqlDbType.VarChar, 10).Value = ddlresult.SelectedItem.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            grdDetail.DataSource = ds.Tables[0];
            grdDetail.DataBind();
        

    }
    protected void lnkReset_Click(object sender, EventArgs e)
    {
        Response.Redirect("QualityAnalysisReport.aspx");
    }
    protected void txttestedby_TextChanged(object sender, EventArgs e)
    {

    }
    protected void lnkexcel_Click(object sender, EventArgs e)
    {
         SqlCommand cmd = new SqlCommand("Jct_Ops_Quality_Analysis_Fetch", ObjCon.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@datefrom", SqlDbType.DateTime).Value = txtdatefrom.Text;
            cmd.Parameters.Add("@dateto", SqlDbType.DateTime).Value = txtdateto.Text;
            cmd.Parameters.Add("@orderno", SqlDbType.VarChar, 30).Value = txtorderno.Text;
            cmd.Parameters.Add("@sortno", SqlDbType.VarChar, 20).Value = txtsortno.Text;
            cmd.Parameters.Add("@result", SqlDbType.VarChar, 10).Value = ddlresult.SelectedItem.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            grdDetail.DataSource = ds.Tables[0];
            grdDetail.DataBind();

            DataTable dt = ds.Tables[0];
        string attachment = "attachment; quality_analysis_report.xls";
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

        ObjCon.ConClose();
    }


    }




