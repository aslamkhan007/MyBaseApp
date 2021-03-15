using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Telerik.Web.UI;
using System.IO;
using System.Drawing;

public partial class AssetMngmnt_AssetFurnitureReport : System.Web.UI.Page
{
    string empcode;
    Connection obj = new Connection();
    string sql = string.Empty;
    SqlConnection con = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["misjctdev"].ConnectionString);    

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindlocation();
            bindsublocation();
            ddlloc_SelectedIndexChanged(sender, null);
        }
    }
    protected void txtempcode_TextChanged(object sender, EventArgs e)
    {
    
    }
    //protected void ddlAssetCatg_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    //{
    //    SqlDataSource4.SelectParameters["ASSET_TYPE_ID"].DefaultValue = ddlAssetCatg.SelectedValue;
    //    ddlItemDesc.DataBind();
    //}
    protected void grdDetail_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void lnkfetch_Click(object sender, EventArgs e)
    {
        bindgrid();
    }

    private void bindgrid()
    {
        //SqlCommand cmd = new SqlCommand("jct_ops_asset_Furniture_report_Delete", obj.Connection());
        SqlCommand cmd = new SqlCommand("jct_ops_asset_Furniture_report", obj.Connection());
        con.Open();
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add("@asset_type", SqlDbType.VarChar, 100).Value = ddlAssetType.SelectedItem.Text;        
     
        cmd.Parameters.Add("@asset_type_id", SqlDbType.VarChar, 20).Value = ddlAssetCatg.SelectedItem.Text;
                        
        cmd.Parameters.Add("@item_desc", SqlDbType.VarChar,30).Value = ddlItemDesc.SelectedItem.Text;
                  
        cmd.Parameters.Add("@asset_state", SqlDbType.VarChar, 100).Value = ddlassetstae.SelectedItem.Text;
       
        cmd.Parameters.Add("@dept", SqlDbType.VarChar, 100).Value = ddlloc.SelectedItem.Text;


        if (!string.IsNullOrEmpty(txtempcode.Text))
        {

            if (txtempcode.Text.Contains('|'))
            {
                if (ddlloc.SelectedItem.Text == "Colony" || ddlloc.SelectedItem.Text == "colony" & txtempcode.Text != "")
                {
                    empcode = txtempcode.Text.Split('|')[1].ToString();
                    cmd.Parameters.Add("@empcode", SqlDbType.VarChar, 30).Value = empcode.Split('~')[0].ToString();
                    cmd.Parameters.Add("@fur_dept", SqlDbType.VarChar, 30).Value = "";

                }

            }
        }
        else
        {
            cmd.Parameters.Add("@empcode", SqlDbType.VarChar, 30).Value = "";
            cmd.Parameters.Add("@fur_dept", SqlDbType.VarChar, 30).Value = ddlSubloc.SelectedItem.Text;
            //cmd.Parameters.Add("@fur_dept", SqlDbType.VarChar, 30).Value = "";
        }

        cmd.Parameters.Add("@sublocation", SqlDbType.VarChar, 50).Value = ddlSubloc.SelectedItem.Text; 

        //cmd.Parameters.Add("@empcode", SqlDbType.VarChar, 100).Value = txtempcode.Text.Split('~')[0].ToString();


        //if (!string.IsNullOrEmpty(txtempcode.Text))
        //{

        //    if (txtempcode.Text.Contains('|'))
        //    {
        //        if (ddlloc.SelectedItem.Text == "Company items")
        //        {
        //            empcode = txtempcode.Text.Split('|')[0].ToString();
        //            cmd.Parameters.Add("@empcode", SqlDbType.VarChar, 30).Value = empcode;
        //            //cmd.Parameters.Add("@fur_dept", SqlDbType.VarChar, 30).Value = empcode;
        //        }
        //        else
        //        {
        //            empcode = txtempcode.Text.Split('|')[1].ToString();
        //            cmd.Parameters.Add("@empcode", SqlDbType.VarChar, 30).Value = empcode.Split('~')[0].ToString();
        //            //cmd.Parameters.Add("@fur_dept", SqlDbType.VarChar, 30).Value = "";
        //        }
        //    }

        //    else if (txtempcode.Text.Contains('-'))
        //    {
        //        empcode = txtempcode.Text;
        //        cmd.Parameters.Add("@empcode", SqlDbType.VarChar, 30).Value = empcode;
        //    }
        //    else
        //    {
        //        string script = "alert('Please enter user for this item in EmpCode Textbox.');";
        //        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        //        return;
        //    }
        //   }


        //    else
        //    {

        //    }





            if (string.IsNullOrEmpty(txtFrom.Text))
            {
                txtFrom.Text = "";
            }
            else
            {
                cmd.Parameters.Add("@DateFrom", SqlDbType.DateTime).Value = txtFrom.Text;
            }
            if (string.IsNullOrEmpty(txtTo.Text))
            {
                txtTo.Text = "";
            }
            else
            {
                cmd.Parameters.Add("@DateTo", SqlDbType.DateTime).Value = txtTo.Text;
            }

            cmd.Parameters.Add("@reporttype", SqlDbType.VarChar, 20).Value = RadioButtonList1.SelectedItem.Text;

        cmd.ExecuteNonQuery();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds); 
        grdDetail.DataSource = ds;
        grdDetail.DataBind();
        con.Close();

    }

    protected void ddlloc_TextChanged(object sender, EventArgs e)
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
        sql = "Jct_Asset_FurdetailReport_Sublocation_Fetch";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        //SqlCommand cmd = new SqlCommand("Select distinct '' as location Union   SELECT location  FROM dbo.jct_asset_location_master where status='A' AND main_location='" + ddlloc.SelectedItem.Text + "'", obj.Connection());
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

    protected void ddlAssetType_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {

    }
    protected void ddlAssetCatg_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {

    }
    protected void excel_Click(object sender, EventArgs e)
    {
        GridViewExportUtil.Export("XL.xls", grdDetail);
    }

    protected void ImgSaveRecord_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton lnkbtn = sender as ImageButton;
        GridViewRow row = lnkbtn.NamingContainer as GridViewRow;
        int srno = Convert.ToInt32(row.Cells[12].Text);
        //ViewState["sr_id"] = srno;
        //string Location = row.Cells[3].Text;
        //string Sublocation = row.Cells[4].Text;
        //string usercode = row.Cells[5].Text;
        //string EmployeeName = row.Cells[6].Text;
        //DateTime eff_from = Convert.ToDateTime(row.Cells[7].Text);

        string script = string.Empty;
        string empcode = string.Empty;

        try
        {
            TextBox Unmapdate = (TextBox)row.FindControl("txtunmapdate");
            if (Unmapdate.Text != "")
            {
                DateTime UnMapDateValue = Convert.ToDateTime(Unmapdate.Text);
                SqlCommand cmd = new SqlCommand("jct_asset_Furniture_AllocDate_Update", obj.Connection());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@TransNo", SqlDbType.Int).Value = srno;
                cmd.Parameters.Add("@AllocationDate", SqlDbType.DateTime).Value = Unmapdate.Text;
                cmd.Parameters.Add("@Alloc_Update_BY", SqlDbType.VarChar, 30).Value = Session["EmpCode"].ToString();
                cmd.Parameters.Add("@Alloc_Update_HostName", SqlDbType.VarChar, 15).Value = Request.ServerVariables["REMOTE_ADDR"];
                cmd.Parameters.Add("@module_usedby", SqlDbType.VarChar, 30).Value = "GEN";               
                cmd.ExecuteNonQuery();               
                bindgrid();
                script = "alert('Allocation Date Changed Successfully!!');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                               
            }
            else
            {
                script = "alert('Allocation Date Cannot Be Empty!!');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
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