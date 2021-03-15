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

public partial class AssetMngmnt_standardVsActualItemComparision : System.Web.UI.Page
{
    string empcode = string.Empty;
    string sql = string.Empty;
    SqlConnection con = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["misjctdev"].ConnectionString);
    Connection obj = new Connection();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            bindlocation();
            bindsublocation();
        }
    }


    public void MappingDetail()
    {
        string sqlpass = "jct_asset_Standard_Actual_item_Comparision";
        SqlCommand cmd = new SqlCommand(sqlpass, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@Location", SqlDbType.VarChar, 30).Value = ddlloc.SelectedItem.Text;
        cmd.Parameters.Add("@sub_location", SqlDbType.VarChar, 60).Value = ddlSubloc.SelectedItem.Text;

        if (!string.IsNullOrEmpty(txtempcode.Text))
        {

            if (txtempcode.Text.Contains('|'))
            {
                //if (ddlloc.SelectedItem.Text == "Colony" || ddlloc.SelectedItem.Text == "colony" & txtempcode.Text != "")
                //{
                empcode = txtempcode.Text.Split('|')[1].ToString();
                cmd.Parameters.Add("@Usercode", SqlDbType.VarChar, 50).Value = empcode.Split('~')[0].ToString();

                //}
            }
            else
            {
                cmd.Parameters.Add("@Usercode", SqlDbType.VarChar, 50).Value = txtempcode.Text;

            }
        }
        else
        {
            cmd.Parameters.Add("@Usercode", SqlDbType.VarChar, 50).Value = "";

        }

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        grdDetail.DataSource = ds;
        grdDetail.DataBind();
    }
    public void bindsublocation()
    {
        //sql = "Jct_Asset_Furdetail_Sublocation_Fetch";
        sql = "Jct_Asset_Allocation_Comparision_Sublocation_Fetch";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
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
        //SqlCommand cmd = new SqlCommand("SELECT DISTINCT   '' AS main_location UNION SELECT  DISTINCT  main_location AS main_location FROM    jct_asset_location_master WHERE   STATUS = 'A' AND main_location IS NOT NULL AND module_usedby = 'GEN'", obj.Connection());
        SqlCommand cmd = new SqlCommand("SELECT  DISTINCT  main_location AS main_location FROM    jct_asset_location_master WHERE   STATUS = 'A' AND main_location IS NOT NULL AND module_usedby = 'GEN'", obj.Connection());
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

    protected void lnkfetch_Click(object sender, EventArgs e)
    {
        try
        {
            MappingDetail();
        }
        catch (Exception ex)
        {
            string script2 = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);
            return;
        }
    }
    protected void ddlloc_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        //if (ddlloc.SelectedItem.Text == "Colony")
        //{
        //    txtempcode.Enabled = true;
        //    txtempcode.Visible = true;
        //    lblLocation.Visible = true;

        //}
        //else
        //{
        //    txtempcode.Enabled = false;
        //    txtempcode.Visible = false;
        //    lblLocation.Visible = false;
        //}
        bindsublocation();
    }
    protected void ddlSubloc_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {

    }
    protected void txtempcode_TextChanged(object sender, EventArgs e)
    {

    }



    protected void grdDetail_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string reorderPoint = e.Row.Cells[6].Text;
            string MasterQuantity = e.Row.Cells[4].Text;
            string AllocateQuantity = e.Row.Cells[5].Text;


            if (reorderPoint == "NOT ELIGIBLE")
            {
                e.Row.Cells[6].CssClass = "blink_me";
            }

            if (reorderPoint == "OK")
            {
                e.Row.Cells[6].CssClass = "OK";
            }


            if (MasterQuantity == "&nbsp;")
            {
                e.Row.Cells[4].Text = "UNMAPPED ITEM";
            }


            if (AllocateQuantity == "&nbsp;")
            {
                e.Row.Cells[5].Text = "NOT ALLOCATED";
            }



        }
    }
    protected void excel_Click(object sender, EventArgs e)
    {
        GridViewExportUtil.Export("XL.xls", grdDetail);
    }
    protected void lnkReset_Click(object sender, EventArgs e)
    {
        Response.Redirect("standardVsActualItemComparision.aspx");
    }
}



