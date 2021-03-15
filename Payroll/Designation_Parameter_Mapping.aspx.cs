using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;


public partial class Payroll_Designation_Parameter_Mapping : System.Web.UI.Page
{
    Connection obj = new Connection();
  
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //string  qry = ConfigurationManager.ConnectionStrings["misdev"].ToString();
            //SqlConnection con = new SqlConnection(qry);
            //con.Open();
            SqlCommand cmd = new SqlCommand("select distinct short_desc ,sr_no from jct_payroll_allownc_paramtr where status  = 'A' ", obj.Connection());
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            chklist.DataSource = ds.Tables[0];
            //chklist.DataTextField = "short_desc";
            //chklist.DataValueField = "sr_no";
            chklist.DataBind();
            Panel1.Visible = true;
            //con.Close();

            //con.Open();
            cmd = new SqlCommand("SELECT DISTINCT Desg_Long_Description , Designation_code FROM JCT_payroll_designation_master  where status = 'A' ", obj.Connection());
            cmd.CommandType = CommandType.Text;
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            rdbdesglist.DataSource = ds.Tables[0];
            //chklist.DataTextField = "short_desc";
            //chklist.DataValueField = "sr_no";
            rdbdesglist.DataBind();
            Panel2.Visible = true;
            //con.Close();
        }
    }

    protected void lnkadd_Click(object sender, EventArgs e)
    {
      try
        {

        if (lnkadd.Text == "Update")
        {
          //string qry = ConfigurationManager.ConnectionStrings["misdev"].ToString();
          //SqlConnection con = new SqlConnection(qry);
          //con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE  JCT_payroll_designation_parameter_master  SET STATUS ='U' , UpdatedBy = @UpdatedBy  , update_date = getdate() WHERE Designation_code  = @Designation_code  AND STATUS='A'", obj.Connection());
          cmd.CommandType = CommandType.Text;
          cmd.Parameters.Add("@Designation_code", SqlDbType.VarChar, 10).Value = rdbdesglist.SelectedValue;
          cmd.Parameters.Add("@UpdatedBy", SqlDbType.VarChar, 30).Value = Session["Empcode"];
          cmd.ExecuteNonQuery();
          //con.Close();
          //con.Open();
            for (int i = 0; i <= chklist.Items.Count - 1; i++)
            {
                if (chklist.Items[i].Selected == true)
                {
                    cmd = new SqlCommand("JCT_payroll_designation_parameter_master_insert", obj.Connection());
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Designation_code", SqlDbType.VarChar, 10).Value = rdbdesglist.SelectedValue;
                    cmd.Parameters.Add("@Allownce_Short_Description", SqlDbType.VarChar, 20).Value = chklist.Items[i].Text;
                    cmd.Parameters.Add("@Allownce_sr_no", SqlDbType.Int).Value = chklist.Items[i].Value;
                    cmd.Parameters.Add("@Entry_By", SqlDbType.VarChar, 30).Value = Session["Empcode"];
                    cmd.ExecuteNonQuery();
                }
            }
            //con.Close();
            string script = "alert('Record Updated Successfully.');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
        else
        {
            //string qry = ConfigurationManager.ConnectionStrings["misdev"].ToString();
            //SqlConnection con = new SqlConnection(qry);
            //con.Open();
            for (int i = 0; i <= chklist.Items.Count - 1; i++)
            {
                if (chklist.Items[i].Selected == true)
                {
                    SqlCommand cmd = new SqlCommand("JCT_payroll_designation_parameter_master_insert", obj.Connection());
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Designation_code", SqlDbType.VarChar, 10).Value = rdbdesglist.SelectedValue;
                    cmd.Parameters.Add("@Allownce_Short_Description", SqlDbType.VarChar, 20).Value = chklist.Items[i].Text;
                    cmd.Parameters.Add("@Allownce_sr_no", SqlDbType.Int).Value = chklist.Items[i].Value;
                    cmd.Parameters.Add("@Entry_By", SqlDbType.VarChar, 30).Value = Session["Empcode"];
                    cmd.ExecuteNonQuery();
                }
            }
            //con.Close();
            string script = "alert('Record Saved Successfully.');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }


        }
      catch (Exception exception)
      {
          string script = "alert('" + exception.Message + "');";
          ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
      }

    }
    protected void lnkreset_Click(object sender, EventArgs e)
    {
        Response.Redirect("Designation_Parameter_Mapping.aspx");       
    }
    protected void rdbdesglist_SelectedIndexChanged(object sender, EventArgs e)
    {
         try
        {  
        //string qry = ConfigurationManager.ConnectionStrings["misdev"].ToString();
        //SqlConnection con = new SqlConnection(qry);
      
        for (int i = 0; i <= chklist.Items.Count - 1; i++)
        {
            string allowclst;
            allowclst = chklist.Items[i].Text;
            SqlCommand cmd = new SqlCommand("JCT_payroll_designation_parameter_master_select", obj.Connection());
            //con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Designation_code", SqlDbType.VarChar, 10).Value = rdbdesglist.SelectedItem.Value;
            cmd.Parameters.Add("@Allownce_Short_Description", SqlDbType.VarChar, 20).Value = allowclst;
            cmd.Parameters.Add("@flag", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            //con.Close();
            string output = cmd.Parameters["@flag"].Value.ToString();
            if (output == "1")
            {
                chklist.Items[i].Selected = true;
                lnkadd.Text = "Update";
            }
            else
            {
                chklist.Items[i].Selected = false;
                //lnkadd.Text = "Update";
            }
      
        }
 
        }
         catch (Exception exception)
         {
             string script = "alert('" + exception.Message + "');";
             ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
         }
    }

}