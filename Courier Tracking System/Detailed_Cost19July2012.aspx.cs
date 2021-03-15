using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Courier_Tracking_System_Detailed_Cost : System.Web.UI.Page
{
    Connection obj = new Connection();
    Functions obj1 = new Functions();
    string sql;
    TextBox deptname;
    int sum = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["DeptName"] != "")
        {
            BindGrid();
        }
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        BindGrid();
    }
   public void  BindGrid()
    {
        sql = "exec jct_courier_DetailedCost '" + Request.QueryString["DeptName"] + "'";
       obj1.FillGrid(sql,ref GridView1);
    }

   
   protected void GridView1_RowDataBound1(object sender, GridViewRowEventArgs e)
   {


       if (e.Row.RowType == DataControlRowType.DataRow)
       {
           sum = sum + int.Parse(e.Row.Cells[2].Text);


       }

       if (e.Row.RowType == DataControlRowType.Footer)
       {
           e.Row.Cells[1].Text = "Total (in Rupees)";
           e.Row.Cells[2].Text = sum.ToString();
           e.Row.Cells[2].ForeColor.Equals("Blue");
           e.Row.Cells[1].ForeColor.Equals(System.Drawing.Color.Red);
           e.Row.Cells[2].ForeColor.Equals(System.Drawing.Color.Red);
          
       }
   }
   protected void btnExcel_Click(object sender, EventArgs e)
   {

       sql = " exec jct_courier_DetailedCost '" + Request.QueryString["DeptName"] + "' ";
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
       string sTableStart = "<HTML><BODY><TABLE Border=1><TR><TH>Courier Cost of '"+ Request.QueryString["DeptName"] +"'</TH></TR>";
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
}