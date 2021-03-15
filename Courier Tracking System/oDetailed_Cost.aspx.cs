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
    float sum = 0;
    float total = 0;
    //Boolean flag=false;

    String Date1;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        { 
            if (Request.QueryString["DeptName"] != "")
        {
            BindGrid();
        }
        }
        
        
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        if (   flag.Value == "0")
        {
            GridView1.PageIndex = e.NewPageIndex;
            BindGrid();
        }
        else
        {
            GridView1.PageIndex = e.NewPageIndex;
            sql = "exec jct_courier_Complete_Department_Cost '" + Request.QueryString["DeptName"] + "','" + Date.Value + "'";
            obj1.FillGrid(sql, ref GridView1);
        }
    }
   public void  BindGrid()
    {
        sql = "exec jct_courier_DetailedCost  '" + Session["DateFrom"] + "','" + Session["DateTo"] + "', '" + Request.QueryString["DeptName"] + "'";
        obj1.FillGrid(sql,ref GridView1);
    }

   
   protected void GridView1_RowDataBound1(object sender, GridViewRowEventArgs e)
   {
       if (   flag.Value == "0")
       {
           if (e.Row.RowType == DataControlRowType.DataRow)
           {
               sum = sum + float.Parse(e.Row.Cells[2].Text);
               total = total + float.Parse(e.Row.Cells[3].Text);
           }
           if (e.Row.RowType == DataControlRowType.Footer)
           {
               e.Row.Cells[1].Text = "Total (in Rupees)";
               e.Row.Cells[2].Text = sum.ToString();
               e.Row.Cells[3].Text = total.ToString();
           }
       }
       else
       {
           if (e.Row.RowType == DataControlRowType.DataRow)
           {
               sum = sum + float.Parse(e.Row.Cells[3].Text);
               total = total + float.Parse(e.Row.Cells[4].Text);
           }
           if (e.Row.RowType == DataControlRowType.Footer)
           {
               e.Row.Cells[2].Text = "Total (in Rupees)";
               e.Row.Cells[3].Text = sum.ToString();
               e.Row.Cells[4].Text = total.ToString();
           }
       }

   }
   protected void btnExcel_Click(object sender, EventArgs e)
   {
       sql = " exec jct_courier_DetailedCost '"+ Session["DateFrom"] +"','"+ Session["DateTo"] +"','" + Request.QueryString["DeptName"] + "' ";
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
   protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
   {
       if (e.CommandName == "Select")
       {
           flag.Value = "1";
           Button btn = (Button)e.CommandSource;
           GridViewRow row = (GridViewRow)btn.NamingContainer;
            Date1 = Convert.ToString(GridView1.DataKeys[row.RowIndex].Value);
            Date.Value = Date1;
           sql = "exec jct_courier_Complete_Department_Cost '" + Request.QueryString["DeptName"] + "','"+ Date.Value +"'";
           obj1.FillGrid(sql, ref GridView1);
       }
   }


   protected void btnBack_Click(object sender, EventArgs e)
   {
       flag.Value = "0";
       BindGrid();
   }
   protected void btnExcel1_Click(object sender, EventArgs e)
   {
       btnExcel_Click(sender, e);
   }
   protected void btnBack1_Click(object sender, EventArgs e)
   {
       btnBack_Click(sender, e);
   }
}