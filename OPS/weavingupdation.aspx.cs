using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Text;

public partial class OPS_weavingupdation : System.Web.UI.Page
{

    SqlConnection con = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["misjctdev"].ConnectionString);
   // workwagesConnectionString
    SqlConnection workwages = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["workwagesConnectionString"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Empcode"] == "")
        {
            Response.Redirect("~/Login.aspx");

        }
    }
    protected void lnkapply_Click(object sender, EventArgs e)
    {
        try
        {
            SqlCommand cmd = new SqlCommand("weaving_picks_upd", workwages);
            workwages.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 0;
            cmd.Parameters.Add("@eff_date", SqlDbType.VarChar, 10).Value = txtdate.Text;
            cmd.ExecuteNonQuery();
            workwages.Close();

            cmd = new SqlCommand("jct_ops_weaving_updation_entry", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@effdate", SqlDbType.VarChar, 10).Value = txtdate.Text;
            cmd.Parameters.Add("@empname", SqlDbType.VarChar, 10).Value = Session["Empcode"];
            cmd.ExecuteNonQuery();
            con.Close();

            string script2 = "alert(' record saved sucesfully.!! ');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);
        }
        catch (Exception ex)
        {
            string script3 = "alert(' Record  not saved some problem occured .!! ' );";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script3, true);
        }


    }
}