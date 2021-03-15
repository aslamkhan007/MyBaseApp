using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class OPS_Dak_Monthly_Report : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["DRS"].ConnectionString);
    Connection obj = new Connection();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    private void bindgrid()
    {

        SqlCommand cmd = new SqlCommand("Jct_Dak_Monthly_Report", con);
        con.Open();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@Hod_Code", SqlDbType.VarChar, 10).Value = Session["EmpCode"];
        if (txtFrom.Text != null)
        {
            cmd.Parameters.Add("@Eff_From", SqlDbType.DateTime).Value = DateTime.Parse(txtFrom.Text);
        }

        if (txtFrom.Text != null)
        {
            cmd.Parameters.Add("@Eff_To", SqlDbType.DateTime).Value = DateTime.Parse(txtTo.Text);
        }

        if (!string.IsNullOrEmpty(ddlDakStatus.SelectedItem.Text))
        {
            //cmd.Parameters.Add("@Auth_Status", SqlDbType.Bit ).Value = Convert.ToBoolean(ddlDakStatus.SelectedItem.Value);
            cmd.Parameters.Add("@Auth_Status", SqlDbType.Bit).Value = Convert.ToBoolean(ddlDakStatus.SelectedItem.Value);
        }             
        cmd.ExecuteNonQuery();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        grdDetail.DataSource = ds;
        grdDetail.DataBind();     
        con.Close();

    }

    protected void lnkfetch_Click(object sender, EventArgs e)
    {
        try
        {
        bindgrid();
        }
         catch (Exception ex)
        {
            string  script = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }

    
    protected void lnkexcel_Click(object sender, EventArgs e)
    { 
       try
        {
            SqlCommand cmd = new SqlCommand("Jct_Dak_Monthly_Report", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Hod_Code", SqlDbType.VarChar, 10).Value = Session["EmpCode"];
            if (txtFrom.Text != null)
            {
                cmd.Parameters.Add("@Eff_From", SqlDbType.DateTime).Value = DateTime.Parse(txtFrom.Text);
            }

            if (txtFrom.Text != null)
            {
                cmd.Parameters.Add("@Eff_To", SqlDbType.DateTime).Value = DateTime.Parse(txtTo.Text);
            }

            if (!string.IsNullOrEmpty(ddlDakStatus.SelectedItem.Text))
            {
                //cmd.Parameters.Add("@Auth_Status", SqlDbType.Bit ).Value = Convert.ToBoolean(ddlDakStatus.SelectedItem.Value);
                cmd.Parameters.Add("@Auth_Status", SqlDbType.Bit).Value = Convert.ToBoolean(ddlDakStatus.SelectedItem.Value);
            }             
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            grdDetail.DataSource = ds.Tables[0];
            grdDetail.DataBind();

            DataTable dt = ds.Tables[0];
            string attachment = "attachment; printerDetail.xls";
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
        catch (Exception ex)
        {
            string  script = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }
    protected void grdDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdDetail.PageIndex = e.NewPageIndex;
        bindgrid();
    }
}