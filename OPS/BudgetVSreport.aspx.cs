using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;


public partial class OPS_BudgetVSreport : System.Web.UI.Page
{
    SqlConnection obj = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ReportDBConnectionString"].ConnectionString);
    //Connection obj = new Connection();
    Functions obj1 = new Functions();
    string sql = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void lnkfetch_Click(object sender, EventArgs e)
    {
        SqlCommand cmd = new SqlCommand("jct_budget_indent_excess_sanction_rpt", obj);
        obj.Open();
        cmd.CommandType = CommandType.StoredProcedure;


        cmd.Parameters.Add("@from_date", SqlDbType.DateTime).Value =Convert.ToDateTime(txtfrmdate.Text);
        cmd.Parameters.Add("@to_date", SqlDbType.DateTime).Value = Convert.ToDateTime(txttodate.Text);
        cmd.Parameters.Add("@budget_type", SqlDbType.VarChar, 20).Value = ddltype.SelectedItem.Text;

        cmd.ExecuteNonQuery();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        grdDetail.DataSource = ds.Tables[0];
        grdDetail.DataBind();

        obj.Close();
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        SqlCommand cmd = new SqlCommand("jct_budget_indent_excess_sanction_rpt", obj);
        obj.Open();
        cmd.CommandType = CommandType.StoredProcedure;


        cmd.Parameters.Add("@from_date", SqlDbType.DateTime).Value = Convert.ToDateTime(txtfrmdate.Text);
        cmd.Parameters.Add("@to_date", SqlDbType.DateTime).Value = Convert.ToDateTime(txttodate.Text);
        cmd.Parameters.Add("@budget_type", SqlDbType.VarChar, 20).Value = ddltype.SelectedItem.Text;

        cmd.ExecuteNonQuery();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        grdDetail.DataSource = ds.Tables[0];
        grdDetail.DataBind();


        DataTable dt = ds.Tables[0];
        string attachment = "attachment; Budget Report.xls";
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

        obj.Close();
    }

    
}