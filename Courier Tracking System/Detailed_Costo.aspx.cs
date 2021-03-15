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
     string DeptName ;
     static string  Party_Name;
     String dept = "";
     String DateFrom = "";
     String DateTo = "";
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (this.Page.PreviousPage != null)
        {
            GridView GridView1 = (GridView)this.Page.PreviousPage.FindControl("GridView1");
            GridViewRow selectedRow = GridView1.SelectedRow;

             dept= selectedRow.Cells[1].Text ;
             DateFrom= selectedRow.Cells[3].Text;
             DateTo = selectedRow.Cells[4].Text;
        }

           // if (Request.QueryString["DeptName"] != null)
           // {
           //     DeptName = Request.QueryString["DeptName"].ToString();
           //     if (DeptName.Equals(""))
           //     {
           //         BindGrid();
           //     }
           // }

           // if (Request.QueryString["Party_Name"] != null)
           //{
           //   Party_Name = Request.QueryString["Party_Name"].ToString();
           //   BindGrid();
           //}

           // if (Request.QueryString["Dept"] != null)
           // {
           //     dept = Request.QueryString["Dept"].ToString();
           //     BindGrid();
           // }
        
       //if (!Party_Name.Equals(""))
       // {
            
       // }
    }
    protected void grdDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdDetail.PageIndex = e.NewPageIndex;
        BindGrid();
    }
   public void  BindGrid()
    {
        //if (Request.QueryString["DeptName"] != null)
        //{
        //  sql = "exec jct_courier_DetailedCost '" + Request.QueryString["DeptName"] + "','"+ Session["StartDate"] +"','"+ Session["EndDate"] +"'";
        //    obj1.FillGrid(sql, ref GridView1);
        //}

        //if (Request.QueryString["Party_Name"] != null)
        //{
        // sql = "Exec jct_courier_Department_Wise_Report 'All','" + Party_Name + "','" + Session["DateFrom"] + "','" + Session["DateTo"] + "'";
        //    obj1.FillGrid(sql, ref GridView1);
        //}
        //if (Request.QueryString["Dept"] != null)
        //{
        //    sql = "Exec jct_courier_Department_Wise_Report '"+ dept +"','" + Party_Name + "','" + Session["DateFrom"] + "','" + Session["DateTo"] + "'";
        //    obj1.FillGrid(sql, ref GridView1);
        //    btnBack.Visible = true;
        //    btnBack.PostBackUrl = "Detailed_Cost.aspx?Party_Name=" + Party_Name + "";
        //}
       
       // New Code on 19 July 2012 by Jatin . To generate report for receipt entry screen

        sql = "Exec jct_courier_DetailedCost '" + DateFrom + "','"+ DateTo +"','"+ dept +"'";
        obj1.FillGrid(sql, ref grdDetail);
    }

   
   protected void grdDetail_RowDataBound1(object sender, GridViewRowEventArgs e)
   {


       if (e.Row.RowType == DataControlRowType.DataRow)
       {
           sum = sum + int.Parse(e.Row.Cells[3].Text);


       }

       if (e.Row.RowType == DataControlRowType.Footer)
       {
           e.Row.Cells[2].Text = "Total (in Rupees)";
           e.Row.Cells[3].Text = sum.ToString();
           e.Row.Cells[3].ForeColor.Equals("Blue");
           e.Row.Cells[2].ForeColor.Equals(System.Drawing.Color.Red);
           e.Row.Cells[3].ForeColor.Equals(System.Drawing.Color.Red);
          
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
       Response.AddHeader("Content-Disposition", string.Format("attachment; filename = {0}", System.IO.Path.GetFileName("Detailed_Courier_Cost.xls")));
       Response.AppendHeader("Content-Disposition", "attachment; filename=Detailed_Courier_Cost.xls");
       Response.TransmitFile(Server.MapPath("Detailed_Courier_Cost.xls"));
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
       string sExcelFile = Server.MapPath("Detailed_Courier_Cost.xls");
       oExcelWrite = System.IO.File.CreateText(sExcelFile);
       oExcelWrite.WriteLine(sTable);
       oExcelWrite.Close();
       bFileCreated = true;
       return bFileCreated;

   }
   protected void btnBack_Click(object sender, EventArgs e)
   {
     
   }
}