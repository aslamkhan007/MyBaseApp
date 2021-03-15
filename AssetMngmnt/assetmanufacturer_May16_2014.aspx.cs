using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class AssetMngmnt_assetmanufacturer : System.Web.UI.Page
{
    string sql = string.Empty;
    SqlConnection con = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["misjctdev"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            bindgrid();
        }
        
    }

    private void bindgrid()
    {
        con.Open();
        sql = " SELECT manufacturer_id,manufacturer,description,CONVERT(VARCHAR(10),effective_from,101) AS EffectiveFrom,CONVERT(VARCHAR(10),effective_to,101) AS EffectiveTo,e_mail,ADDRESS,contact_num FROM jct_asset_manufacturer_master WHERE status='A'";
        SqlCommand cmd = new SqlCommand(sql, con);
        cmd.CommandType = CommandType.Text;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        grdDetail.DataSource = ds.Tables[0];
        grdDetail.DataBind();
        con.Close();
    }

    protected void lnkadd_Click(object sender, EventArgs e)
    {
        sql = "jct_asset_manufacturer_master_insert";
        SqlCommand cmd = new SqlCommand(sql, con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@manufacturer_name", SqlDbType.VarChar, 100).Value=txtmanfactname.Text;
        cmd.Parameters.Add("@manufacturer_desc", SqlDbType.VarChar, 100).Value=txtmanufactdesc.Text;
        cmd.Parameters.Add("@contact", SqlDbType.VarChar, 15).Value=txtcontactnum.Text;
        cmd.Parameters.Add("@address", SqlDbType.VarChar, 200).Value=txtaddress.Text;
        cmd.Parameters.Add("@email ", SqlDbType.VarChar, 100).Value=txtemail.Text;
        cmd.Parameters.Add("@eff_frm", SqlDbType.DateTime).Value=Convert.ToDateTime(txtefffrm.Text);
        cmd.Parameters.Add("@eff_to", SqlDbType.DateTime).Value=Convert.ToDateTime(txteffto.Text);
        cmd.Parameters.Add("@empcode", SqlDbType.VarChar, 120).Value = Session["EmpCode"];
        cmd.Parameters.Add("@vendor", SqlDbType.VarChar, 200).Value = txtvendor.Text;
        cmd.Parameters.Add("@vendoraddress", SqlDbType.VarChar, 200).Value = txtvendoraddres.Text;
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();

        bindgrid();

        string script = "alert('Record saved.!!');";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
      
    }

    protected void lnkdel_Click(object sender, EventArgs e)
    {
        sql = "jct_asset_manufacturer_master_delete";
        SqlCommand cmd = new SqlCommand(sql, con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@manufacturer_id", SqlDbType.VarChar, 100).Value = lbid.Text;

        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();

        bindgrid();

        string script = "alert('Record deleted.!!');";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        
    }

    protected void lnkupdate_Click(object sender, EventArgs e)
    {
        sql = "jct_asset_manufacturer_master_update";
        SqlCommand cmd = new SqlCommand(sql, con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@manufacturer_id", SqlDbType.VarChar, 100).Value = lbid.Text;
        cmd.Parameters.Add("@manufacturer_name", SqlDbType.VarChar, 100).Value = txtmanfactname.Text;
        cmd.Parameters.Add("@manufacturer_desc", SqlDbType.VarChar, 100).Value = txtmanufactdesc.Text;
        cmd.Parameters.Add("@contact", SqlDbType.VarChar, 15).Value = txtcontactnum.Text;
        cmd.Parameters.Add("@address", SqlDbType.VarChar, 200).Value = txtaddress.Text;
        cmd.Parameters.Add("@email ", SqlDbType.VarChar, 100).Value = txtemail.Text;
        cmd.Parameters.Add("@eff_frm", SqlDbType.DateTime).Value = Convert.ToDateTime(txtefffrm.Text);
        cmd.Parameters.Add("@eff_to", SqlDbType.DateTime).Value = Convert.ToDateTime(txteffto.Text);
        cmd.Parameters.Add("@empcode", SqlDbType.VarChar, 120).Value = "s-13823";

        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();

        bindgrid();

        string script = "alert('Record updated.!!');";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        
    }

    protected void lnkreset_Click(object sender, EventArgs e)
    {
        Response.Redirect("assetmanufacturer.aspx");
    }

    protected void grdDetail_SelectedIndexChanged(object sender, EventArgs e)
    {
        lbid.Text = grdDetail.SelectedRow.Cells[1].Text.Replace("&nbsp;", "");
        txtmanfactname.Text = grdDetail.SelectedRow.Cells[2].Text.Replace("&nbsp;", ""); ;
        txtmanufactdesc.Text = grdDetail.SelectedRow.Cells[3].Text.Replace("&nbsp;", ""); ;
        txtefffrm.Text = grdDetail.SelectedRow.Cells[4].Text.Replace("&nbsp;", ""); ;
        txteffto.Text = grdDetail.SelectedRow.Cells[5].Text.Replace("&nbsp;", ""); ;
        txtemail.Text = grdDetail.SelectedRow.Cells[6].Text.Replace("&nbsp;", ""); ;
        txtaddress.Text = grdDetail.SelectedRow.Cells[7].Text.Replace("&nbsp;", ""); ;
        txtcontactnum.Text = grdDetail.SelectedRow.Cells[8].Text.Replace("&nbsp;", ""); ;
        lnkadd.Enabled = false;
    }
   
}