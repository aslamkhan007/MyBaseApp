using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class AssetMngmnt_AssetCategory : System.Web.UI.Page
{
    Connection obj = new Connection();
    Functions obj1 = new Functions();
    string sql = string.Empty;
    string script = string.Empty;
     string dept = string.Empty;
     string empcode = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["EmpCode"] == string.Empty)
        {
            Response.Redirect("~/login.aspx");
        }
     
        if (!IsPostBack)
        {
            sql = "SELECT DISTINCT  empcode,b.deptcode FROM jct_empmast_base  a JOIN dbo.DEPTMAST  b ON a.deptcode=b.DEPTCODE WHERE  a.empcode= '" + Session["EmpCode"] + "'";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            SqlDataReader Dr = cmd.ExecuteReader();
            if (Dr.HasRows)
            {
                while (Dr.Read())
                {
                    empcode = Dr[0].ToString();
                    if (empcode.ToString() == "M-02467" || empcode.ToString() == "m-02467" || empcode.ToString() == "a-00098" || empcode.ToString() == "A-00098")
                    {
                        dept = "GEN";
                        ViewState["dept"] = dept;
                    }
                    else
                    {
                        dept = Dr[1].ToString();
                        if (dept != "MIS")
                        {
                            dept = "GEN";
                            ViewState["dept"] = dept;
                        }
                        else
                        {
                            ViewState["dept"] = dept;
                        }
                    }

                }

            }
            Dr.Close();
            Bindgrid();
        }
      
    }

    protected void Bindgrid()
    {
        sql = "jct_asset_master_select";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@module_usedby", SqlDbType.VarChar, 20).Value = ViewState["dept"];
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        grdDetail.DataSource = ds.Tables[0];
        grdDetail.DataBind();
    }

    protected void lnksave_Click(object sender, EventArgs e)
    {
        try
        {
            sql = "jct_asset_master_insert";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@asset_name", SqlDbType.VarChar, 100).Value = txtasset.Text;
            cmd.Parameters.Add("@asset_desc", SqlDbType.VarChar, 500).Value = txtdesc.Text;
            cmd.Parameters.Add("@empcode", SqlDbType.VarChar, 7).Value = Session["EmpCode"];
            cmd.Parameters.Add("@module_usedby", SqlDbType.VarChar, 20).Value = ViewState["dept"];
            cmd.Parameters.Add("@Hostname", SqlDbType.VarChar, 15).Value = Request.ServerVariables["REMOTE_ADDR"];
    
            cmd.ExecuteNonQuery();
          
            Bindgrid();

            script = "alert('Record saved!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
        catch (Exception ex)
        {
            script = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }

    protected void lnkdel_Click(object sender, EventArgs e)
    {
        try
        {
            sql = "jct_asset_master_delete";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@asset_name", SqlDbType.VarChar, 100).Value = txtasset.Text;
            cmd.Parameters.Add("@Hostname", SqlDbType.VarChar, 15).Value = Request.ServerVariables["REMOTE_ADDR"];
            cmd.Parameters.Add("@asset_id", SqlDbType.Int).Value = ViewState["asset_id"];
            cmd.Parameters.Add("@module_usedby", SqlDbType.VarChar, 20).Value = ViewState["dept"];

            cmd.ExecuteNonQuery();
            script = "alert('Record Deleted !!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
        catch (Exception ex)
        {
            script = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }

    protected void lnkupdate_Click(object sender, EventArgs e)
    {
        try
        {
            sql = "jct_asset_master_update";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@asset_id", SqlDbType.Int).Value = ViewState["asset_id"];
            cmd.Parameters.Add("@asset_name", SqlDbType.VarChar, 100).Value = txtasset.Text;
            cmd.Parameters.Add("@asset_desc", SqlDbType.VarChar, 500).Value = txtdesc.Text;
            cmd.Parameters.Add("@empcode", SqlDbType.VarChar, 7).Value = Session["EmpCode"];
            cmd.Parameters.Add("@module_usedby", SqlDbType.VarChar, 20).Value = ViewState["dept"];
            cmd.Parameters.Add("@Hostname", SqlDbType.VarChar, 15).Value = Request.ServerVariables["REMOTE_ADDR"];
            cmd.ExecuteNonQuery();
            script = "alert('Record updated !!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
        catch (Exception ex)
        {
            script = "alert('"+ ex.Message +"');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }

    //protected void grdDetail_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    lbassetid.Text = grdDetail.SelectedRow.Cells[1].Text.ToString();
 
    //    //txtasset.Text = grdDetail.SelectedRow.Cells[2].Text.ToString();
    //    //txtdesc.Text = grdDetail.SelectedRow.Cells[3].Text.ToString();
    //    //ViewState["asset_id"] = grdDetail.SelectedRow.Cells[1].Text.ToString();
 
   
    //}

    protected void lnkReset_Click(object sender, EventArgs e)
    {
        Response.Redirect("AssetCategory.aspx");
    }

    protected void grdDetail_SelectedIndexChanged(object sender, EventArgs e)
    {

     txtasset.Text = grdDetail.SelectedRow.Cells[2].Text.ToString();
       txtdesc.Text = grdDetail.SelectedRow.Cells[3].Text.ToString();
      ViewState["asset_id"] = grdDetail.SelectedRow.Cells[1].Text.ToString();
    }
   
}