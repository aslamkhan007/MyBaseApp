using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class AssetMngmnt_asset_printer_report : System.Web.UI.Page
{

    Connection obj = new Connection();
    Functions obj1 = new Functions();
    string sql = string.Empty;
    string script = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ddlassettype_SelectedIndexChanged(sender, null);
        }

    }
    protected void ddlassettype_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlassettype.SelectedItem.Text== "Printer")
        {
            SqlCommand cmd = new SqlCommand("SELECT  DISTINCT LTRIM(ISNULL(model,''))  AS model FROM dbo.jct_asset_printer_scanner_network  WHERE STATUS='A' and  asset_type='" + ddlassettype.SelectedItem.Text + "'", obj.Connection());
            cmd.CommandType = CommandType.Text;
            DataSet ds = new DataSet();
            ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            ddlmodel.DataSource = ds;
            ddlmodel.DataTextField = "model";
            //ddlprintertype.DataValueField = "Item_no";
            ddlmodel.DataBind();
        }
        if (ddlassettype.SelectedItem.Text == "Scanner")
        {
            SqlCommand cmd = new SqlCommand("SELECT  DISTINCT LTRIM(ISNULL(model,''))  AS model FROM dbo.jct_asset_printer_scanner_network WHERE STATUS='A' and  asset_type='" + ddlassettype.SelectedItem.Text + "'", obj.Connection());
            cmd.CommandType = CommandType.Text;
            DataSet ds = new DataSet();
            ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            ddlmodel.DataSource = ds;
            ddlmodel.DataTextField = "model";
            //ddlprintertype.DataValueField = "Item_no";
            ddlmodel.DataBind();
        }
        if (ddlassettype.SelectedItem.Text == "NetworkItems")
        {
            SqlCommand cmd = new SqlCommand("SELECT  DISTINCT LTRIM(ISNULL(model,''))  AS model FROM dbo.jct_asset_printer_scanner_network WHERE STATUS='A' and  asset_type='" + ddlassettype.SelectedItem.Text + "'", obj.Connection());
            cmd.CommandType = CommandType.Text;
            DataSet ds = new DataSet();
            ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            ddlmodel.DataSource = ds;
            ddlmodel.DataTextField = "model";
            //ddlprintertype.DataValueField = "Item_no";
            ddlmodel.DataBind();
        }
        if (ddlassettype.SelectedItem.Text == "Conference Phone")
        {
            SqlCommand cmd = new SqlCommand("SELECT  DISTINCT LTRIM(ISNULL(model,''))  AS model FROM dbo.jct_asset_printer_scanner_network  WHERE STATUS='A' and  asset_type='" + ddlassettype.SelectedItem.Text + "'", obj.Connection());
            cmd.CommandType = CommandType.Text;
            DataSet ds = new DataSet();
            ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            ddlmodel.DataSource = ds;
            ddlmodel.DataTextField = "model";
            //ddlprintertype.DataValueField = "Item_no";
            ddlmodel.DataBind();
        }
    }
    protected void lnkfetch_Click(object sender, EventArgs e)
    {
        sql = "jct_asset_printer_fetch";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@asset_type", SqlDbType.VarChar, 50).Value = ddlassettype.SelectedItem.Text;
        cmd.Parameters.Add("@printer_type", SqlDbType.VarChar, 20).Value = ddlprintertype.SelectedItem.Text;
        cmd.Parameters.Add("@printer_ID", SqlDbType.VarChar, 20).Value = txtjctmachineid.Text;
        cmd.Parameters.Add("@model", SqlDbType.VarChar, 100).Value = ddlmodel.SelectedItem.Text;
        cmd.Parameters.Add("@state", SqlDbType.VarChar, 20).Value = ddlstate.SelectedItem.Text.Trim();
        cmd.Parameters.Add("@manufacturer", SqlDbType.VarChar, 50).Value = ddlmanufactuer.SelectedItem.Text.Trim();
        cmd.Parameters.Add("@location", SqlDbType.VarChar, 50).Value = ddlloc.SelectedItem.Text;
        cmd.ExecuteNonQuery();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        grdDetail.DataSource = ds.Tables[0];
        grdDetail.DataBind();

    }
    protected void ddlmanufactuer_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    //protected void lnkexcel_Click(object sender, EventArgs e)
    //{
    //    GridViewExportUtil.Export("XL.xls", grdDetail);
    //    //sql = "jct_asset_printer_fetch";
    //    //SqlCommand cmd = new SqlCommand(sql, obj.Connection());
    //    //cmd.CommandType = CommandType.StoredProcedure;
    //    //cmd.Parameters.Add("@asset_type", SqlDbType.VarChar, 50).Value = ddlassettype.SelectedItem.Text;
    //    //cmd.Parameters.Add("@printer_type", SqlDbType.VarChar, 20).Value = ddlprintertype.SelectedItem.Text;
    //    //cmd.Parameters.Add("@printer_ID", SqlDbType.VarChar, 20).Value = txtjctmachineid.Text;
    //    //cmd.Parameters.Add("@model", SqlDbType.VarChar, 100).Value = ddlmodel.SelectedItem.Text;
    //    //cmd.Parameters.Add("@state", SqlDbType.VarChar, 20).Value = ddlstate.SelectedItem.Text.Trim();
    //    //cmd.Parameters.Add("@manufacturer", SqlDbType.VarChar, 50).Value = ddlmanufactuer.SelectedItem.Text.Trim();
    //    //cmd.Parameters.Add("@location", SqlDbType.VarChar, 50).Value = ddlloc.SelectedItem.Text;
    //    //cmd.ExecuteNonQuery();
    //    //SqlDataAdapter da = new SqlDataAdapter(cmd);
    //    //DataSet ds = new DataSet();
    //    //da.Fill(ds);
    //    //grdDetail.DataSource = ds.Tables[0];
    //    //grdDetail.DataBind();

    //    ////DataTable dt = ds.Tables[0];
    //    ////string attachment = "attachment; AssetReport.xls";
    //    ////Response.ClearContent();
    //    ////Response.AddHeader("content-disposition", attachment);
    //    ////Response.ContentType = "application/vnd.ms-excel";
    //    ////string tab = "";
    //    ////foreach (DataColumn dc in dt.Columns)
    //    ////{
    //    ////    Response.Write(tab + dc.ColumnName);
    //    ////    tab = "\t";
    //    ////}

    //    ////Response.Write("\n");
    //    ////int i;
    //    ////foreach (DataRow dr in dt.Rows)
    //    ////{
    //    ////    tab = "";
    //    ////    for (i = 0; i < dt.Columns.Count; i++)
    //    ////    {
    //    ////        Response.Write(tab + dr[i].ToString());
    //    ////        tab = "\t";
    //    ////    }
    //    ////    Response.Write("\n");
    //    ////}
    //    ////Response.End();






    //    //DataTable dt = ds.Tables[0];
    //    //string attachment = "attachment; printerDetail.xls";
    //    //Response.ClearContent();
    //    //Response.AddHeader("content-disposition", attachment);
    //    //Response.ContentType = "application/vnd.ms-excel";
    //    //string tab = "";
    //    //foreach (DataColumn dc in dt.Columns)
    //    //{
    //    //    Response.Write(tab + dc.ColumnName);
    //    //    tab = "\t";
    //    //}

    //    //Response.Write("\n");
    //    //int i;
    //    //foreach (DataRow dr in dt.Rows)
    //    //{
    //    //    tab = "";
    //    //    for (i = 0; i < dt.Columns.Count; i++)
    //    //    {
    //    //        Response.Write(tab + dr[i].ToString());
    //    //        tab = "\t";
    //    //    }
    //    //    Response.Write("\n");
    //    //}
    //    //Response.End();



    //}
    protected void grdDetail_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void excel_Click(object sender, EventArgs e)
    {
        GridViewExportUtil.Export("XL.xls", grdDetail);
    }
}