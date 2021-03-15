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


public partial class AssetMngmnt_Itemdetail : System.Web.UI.Page
{

    Connection obj = new Connection();
    Functions obj1 = new Functions();
    string sql = string.Empty;
    string requestID = string.Empty;
      
    SqlConnection con = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["misjctdev"].ConnectionString);

  protected void Page_Load(object sender, EventArgs e)
  {
        if (Session["Empcode"] == "")
        {
            Response.Redirect("~/Login.aspx");
        }

        if(!IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["requestid"]))
            {
                requestID = Request.QueryString["requestid"].ToString();

                FillData();
 
                lnksave.Enabled = false;
            }
            else
            {
                //sql = "Select '' as PrinterName Union select type_name +' , ' + isnull(Convert(varchar,dop,106),'') as PrinterName from jct_asset_type_master_detail where status='A' and  asset_type_name ='Printer'";
                //obj1.FillList(ddlPrinter, sql);
                sql = "Select '-1' as PrinterID,'' as PrinterName Union select SrNo as PrinterID, type_name +' , ' + isnull(Convert(varchar,dop,106),'') as PrinterName from jct_asset_type_master_detail where status='A' and  asset_type_name ='Printer'";
                obj1.FillList(ddlPrinter, sql);

                sql = "SELECT distinct deptcode,deptname FROM DEPTMAST order by deptname ";
                obj1.FillList(ddlDept, sql);
                lnksave.Enabled = true;
            }
          
            toshowfirstrow();
        }
  }
     
  protected void lnksave_Click(object sender, EventArgs e)
    {
         string item_id = string.Empty;
         string script= string.Empty;
         string empcode = string.Empty;

         try
         {
             RadComboBox assettype = new RadComboBox();
             RadComboBox assetcat = new RadComboBox();
             RadComboBox assetdesc = new RadComboBox();
             DropDownList manufacturer = new DropDownList();
             string Printer = string.Empty;

             if (ddlPrinter.SelectedItem.Text != string.Empty)
             {
                 Printer = ddlPrinter.SelectedItem.Value;//.Split(',')[0].ToString();
             }

             sql = "jct_asset_item_detail_insert";
             SqlCommand cmd = new SqlCommand(sql, con);
             con.Open();
             cmd.CommandType = CommandType.StoredProcedure;
             //cmd.Parameters.Add("@asset_type_id", SqlDbType.Int).Value = ddlAssetType.SelectedItem.Value;
             cmd.Parameters.Add("@item_desc", SqlDbType.VarChar, 500).Value = txtItemDescription.Text;
             cmd.Parameters.Add("@item_name", SqlDbType.VarChar, 100).Value = txtItemName.Text;
             cmd.Parameters.Add("@modelno", SqlDbType.VarChar, 50).Value = txtModelNo.Text;
             cmd.Parameters.Add("@deptloc", SqlDbType.VarChar, 50).Value = ddlloc.SelectedItem.Text;

             if (txtDOP.Text != string.Empty)
             {
                 cmd.Parameters.Add("@DOP", SqlDbType.DateTime).Value = Convert.ToDateTime(txtDOP.Text);
             }
             if (txtAcqDt.Text != string.Empty)
             {
                 cmd.Parameters.Add("@acquisitiondate", SqlDbType.DateTime).Value = Convert.ToDateTime(txtAcqDt.Text);
             }

             if (!string.IsNullOrEmpty(txtEmpCode.Text))
             {
                 if (txtEmpCode.Text.Contains('|'))
                 {
                     empcode = txtEmpCode.Text.Split('|')[1].ToString();
                     cmd.Parameters.Add("@usercode", SqlDbType.VarChar, 30).Value = empcode.Split('~')[0].ToString();
                 }
                 else if (txtEmpCode.Text.Contains('-'))
                 {
                     empcode = txtEmpCode.Text;
                     cmd.Parameters.Add("@usercode", SqlDbType.VarChar, 30).Value = empcode;
                 }
                 else
                 {
                     script = "alert('Please enter user for this item in EmpCode Textbox.');";
                     ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                     return;
                 }

             }
             else
             {
                 //script = "alert('Please enter user for this item in EmpCode Textbox.');";
                 //ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                 //return;
             }
              
             cmd.Parameters.Add("@location", SqlDbType.VarChar, 50).Value = ddlShadred.SelectedItem.Text;
             cmd.Parameters.Add("@asset_state", SqlDbType.Int).Value = ddlState.SelectedItem.Value;
            // cmd.Parameters.Add("@Dept", SqlDbType.VarChar, 100).Value = ddlDept.SelectedItem.Value;
             cmd.Parameters.Add("@entry_by", SqlDbType.VarChar, 30).Value = Session["EmpCode"].ToString();
             cmd.Parameters.Add("@computer_name", SqlDbType.VarChar, 100).Value = txtComputerName.Text;
             cmd.Parameters.Add("@capital_item", SqlDbType.VarChar, 100).Value = ddlCapital.SelectedItem.Value;
             cmd.Parameters.Add("@jctSR_NO", SqlDbType.VarChar, 100).Value = txtJctsrno.Text;
             cmd.Parameters.Add("@shared", SqlDbType.VarChar, 100).Value = ddlshared.Text;
             cmd.Parameters.Add("@shareduser", SqlDbType.VarChar, 200).Value = txtshareduser.Text;
             cmd.Parameters.Add("@item_id", SqlDbType.Int).Direction = ParameterDirection.Output;

             if (ddlManufacturer.SelectedItem.Value != string.Empty)
             {
                 cmd.Parameters.Add("@manufacturer_id", SqlDbType.Int).Value = Convert.ToInt16(ddlManufacturer.SelectedItem.Value);
             }
             
             cmd.Parameters.Add("@IP_address", SqlDbType.VarChar, 50).Value = txtIP.Text;
             cmd.Parameters.Add("@printertype", SqlDbType.VarChar, 20).Value = ddlPrinterType.SelectedItem.Text;
             cmd.Parameters.Add("@printer", SqlDbType.VarChar, 50).Value = Printer;
             cmd.Parameters.Add("@computer_type", SqlDbType.VarChar, 20).Value = ddlSelectAsset.SelectedItem.Text;
             cmd.Parameters.Add("@vendor", SqlDbType.VarChar, 50).Value = ddlvendor.SelectedItem.Text;
             cmd.Parameters.Add("@sr_no", SqlDbType.VarChar, 50).Value = txtsrno.Text;
             cmd.Parameters.Add("@SharedDesc", SqlDbType.VarChar, 500).Value = txtPrinterDesc.Text;
             cmd.ExecuteNonQuery();
             item_id = cmd.Parameters["@item_id"].Value.ToString();
             con.Close();

             foreach (GridViewRow gvRow in grdDetail.Rows)
             {
                 RadComboBox AssetType = (RadComboBox)gvRow.FindControl("ddlAssetTypeGrid");
                 RadComboBox AssetCatg = (RadComboBox)gvRow.FindControl("ddlAssetCatg");
                 RadComboBox ItemDesc = (RadComboBox)gvRow.FindControl("ddlItemDesc");

                 var collection = ItemDesc.CheckedItems;

                 if (collection.Count != 0)
                 {
                     foreach (var item in collection)
                     {
                         cmd = new SqlCommand("jct_asset_type_item_detail_insert", con);
                         cmd.CommandType = CommandType.StoredProcedure;
                         cmd.Parameters.Add("@request_id", SqlDbType.Int).Value = item_id;
                         cmd.Parameters.Add("@item_desc", SqlDbType.VarChar, 100).Value = item.Text;
                         cmd.Parameters.Add("@item_value", SqlDbType.Int).Value = ItemDesc.SelectedItem.Value;
                         cmd.Parameters.Add("@asset_id", SqlDbType.Int).Value = Convert.ToInt16(AssetType.SelectedValue);
                         cmd.Parameters.Add("@asset_type_id", SqlDbType.Int).Value = Convert.ToInt16(AssetCatg.SelectedValue);
                         cmd.Parameters.Add("@asset_type_name", SqlDbType.VarChar, 200).Value = AssetCatg.SelectedItem.Text;
                         con.Open();
                         cmd.ExecuteNonQuery();
                         con.Close();
                     }
                 }
             }
             script = "alert('Record saved!!');";
             ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
         }
         
         catch(Exception ex)
         {
             string script2 = "alert('"+ ex.Message +"');";
             ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);
             return;
         }
    }

  private bool checkDate(string date)
    {
        Boolean hasDate = false;
        DateTime dateTime = new DateTime();
        try
        {
            dateTime = DateTime.Parse(date);
            hasDate = true;
            return hasDate;
            //break;//no need to execute/loop further if you have your date
        }
        catch (Exception ex)
        {
            hasDate = false;
            return hasDate;
        }
    }

  protected void LinkButton1_Click(object sender, EventArgs e)
  {
      Response.Redirect("Itemdetail.aspx");
  }

  protected void radPrinter_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
  {

      ////string sql = "SELECT CONVERT(VARCHAR(10),dop ,105)  FROM [jct_asset_printer_master] WHERE printer_id= '" + radPrinter.SelectedValue + "' AND status='A'";
      //string sql = "select CONVERT(VARCHAR(10),dop ,105) from jct_asset_type_master_detail where srno='" + radPrinter.SelectedValue + "'  and status='A'";
      //SqlCommand cmd = new SqlCommand(sql, con);
      //con.Open();

      //lbpdate.Text = cmd.ExecuteScalar().ToString();
      //con.Close();
  }

  protected void radScanner_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
  {
      ////string sql = "SELECT CONVERT(VARCHAR(10),dop,105)FROM jct_asset_scanner_master WHERE scanner_id='" + radScanner.SelectedValue + "' AND status='a'";
      //string sql = "select CONVERT(VARCHAR(10),dop ,105) from jct_asset_type_master_detail where srno='" + radScanner.SelectedValue + "'  and status='A'";
      //SqlCommand cmd = new SqlCommand(sql, con);
      //con.Open();
      //lbsdate.Text = cmd.ExecuteScalar().ToString();
      //con.Close();
  }

  protected void ddlAsset_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
  {
      SqlCommand cmd = new SqlCommand("SELECT b.asset_type_name,b.asset_type_id FROM dbo.jct_asset_type_master b JOIN jct_asset_master a ON a.asset_id=b.asset_id  WHERE a.asset_id='" + ddlAsset.SelectedValue + "' AND a.status='A'", con);
      cmd.CommandType = CommandType.Text;
      con.Open();

      SqlDataAdapter da = new SqlDataAdapter(cmd);
      DataSet ds = new DataSet();
      da.Fill(ds);
      //ddlAssetType.DataSource = ds;
      //ddlAssetType.DataTextField = "asset_type_name";
      //ddlAssetType.DataValueField = "asset_type_id";
      //ddlAssetType.DataBind();
      con.Close();
  }

  private void toshowfirstrow()
  {
        DataTable dt = new DataTable();
        DataRow dr = null;
        dt.Columns.Add(new DataColumn("AssetType", typeof(string)));
        dt.Columns.Add(new DataColumn("AssetCategory", typeof(string)));
        dt.Columns.Add(new DataColumn("AssetDescription", typeof(string)));

        if (!string.IsNullOrEmpty(Request.QueryString["requestid"]))
        {
            dr = dt.NewRow();
            dr["AssetType"] = string.Empty;
            dr["AssetCategory"] = string.Empty;
            dr["AssetDescription"] = string.Empty;
            dt.Rows.Add(dr);
            dr = dt.NewRow();
        }
        else
        {
            for (int i = 0; i <= 9; i++)
            {
                dr = dt.NewRow();
                dr["AssetType"] = string.Empty;
                dr["AssetCategory"] = string.Empty;
                dr["AssetDescription"] = string.Empty;
                dt.Rows.Add(dr);
                dr = dt.NewRow();
            }
        }

        ViewState["CurrentTable"] = dt;
        grdDetail.DataSource = dt;
        grdDetail.DataBind();
  }

  protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
  {

  }

  protected void grdDetail_RowDataBound(object sender, GridViewRowEventArgs e)
  {
      GridViewRow row = e.Row;
      if (e.Row.RowType == DataControlRowType.DataRow)
      {
          RadComboBox AssetType = (RadComboBox)row.FindControl("ddlAssetTypeGrid");
          RadComboBox AssetCatg = (RadComboBox)row.FindControl("ddlAssetCatg");
          RadComboBox ItemDesc = (RadComboBox)row.FindControl("ddlItemDesc");
          SqlDataSource assetType_sqlDS = (SqlDataSource)row.Cells[0].FindControl("SqlDataSource1");
          SqlDataSource assetCatg_sqlDS = (SqlDataSource)row.Cells[1].FindControl("SqlDataSource2");
          SqlDataSource desc_sqlDS = (SqlDataSource)row.Cells[2].FindControl("SqlDataSource3");

         // AssetType.DataSource = assetType_sqlDS;
          AssetType.DataBind();

          //assetCatg_sqlDS.SelectParameters["ASSET_ID"].DefaultValue = AssetType.SelectedValue;
          AssetCatg.DataBind();

          //desc_sqlDS.SelectParameters["ASSET_TYPE_ID"].DefaultValue = AssetCatg.SelectedValue;
          ItemDesc.DataBind();
 
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
          }
      }
  }

  protected void grdItemDetail_RowCommand(object sender, GridViewCommandEventArgs e)
  {
  //    if (e.CommandName == "Remove")
  //    {
  //        try
  //        {
  //            int rowIndex = 0;
  //            if (dtgridItems.Rows.Count > 0)
  //            {
  //                GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
  //                rowIndex = gvr.RowIndex;
  //                string asset_id = gvr.Cells[1].Text;
  //                string asset_type_id = gvr.Cells[2].Text;
  //                string requestid = gvr.Cells[5].Text;

  //                //sql = "update jct_asset_type_item_detail set Status='U',updated_on=getdate() where asset_id= " + asset_id + " and asset_type_id=" + asset_type_id + " and request_id=" + requestid + " and status='A'";
  //                //SqlCommand cmd = new SqlCommand(sql, obj.Connection());
  //                //cmd.ExecuteNonQuery();

  //                dtgridItems.Rows.RemoveAt(rowIndex);
  //                grdItemDetail.DataSource = dtgridItems;
  //                grdItemDetail.DataBind();

  //                //string script2 = "alert('Record Deleted !!');";
  //                //ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);
  //            }
  //        }
  //        catch (Exception ex)
  //        {
  //            string script2 = "alert('"+ ex.Message +"');";
  //            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);
  //        }
  //    }
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
   
  protected void ddlAssetType_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
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

  private void fun3()
       {
           int rowIndex = 0;
           if (ViewState["CurrentTable"] != null)
           {
               DataTable dt = (DataTable)ViewState["CurrentTable"];
               if (dt.Rows.Count > 0)
               {
                   for (int i = 0; i < dt.Rows.Count; i++)
                   {
                       RadComboBox assettype = (RadComboBox)grdDetail.Rows[rowIndex].Cells[0].FindControl("ddlAssetTypeGrid");
                       RadComboBox assetcat = (RadComboBox)grdDetail.Rows[rowIndex].Cells[1].FindControl("ddlAssetCatg");
                       RadComboBox desc = (RadComboBox)grdDetail.Rows[rowIndex].Cells[2].FindControl("ddlItemDesc");

                       //assettype.SelectedIndex = assettype.Items.IndexOf(assettype.Items.FindItemByValue(dt.Rows[i][0].ToString()));
                       //assetcat.SelectedIndex = assetcat.Items.IndexOf(assetcat.Items.FindItemByValue(dt.Rows[i][1].ToString()));
                       //desc.SelectedIndex = desc.Items.IndexOf(desc.Items.FindItemByValue(dt.Rows[i][2].ToString()));
                       rowIndex++;

                   }
               }
           }
       }

  protected void lnkupdate_Click(object sender, EventArgs e)
  {
        int ret_val;
        string script = string.Empty;
        string empcode = string.Empty;

        try
        {
            RadComboBox assettype = new RadComboBox();
            RadComboBox assetcat = new RadComboBox();
            RadComboBox assetdesc = new RadComboBox();
            DropDownList manufacturer = new DropDownList();

            string Printer = string.Empty;

            if (ddlPrinter.SelectedItem.Text != string.Empty)
            {
                Printer = ddlPrinter.SelectedItem.Value;
            }

            sql = "jct_asset_item_detail_update";
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.Add("@asset_type_id", SqlDbType.Int).Value = ddlAssetType.SelectedItem.Value;

            try
            {
                cmd.Parameters.Add("@item_desc", SqlDbType.VarChar, 500).Value = txtItemDescription.Text;
                cmd.Parameters.Add("@item_name", SqlDbType.VarChar, 100).Value = txtItemName.Text;
                cmd.Parameters.Add("@modelno", SqlDbType.VarChar, 50).Value = txtModelNo.Text;

                if (txtDOP.Text != string.Empty)
                {
                    cmd.Parameters.Add("@DOP", SqlDbType.DateTime).Value = Convert.ToDateTime(txtDOP.Text);
                }
                if (txtAcqDt.Text != string.Empty)
                {
                    cmd.Parameters.Add("@acquisitiondate", SqlDbType.DateTime).Value = Convert.ToDateTime(txtAcqDt.Text);
                }
                if (!string.IsNullOrEmpty(txtEmpCode.Text))
                {
                    if (txtEmpCode.Text.Contains('|'))
                    {
                        empcode = txtEmpCode.Text.Split('|')[1].ToString();
                        cmd.Parameters.Add("@usercode", SqlDbType.VarChar, 30).Value = empcode.Split('~')[0].ToString();
                    }
                    else if (txtEmpCode.Text.Contains('-'))
                    {
                        empcode = txtEmpCode.Text;
                        cmd.Parameters.Add("@usercode", SqlDbType.VarChar, 30).Value = empcode;
                    }
                    else
                    {
                        script = "alert('Please enter user for this item in EmpCode Textbox.');";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                        return;
                    }

                }
                else
                {
                    //script = "alert('Please enter user for this item in EmpCode Textbox.');";
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                    //return;
                }

                cmd.Parameters.Add("@location", SqlDbType.VarChar, 50).Value = ddlShadred.SelectedItem.Text;
                cmd.Parameters.Add("@asset_state", SqlDbType.Int).Value = ddlState.SelectedItem.Value;
                cmd.Parameters.Add("@Dept", SqlDbType.VarChar, 100).Value = ddlDept.SelectedItem.Value;
                cmd.Parameters.Add("@entry_by", SqlDbType.VarChar, 30).Value = Session["EmpCode"].ToString();
                cmd.Parameters.Add("@computer_name", SqlDbType.VarChar, 100).Value = txtComputerName.Text;
                cmd.Parameters.Add("@capital_item", SqlDbType.VarChar, 100).Value = ddlCapital.SelectedItem.Value;
                cmd.Parameters.Add("@jctSR_NO", SqlDbType.VarChar, 100).Value = txtJctsrno.Text;
                cmd.Parameters.Add("@shared", SqlDbType.VarChar, 100).Value = ddlshared.Text;
                cmd.Parameters.Add("@item_id", SqlDbType.Int).Value = ViewState["RequestID"];
                cmd.Parameters.Add("@manufacturer_id", SqlDbType.Int).Value = Convert.ToInt16(ddlManufacturer.SelectedItem.Value);
                cmd.Parameters.Add("@IP_address", SqlDbType.VarChar, 50).Value = txtIP.Text;
                cmd.Parameters.Add("@printertype", SqlDbType.VarChar, 20).Value = ddlPrinterType.SelectedItem.Text;
                cmd.Parameters.Add("@printer", SqlDbType.VarChar, 50).Value = Printer;
                cmd.Parameters.Add("@computer_type", SqlDbType.VarChar, 20).Value = ddlSelectAsset.SelectedItem.Text;
                cmd.Parameters.Add("@ret_val", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@vendor", SqlDbType.VarChar, 50).Value = ddlvendor.SelectedItem.Text;
                cmd.Parameters.Add("@sr_no", SqlDbType.VarChar, 50).Value = txtsrno.Text;
                cmd.Parameters.Add("@SharedDesc", SqlDbType.VarChar, 500).Value = txtPrinterDesc.Text;
                cmd.Parameters.Add("@deptloc", SqlDbType.VarChar, 50).Value = ddlloc.SelectedItem.Text;
                cmd.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                script = "alert('Error - "+ ex.Message +"' );";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                return;
            }

            
            ret_val = Convert.ToInt16(cmd.Parameters["@ret_val"].Value.ToString());
            ViewState["RequestID"] = ret_val;
            con.Close();

            foreach (GridViewRow gvRow in grdDetail.Rows)
            {
                RadComboBox AssetType = (RadComboBox)gvRow.FindControl("ddlAssetTypeGrid");
                RadComboBox AssetCatg = (RadComboBox)gvRow.FindControl("ddlAssetCatg");
                RadComboBox ItemDesc = (RadComboBox)gvRow.FindControl("ddlItemDesc");

                var collection = ItemDesc.CheckedItems;

                if (collection.Count != 0)
                {
                    foreach (var item in collection)
                    {
                        cmd = new SqlCommand("jct_asset_type_item_detail_update", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@request_id", SqlDbType.Int).Value = ViewState["RequestID"];//ret_val;
                        cmd.Parameters.Add("@item_desc", SqlDbType.VarChar, 200).Value = item.Text;
                        cmd.Parameters.Add("@item_value", SqlDbType.Int).Value = ItemDesc.SelectedItem.Value;
                        cmd.Parameters.Add("@asset_id", SqlDbType.Int).Value = Convert.ToInt16(AssetType.SelectedValue);
                        cmd.Parameters.Add("@asset_type_id", SqlDbType.Int).Value = Convert.ToInt16(AssetCatg.SelectedValue);
                        cmd.Parameters.Add("@asset_type_name", SqlDbType.VarChar, 100).Value = AssetCatg.SelectedItem.Text;
                        cmd.Parameters.Add("@new_requestid", SqlDbType.Int).Value =ret_val;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
 
            foreach (GridViewRow gvRow in grdItemDetail.Rows)
            {
                cmd = new SqlCommand("jct_asset_type_item_detail_update", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@request_id", SqlDbType.Int).Value = ret_val;
                cmd.Parameters.Add("@item_desc", SqlDbType.VarChar, 100).Value = gvRow.Cells[4].Text;
                cmd.Parameters.Add("@item_value", SqlDbType.Int).Value = Convert.ToInt16(gvRow.Cells[5].Text);
                cmd.Parameters.Add("@asset_id", SqlDbType.Int).Value = Convert.ToInt16(gvRow.Cells[1].Text);
                cmd.Parameters.Add("@asset_type_id", SqlDbType.Int).Value = Convert.ToInt16(gvRow.Cells[2].Text);
                cmd.Parameters.Add("@asset_type_name", SqlDbType.VarChar, 200).Value = gvRow.Cells[3].Text; ;
                cmd.Parameters.Add("@mode", SqlDbType.VarChar, 20).Value = "Update";
                cmd.Parameters.Add("@new_requestid", SqlDbType.Int).Value = ret_val;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

            sql = "jct_asset_type_item_detail_update_merge";
            cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();

            // re-fill all the data
            FillData();
            
            script = "alert('Record updated!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
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
          ddlManufacturer.DataBind();
          ddlvendor.DataBind();

          sql = "SELECT distinct deptcode,deptname FROM DEPTMAST order by deptname";
          obj1.FillList(ddlDept, sql);

          sql = "Select '-1' as PrinterID,'' as PrinterName Union select SrNo as PrinterID, type_name +' , ' + isnull(Convert(varchar,dop,106),'') as PrinterName from jct_asset_type_master_detail where status='A' and  asset_type_name ='Printer'";
          obj1.FillList(ddlPrinter, sql);

          sql = "jct_asset_item_detail_select";
          SqlCommand cmd = new SqlCommand(sql, obj.Connection());
          cmd.CommandType = CommandType.StoredProcedure;

          if (requestID != string.Empty)
          {
              cmd.Parameters.Add("@requestid", SqlDbType.Int).Value = Convert.ToInt16(requestID);
          }

          cmd.Parameters.Add("@empcode", SqlDbType.VarChar, 10).Value = txtEmpCode.Text;
          cmd.Parameters.Add("@computername", SqlDbType.VarChar, 100).Value = txtComputerName.Text;
          cmd.Parameters.Add("@jctsrno", SqlDbType.VarChar, 100).Value = txtJctsrno.Text;
          cmd.Parameters.Add("@ipaddress", SqlDbType.VarChar, 30).Value = txtIP.Text;

          SqlDataAdapter da = new SqlDataAdapter(cmd);
          DataSet dsItem = new DataSet();
          da.Fill(dsItem);
          //da.Fill(dsItem.Tables["Itemdetail"]);

          foreach (DataRow dr in dsItem.Tables[0].Rows)
          {
              txtEmpCode.Text = dr["empcode"].ToString();
              //ddlAsset.SelectedItem.Text = dr["asset"].ToString();

              //ddlDept.SelectedItem.Value = dr["assetstate"].ToString();

              //ddlDept.SelectedIndex = ddlDept.Items.IndexOf(ddlDept.Items.FindByValue(dr["department"].ToString()));
              ddlloc.SelectedIndex = ddlloc.Items.IndexOf(ddlloc.Items.FindByText(dr["deptloc"].ToString()));
              ddlState.SelectedIndex = ddlState.Items.IndexOf(ddlState.Items.FindByValue(dr["assetstate"].ToString()));
              ddlshared.SelectedIndex = ddlshared.Items.IndexOf(ddlShadred.Items.FindByValue(dr["Plant"].ToString()));
              txtItemName.Text = dr["item_name"].ToString();
              txtComputerName.Text = dr["computername"].ToString();
              txtItemDescription.Text = dr["itemdescription"].ToString();
              ddlCapital.SelectedIndex = ddlCapital.Items.IndexOf(ddlCapital.Items.FindByValue(dr["capitalitem"].ToString()));
              //ddlPrinterType.SelectedIndex = ddlPrinterType.Items.IndexOf(ddlPrinterType.Items.FindByValue(dr["printertype"].ToString()));
              //ddlPrinter.SelectedIndex = ddlPrinter.Items.IndexOf(ddlPrinter.Items.FindByText(dr["printer"].ToString()));
              txtModelNo.Text = dr["modelno"].ToString();
              txtJctsrno.Text = dr["jctsrno"].ToString();
              if (string.IsNullOrEmpty(dr["DOP"].ToString()))
              {
                  txtDOP.Text = string.Empty;
              }
              else 
              {
                  txtdop_CalendarExtender.SelectedDate = Convert.ToDateTime(dr["DOP"].ToString()).Date;
              }
              
              ddlManufacturer.SelectedIndex= ddlManufacturer.Items.IndexOf(ddlManufacturer.Items.FindByValue(dr["manufacturer"].ToString()));
              ddlvendor.SelectedIndex = ddlvendor.Items.IndexOf(ddlvendor.Items.FindByText(dr["vendor"].ToString()));
              txtsrno.Text = dr["sr_no"].ToString();

              if (!string.IsNullOrEmpty(dr["printertype"].ToString()))
              {
                  ddlPrinterType.SelectedIndex = ddlPrinterType.Items.IndexOf(ddlPrinterType.Items.FindByText(dr["printertype"].ToString()));
              }

              if (!string.IsNullOrEmpty(dr["printer"].ToString()))
              {
                  ddlPrinter.SelectedIndex = ddlPrinter.Items.IndexOf(ddlPrinter.Items.FindByValue(dr["printer"].ToString()));
              }

              if (string.IsNullOrEmpty(dr["acquisitiondate"].ToString()))
              {
                  txtAcqDt.Text = string.Empty;
              }
              else
              {
                  txtacqdt_CalendarExtender.SelectedDate = Convert.ToDateTime(dr["acquisitiondate"].ToString()).Date;
              }
              
              txtIP.Text = dr["ipaddress"].ToString();
              txtshareduser.Text = dr["SharedUser"].ToString();
              txtPrinterDesc.Text = dr["SharedDesc"].ToString();
              ddlSelectAsset.SelectedIndex = ddlSelectAsset.Items.IndexOf(ddlSelectAsset.Items.FindByText(dr["computer_type"].ToString()));
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
      }
      catch (Exception ex)
      {
          string script2 = "alert('" + ex.Message + "');";
          ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);
          return;
      }
  }

  protected void txtEmpCode_TextChanged(object sender, EventArgs e)
    {
        //FillData();
    }

  protected void txtJctsrno_TextChanged(object sender, EventArgs e)
    {
        //FillData();
    }

  protected void txtComputerName_TextChanged(object sender, EventArgs e)
    {
        //FillData();
    }

  protected void txtIP_TextChanged(object sender, EventArgs e)
    {
        //FillData(); 
    }


  protected void lnkDelete_Click(object sender, EventArgs e)
  {
      DataTable dt = new DataTable();
      dt = (DataTable)ViewState["dtgridItems"];

      foreach(GridViewRow gvRow in grdItemDetail.Rows)
      {
          CheckBox chkRemove = (CheckBox)gvRow.FindControl("chkRemove");
          int TransNo = Convert.ToInt16(gvRow.Cells[6].Text);
          if (chkRemove.Checked == true)
          {
              int rowIndex = 0;
              rowIndex = gvRow.RowIndex;
              dt.Rows.RemoveAt(rowIndex);
              sql = "Update jct_asset_type_item_detail set status='D' where TransNo=" + TransNo;
              SqlCommand cmd = new SqlCommand(sql, obj.Connection());
              cmd.ExecuteNonQuery();
          }
      }

      ViewState["dtgridItems"] = dt;
      grdItemDetail.DataSource = ViewState["dtgridItems"];
      grdItemDetail.DataBind();
  }


  protected void ddlPrinterType_SelectedIndexChanged(object sender, EventArgs e)
  {
      try
      {
          sql = "Select '-1' as PrinterID,'' as PrinterName Union select SrNo as PrinterID, type_name +' , ' + isnull(Convert(varchar,dop,106),'') as PrinterName from jct_asset_type_master_detail where status='A' and  asset_type_name ='Printer'";
          obj1.FillList(ddlPrinter, sql);

          //sql = "select type_name +' , ' + isnull(Convert(varchar,dop,106),'') as PrinterName from jct_asset_type_master_detail where status='A' and  asset_type_name ='Printer' and (type='" + ddlPrinterType.SelectedItem.Text + "' or '" + ddlPrinterType.SelectedItem.Text + "'='')";
          //obj1.FillList(ddlPrinter, sql);

          sql = "select isnull(type_description,'') as PrinterDesc from jct_asset_type_master_detail where status='A' and asset_type_name ='Printer' and (type='" + ddlPrinterType.SelectedItem.Text + "' or '" + ddlPrinterType.SelectedItem.Text + "'='')";
          txtPrinterDesc.Text = obj1.FetchValue(sql).ToString();
      }
      catch (Exception ex)
      {
          string script2 = "alert('No Printer Found..!!');";
          ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script2, true);
          return;
      }
  }
}
