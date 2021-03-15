using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;


public partial class OPS_jct_workcell_workwages_page : System.Web.UI.Page
{
  
    SqlConnection con = new SqlConnection(@"Data Source=misdev;Initial Catalog=workwages;User ID=itgrp ;password=power");
    Connection obj = new Connection();
    string sql = string.Empty;
    string CheckValue = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //bindgrid();              
        }

    }

    protected void lnkadd_Click(object sender, EventArgs e)
    {
        try
        {
            con.Open();
            string sql = "Jct_Worker_Cell_Approval";
            SqlCommand cmd = new SqlCommand(sql, con);
           
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Empcode", SqlDbType.Char, 6).Value = txtEmployeecode.Text;
            cmd.Parameters.Add("@From_date", SqlDbType.Char, 50).Value = Convert.ToDateTime(txteff_from.Text);
            cmd.Parameters.Add("@TO_date", SqlDbType.Char, 50).Value = Convert.ToDateTime(txteff_to.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            bindgrid();
          

        }
        catch (Exception ex)
        {
            string script = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }

    }

    protected void lnkreset_Click(object sender, EventArgs e)
    {
        Response.Redirect("jct_workcell_workwages_page.aspx");
    }
    private void bindgrid()
    {
        sql = "SELECT * FROM Jct_Mobile_Approval WHERE   employee_code = '"+  txtEmployeecode.Text +"'  ";
        SqlCommand cmd = new SqlCommand(sql, con);
        cmd.CommandType = CommandType.Text;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        grdDetail.DataSource = ds.Tables[0];
        grdDetail.DataBind();
        Panel1.Visible = true;
    }

    protected void lnkPrint_Click(object sender, EventArgs e)
    {
        string querystring;
        querystring = txtEmployeecode.Text;
        querystring =  txtEmployeecode.Text;

        DateTime a = Convert.ToDateTime(txteff_from.Text);
        DateTime b = Convert.ToDateTime(txteff_to.Text);

        Response.Redirect("jct_workercell_approval.aspx?fd=" + a + "&requestid=" + querystring + "&td=" + b);     

    }
}