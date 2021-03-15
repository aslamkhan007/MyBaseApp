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

public partial class AssetMngmnt_Furniture_Accepted_Pending_Report : System.Web.UI.Page
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
            ddlloc_SelectedIndexChanged(sender, null);
        }
    }

    protected void lnkfetch_Click(object sender, EventArgs e)
    {
        bindgrid();
    }

    private void bindgrid()
    {
        SqlCommand cmd = new SqlCommand("Jct_Asset_Accept_Pending_Itemwise_Report", obj.Connection());
        con.Open();
        cmd.CommandType = CommandType.StoredProcedure;
 
        if (!string.IsNullOrEmpty(txtempcode.Text))
        {

            if (txtempcode.Text.Contains('|'))
            {
                if (ddlloc.SelectedItem.Text == "Colony" || ddlloc.SelectedItem.Text == "colony" & txtempcode.Text != "")
                {
                    empcode = txtempcode.Text.Split('|')[1].ToString();
                    cmd.Parameters.Add("@Usercode", SqlDbType.VarChar, 50).Value = empcode.Split('~')[0].ToString();           

                }
            }
        }
        else
        {
            cmd.Parameters.Add("@Usercode", SqlDbType.VarChar, 50).Value = "";
           
        }
        cmd.Parameters.Add("@Location", SqlDbType.VarChar, 50).Value = ddlloc.SelectedItem.Text;
        cmd.Parameters.Add("@sub_location", SqlDbType.VarChar, 60).Value = ddlSubloc.SelectedItem.Text;
        cmd.Parameters.Add("@Is_Summary", SqlDbType.Char, 1).Value = ddlReport.SelectedItem.Value;
        cmd.Parameters.Add("@status", SqlDbType.Int).Value = ddlStatus.SelectedItem.Value; 
        

        cmd.ExecuteNonQuery();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        grdDetail.DataSource = ds;
        grdDetail.DataBind();
        con.Close();

    }
    protected void ddlloc_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        if (ddlloc.SelectedItem.Text == "Colony")
        {
            txtempcode.Enabled = true;
            txtempcode.Visible = true;
            //lblLocation.Text = "Department";
            //txtEmpCode.Enabled = false;
            lblLocation.Visible = true;

        }
        else
        {
            txtempcode.Enabled = false;
            txtempcode.Visible = false;
            //lblLocation.Text = "Department";
            //txtEmpCode.Enabled = false;
            lblLocation.Visible = false;
        }
        bindsublocation();
    }


    public void bindsublocation()
    {
        //sql = "Jct_Asset_FurdetailReport_Sublocation_Fetch";
        //SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        ////SqlCommand cmd = new SqlCommand("Select distinct '' as location Union   SELECT location  FROM dbo.jct_asset_location_master where status='A' AND main_location='" + ddlloc.SelectedItem.Text + "'", obj.Connection());
        //cmd.CommandType = CommandType.StoredProcedure;
        //cmd.Parameters.Add("@Location", SqlDbType.VarChar, 30).Value = ddlloc.SelectedItem.Text;
        //DataSet ds = new DataSet();
        //ds = new DataSet();
        //SqlDataAdapter da = new SqlDataAdapter(cmd);
        //da.Fill(ds);
        //ddlSubloc.DataSource = ds;
        //ddlSubloc.DataTextField = "location";
        //ddlSubloc.DataValueField = "location";
        //ddlSubloc.DataBind();


        SqlCommand cmd = new SqlCommand("SELECT '' as location  UNION SELECT  Sublocation  FROM dbo.jct_asset_sublocation_Type_master where status='A' AND location ='" + ddlloc.SelectedItem.Text + "'", obj.Connection());
        cmd.CommandType = CommandType.Text;
        DataSet ds = new DataSet();
        ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);
        ddlSubloc.DataSource = ds;
        ddlSubloc.DataTextField = "location";
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
    protected void excel_Click(object sender, EventArgs e)
    {
        GridViewExportUtil.Export("XL.xls", grdDetail);
    }
    protected void txtempcode_TextChanged(object sender, EventArgs e)
    {

    }
    protected void txtRequestId_TextChanged(object sender, EventArgs e)
    {

    }
}