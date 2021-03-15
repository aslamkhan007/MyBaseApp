using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;


public partial class AssetMngmnt_Harpreet : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["MyProject"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void button_Click(object sender, EventArgs e)
    {
       try
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("dummytable1_Save",con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@NAME", SqlDbType.VarChar, 40).Value = Txtbox.Text;
            cmd.Parameters.Add("@class", SqlDbType.Int).Value = txtclass.Text; 
            cmd.Parameters.Add("@RollNo", SqlDbType.Int).Value = txtroll.Text;    
                   
            cmd.ExecuteNonQuery();
            string   script = "alert('Record Saved');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            //Bindgrid();                        
            con.Close();
        }
       catch (Exception ex)
       {
           string script2 = "alert('" + ex.Message + "');";
           ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);
           return;
       }
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void LinkFetch_Click(object sender, EventArgs e)
    {

        SqlCommand cmd = new SqlCommand("dummytable_fetch", con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        GridView1.DataSource = ds;
        GridView1.DataBind();
 

    }
}