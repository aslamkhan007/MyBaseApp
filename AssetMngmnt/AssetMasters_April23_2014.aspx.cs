using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class AssetMngmnt_AssetMasters : System.Web.UI.Page
{

    Connection obj = new Connection();
    Functions obj1 = new Functions();
    string sql = string.Empty;
    string script = string.Empty;

    SqlConnection con = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["misjctdev"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindgrid();
        }

    }
    protected void ddlasssetcat_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            SqlDataSource4.SelectParameters["asset_id"].DefaultValue = ddlasssetcat.SelectedValue;
            ddlassettype.DataTextField = "asset_type_name";
            ddlassettype.DataValueField = "asset_type_id";
            ddlassettype.DataBind();

            SqlCommand cmd = new SqlCommand("jct_asset_masters_fetch", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@asset_id", SqlDbType.Int).Value = ddlasssetcat.SelectedItem.Value;
            cmd.Parameters.Add("@asset_type_id", SqlDbType.Int).Value = ddlassettype.SelectedItem.Value;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                grdDetail.DataSource = ds.Tables[0];
                grdDetail.DataBind();
            }
            con.Close();
        }
        catch (Exception ex)
        {
            script = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
        
    }
    protected void lnksave_Click(object sender, EventArgs e)
    {
        try
        {
            sql = "jct_asset_masters_insert";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@asset_id", SqlDbType.Int).Value = ddlasssetcat.SelectedItem.Value;
            cmd.Parameters.Add("@asset_type_id", SqlDbType.Int).Value = ddlassettype.SelectedItem.Value;
            cmd.Parameters.Add("@asset_type_name", SqlDbType.VarChar, 100).Value = ddlassettype.SelectedItem.Text;
            cmd.Parameters.Add("@type_name", SqlDbType.VarChar, 100).Value = txtassetname.Text;
            cmd.Parameters.Add("@type_description", SqlDbType.VarChar, 1000).Value = txtassetdesc.Text;
            cmd.Parameters.Add("@warranty", SqlDbType.VarChar, 100).Value = txtwarranty.Text;

            if (txtDOP.Text != string.Empty)
            {
                cmd.Parameters.Add("@dop", SqlDbType.DateTime).Value = Convert.ToDateTime(txtDOP.Text);
            }

            if (txtacquisitiondt.Text != string.Empty)
            {
                cmd.Parameters.Add("@acquisition_dt", SqlDbType.DateTime).Value = Convert.ToDateTime(txtacquisitiondt.Text);
            }

            cmd.Parameters.Add("@manufacturer_id", SqlDbType.VarChar, 100).Value = ddlmanufacturer.SelectedValue;
            cmd.Parameters.Add("@state_id", SqlDbType.Int).Value = ddlstate.SelectedValue;
            cmd.Parameters.Add("@capital_id", SqlDbType.VarChar, 20).Value = ddlcapital.SelectedValue;
            cmd.Parameters.Add("@created_by", SqlDbType.VarChar, 20).Value = Session["Empcode"];

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            bindgrid();
            script = "alert('Record saved.!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            
        }
        catch (Exception ex)
        {
            script = "alert('"+ ex.Message +"');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblAssetNameID.Text = grdDetail.SelectedRow.Cells[1].Text.Replace("&nbsp;", "");
        ddlassettype.SelectedIndex = ddlassettype.Items.IndexOf(ddlassettype.Items.FindByText(grdDetail.SelectedRow.Cells[2].Text.Replace("&nbsp;", "")));
        ddlasssetcat.SelectedIndex = ddlasssetcat.Items.IndexOf(ddlasssetcat.Items.FindByText(grdDetail.SelectedRow.Cells[3].Text.Replace("&nbsp;", "")));
        txtassetname.Text = grdDetail.SelectedRow.Cells[4].Text.Replace("&nbsp;", "");
        txtassetdesc.Text = grdDetail.SelectedRow.Cells[6].Text.Replace("&nbsp;", "");
        txtDOP.Text = grdDetail.SelectedRow.Cells[5].Text.Replace("&nbsp;","");
        ddlmanufacturer.SelectedIndex = ddlmanufacturer.Items.IndexOf(ddlmanufacturer.Items.FindByText(grdDetail.SelectedRow.Cells[7].Text));
        ddlstate.SelectedIndex = ddlstate.Items.IndexOf(ddlstate.Items.FindByText(grdDetail.SelectedRow.Cells[8].Text));
        ddlcapital.SelectedIndex = ddlcapital.Items.IndexOf(ddlcapital.Items.FindByText(grdDetail.SelectedRow.Cells[9].Text));
    }

    protected void ddlassettype_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            bindgrid();
        }
        catch(Exception ex)
        {
            script = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
        finally
        {
            con.Close();
        }
    }
    protected void lnkdel_Click(object sender, EventArgs e)
    {
        try
        {
            sql = "jct_asset_masters_delete";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = lblAssetNameID.Text;
            cmd.Parameters.Add("@empcode", SqlDbType.VarChar, 7).Value = "s-13823";// Session["Empcode"];
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            bindgrid();

            script = "alert('Record Deleted.!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            
        }
        catch (Exception ex)
        {
            script = "alert('"+ ex.Message +"');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
       
    }

    protected void lnkupdate_Click(object sender, EventArgs e)
    {
        try
        {
            sql = "jct_asset_masters_update";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = lblAssetNameID.Text;
            cmd.Parameters.Add("@asset_id", SqlDbType.Int).Value = ddlasssetcat.SelectedItem.Value;
            cmd.Parameters.Add("@asset_type_id", SqlDbType.Int).Value = ddlassettype.SelectedItem.Value;
            cmd.Parameters.Add("@asset_type_name", SqlDbType.VarChar, 100).Value = ddlassettype.SelectedItem.Text;
            cmd.Parameters.Add("@type_name", SqlDbType.VarChar, 100).Value = txtassetname.Text;
            cmd.Parameters.Add("@type_description", SqlDbType.VarChar, 1000).Value = txtassetdesc.Text;

            if (txtDOP.Text != string.Empty)
            {
                cmd.Parameters.Add("@dop", SqlDbType.DateTime).Value = Convert.ToDateTime(txtDOP.Text);
            }

            if (txtacquisitiondt.Text != string.Empty)
            {
                cmd.Parameters.Add("@acquisition_dt", SqlDbType.DateTime).Value = Convert.ToDateTime(txtacquisitiondt.Text);
            }

            cmd.Parameters.Add("@manufacturer_id", SqlDbType.VarChar, 100).Value = ddlmanufacturer.SelectedValue;
            cmd.Parameters.Add("@state_id", SqlDbType.Int).Value = ddlstate.SelectedValue;
            cmd.Parameters.Add("@capital_id", SqlDbType.VarChar, 20).Value = ddlcapital.SelectedValue;
            cmd.Parameters.Add("@created_by", SqlDbType.VarChar, 20).Value = Session["Empcode"];

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            bindgrid();

            script = "alert('Record updated.!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
           
        }
        catch (Exception ex)
        {
            script = "alert('"+ ex.Message +"');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
        
    }

    protected void grdDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdDetail.PageIndex = e.NewPageIndex;
        bindgrid();
    }

    protected void lnkresest_Click(object sender, EventArgs e)
    {
        Response.Redirect("AssetMasters.aspx");
    }

    private void bindgrid()
    {
        SqlCommand cmd = new SqlCommand("jct_asset_masters_fetch", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();

        if (ddlasssetcat.SelectedValue != string.Empty && ddlassettype.SelectedValue != "-1")
        {
            cmd.Parameters.Add("@asset_id", SqlDbType.Int).Value = ddlasssetcat.SelectedItem.Value;
        }

        if (ddlassettype.SelectedValue != string.Empty && ddlassettype.SelectedValue !="-1")
        {
            cmd.Parameters.Add("@asset_type_id", SqlDbType.Int).Value = ddlassettype.SelectedItem.Value;
        }

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        grdDetail.DataSource = ds.Tables[0];
        grdDetail.DataBind();
        con.Close();
    }
}
