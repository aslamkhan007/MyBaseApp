using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class AssetMngmnt_AssetType : System.Web.UI.Page
{
    Connection obj = new Connection();
    Functions obj1 = new Functions();
    string sql = string.Empty;

    SqlConnection con = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["misjctdev"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        bindgrid();
    }

    protected void lnksave_Click(object sender, EventArgs e)
    {
        sql = "jct_asset_type_insert";
        SqlCommand cmd = new SqlCommand(sql,con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@asset_id", SqlDbType.Int).Value = ddlassettype.SelectedValue;
        cmd.Parameters.Add("@asset_type_name", SqlDbType.VarChar, 500).Value =txtasset.Text;
        cmd.Parameters.Add("@asset_type_desc", SqlDbType.VarChar, 500).Value = txtdesc.Text;
        cmd.Parameters.Add("@creted_by", SqlDbType.VarChar, 500).Value = Session["Empcode"];
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
        string  script = "alert('Record saved!!');";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        bindgrid();
    }

    protected void lnkadd_Click(object sender, EventArgs e)
    {
        Response.Redirect("AssetType.aspx");
    }

    protected void lnkdel_Click(object sender, EventArgs e)
    {
        sql = "jct_asset_type_delete";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@asset_type_id", SqlDbType.Int).Value = grdDetail.SelectedRow.Cells[1].Text;
        cmd.Parameters.Add("@empcode", SqlDbType.VarChar, 500).Value = Session["Empcode"];
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
        string script = "alert('Record saved!!');";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        bindgrid();
    }

    private void bindgrid()
    {
        sql = "SELECT  asset_type_id,asset_type_name,asset_type_desc fROM  jct_asset_type_master WHERE STATUS='A'  ORDER BY asset_type_id ";
        SqlCommand cmd = new SqlCommand(sql, con);
        cmd.CommandType = CommandType.Text;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        grdDetail.DataSource = ds.Tables[0];
        grdDetail.DataBind();
    }

    protected void grdDetail_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtasset.Text = grdDetail.SelectedRow.Cells[2].Text.Replace("&nbsp;", "");
        txtdesc.Text = grdDetail.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");
    }

    protected void lnkupdate_Click(object sender, EventArgs e)
    {
        sql = "jct_asset_type_update";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@asset_id", SqlDbType.Int).Value = ddlassettype.SelectedValue;
        cmd.Parameters.Add("@asset_type_id", SqlDbType.VarChar, 50).Value = grdDetail.SelectedRow.Cells[1].Text;
        cmd.Parameters.Add("@asset_type_name", SqlDbType.VarChar, 50).Value = txtasset.Text;
        cmd.Parameters.Add("@asset_type_desc", SqlDbType.VarChar, 50).Value = txtdesc.Text;
        cmd.Parameters.Add("@empcode", SqlDbType.VarChar, 50).Value = Session["Empcode"];
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
        string script = "alert('Record updtae!!');";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        bindgrid();
    }

    protected void lnkReset_Click(object sender, EventArgs e)
    {
        Response.Redirect("AssetType.aspx");
    }
}