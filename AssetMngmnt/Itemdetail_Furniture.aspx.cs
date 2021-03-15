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
using System.Net;
public partial class AssetMngmnt_Itemdetail_Furniture : System.Web.UI.Page
{
    SqlTransaction tran;
    string requestID = string.Empty;
    //string oldrequestID = string.Empty;
    string sql = string.Empty;
    string dept = string.Empty;
    SqlConnection con = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["misjctdev"].ConnectionString);
Connection obj = new Connection();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Empcode"] == "")
        {
            Response.Redirect("~/Login.aspx");
        }

        if (!IsPostBack)
        {
            bindlocation();
            bindsublocation();


            //SqlCommand cmd = new SqlCommand("SELECT distinct ID,main_location FROM jct_asset_location_master WHERE STATUS='A' AND main_location IS NOT null and module_usedby = 'GEN'   order by ID", obj.Connection());
            //cmd.CommandType = CommandType.Text;
            //DataSet ds = new DataSet();
            //ds = new DataSet();
            //SqlDataAdapter da = new SqlDataAdapter(cmd);
            //da.Fill(ds);
            //ddlloc.DataSource = ds;
            //ddlloc.DataTextField = "main_location";
            //ddlloc.DataValueField = "ID";
            //ddlloc.DataBind();


            //cmd = new SqlCommand("SELECT  location  FROM dbo.jct_asset_location_master where status='A' AND main_location ='" + ddlloc.SelectedItem.Text + "'", obj.Connection());
            //cmd.CommandType = CommandType.Text;
            // ds = new DataSet();
            //ds = new DataSet();
            // da = new SqlDataAdapter(cmd);
            //da.Fill(ds);
            //ddlSubloc.DataSource = ds;
            //ddlSubloc.DataTextField = "location";
            //ddlSubloc.DataValueField = "location";
            //ddlSubloc.DataBind();



            ddlloc_SelectedIndexChanged(sender, null);
            toshowfirstrow();

            if (!string.IsNullOrEmpty(Request.QueryString["requestid"]))
            {
                requestID = Request.QueryString["requestid"].ToString();
                ViewState["oldrequestID"] = Request.QueryString["requestid"].ToString();

                FillData();

                lnksave.Enabled = false;
                //
                ddlloc.Enabled = false;
                ddlSubloc.Enabled = false;
                txtEmpCode.Enabled = false;
                ddlState.Enabled = false;
                //txtAcqDt.Enabled = false;
                ddlCapital.Enabled = false;
                txtRemarks.Enabled = false;
            }
            else
            {
                lnkupdate.Enabled = false;
                lnkDelete.Enabled = false;
            }

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
            //SELECT 25457+68542+6658+  6958+3245 +1475+3558+6985   175
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
    protected void lnksave_Click(object sender, EventArgs e)
    {
        string item_id = string.Empty;        
        string script = string.Empty;
        string empcode = string.Empty;

        SqlTransaction tran;
        con.Open();
        tran = con.BeginTransaction();
        try
        {
            sql = "jct_asset_item_detail_insert_new";
            SqlCommand cmd = new SqlCommand(sql,con,tran);
            //con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.Add("@item_desc", SqlDbType.VarChar, 500).Value = "";
            cmd.Parameters.Add("@item_name", SqlDbType.VarChar, 100).Value = "";
            cmd.Parameters.Add("@modelno", SqlDbType.VarChar, 50).Value = "";
            cmd.Parameters.Add("@item_desc", SqlDbType.VarChar, 500).Value = txtRemarks.Text;                       
            cmd.Parameters.Add("@deptloc", SqlDbType.VarChar, 50).Value = ddlloc.SelectedItem.Text;
            cmd.Parameters.Add("@DOP", SqlDbType.DateTime).Value = Convert.ToDateTime("01/01/2099");
            cmd.Parameters.Add("@acquisitiondate", SqlDbType.DateTime).Value = Convert.ToDateTime("01/01/2099");

                if (!string.IsNullOrEmpty(txtEmpCode.Text) && ddlloc.SelectedItem.Text=="Colony"  )
                    {
                        if (txtEmpCode.Text.Contains('|'))
                        {
                            //if (ddlloc.SelectedItem.Text == "Colony" || ddlloc.SelectedItem.Text=="colony")
                           if (ddlloc.SelectedItem.Text == "Colony")
                            {
                                empcode = txtEmpCode.Text.Split('|')[1].ToString();
                                cmd.Parameters.Add("@usercode", SqlDbType.VarChar, 30).Value = empcode.Split('~')[0].ToString();
                                cmd.Parameters.Add("@fur_dept", SqlDbType.VarChar, 30).Value = ddlSubloc.SelectedItem.Text;
                    
                            }
            
                        }
                        else
                        {

                            script = "alert('Invalid EmployeeCode!!');";
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                            return;



                        }
                    }
                   else
                    {

                        cmd.Parameters.Add("@usercode", SqlDbType.VarChar, 30).Value = "";
                        cmd.Parameters.Add("@fur_dept", SqlDbType.VarChar, 30).Value = ddlSubloc.SelectedItem.Text;

                    }



           

            cmd.Parameters.Add("@location", SqlDbType.VarChar, 50).Value = ddlShadred.SelectedItem.Text;
            cmd.Parameters.Add("@asset_state", SqlDbType.Int).Value = ddlState.SelectedItem.Value;            
            cmd.Parameters.Add("@entry_by", SqlDbType.VarChar, 30).Value = Session["EmpCode"].ToString();
            cmd.Parameters.Add("@computer_name", SqlDbType.VarChar, 100).Value = "";
            cmd.Parameters.Add("@capital_item", SqlDbType.VarChar, 100).Value = ddlCapital.SelectedItem.Value;
            cmd.Parameters.Add("@jctSR_NO", SqlDbType.VarChar, 100).Value = "";
            cmd.Parameters.Add("@shared", SqlDbType.VarChar, 100).Value = "";
            cmd.Parameters.Add("@shareduser", SqlDbType.VarChar, 200).Value = "";
            cmd.Parameters.Add("@item_id", SqlDbType.Int).Direction = ParameterDirection.Output;                       
            cmd.Parameters.Add("@manufacturer_id", SqlDbType.Int).Value = 0;           
            cmd.Parameters.Add("@IP_address", SqlDbType.VarChar, 50).Value = "";
            cmd.Parameters.Add("@printertype", SqlDbType.VarChar, 20).Value = "";
            cmd.Parameters.Add("@printer", SqlDbType.VarChar, 50).Value = "";
            cmd.Parameters.Add("@computer_type", SqlDbType.VarChar, 20).Value = "";
            cmd.Parameters.Add("@vendor", SqlDbType.VarChar, 50).Value = "";
            cmd.Parameters.Add("@sr_no", SqlDbType.VarChar, 50).Value = "";
            cmd.Parameters.Add("@SharedDesc", SqlDbType.VarChar, 500).Value = "";
            //cmd.Parameters.Add("@module_usedby", SqlDbType.VarChar, 20).Value = ViewState["dept"];
            cmd.Parameters.Add("@module_usedby", SqlDbType.VarChar, 20).Value = "GEN";
            cmd.Parameters.Add("@sub_location", SqlDbType.VarChar, 50).Value = ddlSubloc.SelectedItem.Text;
            cmd.Parameters.Add("@Hostname", SqlDbType.VarChar, 15).Value = Request.ServerVariables["REMOTE_ADDR"];
            cmd.ExecuteNonQuery();

            item_id = cmd.Parameters["@item_id"].Value.ToString();
            ViewState["RequestID"] = item_id;
            //con.Close();

            foreach (GridViewRow gvRow in grdDetail.Rows)
            {
                RadComboBox AssetType = (RadComboBox)gvRow.FindControl("ddlAssetTypeGrid");
                RadComboBox AssetCatg = (RadComboBox)gvRow.FindControl("ddlAssetCatg");
                RadComboBox ItemDesc = (RadComboBox)gvRow.FindControl("ddlItemDesc");
                RadNumericTextBox txtnoofitems = (RadNumericTextBox)gvRow.FindControl("txtNoOfItems");
                RadDatePicker txtAcqDt = (RadDatePicker)gvRow.FindControl("txtAcqDt");
                DateTime txtAcqDtValue = txtAcqDt.SelectedDate.Value;

                        cmd = new SqlCommand("jct_asset_type_item_detail_insert_furniture", con, tran);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@request_id", SqlDbType.Int).Value = item_id;

                        cmd.Parameters.Add("@item_desc", SqlDbType.VarChar, 100).Value = ItemDesc.SelectedItem.Text.Split(',')[0].ToString();
                        string VAL =  ItemDesc.SelectedItem.Text.Split(',')[1].ToString();
                        cmd.Parameters.Add("@Balance_Qty", SqlDbType.Int).Value = Convert.ToInt16(VAL.Split('-')[0].ToString());
                        //cmd.Parameters.Add("@manufacture", SqlDbType.VarChar, 100).Value = ItemDesc.SelectedItem.Value.Split('-')[1].ToString(); 
                        cmd.Parameters.Add("@manufacture", SqlDbType.VarChar, 100).Value = ItemDesc.SelectedItem.Value.Split('-', '$')[1].ToString();

                        if (!string.IsNullOrEmpty(ItemDesc.SelectedItem.Value.Replace("&nbsp;", "")))
                        {
                            cmd.Parameters.Add("@item_value", SqlDbType.Int).Value = ItemDesc.SelectedItem.Value.Split('-')[0];
                        }
                        // cmd.Parameters.Add("@item_value", SqlDbType.Int).Value = ItemDesc.SelectedItem.Value;
                        cmd.Parameters.Add("@asset_id", SqlDbType.Int).Value = Convert.ToInt16(AssetType.SelectedValue);
                        cmd.Parameters.Add("@asset_type_id", SqlDbType.Int).Value = Convert.ToInt16(AssetCatg.SelectedValue);
                        cmd.Parameters.Add("@asset_type_name", SqlDbType.VarChar, 200).Value = AssetCatg.SelectedItem.Text;

                        if (!string.IsNullOrEmpty(txtnoofitems.Text))
                        {
                            cmd.Parameters.Add("@No_of_items", SqlDbType.Int).Value = Convert.ToInt16(txtnoofitems.Text);
                        }
                        //cmd.Parameters    .Add("@module_usedby", SqlDbType.VarChar, 20).Value = ViewState["dept"];
                        cmd.Parameters.Add("@module_usedby", SqlDbType.VarChar, 20).Value = "GEN";

                        cmd.Parameters.Add("@ALLOCATION_DATE", SqlDbType.DateTime).Value = Convert.ToDateTime(txtAcqDt.SelectedDate.Value);
                        //con.Open();
                        cmd.Parameters.Add("@item_desc_id", SqlDbType.Int).Value = Convert.ToInt32(ItemDesc.SelectedItem.Value.Split('$')[1]);
                        cmd.ExecuteNonQuery();
                        //con.Close();
                      
            }
            script = "alert('Record saved!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            tran.Commit();
            con.Close();
            toshowfirstrow();
            //sendmail();
            
        }
            
        catch (Exception ex)
        {
            tran.Rollback();
            string script2 = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);
            return;
        }
    }

    /*
The let keyword before hero creates a template input variable called hero. The NgForOf directive iterates over the heroes array returned by the parent component's heroes
  property and sets hero to the current item from the array during each iteration.

You reference the hero input variable within the NgForOf host element (and within its descendants) to access the hero's properties.
   Here it is referenced first in an interpolation and then passed in a binding to the hero property of the <hero-detail> component.  
     * 
<div *ngFor="let hero of heroes">{{hero.name}}</div>
<app-hero-detail *ngFor="let hero of heroes" [hero]="hero"></app-hero-detail>     
     */

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
                //if (rowIndex == 0)
                //{
                //    lnksave.Enabled = false;
                //}
                dt.Rows.RemoveAt(rowIndex);
                grdDetail.DataSource = dt;
                grdDetail.DataBind();
                SetPreviousData();
                ViewState["CurrentTable"] = dt;
                if (dt.Rows.Count == 0)
                {
                    lnksave.Enabled = false;
                }
            }
        }
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

    protected void lnkupdate_Click(object sender, EventArgs e)
    {
        int ret_val;
        string script = string.Empty;
        string empcode = string.Empty;

        //SqlTransaction tran;
        con.Open();
        tran = con.BeginTransaction();

        try
        {
            string Printer = string.Empty;
            sql = "jct_asset_item_detail_update_furniture";
            SqlCommand cmd = new SqlCommand(sql, con,tran);
            //con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.Parameters.Add("@item_desc", SqlDbType.VarChar, 500).Value = txtRemarks.Text; 
                cmd.Parameters.Add("@item_name", SqlDbType.VarChar, 100).Value = "";
                cmd.Parameters.Add("@modelno", SqlDbType.VarChar, 50).Value = "";

                cmd.Parameters.Add("@DOP", SqlDbType.DateTime).Value = Convert.ToDateTime("01/01/2099");
                cmd.Parameters.Add("@acquisitiondate", SqlDbType.DateTime).Value = Convert.ToDateTime("01/01/2099");

                if (!string.IsNullOrEmpty(txtEmpCode.Text))
                {

                    if (txtEmpCode.Text.Contains('|'))
                    {
                        if (ddlloc.SelectedItem.Text == "Colony" || ddlloc.SelectedItem.Text == "colony")
                        {
                            empcode = txtEmpCode.Text.Split('|')[1].ToString();
                            cmd.Parameters.Add("@usercode", SqlDbType.VarChar, 30).Value = empcode.Split('~')[0].ToString();
                            cmd.Parameters.Add("@fur_dept", SqlDbType.VarChar, 30).Value = ddlSubloc.SelectedItem.Text;

                        }

                    }
                    else
                    {
                        script = "alert('Invalid EmployeeCode!!');";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                        return;
                        //cmd.Parameters.Add("@usercode", SqlDbType.VarChar, 30).Value = "";
                        //cmd.Parameters.Add("@fur_dept", SqlDbType.VarChar, 30).Value = ddlSubloc.SelectedItem.Text;

                    }
                }
                else
                {

                    cmd.Parameters.Add("@usercode", SqlDbType.VarChar, 30).Value = "";
                    cmd.Parameters.Add("@fur_dept", SqlDbType.VarChar, 30).Value = ddlSubloc.SelectedItem.Text;

                }


                cmd.Parameters.Add("@location", SqlDbType.VarChar, 50).Value = ddlShadred.SelectedItem.Text;
                cmd.Parameters.Add("@asset_state", SqlDbType.Int).Value = ddlState.SelectedItem.Value;
                cmd.Parameters.Add("@Dept", SqlDbType.VarChar, 100).Value = "";
                cmd.Parameters.Add("@entry_by", SqlDbType.VarChar, 30).Value = Session["EmpCode"].ToString();
                cmd.Parameters.Add("@computer_name", SqlDbType.VarChar, 100).Value = "";
                cmd.Parameters.Add("@capital_item", SqlDbType.VarChar, 100).Value = ddlCapital.SelectedItem.Value;
                cmd.Parameters.Add("@jctSR_NO", SqlDbType.VarChar, 100).Value = "";
                cmd.Parameters.Add("@shared", SqlDbType.VarChar, 100).Value = "";
                cmd.Parameters.Add("@item_id", SqlDbType.Int).Value = ViewState["RequestID"];
                cmd.Parameters.Add("@manufacturer_id", SqlDbType.Int).Value = 0;
                cmd.Parameters.Add("@IP_address", SqlDbType.VarChar, 50).Value = "";
                cmd.Parameters.Add("@printertype", SqlDbType.VarChar, 20).Value = "";
                cmd.Parameters.Add("@printer", SqlDbType.VarChar, 50).Value = "";
                cmd.Parameters.Add("@computer_type", SqlDbType.VarChar, 20).Value = "";
                cmd.Parameters.Add("@ret_val", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@vendor", SqlDbType.VarChar, 50).Value = "";
                cmd.Parameters.Add("@sr_no", SqlDbType.VarChar, 50).Value = "";
                cmd.Parameters.Add("@SharedDesc", SqlDbType.VarChar, 500).Value = "";
                cmd.Parameters.Add("@deptloc", SqlDbType.VarChar, 50).Value = ddlloc.SelectedItem.Text;
                cmd.Parameters.Add("@module_usedby", SqlDbType.VarChar, 20).Value = "GEN";
                cmd.Parameters.Add("@PREVIOUS_ID", SqlDbType.Int).Value = ViewState["oldrequestID"];
                cmd.Parameters.Add("@sub_location", SqlDbType.VarChar, 50).Value = ddlSubloc.SelectedItem.Text;
                cmd.Parameters.Add("@Hostname", SqlDbType.VarChar, 15).Value = Request.ServerVariables["REMOTE_ADDR"];
                cmd.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                script = "alert('Error - " + ex.Message + "' );";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                return;
            }


            ret_val = Convert.ToInt16(cmd.Parameters["@ret_val"].Value.ToString());
            ViewState["RequestID"] = ret_val;
            ViewState["NewRequestID"] = ret_val;
            //con.Close();

            foreach (GridViewRow gvRow in grdDetail.Rows)
            {
                RadComboBox AssetType = (RadComboBox)gvRow.FindControl("ddlAssetTypeGrid");
                RadComboBox AssetCatg = (RadComboBox)gvRow.FindControl("ddlAssetCatg");
                RadComboBox ItemDesc = (RadComboBox)gvRow.FindControl("ddlItemDesc");
                RadNumericTextBox txtnoofitems = (RadNumericTextBox)gvRow.FindControl("txtNoOfItems");
                RadDatePicker txtAcqDt = (RadDatePicker)gvRow.FindControl("txtAcqDt");

                       cmd = new SqlCommand("jct_asset_type_item_detail_update_furniture", con, tran);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@request_id", SqlDbType.Int).Value = ViewState["RequestID"];//ret_val;
                        //cmd.Parameters.Add("@item_desc", SqlDbType.VarChar, 200).Value = ItemDesc.SelectedItem.Text;
                        cmd.Parameters.Add("@item_desc", SqlDbType.VarChar, 100).Value = ItemDesc.SelectedItem.Text.Split(',')[0].ToString();


                        string VAL = ItemDesc.SelectedItem.Text.Split(',')[1].ToString();

                        cmd.Parameters.Add("@Balance_Qty", SqlDbType.Int).Value = Convert.ToInt16(VAL.Split('-')[0].ToString());
                        //cmd.Parameters.Add("@manufacture", SqlDbType.VarChar, 100).Value = ItemDesc.SelectedItem.Value.Split('-')[1].ToString(); 
                        cmd.Parameters.Add("@manufacture", SqlDbType.VarChar, 100).Value = ItemDesc.SelectedItem.Value.Split('-', '$')[1].ToString();

                        //cmd.Parameters.Add("@Balance_Qty", SqlDbType.Int).Value = Convert.ToInt16(ItemDesc.SelectedItem.Text.Split(',')[1].ToString()); 
                        if (!string.IsNullOrEmpty(ItemDesc.SelectedItem.Value.Replace("&nbsp;", "")))
                        {
                            cmd.Parameters.Add("@item_value", SqlDbType.Int).Value = ItemDesc.SelectedItem.Value.Split('-')[0];
                        }

                        cmd.Parameters.Add("@asset_id", SqlDbType.Int).Value = Convert.ToInt16(AssetType.SelectedValue);
                        cmd.Parameters.Add("@asset_type_id", SqlDbType.Int).Value = Convert.ToInt16(AssetCatg.SelectedValue);
                        cmd.Parameters.Add("@asset_type_name", SqlDbType.VarChar, 100).Value = AssetCatg.SelectedItem.Text;
                        cmd.Parameters.Add("@new_requestid", SqlDbType.Int).Value = ret_val;
                        cmd.Parameters.Add("@mode", SqlDbType.VarChar, 20).Value = "Update";
                        if (!string.IsNullOrEmpty(txtnoofitems.Text))
                        {
                            cmd.Parameters.Add("@No_of_items", SqlDbType.Int).Value = Convert.ToInt16(txtnoofitems.Text);
                        }
                        //cmd.Parameters.Add("@module_usedby", SqlDbType.VarChar, 20).Value = ViewState["dept"];
                        cmd.Parameters.Add("@module_usedby", SqlDbType.VarChar, 20).Value = "GEN";
                        //cmd.Parameters.Add("@oldrequestID", SqlDbType.Int).Value = ViewState["oldrequestID"]; 


                        cmd.Parameters.Add("@ALLOCATION_DATE", SqlDbType.DateTime).Value = Convert.ToDateTime(txtAcqDt.SelectedDate.Value);

                        cmd.Parameters.Add("@item_desc_id", SqlDbType.Int).Value = Convert.ToInt32(ItemDesc.SelectedItem.Value.Split('$')[1]);
               

                        //con.Open();
                        cmd.ExecuteNonQuery();
                        //con.Close();    



                //NEW CODE
                        //cmd = new SqlCommand("jct_asset_masters_furniture_desc_trans_update", con, tran);

                        //cmd.CommandType = CommandType.StoredProcedure;

                        //cmd.Parameters.Add("@asset_type_id", SqlDbType.Int).Value = Convert.ToInt16(AssetCatg.SelectedValue);

                        //if (!string.IsNullOrEmpty(ItemDesc.SelectedItem.Value.Replace("&nbsp;", "")))
                        //{
                        //    cmd.Parameters.Add("@item_value", SqlDbType.Int).Value = ItemDesc.SelectedItem.Value;
                        //}
                        //cmd.Parameters.Add("@item_desc", SqlDbType.VarChar, 100).Value = ItemDesc.SelectedItem.Text.Split(',')[0].ToString();

                        //if (!string.IsNullOrEmpty(txtnoofitems.Text))
                        //{
                        //    cmd.Parameters.Add("@quantity", SqlDbType.Int).Value = Convert.ToInt16(txtnoofitems.Text);
                        //}

                        //cmd.ExecuteNonQuery();
           
            }

            //foreach (GridViewRow gvRow in grdItemDetail.Rows)
            //{
            //    cmd = new SqlCommand("jct_asset_type_item_detail_update", con,tran);
            //    cmd.CommandType = CommandType.StoredProcedure;
            //    cmd.Parameters.Add("@request_id", SqlDbType.Int).Value = ret_val;
            //    cmd.Parameters.Add("@item_desc", SqlDbType.VarChar, 100).Value = gvRow.Cells[4].Text;
            //    if (!string.IsNullOrEmpty(gvRow.Cells[6].Text.Replace("&nbsp;", "")))
            //    {
            //        cmd.Parameters.Add("@item_value", SqlDbType.Int).Value = Convert.ToInt16(gvRow.Cells[6].Text);
            //    }
            //    cmd.Parameters.Add("@asset_id", SqlDbType.Int).Value = Convert.ToInt16(gvRow.Cells[1].Text);
            //    cmd.Parameters.Add("@asset_type_id", SqlDbType.Int).Value = Convert.ToInt16(gvRow.Cells[2].Text);
            //    cmd.Parameters.Add("@asset_type_name", SqlDbType.VarChar, 200).Value = gvRow.Cells[3].Text; ;
            //    cmd.Parameters.Add("@mode", SqlDbType.VarChar, 20).Value = "Update";
            //    cmd.Parameters.Add("@new_requestid", SqlDbType.Int).Value = ret_val;

            //    if (!string.IsNullOrEmpty(gvRow.Cells[7].Text.Replace("&nbsp;", "")))             
            //    {
            //        cmd.Parameters.Add("@No_of_items", SqlDbType.Int).Value = Convert.ToInt16(gvRow.Cells[7].Text);
            //    }
               
            //    //cmd.Parameters.Add("@module_usedby", SqlDbType.VarChar, 20).Value = ViewState["dept"];
            //    cmd.Parameters.Add("@module_usedby", SqlDbType.VarChar, 20).Value = "GEN"; 

            //    //con.Open();
            //    cmd.ExecuteNonQuery();
            //    //con.Close();
            //}




            sql = "jct_asset_type_item_detail_insert_previousRecords";
            cmd = new SqlCommand(sql, con, tran);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@new_requestid", SqlDbType.Int).Value = ViewState["NewRequestID"];
            cmd.Parameters.Add("@oldrequestID", SqlDbType.Int).Value = ViewState["oldrequestID"];
            cmd.ExecuteNonQuery();



            sql = "jct_asset_type_item_detail_update_merge_furniture";
            cmd = new SqlCommand(sql, con,tran);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();


            sql = "UPDATE  jct_asset_type_item_detail SET status = 'U'  WHERE   request_id = " + Convert.ToInt32(ViewState["oldrequestID"]) + "  AND     status = 'A'  AND module_usedby = 'GEN'";
            cmd = new SqlCommand(sql, con, tran);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();



            // added on  21 nov 2015 
            sql = "Jct_Asset_Accept_Update_RequestId_check";
            //sql = "Jct_Asset_Accept_Update_RequestId";
            cmd = new SqlCommand(sql, con, tran);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@RequestID", SqlDbType.Int).Value = ViewState["oldrequestID"];
            cmd.Parameters.Add("@NewRequestID", SqlDbType.Int).Value = ViewState["NewRequestID"];
            cmd.Parameters.Add("@Location", SqlDbType.VarChar, 50).Value = ddlloc.SelectedItem.Text;
            cmd.Parameters.Add("@sub_location", SqlDbType.VarChar, 60).Value = ddlSubloc.SelectedItem.Text;
            cmd.Parameters.Add("@Hostname", SqlDbType.VarChar, 15).Value = Request.ServerVariables["REMOTE_ADDR"];
            cmd.Parameters.Add("@module_usedby", SqlDbType.VarChar, 20).Value = "GEN";
            cmd.ExecuteNonQuery();



            // re-fill all the data
            //FillData();
            lnkupdate.Enabled = false;
            script = "alert('Record updated!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
            tran.Commit();
            con.Close();
            toshowfirstrow();

            if (!string.IsNullOrEmpty(Request.QueryString["requestid"]))
            {
                requestID = Request.QueryString["requestid"].ToString();

                FillDataUpdate();

                lnksave.Enabled = false;
            }
            else
            {
                lnkupdate.Enabled = false;
                lnkDelete.Enabled = false;
            }
            //sendmail();

        }
        catch (Exception ex)
        {
            tran.Rollback();
            string script2 = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);
            return;
        }
    }


    protected void FillDataUpdate()
    {
        try
        {
            //ddlDept.DataBind();
            ddlloc.DataBind();
            ddlState.DataBind();
            //sql = "jct_asset_item_furniture_detail_select_furniture_28jan2015";
            sql = "jct_asset_item_furniture_detail_select_furniture";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;

            if (ViewState["NewRequestID"] != string.Empty)
            {
                cmd.Parameters.Add("@requestid", SqlDbType.Int).Value = Convert.ToInt16(ViewState["NewRequestID"]);
            }

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet dsItem = new DataSet();
            da.Fill(dsItem);
            //da.Fill(dsItem.Tables["Itemdetail"]);

            foreach (DataRow dr in dsItem.Tables[0].Rows)
            {
                txtEmpCode.Text = dr["empcode"].ToString();

                ddlloc.SelectedIndex = ddlloc.Items.IndexOf(ddlloc.Items.FindItemByText(dr["deptloc"].ToString()));
                ddlSubloc.SelectedIndex = ddlSubloc.Items.IndexOf(ddlSubloc.Items.FindItemByText(dr["sub_location"].ToString()));
                ddlState.SelectedIndex = ddlState.Items.IndexOf(ddlState.Items.FindItemByText(dr["assetstate"].ToString()));

                ddlShadred.SelectedIndex = ddlShadred.Items.IndexOf(ddlShadred.Items.FindItemByText(dr["plant"].ToString()));

                ddlCapital.SelectedIndex = ddlCapital.Items.IndexOf(ddlCapital.Items.FindItemByValue(dr["capitalitem"].ToString()));

                txtRemarks.Text = dr["itemdescription"].ToString();

                //if (string.IsNullOrEmpty(dr["acquisitiondate"].ToString()))
                //{
                //    txtAcqDt.Text = string.Empty;
                //}
                //else
                //{
                //    txtacqdt_CalendarExtender.SelectedDate = Convert.ToDateTime(dr["acquisitiondate"].ToString()).Date;
                //}

                ViewState["RequestID"] = dr["item_id"].ToString();
            }

            //grdDetail.DataSource = dsItem.Tables[1];
            //grdDetail.DataBind();


            ViewState["dtgridItems"] = dsItem.Tables[1];
            grdItemDetail.DataSource = dsItem.Tables[1];
            grdItemDetail.DataBind();
            //lnksave.Enabled = false;

            if (!string.IsNullOrEmpty(Request.QueryString["requestid"]))
            {
                grdItemDetail.Visible = true;
            }
            else
            {
                lnkupdate.Enabled = false;
                lnkDelete.Enabled = false;
            }

        }
        catch (Exception ex)
        {
            string script2 = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);
            return;
        }
    }


    protected void FillData()
    {
        try
        {
            //ddlDept.DataBind();
            ddlloc.DataBind();
            ddlState.DataBind();
            bindsublocation();
            //ddlSubloc.DataBind();
            //ddlloc_SelectedIndexChanged(sender,e);
            //sql = "jct_asset_item_furniture_detail_select_furniture_28jan2015";
            sql = "jct_asset_item_furniture_detail_select_furniture";
            SqlCommand cmd = new SqlCommand(sql,obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;

            if (requestID != string.Empty)
            {
                cmd.Parameters.Add("@requestid", SqlDbType.Int).Value = Convert.ToInt16(requestID);
            }

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet dsItem = new DataSet();
            da.Fill(dsItem);
            //da.Fill(dsItem.Tables["Itemdetail"]);

            foreach (DataRow dr in dsItem.Tables[0].Rows)
            {
                //if (dsItem.Tables["empcode"].ToString() == "")
                if (string.IsNullOrEmpty(dr["empcode"].ToString()))

                {
                    txtEmpCode.Text = dr["fur_dept"].ToString();
                    //ReqtxtAcqDt0.Enabled = false;
                    ddlloc.SelectedIndex = ddlloc.Items.IndexOf(ddlloc.Items.FindItemByText(dr["deptloc"].ToString()));


                    cmd = new SqlCommand("SELECT  location  FROM dbo.jct_asset_location_master where status='A' AND main_location ='" + ddlloc.SelectedItem.Text + "'", obj.Connection());
                    cmd.CommandType = CommandType.Text;
                    DataSet ds = new DataSet();
                    ds = new DataSet();
                    da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    ddlSubloc.DataSource = ds;
                    ddlSubloc.DataTextField = "location";
                    ddlSubloc.DataValueField = "location";
                    ddlSubloc.DataBind();


                    ddlSubloc.SelectedIndex = ddlSubloc.Items.IndexOf(ddlSubloc.Items.FindItemByText(dr["sub_location"].ToString()));
                    ddlState.SelectedIndex = ddlState.Items.IndexOf(ddlState.Items.FindItemByText(dr["assetstate"].ToString()));

                    ddlShadred.SelectedIndex = ddlShadred.Items.IndexOf(ddlShadred.Items.FindItemByText(dr["plant"].ToString()));

                    ddlCapital.SelectedIndex = ddlCapital.Items.IndexOf(ddlCapital.Items.FindItemByValue(dr["capitalitem"].ToString()));

                    txtRemarks.Text = dr["itemdescription"].ToString();

                    //if (string.IsNullOrEmpty(dr["acquisitiondate"].ToString()))
                    //{
                    //    txtAcqDt.Text = string.Empty;
                    //}
                    //else
                    //{
                    //    txtacqdt_CalendarExtender.SelectedDate = Convert.ToDateTime(dr["acquisitiondate"].ToString()).Date;
                    //}

                    ViewState["RequestID"] = dr["item_id"].ToString();
                }
                else
                {
                    txtEmpCode.Text = dr["empcode"].ToString();
                    //ReqtxtAcqDt0.Enabled = true;
                    ddlloc.SelectedIndex = ddlloc.Items.IndexOf(ddlloc.Items.FindItemByText(dr["deptloc"].ToString()));



                    cmd = new SqlCommand("SELECT  location  FROM dbo.jct_asset_location_master where status='A' AND main_location ='" + ddlloc.SelectedItem.Text + "'", obj.Connection());
                    cmd.CommandType = CommandType.Text;
                    DataSet ds = new DataSet();
                    ds = new DataSet();
                    da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    ddlSubloc.DataSource = ds;
                    ddlSubloc.DataTextField = "location";
                    ddlSubloc.DataValueField = "location";
                    ddlSubloc.DataBind();



                    ddlSubloc.SelectedIndex = ddlSubloc.Items.IndexOf(ddlSubloc.Items.FindItemByText(dr["sub_location"].ToString()));
                    ddlState.SelectedIndex = ddlState.Items.IndexOf(ddlState.Items.FindItemByText(dr["assetstate"].ToString()));

                    ddlShadred.SelectedIndex = ddlShadred.Items.IndexOf(ddlShadred.Items.FindItemByText(dr["plant"].ToString()));

                    ddlCapital.SelectedIndex = ddlCapital.Items.IndexOf(ddlCapital.Items.FindItemByValue(dr["capitalitem"].ToString()));

                    txtRemarks.Text = dr["itemdescription"].ToString();

                    //if (string.IsNullOrEmpty(dr["acquisitiondate"].ToString()))
                    //{
                    //    txtAcqDt.Text = string.Empty;
                    //}
                    //else
                    //{
                    //    txtacqdt_CalendarExtender.SelectedDate = Convert.ToDateTime(dr["acquisitiondate"].ToString()).Date;
                    //}

                    ViewState["RequestID"] = dr["item_id"].ToString();
                }
            }

            //grdDetail.DataSource = dsItem.Tables[1];
            //grdDetail.DataBind();


            ViewState["dtgridItems"] = dsItem.Tables[1];
            grdItemDetail.DataSource = dsItem.Tables[1];
            grdItemDetail.DataBind();
            //lnksave.Enabled = false;

            if (!string.IsNullOrEmpty(Request.QueryString["requestid"]))
            {
                grdItemDetail.Visible = true;
            }
            else
            {
                lnkupdate.Enabled = false;
                lnkDelete.Enabled = false;
            }

        }
        catch (Exception ex)
        {
            string script2 = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);
            return;
        }
    }

    protected void lnkReset_Click(object sender, EventArgs e)
    {
        Response.Redirect("Itemdetail_Furniture.aspx");
    }

    protected void lnkDelete_Click(object sender, EventArgs e)
    {
        //DataTable dt = new DataTable();
        //dt = (DataTable)ViewState["dtgridItems"];
        //SqlTransaction tran;
        con.Open();
        tran = con.BeginTransaction();

        try
        {
            foreach (GridViewRow gvRow in grdItemDetail.Rows)
            {
                CheckBox chkRemove = (CheckBox)gvRow.FindControl("chkRemove");
                int TransNo = Convert.ToInt16(gvRow.Cells[11].Text);
                int assetid = Convert.ToInt16(gvRow.Cells[1].Text);
                int assetypeid = Convert.ToInt16(gvRow.Cells[2].Text);
                string itemdesctext = gvRow.Cells[3].Text;
                string ITEMDESC = gvRow.Cells[4].Text;
                int requestid = Convert.ToInt16(gvRow.Cells[5].Text);
                int itemdescvalue = Convert.ToInt16(gvRow.Cells[6].Text);
                int quantity = Convert.ToInt16(gvRow.Cells[7].Text);
                if (chkRemove.Checked == true)
                {
                    //SqlTransaction tran;
                    //con.Open();
                    //tran = con.BeginTransaction();
                    try
                    {

                        //int rowIndex = 0;
                        //rowIndex = gvRow.RowIndex;
                        //dt.Rows.RemoveAt(rowIndex);
                        //sql = "Update jct_asset_type_item_detail set status='D' , Hostname = '"+ Request.ServerVariables["REMOTE_ADDR"]+ "'   WHERE asset_id = '" + assetid + "' AND  asset_type_id = '" + assetypeid + "'  AND  asset_type_name = '" + itemdesctext + "' AND item_desc = '" + ITEMDESC + "' AND request_id = '" + requestid + "' AND item_desc_value = '" + itemdescvalue + "' AND status  = 'A' ";
                        sql = "Update jct_asset_type_item_detail set status='D' , Hostname = '" + Request.ServerVariables["REMOTE_ADDR"] + "'   WHERE asset_id = '" + assetid + "' AND  asset_type_id = '" + assetypeid + "'  AND  asset_type_name = '" + itemdesctext + "' AND item_desc = '" + ITEMDESC + "' AND request_id = '" + requestid + "' AND item_desc_value = '" + itemdescvalue + "' AND status  = 'A' and TransNo = '" + TransNo + "' ";

                        SqlCommand cmd = new SqlCommand(sql, con, tran);
                        cmd.ExecuteNonQuery();

                        //cmd = new SqlCommand("jct_asset_masters_furniture_desc_trans_standby_update", con, tran);

                        //cmd.CommandType = CommandType.StoredProcedure;

                        //cmd.Parameters.Add("@asset_type_id", SqlDbType.Int).Value = assetypeid;

                        //cmd.Parameters.Add("@item_desc_id", SqlDbType.Int).Value = itemdescvalue;

                        //cmd.Parameters.Add("@item_desc_text", SqlDbType.VarChar, 100).Value = ITEMDESC;

                        //cmd.Parameters.Add("@quantity", SqlDbType.Int).Value = quantity;

                        //cmd.ExecuteNonQuery();
                        //tran.Commit();
                        //con.Close();
                        //string script = "alert('Record Deleted!!');";
                        // ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                        // toshowfirstrow();



                        sql = "Jct_Asset_Accept_Delete_RequestId_check";
                        //sql = "Jct_Asset_Accept_Update_RequestId";
                        cmd = new SqlCommand(sql, con, tran);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@RequestID", SqlDbType.Int).Value = ViewState["oldrequestID"];
                        cmd.Parameters.Add("@Location", SqlDbType.VarChar, 50).Value = ddlloc.SelectedItem.Text;
                        cmd.Parameters.Add("@sub_location", SqlDbType.VarChar, 60).Value = ddlSubloc.SelectedItem.Text;
                        cmd.Parameters.Add("@Hostname", SqlDbType.VarChar, 15).Value = Request.ServerVariables["REMOTE_ADDR"];
                        cmd.Parameters.Add("@transno", SqlDbType.Int).Value = TransNo;
                        cmd.ExecuteNonQuery();




                        string script = "alert('Record Deleted!!');";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);

                    }

                    catch (Exception ex)
                    {
                        tran.Rollback();
                        string script2 = "alert('" + ex.Message + "');";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);
                        return;
                    }

                }

            }


            tran.Commit();
            con.Close();

            toshowfirstrow();




            if (ViewState["NewRequestID"]!=null)
            {
                requestID = ViewState["NewRequestID"].ToString();

                grdItemDetail.DataSource = null;
                grdItemDetail.DataBind();

                FillData();

                lnksave.Enabled = false;
            }

          else if (!string.IsNullOrEmpty(Request.QueryString["requestid"]))
            {
                requestID = Request.QueryString["requestid"].ToString();

                grdItemDetail.DataSource = null;
                grdItemDetail.DataBind();

                FillData();

                lnksave.Enabled = false;
            }
            else
            {
                lnkupdate.Enabled = false;
                lnkDelete.Enabled = false;
            }


            //ViewState["dtgridItems"] = dt;
            //grdItemDetail.DataSource = ViewState["dtgridItems"];
            //grdItemDetail.DataBind();
        }

        catch (Exception ex)
        {
            tran.Rollback();
            string script2 = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);
            return;
        }
    }
    protected void ddlloc_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        if (ddlloc.SelectedItem.Text == "Colony")
        {
            txtEmpCode.Enabled = false;
            txtEmpCode.Visible = false;
            //lblLocation.Text = "Department";
            //txtEmpCode.Enabled = false;
            lblLocation.Visible = false;

        }
        else
        {
            txtEmpCode.Enabled = false;
            txtEmpCode.Visible = false;
            //lblLocation.Text = "Department";
            //txtEmpCode.Enabled = false;
            lblLocation.Visible = false;
        }
        bindsublocation();
    }

    public void bindsublocation()
    {
        sql = "Jct_Asset_Furdetail_Sublocation_Fetch";
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
    protected void lnkDeallocate_Click(object sender, EventArgs e)
    {
        //string empname = txtEmpCode.Text.Split('|')[1].ToString();
        //string employeename = empname.Split('~')[0].ToString();
        //if (ViewState["NewRequestID"] != null)
        //{
        //    requestID = ViewState["NewRequestID"].ToString();
        //}
        //else if (!string.IsNullOrEmpty(Request.QueryString["requestid"]))
        //{
        //    requestID = Request.QueryString["requestid"].ToString();
        //}

        //con.Open();
        //tran = con.BeginTransaction();
        //try
        //{
        //    sql = "UPDATE  jct_asset_item_details SET status = 'R'  WHERE   item_id  = '"+requestID+"'  AND  status = 'A'  AND module_usedby = 'GEN'";
        //    SqlCommand cmd = new SqlCommand(sql, con, tran);
        //    cmd.CommandType = CommandType.Text;
        //    cmd.ExecuteNonQuery();

        //    sql = "UPDATE  jct_asset_type_item_detail SET status = 'R'  WHERE   request_id = '" + requestID + "'  AND  status = 'A'  AND module_usedby = 'GEN'";
        //    cmd = new SqlCommand(sql, con, tran);
        //    cmd.CommandType = CommandType.Text;
        //    cmd.ExecuteNonQuery();

        //    sql = "UPDATE  jct_asset_house_reallocation SET FLAG  = 'Deallocated'  WHERE   empcode = '" + employeename + "'  AND  status = 'A' ";
        //    cmd = new SqlCommand(sql, con, tran);
        //    cmd.CommandType = CommandType.Text;
        //    cmd.ExecuteNonQuery();

        //    tran.Commit();
        //    con.Close();

        //    string script = "alert('Record Deallocated Successfully!!');";
        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        //}
        //catch (Exception ex)
        //{
        //    tran.Rollback();
        //    string script2 = "alert('" + ex.Message + "');";
        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);
        //    return;
        //}
       
    }

    private void sendmail()
    {
        try
        {
            string sql = string.Empty;
            string to = string.Empty;
            string from = string.Empty;
            string bcc = string.Empty;
            string cc = string.Empty;
            string subject = string.Empty;
            string body = string.Empty;
            string url = string.Empty;
            string querystring = string.Empty;
            string usercode = string.Empty;
            string querystring1 = string.Empty;
            string querystring2 = string.Empty;

            if (ViewState["NewRequestID"] != null)
            {

                sql = ("SELECT usercode FROM dbo.jct_asset_item_details WHERE item_id= '" + ViewState["NewRequestID"] + "' AND status='A' and module_usedby='GEN'");
                SqlCommand cmd = new SqlCommand(sql, obj.Connection());
                cmd.CommandType = CommandType.Text;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                        usercode = dr[0].ToString();
                    }
                }
                dr.Close();
            }

            else if (ViewState["RequestID"] != null)
            {
                sql = ("SELECT usercode FROM dbo.jct_asset_item_details WHERE item_id= '" + ViewState["RequestID"] + "' AND status='A' and module_usedby='GEN'");
                SqlCommand cmd = new SqlCommand(sql, obj.Connection());
                cmd.CommandType = CommandType.Text;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                        usercode = dr[0].ToString();
                    }
                }
                dr.Close();

            }

            //sql = "Select a.empname,b.e_mailid as email from  misdev.jctdev.dbo.jct_empmast_base a left outer join  misdev.jctdev.dbo.mistel b on a.empcode=b.empcode where a.empcode='" + usercode + "'";
            //cmd = new SqlCommand(sql, con);
            //con.Open();
            //SqlDataReader Dr = cmd.ExecuteReader();
            //if (Dr.HasRows)
            //{
            //    while (Dr.Read())
            //    {
            //        ViewState["RequestBy"] = Dr["empname"].ToString();
            //        ViewState["RequestByEmail"] = Dr["email"].ToString();
            //    }
            //}
            //else
            //{
            //    ViewState["RequestBy"] = "";
            //    ViewState["RequestByEmail"] = "shwetaloria@jctltd.com";
            //}

            //Dr.Close();


            // + lblBudgetID.Text;// ddlsubdept.SelectedItem.Value;//ViewState["budgetID"];
            //querystring = "RequestID=" + ViewState["RequestID"];




            if (ViewState["NewRequestID"] != null)
            {
                subject = "Furniture items Updation";
                //requestID = ViewState["NewRequestID"].ToString();

                querystring = "requestid=" + ViewState["NewRequestID"];
                querystring1 = usercode;
                querystring2 = Session["Empcode"].ToString();
            }

            else if (ViewState["RequestID"] != null)
            {

                subject = "Furniture Allocation";
                querystring = "requestid=" + ViewState["RequestID"];
                querystring1 = usercode;
                querystring2 = Session["Empcode"].ToString();
            }


            //querystring = "requestid=" + ViewState["RequestiD"];


            //url = "http://localhost:3062/FusionApps/AssetMngmnt/AssetMngtMail.aspx?" + querystring + "&EmpCode=" + querystring1 + "&Generatedby=" + querystring2;

             url = "http://testerp/FusionApps/AssetMngmnt/AssetMngtMail.aspx?" + querystring + "&EmpCode=" + querystring1 + "&Generatedby=" + querystring2;

            //url = "http://misdev/FusionApps/AssetMngmnt/AssetMngtMail.aspx?" + querystring + "&EmpCode=" + querystring1 + "&Generatedby=" + querystring2;

            //url = "http://test2k/FusionApps/OPS/MailContentPages/asset_sendmail_new.aspx?" + querystring;

            //url = "http://misdev/FusionApps/OPS/MailContentPages/asset_sendmail_new.aspx?" + querystring;

            @from = "noreply@jctltd.com";

            to = "aslam@jctltd.com,ashish@jctltd.com,shwetaloria@jctltd.com";
            //to = "aslam@jctltd.com";
            bcc = "aslam@jctltd.com";

            string Body = GetPage(url);

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(@from);
            if (to.Contains(","))
            {
                string[] tos = to.Split(',');
                for (int i = 0; i <= tos.Length - 1; i++)
                {
                    mail.To.Add(new MailAddress(tos[i]));
                }
            }
            else
            {
                mail.To.Add(new MailAddress(to));
            }

            if (!string.IsNullOrEmpty(cc))
            {
                if (cc.Contains(","))
                {
                    string[] ccs = cc.Split(',');
                    for (int i = 0; i <= ccs.Length - 1; i++)
                    {
                        mail.CC.Add(new MailAddress(ccs[i]));
                    }
                }
                else
                {
                    mail.CC.Add(new MailAddress(cc));
                }
            }

            if (!string.IsNullOrEmpty(bcc))
            {
                if (bcc.Contains(","))
                {
                    string[] bccs = bcc.Split(',');
                    for (int i = 0; i <= bccs.Length - 1; i++)
                    {
                        mail.Bcc.Add(new MailAddress(bccs[i]));
                    }
                }
                else
                {
                    mail.Bcc.Add(new MailAddress(bcc));
                }
            }

            mail.Subject = subject;

            mail.Body = Body;
            mail.IsBodyHtml = true;
            mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
            SmtpClient SmtpMail = new SmtpClient("exchange2k7");
            SmtpMail.Send(mail);
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
            return;
        }

    }

    protected string GetPage(string page_name)
    {
        WebClient myclient = new WebClient();
        string myPageHTML = null;
        byte[] requestHTML = null;
        string currentPageUrl = null;

        currentPageUrl = Request.Url.AbsoluteUri;
        currentPageUrl = page_name;

        UTF8Encoding utf8 = new UTF8Encoding();

        requestHTML = myclient.DownloadData(currentPageUrl);
        myPageHTML = utf8.GetString(requestHTML);

        //Response.Write(myPageHTML);

        return myPageHTML;

    }
    protected void ddlSubloc_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {

    }
}