using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using Telerik.Web.UI;
using System.Text;
using System.Net.Mail;
public partial class AssetMngmnt_Asset_LocationStandardItemMaster : System.Web.UI.Page
{
    string sql = string.Empty;
    Connection obj = new Connection();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindlocation();
            bindsublocation();
            ddlloc_SelectedIndexChanged(sender, null);
            toshowfirstrow();
            Bindgrid();
        }      
    }


    private void toshowfirstrow()
    {
        DataTable dt = new DataTable();
        DataRow dr = null;
        dt.Columns.Add(new DataColumn("AssetType", typeof(string)));
        dt.Columns.Add(new DataColumn("AssetCategory", typeof(string)));
        dt.Columns.Add(new DataColumn("AssetDescription", typeof(string)));
        dt.Columns.Add(new DataColumn("NoOfItems", typeof(string)));
        dt.Columns.Add(new DataColumn("AllocationDate", typeof(string)));


        if (!string.IsNullOrEmpty(Request.QueryString["requestid"]))
        {
            dr = dt.NewRow();
            dr["AssetType"] = string.Empty;
            dr["AssetCategory"] = string.Empty;
            dr["AssetDescription"] = string.Empty;
            dr["NoOfItems"] = string.Empty;
            dr["AllocationDate"] = string.Empty;
            dt.Rows.Add(dr);
            dr = dt.NewRow();
        }
        else
        {
            for (int i = 0; i <= 0; i++)
            {
                dr = dt.NewRow();
                dr["AssetType"] = string.Empty;
                dr["AssetCategory"] = string.Empty;
                dr["AssetDescription"] = string.Empty;
                dr["NoOfItems"] = string.Empty;
                dr["AllocationDate"] = string.Empty;
                dt.Rows.Add(dr);
                dr = dt.NewRow();
            }
        }

        ViewState["CurrentTable"] = dt;
        grdDetail.DataSource = dt;
        grdDetail.DataBind();
    }
    public void bindsublocation()
    {
        sql = "Jct_Asset_LocationStandardItem_Sublocation_Fetch";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());

        //SqlCommand cmd = new SqlCommand("SELECT  location  FROM dbo.jct_asset_location_master where status='A' AND main_location ='" + ddlloc.SelectedItem.Text + "' ORDER BY LEFT(location,1)", obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@Location", SqlDbType.VarChar, 30).Value = ddlloc.SelectedItem.Text;
        DataSet ds = new DataSet();
        ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);
        ddlSubloc.DataSource = ds;
        ddlSubloc.DataTextField = "location";
        ddlSubloc.DataValueField = "location";
        ddlSubloc.DataBind();
    }

    public void bindlocation()
    {
        SqlCommand cmd = new SqlCommand("SELECT distinct main_location FROM jct_asset_location_master WHERE STATUS='A' AND main_location IS not null and module_usedby = 'GEN'", obj.Connection());
        cmd.CommandType = CommandType.Text;
        DataSet ds = new DataSet();
        ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);
        ddlloc.DataSource = ds;
        ddlloc.DataTextField = "main_location";
        ddlloc.DataValueField = "main_location";
        ddlloc.DataBind();
    }
    protected void ddlloc_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        bindsublocation();
        Bindgrid();
    }

    protected void ddlAssetTypeGrid_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        RadComboBox AssetType = (RadComboBox)sender;
        GridViewRow gridRow = (GridViewRow)AssetType.Parent.Parent;

        RadComboBox AssetCatg = (RadComboBox)gridRow.FindControl("ddlAssetCatg");
        SqlDataSource sqlDs = (SqlDataSource)gridRow.FindControl("SqlDataSource2");

        sqlDs.SelectParameters["ASSET_ID"].DefaultValue = AssetType.SelectedValue;
        AssetCatg.DataBind();

    }
    protected void ddlAssetCatg_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        RadComboBox AssetCatg = (RadComboBox)sender;
        GridViewRow gridRow = (GridViewRow)AssetCatg.Parent.Parent;

        RadComboBox ItemDesc = (RadComboBox)gridRow.FindControl("ddlItemDesc");
        SqlDataSource sqlDs = (SqlDataSource)gridRow.FindControl("SqlDataSource3");

        sqlDs.SelectParameters["ASSET_TYPE_ID"].DefaultValue = AssetCatg.SelectedValue;
        ItemDesc.DataBind();
    }

    protected void grdDetail_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        GridViewRow row = e.Row;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            RadComboBox AssetType = (RadComboBox)row.FindControl("ddlAssetTypeGrid");
            RadComboBox AssetCatg = (RadComboBox)row.FindControl("ddlAssetCatg");
            RadComboBox ItemDesc = (RadComboBox)row.FindControl("ddlItemDesc");


            RadNumericTextBox txtnoofitems = (RadNumericTextBox)e.Row.FindControl("txtNoOfItems");
            string txtnoOfItemsValue = txtnoofitems.Text;


            //RadNumericTextBox txtAcqDt = (RadNumericTextBox)e.Row.FindControl("txtAcqDt");

            RadDatePicker txtAcqDt = (RadDatePicker)e.Row.FindControl("txtAcqDt");
            //DateTime txtAcqDtValue = txtAcqDt



            SqlDataSource assetType_sqlDS = (SqlDataSource)row.Cells[0].FindControl("SqlDataSource1");
            SqlDataSource assetCatg_sqlDS = (SqlDataSource)row.Cells[1].FindControl("SqlDataSource2");
            SqlDataSource desc_sqlDS = (SqlDataSource)row.Cells[2].FindControl("SqlDataSource3");

            // AssetType.DataSource = assetType_sqlDS;
            AssetType.DataBind();

            //assetCatg_sqlDS.SelectParameters["ASSET_ID"].DefaultValue = AssetType.SelectedValue;
            AssetCatg.DataBind();

            //desc_sqlDS.SelectParameters["ASSET_TYPE_ID"].DefaultValue = AssetCatg.SelectedValue;
            ItemDesc.DataBind();

            txtnoofitems.Text = txtnoOfItemsValue.ToString();
            //txtAcqDt.SelectedDate = txtAcqDtValue;
            //txtAcqDt1.Text = txtAcqDtValue.ToString();

        }
    }


    protected void lnkaddrow_Click(object sender, EventArgs e)
    {
        fun2();
    }
    private void fun2()
    {
        int rowIndex = 0;

        if (ViewState["CurrentTable"] != null)
        {
            DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
            DataRow drCurrentRow = null;
            if (dtCurrentTable.Rows.Count > 0)
            {
                RadComboBox assettype = (RadComboBox)grdDetail.Rows[rowIndex].Cells[0].FindControl("ddlAssetTypeGrid");
                RadComboBox assetcat = (RadComboBox)grdDetail.Rows[rowIndex].Cells[1].FindControl("ddlAssetCatg");
                RadComboBox desc = (RadComboBox)grdDetail.Rows[rowIndex].Cells[2].FindControl("ddlItemDesc");
                SqlDataSource assetType_sqlDS = (SqlDataSource)grdDetail.Rows[rowIndex].Cells[0].FindControl("SqlDataSource1");
                SqlDataSource assetCatg_sqlDS = (SqlDataSource)grdDetail.Rows[rowIndex].Cells[1].FindControl("SqlDataSource2");
                SqlDataSource desc_sqlDS = (SqlDataSource)grdDetail.Rows[rowIndex].Cells[2].FindControl("SqlDataSource3");

                drCurrentRow = dtCurrentTable.NewRow();

                drCurrentRow[0] = assettype.SelectedValue;
                drCurrentRow[1] = assetcat.SelectedValue;
                drCurrentRow[2] = desc.SelectedValue;

                assettype.SelectedIndex = assettype.Items.IndexOf(assettype.Items.FindItemByValue(assettype.SelectedValue));

                //assetCatg_sqlDS.SelectParameters["ASSET_ID"].DefaultValue = assettype.SelectedValue;
                //assetcat.DataBind();

                assetcat.SelectedIndex = assetcat.Items.IndexOf(assetcat.Items.FindItemByValue(assetcat.SelectedValue));

                //desc_sqlDS.SelectParameters["ASSET_TYPE_ID"].DefaultValue = assetcat.SelectedValue;
                //assetcat.DataBind();

                desc.SelectedIndex = desc.Items.IndexOf(desc.Items.FindItemByValue(desc.SelectedValue));

                dtCurrentTable.Rows.Add(drCurrentRow);
                ViewState["CurrentTable"] = dtCurrentTable;

                grdDetail.DataSource = dtCurrentTable;
                grdDetail.DataBind();
            }
        }
        else
        {
            Response.Write("ViewState is null");
        }
        SetPreviousData();
    }
    private void SetPreviousData()
    {
        int rowIndex = 0;
        if (ViewState["CurrentTable"] != null)
        {
            DataTable dt = (DataTable)ViewState["CurrentTable"];
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    RadComboBox assettype = (RadComboBox)grdDetail.Rows[i].Cells[0].FindControl("ddlAssetTypeGrid");
                    RadComboBox assetcat = (RadComboBox)grdDetail.Rows[i].Cells[1].FindControl("ddlAssetCatg");
                    RadComboBox desc = (RadComboBox)grdDetail.Rows[i].Cells[2].FindControl("ddlItemDesc");
                    SqlDataSource assetType_sqlDS = (SqlDataSource)grdDetail.Rows[i].Cells[0].FindControl("SqlDataSource1");
                    SqlDataSource assetCatg_sqlDS = (SqlDataSource)grdDetail.Rows[i].Cells[1].FindControl("SqlDataSource2");
                    SqlDataSource desc_sqlDS = (SqlDataSource)grdDetail.Rows[i].Cells[2].FindControl("SqlDataSource3");

                    assettype.SelectedIndex = assettype.Items.IndexOf(assettype.Items.FindItemByValue(dt.Rows[i][0].ToString()));//.FindByText(grdDetail.SelectedRow.Cells[0].Text));

                    assetCatg_sqlDS.SelectParameters["ASSET_ID"].DefaultValue = assettype.SelectedValue;
                    assetcat.DataBind();

                    assetcat.SelectedIndex = assetcat.Items.IndexOf(assetcat.Items.FindItemByValue(dt.Rows[i][1].ToString()));

                    desc_sqlDS.SelectParameters["ASSET_TYPE_ID"].DefaultValue = assetcat.SelectedValue;
                    desc.DataBind();

                    desc.SelectedIndex = desc.Items.IndexOf(desc.Items.FindItemByValue(dt.Rows[i][2].ToString()));
                    rowIndex++;
                }
            }
        }
    }

    protected void grdDetail_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Remove")
        {
            int rowIndex = 0;
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                rowIndex = gvr.RowIndex;
                dt.Rows.RemoveAt(rowIndex);
                grdDetail.DataSource = dt;
                grdDetail.DataBind();
                SetPreviousData();
                ViewState["CurrentTable"] = dt;
                if (dt.Rows.Count == 0)
                {
                   
                }
            }
        }
    }

    protected void lnkApply_Click(object sender, EventArgs e)
    {    
        try
        {

           foreach (GridViewRow gvRow in grdDetail.Rows)
            {
                RadComboBox AssetType = (RadComboBox)gvRow.FindControl("ddlAssetTypeGrid");
                RadComboBox AssetCatg = (RadComboBox)gvRow.FindControl("ddlAssetCatg");
                RadComboBox ItemDesc = (RadComboBox)gvRow.FindControl("ddlItemDesc");
                RadNumericTextBox txtnoofitems = (RadNumericTextBox)gvRow.FindControl("txtNoOfItems");


                SqlCommand cmd = new SqlCommand("jct_asset_LocationStandardItem_master_Insert", obj.Connection());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Location", SqlDbType.VarChar, 15).Value = ddlloc.SelectedItem.Text;
                cmd.Parameters.Add("@Sublocation", SqlDbType.VarChar, 50).Value = ddlSubloc.SelectedItem.Text;
                cmd.Parameters.Add("@asset_id", SqlDbType.Int).Value = Convert.ToInt16(AssetType.SelectedValue);
                cmd.Parameters.Add("@asset_type_id", SqlDbType.Int).Value = Convert.ToInt16(AssetCatg.SelectedValue);
                cmd.Parameters.Add("@asset_type_name", SqlDbType.VarChar, 200).Value = AssetCatg.SelectedItem.Text;
                cmd.Parameters.Add("@item_desc", SqlDbType.VarChar, 100).Value = ItemDesc.SelectedItem.Text.Split(',')[0].ToString();

                if (!string.IsNullOrEmpty(ItemDesc.SelectedItem.Value.Replace("&nbsp;", "")))
                {
                    cmd.Parameters.Add("@item_desc_value", SqlDbType.Int).Value = ItemDesc.SelectedItem.Value.Split('-')[0];
                }

                if (!string.IsNullOrEmpty(txtnoofitems.Text))
                {
                    cmd.Parameters.Add("@No_of_items", SqlDbType.Int).Value = Convert.ToInt16(txtnoofitems.Text);
                }
                cmd.Parameters.Add("@STATUS", SqlDbType.Char, 1).Value = "A";
                cmd.Parameters.Add("@Created_by", SqlDbType.VarChar, 30).Value = Session["EmpCode"].ToString();
                cmd.Parameters.Add("@Hostname", SqlDbType.VarChar, 100).Value = Request.ServerVariables["REMOTE_ADDR"];
                cmd.Parameters.Add("@module_usedby", SqlDbType.VarChar, 100).Value = "GEN";
                cmd.ExecuteNonQuery();
                            
                  
            }
           Bindgrid();
           string script = "alert('Record saved!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);                      
            //toshowfirstrow();            
        }
            
        catch (Exception ex)
        {         
            string script2 = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);
            return;
        }

    }

    protected void Bindgrid()
    {
        sql = "jct_asset_LocationStandardItem_master_fetch";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@location", SqlDbType.VarChar, 50).Value = ddlloc.SelectedItem.Value;
        cmd.Parameters.Add("@Sublocation", SqlDbType.VarChar, 50).Value = ddlSubloc.SelectedItem.Value; 
        cmd.Parameters.Add("@module_usedby", SqlDbType.VarChar, 20).Value = "Gen";
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);

        GridView1.DataSource = ds.Tables[0];
        GridView1.DataBind();
    }



    protected void lnkReset_Click(object sender, EventArgs e)
    {
        Response.Redirect("Asset_LocationStandardItemMaster.aspx");
    }

    protected void ddlSubloc_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        Bindgrid();
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "deleterow")
            {
                GridViewRow row = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);                 
                    int id = Convert.ToInt32(row.Cells[1].Text);
                    TextBox remarks = (TextBox)row.FindControl("txtremarks");
                    sql = "UPDATE  jct_asset_LocationStandardItem_master  SET status = 'D' , Deleted_by = '" + Session["EmpCode"] + "' , Deleted_ip = '" + Request.ServerVariables["REMOTE_ADDR"] + "' , Remarks = '" + remarks.Text + "' , Deleted_date = getdate()    WHERE   id   = " + id + "  AND     status = 'A' ";
                    SqlCommand cmd = new SqlCommand(sql, obj.Connection());
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    string script = "alert('Record Deleted Successfully !!');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                    Bindgrid();
            }
        }
        catch (Exception ex)
        {
            string script2 = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);
            return;
        }
    }

}