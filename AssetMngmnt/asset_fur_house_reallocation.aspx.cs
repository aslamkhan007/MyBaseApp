using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class AssetMngmnt_asset_fur_house_reallocation : System.Web.UI.Page
{

    Connection obj = new Connection();
    Functions obj1 = new Functions();
    string sql = string.Empty;
    string script = string.Empty;
    string dept = string.Empty;
    string empcode = string.Empty;
 
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            if (Session["EmpCode"] == string.Empty)
            {
                Response.Redirect("~/login.aspx");
            }
            bindgrid();
        }

    }

    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        Response.Redirect("asset_fur_house_reallocation.aspx");
    }
    protected void lnkapply_Click(object sender, EventArgs e)
    {      
        try
        {
            sql = "jct_asset_house_reallocation_update";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;


            if (txtempcode.Text.Contains('|'))
            {

                string empcode = txtempcode.Text.Split('|')[1].ToString();
                cmd.Parameters.Add("@empcode", SqlDbType.VarChar, 30).Value = empcode.Split('~')[0].ToString();
            }
            else
            {
                cmd.Parameters.Add("@empcode", SqlDbType.VarChar, 30).Value = txtempcode.Text;
            }
            //cmd.Parameters.Add("@empcode", SqlDbType.VarChar,20).Value =   txtempcode.Text;
            cmd.Parameters.Add("@Current_location", SqlDbType.VarChar, 100).Value = ddlloc.SelectedItem.Text;
           
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = lbid.Text;
            cmd.Parameters.Add("@entry_by", SqlDbType.VarChar,20).Value = Session["EmpCode"];
            cmd.Parameters.Add("@Hostname", SqlDbType.VarChar, 15).Value = Request.ServerVariables["REMOTE_ADDR"];
            cmd.ExecuteNonQuery();

            bindgrid();
            script = "alert('Record saved.!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);

        }

        catch (SqlException ex)
        {
            string script = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }

        catch (Exception ex)
        {
            script = "alert('plaese Select the record.!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }
    protected void grdDetail_SelectedIndexChanged(object sender, EventArgs e)
    {
       lbid.Text = grdDetail.SelectedRow.Cells[1].Text.Replace("&nbsp;", "");
       txtempcode.Text=grdDetail.SelectedRow.Cells[2].Text.Replace("&nbsp;", "");
       ddlloc.SelectedIndex = ddlloc.Items.IndexOf(ddlloc.Items.FindByText(grdDetail.SelectedRow.Cells[4].Text.Replace("&nbsp;", "")));
    }
    private void bindgrid()
    {
        
       //SqlCommand cmd = new SqlCommand("SELECT ID,b.empcode,Current_location AS [Currentlocation],empname FROM  jct_asset_house_reallocation  a JOIN  jct_empmast_base b  ON  a.empcode=b.empcode WHERE a.status='a' AND Active='Y'", obj.Connection());   
        SqlCommand cmd = new SqlCommand("SELECT ID,b.empcode as [EmployeeCode] ,empname as [EmployeeName],Current_location AS [DeallocatedLocation] FROM  jct_asset_house_reallocation  a JOIN  jct_empmast_base b  ON  a.empcode=b.empcode WHERE a.status='a' AND Active='Y' AND a.flag = 'Deallocated' ", obj.Connection());   
        cmd.CommandType = CommandType.Text;
        
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        grdDetail.DataSource = ds.Tables[0];
        grdDetail.DataBind();
     
    }
}