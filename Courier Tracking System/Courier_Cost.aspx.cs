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
    float sum = 0;
    float Count = 0;
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
            sql = "Select '--All--' as [DeptCode],'--All--' as [DeptName] Union Select DeptCode,DeptName from deptmast order by Deptcode";
            obj1.FillList(ddlDepartment, sql);
            sql = "Select '--All--' as [ma_center_no],'--All--' as [ma_center_sdesc] Union  SELECT ma_center_no,ma_center_sdesc  FROM miserp.COMMON.dbo.mac_cost_center";
            obj1.FillList(ddlDept, sql);
            sql = "Select '--All--' as [Courier_Service],'--All--' as [Courier_Service] Union Select Courier_Service,Courier_Service from jct_courier_Service_Master where status='A' order by Courier_Service";
            obj1.FillList(ddlCourierService, sql);

           
        }
        //if (txtDateFrom.Text != "" && txtDateTo.Text != "")
        //{

        //    sql = " Exec jct_courier_TotalCost '" + txtDateFrom.Text + "','" + txtDateTo.Text + "','" + ddlDept.SelectedItem.Value + "','" + ddlCourierService.SelectedItem.Value + "'";
        //    obj1.FillGrid(sql, ref GridView2);
        //}

    }
    protected void lnkfetch_Click(object sender, EventArgs e)
    {

            try
        {
            Panel3.Visible = true;
            sum = 0;
            Session["DateFrom"] = txtDateFrom.Text;
            Session["DateTo"] = txtDateTo.Text;
            sql = " Exec JCT_COURIER_GET_LIST_OF_ALL_COURIERS_JATIN '" + txtDateFrom.Text + "','" + txtDateTo.Text + "','" + ddlCourierService.SelectedItem.Value + "'";
            obj1.FillGrid(sql, ref GridView2);
        }
        catch (Exception ex)
        {

        }
  
    
    }
    protected void ddlDepartment_SelectedIndexChanged(object sender, EventArgs e)
    {
      
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[4].Visible = false;
                e.Row.Cells[5].Visible = false;
                e.Row.Cells[6].Visible = false;
                Label lnkCost = (Label)e.Row.Cells[3].FindControl("lnkCost");
                sum = sum + float.Parse(lnkCost.Text);
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[4].Visible = false;
                e.Row.Cells[5].Visible = false;
                e.Row.Cells[6].Visible = false;
                e.Row.Cells[2].Text = "Total (in Rupees)";
                e.Row.Cells[3].Text = sum.ToString();

            }
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[4].Visible = false;
                e.Row.Cells[5].Visible = false;
                e.Row.Cells[6].Visible = false;
            }
        }
        catch (Exception ex)
        { 
        
        }
    
    }

    protected void lnkReset_Click(object sender, EventArgs e)
    {
        Response.Redirect("Courier_Cost.aspx");
    }
   

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        sql = " Exec jct_courier_TotalCost_ToExcel '" + txtDateFrom.Text + "','" + txtDateTo.Text + "','" + ddlDept.SelectedItem.Text + "','" + ddlCourierService.SelectedItem.Text + "','--All--',null";//,'" + ddlCourierType.SelectedItem.Value + "' ";
        obj1.FillGrid(sql, ref GridView1);


    }
   


    protected void lnkExcel_Click(object sender, EventArgs e)
    {
        GridView grd = new GridView();
        sql = " Exec jct_courier_TotalCost_ToExcel '" + txtDateFrom.Text + "','" + txtDateTo.Text + "','" + ddlDept.SelectedItem.Value + "','" + ddlCourierService.SelectedItem.Value + "','--All--',null ";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        DataTable dt = ds.Tables[0];
        //GridView grd = new GridView();
        grd.DataSource = dt;
        grd.DataBind();
        GridViewExportUtil.Export("Courier_Cost_Summary.xls", grd);
        obj.ConClose();

     
        //sql = "JCT_COURIER_GET_LIST_OF_ALL_COURIERS_TOEXCEL";
        //SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        //cmd.CommandType = CommandType.StoredProcedure;
        //cmd.Parameters.AddWithValue("@DATEFROM", txtDateFrom.Text);
        //cmd.Parameters.AddWithValue("@DATETO", txtDateTo.Text);
        //cmd.Parameters.AddWithValue("@COURIERSERVICE", ddlCourierService.SelectedItem.Text);
        //cmd.Parameters.AddWithValue("@COURIER_TYPE", ddlCourierType.SelectedItem.Text);
        //SqlDataAdapter da = new SqlDataAdapter(cmd);
        //DataSet ds = new DataSet();
        //da.Fill(ds);
        
        //grd.DataSource = ds;
        //grd.DataBind();
        //GridViewExportUtil.Export("Courier_Receipt_Checking.xls", grd);
        //obj.ConClose();
        
    }


    protected void GridView1_PageIndexChanging1(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        sql = " Exec jct_courier_TotalCost '" + txtDateFrom.Text + "','" + txtDateTo.Text + "','" + ddlDept.SelectedItem.Text + "','" + ddlCourierService.SelectedItem.Value + "'";
        obj1.FillGrid(sql, ref GridView1);
    }
    protected void ddlDept_SelectedIndexChanged(object sender, EventArgs e)
    {
        sql = " Exec jct_courier_TotalCost '" + txtDateFrom.Text + "','" + txtDateTo.Text + "','" + ddlDept.SelectedItem.Value + "','" + ddlCourierService.SelectedItem.Value + "'";
        obj1.FillGrid(sql, ref GridView1);
    }
    protected void lnkList_Click(object sender, EventArgs e)
    {
        Panel2.Visible = true;
        sum = 0;
        sql = "JCT_COURIER_GET_LIST_OF_ALL_COURIERS";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@DATEFROM", txtDateFrom.Text);
        cmd.Parameters.AddWithValue("@DATETO", txtDateTo.Text);
        cmd.Parameters.AddWithValue("@COURIERSERVICE", ddlCourierService.SelectedItem.Text);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        grdList.DataSource = ds;
        grdList.DataBind();

    }
    protected void grdList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    
        if (e.Row.RowType == DataControlRowType.DataRow)

        {
         
            sum = sum + float.Parse(e.Row.Cells[2].Text.ToString());
           // Count = Count + float.Parse(e.Row.Cells[3].Text.ToString());
        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {

            e.Row.Cells[1].Text = "Total (in Rupees)";
            e.Row.Cells[2].Text = sum.ToString();
          // e.Row.Cells[3].Text = Count.ToString();

        }
      
    }
    //protected void lnkToExcel_Click(object sender, EventArgs e)
    //{
    //    //sql = "JCT_COURIER_GET_LIST_OF_ALL_COURIERS";
    //    //SqlCommand cmd = new SqlCommand(sql, obj.Connection());
    //    //cmd.CommandType = CommandType.StoredProcedure;
    //    //cmd.Parameters.AddWithValue("@DATEFROM", txtDateFrom.Text);
    //    //cmd.Parameters.AddWithValue("@DATETO", txtDateTo.Text);
    //    //cmd.Parameters.AddWithValue("@COURIERSERVICE", ddlCourierService.SelectedItem.Text);
    //    //SqlDataAdapter da = new SqlDataAdapter(cmd);
    //    //DataSet ds = new DataSet();
    //    //da.Fill(ds);
    //    //grdList.DataSource = ds;
    //    //grdList.DataBind();
    //    GridViewExportUtil.Export("Courier_Receipt_Checking.xls", grdList);
    //    obj.ConClose();
    //}

    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                sum = sum + float.Parse(e.Row.Cells[2].Text);

            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[1].Text = "Total (in Rupees)";
                e.Row.Cells[2].Text = sum.ToString();

            }
            if (e.Row.RowType == DataControlRowType.Header)
            {

            }
        }
        catch (Exception ex)
        {

        }
    }
}