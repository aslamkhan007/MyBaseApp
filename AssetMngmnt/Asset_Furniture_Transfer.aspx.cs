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

public partial class AssetMngmnt_Asset_Furniture_Transfer : System.Web.UI.Page
{
    SqlTransaction tran;
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
            bindTragetlocation();
            ddlloc_SelectedIndexChanged(sender, null);
        }       
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

    public void bindsublocation()
    {
        sql = "Jct_Asset_FurdetailReport_Sublocation_Fetch";
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

    public void bindTragetlocation()
    {
        SqlCommand cmd = new SqlCommand("SELECT distinct main_location FROM jct_asset_location_master WHERE STATUS='A' AND main_location IS not null and module_usedby = 'GEN'", obj.Connection());
        cmd.CommandType = CommandType.Text;
        DataSet ds = new DataSet();
        ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);
        ddltargetloc.DataSource = ds;
        ddltargetloc.DataTextField = "main_location";
        ddltargetloc.DataValueField = "main_location";
        ddltargetloc.DataBind();
    }

    public void bindTargetsublocation()
    {
        sql = "Jct_Asset_Transfer_Sublocation_Fetch";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@Location", SqlDbType.VarChar, 30).Value = ddltargetloc.SelectedItem.Text;
        cmd.Parameters.Add("@OldSuLocation", SqlDbType.VarChar, 30).Value = ddlSubloc.SelectedItem.Text; 
        DataSet ds = new DataSet();
        ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);
        ddlTargetSubloc.DataSource = ds;
        ddlTargetSubloc.DataTextField = "location";
        ddlTargetSubloc.DataValueField = "location";
        ddlTargetSubloc.DataBind();
    }

    protected void ddlloc_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        bindsublocation();
        //bindgrid();
    }

    protected void lnkfetch_Click(object sender, EventArgs e)
    {
        bindgrid();
        bindTransfergrid();
    }

    protected void ddltargetloc_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        bindTargetsublocation();
        bindMappedEmployee();
        bindTransfergrid();
    }

    private void bindgrid()
    {
        SqlCommand cmd = new SqlCommand("Jct_Asset_Furniture_Transfer_Fetch", obj.Connection());
        con.Open();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@dept", SqlDbType.VarChar, 100).Value = ddlloc.SelectedItem.Text;
        cmd.Parameters.Add("@sublocation", SqlDbType.VarChar, 50).Value = ddlSubloc.SelectedItem.Text;
        cmd.ExecuteNonQuery();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        grdDetail.DataSource = ds;
        grdDetail.DataBind();
        con.Close();
    }

    private void bindTransfergrid()
    {
        SqlCommand cmd = new SqlCommand("Jct_Asset_Furniture_Transfer_Fetch", obj.Connection());
        con.Open();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@dept", SqlDbType.VarChar, 100).Value = ddltargetloc.SelectedItem.Text;
        cmd.Parameters.Add("@sublocation", SqlDbType.VarChar, 50).Value = ddlTargetSubloc.SelectedItem.Text;
        cmd.ExecuteNonQuery();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        grdTransfer.DataSource = ds;
        grdTransfer.DataBind();
        con.Close();
    }


    protected void lnkTransfer_Click(object sender, EventArgs e)
    {
        string OK = string.Empty;
        foreach (GridViewRow gvRow1 in grdDetail.Rows)
        {
            CheckBox chkRemove1 = (CheckBox)gvRow1.FindControl("chkRemove");
            if (chkRemove1.Checked == true)
            {
                 OK = "OK";
            }
        }
        if (OK == "OK")
        {
            int item_id;
            string script = string.Empty;
            string empcode = string.Empty;
            con.Open();
            tran = con.BeginTransaction();
            try
            {
                sql = "jct_asset_item_detail_Transfer_Header";
                SqlCommand cmd = new SqlCommand(sql, con, tran);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    cmd.Parameters.Add("@Olddeptloc", SqlDbType.VarChar, 50).Value = ddlloc.SelectedItem.Text;
                    cmd.Parameters.Add("@Newdeptloc", SqlDbType.VarChar, 50).Value = ddltargetloc.SelectedItem.Text;
                    cmd.Parameters.Add("@entry_by", SqlDbType.VarChar, 30).Value = Session["EmpCode"].ToString();
                    cmd.Parameters.Add("@item_id", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@module_usedby", SqlDbType.VarChar, 20).Value = "GEN";
                    cmd.Parameters.Add("@Oldsub_location", SqlDbType.VarChar, 50).Value = ddlSubloc.SelectedItem.Text;
                    cmd.Parameters.Add("@Newsub_location", SqlDbType.VarChar, 50).Value = ddlTargetSubloc.SelectedItem.Text;
                    cmd.Parameters.Add("@Hostname", SqlDbType.VarChar, 15).Value = Request.ServerVariables["REMOTE_ADDR"];
                    cmd.ExecuteNonQuery();

                }
                catch (SqlException ex)
                {
                    script = "alert('Error - " + ex.Message + "' );";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                    return;
                }

                item_id = Convert.ToInt32(cmd.Parameters["@item_id"].Value.ToString());
                ViewState["item_id"] = item_id;

                foreach (GridViewRow gvRow in grdDetail.Rows)
                {
                    CheckBox chkRemove = (CheckBox)gvRow.FindControl("chkRemove");
                    TextBox AllocationDate = (TextBox)gvRow.FindControl("txtAllocationDate");
                    if (chkRemove.Checked == true)
                    {
                        int TransNo = Convert.ToInt32(gvRow.Cells[8].Text);
                        cmd = new SqlCommand("jct_asset_type_item_detail_Transfer_Detail", con, tran);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@request_id", SqlDbType.Int).Value = ViewState["item_id"];
                        cmd.Parameters.Add("@TransNo", SqlDbType.Int).Value = TransNo;
                        cmd.Parameters.Add("@AllocationDate", SqlDbType.DateTime).Value = AllocationDate.Text;
                        cmd.ExecuteNonQuery();
                    }
                }

                sql = "jct_asset_type_item_detail_Transfer_insert_previousRecords";
                cmd = new SqlCommand(sql, con, tran);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@request_id", SqlDbType.Int).Value = ViewState["item_id"];
                cmd.ExecuteNonQuery();


                sql = "jct_asset_type_item_detail_Transfer_Merge_Furniture";
                cmd = new SqlCommand(sql, con, tran);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();


                sql = "jct_asset_type_item_detail_Transfer_Update_Furniture";
                cmd = new SqlCommand(sql, con, tran);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();



                // Entered on  28 jan 2016
                sql = "Jct_Asset_accept_Addtional_Detail";
                cmd = new SqlCommand(sql, con, tran);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Olddeptloc", SqlDbType.VarChar, 50).Value = ddlloc.SelectedItem.Text;
                cmd.Parameters.Add("@Newdeptloc", SqlDbType.VarChar, 50).Value = ddltargetloc.SelectedItem.Text;
                cmd.Parameters.Add("@Oldsub_location", SqlDbType.VarChar, 50).Value = ddlSubloc.SelectedItem.Text;
                cmd.Parameters.Add("@Newsub_location", SqlDbType.VarChar, 50).Value = ddlTargetSubloc.SelectedItem.Text;
                cmd.Parameters.Add("@RefdocType", SqlDbType.VarChar, 200).Value = ddlRefType.SelectedItem.Text;
                cmd.Parameters.Add("@RefdocNo", SqlDbType.VarChar, 200).Value = txtrefdocno.Text;
                cmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 200).Value = txtRemarks.Text;
                cmd.Parameters.Add("@entry_by", SqlDbType.VarChar, 30).Value = Session["EmpCode"].ToString();                
                cmd.ExecuteNonQuery();


                sql = "Jct_Asset_Accept_Null_RequestId";
                cmd = new SqlCommand(sql, con, tran);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Olddeptloc", SqlDbType.VarChar, 50).Value = ddlloc.SelectedItem.Text;
                cmd.Parameters.Add("@Newdeptloc", SqlDbType.VarChar, 50).Value = ddltargetloc.SelectedItem.Text;
                cmd.Parameters.Add("@Oldsub_location", SqlDbType.VarChar, 50).Value = ddlSubloc.SelectedItem.Text;
                cmd.Parameters.Add("@Newsub_location", SqlDbType.VarChar, 50).Value = ddlTargetSubloc.SelectedItem.Text;
                cmd.Parameters.Add("@entry_by", SqlDbType.VarChar, 30).Value = Session["EmpCode"].ToString();
                cmd.Parameters.Add("@module_usedby", SqlDbType.VarChar, 20).Value = "GEN";
                cmd.ExecuteNonQuery();

                script = "alert('Items Transfered!!');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                tran.Commit();
                con.Close();
                bindgrid();
                bindTransfergrid();

            }
            catch (Exception ex)
            {
                tran.Rollback();
                string script2 = "alert('" + ex.Message + "');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);
                return;
            }
            OK = string.Empty;
            
        }

        else
        {
            string  script2 = "alert('Please Check Atleast One Item To Be Transfered!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);
        }
        bindMappedEmployee();

    }

    protected void lnkReset_Click(object sender, EventArgs e)
    {
        Response.Redirect("Asset_Furniture_Transfer.aspx");
    }

    protected void ddlSubloc_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        ddltargetloc_SelectedIndexChanged(sender, e);
        bindgrid();
        bindMappedEmployee();
        bindTransfergrid();
    }

    protected void ddlTargetSubloc_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        bindMappedEmployee();
        bindTransfergrid();
    }

    public void bindMappedEmployee()
    {
        lblTotal.Text = null;
        lblMappedEmployee.Text = null;
        sql = "Jct_Asset_Furniture_Transfer_TotalItems_MappedEmployee";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@Dept", SqlDbType.VarChar, 30).Value = ddltargetloc.SelectedItem.Text;
        cmd.Parameters.Add("@sublocation", SqlDbType.VarChar, 30).Value = ddlTargetSubloc.SelectedItem.Text;
        DataSet ds = new DataSet();
        ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (Convert.ToString(ds.Tables[0].Rows[0]["MappedEmployee"]) == null || Convert.ToString(ds.Tables[0].Rows[0]["MappedEmployee"]) == "")
            {
                lblMappedEmployee.Text = null;
                lblMappedEmployee.Text = "No Employee Mapped";
                //lblTotal.Text = null;
                lblTotal.Text = ds.Tables[0].Rows[0]["NoOfItems"].ToString();

            }

            else
            {
                lblMappedEmployee.Text = ds.Tables[0].Rows[0]["MappedEmployee"].ToString();
                lblTotal.Text = ds.Tables[0].Rows[0]["NoOfItems"].ToString();
            }
        }

        else
        {
           
            lblMappedEmployee.Text = null;
            lblMappedEmployee.Text = "No Employee Mapped";
            lblTotal.Text = null;
        }
        ds.Dispose();
        
    }



    private void bindInvoicegrid()
    {
        SqlCommand cmd = new SqlCommand("Jct_Asset_Import_RefDocs_Info", obj.Connection());
        con.Open();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@DocType", SqlDbType.VarChar, 100).Value = ddlRefType.SelectedItem.Text;
        cmd.Parameters.Add("@DocNo", SqlDbType.VarChar, 50).Value = txtrefdocno.Text;
        cmd.ExecuteNonQuery();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);

        if (ds.Tables.Count > 0)
        {
            grdInvoiceDetail.DataSource = ds;
            grdInvoiceDetail.DataBind();
        }
        
        con.Close();
    }


    protected void lnkInvoiceDetail_Click(object sender, EventArgs e)
    {
        bindInvoicegrid();
    }
}