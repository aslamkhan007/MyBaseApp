using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Drawing;
using System.Web.Services;


public partial class Payroll_PortalAutoRights : System.Web.UI.Page
{
    string sql = string.Empty;
    Functions obj1 = new Functions();
    string cardno;
    string empcode;
    string FlagCheck = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
        }
    }

    protected void txtEmployee_TextChanged(object sender, EventArgs e)
    {
        try
        {
            string employeecode = txtEmployee.Text.Split('|')[1].ToString();
            txtEmployee.Text = employeecode;
        }
        catch (Exception exception)
        {
            txtEmployee.Text = "";
            string script = "alert('Please Select Record From List');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }

    protected void lnkadd_Click(object sender, EventArgs e)
    {
        try
        {
            FetchRecord();
        }
        catch (Exception ex)
        {
            string script = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }

    public void FetchRecord()
    {
        Connection obj = new Connection();
        SqlCommand cmd = new SqlCommand("Jct_Payroll_NewJoinning_Portal_Rights", obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 10).Value = txtEmployee.Text;
        cmd.ExecuteNonQuery();
        string script = "alert('Authorization Rights Provided');";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        //DataTable dt = new DataTable();
        //SqlDataAdapter da = new SqlDataAdapter(cmd);
        //da.Fill(dt);
        //GridView1.DataSource = dt;
        //GridView1.DataBind();
    }
      

    protected void lnkreset_Click(object sender, EventArgs e)
    {
        Response.Redirect("PortalAutoRights.aspx");
    }
}