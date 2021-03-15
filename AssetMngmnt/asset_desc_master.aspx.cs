using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class AssetMngmnt_asset_desc_master : System.Web.UI.Page
{
    Connection obj = new Connection();
    Functions obj1 = new Functions();
    string sql = string.Empty;
    string script = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            sql = "SELECT DISTINCT  asset_type_id,asset_type_name FROM dbo.jct_asset_type_master WHERE STATUS='A' AND module_usedby = 'MIS' ";
            obj1.FillList(ddlasssetcat, sql);

            sql = "SELECT  DISTINCT type_name,SrNo FROM dbo.jct_asset_type_master_detail WHERE status='A' AND asset_type_id= '" + ddlasssetcat.SelectedItem.Value + "' AND module_usedby = 'MIS' ";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            ddlassettypes.DataSource = ds;

            ddlassettypes.DataTextField = "type_name";
            ddlassettypes.DataValueField = "SrNo";
            ddlassettypes.DataBind();

            bindgrid();
        }
    }
    protected void lnksave_Click(object sender, EventArgs e)
    {
        try
        {
            sql = "jct_asset_masters_desc_insert";
            SqlCommand cmd = new SqlCommand(sql,obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.Add("@id", SqlDbType.Int).Value = ddlasssetcat.SelectedItem.Value;
            //cmd.Parameters.Add("@assettypes", SqlDbType.VarChar,30).Value =   ddlassettypes.SelectedItem.Text;
            cmd.Parameters.Add("@asset_type_id", SqlDbType.Int).Value = ddlasssetcat.SelectedItem.Value;
            cmd.Parameters.Add("@asset_type_name", SqlDbType.VarChar, 100).Value = ddlasssetcat.SelectedItem.Text;
            cmd.Parameters.Add("@type_name", SqlDbType.VarChar, 100).Value = ddlassettypes.SelectedItem.Text;
            cmd.Parameters.Add("@type_description", SqlDbType.VarChar, 1000).Value = txtassetname.Text;//txtassetdesc.Text;
            if (txtwarranty.Text != string.Empty)
            {
                cmd.Parameters.Add("@warranty", SqlDbType.VarChar, 100).Value = txtwarranty.Text;
            }

            if (txtDOP.Text != string.Empty)
            {
                cmd.Parameters.Add("@dop", SqlDbType.DateTime).Value = Convert.ToDateTime(txtDOP.Text);
            }

            if (txtacquisitiondt.Text != string.Empty)
            {
                cmd.Parameters.Add("@acquisition_dt", SqlDbType.DateTime).Value = Convert.ToDateTime(txtacquisitiondt.Text);
            }

            if (ddlmanufacturer.Text != string.Empty)
            {
            cmd.Parameters.Add("@manufacturer_id", SqlDbType.VarChar, 100).Value = ddlmanufacturer.SelectedValue;
              }
            if (ddlstate.Text != string.Empty)
            {
                cmd.Parameters.Add("@state_id", SqlDbType.Int).Value = ddlstate.SelectedValue;
            }
            if (ddlcapital.Text != string.Empty)
            {
                cmd.Parameters.Add("@capital_id", SqlDbType.VarChar, 20).Value = ddlcapital.SelectedValue;
            }
            cmd.Parameters.Add("@created_by", SqlDbType.VarChar, 20).Value = Session["Empcode"];
            if (ddlvendor.Text != string.Empty)
            {
                cmd.Parameters.Add("@vendor", SqlDbType.VarChar, 90).Value = ddlvendor.SelectedItem.Text;
            }
            //if (ddlPrinterType.Visible == true)
            //{
            //    cmd.Parameters.Add("@type", SqlDbType.VarChar, 20).Value = ddlPrinterType.SelectedItem.Text;
            //}
            cmd.Parameters.Add("@module_usedby", SqlDbType.VarChar, 20).Value = "MIS";
            cmd.Parameters.Add("@Hostname", SqlDbType.VarChar, 15).Value = Request.ServerVariables["REMOTE_ADDR"];

            cmd.ExecuteNonQuery();
        

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
    protected void lnkupdate_Click(object sender, EventArgs e)
    {
         try
        {
            sql = "jct_asset_masters_desc_update";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.Add("@id", SqlDbType.Int).Value = ddlasssetcat.SelectedItem.Value;

            cmd.Parameters.Add("@id", SqlDbType.Int).Value = lblAssetNameID.Text;

           // cmd.Parameters.Add("@assettypes", SqlDbType.VarChar,30).Value =   ddlassettypes.SelectedItem.Text;
            cmd.Parameters.Add("@asset_type_id", SqlDbType.Int).Value = ddlasssetcat.SelectedItem.Value;
            cmd.Parameters.Add("@asset_type_name", SqlDbType.VarChar, 100).Value = ddlassettypes.SelectedItem.Text;
            cmd.Parameters.Add("@type_name", SqlDbType.VarChar, 100).Value = txtassetname.Text;//ddlassettypes.SelectedItem.Text;
            cmd.Parameters.Add("@type_description", SqlDbType.VarChar, 1000).Value = txtassetdesc.Text;
            if (txtwarranty.Text != string.Empty)
            {
                cmd.Parameters.Add("@warranty", SqlDbType.VarChar, 100).Value = txtwarranty.Text;
            }

            if (txtDOP.Text != string.Empty)
            {
                cmd.Parameters.Add("@dop", SqlDbType.DateTime).Value = Convert.ToDateTime(txtDOP.Text);
            }

            if (txtacquisitiondt.Text != string.Empty)
            {
                cmd.Parameters.Add("@acquisition_dt", SqlDbType.DateTime).Value = Convert.ToDateTime(txtacquisitiondt.Text);
            }

            if (ddlmanufacturer.Text != string.Empty)
            {
                cmd.Parameters.Add("@manufacturer_id", SqlDbType.VarChar, 100).Value = ddlmanufacturer.SelectedValue;
            }
            if (ddlstate.Text != string.Empty)
            {
                cmd.Parameters.Add("@state_id", SqlDbType.Int).Value = ddlstate.SelectedValue;
            }
            if (ddlcapital.Text != string.Empty)
            {
                cmd.Parameters.Add("@capital_id", SqlDbType.VarChar, 20).Value = ddlcapital.SelectedValue;
            }
            cmd.Parameters.Add("@created_by", SqlDbType.VarChar, 20).Value = Session["Empcode"];
            if (ddlvendor.Text != string.Empty)
            {
                cmd.Parameters.Add("@vendor", SqlDbType.VarChar, 90).Value = ddlvendor.SelectedItem.Text;
            }
         
            //if (ddlPrinterType.Visible == true)
            //{
            //    cmd.Parameters.Add("@type", SqlDbType.VarChar, 20).Value = ddlPrinterType.SelectedItem.Text;
            //}
            cmd.Parameters.Add("@module_usedby", SqlDbType.VarChar, 20).Value = "MIS";
            cmd.Parameters.Add("@Hostname", SqlDbType.VarChar, 15).Value = Request.ServerVariables["REMOTE_ADDR"];
            cmd.ExecuteNonQuery();

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
    protected void lnkdel_Click(object sender, EventArgs e)
    {

        try
        {
            sql = "jct_asset_masters_desc_delete";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = lblAssetNameID.Text;
            cmd.Parameters.Add("@empcode", SqlDbType.VarChar, 7).Value = Session["Empcode"];
            cmd.Parameters.Add("@module_usedby", SqlDbType.VarChar, 20).Value = "MIS";
            cmd.Parameters.Add("@Hostname", SqlDbType.VarChar, 15).Value = Request.ServerVariables["REMOTE_ADDR"];
            cmd.ExecuteNonQuery();

            bindgrid();

            script = "alert('Record Deleted.!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
        catch (Exception ex)
        {
            script = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }

    }
    protected void lnkresest_Click(object sender, EventArgs e)
    {
        Response.Redirect("asset_desc_master.aspx");

    }
    protected void ddlasssetcat_SelectedIndexChanged(object sender, EventArgs e)
    {
        sql = "SELECT  DISTINCT type_name,SrNo FROM dbo.jct_asset_type_master_detail WHERE status='A' AND asset_type_id= '" + ddlasssetcat.SelectedItem.Value + "' ";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.ExecuteNonQuery();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ddlassettypes.DataSource = ds;

        ddlassettypes.DataTextField = "type_name";
        ddlassettypes.DataValueField = "SrNo";
        ddlassettypes.DataBind();
    }
   
    protected void grdDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    protected void grdDetail_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblAssetNameID.Text = grdDetail.SelectedRow.Cells[1].Text.Replace("&nbsp;", "");
        //ddlassettypes.SelectedIndex = ddlassettypes.Items.IndexOf(ddlassettypes.Items.FindByText(grdDetail.SelectedRow.Cells[3].Text.Replace("&nbsp;", "")));
        ddlasssetcat.SelectedIndex = ddlasssetcat.Items.IndexOf(ddlasssetcat.Items.FindByText(grdDetail.SelectedRow.Cells[2].Text.Replace("&nbsp;", "")));
        txtassetname.Text = grdDetail.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");
        txtassetdesc.Text = grdDetail.SelectedRow.Cells[4].Text.Replace("&nbsp;", "");
        txtDOP.Text = grdDetail.SelectedRow.Cells[5].Text.Replace("&nbsp;", "");
        ddlmanufacturer.SelectedIndex = ddlmanufacturer.Items.IndexOf(ddlmanufacturer.Items.FindByValue(grdDetail.SelectedRow.Cells[6].Text));
        ddlstate.SelectedIndex = ddlstate.Items.IndexOf(ddlstate.Items.FindByValue(grdDetail.SelectedRow.Cells[7].Text));
        ddlcapital.SelectedIndex = ddlcapital.Items.IndexOf(ddlcapital.Items.FindByValue(grdDetail.SelectedRow.Cells[8].Text));
    }
    private void bindgrid()
    {
        SqlCommand cmd = new SqlCommand("jct_asset_masters_desc_fetch", obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 0;
   
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        grdDetail.DataSource = ds.Tables[0];
        grdDetail.DataBind();

    }
}