using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;


public partial class OPS_Excess_Budget_list : System.Web.UI.Page
{
    Connection obj = new Connection();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void lnkbtnFetch_Click(object sender, EventArgs e)
    {
        try
        {
            Panel1.Visible = true;
            //string qry = ConfigurationManager.ConnectionStrings["testerp"].ToString();
            //SqlConnection con = new SqlConnection(qry);
            //con.Open();
            string address = System.Web.HttpContext.Current.Request.UserHostAddress;
            string strqry = "jct_excess_budget_list";
            SqlCommand cmd = new SqlCommand(strqry, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@from_date", SqlDbType.DateTime).Value = txtFromdate.Text;
            cmd.Parameters.Add("@to_date", SqlDbType.DateTime).Value = txtTodate.Text;
            cmd.Parameters.Add("@empcode", SqlDbType.VarChar, 7).Value = Session["empcode"].ToString();
            
	//cmd.ExecuteNonQuery();                       
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            Grdfreezedate.DataSource = ds;
            Grdfreezedate.DataBind();
            //con.Close();   
        }
        catch (Exception exception)
        {
            string script = "alert('" + exception.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }

    }
    protected void lnkbtnexcel_Click(object sender, EventArgs e)
    {
        GridViewExportUtil.Export("XL.xls", Grdfreezedate);
    }
}