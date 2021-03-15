using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class OPS_SellingPrice_Vs_DnV : System.Web.UI.Page
{
    Connection obj = new Connection();
    Functions obj1 = new Functions();
    String sql;

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void lnkFetch_Click(object sender, EventArgs e)
    {
        sql = "jct_ops_selling_price_dnv";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 0;
        cmd.Parameters.Add("@DateFrom", SqlDbType.VarChar, 20).Value = txtDateFrom.Text;
        cmd.Parameters.Add("@DateTo", SqlDbType.VarChar, 20).Value = txtDateTo.Text;
        cmd.Parameters.Add("@DelDateFrom", SqlDbType.VarChar, 20).Value = txtDelDateFrom.Text;
        cmd.Parameters.Add("@DelDateTo", SqlDbType.VarChar, 20).Value = txtDelDateTo.Text;
        cmd.Parameters.Add("@SortNo", SqlDbType.VarChar, 20).Value = txtSort.Text;
        cmd.Parameters.Add("@OrderNo", SqlDbType.VarChar, 25).Value = txtOrderNo.Text;
        cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 25).Value = ddlPlant.SelectedItem.Text;
        cmd.Parameters.Add("@empcode", SqlDbType.VarChar, 10).Value = Session["EmpCode"];
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new  DataSet();
        da.Fill(ds);
        grdDetail.DataSource = ds.Tables[0];
        grdDetail.DataBind();
    }

    protected void grdDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdDetail.PageIndex = e.NewPageIndex;
        sql = "jct_ops_selling_price_dnv";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 0;
        cmd.Parameters.Add("@DateFrom", SqlDbType.VarChar, 20).Value = txtDateFrom.Text;
        cmd.Parameters.Add("@DateTo", SqlDbType.VarChar, 20).Value = txtDateTo.Text;
        cmd.Parameters.Add("@DelDateFrom", SqlDbType.VarChar, 20).Value = txtDelDateFrom.Text;
        cmd.Parameters.Add("@DelDateTo", SqlDbType.VarChar, 20).Value = txtDelDateTo.Text;
        cmd.Parameters.Add("@SortNo", SqlDbType.VarChar, 20).Value = txtSort.Text;
        cmd.Parameters.Add("@OrderNo", SqlDbType.VarChar, 25).Value = txtOrderNo.Text;
        cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 25).Value = ddlPlant.SelectedItem.Text;
        cmd.Parameters.Add("@empcode", SqlDbType.VarChar, 10).Value = Session["EmpCode"];
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        grdDetail.DataSource = ds.Tables[0];
        grdDetail.DataBind();
    }

    protected void lnkExcel_Click(object sender, EventArgs e)
    {
        sql = "jct_ops_selling_price_dnv";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 0;
        cmd.Parameters.Add("@DateFrom", SqlDbType.VarChar, 20).Value = txtDateFrom.Text;
        cmd.Parameters.Add("@DateTo", SqlDbType.VarChar, 20).Value = txtDateTo.Text;
        cmd.Parameters.Add("@DelDateFrom", SqlDbType.VarChar, 20).Value = txtDelDateFrom.Text;
        cmd.Parameters.Add("@DelDateTo", SqlDbType.VarChar, 20).Value = txtDelDateTo.Text;
        cmd.Parameters.Add("@SortNo", SqlDbType.VarChar, 20).Value = txtSort.Text;
        cmd.Parameters.Add("@OrderNo", SqlDbType.VarChar, 25).Value = txtOrderNo.Text;
        cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 25).Value = ddlPlant.SelectedItem.Text;
        cmd.Parameters.Add("@empcode", SqlDbType.VarChar, 10).Value = Session["EmpCode"];
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        DataTable dt = ds.Tables[0];

        //string attachment = "attachment; filename=SpVsDnV.xls";
        //Response.ClearContent();
        //Response.AddHeader("content-disposition", attachment);
        //Response.ContentType = "application/vnd.ms-excel";
        //string tab = "";
        //foreach (DataColumn dc in dt.Columns)
        //{
        //    Response.Write(tab + dc.ColumnName);
        //    tab = "\t";
        //}
        //Response.Write("\n");
        //int i;
        //foreach (DataRow dr in dt.Rows)
        //{
        //    tab = "";
        //    for (i = 0; i < dt.Columns.Count; i++)
        //    {
        //        Response.Write(tab + dr[i].ToString());
        //        tab = "\t";
        //    }
        //    Response.Write("\n");
        //}
        //Response.End();
        CreateExcelFile(dt);
        Response.ContentType = "application/octet-stream";
        Response.AddHeader("Content-Disposition", string.Format("attachment; filename = {0}", System.IO.Path.GetFileName("SpVsDnV.xls")));
        Response.AppendHeader("Content-Disposition", "attachment; filename=SpVsDnV.xls");
        Response.TransmitFile(Server.MapPath("SpVsDnV.xls"));
        Response.End();
        obj.ConClose();
    }

    public bool CreateExcelFile(DataTable dt)
    {
        bool bFileCreated = false;
        string sTableStart = "<HTML><BODY><TABLE Border=1><TR><TH>Selling Price Vs DnV</TH></TR>";
        string sTableEnd = "</TABLE></BODY></HTML>";
        string sTableData = "";
        int nRow = 0;
        int nCol;
        sTableData += "<TR>";
        for (nCol = 0; nCol <= dt.Columns.Count - 1; nCol++)
        {
            sTableData += "<TD><B>" + dt.Columns[nCol].ColumnName + "</B></TD>";
        }
        sTableData += "</TR>";
        for (nRow = 0; nRow <= dt.Rows.Count - 1; nRow++)
        {
            sTableData += "<TR>";
            for (nCol = 0; nCol <= dt.Columns.Count - 1; nCol++)
            {
                sTableData += "<TD>" + dt.Rows[nRow][nCol].ToString() + "</TD>";
            }
            sTableData += "</TR>";
        }
        string sTable = sTableStart + sTableData + sTableEnd;
        System.IO.StreamWriter oExcelWrite = null;
        string sExcelFile = Server.MapPath("SpVsDnV.xls");
        oExcelWrite = System.IO.File.CreateText(sExcelFile);
        oExcelWrite.WriteLine(sTable);
        oExcelWrite.Close();
        bFileCreated = true;
        return bFileCreated;

    }
    protected void lnkReset_Click(object sender, EventArgs e)
    {
        Response.Redirect("SellingPrice_Vs_DnV");
    }
}