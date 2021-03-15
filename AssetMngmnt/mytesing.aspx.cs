using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class AssetMngmnt_mytesing : System.Web.UI.Page
{
    //SqlConnection con = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["MyProject"].ConnectionString);
    Connection obj = new Connection();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void lnkSave_Click(object sender, EventArgs e)
    {

        try
        {
            //con.Open();
            SqlCommand cmd = new SqlCommand("dummytable1_Save", obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@NAME", SqlDbType.VarChar, 40).Value = txtName.Text;
            cmd.Parameters.Add("@roll_no", SqlDbType.Int).Value = Txtroll_no.Text;
            cmd.Parameters.Add("@class", SqlDbType.VarChar,5).Value = txtClass.Text;        
            cmd.ExecuteNonQuery();
            string   script = "alert('Record Saved');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            //Bindgrid();                        
            //con.Close();
        }

        catch (Exception ex)
        {
            string script2 = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);
            return;
        }


    }
  
    protected void lnkfetch_Click(object sender, EventArgs e)
    {
       
            SqlCommand cmd = new SqlCommand("dummytable_fetch", obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@from_date", SqlDbType.DateTime).Value = Convert.ToDateTime(Txtdatefrom.Text);
            cmd.Parameters.Add("@to_date", SqlDbType.DateTime).Value =Convert.ToDateTime(Txtdateto.Text);
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();
 
    }
    protected void excel_Click(object sender, EventArgs e)
    {
        GridViewExportUtil.Export("XL.xls", GridView1);

    }
    protected void lnkreset_Click(object sender, EventArgs e)
    {
        Response.Redirect("mytesing.aspx");
    }
}