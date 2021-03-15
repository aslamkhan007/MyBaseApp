using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;

public partial class Courier_Tracking_System_Courier_Cost : System.Web.UI.Page
{
    string sql;
    int sum = 0;
    Functions obj1 = new Functions();
    Connection obj = new Connection();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["EmpCode"] == "")
        {
            Response.Redirect("~/login.aspx");
        }
        if (!IsPostBack)
        {
            sql = "Select '  All  ' as [DeptCode],'  All  ' as [DeptName] Union Select DeptCode,DeptName from deptmast order by Deptcode";
            obj1.FillList(ddlDepartment, sql);
            sql = "Select '  All  ' as [Courier_Service],'  All  ' as [Courier_Service] Union Select Courier_Service,Courier_Service from jct_courier_Service_Master where status='A' order by Courier_Service";
            obj1.FillList(ddlCourierService, sql);
            sql = "Select '  All  ' as [CourierType],'  All  ' as [CourierType] Union Select CourierType,CourierType from jct_courier_type_master where status='A' order by CourierType";
            obj1.FillList(ddlCourierType, sql);
           
        }

    }
    protected void lnkfetch_Click(object sender, EventArgs e)
    {
        sql = " Exec jct_courier_TotalCost '"+ txtDateFrom.Text +"','"+ txtDateTo.Text +"','"+ ddlDepartment.SelectedItem.Value  +"','"+ ddlCourierService.SelectedItem.Value +"','"+ ddlCourierType.SelectedItem.Value +"'";
        obj1.FillGrid(sql,ref GridView1);
    }
    protected void ddlDepartment_SelectedIndexChanged(object sender, EventArgs e)
    {
      
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            sum = sum + int.Parse(e.Row.Cells[2].Text);
        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[1].Text = "Total (in Rupees)";
            e.Row.Cells[2].Text = sum.ToString();
        }
    }
    protected void lnkReset_Click(object sender, EventArgs e)
    {
        Response.Redirect("Courier_Cost.aspx");
    }
    protected void lnkExcel_Click(object sender, EventArgs e)
    {
       
      //  GridViewExportUtil.Export("Courier_Cost.xls", GridView1);

        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        DataTable dt = ds.Tables[0];
        CreateExcelFile(dt);
        Response.ContentType = "application/octet-stream";
        Response.AddHeader("Content-Disposition", string.Format("attachment; filename = {0}", System.IO.Path.GetFileName("Courier_Cost.xls")));
        Response.AppendHeader("Content-Disposition", "attachment; filename=Courier_Cost.xls");
        Response.TransmitFile(Server.MapPath("Courier_Cost.xls"));
        Response.End();
        obj.ConClose();
     
    }
    public bool CreateExcelFile(DataTable dt)
    {
        bool bFileCreated = false;
        string sTableStart = "<HTML><BODY><TABLE Border=1><TR><TH>Courier Cost Between " + txtDateFrom.Text + " and " + txtDateTo.Text + " </TH></TR>";
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
        string sExcelFile = Server.MapPath("Courier_Cost.xls");
        oExcelWrite = System.IO.File.CreateText(sExcelFile);
        oExcelWrite.WriteLine(sTable);
        oExcelWrite.Close();
        bFileCreated = true;
        return bFileCreated;

    }


    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        sql = " Exec jct_courier_TotalCost_ToExcel '" + txtDateFrom.Text + "','" + txtDateTo.Text + "','" + ddlDepartment.SelectedItem.Value + "','" + ddlCourierService.SelectedItem.Value + "','" + ddlCourierType.SelectedItem.Value + "' ";
        obj1.FillGrid(sql, ref GridView1);
       // GridViewExportUtil.Export("Courier_Cost.xls", GridView1);

    }
}