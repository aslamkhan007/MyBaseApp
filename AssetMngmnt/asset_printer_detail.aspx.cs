using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class AssetMngmnt_asset_printer_detail : System.Web.UI.Page
{

    Connection obj = new Connection();
    Functions obj1 = new Functions();
    string sql = string.Empty;
    string script = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Bindgrid();
        }
    }

    protected void lnkadd_Click(object sender, EventArgs e)
    {
        try
        {
            sql = "jct_asset_printer_scanner_network_insert";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@asset_type", SqlDbType.VarChar, 30).Value = ddlassettype.SelectedItem.Text;
            cmd.Parameters.Add("@asset_id", SqlDbType.Int).Value = ddlassettype.SelectedItem.Value == "" ? -1 : Convert.ToInt16(ddlassettype.SelectedItem.Value);
            cmd.Parameters.Add("@item_name", SqlDbType.VarChar, 30).Value = txtitem_name.Text;

            if (!string.IsNullOrEmpty(lblSrNo.Text))
            {
                cmd.Parameters.Add("@srno", SqlDbType.Int).Value = Convert.ToInt16(lblSrNo.Text);
            }

            if (!string.IsNullOrEmpty(txtdesc.Text))
            {
                cmd.Parameters.Add("@DESCRIPTION", SqlDbType.VarChar, 50).Value = txtdesc.Text;
            }
            cmd.Parameters.Add("@jct_machine_ID", SqlDbType.VarChar, 30).Value = txtmachineid.Text;
            cmd.Parameters.Add("@location", SqlDbType.VarChar, 30).Value = ddlloc.SelectedItem.Text;
            if (ddlmanufactuer.Text != string.Empty)
            {
                cmd.Parameters.Add("@manufacturer", SqlDbType.VarChar, 30).Value = ddlmanufactuer.SelectedItem.Text;
            }
            if (!string.IsNullOrEmpty(txtdop.Text))
            {
                cmd.Parameters.Add("@DOP", SqlDbType.DateTime).Value = Convert.ToDateTime(txtdop.Text);
            }
            if (!string.IsNullOrEmpty(ddlvendor.Text))
            {
                cmd.Parameters.Add("@vendor", SqlDbType.VarChar, 30).Value = ddlvendor.SelectedItem.Text;
            }
            if (!string.IsNullOrEmpty(txtmodel.Text))
            {
                cmd.Parameters.Add("@model", SqlDbType.VarChar, 50).Value = txtmodel.Text;
            }
            if (ddlPrinterType.SelectedItem.Text != string.Empty)
            {
                cmd.Parameters.Add("@printer_type", SqlDbType.VarChar, 50).Value = ddlPrinterType.SelectedItem.Text;
            }
            if (!string.IsNullOrEmpty(ddlstate.Text))
            {
                cmd.Parameters.Add("@state", SqlDbType.VarChar, 50).Value = ddlstate.SelectedItem.Text;
            }
            if (!string.IsNullOrEmpty(ddloption.Text))
            {
                cmd.Parameters.Add("@printer_option", SqlDbType.VarChar, 50).Value = ddloption.SelectedItem.Text;
            }
            cmd.Parameters.Add("@itemno", SqlDbType.VarChar, 50).Value = txtitemno.Text;
            cmd.Parameters.Add("@entry_BY", SqlDbType.VarChar, 7).Value = Session["EmpCode"];
            cmd.Parameters.Add("@Hostname", SqlDbType.VarChar, 15).Value = Request.ServerVariables["REMOTE_ADDR"];
            cmd.ExecuteNonQuery();

            Bindgrid();

            script = "alert('Record saved!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
        catch (Exception ex)
        {
            script = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }




    protected void lnkupd_Click(object sender, EventArgs e)
    {
        try
        {
            sql = "jct_asset_printer_scanner_network_update";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            if (!string.IsNullOrEmpty(txtdesc.Text))
            {
                cmd.Parameters.Add("@sr_no", SqlDbType.Int).Value = "0";
            }
            cmd.Parameters.Add("@asset_type", SqlDbType.VarChar, 30).Value = ddlassettype.SelectedItem.Text;
            cmd.Parameters.Add("@asset_id", SqlDbType.Int).Value = ddlassettype.SelectedItem.Value == "" ? -1 : Convert.ToInt16(ddlassettype.SelectedItem.Value);
            cmd.Parameters.Add("@item_name", SqlDbType.VarChar, 30).Value = txtitem_name.Text;

            if (!string.IsNullOrEmpty(txtdesc.Text))
            {
                cmd.Parameters.Add("@DESCRIPTION", SqlDbType.VarChar, 50).Value = txtdesc.Text;
            }

            cmd.Parameters.Add("@jct_machine_ID", SqlDbType.VarChar, 30).Value = txtmachineid.Text;

            cmd.Parameters.Add("@location", SqlDbType.VarChar, 30).Value = ddlloc.SelectedItem.Text;

            if (ddlmanufactuer.Text != string.Empty)
            {
                cmd.Parameters.Add("@manufacturer", SqlDbType.VarChar, 30).Value = ddlmanufactuer.SelectedItem.Text;
            }
            if (!string.IsNullOrEmpty(txtdop.Text))
            {
                cmd.Parameters.Add("@DOP", SqlDbType.DateTime).Value = Convert.ToDateTime(txtdop.Text);
            }
            if (!string.IsNullOrEmpty(ddlvendor.Text))
            {
                cmd.Parameters.Add("@vendor", SqlDbType.VarChar, 30).Value = ddlvendor.SelectedItem.Text;
            }
            if (!string.IsNullOrEmpty(txtmodel.Text))
            {
                cmd.Parameters.Add("@model", SqlDbType.VarChar, 50).Value = txtmodel.Text;
            }
            if (ddlPrinterType.SelectedItem.Text != string.Empty)
            {
                cmd.Parameters.Add("@printer_type", SqlDbType.VarChar, 50).Value = ddlPrinterType.SelectedItem.Text;
            }
            if (!string.IsNullOrEmpty(ddlstate.Text))
            {
                cmd.Parameters.Add("@state", SqlDbType.VarChar, 50).Value = ddlstate.SelectedItem.Text;
            }
            if (!string.IsNullOrEmpty(ddloption.Text))
            {
                cmd.Parameters.Add("@printer_option", SqlDbType.VarChar, 50).Value = ddloption.SelectedItem.Text;
            }
            //cmd.Parameters.Add("@itemno", SqlDbType.VarChar, 50).Value = grdDetail.SelectedRow.Cells[1].Text;
            cmd.Parameters.Add("@itemno", SqlDbType.VarChar, 50).Value = grdDetail.SelectedRow.Cells[8].Text;
            cmd.Parameters.Add("@entry_BY", SqlDbType.VarChar, 7).Value = Session["EmpCode"];
            cmd.Parameters.Add("@Hostname", SqlDbType.VarChar, 15).Value = Request.ServerVariables["REMOTE_ADDR"];
            cmd.ExecuteNonQuery();
            Bindgrid();

            script = "alert('Record updated!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
        catch (Exception ex)
        {
            script = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }

    protected void Bindgrid()
    {
        sql = "jct_asset_printer_scanner_network_select_type_Aslam";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@asset_type", SqlDbType.VarChar, 20).Value = ddlassettype.SelectedItem.Text;
        cmd.ExecuteNonQuery();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        grdDetail.DataSource = null;
        grdDetail.DataBind();
        grdDetail.DataSource = ds.Tables[0];
        grdDetail.DataBind();

        if (ddlassettype.SelectedItem.Text == "Printer")
        {
            lblPrinterType.Visible = true;
            ddlPrinterType.Visible = true;
            lblPrinteroption.Visible = true;
            ddloption.Visible = true;
        }
        else
        {
            lblPrinterType.Visible = false;
            ddlPrinterType.Visible = false;
            lblPrinteroption.Visible = false;
            ddloption.Visible = false;
        }
    }

    protected void BindItemWisegrid()
    {
        DataSet ds1 = new DataSet();
        ds1 = null;
        grdDetail.DataSource = ds1;
        grdDetail.DataBind();

        sql = "jct_asset_printer_scanner_network_select_type_Aslam_id";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@asset_type", SqlDbType.VarChar, 20).Value = ddlassettype.SelectedItem.Text;
        cmd.Parameters.Add("@Item_no", SqlDbType.VarChar, 20).Value = txtitemno.Text;
        cmd.ExecuteNonQuery();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        grdDetail.DataSource = ds.Tables[0];
        grdDetail.DataBind();

        if (ddlassettype.SelectedItem.Text == "Printer")
        {
            lblPrinterType.Visible = true;
            ddlPrinterType.Visible = true;
            lblPrinteroption.Visible = true;
            ddloption.Visible = true;
        }
        else
        {
            lblPrinterType.Visible = false;
            ddlPrinterType.Visible = false;
            lblPrinteroption.Visible = false;
            ddloption.Visible = false;
        }
    }


    protected void lnkdel_Click(object sender, EventArgs e)
    {
        try
        {
            sql = "jct_asset_printer_scanner_network_delete";
            SqlCommand cmd = new SqlCommand(sql, obj.Connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Item_no", SqlDbType.VarChar, 20).Value = ViewState["ItemID"].ToString();
            cmd.Parameters.Add("@entry_by", SqlDbType.VarChar,20).Value = Session["EmpCode"].ToString();
            cmd.Parameters.Add("@asset_type", SqlDbType.VarChar, 100).Value = ddlassettype.SelectedItem.Text;
            cmd.Parameters.Add("@Hostname", SqlDbType.VarChar, 15).Value = Request.ServerVariables["REMOTE_ADDR"];
            cmd.ExecuteNonQuery();
            Bindgrid();

            script = "alert('Record Deleted!!');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
        catch (Exception ex)
        {
            script = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }
    protected void grdDetail_SelectedIndexChanged(object sender, EventArgs e)
    {       
        grdDetail.SelectedRowStyle.CssClass = "GridRowGreen";
        
        //txtlcation.Text = grdDetail.SelectedRow.Cells[2].Text;
        //assettype.SelectedIndex = assettype.Items.IndexOf(assettype.Items.FindItemByValue(dt.Rows[i][0].ToString()))//FindByText(grdDetail.SelectedRow.Cells[0].Text))
        //lblSrNo.Text = grdDetail.SelectedRow.Cells[1].Text.Replace("&nbsp;", "");
        ViewState["ItemID"] = grdDetail.SelectedRow.Cells[8].Text;
        txtitemno.Text = ViewState["ItemID"].ToString();
        ddlassettype.SelectedIndex = ddlassettype.Items.IndexOf(ddlassettype.Items.FindByText(grdDetail.SelectedRow.Cells[10].Text.Replace("&nbsp;", "")));
        txtitem_name.Text = grdDetail.SelectedRow.Cells[4].Text.Replace("&nbsp;", "");
        txtdesc.Text = grdDetail.SelectedRow.Cells[11].Text.Replace("&nbsp;", "");
        txtmachineid.Text = grdDetail.SelectedRow.Cells[12].Text.Replace("&nbsp;", "");
        ddlloc.SelectedIndex = ddlloc.Items.IndexOf(ddlloc.Items.FindByText(grdDetail.SelectedRow.Cells[2].Text.Replace("&nbsp;", "")));        
        ddlloc.SelectedIndex = ddlloc.Items.IndexOf(ddlloc.Items.FindByText(grdDetail.SelectedRow.Cells[2].Text.Replace("&amp;", "&")));
        ddlvendor.SelectedIndex = ddlvendor.Items.IndexOf(ddlvendor.Items.FindByText(grdDetail.SelectedRow.Cells[6].Text.Replace("&nbsp;", "")));
        ddlmanufactuer.SelectedIndex = ddlmanufactuer.Items.IndexOf(ddlmanufactuer.Items.FindByText(grdDetail.SelectedRow.Cells[5].Text.Replace("&nbsp;", "")));
        txtdop.Text = grdDetail.SelectedRow.Cells[7].Text.Replace("&nbsp;","");
        txtmodel.Text = grdDetail.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");

        if (!string.IsNullOrEmpty(grdDetail.SelectedRow.Cells[14].Text.Replace("&nbsp;", "")))
        {
            ddlPrinterType.SelectedIndex = ddlPrinterType.Items.IndexOf(ddlPrinterType.Items.FindByText(grdDetail.SelectedRow.Cells[14].Text.Replace("&nbsp;", "")));
        }
        if (!string.IsNullOrEmpty(grdDetail.SelectedRow.Cells[15].Text.Replace("&nbsp;", "")))
        {
            ddloption.SelectedIndex = ddloption.Items.IndexOf(ddloption.Items.FindByText(grdDetail.SelectedRow.Cells[15].Text.Replace("&nbsp;", "")));
        }

        ddlstate.SelectedIndex = ddlstate.Items.IndexOf(ddlstate.Items.FindByText(grdDetail.SelectedRow.Cells[9].Text.Replace("&nbsp;", "")));
        
    }
    protected void lnkreset_Click(object sender, EventArgs e)
    {
        Response.Redirect("asset_printer_detail.aspx");
    }
    protected void ddlassettype_SelectedIndexChanged(object sender, EventArgs e)
    {
        grdDetail.DataSource = null;
        grdDetail.DataBind();
        Bindgrid();
        ddlPrinterType.Items.FindByText("").Selected = true;
        ddloption.Items.FindByText("").Selected = true;
    }
    protected void excel_Click(object sender, EventArgs e)
    {
        sql = "jct_asset_printer_scanner_network_select_type_Aslam";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@asset_type", SqlDbType.VarChar, 20).Value = ddlassettype.SelectedItem.Text;
        cmd.ExecuteNonQuery();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        grdDetail.DataSource = ds.Tables[0];
        grdDetail.DataBind();

        DataTable dt = ds.Tables[0];
        string attachment = "attachment; AssetReport.xls";
        Response.ClearContent();
        Response.AddHeader("content-disposition", attachment);
        Response.ContentType = "application/vnd.ms-excel";
        string tab = "";
        foreach (DataColumn dc in dt.Columns)
        {
            Response.Write(tab + dc.ColumnName);
            tab = "\t";
        }

        Response.Write("\n");
        int i;
        foreach (DataRow dr in dt.Rows)
        {
            tab = "";
            for (i = 0; i < dt.Columns.Count; i++)
            {
                Response.Write(tab + dr[i].ToString());
                tab = "\t";
            }
            Response.Write("\n");
        }
        Response.End();
    
    }
    protected void lnkexcel_Click(object sender, EventArgs e)
    {
        sql = "jct_asset_printer_scanner_network_select_type_Aslam";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@asset_type", SqlDbType.VarChar, 20).Value = ddlassettype.SelectedItem.Text;
        cmd.ExecuteNonQuery();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        grdDetail.DataSource = ds.Tables[0];
        grdDetail.DataBind();

        DataTable dt = ds.Tables[0];
        string attachment = "attachment; printerDetail.xls";
        Response.ClearContent();
        Response.AddHeader("content-disposition", attachment);
        Response.ContentType = "application/vnd.ms-excel";
        string tab = "";
        foreach (DataColumn dc in dt.Columns)
        {
            Response.Write(tab + dc.ColumnName);
            tab = "\t";
        }

        Response.Write("\n");
        int i;
        foreach (DataRow dr in dt.Rows)
        {
            tab = "";
            for (i = 0; i < dt.Columns.Count; i++)
            {
                Response.Write(tab + dr[i].ToString());
                tab = "\t";
            }
            Response.Write("\n");
        }
        Response.End();

    }
    protected void lnkreport_Click(object sender, EventArgs e)
    {
        Response.Redirect("asset_printer_report.aspx");
    }

    protected void txtitemno_TextChanged(object sender, EventArgs e)
    {

    }
    protected void Linkitem_id1_Click(object sender, EventArgs e)
    {
        try
        {
            grdDetail.SelectedRowStyle.CssClass = "AAA";
            DataSet ds = new DataSet();
            ds = null;
            grdDetail.DataSource = ds;           
            grdDetail.DataBind();
            BindItemWisegrid();
        }

        catch (Exception ex)
        {
            script = "alert('" + ex.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
        }
    }
}