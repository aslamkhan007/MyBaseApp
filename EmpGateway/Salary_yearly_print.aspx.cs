using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class OPS_Salary_yearly_print : System.Web.UI.Page
{
    Connection obj = new Connection();
    SqlConnection conjctgen = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["misjctgen"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Empcode"] == "")
        {
            Response.Redirect("~/Login.aspx");
        }
        if(!IsPostBack)
        {
   lbyear.Text = ddlyearfrom.SelectedItem.Text;
        string sql = "select * from ops_salary_yearly_print_detail where  empcode = '" + Session["Empcode"] + "' and  financial_year = '" +ddlyearfrom.SelectedItem.Text + "'  ";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
       
        cmd.CommandType = CommandType.Text;
   
        cmd.ExecuteNonQuery();
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            lnkprint.Enabled = false;
            string script = "alert( 'Print Already Taken ');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);  
        }
        }

    
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        try
        {
                 string sql = "select distinct a.empcode as Empcode,a.Cardno,a.Empname,a.Fathername,a.Desg as Designation,b.Deptname as Department,CONVERT(VARCHAR(10),a.doj,103) as[ D.O.J] from jctdev.dbo.jct_empmast_base as a inner join  jctdev.dbo.deptmast as b on a.deptcode = b.deptcode where  a.empcode = '" + Session["Empcode"] + "' and a.active  = 'y' ";
                SqlCommand cmd = new SqlCommand(sql, conjctgen);
                conjctgen.Open();
                cmd.CommandType = CommandType.Text;
                //cmd.Parameters.Add("@empcode", SqlDbType.VarChar, 100).Value = "S-13823";//Session["Empcode"];
                cmd.ExecuteNonQuery();
                conjctgen.Close();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                Gridbasicdetail.DataSource = ds.Tables[0];
                Gridbasicdetail.DataBind();

                sql = "ops_salary_print";
                cmd = new SqlCommand(sql, conjctgen);
                conjctgen.Open();
                //txtvendor.Text.Split('~')[0]
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@empcode", SqlDbType.VarChar, 100).Value = Session["Empcode"];
                cmd.Parameters.Add("@datefrom", SqlDbType.VarChar, 15).Value = ddlyearfrom.SelectedItem.Text.Split('-')[0] + "04";
                cmd.Parameters.Add("@dateto", SqlDbType.VarChar, 100).Value = ddlyearfrom.SelectedItem.Text.Split('-')[1] + "03";

                cmd.ExecuteNonQuery();
                conjctgen.Close();
                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
             
                grdDetail.DataSource = ds.Tables[0];
                grdDetail.DataBind();
                //Panel1.Visible = true;
                pnlContents.Visible = true;
                lnkprint.Visible = true;
                lnkprint.Enabled = true;
                if (ds.Tables[0].Rows.Count == 0)
                {
                    lnkprint.Enabled = false;
                    lnkprint.Visible = false;
                }
 
     
          
                  sql = "select * from ops_salary_yearly_print_detail where  empcode = '" + Session["Empcode"] + "' and  financial_year = '" +ddlyearfrom.SelectedItem.Text + "'  ";
               cmd = new SqlCommand(sql, obj.Connection());
       
        cmd.CommandType = CommandType.Text;
   
        cmd.ExecuteNonQuery();
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            lnkprint.Enabled = false;
          
        }
            }

            
     
        catch (Exception ex)
        {
            string script = "alert('Please check the year! ');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);

        }

    }



    protected void Gridbasicdetail_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void lnkprint_Click(object sender, EventArgs e)
    {
        try
        {
            string sql = "ops_salary_yearly_print_detail_insert";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@empcode", SqlDbType.VarChar, 100).Value = Session["Empcode"];
            cmd.Parameters.Add("@financial_year", SqlDbType.VarChar, 100).Value = ddlyearfrom.SelectedItem.Text;

            cmd.ExecuteNonQuery();
            pnlContents.Visible = false;
            lnkprint.Enabled = false;
         

        }
        catch (Exception ex)
        {
            string script = "alert( '" + ex.Message + " ');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);  
        }

    }
    protected void ddlyearfrom_SelectedIndexChanged(object sender, EventArgs e)
    {
        lbyear.Text = ddlyearfrom.SelectedItem.Text;
        string sql = "select * from ops_salary_yearly_print_detail where  empcode = '" + Session["Empcode"] + "' and  financial_year = '" +ddlyearfrom.SelectedItem.Text + "'  ";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
       
        cmd.CommandType = CommandType.Text;
   
        cmd.ExecuteNonQuery();
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            lnkprint.Enabled = false;
            string script = "alert( 'Print Already Taken ');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);  
        }
        dr.Close();
        LinkButton1_Click(sender, e);

    }
}