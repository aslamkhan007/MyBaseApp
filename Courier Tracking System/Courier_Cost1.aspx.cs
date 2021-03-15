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
        if (txtDateFrom.Text != "" && txtDateTo.Text != "")
        {

            sql = " Exec jct_courier_TotalCost '" + txtDateFrom.Text + "','" + txtDateTo.Text + "','" + ddlDept.SelectedItem.Value + "','" + ddlCourierService.SelectedItem.Value + "'";
            obj1.FillGrid(sql, ref GridView1);
        }

    }
    protected void lnkfetch_Click(object sender, EventArgs e)
    {

            try
        {
            sum = 0;
            Session["DateFrom"] = txtDateFrom.Text;
            Session["DateTo"] = txtDateTo.Text;
            sql = " Exec jct_courier_TotalCost '" + txtDateFrom.Text + "','" + txtDateTo.Text + "','" + ddlDept.SelectedItem.Value + "','" + ddlCourierService.SelectedItem.Value + "'";
            obj1.FillGrid(sql, ref GridView1);
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
 
    
        if (e.Row.RowType == DataControlRowType.DataRow)
        {          
            e.Row.Cells[3].Visible=false;
            e.Row.Cells[4].Visible=false;
            e.Row.Cells[5].Visible = false;
           // e.Row.Cells[0].Visible = false;
          //  LinkButton lnkCost = (LinkButton)e.Row.Cells[2].FindControl("lnkCost");
            Label lnkCost = (Label)e.Row.Cells[2].FindControl("lnkCost");
            sum = sum + float.Parse(lnkCost.Text);
        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[3].Visible = false;
            e.Row.Cells[4].Visible = false;
            e.Row.Cells[5].Visible = false;
        //    e.Row.Cells[0].Visible = false;
            e.Row.Cells[1].Text = "Total (in Rupees)";
            e.Row.Cells[2].Text = sum.ToString();
            
        }
        if (e.Row.RowType == DataControlRowType.Header)
        {
            e.Row.Cells[3].Visible = false;
            e.Row.Cells[4].Visible = false;
            e.Row.Cells[5].Visible = false;
         //   e.Row.Cells[0].Visible = false;
        }
    }
    protected void lnkReset_Click(object sender, EventArgs e)
    {
        Response.Redirect("Courier_Cost.aspx");
    }
   

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        sql = " Exec jct_courier_TotalCost_ToExcel '" + txtDateFrom.Text + "','" + txtDateTo.Text + "','" + ddlDept.SelectedItem.Text + "','" + ddlCourierService.SelectedItem.Text + "'";//,'" + ddlCourierType.SelectedItem.Value + "' ";
        obj1.FillGrid(sql, ref GridView1);

    }
   


    protected void lnkExcel_Click(object sender, EventArgs e)
    {
        sql = " Exec jct_courier_TotalCost_ToExcel '" + txtDateFrom.Text + "','" + txtDateTo.Text + "','" + ddlDept.SelectedItem.Value + "','" + ddlCourierService.SelectedItem.Value + "' ";
        SqlCommand cmd = new SqlCommand(sql, obj.Connection());
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        DataTable dt = ds.Tables[0];
        GridView grd = new GridView();
        grd.DataSource = dt;
        grd.DataBind();
        GridViewExportUtil.Export("Courier_Cost_Summary.xls", grd);
        obj.ConClose();
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
}